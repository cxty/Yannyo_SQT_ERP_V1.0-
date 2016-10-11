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
    public partial class stockproduct_do : PageBase
    {
        
        public StockProductInfo spi = new StockProductInfo();
        public string Act = "";
        public int ProductsID = 0;
        public decimal isOK = 0;
        public decimal isBad = 0;
        public DateTime sAppendTime = DateTime.Now;
        public DataTable dList = new DataTable();
        public DataTable StorageList = new DataTable();

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (this.userid > 0)
            {
				if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-5-3"))
                {
                    Act = HTTPRequest.GetString("Act");
                    if (Act == "Edit")
                    {
                        ProductsID = Utils.StrToInt(HTTPRequest.GetString("pid"), 0);

                        dList = DataUtils.GetStock_analysis(0, DateTime.Now, ProductsID);
                        
                        //spi = tbStockProductInfo.GetStockProductInfoModelByProductsID(ProductsID); 
                    }
                    if (dList != null)
                    {
                        if (ispost)
                        {
                            try
                            {
                                int loop = HTTPRequest.GetInt("loop", 0);
                                int StorageID = 0;
                                decimal pBad = 0;
                                if (loop > 0)
                                {
                                    for (int i = 0; i <= loop; i++)
                                    {
                                        StorageID = HTTPRequest.GetInt("StorageID_" + i, 0);
                                        if (StorageID > 0)
                                        {
                                            pBad = (HTTPRequest.GetString("Bad_" + i).Trim() != "") ? decimal.Parse(Utils.ChkSQL(HTTPRequest.GetString("Bad_" + i))) : 0;

                                            spi = new StockProductInfo();
                                            spi.ProductsID = ProductsID;
                                            spi.StorageID = StorageID;
                                            spi.isBad = pBad;
                                            spi.sAppendTime = DateTime.Now;

                                            tbStockProductInfo.AddStockProductInfo(spi);

											ProductsInfo _pi = new ProductsInfo();
											StorageInfo _si = new StorageInfo();

											_pi = tbProductsInfo.GetProductsInfoModel(ProductsID);
											_si = tbStorageInfo.GetStorageInfoModel(StorageID);

											if(_pi!=null && _si!=null){
												Logs.AddEventLog(this.userid, "修改实时库存."+_si.sName+","+_pi.pName+".Bad:"+pBad);
											}
											_pi = null;
											_si = null;

                                        }
                                    }
                                    AddMsgLine("更新成功!");
                                    AddScript("window.setTimeout('window.parent.HidBox();',1000);");
                                }

                               
                            }
                            catch
                            {
                                AddErrLine("系统忙,请稍候!");
                                AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                            }
                        }
                        else {
                            StorageList = tbStorageInfo.GetStorageInfoList("").Tables[0];
                            if (StorageList != null)
                            {
                                StorageList.Columns.Add("Bad", Type.GetType("System.Decimal"));
                                DataTable dt = new DataTable();
                                dt = tbStockProductInfo.GetStockProductInfoListByNow(" sp.ProductsID=" + ProductsID).Tables[0];
                                if (dt != null)
                                {
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        foreach (DataRow drr in StorageList.Rows)
                                        {
                                            if (dr["StorageID"].ToString() == drr["StorageID"].ToString())
                                            {
                                                drr["Bad"] = dr["isBad"];
                                            }
                                        }
                                    }
                                }
                                StorageList.AcceptChanges();
                            }
                        }
                    }
                    else
                    {
                        AddErrLine("参数错误,请重试!");
                        AddScript("window.setTimeout('window.parent.HidBox();',2000);");
                    }
                }
                else
                {
                    AddErrLine("权限不足!");
                    AddScript("window.setTimeout('window.parent.HidBox();',2000);");
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
            pagetitle = " 更新库存信息";
            this.Load += new EventHandler(this.Page_Load);
        }
    }
}
