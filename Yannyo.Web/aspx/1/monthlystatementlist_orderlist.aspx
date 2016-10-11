<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.monthlystatementlist_orderlist" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:16. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/monthlystatementlist_orderlist.js\"></" + "script>\r\n");

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

	templateBuilder.Append("        <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("<table border=\"0\" cellspacing=\"3\" cellpadding=\"3\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"left\">单据号:<br/><input name=\"oOrderNum\" id=\"oOrderNum\" value=\"" + oOrderNum.ToString() + "\" type=\"text\" /></td>\r\n");
	templateBuilder.Append("    <td align=\"left\">\r\n");
	templateBuilder.Append("    客户订单号:<br/><input name=\"oCustomersOrderID\" id=\"oCustomersOrderID\" value=\"" + oCustomersOrderID.ToString() + "\" type=\"text\" />\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td align=\"left\">单据时间:<br/><input name=\"oOrderDateTimeB\" id=\"oOrderDateTimeB\" style=\"width:80px\" value=\"" + oOrderDateTimeB.ToString() + "\" type=\"text\" onClick=\"new Calendar().show(this);\" readonly=\"readonly\"/>-<input name=\"oOrderDateTimeE\" id=\"oOrderDateTimeE\" style=\"width:80px\" value=\"" + oOrderDateTimeE.ToString() + "\" type=\"text\" onClick=\"new Calendar().show(this);\" readonly=\"readonly\"/></td>\r\n");
	templateBuilder.Append("    <td align=\"left\"><input type=\"button\" id=\"button_Search\" name=\"button_Search\" style=\"margin:5px;width:120px\" class=\"B_INPUT\" value=\" 单据查找 \"  /></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div class=\"datalist\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tBox\" id=\"tBoxs\">\r\n");
	templateBuilder.Append("  <thead>   \r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td width=\"5%\" colspan=\"8\" align=\"center\"><input type=\"checkbox\" name=\"checkbox\" id=\"checkbox_b\" class=\"B_Check\"></td>\r\n");
	templateBuilder.Append("    <td valign=\"top\" width=\"10%\" align=\"left\">单据编号</td>\r\n");
	templateBuilder.Append("	<td valign=\"top\" align=\"left\">\r\n");

	if (OrderType==2)
	{

	templateBuilder.Append("	客户\r\n");

	}	//end if


	if (OrderType==1)
	{

	templateBuilder.Append("	供应商\r\n");

	}	//end if

	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("    <td valign=\"top\" width=\"10%\" align=\"center\">单据类型</td>\r\n");
	templateBuilder.Append("    <td valign=\"top\" width=\"10%\" align=\"right\">总金额</td>\r\n");
	templateBuilder.Append("    <td valign=\"top\" width=\"10%\" align=\"right\">单据时间</td>\r\n");
	templateBuilder.Append("    <td valign=\"top\" width=\"10%\" align=\"center\">业务员</td>\r\n");
	templateBuilder.Append("    <td valign=\"top\" width=\"10%\" align=\"center\">操作员</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  </thead> \r\n");
	templateBuilder.Append("  <tbody id=\"dLoop\">\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("  <tr >\r\n");
	templateBuilder.Append("    <td colspan=\"8\" align=\"center\">\r\n");
	templateBuilder.Append("    <input type=\"checkbox\" name=\"checkbox_bb\" id=\"checkbox_bb_" + dl__loop__id.ToString() + "\" oOrderNum=\"" + dl["oOrderNum"].ToString().Trim() + "\"\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["SumMoney"]),2).ToString();
	
	templateBuilder.Append("     SumMoney=\"" + aspxrewriteurl.ToString() + "\"\r\n");
	 aspxrewriteurl = Convert.ToDateTime(dl["oOrderDateTime"]).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("     oOrderDateTime=\"" + aspxrewriteurl.ToString() + "\"\r\n");
	templateBuilder.Append("     StaffName=\"" + dl["StaffName"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("	 StoresSupplierName = \"" + dl["StoresSupplierName"].ToString().Trim() + "\"\r\n");
	 aspxrewriteurl = GetOrderType(dl["oType"].ToString());
	
	templateBuilder.Append("     oTypeStr=\"" + aspxrewriteurl.ToString() + "\"\r\n");
	templateBuilder.Append("     oType=\"" + dl["oType"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("     id=\"checkbox2\" value=\"" + dl["OrderID"].ToString().Trim() + "\"  class=\"B_Check\"></td>\r\n");
	templateBuilder.Append("    <td valign=\"top\" align=\"left\">" + dl["oOrderNum"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("	<td valign=\"top\" align=\"left\">" + dl["StoresSupplierName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td valign=\"top\" align=\"center\">\r\n");
	 aspxrewriteurl = GetOrderType(dl["oType"].ToString());
	
	templateBuilder.Append("            " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("    <td align=\"right\" valign=\"top\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["SumMoney"]),2).ToString();
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("			&nbsp;&nbsp;</td>\r\n");
	templateBuilder.Append("    <td valign=\"top\" align=\"right\">\r\n");
	 aspxrewriteurl = Convert.ToDateTime(dl["oOrderDateTime"]).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("    <td valign=\"top\" align=\"center\">" + dl["StaffName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td valign=\"top\" align=\"center\">\r\n");

	if (dl["UserStaffName"].ToString()=="")
	{

	templateBuilder.Append("            " + dl["UserName"].ToString().Trim() + "\r\n");

	}
	else
	{

	templateBuilder.Append("            " + dl["UserStaffName"].ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("  </tbody>\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td height=\"60\">&nbsp;</td>\r\n");
	templateBuilder.Append("    <td>&nbsp;</td>\r\n");
	templateBuilder.Append("    <td>&nbsp;</td>\r\n");
	templateBuilder.Append("    <td>&nbsp;</td>\r\n");
	templateBuilder.Append("    <td>&nbsp;</td>\r\n");
	templateBuilder.Append("    <td>&nbsp;</td>\r\n");
	templateBuilder.Append("    <td>&nbsp;</td>\r\n");
	templateBuilder.Append("    <td>&nbsp;</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div style=\"height:60px\"></div>\r\n");
	templateBuilder.Append("<div id=\"footer_tool\">\r\n");
	templateBuilder.Append("<div style=\"text-align:left\">\r\n");

	if (PageBarHTML!=null)
	{

	templateBuilder.Append("" + PageBarHTML.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<input type=\"button\" name=\"subbutton_add\" id=\"subbutton_add\" value=\" 添加选中 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("<input type=\"button\" name=\"subbutton_close\" id=\"subbutton_close\" value=\" 返回对账单 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("</form>        \r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var MonthlyStatementList_OrderList = new TMonthlyStatementList_OrderList();\r\n");
	templateBuilder.Append("MonthlyStatementList_OrderList.OrderType = " + OrderType.ToString() + ";\r\n");
	templateBuilder.Append("MonthlyStatementList_OrderList.StoresSupplierID = " + StoresSupplierID.ToString() + ";\r\n");
	templateBuilder.Append("MonthlyStatementList_OrderList.ini();	\r\n");
	templateBuilder.Append("addTableListener(document.getElementById(\"tBoxs\"),0,0);\r\n");
	templateBuilder.Append("function HidBox()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	MonthlyStatementList_OrderList.HidUserBox();\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
