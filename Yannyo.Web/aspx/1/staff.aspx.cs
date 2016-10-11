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
    public partial class staff : PageBase
    {
        public DataTable dList = new DataTable();
        public int pagesize;
        public int pageindex;
        public int pagetotal;

        public string Act = "";
        public string S_key = "";
        public int sType = -1;
        public int sState = -1;
        public int DepartmentsClassID = 0;//部门编号
        public DepartmentsClassInfo Departments = new DepartmentsClassInfo();

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            pagesize = 20;
            PageBarHTML = "";
            string tSQL = " 1=1 ";
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("4-1"))
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
                    }
                    else
                    {
                        Act = HTTPRequest.GetQueryString("Act");
                        S_key = Utils.ChkSQL(HTTPRequest.GetQueryString("S_key"));
                    }
                    sType = HTTPRequest.GetInt("sType", -1);
                    sState = HTTPRequest.GetInt("sState", -1);

                    DepartmentsClassID = HTTPRequest.GetInt("DepartmentsClassID",0);
                    if (sType > -1)
                    {
                        tSQL += " and sType=" + sType + " ";
                    }
                    if (sState > -1)
                    {
                        tSQL += " and sState=" + sState + " ";
                    }
                    if (DepartmentsClassID > 0)
                    {
                        Departments = DataClass.GetDepartmentsClassInfoModel(DepartmentsClassID);
                        string DepartmentsClassIDStr = DataClass.GetDepartmentsClassChildStr(DepartmentsClassID);
                        DepartmentsClassIDStr = DepartmentsClassIDStr.Trim() != "" ? DepartmentsClassIDStr + "," + DepartmentsClassID.ToString() : DepartmentsClassID.ToString();
                        tSQL += " and DepartmentsClassID in(" + DepartmentsClassIDStr + ")";
                    }
                    if (Act.Trim() == "Search" && S_key.Trim() != "")
                    {
                        tSQL += " and sName like '%" + S_key.Trim() + "%' ";
                    }
                    dList = tbStaffInfo.GetStaffInfoList(pagesize, pageindex, tSQL, out pagetotal, 1, "*");
                    PageBarHTML = Utils.TenPage(pageindex, pagetotal, 0, "&Act=" + Act + "&S_key=" + S_key + "&sType=" + sType + "&sState=" + sState + "&DepartmentsClassID=" + DepartmentsClassID);
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
            pagetitle = " 人员管理";
            this.Load += new EventHandler(this.Page_Load);
        }
        public string GetDepartmentsPaterStr(string rID)
        {
            return DataClass.GetDepartmentsClassPaterStr(Utils.StrToInt(rID, 0),"/"); 
        }
    }
}
