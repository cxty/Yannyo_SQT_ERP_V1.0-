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
    public partial class dataanalysis_fee : PageBase
    {
        public string Act = "";
        public DataTable dList = new DataTable();
        public int StoresID = 0;
        public int Feeid = 0;
        public DateTime bDate = DateTime.Now;
        public DateTime eDate = DateTime.Now;
        public StoresInfo si = new StoresInfo();
        public FeesSubjectInfo fs = new FeesSubjectInfo();
        public decimal AllSumValue = 0;
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Act = HTTPRequest.GetString("Act");
            if (Act.Trim() == "")
            {
                StoresID = HTTPRequest.GetInt("StoresID", 0);
            }else if(Act=="com")
            {
                Feeid = HTTPRequest.GetInt("Feeid", 0);
            }
            try
            {
                bDate = DateTime.Parse(HTTPRequest.GetString("bDate") +"  00:00:00");
                eDate = DateTime.Parse(HTTPRequest.GetString("eDate") + " 23:59:59");
                if (StoresID > 0)
                {
                    si = tbStoresInfo.GetStoresInfoModel(StoresID);
                    dList = DataUtils.Get_Fees_by_StoresID(bDate, eDate, StoresID);
                    if (dList != null)
                    {
                        foreach (DataRow dr in dList.Rows)
                        {
                            AllSumValue += Convert.ToDecimal(dr["mFees"]);
                        }
                    }
                }

                if (Feeid>0)
                {
                    fs = tbFeesSubjectInfo.GetFeesSubjectInfoModel(Feeid);
                    dList = DataUtils.Get_Fees_by_FeesSubjectID(bDate, eDate, Feeid);
                    if (dList != null)
                    {
                        foreach (DataRow dr in dList.Rows)
                        {
                            AllSumValue += Convert.ToDecimal(dr["mFees"]);
                        }
                    }
                }
                if (StoresID <= 0 && Feeid <= 0) {
                    AddErrLine("参数错误!");
                }
            }
            catch(Exception ex) {
                AddErrLine("参数错误!"+ex.Message);
            }
        }
        protected override void ShowPage()
        {
            pagetitle = " 费用明细";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}