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
	public partial class product_price : PageBase
	{
		public DataTable dList = new DataTable();
		public DataTable priceList = new DataTable();
		public string Act = "";
		public string S_key = "";
		public int StorageID = 0;
		public int ProductID = 0;
		public decimal Price = 0;
		public decimal PriceRMB = 0;//人民币成本
		public DataTable StorageName = new DataTable();
		public int loop_count = 0;
		public DateTime sDate = DateTime.Now;
		public DataTable StorageList = new DataTable();
		public string StorageClassJson="";
		public string StorageClassID=""; //分类编号
		public string Aclass = "";
		public string className = "";//分类名称
		public string rCode = "";//随机校验码

		public bool ShowProductCostPrice = false;//是否显示成本

		protected virtual void Page_Load(object sender, EventArgs e)
		{
			if (this.userid > 0)
			{
				if (CheckUserPopedoms("X"))
				{
					Act = HTTPRequest.GetString("Act");

					//邮件校验码
					if (HTTPRequest.GetString ("rCode") != "") {

						Session ["r_Code"] = HTTPRequest.GetString ("rCode");

					}

					string _rCode = Session["r_Code"]!= null?Convert.ToString(Session["r_Code"]):"";//邮件获取
					string s_rCode = Session["s_r_Code"]!= null?Convert.ToString(Session["s_r_Code"]):"";//本地校验


					if (_rCode == "" || _rCode != s_rCode) {
					
						string s_r_Code = s_rCode.Trim()!=""?s_rCode: MakeCode (6);//生成6位验证码

						if (Act == "SendCode") {
							Session ["s_r_Code"] = s_r_Code;
							UsersUtils.SendMailToEmail (config.ProductCostPriceCodeMail, "商品成本维护校验码", "请在10分钟内输入商品成本维护校验码:<b>" + s_r_Code + "</b>");
							Response.ClearContent ();
							Response.Buffer = true;
							Response.ExpiresAbsolute = System.DateTime.Now.AddYears (-1);
							Response.Expires = 0;

							Response.Write ("{state:true,msg:\"OK!\"}");
							Response.End ();
						}

						if (Act.Trim () == "UpdatePrice") {
							Response.ClearContent ();
							Response.Buffer = true;
							Response.ExpiresAbsolute = System.DateTime.Now.AddYears (-1);
							Response.Expires = 0;

							Response.Write ("{state:false,msg:\"No Code!\"}");
							Response.End ();
						} else {

							ShowRCodeInput (s_r_Code);
						
						}//AddErrLine ("请输入授权码!");

					} else {


						//仓库分类树
						StorageClassJson = Caches.GetStorageInfoToJson (-1, false, true);
						Aclass = HTTPRequest.GetString ("aclass");
						if (Aclass.IndexOf ("aclass") > -1) {
							string sID = "";
							string sCode = "";
							string sName = "";

							//获得仓库分类编号
							StorageClassID = HTTPRequest.GetString ("sClassID");
							//获得仓库名称、编号、系统编号
							StorageName = tbStockProductInfo.getStorageNameByClass (Convert.ToInt32 (StorageClassID));
							for (int i = 0; i < StorageName.Rows.Count; i++) {
								if (StorageName.Rows [i] ["sState"].ToString () == "0") {
									sName += StorageName.Rows [i] ["sName"].ToString () + "(" + StorageName.Rows [i] ["sCode"].ToString () + ")" + ",";
									sID += StorageName.Rows [i] ["StorageID"].ToString () + ",";
									sCode += StorageName.Rows [i] ["sCode"].ToString () + ",";
								}
							}
							Response.ClearContent ();
							Response.Buffer = true;
							Response.ExpiresAbsolute = System.DateTime.Now.AddYears (-1);
							Response.Expires = 0;

							Response.Write ("{sID:'" + sID + "',sCode:'" + sCode + "',sName:'" + sName + "'}");
							Response.End ();
						}

						StorageID = HTTPRequest.GetInt ("StorageID", 0);
						sDate = HTTPRequest.GetString ("sDate").Trim () != "" ? Convert.ToDateTime (HTTPRequest.GetString ("sDate").Trim () + " 23:59:59") : DateTime.Now;

						//显示列表
						if (Act.Trim () != "") {
							className = HTTPRequest.GetString ("StorageClassName").Trim ();
							StorageClassID = HTTPRequest.GetString ("StorageClassNum");
							if (StorageClassID == "") {
								AddMsgLine ("请选择仓库类别后再进行查询!");
							} else {
								priceList = tbProductPriceNOAuto.GetProductPriceNOAutoListNew ("").Tables [0];
								StorageName = tbStockProductInfo.getStorageNameByClass (Convert.ToInt32 (StorageClassID));
								if (StorageID == 0) {
									dList = tbProductsInfo.GetProductsStorageInfoByStorageID (Convert.ToInt32 (StorageClassID), StorageID, sDate, ProductID);
								} else {
									dList = tbProductsInfo.GetProductsStorageInfoByStorageID (0, StorageID, sDate, ProductID);// DataUtils.GetStock_analysis(0, DateTime.Now, ProductID);
								}

								if (dList.Rows.Count > 0) {
									DataColumn dc = dList.Columns.Add("pPrice", Type.GetType("System.Decimal"));
									dc.DefaultValue = 0;
									DataColumn dc2 = dList.Columns.Add("pPriceRMB", Type.GetType("System.Decimal"));
									dc2.DefaultValue = 0;
									for(int k=0;k < priceList.Rows.Count;k++){
										for (int j = 0; j < dList.Rows.Count; j++) {

											if (dList.Rows [j] ["ProductsID"].ToString() == priceList.Rows [k] ["ProductsID"].ToString()) {
												dList.Rows [j] ["pPrice"] = Convert.ToDecimal(priceList.Rows [k] ["Price"]);
												dList.Rows [j] ["pPriceRMB"] = Convert.ToDecimal(priceList.Rows [k] ["PriceRMB"]);
											}
										}
									}
									dList.AcceptChanges();

								}

							}

						}

						//更新成本
						if (Act == "UpdatePrice") {
							ProductID = HTTPRequest.GetInt ("ProductID",0);
							Price = Convert.ToDecimal(HTTPRequest.GetFloat ("Price",0));
							PriceRMB = Convert.ToDecimal(HTTPRequest.GetFloat ("PriceRMB",0));

							if (ProductID > 0) {
								ProductPriceNOAutoInfo pp = new ProductPriceNOAutoInfo ();
								pp.ProductsID = ProductID;
								pp.Price = Price;
								pp.PriceRMB = PriceRMB;
								pp.ppAppendTime = DateTime.Now;

								if (tbProductPriceNOAuto.AddProductPriceNOAuto (pp)>0) {
									Response.ClearContent ();
									Response.Buffer = true;
									Response.ExpiresAbsolute = System.DateTime.Now.AddYears (-1);
									Response.Expires = 0;

									Response.Write ("{state:true,ProductsID:"+ProductID+",Price:"+Price+"}");
									Response.End ();
								}
							}
						}

						if (ispost)
						{
							Act = HTTPRequest.GetFormString("Act");
							S_key = Utils.ChkSQL(HTTPRequest.GetFormString("S_key")); 
						}
						else
						{

							S_key = Utils.ChkSQL(HTTPRequest.GetQueryString("S_key"));

							//导出
							if (Act.IndexOf("Export") > -1)
							{
								DataTable dt = dList.Copy();
								if (dt.Rows.Count > 0)
								{
									for (int j = 0; j < dt.Rows.Count; j++)
									{
										dt.Rows[j]["pStorage"] = (Convert.ToDecimal(dt.Rows[j]["pStorage"].ToString()) + Convert.ToDecimal(dt.Rows[j]["pStorageIn"].ToString()) - Convert.ToDecimal(dt.Rows[j]["pStorageOut"].ToString()) + Convert.ToDecimal(dt.Rows[j]["Beginning"].ToString())).ToString();
									}
									dt.AcceptChanges();

									dt.Columns.RemoveAt(0);
									dt.Columns.RemoveAt(0);
									dt.Columns.RemoveAt(6);
									dt.Columns.RemoveAt(6);
									dt.Columns.RemoveAt(6);
									dt.Columns.RemoveAt(7);
									DataSet dset = new DataSet();
									dt.Columns["sName"].SetOrdinal(0);
									dset.Tables.Add(dt);
									dset.Tables[0].Columns[0].ColumnName = "仓库名称";
									dset.Tables[0].Columns[1].ColumnName = "商品条码";
									dset.Tables[0].Columns[2].ColumnName = "商品名称";
									dset.Tables[0].Columns[3].ColumnName = "默认售价";
									dset.Tables[0].Columns[4].ColumnName = "库存数量";
									dset.Tables[0].Columns[5].ColumnName = "入库未核销";
									dset.Tables[0].Columns[6].ColumnName = "出库未核销";
									dset.Tables[0].Columns[7].ColumnName = "不可用库存";
									dset.Tables[0].Columns[8].ColumnName = "成本(€)";
									dset.Tables[0].Columns[9].ColumnName = "成本(¥)";



									CreateExcel(dset.Tables[0], "Data_" + sDate.ToShortDateString() + ".xls");
								}
								else
								{
									AddErrLine("请选择仓库类别后再进行查询!");
								}
							}
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
			pagetitle = " 商品价格维护";
			this.Load += new EventHandler(this.Page_Load);
		}
	}
}

