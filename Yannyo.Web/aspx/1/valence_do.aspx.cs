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
    public partial class valence_do : PageBase
    {
        public ValenceInfo vi = new ValenceInfo();
        public string Act = "";
        public int ValenceID = 0;
        public int ProductsID = 0;
        public float vPrice = 0;
        public DateTime bDateTime = DateTime.Now;
        public DateTime eDateTime = DateTime.Now;
        public DateTime vAppendTime = DateTime.Now;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        ValenceID = Utils.StrToInt(HTTPRequest.GetString("vid"), 0);

                        vi = tbValenceInfo.GetValenceInfoModel(ValenceID);
                    }
                    if (ispost)
                    {
                        ProductsID = Utils.StrToInt(Utils.ChkSQL(HTTPRequest.GetString("ProductsID")), 0);
                        vPrice = Utils.StrToFloat(Utils.ChkSQL(HTTPRequest.GetString("vPrice")), 0);
                        bDateTime = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("bDateTime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("bDateTime"))) : DateTime.Now;
                        eDateTime = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("eDateTime"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("eDateTime"))) : DateTime.Now;

                        vi.ProductsID = ProductsID;
                        vi.vPrice = decimal.Parse(vPrice.ToString());
                        vi.bDateTime = bDateTime;
                        vi.eDateTime = eDateTime;

                        if (ProductsID > 0)
                        {
                            if (Act == "Add")
                            {
                                vi.vAppendTime = vAppendTime;
                                if (tbValenceInfo.AddValenceInfo(vi) > 0)
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
                                    tbValenceInfo.UpdateValenceInfo(vi);
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
                        if (Act == "Del")
                        {
                            try
                            {
                                tbValenceInfo.DeleteValenceInfo(HTTPRequest.GetString("vid"));
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
            pagetitle = " 添加修改变价数据";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
