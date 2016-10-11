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
    public partial class staffstores : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;
        public string Act = "";
        public string S_key = "";
        public string StoresName = "";//门店
        public int sType = -1;//发生类型,上岗=0,离岗=1

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 20;
            PageBarHTML = "  ";
            string tSQL = " tbStaffStoresInfo.StaffStoresID<>0 ";

            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("4-2"))
                {
                    if (HTTPRequest.GetString("page").Trim() != "" && Utils.IsInt(HTTPRequest.GetString("page").Trim()))
                    {
                        pageindex = int.Parse(HTTPRequest.GetString("page").Trim());
                    }
                    else
                    {
                        pageindex = 1;
                    }
                    if (ispost)
                    {
                        Act = HTTPRequest.GetFormString("Act");
                        S_key = Utils.ChkSQL(HTTPRequest.GetFormString("S_key"));
                        StoresName = Utils.ChkSQL(HTTPRequest.GetFormString("StoresName"));
                        sType = HTTPRequest.GetFormInt("sType", -1);
                    }
                    else
                    {
                        Act = HTTPRequest.GetQueryString("Act");
                        S_key = Utils.ChkSQL(HTTPRequest.GetQueryString("S_key"));
                        StoresName = Utils.ChkSQL(HTTPRequest.GetQueryString("StoresName"));
                        sType = HTTPRequest.GetQueryInt("sType", -1);
                    }

                    if (Act.Trim() == "Search" && S_key.Trim() != "")
                    {
                        tSQL = tSQL + " and tbStaffStoresInfo.StaffID in (select StaffID from tbStaffInfo where tbStaffInfo.sName like'%" + S_key + "%') ";
                    }
                    if (Act.Trim() == "SearchB")
                    {

                    }
                    if (StoresName.Trim() != "")
                    {
                        tSQL = tSQL + " and tbStaffStoresInfo.StoresID in (select StoresID from tbStoresInfo where tbStoresInfo.sName like'%" + StoresName.Trim() + "%') ";
                    }
                    if (sType > -1)
                    {
                        tSQL = tSQL + " and tbStaffStoresInfo.sType=" + sType + " ";
                    }
                    if (Act.Trim() == "SearchB")
                    {
                        dList = tbStaffStoresInfo.GetStaff_StoresList(0, DateTime.Now.AddYears(-100), DateTime.Now, -1);

                        DataView view = new DataView();
                        view.Table = dList;
                        view.RowFilter = "edate > '" + DateTime.Now + "'";//离岗时间大于当前的
                        view.Sort = "StaffID DESC,StoresID DESC";
                        dList = view.ToTable();

                    }
                    else if (Act.Trim() == "SearchC")
                    {
                        dList = tbStaffStoresInfo.GetStaff_StoresList(0, DateTime.Now.AddYears(-100), DateTime.Now, -1);
                        DataView view = new DataView();
                        view.Table = dList;

                        view.Sort = "StaffID DESC,StoresID DESC";
                        dList = view.ToTable();
                    }
                    else
                    {
                        dList = tbStaffStoresInfo.GetStaffStoresInfoList(pagesize, pageindex, tSQL, out pagetotal, 1, "*,(select sName from tbStoresInfo where StoresID=tbStaffStoresInfo.StoresID) as StoresName,(select sName from tbStaffInfo where StaffID=tbStaffStoresInfo.StaffID) as StaffName");

                        PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&Act=" + Act + "&S_key=" + S_key + "&StoresName=" + StoresName + "&sType=" + sType);
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
            pagetitle = " 人员门店管理";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
