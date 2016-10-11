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
    public partial class staff_do_updown : PageBase
    {
        public DataTable dList = new DataTable();
        public string Act = "";
        public int StaffID = 0;
        public string tSidStr = "";
        public int sType = 0;//人员类型,公司=0,业务员=1,促销员=2,其他=3
        public DateTime aDate = DateTime.Now;
        public StaffInfo si = new StaffInfo();

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Act = HTTPRequest.GetString("Act");
            StaffID = HTTPRequest.GetInt("sid", 0);

            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("4-2-1") || CheckUserPopedoms("4-2-2"))
                {
                    if (StaffID > 0)
                    {
                        si = tbStaffInfo.GetStaffInfoModel(StaffID);
                        if (ispost)
                        {
                            tSidStr = Utils.ChkSQL(HTTPRequest.GetString("tSidStr"));
                            aDate = DateTime.Parse(HTTPRequest.GetString("aDate"));

                            StaffStoresInfo ssi = new StaffStoresInfo();
                            try
                            {
                                string[] tSidStrArray = Utils.SplitString(tSidStr, ",");
                                if (Act == "Up")
                                {
                                    if (si.sType == 1 || si.sType == 2)
                                    {
                                        if (tSidStr.Trim() != "")
                                        {
                                            foreach (string sid in tSidStrArray)
                                            {
                                                if (sid.Trim() != "")
                                                {
                                                    ssi.StoresID = Utils.StrToInt(sid.Trim(), 0);
                                                    ssi.StaffID = StaffID;
                                                    ssi.sType = 0;
                                                    ssi.sDateTime = aDate;
                                                    ssi.sAppendTime = DateTime.Now;

                                                    tbStaffStoresInfo.AddStaffStoresInfo(ssi);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            AddErrLine("请选择门店客户!");
                                            AddScript("window.setTimeout('history.back(1);',2000);");
                                        }
                                    }
                                    else
                                    {
                                        ssi.StoresID = -1;
                                        ssi.StaffID = StaffID;
                                        ssi.sType = 0;
                                        ssi.sDateTime = aDate;
                                        ssi.sAppendTime = DateTime.Now;

                                        tbStaffStoresInfo.AddStaffStoresInfo(ssi);
                                    }
                                }
                                if (Act == "Down")
                                {
                                    if (si.sType == 1 || si.sType == 2)
                                    {
                                        if (tSidStr.Trim() != "")
                                        {
                                            foreach (string sid in tSidStrArray)
                                            {
                                                if (sid.Trim() != "")
                                                {
                                                    ssi.StoresID = Utils.StrToInt(sid.Trim(), 0);
                                                    ssi.StaffID = StaffID;
                                                    ssi.sType = 1;
                                                    ssi.sDateTime = aDate;
                                                    ssi.sAppendTime = DateTime.Now;

                                                    tbStaffStoresInfo.AddStaffStoresInfo(ssi);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            AddErrLine("请选择门店客户!");
                                            AddScript("window.setTimeout('history.back(1);',2000);");
                                        }
                                    }
                                    else
                                    {
                                        ssi.StoresID = -1;
                                        ssi.StaffID = StaffID;
                                        ssi.sType = 1;
                                        ssi.sDateTime = aDate;
                                        ssi.sAppendTime = DateTime.Now;

                                        tbStaffStoresInfo.AddStaffStoresInfo(ssi);
                                    }
                                }
                                AddMsgLine("操作成功!");
                                AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                            }
                            finally
                            {
                                ssi = null;
                            }

                        }
                        else
                        {
                            if (Act == "Up")
                            {
                                sType = si.sType;
                                //需过滤当前已有人员在岗记录
                                dList = tbStoresInfo.GetStoresInfoList(" sState=0 and " +
                                                                                            " StoresID not in( " +
                                                                                            " select ss.StoresID from tbStaffStoresInfo ss " +
                                                                                            " where ss.sType=0 and ss.StaffID in(select StaffID from tbStaffInfo where sType =" + sType + ") " +
                                                                                            " and ss.StaffID not in(select StaffID from tbStaffStoresInfo where StoresID=ss.StoresID and StaffID in(select StaffID from tbStaffInfo where sType =" + sType + ") and sType=1 and sDateTime<GETDATE()) " +
                                                                                            " ) " +
                                                                                            " order by CustomersClassID,StoresID desc").Tables[0];
                            }
                            if (Act == "Down")
                            {
                                dList = tbStaffStoresInfo.GetStaff_StoresList(StaffID, DateTime.Now.AddYears(-100), DateTime.Now, -1);

                                DataView view = new DataView();
                                view.Table = dList;
                                view.RowFilter = "edate > '" + DateTime.Now + "'";//离岗时间大于当前的
                                dList = view.ToTable();

                            }
                        }
                    }
                    else
                    {
                        AddErrLine("参数错误,请重试!");
                        AddScript("window.setTimeout('history.back(1);',2000);");
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
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
            pagetitle = " 人员上岗离岗管理";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
