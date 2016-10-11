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
    public partial class apmoney_importdata : PageBase
    {
        public DataTable dList = new DataTable();
        public string Act = Utils.ChkSQL(HTTPRequest.GetString("Act"));
        public DateTime bDate = DateTime.Parse(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-01 00:00:00"));
        public DateTime eDate = DateTime.Parse(DateTime.Now.AddMonths(1).AddDays(DateTime.Now.Day * -1).ToString("yyyy-MM-dd 23:59:59"));
        public int loop_count = 0;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (ispost)
            {
                //if (Act == "Search")
                {
                    if (HTTPRequest.GetString("bDate").Trim() != "")
                    {
                        bDate = DateTime.Parse(HTTPRequest.GetString("bDate").Trim() + " 00:00:00");
                    }
                    if (HTTPRequest.GetString("eDate").Trim() != "")
                    {
                        eDate = DateTime.Parse(HTTPRequest.GetString("eDate").Trim() + " 23:59:59");
                    }
                }
                if (Act == "OK")
                {
                    loop_count = HTTPRequest.GetInt("loop_count", 0);
                    if (loop_count > 0)
                    {
                        int SupplierID = 0;
                        APMoneyInfo ap = new APMoneyInfo();
                        string odIDStr = "";
                        int tCount = 0;
                        decimal nMoney = 0;
                        decimal tMoney = 0;
                        
                        for (int i = 0; i < loop_count; i++)
                        {
                            SupplierID = HTTPRequest.GetInt("_SupplierID_" + i, 0);
                            if (SupplierID > 0)
                            {
                                nMoney = decimal.Parse(HTTPRequest.GetString("_nMoney_" + i).ToString());
                                tMoney = decimal.Parse(HTTPRequest.GetString("_tMoney_" + i).ToString());
                                odIDStr = "";

                                ap.APObjID = SupplierID;
                                ap.APObjType = 2;
                                ap.aPMoney = nMoney;
                                ap.aPayMoney = tMoney;
                                ap.aOtherMoney = 0;
                                ap.FeesSubjectID = 0;
                                ap.aReMake = "";
                                ap.aDoDateTime = DateTime.Now;
                                ap.aAppendTime = DateTime.Now;

                                ap.APMoneyID = tbAPMoneyInfo.AddAPMoneyInfo(ap);

                                if (ap.APMoneyID > 0)
                                {
                                    //给单据打标记,标明为"已对账"
                                    //取出该供货商下所有指定订单编号
                                    odIDStr = tbErpOrderInfo.GetErpOrderIDStr(ap.APObjID, 4, eDate);//入库
                                    odIDStr = odIDStr + "," + tbErpOrderInfo.GetErpOrderIDStr(ap.APObjID, 8, eDate);//退货
                                    ap.aErpOrderIDStr = odIDStr;

                                    try
                                    {
                                        tbErpOrderInfo.UpdateErpOrderCheck(ap.APObjID, 4, eDate, 1);//发货
                                        tbErpOrderInfo.UpdateErpOrderCheck(ap.APObjID, 8, eDate, 1);//退货

                                        tbAPMoneyInfo.UpdateAPMoneyInfo(ap);
                                    }
                                    catch
                                    {

                                    }
                                    tCount++;
                                }
                            }
                        }

                        AddMsgLine("导入成功,共导入 <b>" + tCount + "</b> 家客户,门店应收数据!");
                        AddScript("window.setTimeout('window.parent.HidBox();',3000);");
                    }
                }
            }
            dList = tbAPMoneyInfo.GetErpWillPay(bDate, eDate);
            if (dList != null)
            {
                dList.Columns.Add("tMoney", typeof(decimal));
                dList.Columns.Add("nMoney", typeof(decimal));
                foreach (DataRow dr in dList.Rows)
                {
                    //实际应付
                    dr["tMoney"] = decimal.Parse(dr["sDoDayMoney"].ToString()) + (decimal.Parse(dr["DeliveryMoney"].ToString()) - decimal.Parse(dr["ReturnMoney"].ToString())) + (decimal.Parse(dr["AMoney"].ToString()) - decimal.Parse(dr["ActualMoney"].ToString()));
                    //新增应付
                    dr["nMoney"] = decimal.Parse(dr["DeliveryMoney"].ToString()) - decimal.Parse(dr["ReturnMoney"].ToString());
                }
            }
            DataView dv = dList.DefaultView;
            dv.Sort = "tMoney desc";
            dList = dv.ToTable();
            /*
            if (Act == "OK")
            {
                APMoneyInfo ap = new APMoneyInfo();
                string odIDStr = "";
                int tCount = 0;

                foreach (DataRow dr2 in dList.Rows)
                {
                    if (decimal.Parse(dr2["nMoney"].ToString()) != 0)
                    {
                        odIDStr = "";

                        ap.APObjID = int.Parse(dr2["SupplierID"].ToString());
                        ap.APObjType = 0;
                        ap.aPMoney = decimal.Parse(dr2["nMoney"].ToString());
                        ap.aPayMoney = 0;
                        ap.aOtherMoney = 0;
                        ap.FeesSubjectID = 0;
                        ap.aReMake = "";
                        ap.aDoDateTime = DateTime.Now;
                        ap.aAppendTime = DateTime.Now;
                        

                        ap.APMoneyID = tbAPMoneyInfo.AddAPMoneyInfo(ap);

                        if (ap.APMoneyID > 0)
                        {
                            //给单据打标记,标明为"已对账"
                            //取出该供货商下所有指定订单编号
                            odIDStr = tbErpOrderInfo.GetErpOrderIDStr(ap.APObjID, 4, eDate);//入库
                            odIDStr = odIDStr + "," + tbErpOrderInfo.GetErpOrderIDStr(ap.APObjID, 8, eDate);//退货
                            ap.aErpOrderIDStr = odIDStr;

                            try
                            {
                                tbErpOrderInfo.UpdateErpOrderCheck(ap.APObjID, 4, eDate, 1);//发货
                                tbErpOrderInfo.UpdateErpOrderCheck(ap.APObjID, 8, eDate, 1);//退货

                                tbAPMoneyInfo.UpdateAPMoneyInfo(ap);
                            }
                            catch
                            {

                            }
                            tCount++;
                        }
                    }
                }
                AddMsgLine("导入成功,共导入 <b>" + tCount + "</b> 家客户,门店应收数据!");
                AddScript("window.setTimeout('window.parent.HidBox();',3000);");
            }
             */

        }
        protected override void ShowPage()
        {
            pagetitle = " 导入供货商应付账款";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
