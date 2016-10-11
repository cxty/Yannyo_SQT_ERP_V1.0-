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
    public partial class gifts_do : PageBase
    {
        public GiftsInfo gi = new GiftsInfo();
        public string Act = "";
        public int GiftsID = 0;
        public int ProductsID = 0;
        public int StoresID = 0;
        public int gNum = 0;
        public DateTime gDateTime = DateTime.Now;
        public DateTime gAppendTime = DateTime.Now;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        GiftsID = Utils.StrToInt(HTTPRequest.GetString("gid"), 0);

                        gi = tbGiftsInfo.GetGiftsInfoModel(GiftsID);
                    }
                    if (ispost)
                    {
                        StoresID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("StoresID")), 0);
                        ProductsID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("ProductsID")), 0);
                        gNum = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("gNum")), 0);
                        gDateTime = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("gDateTime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("gDateTime"))) : DateTime.Now;

                        gi.StoresID = StoresID;
                        gi.ProductsID = ProductsID;
                        gi.gNum = gNum;
                        gi.gDateTime = gDateTime;
                        if (StoresID > 0)
                        {
                            if (ProductsID > 0)
                            {
                                if (Act == "Add")
                                {
                                    gi.gAppendTime = gAppendTime;
                                    if (tbGiftsInfo.AddGiftsInfo(gi) > 0)
                                    {
                                        AddMsgLine("创建成功!");
                                        AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                    }
                                    else
                                    {
                                        AddErrLine("创建失败!");
                                        AddScript("history.back(1);");
                                    }
                                }
                                if (Act == "Edit")
                                {
                                    try
                                    {
                                        tbGiftsInfo.UpdateGiftsInfo(gi);
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
                                AddErrLine("产品不能为空!");
                                AddScript("history.back(1);");
                            }
                        }
                        else
                        {
                            AddErrLine("门店不能为空!");
                            AddScript("history.back(1);");
                        }
                    }
                    else
                    {
                        if (Act == "Del")
                        {
                            try
                            {
                                tbGiftsInfo.DeleteGiftsInfo(HTTPRequest.GetString("gid"));
                                AddMsgLine("删除成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                            catch (Exception ex)
                            {
                                AddErrLine("删除失败!<br/>" + ex);
                                AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                            }
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.parent.HidBox();");
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
            pagetitle = " 添加修改赠品数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
