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
    public partial class datatomail_do : PageBase
    {
        public DataToMailInfo dtm = new DataToMailInfo();
        public DataTable DataTypes = new DataTable();
        public string Act = "";

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X"))
                {
                    int DataToMaillID = HTTPRequest.GetInt("did",0);
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        dtm = tbDataToMailInfo.GetDataToMailInfoModel(DataToMaillID);
                    }
                    if (ispost)
                    {
                        dtm.dDataType = HTTPRequest.GetInt("dDataType", 0);
                        dtm.dDateType = HTTPRequest.GetInt("dDateType", 0);
                        dtm.dState = HTTPRequest.GetInt("dState", 0);
                        dtm.dEmail = Utils.ChkSQL(HTTPRequest.GetString("dEmail"));

                        if (Act == "Add")
                        {
                            dtm.dAppendTime = DateTime.Now;
                            if (tbDataToMailInfo.AddDataToMailInfo(dtm) > 0)
                            {
                                AddMsgLine("创建成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            else
                            {
                                AddErrLine("创建失败!");
                                AddScript("window.setTimeout('history.back(1);',1000);");
                            }
                        }
                        if (Act == "Edit")
                        {
                            try
                            {
                                tbDataToMailInfo.UpdateDataToMailInfo(dtm);
                                AddMsgLine("修改成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("修改失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                        }
                    }
                    else
                    {
                        DataTypes = tbDataToMailInfo.GetDataToMailDataTypes();
                        if (Act == "Del")
                        {
                            try
                            {
                                tbDataToMailInfo.DeleteDataToMailInfoList(HTTPRequest.GetString("did"));
                                AddMsgLine("删除成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("删除失败!<br/>" + ex);
                            }
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                }
            }
            else
            {
                AddErrLine("请先登录!");
                SetBackLink("login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
                SetMetaRefresh(1, "login.aspx?referer=" + Utils.UrlEncode(Utils.GetUrlReferrer()));
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 导出数据转发邮件 计划任务";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}