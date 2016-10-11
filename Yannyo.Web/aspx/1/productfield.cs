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
	public partial class productfield :PageBase
	{
		public DataTable ProductFieldList = new DataTable();

		public string className = "";                    //分类名称
		public int classID = 0;                          //分类编号
		public string sTjson;
		public string ProductFieldID = "";
		public string Act = "";                         //获得操作步骤

		protected virtual void Page_Load(object sender, EventArgs e)
		{
			if (this.userid > 0)
			{
				if (CheckUserPopedoms("X") || CheckUserPopedoms("2-1-8"))
				{
					className = Utils.ChkSQL(HTTPRequest.GetString("className"));
					classID = HTTPRequest.GetInt("classID", 0);
					ProductFieldID = HTTPRequest.GetString ("ProductFieldID");
					Act = HTTPRequest.GetString("Act");
					Caches.ReSet();

					ProductFieldList = tbProductFieldInfo.GetProductFieldList (" ProductClassID = "+classID);

					if (ispost) {
						if (Act.IndexOf ("getNode") > -1) {
							string _json = "";
							for (int i = 0; i < ProductFieldList.Rows.Count; i++) {
								_json += "{'Field':{'ProductFieldID':" + ProductFieldList.Rows [i] ["ProductFieldID"].ToString () + "," +
									"'ProductClassID':" + ProductFieldList.Rows [i] ["ProductClassID"].ToString () + "," +
									"'ProductClassName':'" + ProductFieldList.Rows [i] ["ProductClassName"].ToString () + "'," +
									"'pfName':'" + ProductFieldList.Rows [i] ["pfName"].ToString () + "'," +
									"'pfType':" + ProductFieldList.Rows [i] ["pfType"].ToString () + "," +
									"'TypeName':'" + ProductFieldList.Rows [i] ["TypeName"].ToString () + "'," +
									"'pfOrder':" + ProductFieldList.Rows [i] ["pfOrder"].ToString () + "," +
									"'pfState':" + ProductFieldList.Rows [i] ["pfState"].ToString () + "," +
									"'pfAppendTime':'" + ProductFieldList.Rows [i] ["pfAppendTime"].ToString () + "'" +
									"}},";
							}
							_json = _json.Trim () != "" ? _json.Trim ().Substring (0, _json.Trim ().Length - 1) : "";
							Response.Write ("{'FieldList':[" + _json + "]}");
							Response.End ();
						}
						if (Act.IndexOf ("del") > -1) {


							if (ProductFieldID != "") {
								try {
									tbProductFieldInfo.DeleteProductField (ProductFieldID);

								
									//记录删除商品
									Logs.AddEventLog (this.userid, "删除" + ProductFieldID + "商品分类");
									Response.Write ("1");
									Response.End ();
								} catch {
									Response.Write ("0");
									Response.End ();
								}
							} else {
								Response.Write ("-1");
								Response.End ();
							}
						}
					} 
				}
				else
				{
					AddErrLine("权限不足!");
					AddScript("window.parent.HidBox();");
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
			pagetitle = "商品自定义字段信息";
			this.Load += new EventHandler(this.Page_Load);
		}
	}
}

