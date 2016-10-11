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

	public partial class storage_order_list : PageBase
	{
		public DataTable bList = new DataTable();
		public DataTable dList = new DataTable();
		public DataTable pList = new DataTable();
		public DataTable sList = new DataTable();

		public string Act = "";
		public string S_key = "";
		public int ProductID = 0;
		public int StorageID = 0;
		public DataTable StorageName = new DataTable();
		public int loop_count = 0;
		public DateTime bDate = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
		public DateTime eDate = DateTime.Now;


		public string StorageClassJson="";
		public int StorageClassID; //分类编号
		public string Aclass = "";
		public string className = "";//分类名称

		protected virtual void Page_Load(object sender, EventArgs e)
		{
			Act = HTTPRequest.GetQueryString("Act");
			if (this.userid > 0)
			{


				//仓库分类树
				StorageClassJson = Caches.GetStorageInfoToJson(-1, false, true);
				Aclass = HTTPRequest.GetString("aclass");
				if (Aclass.IndexOf("aclass") > -1)
				{
					string sID = "";
					string sCode = "";
					string sName = "";
					//获得仓库分类编号
					StorageClassID = HTTPRequest.GetInt("sClassID",0);
					//获得仓库名称、编号、系统编号
					StorageName = tbStockProductInfo.getStorageNameByClass(StorageClassID);
					for (int i = 0; i < StorageName.Rows.Count; i++)
					{
						if (StorageName.Rows[i]["sState"].ToString() == "0")
						{
							sName += StorageName.Rows[i]["sName"].ToString() + "(" + StorageName.Rows[i]["sCode"].ToString() + ")" + ",";
							sID += StorageName.Rows[i]["StorageID"].ToString() + ",";
							sCode += StorageName.Rows[i]["sCode"].ToString() + ",";
						}
					}
					Response.ClearContent();
					Response.Buffer = true;
					Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);
					Response.Expires = 0;

					Response.Write("{sID:'" + sID + "',sCode:'" + sCode + "',sName:'" + sName + "'}");
					Response.End();
				}

				if (CheckUserPopedoms("X") || CheckUserPopedoms("7-2-1-5-5") || CheckUserPopedoms("5-7") || CheckUserPopedoms("5-4"))
				{
					S_key = HTTPRequest.GetString ("S_key");
					className = HTTPRequest.GetString ("StorageClassName");
					ProductID = HTTPRequest.GetInt ("ProductID", 0);
					StorageID = HTTPRequest.GetInt ("StorageID", 0);
					StorageClassID = HTTPRequest.GetInt ("StorageClassNum", 0);
					bDate = HTTPRequest.GetString ("bDate").Trim () != "" ? Convert.ToDateTime (HTTPRequest.GetString ("bDate").Trim () + " 00:00:00") : DateTime.Now.AddDays (-DateTime.Now.Day + 1);
					eDate = HTTPRequest.GetString ("eDate").Trim () != "" ? Convert.ToDateTime (HTTPRequest.GetString ("eDate").Trim () + " 23:59:59") : DateTime.Now;

					if (StorageClassID > 0) {
						StorageName = tbStockProductInfo.getStorageNameByClass (Convert.ToInt32 (StorageClassID));
					}
					//json表格
					if (Act == "data") {

						DataSet ds = tbStorageProductLogInfo.GetStorageList (StorageClassID, StorageID, ProductID, bDate, eDate);
						if (ds != null) {
							bList = ds.Tables [0];
							dList = ds.Tables [1];
							pList = ds.Tables [2];
							sList = ds.Tables [3];
						}

						string bListJson = "";// Utils.DataTableToJSON (bList).ToString().TrimEnd(";".ToCharArray());
						string dListJson = "";// Utils.DataTableToJSON (dList).ToString().TrimEnd(";".ToCharArray());
						string pListJson = "";// Utils.DataTableToJSON (pList).ToString().TrimEnd(";".ToCharArray());
						string sListJson = "";// Utils.DataTableToJSON (sList).ToString().TrimEnd(";".ToCharArray());

						if (bList != null) {
							foreach (DataRow dr_bL in bList.Rows) {
								bListJson += "{\"storageid\":"+dr_bL["storageid"].ToString()+","+
								             "\"quantity\":"+dr_bL["quantity"].ToString()+","+
								             "\"productsid\":"+dr_bL["productsid"].ToString()+","+
								             "\"pbarcode\":\""+dr_bL["pbarcode"].ToString()+"\""+","+
								             "\"pname\":\""+dr_bL["pname"].ToString()+"\""+","+
								             "\"punits\":\""+dr_bL["punits"].ToString()+"\""+","+
								             "\"pmaxunits\":\""+dr_bL["pmaxunits"].ToString()+"\""+","+
								             "\"ptoboxno\":"+dr_bL["ptoboxno"].ToString()+
								             "},";
							}
						}

						if (dList != null) {
							foreach (DataRow dr_dL in dList.Rows) {
								dListJson += "{\"StaffID\":"+dr_dL["StaffID"].ToString()+","+
								             "\"splremake\":\""+dr_dL["splremake"].ToString()+"\","+
								             "\"splappendtime\":\""+dr_dL["splappendtime"].ToString()+"\","+
								             "\"orderlistid\":"+dr_dL["orderlistid"].ToString()+","+
								             "\"storageid\":"+dr_dL["storageid"].ToString()+","+
								             "\"productsid\":"+dr_dL["productsid"].ToString()+","+
								             "\"quantity\":"+dr_dL["quantity"].ToString()+","+
								             "\"orderid\":\""+dr_dL["orderid"].ToString()+"\","+
								             "\"oordernum\":\""+dr_dL["oordernum"].ToString()+"\","+
								             "\"otype\":\""+dr_dL["otype"].ToString()+"\","+
								             "\"oappendtime\":\""+dr_dL["oappendtime"].ToString()+"\","+
								             "\"oorderdatetime\":\""+dr_dL["oorderdatetime"].ToString()+"\","+
								             "\"ostate\":\""+dr_dL["ostate"].ToString()+"\","+
								             "\"osteps\":\""+dr_dL["osteps"].ToString()+"\","+
								             "\"storesid\":\""+dr_dL["storesid"].ToString()+"\","+
								             "\"ocustomersname\":\""+dr_dL["ocustomersname"].ToString()+"\","+
								             "\"StoresSupplierName\":\""+dr_dL["StoresSupplierName"].ToString()+"\""+
								             "},";
							}
						}

						if (pList != null) {
							foreach (DataRow dr_pL in pList.Rows) {
								pListJson += "{\"ProductsID\":"+dr_pL["ProductsID"].ToString()+","+
								             "\"productclassid\":"+dr_pL["productclassid"].ToString()+","+
								             "\"pcode\":\""+dr_pL["pcode"].ToString()+"\","+
								             "\"pbarcode\":\""+dr_pL["pbarcode"].ToString()+"\","+
								             "\"pname\":\""+dr_pL["pname"].ToString()+"\","+
								             "\"pbrand\":\""+dr_pL["pbrand"].ToString()+"\","+
								             "\"pstandard\":\""+dr_pL["pstandard"].ToString()+"\","+
								             "\"punits\":\""+dr_pL["punits"].ToString()+"\","+
								             "\"pmaxunits\":\""+dr_pL["pmaxunits"].ToString()+"\","+
								             "\"ptoboxno\":"+dr_pL["ptoboxno"].ToString()+","+
								             "\"pstate\":"+dr_pL["pstate"].ToString()+
								             "},";
							}
						}

						if (sList != null) {
							foreach (DataRow dr_sL in sList.Rows) {
								sListJson += "{\"storageid\":"+dr_sL["storageid"].ToString()+","+
								             "\"scode\":\""+dr_sL["scode"].ToString()+"\","+
								             "\"sname\":\""+dr_sL["sname"].ToString()+"\","+
								             "\"smanager\":\""+dr_sL["smanager"].ToString()+"\","+
								             "\"stel\":\""+dr_sL["stel"].ToString()+"\","+
								             "\"storageclassid\":"+dr_sL["storageclassid"].ToString()+","+
								             "\"sstate\":"+dr_sL["sstate"].ToString()+
								             "},";
							}
						}

						string Json_Str = "{\"bList\":["+bListJson.TrimEnd(",".ToCharArray())+"],"+
						                  "\"dList\":["+dListJson.TrimEnd(",".ToCharArray())+"],"+
						                  "\"pList\":["+pListJson.TrimEnd(",".ToCharArray())+"],"+
						                  "\"sList\":["+sListJson.TrimEnd(",".ToCharArray())+"]}";

						Response.ClearContent();
						Response.Buffer = true;
						Response.ExpiresAbsolute = System.DateTime.Now.AddYears(-1);

						Response.Expires = 0;

						Response.Charset = "utf-8";
						Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
						Response.ContentType = "application/json";
						if (Json_Str.Trim () == "") {
							Json_Str = "{\"results\": []}";
						} else {
							Json_Str = "{\"results\": "+Json_Str+"}";
						}
						Response.Write(Json_Str);
						Response.End ();
					}

					//导出
					if (Act == "exp") {

						DataSet ds = tbStorageProductLogInfo.GetStorageList (StorageClassID, StorageID, ProductID, bDate, eDate);
						if (ds != null) {
							bList = ds.Tables [0];
							dList = ds.Tables [1];
							pList = ds.Tables [2];
							sList = ds.Tables [3];

							DataTable _t = new DataTable ();

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
			pagetitle = " 仓库管理日常明细";
			this.Load += new EventHandler(this.Page_Load);
		}
	}
}

