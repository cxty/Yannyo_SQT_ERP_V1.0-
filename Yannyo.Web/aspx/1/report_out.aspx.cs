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
    public partial class report_out : PageBase
    {
        public DataTable dList = new DataTable();
        public bool ShowPrice = false;//是否显示金额
        public DateTime bDate = DateTime.Now;
        public DateTime eDate = DateTime.Now;
        public int ReType = 1;//商品=1,供货商=2
        public decimal MoneyAAA, MoneyAA, MoneyA;
        public decimal MoneyBBB, MoneyBB, MoneyB;
        public int NOJoinSales = 0;//剔除联营,不剔除=0,剔除=1,仅联营=2


        public string Act;
        public int checkValue;
        public DataTable dcList = new DataTable();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Act = HTTPRequest.GetString("Act");
            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-3-1"))
                {
            if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-3-2"))
            {
                ShowPrice = true;
            }
                    bDate = (HTTPRequest.GetString("bDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("bDate").Trim()) : Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-1");
                    eDate = (HTTPRequest.GetString("eDate").Trim() != "") ? Convert.ToDateTime(HTTPRequest.GetString("eDate").Trim()) : DateTime.Now;

                    ReType = HTTPRequest.GetInt("ReType", 1);
                    NOJoinSales = HTTPRequest.GetInt("NOJoinSales", 0);
                   
                    checkValue = HTTPRequest.GetInt("checkValue",0);
                    if (ispost)
                    {
                        dList = DataUtils.GetOutReport(ReType, bDate, eDate, NOJoinSales);
                    }
                    else
                    {
                        if (Act.IndexOf("Export") > -1)
                        {
                            if (ReType == 1)
                            {
                                dcList = DataUtils.GetOutReport(ReType, bDate, eDate, NOJoinSales);
                                DataTable dt = dcList.Copy();
                                dt.Columns.RemoveAt(0);
                                dt.Columns.RemoveAt(0);
                                dt.Columns.RemoveAt(2);
                                dt.Columns.RemoveAt(2);
                                dt.Columns.RemoveAt(2);
                                dt.Columns.RemoveAt(2);
                                dt.Columns.RemoveAt(2);
                                dt.Columns.RemoveAt(3);
                                dt.Columns.RemoveAt(3);
                                dt.Columns.RemoveAt(3);
                                dt.Columns.RemoveAt(3);
                                dt.Columns.RemoveAt(3);
                                dt.Columns.RemoveAt(3);
                                dt.Columns.RemoveAt(3);
                                DataSet ds = new DataSet();
                                ds.Tables.Add(dt);

                                ds.Tables[0].Columns[0].ColumnName = "商品条码";
                                ds.Tables[0].Columns[1].ColumnName = "商品名称";
                                ds.Tables[0].Columns[2].ColumnName = "装件数";
                                ds.Tables[0].Columns[3].ColumnName = "出货数量";
                                ds.Tables[0].Columns[4].ColumnName = "出货金额";
                                ds.Tables[0].Columns[5].ColumnName = "退货数量";
                                ds.Tables[0].Columns[6].ColumnName = "退货金额";
                                CreateExcel(ds.Tables[0], "Island_Shipment_Data_" + DateTime.Now.ToShortDateString() + ".xls");
                            }
                            if (ReType == 2)
                            {
                                dcList = DataUtils.GetOutReport(ReType, bDate, eDate, NOJoinSales);
                                DataTable dt = dcList.Copy();
                                dt.Columns.RemoveAt(0);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(1);
                                dt.Columns.RemoveAt(2);
                                DataSet ds = new DataSet();
                                ds.Tables.Add(dt);

                                ds.Tables[0].Columns[0].ColumnName = "门店名称";
                                ds.Tables[0].Columns[1].ColumnName = "出货金额";
                                ds.Tables[0].Columns[2].ColumnName = "退货金额";
                                CreateExcel(ds.Tables[0], "Island_Shipment_Data_" + DateTime.Now.ToShortDateString() + ".xls");
                            }
                        }
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
            pagetitle = " 出库统计";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}