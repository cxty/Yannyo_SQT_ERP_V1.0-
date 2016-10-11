<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.storage_order_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:45. 
	*/

	base.OnLoad(e);

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
	templateBuilder.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
	templateBuilder.Append("<head>\r\n");
	templateBuilder.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n");
	templateBuilder.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=7\" />\r\n");
	templateBuilder.Append("" + meta.ToString() + "\r\n");
	templateBuilder.Append("<title>" + config.Systitle.ToString().Trim() + "  " + pagetitle.ToString() + "</title>\r\n");
	templateBuilder.Append("<link rel=\"icon\" href=\"favicon.ico\" type=\"image/x-icon\" />\r\n");
	templateBuilder.Append("<link rel=\"shortcut icon\" href=\"favicon.ico\" type=\"image/x-icon\" />\r\n");
	templateBuilder.Append("<!-- 调用样式表 -->\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/default.css\" type=\"text/css\" media=\"all\"  />\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/index.css\" type=\"text/css\" media=\"all\"  />\r\n");
	templateBuilder.Append("" + link.ToString() + "\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/comm.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/xml.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/swfobject.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.cookie.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.hotkeys.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.jstree.js\"></" + "script>\r\n");
	templateBuilder.Append("<link type=\"text/css\" rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/syntax/!style.css\"/>\r\n");
	templateBuilder.Append("<link type=\"text/css\" rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/!style.css\"/>\r\n");
	templateBuilder.Append("<link type=\"text/css\" rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/syntax/style.css\"/>\r\n");
	templateBuilder.Append("<!--<script type=\"text/javascript\" src=\"templates/" + templatepath.ToString() + "/syntax/!script.js\"></" + "script>-->\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.alerts.js\"></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.alerts.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\">\r\n");
	templateBuilder.Append("	var aspxrewrite = " + config.Aspxrewrite.ToString().Trim() + ";\r\n");
	templateBuilder.Append("</" + "script>\r\n");
	templateBuilder.Append("" + script.ToString() + "\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/public.js\"></" + "script>\r\n");
	templateBuilder.Append("</head>\r\n");


	templateBuilder.Append("<body>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/dialog.js \"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.cookie.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.hotkeys.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.jstree.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.maskedinput-1.2.2.min.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/storage_order_do.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/LodopFuncs.js\" type=\"text/javascript\" ></" + "script>\r\n");

	if (ispost)
	{


	if (page_err==0)
	{


	templateBuilder.Append("<div id=\"tmes\">\r\n");
	templateBuilder.Append("	<h1>提示信息</h1>\r\n");
	templateBuilder.Append("	<p class=\"errorback\">" + msgbox_text.ToString() + "</p>\r\n");

	if (msgbox_url!="")
	{

	templateBuilder.Append("	<p><a href=\"" + msgbox_url.ToString() + "\">如果浏览器没有转向, 请点击这里.</a></p>\r\n");

	}	//end if

	templateBuilder.Append("</div>\r\n");



	}
	else
	{


	templateBuilder.Append("<div id=\"tmes\">\r\n");
	templateBuilder.Append("	<h1>出现了" + page_err.ToString() + "个错误</h1>\r\n");
	templateBuilder.Append("	<p class=\"errorback\">" + msgbox_text.ToString() + "</p>\r\n");
	templateBuilder.Append("	<p class=\"errorback\">\r\n");
	templateBuilder.Append("		<script type=\"text/javascript\">\r\n");
	templateBuilder.Append("			if(" + msgbox_showbacklink.ToString() + ")\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				document.write(\"<a href=\\\"" + msgbox_backlink.ToString() + "\\\">返回上一步</a> &nbsp; &nbsp;|&nbsp; &nbsp  \");\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		</" + "script>\r\n");
	templateBuilder.Append("	</p>\r\n");
	templateBuilder.Append("</div>\r\n");



	}	//end if


	}
	else
	{


	if (page_err!=0)
	{


	templateBuilder.Append("<div id=\"tmes\">\r\n");
	templateBuilder.Append("	<h1>出现了" + page_err.ToString() + "个错误</h1>\r\n");
	templateBuilder.Append("	<p class=\"errorback\">" + msgbox_text.ToString() + "</p>\r\n");
	templateBuilder.Append("	<p class=\"errorback\">\r\n");
	templateBuilder.Append("		<script type=\"text/javascript\">\r\n");
	templateBuilder.Append("			if(" + msgbox_showbacklink.ToString() + ")\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				document.write(\"<a href=\\\"" + msgbox_backlink.ToString() + "\\\">返回上一步</a> &nbsp; &nbsp;|&nbsp; &nbsp  \");\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		</" + "script>\r\n");
	templateBuilder.Append("	</p>\r\n");
	templateBuilder.Append("</div>\r\n");



	}
	else
	{


	if (page_msg!=0)
	{


	templateBuilder.Append("<div id=\"tmes\">\r\n");
	templateBuilder.Append("	<h1>提示信息</h1>\r\n");
	templateBuilder.Append("	<p class=\"errorback\">" + msgbox_text.ToString() + "</p>\r\n");

	if (msgbox_url!="")
	{

	templateBuilder.Append("	<p><a href=\"" + msgbox_url.ToString() + "\">如果浏览器没有转向, 请点击这里.</a></p>\r\n");

	}	//end if

	templateBuilder.Append("</div>\r\n");



	}
	else
	{

	templateBuilder.Append("            <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td colspan=\"2\" align=\"left\">\r\n");
	 aspxrewriteurl = GetOrderType(ordertype.ToString());
	
	templateBuilder.Append("                  <h2>" + aspxrewriteurl.ToString() + "\r\n");

	if (Act=="v")
	{


	if (oi.oState==1)
	{

	templateBuilder.Append("                  	(已经作废)\r\n");

	}
	else
	{

	 aspxrewriteurl = GetOrderStpes(oi.oSteps.ToString());
	
	templateBuilder.Append("                      (" + aspxrewriteurl.ToString() + ")\r\n");

	}	//end if

	templateBuilder.Append("                  &nbsp;&nbsp;&nbsp;&nbsp;单号:" + oi.oOrderNum.ToString().Trim() + " \r\n");

	}	//end if

	templateBuilder.Append("                  </h2>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                	<td width=\"20%\" align=\"left\" valign=\"top\" id=\"tTreeBox\">\r\n");

	if (IsEditData == true)
	{

	templateBuilder.Append("                      <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"left\" valign=\"top\"><div id=\"tTree\" class=\"tTree\"></div></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                      </table>\r\n");

	}
	else
	{

	templateBuilder.Append("                      <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("                      $('#tTreeBox').hide();\r\n");
	templateBuilder.Append("                      </" + "script>\r\n");

	}	//end if

	templateBuilder.Append("                     </td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" valign=\"top\" >\r\n");
	templateBuilder.Append("                  <!--采购-->\r\n");

	if (ordertype==1 || ordertype ==2)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>\r\n");
	templateBuilder.Append("供货商:\r\n");

	if (Act=="v")
	{

	templateBuilder.Append("" + oi.StoresSupplierName.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("      日期:" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("	<tr class=\"tBar\">\r\n");
	templateBuilder.Append("	  <td width=\"80px\">仓库</td>\r\n");
	templateBuilder.Append("	  <td width=\"100px\">条码</td>\r\n");
	templateBuilder.Append("	  <td align=\"left\">商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">包装量</td>\r\n");
	templateBuilder.Append("	  <!--<td width=\"80px\">单价(元)</td>-->\r\n");
	templateBuilder.Append("	  <td width=\"120px\">单据数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)</td>\r\n");
	templateBuilder.Append("	  <td width=\"120px\">已入库数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)</td>\r\n");
	templateBuilder.Append("		<td width=\"120px\">\r\n");
	templateBuilder.Append("        剩余数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)\r\n");
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td width=\"120px\">\r\n");
	templateBuilder.Append("        本次入库数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)\r\n");
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("	</tr>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  <div id=\"OrderListLoop\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\" id=\"OrderListLoop_data\">\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  </div>\r\n");
	templateBuilder.Append("  </td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append(" OrderField = '" + OrderFieldListJson.ToString() + "';\r\n");
	templateBuilder.Append(" OrderListDataJsonStr = '" + OrderListDataJsonStr.ToString() + "';\r\n");
	templateBuilder.Append(" StorageOrderListJsonStr = '" + StorageOrderListJsonStr.ToString() + "';\r\n");
	templateBuilder.Append("</" + "script>\r\n");



	}	//end if

	templateBuilder.Append("                  <!--销售-->\r\n");

	if (ordertype==3 || ordertype == 4 || ordertype==5 || ordertype==6 || ordertype==7 || ordertype==11 )
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td valign=\"top\">\r\n");
	templateBuilder.Append("    客 户:\r\n");

	if (Act=="v")
	{

	templateBuilder.Append("" + oi.StoresSupplierName.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    <td valign=\"top\">客户编号: <span id=\"sCode\">\r\n");

	if (Act=="v")
	{

	templateBuilder.Append("" + oi.StoresSupplierCode.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("</span></td>\r\n");
	templateBuilder.Append("    <td valign=\"top\">\r\n");
	templateBuilder.Append("业务员:\r\n");

	if (Act=="v")
	{

	templateBuilder.Append("" + oi.StaffName.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td valign=\"top\">\r\n");
	 aspxrewriteurl = oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("日期:" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td valign=\"top\">\r\n");
	templateBuilder.Append("联系人:\r\n");

	if (Act=="v")
	{

	templateBuilder.Append("" + oi.oCustomersContact.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td valign=\"top\">\r\n");
	templateBuilder.Append("联系电话:\r\n");

	if (Act=="v")
	{

	templateBuilder.Append("" + oi.oCustomersTel.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\" valign=\"top\">\r\n");
	templateBuilder.Append("      地址:\r\n");

	if (Act=="v")
	{

	templateBuilder.Append("" + oi.oCustomersAddress.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td valign=\"top\">客户订单号:\r\n");

	if (Act=="v")
	{

	templateBuilder.Append("" + oi.oCustomersOrderID.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("    <td valign=\"top\">客户指定门店:\r\n");

	if (Act=="v")
	{

	templateBuilder.Append("" + oi.oCustomersNameB.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("	<tr class=\"tBar\">\r\n");
	templateBuilder.Append("	  <td width=\"80px\">仓库</td>\r\n");
	templateBuilder.Append("	  <td width=\"100px\">条码</td>\r\n");
	templateBuilder.Append("	  <td>商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">包装量</td>\r\n");
	templateBuilder.Append("	  <!--<td width=\"80px\">单价(元)</td>-->\r\n");
	templateBuilder.Append("	  <td width=\"120px\">单据数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)</td>\r\n");
	templateBuilder.Append("	  <td width=\"120px\">已出库数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)</td>\r\n");
	templateBuilder.Append("		<td width=\"120px\">\r\n");
	templateBuilder.Append("        剩余数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)\r\n");
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("     <td width=\"120px\">\r\n");
	templateBuilder.Append("        本次出库数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)\r\n");
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("	</tr>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  <div id=\"OrderListLoop\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\" id=\"OrderListLoop_data\">\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  </div>\r\n");
	templateBuilder.Append("  </td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append(" OrderField = '" + OrderFieldListJson.ToString() + "';\r\n");
	templateBuilder.Append(" OrderListDataJsonStr = '" + OrderListDataJsonStr.ToString() + "';\r\n");
	templateBuilder.Append(" StorageOrderListJsonStr = '" + StorageOrderListJsonStr.ToString() + "';\r\n");
	templateBuilder.Append("</" + "script>\r\n");



	}	//end if

	templateBuilder.Append("                  <!--调整,坏货-->\r\n");

	if (ordertype==8 || ordertype==10)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("  <td>目标仓库: \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("" + oi.StoresSupplierName.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("日期:" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("	<tr class=\"tBar\">\r\n");
	templateBuilder.Append("	  <td width=\"100px\">仓库</td>\r\n");
	templateBuilder.Append("	  <td width=\"100px\">条码</td>\r\n");
	templateBuilder.Append("	  <td>商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">包装量</td>\r\n");
	templateBuilder.Append("	  <td width=\"120px\">单据数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)</td>\r\n");
	templateBuilder.Append("	  <td width=\"120px\">完成数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)</td>\r\n");
	templateBuilder.Append("		<td width=\"120px\">\r\n");
	templateBuilder.Append("        剩余数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)\r\n");
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td width=\"120px\">\r\n");
	templateBuilder.Append("        本次数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)\r\n");
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("	</tr>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  <div id=\"OrderListLoop\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\" id=\"OrderListLoop_data\">\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  </div>\r\n");
	templateBuilder.Append("  </td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append(" OrderField = '" + OrderFieldListJson.ToString() + "';\r\n");
	templateBuilder.Append(" OrderListDataJsonStr = '" + OrderListDataJsonStr.ToString() + "';\r\n");
	templateBuilder.Append(" StorageOrderListJsonStr = '" + StorageOrderListJsonStr.ToString() + "';\r\n");
	templateBuilder.Append("</" + "script>\r\n");



	}	//end if

	templateBuilder.Append("                  <!--调拨-->\r\n");

	if (ordertype==9)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("  <td>目标仓库: \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("" + oi.StoresSupplierName.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("日期:" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("	<tr class=\"tBar\">\r\n");
	templateBuilder.Append("	  <td width=\"100px\">仓库</td>\r\n");
	templateBuilder.Append("	  <td width=\"100px\">条码</td>\r\n");
	templateBuilder.Append("	  <td>商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">包装量</td>\r\n");
	templateBuilder.Append("	  <td width=\"120px\">单据数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)</td>\r\n");
	templateBuilder.Append("	  <td width=\"120px\">完成数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)</td>\r\n");
	templateBuilder.Append("		<td width=\"120px\">\r\n");
	templateBuilder.Append("        剩余数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)\r\n");
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td width=\"120px\">\r\n");
	templateBuilder.Append("        本次数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)\r\n");
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("	</tr>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  <div id=\"OrderListLoop\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\" id=\"OrderListLoop_data\">\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  </div>\r\n");
	templateBuilder.Append("  </td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append(" OrderField = '" + OrderFieldListJson.ToString() + "';\r\n");
	templateBuilder.Append(" OrderListDataJsonStr = '" + OrderListDataJsonStr.ToString() + "';\r\n");
	templateBuilder.Append(" StorageOrderListJsonStr = '" + StorageOrderListJsonStr.ToString() + "';\r\n");
	templateBuilder.Append("</" + "script>\r\n");



	}	//end if

	templateBuilder.Append("                  <!--数据调整-->\r\n");

	if (IsEditData == true)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td valign=\"top\">\r\n");
	 aspxrewriteurl = oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("      日期:<br /><input name=\"oOrderDateTime\" type=\"text\" id=\"oOrderDateTime\" onClick=\"new Calendar().show(this);\" value=\"" + aspxrewriteurl.ToString() + "\" readonly=\"readonly\"/></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("	<tr class=\"tBar\">\r\n");
	templateBuilder.Append("	  <td width=\"80px\">仓库</td>\r\n");
	templateBuilder.Append("	  <td width=\"100px\">条码</td>\r\n");
	templateBuilder.Append("	  <td>商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">包装量</td>\r\n");
	templateBuilder.Append("	  <td width=\"120px\">修正数量<br />\r\n");
	templateBuilder.Append("	    (最小单位)</td>\r\n");
	templateBuilder.Append("	  </tr>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  <div id=\"OrderListLoop\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\" id=\"OrderListLoop_data\">\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  </div>\r\n");
	templateBuilder.Append("  </td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");



	}	//end if

	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("              <div style=\"width:100%;height:80px\"></div>\r\n");
	templateBuilder.Append("<div id=\"footer_tool\">\r\n");
	templateBuilder.Append("<div style=\"width:100%\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("	  <td width=\"30px;\"  align=\"left\">本次操作备注:</td>\r\n");
	templateBuilder.Append("	  <td  align=\"left\" ><input type=\"text\" id=\"splRemake\" name=\"splRemake\" style=\"width:100%;\r\n");
	templateBuilder.Append("      text-align:left\" maxlength=\"500\" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");

	if (IsEditData == false)
	{

	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("	  <td width=\"30px;\"  align=\"left\">单据备注:</td>\r\n");
	templateBuilder.Append("	  <td  align=\"left\" >\r\n");

	if (Act == "v")
	{

	templateBuilder.Append("" + oi.oReMake.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");

	}	//end if

	templateBuilder.Append("	<tr class=\"tBar\">\r\n");
	templateBuilder.Append("	  <td align=\"left\">合计:</td>\r\n");
	templateBuilder.Append("	  <td width=\"95%\" align=\"right\" id=\"SumMoney\"></td>\r\n");
	templateBuilder.Append("     </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<input id=\"StoresSupplierID\" name=\"StoresSupplierID\" type=\"hidden\" />\r\n");
	templateBuilder.Append("<input id=\"OrderListDataJson\" name=\"OrderListDataJson\" type=\"hidden\"/>\r\n");
	templateBuilder.Append("<input id=\"pagecode\" name=\"pagecode\" type=\"hidden\" value=\"" + pagecode.ToString() + "\"/>\r\n");

	if (IsEditData == false)
	{

	templateBuilder.Append("<input type=\"button\" name=\"subbutton_print\" id=\"subbutton_print\" value=\" 打  印 \" class=\"B_INPUT\">\r\n");

	}	//end if

	templateBuilder.Append("<input type=\"button\" name=\"subbutton_save\" id=\"subbutton_save\" value=\" 保存记录 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("<!--<input type=\"button\" name=\"subbutton_log\" id=\"subbutton_log\" value=\" 查看记录 \" class=\"B_INPUT\">-->\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("</form>\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var OrderDO = new TOrderDO();\r\n");
	templateBuilder.Append("OrderDO.PrintPageWidth = '" + config.PrintPageWidth.ToString().Trim() + "';\r\n");
	templateBuilder.Append("OrderDO.PrintAddPageWidth = '" + config.PrintAddPageWidth.ToString().Trim() + "';\r\n");
	templateBuilder.Append("OrderDO.Order_lock = " + config.Order_lock.ToString().Trim() + ";\r\n");
	templateBuilder.Append("OrderDO.UserCode = '" + UserCode.ToString() + "';\r\n");
	templateBuilder.Append("OrderDO.ShowEdit = '" + ShowEdit.ToString() + "'=='False'?false:true;\r\n");
	templateBuilder.Append("OrderDO.OrderType = " + ordertype.ToString() + ";\r\n");
	templateBuilder.Append("OrderDO.OrderID = " + orderid.ToString() + ";\r\n");
	templateBuilder.Append("OrderDO.MoneyDecimal = " + config.MoneyDecimal.ToString().Trim() + ";\r\n");
	templateBuilder.Append("OrderDO.QuantityDecimal = " + config.QuantityDecimal.ToString().Trim() + ";\r\n");
	templateBuilder.Append("OrderDO.ShowPrice = false;\r\n");

	if (IsEditData == false)
	{


	if (Act == "v")
	{

	templateBuilder.Append("	OrderDO.Steps = " + oi.oSteps.ToString().Trim() + ";\r\n");
	templateBuilder.Append("	$().ready(function(){\r\n");
	templateBuilder.Append("	OrderDO.ReSetDataList();\r\n");
	templateBuilder.Append("	});\r\n");

	}	//end if


	if (IsMOrder == true)
	{


	if (_ms.mExpName!=null)
	{

	templateBuilder.Append("	OrderDO.IsMOrder = true;\r\n");
	templateBuilder.Append("	OrderDO.ExpID = '" + _ms.mExpName.ToString().Trim() + "';\r\n");
	templateBuilder.Append("	OrderDO.mExpNO = '" + _ms.mExpNO.ToString().Trim() + "';\r\n");
	templateBuilder.Append("	OrderDO.m_configid = '" + _ms.m_ConfigInfoID.ToString().Trim() + "';\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("//调拨单用\r\n");
	templateBuilder.Append("OrderDO.ini();\r\n");

	if (IsEditData == false)
	{


	if (Act == "v" )
	{

	templateBuilder.Append("	OrderDO.sel_StorageIDB = " + oi.StoresSupplierID.ToString().Trim() + ";\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("addTableListener(document.getElementById(\"tBoxsb\"),0,0);\r\n");
	templateBuilder.Append("</" + "script>\r\n");
	templateBuilder.Append("<object id=\"LODOP\" classid=\"clsid:2105C259-1E0C-4534-8141-A753534CB4CA\" width=0 height=0> \r\n");
	templateBuilder.Append("<embed id=\"LODOP_EM\" type=\"application/x-print-lodop\" width=0 height=0 pluginspage=\"/public/install_lodop.exe\"></embed>\r\n");
	templateBuilder.Append("</object>\r\n");

	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
