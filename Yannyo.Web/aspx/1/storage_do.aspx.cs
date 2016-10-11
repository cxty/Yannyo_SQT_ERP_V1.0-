using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

namespace Yannyo.Web
{
    public partial class storage_do : PageBase
    {
        public StorageInfo si = new StorageInfo();
        public string Act = "";
        public int StorageID = 0;
        public string strStorage;   //获得分类
        public int StorageClassID;
        public string format = "";
        public string tJson = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Act = HTTPRequest.GetString("Act");
            format = HTTPRequest.GetString("format");
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("2-2-1"))
                {
                    
                    if (Act == "Edit")
                    {
                        StorageID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);

                        si = tbStorageInfo.GetStorageInfoModel(StorageID);
                    }
                    if (ispost)
                    {

                        if (HTTPRequest.GetInt("sManager", 0) > 0)
                        {
                            if (Utils.ChkSQL(HTTPRequest.GetString("sName")).Trim() != "")
                            {
                                si.sManager = HTTPRequest.GetInt("sManager", 0);
                                si.sTel = Utils.ChkSQL(HTTPRequest.GetString("sTel"));
                                si.sAddress = Utils.ChkSQL(HTTPRequest.GetString("sAddress"));
                                si.sRemake = Utils.ChkSQL(HTTPRequest.GetString("sRemake"));
                                si.StorageClassID = HTTPRequest.GetInt("StorageClassID", 0);
                                si.sState = HTTPRequest.GetInt("sState", 1);

                                if (Act == "Add")
                                {
                                    si.sCode = Utils.ChkSQL(HTTPRequest.GetString("sCode"));
                                    si.sName = Utils.ChkSQL(HTTPRequest.GetString("sName"));

                                    if (!tbStorageInfo.ExistsStorageInfo(si.sName))
                                    {
                                        if (!tbStorageInfo.ExistsStorageInfoByCode(si.sCode))
                                        {
                                            si.sAppendTime = DateTime.Now;
                                            if (tbStorageInfo.AddStorageInfo(si) > 0)
                                            {
                                                Logs.AddEventLog(this.userid, "新增仓库."+si.sName);
                                                AddMsgLine("创建成功!");
                                                AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                                            }
                                            else
                                            {
                                                AddErrLine("创建失败!");
                                                AddScript("window.setTimeout('history.back(1);',2000);");
                                            }
                                        }
                                        else
                                        {
                                            AddErrLine("仓库编码重复!");
                                            AddScript("window.setTimeout('history.back(1);',2000);");
                                        }
                                    }
                                    else
                                    {
                                        AddErrLine("仓库名称重复!");
                                        AddScript("window.setTimeout('history.back(1);',2000);");
                                    }
                                }
                                if (Act == "Edit")
                                {
                                    try
                                    {
                                        if (si.sCode.Trim() != Utils.ChkSQL(HTTPRequest.GetString("sCode")).Trim() && tbStorageInfo.ExistsStorageInfoByCode(Utils.ChkSQL(HTTPRequest.GetString("sCode")).Trim()))
                                        {
                                            AddErrLine("仓库编码重复!");
                                            AddScript("window.setTimeout('history.back(1);',2000);");
                                        }
                                        else if (si.sName.Trim() != Utils.ChkSQL(HTTPRequest.GetString("sName")).Trim() && tbStorageInfo.ExistsStorageInfo(Utils.ChkSQL(HTTPRequest.GetString("sName")).Trim()))
                                        {
                                            AddErrLine("仓库名称重复!");
                                            AddScript("window.setTimeout('history.back(1);',2000);");
                                        }
                                        else {
                                            si.sCode = Utils.ChkSQL(HTTPRequest.GetString("sCode")).Trim();
                                            si.sName = Utils.ChkSQL(HTTPRequest.GetString("sName")).Trim();

                                            tbStorageInfo.UpdateStorageInfo(si);
                                            Logs.AddEventLog(this.userid, "修改仓库."+si.sName);
                                            AddMsgLine("修改成功!");
                                            AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                                        }                                     
                                    }
                                    catch (Exception ex)
                                    {
                                        AddErrLine("修改失败!<br/>" + ex);
                                        AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                                    }
                                }
                            }
                            else
                            {
                                AddErrLine("仓库名称不能为空!");
                                AddScript("window.setTimeout('history.back(1);',2000);");
                            }
                        }
                        else
                        {
                            AddErrLine("管理员不能为空!");
                            AddScript("window.setTimeout('history.back(1);',2000);");
                        }
                        Caches.ReSet();
                    }
                    else
                    {
                        //获得分类
                        strStorage = DataClass.GetStorageClassInfoToHTML();

                        if (Act == "Del")
                        {
                            try
                            {
                                tbStorageInfo.DeleteStorageInfo(HTTPRequest.GetString("sid"));
                                Logs.AddEventLog(this.userid, "删除仓库." + HTTPRequest.GetString("sid"));
                                AddMsgLine("删除成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("删除失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                            }
                        }
                        if (Act == "State")
                        {
                            try
                            {
                                StorageID = Utils.StrToInt(HTTPRequest.GetString("sid"), 0);
                                tJson = ",\"StorageID\":" + StorageID + "";

                                si = tbStorageInfo.GetStorageInfoModel(StorageID);

                                si.sState = si.sState == 0 ? 1 : 0;
                                tJson += ",\"StorageState\":" + si.sState;
                                tbStorageInfo.UpdateStorageInfo(si);
                                AddMsgLine("成功!");

                                Logs.AddEventLog(this.userid, "修改仓库状态." + si.sName + ",为:" + (si.sState==0?"正常":"屏蔽"));
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("失败!<br/>" + ex);
                            }
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                }
            }
            else
            {
                AddErrLine("请先登录!");
                SetBackLink("login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
                SetMetaRefresh(1, "login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
            }

            if (format == "json")
            {
                Response.ClearContent();
                Response.Buffer = true;
                Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
                Response.Expires = 0;

                Response.Charset = "utf-8";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                Response.ContentType = "application/json";
                string Json_Str = "{\"results\": {\"msg\":\"" + this.msgbox_text + "\",\"state\":\"" + (!IsErr()).ToString() + "\"" + tJson + "}}";
                Response.Write(Json_Str);
                Response.End();
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 添加修改仓库信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}