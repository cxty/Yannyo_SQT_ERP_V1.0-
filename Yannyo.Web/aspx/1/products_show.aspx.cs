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
using Yannyo.Cache;
using Yannyo.Common;
using Yannyo.Entity;
using Yannyo.BLL;

namespace Yannyo.Web
{

	public partial class products_show : PageBase
	{
		public ProductsInfo pi = new ProductsInfo();
		public DataTable ProductFieldList = new DataTable();
		public DataTable ProductFieldValueList = new DataTable();

		public int ProductsID = 0;

		protected virtual void Page_Load(object sender, EventArgs e)
		{
			if (this.userid > 0) {
				ProductsID = Utils.StrToInt(HTTPRequest.GetString("pid"), 0);

				pi = tbProductsInfo.GetProductsInfoModel(ProductsID);

				ProductFieldValueList = tbProductsFieldValueInfo.GetProductsFieldValueList (" ProductsID = "+ProductsID).Tables[0];

				ProductFieldList = tbProductFieldInfo.GetProductFieldList (" ProductClassID in (0,"+pi.ProductClassID+") and pfState=0 order by pfOrder desc");

				ProductFieldList.Columns.Add("FieldValue", typeof(string));

				for(int i=0;i<ProductFieldList.Rows.Count;i++){
					for(int j=0;j<ProductFieldValueList.Rows.Count;j++){
						if((int)ProductFieldList.Rows[i]["ProductFieldID"] == (int)ProductFieldValueList.Rows[j]["ProductFieldID"]){
							ProductFieldList.Rows [i] ["FieldValue"] = ProductFieldValueList.Rows [j] ["pfvData"].ToString().Replace("[br]","<br>").Replace("[b]","<b>").Replace("[/b]","</b>");
						}
					}
				}
				ProductFieldList.AcceptChanges();

			} else {
				AddErrLine ("请先登录!");
				SetBackLink ("login.aspx?referer=" + Utils.UrlEncode (Utils.GetUrlReferrer ()));
				SetMetaRefresh (1, "login.aspx?referer=" + Utils.UrlEncode (Utils.GetUrlReferrer ()));
			}
		}
		protected override void ShowPage()
		{
			pagetitle = "商品信息";
			this.Load += new EventHandler(this.Page_Load);
		}
		public static DataTable Str2Table(string str){
			DataTable dt = new DataTable ();
			dt.Columns.Add ("data",typeof(string));

			if (str.Trim () != "") {
				string[] str_arr = Utils.SplitString(str.ToString(),",");
				foreach(string _s in str_arr){
					if(_s!=""){
						DataRow dr = dt.NewRow();
						dr ["data"] = _s;
						dt.Rows.Add(dr);
					}
				}

			}
			dt.AcceptChanges();
			return dt;
		}
	}
}

