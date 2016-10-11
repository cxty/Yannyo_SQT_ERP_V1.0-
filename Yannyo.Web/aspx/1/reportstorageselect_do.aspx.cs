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
    public partial class reportstorageselect_do : PageBase
    {
        public DataTable dList = new DataTable();
        public DataTable pList =  new DataTable();
        public DataTable mList = new DataTable();
        public int getData;//产品id
        public string getName;//产品名称
        public string getBarcode;//产品条码
        public DateTime bDate;//开始时间
        public DateTime eDate;//结束时间
        public string regionName;
        public decimal SumA, SumAA, SumB, SumBB, SumC, SumCC,SumD, SumDD;
        public DataTable getDetailsOfProducts(int regionID, int data, DateTime bTime, DateTime eTime)
        {
            pList = storehouseStorage.getProductsOfRegionDetails(regionID, data, bTime, eTime);
          
            if (pList.Rows.Count>0)
            {
                return pList;
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
                if (CheckUserPopedoms("X") || CheckUserPopedoms("7-1-2"))
                {
                    dList = storehouseStorage.RegionName();              //获得地区列表

                    getData = Int32.Parse(HTTPRequest.GetString("sid"));  //获得url过来的产品ID
                    getName = HTTPRequest.GetString("sname");            //获得url过来的产品名称
                    getBarcode = HTTPRequest.GetString("scode");         //获得url过来的产品条码
                    bDate = Convert.ToDateTime(HTTPRequest.GetString("bDate"));               //获得url过来的开始时间
                    eDate = Convert.ToDateTime(HTTPRequest.GetString("eDate"));               //获得url过来的结束时间
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
            pagetitle = config.CompanyName + "单品地区进销存详情";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}