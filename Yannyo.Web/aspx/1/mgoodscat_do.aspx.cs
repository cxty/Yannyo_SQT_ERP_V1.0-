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
using Yannyo.Cache;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

namespace Yannyo.Web
{
    public partial class mgoodscat_do : MPageBase
    {
        public string Act = "";
        public string restr = "";
        public string reformat = "";
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("8-1-1") || CheckUserPopedoms("8-1-2") || CheckUserPopedoms("8-1-3"))
                {
                    Act = HTTPRequest.GetString("Act");
                    reformat = HTTPRequest.GetString("reformat");
                    if (Act == "download")
                    {
                        if (ispost)
                        {
                            M_Utils.DeleteM_GoodsCatAll(M_Config.m_ConfigInfoID);
                            if (TopApiUtils.GetGoodsCatListAll(M_Config, 0))
                            {
                                AddMsgLine("商品类目更新成功!");
                            }else{
                                AddErrLine("商品类目更新失败!");
                            }
                        }
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.parent.HidBox();");
                }
                if (reformat == "json")
                {
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
                    Response.Expires = 0;

                    Response.Charset = "utf-8";
                    Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                    Response.ContentType = "application/json";
                    string Json_Str = "{\"results\": {\"msg\":\"" + this.msgbox_text + "\",\"state\":\"" + (!IsErr()).ToString() + "\"}}";
                    Response.Write(Json_Str);
                    Response.End();
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
            pagetitle = " 网店商品列表";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}