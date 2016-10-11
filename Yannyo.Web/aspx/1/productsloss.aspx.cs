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
    public partial class productsloss : PageBase
    {
        public DateTime sDate =DateTime.Now;           //获取当前时间为时间点:开始日期
        public DateTime eDate=DateTime.Now;            //结束日期
        public DataTable wList = new DataTable();      //获取仓库信息列表
        public DataTable ccList = new DataTable();     //返回产品受影响的行集
        public DataTable rList = new DataTable();      //返回仓库联营产品查询详情
        public int cList;                              //返回产品受影响的行集
        public int tLoopid;                            //设置格式
        public int storageID=0;                        //仓库编号
        public int associated;                         //获取select值
        public decimal sumA, sumB;                     //求和
        public string Show="";                         //判断权限
        public string Act;

        //返回产品受影响的行集
        public int productsCount(DateTime dtb, DateTime dte, int associated, string sID)
        {
            ccList = ProductsLossInfo.bindProductsLoss(Convert.ToDateTime(dtb.ToShortDateString()), Convert.ToDateTime(dte.ToShortDateString()), associated, Convert.ToInt32(sID), 1);
            return ccList.Rows.Count;
        }
        //页面加载过程中获取到产品的详情
        public DataTable getProductsInfoOnLoad(DateTime dtb,DateTime dte, int associated, string sID)
        {
            rList = ProductsLossInfo.bindProductsLoss(Convert.ToDateTime(dtb.ToShortDateString()), Convert.ToDateTime(dte.ToShortDateString()), associated, Convert.ToInt32(sID), 1);
            if (rList.Rows.Count > 0)
            {
                return rList;
            }
            else
            {
                return null;
            }
        }
        protected virtual void Page_Load(object sender, EventArgs e)
        {

            if (this.userid > 0)
            {
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-4-1"))
                {
                     bool ShowMoney = CheckUserPopedoms("7-2-1-5-4-2");
                     bool xshowMoney = CheckUserPopedoms("X");
                     if (ShowMoney || xshowMoney)
                     {
                         Show = "1";
                     }
                    //绑定仓库信息
                    wList = ProductsLossInfo.getWorehouseName();
                    //获取客户端日期
                    sDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("sDate"))) : DateTime.Now.AddDays(-(DateTime.Now.Day) + 1);
                    eDate = Utils.IsDateString(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) ? DateTime.Parse(Utils.ChkSQL(HTTPRequest.GetString("stDate"))) : DateTime.Now;
                    //获取客户端select值
                    associated = HTTPRequest.GetInt("_Associated",0);
                    Act = HTTPRequest.GetString("Act");
                    if (ispost)
                    {
                        if (ShowMoney || xshowMoney)
                        {
                            Show = "1";
                        }

                    }
                    else
                    {
                        if (Act.IndexOf("act") > -1)
                        {
                            rList = ProductsLossInfo.bindProductsLoss(sDate, eDate, associated, 0, 0);
                            DataTable dt = new DataTable();
                            DataSet ds = new DataSet();
                            dt = rList.Copy();
                            ds.Tables.Add(dt);
                            ds.Tables[0].Columns[0].ColumnName = "仓库名称";
                            ds.Tables[0].Columns[1].ColumnName = "商品名称";
                            ds.Tables[0].Columns[2].ColumnName = "商品品牌";
                            ds.Tables[0].Columns[3].ColumnName = "商品条码";
                            ds.Tables[0].Columns[4].ColumnName = "装件数";
                            ds.Tables[0].Columns[5].ColumnName = "数量";
                            ds.Tables[0].Columns[6].ColumnName = "金额";

                            CreateExcel(ds.Tables[0],"仓库报损数据_"+DateTime.Now.ToString("yyyy-MM-dd")+".xls");
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
            pagetitle = " 报损统计";
            this.Load += new EventHandler(this.Page_Load);
        }
       
    }
}