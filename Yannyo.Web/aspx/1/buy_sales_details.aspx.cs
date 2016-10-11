using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Net;

using Yannyo.Common;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.BLL;
using Yannyo.Public;

namespace Yannyo.Web
{
    public partial class buy_sales_details : PageBase
    {
        public DataTable sList = new DataTable();      //客户明细列表:页面加载时
        public DataTable spList = new DataTable();     //查询时候：客户明细列表
        public DateTime sDate = DateTime.Now;          //开始日期
        public DateTime stDate = DateTime.Now;         //结束日期
        public int selectClasses;                      //查询类别 0=客户；1=品牌；2=单品；3=区域；4=业务员
        public decimal sumA, sumB, sumC, sumD, sumE;   //统计数量
        public decimal sumAA, sumBB, sumCC, sumDD, sumEE;//统计金额
        public string Act;

        protected void Page_Load(object sender, EventArgs e)
        {
           if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-7-1"))
                {
                    sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now.AddDays(-(DateTime.Now.Day)+1);
                    stDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) : DateTime.Now;
                    Act = HTTPRequest.GetString("Act");
                    selectClasses = HTTPRequest.GetInt("getCategory", 0);
                    if (ispost)
                    {
                        //客户明细
                        if (selectClasses == 0)
                        {
                            spList = buySaleDetailsOfClasses.getBuySaleDetalsOfStorehouse(sDate, stDate, selectClasses);
                        }
                        //品牌明细
                        if (selectClasses == 1)
                        {
                            spList = buySaleDetailsOfClasses.getBuySaleDetalsOfStorehouse(sDate, stDate, selectClasses);
                        }
                        //单品明细
                        if (selectClasses == 2)
                        {
                            spList = buySaleDetailsOfClasses.getBuySaleDetalsOfStorehouse(sDate, stDate, selectClasses);
                        }
                        //区域明细
                        if (selectClasses == 3)
                        {
                            spList = buySaleDetailsOfClasses.getBuySaleDetalsOfStorehouse(sDate, stDate, selectClasses);
                        }
                        //业务员明细
                        if (selectClasses == 4)
                        {
                            spList = buySaleDetailsOfClasses.getBuySaleDetalsOfStorehouse(sDate, stDate, selectClasses);
                        }
                    }
                    else 
                    {
                        if (Act.IndexOf("act") > -1)
                        {
                            spList = buySaleDetailsOfClasses.getBuySaleDetalsOfStorehouse(sDate, stDate, selectClasses);
                            DataTable dt = new DataTable();
                            DataSet ds = new DataSet();
                            dt = spList.Copy();
                            ds.Tables.Add(dt);

                            if (selectClasses == 0)
                            {
                                ds.Tables[0].Columns[0].ColumnName = "客户名称";
                                ds.Tables[0].Columns[1].ColumnName = "类别";
                                ds.Tables[0].Columns[2].ColumnName = "数量";
                                ds.Tables[0].Columns[3].ColumnName = "金额";
                            }
                            if (selectClasses == 1)
                            {
                                ds.Tables[0].Columns[0].ColumnName = "品牌名称";
                                ds.Tables[0].Columns[1].ColumnName = "数量";
                                ds.Tables[0].Columns[2].ColumnName = "金额";
                            }
                            if (selectClasses == 2)
                            {
                                ds.Tables[0].Columns[0].ColumnName = "商品名称";
                                ds.Tables[0].Columns[1].ColumnName = "商品条码";
                                ds.Tables[0].Columns[2].ColumnName = "数量";
                                ds.Tables[0].Columns[3].ColumnName = "金额";
                            }
                            if (selectClasses == 3)
                            {
                                ds.Tables[0].Columns[0].ColumnName = "区域名称";
                                ds.Tables[0].Columns[1].ColumnName = "数量";
                                ds.Tables[0].Columns[2].ColumnName = "金额";
                            }
                            if (selectClasses == 4)
                            {
                                ds.Tables[0].Columns[0].ColumnName = "业务员名称";
                                ds.Tables[0].Columns[1].ColumnName = "数量";
                                ds.Tables[0].Columns[2].ColumnName = "金额";
                            }
                            CreateExcel(ds.Tables[0],"购销明细数据_"+DateTime.Now.ToString("yyyy-MM-dd")+".xls");
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
            pagetitle = " 购销详情";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}