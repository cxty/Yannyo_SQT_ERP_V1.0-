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

	public partial class productfield_edit : PageBase
	{
		public ProductFieldInfo pf = new ProductFieldInfo();
		public DataTable ProductFieldTypeList = new DataTable();
		public int ProductFieldID;
		public int ProductClassID;
		public string ProductClassStr = "";
		public string pfName = "";
		public string Act = "";
		public int pfType = 0;
		public int pfOrder = 0;
		public int pfState = 0;
		public DateTime pfAppendTime = DateTime.Now;


		protected virtual void Page_Load(object sender, EventArgs e)
		{
			if (this.userid > 0)
			{
				if (CheckUserPopedoms("X") || CheckUserPopedoms("2-1-8"))
				{ 
					Act = HTTPRequest.GetString("Act");
					ProductFieldID = HTTPRequest.GetInt ("ProductFieldID",0);
					ProductClassID = HTTPRequest.GetInt ("ProductClassID",0);
					pfName = Utils.ChkSQL(HTTPRequest.GetString ("pfName").Trim());
					pfType = HTTPRequest.GetInt ("pfType",0);
					pfOrder = HTTPRequest.GetInt ("pfOrder",0);
					pfState = HTTPRequest.GetInt ("pfState",0);
					if (ProductFieldID > 0)
					{
						pf = tbProductFieldInfo.GetProductFieldModel (ProductFieldID);
					}
					if (ispost) {
						//添加
						if (Act.IndexOf ("add") > -1) {
							if (pfName.Trim () != "") {
								if (!tbProductFieldInfo.ExistsProductField (ProductClassID, pfName)) {

									pf.pfName = pfName.Trim ();
									pf.pfOrder = pfOrder;
									pf.pfState = pfState;
									pf.pfType = pfType;
									pf.ProductClassID = ProductClassID;
									pf.pfAppendTime = pfAppendTime;

									int pfID = tbProductFieldInfo.AddProductField (pf);
									if (pfID > 0) {
									
										Logs.AddEventLog (this.userid, "添加" + pfName + "(" + pfID + ")商品字段");
										AddMsgLine ("操作成功！");
										AddScript ("window.setTimeout('window.parent.HidBox();',1000);");

									}

								} else {
									AddErrLine ("操作失败，该商品字段当前分类下已经存在，请核对后重新添加！");
								}
							} else {
								AddErrLine ("操作失败，商品字段不能为空，请核对后重新添加！");
							}
						}
						//修改
						if (Act.IndexOf ("update") > -1) {
							bool isOK = true;
							string error_str = "";
							if (pf.pfName.Trim() != pfName.Trim ()) {
								if (!tbProductFieldInfo.ExistsProductField (ProductClassID, pfName)) {
									isOK = true;
								} else {
									isOK = false;
									AddErrLine ("操作失败，该商品字段当前分类下已经存在，请核对后重新添加！");
								}
							}
							if (isOK) {
								if (pfName.Trim () != "") {
									string lastName = pf.pfName;
									pf.pfName = pfName.Trim ();
									pf.pfOrder = pfOrder;
									pf.pfState = pfState;
									pf.pfType = pfType;
									pf.ProductClassID = ProductClassID;

									int count = tbProductFieldInfo.UpdateProductField (pf);

									if (count > 0) {
										//记录修改操作
										Logs.AddEventLog (this.userid, "将" + lastName + "商品字段修改为" + pfName);
										AddMsgLine ("修改成功！");
										AddScript ("window.setTimeout('window.parent.HidBox();',1000);");
								
									} else {
										AddErrLine ("修改失败！");
									}
								} else {
									AddErrLine ("商品字段不能为空!");
								}
							} 
						}
					} else {
					
						ProductFieldTypeList = tbProductFieldInfo.GetProductFieldTypes ();

						ProductClassStr = DataClass.GetProductClassInfoToHTML();

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

