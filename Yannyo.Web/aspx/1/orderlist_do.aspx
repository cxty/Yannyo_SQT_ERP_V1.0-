<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.orderlist_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:24. 
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
	templateBuilder.Append("    <link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("    <script type=\"text/javascript\" src=\"public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("    <script type=\"text/javascript\" src=\"public/js/dialog.js \"></" + "script>\r\n");
	templateBuilder.Append("    <script src=\"public/js/WebCalendar.js\" type=\"text/javascript\"></" + "script>\r\n");
	templateBuilder.Append("    <script type=\"text/javascript\" src=\"/public/js/jquery.cookie.js\"></" + "script>\r\n");
	templateBuilder.Append("    <script type=\"text/javascript\" src=\"/public/js/jquery.hotkeys.js\"></" + "script>\r\n");
	templateBuilder.Append("    <script type=\"text/javascript\" src=\"/public/js/jquery.jstree.js\"></" + "script>\r\n");
	templateBuilder.Append("    <script type=\"text/javascript\" src=\"/public/js/jquery.maskedinput-1.2.2.min.js\"></" + "script>\r\n");
	templateBuilder.Append("    <script type=\"text/javascript\" src=\"/public/js/orderdo.js\"></" + "script>\r\n");
	templateBuilder.Append("    <script src=\"public/js/LodopFuncs.js\" type=\"text/javascript\"></" + "script>\r\n");

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

	templateBuilder.Append("    <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("                <td colspan=\"2\" align=\"left\">\r\n");
	 aspxrewriteurl = GetOrderType(ordertype.ToString());
	
	templateBuilder.Append("                    <h2>\r\n");
	templateBuilder.Append("                        " + aspxrewriteurl.ToString() + "\r\n");

	if (Act=="v")
	{


	if (oi.oState==1)
	{

	templateBuilder.Append("                        (已经作废)\r\n");

	}
	else
	{

	 aspxrewriteurl = GetOrderStpes(oi.oSteps.ToString());
	
	templateBuilder.Append("                        (" + aspxrewriteurl.ToString() + ")\r\n");

	}	//end if

	templateBuilder.Append("                        &nbsp;&nbsp;&nbsp;&nbsp;单号:" + oi.oOrderNum.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("                    </h2>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("                <td width=\"20%\" align=\"left\" valign=\"top\" id=\"tTreeBox\">\r\n");

	if (Act=="1" || ShowTree == true)
	{

	templateBuilder.Append("                    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                            <td align=\"left\" valign=\"top\"><div id=\"tTree\" class=\"tTree\"></div></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                    </table>\r\n");

	}
	else
	{

	templateBuilder.Append("                    <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("                        $('#tTreeBox').hide();\r\n");
	templateBuilder.Append("                        $('#hide_tree_p_box').hide();\r\n");
	templateBuilder.Append("                    </" + "script>\r\n");

	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"left\" valign=\"top\">\r\n");
	templateBuilder.Append("                    <!--采购-->\r\n");

	if (ordertype==1 || ordertype ==2)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>供货商:<br />\r\n");
	templateBuilder.Append("      <input name=\"SupplierName\" id=\"SupplierName\" type=\"text\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.StoresSupplierName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"输入*可检索\"\r\n");
	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("<INPUT TYPE=\"hidden\" NAME=\"SupplierID\" id=\"SupplierID\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.StoresSupplierID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("日期:<br /><input name=\"oOrderDateTime\" type=\"text\" id=\"oOrderDateTime\" onClick=\"new Calendar().show(this);\" value=\"" + aspxrewriteurl.ToString() + "\" readonly=\"readonly\" showtitle=\"点击输入日期\"/></td>\r\n");
	templateBuilder.Append("    <td align=\"left\">预付款:<br />\r\n");
	templateBuilder.Append("            <input type=\"radio\" class=\"B_Check\" name=\"oPrepay\" value=\"1\" id=\"oPrepay_0\" \r\n");

	if (Act=="v")
	{


	if (oi.oPrepay==1)
	{

	templateBuilder.Append("            checked=\"checked\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("            />\r\n");
	templateBuilder.Append("            需要\r\n");
	templateBuilder.Append("            <input name=\"oPrepay\" class=\"B_Check\" type=\"radio\" id=\"oPrepay_1\" value=\"0\" \r\n");

	if (Act=="v")
	{


	if (oi.oPrepay==0)
	{

	templateBuilder.Append("            checked=\"checked\"\r\n");

	}	//end if


	}
	else
	{

	templateBuilder.Append("            checked=\"checked\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("            不需要\r\n");

	if (Act=="v")
	{


	if (oi.oPrepay==1)
	{

	templateBuilder.Append("            <a href=\"javascript:void(0);\" onclick=\"javascript:OrderDO.SHCertificateList();\">已预付:" + PrepayMoney.ToString() + "</a>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("	<tr class=\"tBar\">\r\n");
	templateBuilder.Append("	  <td width=\"80px\">仓库</td>\r\n");
	templateBuilder.Append("	  <td width=\"100px\">条码</td>\r\n");
	templateBuilder.Append("	  <td align=\"left\">商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"30px\">包装量</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">单价(元)</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">数量(最小单位)</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">金额</td>\r\n");

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;

	templateBuilder.Append("      	<td width=\"80px\">" + ofl["fName"].ToString().Trim() + "</td>\r\n");

	}	//end loop


	}	//end if


	if (ShowEdit == true)
	{

	templateBuilder.Append("	  <td width=\"50px\" >操作</td>\r\n");

	}	//end if

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
	templateBuilder.Append("$().ready(function(){\r\n");
	templateBuilder.Append("	$('#SupplierName').autocomplete('Services/CAjax.aspx',{\r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetSupplierList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'SupplierName':function(){return $('#SupplierName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value,\r\n");
	templateBuilder.Append("					ApMoney:tArray[i].ApMoney,\r\n");
	templateBuilder.Append("					NpMoney:tArray[i].NpMoney\r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted) {\r\n");
	templateBuilder.Append("			$(\"#SupplierID\").val((formatted!=null)?formatted:\"0\");      \r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("});\r\n");
	templateBuilder.Append(" OrderField = '" + OrderFieldListJson.ToString() + "';\r\n");
	templateBuilder.Append(" OrderListDataJsonStr = '" + OrderListDataJsonStr.ToString() + "';\r\n");
	templateBuilder.Append("</" + "script>\r\n");



	}	//end if

	templateBuilder.Append("                    <!--销售-->\r\n");

	if (ordertype==3 || ordertype == 4 || ordertype==5 || ordertype==6 || ordertype==7 || ordertype==11 )
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td valign=\"top\">\r\n");
	templateBuilder.Append("    客 户:<br>\r\n");
	templateBuilder.Append("    <input name=\"StoresName\" id=\"StoresName\" type=\"text\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.StoresSupplierName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"输入*检索\"\r\n");
	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("<INPUT TYPE=\"hidden\" NAME=\"StoresID\" id=\"StoresID\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.StoresSupplierID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("<input type=\"hidden\" name=\"PriceClassID\" id=\"PriceClassID\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.PriceClassID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    <td valign=\"top\">客户编号: <br><span id=\"sCode\">\r\n");

	if (Act=="v")
	{

	templateBuilder.Append("" + oi.StoresSupplierCode.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("</span></td>\r\n");
	templateBuilder.Append("    <td valign=\"top\">\r\n");
	templateBuilder.Append("业务员:<br />\r\n");
	templateBuilder.Append("<input name=\"StaffName\" id=\"StaffName\" type=\"text\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.StaffName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"输入*检索\"\r\n");
	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("<INPUT TYPE=\"hidden\" NAME=\"StaffID\" id=\"StaffID\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.StaffID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td valign=\"top\">\r\n");
	 aspxrewriteurl = oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("日期:<br /><input name=\"oOrderDateTime\" type=\"text\" id=\"oOrderDateTime\" onClick=\"new Calendar().show(this);\" value=\"" + aspxrewriteurl.ToString() + "\" readonly=\"readonly\"/>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td valign=\"top\">\r\n");
	templateBuilder.Append("联系人:<br /><input type=\"text\" id=\"oCustomersContact\" name=\"oCustomersContact\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.oCustomersContact.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("  />\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td valign=\"top\">\r\n");
	templateBuilder.Append("联系电话:<br /><input type=\"text\" id=\"oCustomersTel\" name=\"oCustomersTel\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.oCustomersTel.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("  />\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\" valign=\"top\">\r\n");
	templateBuilder.Append("      地址:<br />      <input type=\"text\" id=\"oCustomersAddress\" style=\"width:300px\" name=\"oCustomersAddress\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.oCustomersAddress.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("  />\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td valign=\"top\">客户订单号:<br /><input type=\"text\" id=\"oCustomersOrderID\"  name=\"oCustomersOrderID\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.oCustomersOrderID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("  /></td>\r\n");
	templateBuilder.Append("    <td valign=\"top\">客户指定门店:<br /><input type=\"text\" id=\"oCustomersNameB\"  name=\"oCustomersNameB\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.oCustomersNameB.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("  /></td>\r\n");
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
	templateBuilder.Append("	  <td width=\"30px\">包装量</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">单价(元)</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">数量(最小单位)</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">金额</td>\r\n");

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;

	templateBuilder.Append("      	<td width=\"80px\">" + ofl["fName"].ToString().Trim() + "</td>\r\n");

	}	//end loop


	}	//end if


	if (ShowEdit == true)
	{

	templateBuilder.Append("	  <td width=\"50px\" >操作</td>\r\n");

	}	//end if

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
	templateBuilder.Append("$().ready(function(){\r\n");
	templateBuilder.Append("	$('#StoresName').autocomplete('Services/CAjax.aspx',{\r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetStoresInfoList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'StoresName':function(){return $('#StoresName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value,\r\n");
	templateBuilder.Append("					sCode:tArray[i].info,\r\n");
	templateBuilder.Append("					CustomersClassID:tArray[i].CustomersClassID,\r\n");
	templateBuilder.Append("					CustomersClassName:tArray[i].CustomersClassName,\r\n");
	templateBuilder.Append("					PriceClassID:tArray[i].PriceClassID,\r\n");
	templateBuilder.Append("					PriceClassName:tArray[i].PriceClassName,\r\n");
	templateBuilder.Append("					sType:tArray[i].sType,\r\n");
	templateBuilder.Append("					sIsFZYH:tArray[i].sIsFZYH,\r\n");
	templateBuilder.Append("					YHsysName:tArray[i].YHsysName,\r\n");
	templateBuilder.Append("					sContact:tArray[i].sContact,\r\n");
	templateBuilder.Append("					sTel:tArray[i].sTel,\r\n");
	templateBuilder.Append("					sAddress:tArray[i].sAddress,\r\n");
	templateBuilder.Append("					StaffID:tArray[i].StaffID,\r\n");
	templateBuilder.Append("					StaffName:tArray[i].StaffName\r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted, row) {\r\n");
	templateBuilder.Append("			$(\"#sCode\").html(row.sCode);\r\n");
	templateBuilder.Append("			$('#StaffName').val(row.StaffName);\r\n");
	templateBuilder.Append("			$('#StaffID').val(row.StaffID);\r\n");
	templateBuilder.Append("			$('#oCustomersContact').val(row.sContact);\r\n");
	templateBuilder.Append("			$('#oCustomersTel').val(row.sTel);\r\n");
	templateBuilder.Append("			$('#oCustomersAddress').val(row.sAddress);\r\n");
	templateBuilder.Append("			$(\"#StoresID\").val((formatted!=null)?formatted:\"0\");   \r\n");
	templateBuilder.Append("			$(\"#PriceClassID\").val(row.PriceClassID);\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("	$('#StaffName').autocomplete('Services/CAjax.aspx',{\r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetStaffList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'sType':1,//只调用业务员数据\r\n");
	templateBuilder.Append("			'StaffName':function(){return $('#StaffName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value\r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted) {\r\n");
	templateBuilder.Append("			$(\"#StaffID\").val((formatted!=null)?formatted:\"0\");      \r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("});\r\n");
	templateBuilder.Append(" OrderField = '" + OrderFieldListJson.ToString() + "';\r\n");
	templateBuilder.Append(" OrderListDataJsonStr = '" + OrderListDataJsonStr.ToString() + "';\r\n");
	templateBuilder.Append("</" + "script>\r\n");



	}	//end if

	templateBuilder.Append("                    <!--调整,坏货-->\r\n");

	if (ordertype==8 || ordertype==10)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("  <td>目标仓库:<br />\r\n");
	templateBuilder.Append("      <input name=\"StorageName\" id=\"StorageName\" type=\"text\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.StoresSupplierName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"输入*可检索\"\r\n");
	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("<INPUT TYPE=\"hidden\" NAME=\"StorageID\" id=\"StorageID\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.StoresSupplierID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("日期:<br /><input name=\"oOrderDateTime\" type=\"text\" id=\"oOrderDateTime\" onClick=\"new Calendar().show(this);\" value=\"" + aspxrewriteurl.ToString() + "\" readonly=\"readonly\"/></td>\r\n");
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
	templateBuilder.Append("	  <td width=\"80px\">单价(元)</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">数量(最小单位)</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">金额</td>\r\n");

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;

	templateBuilder.Append("      	<td width=\"80px\">" + ofl["fName"].ToString().Trim() + "</td>\r\n");

	}	//end loop


	}	//end if


	if (ShowEdit == true)
	{

	templateBuilder.Append("	  <td width=\"50px\" >操作</td>\r\n");

	}	//end if

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
	templateBuilder.Append("$().ready(function(){\r\n");
	templateBuilder.Append("	$('#StorageName').autocomplete('Services/CAjax.aspx',{\r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetStorageList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'StorageName':function(){return $('#StorageName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value\r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted) {\r\n");
	templateBuilder.Append("			$(\"#StorageID\").val((formatted!=null)?formatted:\"0\"); \r\n");
	templateBuilder.Append("			OrderDO.sel_StorageIDB = (formatted!=null)?formatted:\"0\"; \r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("});\r\n");
	templateBuilder.Append(" OrderField = '" + OrderFieldListJson.ToString() + "';\r\n");
	templateBuilder.Append(" OrderListDataJsonStr = '" + OrderListDataJsonStr.ToString() + "';\r\n");
	templateBuilder.Append("</" + "script>\r\n");



	}	//end if

	templateBuilder.Append("                    <!--调拨-->\r\n");

	if (ordertype==9)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("  <td>目标仓库:<br />\r\n");
	templateBuilder.Append("      <input name=\"StorageName\" id=\"StorageName\" type=\"text\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.StoresSupplierName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"输入*可检索\"\r\n");
	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("<INPUT TYPE=\"hidden\" NAME=\"StorageID\" id=\"StorageID\" \r\n");

	if (Act=="v")
	{

	templateBuilder.Append("value=\"" + oi.StoresSupplierID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("日期:<br /><input name=\"oOrderDateTime\" type=\"text\" id=\"oOrderDateTime\" onClick=\"new Calendar().show(this);\" value=\"" + aspxrewriteurl.ToString() + "\" readonly=\"readonly\"/></td>\r\n");
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
	templateBuilder.Append("	  <td width=\"80px\">单价(元)</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">数量(最小单位)</td>\r\n");
	templateBuilder.Append("	  <td width=\"80px\">金额</td>\r\n");

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;

	templateBuilder.Append("      	<td width=\"80px\">" + ofl["fName"].ToString().Trim() + "</td>\r\n");

	}	//end loop


	}	//end if


	if (ShowEdit == true)
	{

	templateBuilder.Append("	  <td width=\"50px\" >操作</td>\r\n");

	}	//end if

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
	templateBuilder.Append("$().ready(function(){\r\n");
	templateBuilder.Append("	$('#StorageName').autocomplete('Services/CAjax.aspx',{\r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetStorageList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'StorageName':function(){return $('#StorageName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value\r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted) {\r\n");
	templateBuilder.Append("			$(\"#StorageID\").val((formatted!=null)?formatted:\"0\"); \r\n");
	templateBuilder.Append("			OrderDO.sel_StorageIDB = (formatted!=null)?formatted:\"0\"; \r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("});\r\n");
	templateBuilder.Append(" OrderField = '" + OrderFieldListJson.ToString() + "';\r\n");
	templateBuilder.Append(" OrderListDataJsonStr = '" + OrderListDataJsonStr.ToString() + "';\r\n");
	templateBuilder.Append("</" + "script>\r\n");



	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("        <div style=\"width:100%;height:200px\"></div>\r\n");
	templateBuilder.Append("        <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("            <div style=\"width:100%\">\r\n");

	if (Act=="1" || ShowTree == true)
	{

	templateBuilder.Append("                <div id=\"hide_tree_p_box\" class=\"tBar\" style=\"text-align:left\">\r\n");
	templateBuilder.Append("                    <input name=\"hide_p\" type=\"checkbox\" id=\"hide_p\" form=\"hide_p_box\" style=\"width:30px;\"\r\n");

	if (ordertype!=1 && ordertype !=2)
	{

	templateBuilder.Append("                    checked\r\n");

	}	//end if

	templateBuilder.Append("                    />过滤“0”库存商品\r\n");
	templateBuilder.Append("                </div>\r\n");

	}	//end if

	templateBuilder.Append("                <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("                    <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                        <td style=\"width:80px;\" align=\"left\">浏览地址:</td>\r\n");
	templateBuilder.Append("                        <td align=\"left\"><input style=\"width:90%;text-align:left\" readonly value=\"" + Order_QRCode_URL.ToString() + "\" /></td>\r\n");
	templateBuilder.Append("                    </tr>\r\n");
	templateBuilder.Append("                    <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                        <td align=\"left\">备注:</td>\r\n");
	templateBuilder.Append("                        <td align=\"left\">\r\n");
	templateBuilder.Append("                            <input name=\"oReMake\" type=\"text\" id=\"oReMake\" style=\"width:90%;\r\n");
	templateBuilder.Append("      text-align:left\" maxlength=\"500\" \r\n");

	if (Act == "v")
	{

	templateBuilder.Append("value=\"" + oi.oReMake.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" >\r\n");
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                    </tr>\r\n");
	templateBuilder.Append("                    <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                        <td align=\"left\">合计:</td>\r\n");
	templateBuilder.Append("                        <td align=\"right\" id=\"SumMoney\"></td>\r\n");
	templateBuilder.Append("                    </tr>\r\n");
	templateBuilder.Append("                </table>\r\n");
	templateBuilder.Append("            </div>\r\n");

	if (Act=="v")
	{

	templateBuilder.Append("            <!--随附凭证-->\r\n");
	templateBuilder.Append("            <div id=\"CertificateList\" style=\"text-align:left;width:100%;\">\r\n");
	templateBuilder.Append("                <div class=\"tBar\" id=\"CertificateList_tool\" style=\"width:100%;\">随附凭证</div>\r\n");
	templateBuilder.Append("                <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tBox\" id=\"tBoxsb\">\r\n");
	templateBuilder.Append("                    <thead>\r\n");
	templateBuilder.Append("                        <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                            <td width=\"5%\">序号</td>\r\n");
	templateBuilder.Append("                            <td>凭证编号</td>\r\n");
	templateBuilder.Append("                            <td width=\"20%\">单位</td>\r\n");
	templateBuilder.Append("                            <td width=\"10%\">经办人</td>\r\n");
	templateBuilder.Append("                            <td width=\"10%\" align=\"right\">金额</td>\r\n");
	templateBuilder.Append("                            <td width=\"10%\" align=\"right\">发生时间</td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                    </thead>\r\n");
	templateBuilder.Append("                    <tbody id=\"dloop\">\r\n");

	if (CertificateList!=null)
	{


	int cl__loop__id=0;
	foreach(DataRow cl in CertificateList.Rows)
	{
		cl__loop__id++;

	templateBuilder.Append("                        <tr certificateid=\"" + cl["CertificateID"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("                            <td width=\"5%\">" + cl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("                            <td>" + cl["cCode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                            <td>" + cl["toObjectName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                            <td width=\"10%\">" + cl["StaffName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                            <td width=\"10%\" align=\"right\" class=\"loop_Money\">\r\n");
	templateBuilder.Append("                                " + cl["cMoney"].ToString().Trim() + "\r\n");
	 cSumMoney = Convert.ToDecimal(cSumMoney+Convert.ToDecimal(cl["cMoney"]));
	
	templateBuilder.Append("                            </td>\r\n");
	templateBuilder.Append("                            <td width=\"10%\" align=\"right\">\r\n");
	 aspxrewriteurl = Convert.ToDateTime(cl["cDateTime"]).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("                            </td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("                    </tbody>\r\n");
	templateBuilder.Append("                    <tfoot>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                            <td>合计</td>\r\n");
	templateBuilder.Append("                            <td>&nbsp;</td>\r\n");
	templateBuilder.Append("                            <td>&nbsp;</td>\r\n");
	templateBuilder.Append("                            <td>&nbsp;</td>\r\n");
	templateBuilder.Append("                            <td align=\"right\" class=\"loop_Money\">" + cSumMoney.ToString() + "</td>\r\n");
	templateBuilder.Append("                            <td align=\"right\">&nbsp;</td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                    </tfoot>\r\n");
	templateBuilder.Append("                </table>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if

	templateBuilder.Append("            <input id=\"StoresSupplierID\" name=\"StoresSupplierID\" type=\"hidden\" />\r\n");
	templateBuilder.Append("            <input id=\"OrderListDataJson\" name=\"OrderListDataJson\" type=\"hidden\" />\r\n");
	templateBuilder.Append("            <input id=\"pagecode\" name=\"pagecode\" type=\"hidden\" value=\"" + pagecode.ToString() + "\" />\r\n");

	if (Act == "1")
	{

	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_add\" id=\"subbutton_add\" value=\" 提  交 \" class=\"B_INPUT\">\r\n");

	}	//end if


	if (Act == "v" && IsVerify == true)
	{

	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_update\" id=\"subbutton_update\" value=\" 更  新 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_verify\" id=\"subbutton_verify\" value=\" 审  核 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("            <!--<input type=\"button\" name=\"subbutton_print_t\" id=\"subbutton_print_t\" value=\" 打印订单 \" class=\"B_INPUT\">-->\r\n");

	}	//end if


	if (Act == "v" && IsVerify == false)
	{


	if (IsFirst == true)
	{

	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_return\" id=\"subbutton_return\" value=\" 返回 \" class=\"B_INPUT\">\r\n");

	}
	else
	{


	if (oi.oState == 0)
	{


	if (oi.oSteps == 2)
	{


	if (oi.oPrepay == 1)
	{

	templateBuilder.Append("            <!--需预付款操作-->\r\n");
	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_prepay\" id=\"subbutton_prepay\" value=\" 预付款 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("            -&gt;\r\n");

	}	//end if


	if (IsPrepayOK==true)
	{

	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_delivery\" id=\"subbutton_delivery\" value=\" 发  货 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("            -&gt;\r\n");

	}	//end if


	}	//end if


	if (oi.oSteps <= 3)
	{

	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_receiving\" id=\"subbutton_receiving\" value=\" 收  货 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("            -&gt;\r\n");

	}	//end if


	if (oi.oSteps <= 4)
	{

	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_verification\" id=\"subbutton_verification\" value=\" 核  销 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("            &nbsp;&nbsp;&nbsp;&nbsp;\r\n");

	}	//end if


	if (oi.oSteps == 3)
	{

	templateBuilder.Append("            <!--<input type=\"button\" name=\"subbutton_update\" id=\"subbutton_update\" value=\" 更  新 \" class=\"B_INPUT\">-->\r\n");

	}	//end if


	}	//end if


	if (IsNOFull == true)
	{

	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_isnofull\" id=\"subbutton_isnofull\" style=\"width:120px\" value=\" 商品差额去向 \" class=\"B_INPUT\">\r\n");

	}	//end if


	if (IsNOFullAndNOToDo == true)
	{

	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_isnofullandnotodo\" id=\"subbutton_isnofullandnotodo\" style=\"width:120px\" value=\" 差额需转新单 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_isnofullandnotodo_no\" id=\"subbutton_isnofullandnotodo_no\" style=\"width:120px\" value=\" 差额无需转新单 \" class=\"B_INPUT\">\r\n");

	}	//end if

	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_first\" id=\"subbutton_first\" value=\" 查看订单 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_log\" id=\"subbutton_log\" value=\" 操作记录 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_print\" id=\"subbutton_print\" value=\" 打  印 \" class=\"B_INPUT\">\r\n");

	if (oi.oType == 3)
	{


	if (oi.oSteps >= 2 && oi.oSteps <= 3)
	{

	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_print_add\" id=\"subbutton_print_add\" value=\" 打印随附单 \" class=\"B_INPUT\">\r\n");

	}	//end if


	}	//end if


	if (IsMOrder == true)
	{

	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_print_exp\" id=\"subbutton_print_exp\" value=\" 打印运单 \" class=\"B_INPUT\">\r\n");

	}	//end if


	if (oi.oSteps == 2 && oi.oState == 0)
	{

	templateBuilder.Append("            <input type=\"button\" name=\"subbutton_invalid\" id=\"subbutton_invalid\" value=\" 作  废 \" class=\"B_INPUT\">\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("        </div>\r\n");
	templateBuilder.Append("    </form>\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("    <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("        var OrderDO = new TOrderDO();\r\n");
	templateBuilder.Append("        OrderDO.PrintPageWidth = '" + config.PrintPageWidth.ToString().Trim() + "';\r\n");
	templateBuilder.Append("        OrderDO.PrintAddPageWidth = '" + config.PrintAddPageWidth.ToString().Trim() + "';\r\n");
	templateBuilder.Append("        OrderDO.PrinterName = '" + config.PrinterName.ToString().Trim() + "';\r\n");
	templateBuilder.Append("        OrderDO.Order_lock = " + config.Order_lock.ToString().Trim() + ";\r\n");
	templateBuilder.Append("        OrderDO.UserCode = '" + UserCode.ToString() + "';\r\n");
	templateBuilder.Append("        OrderDO.ShowEdit = '" + ShowEdit.ToString() + "'=='False'?false:true;\r\n");
	templateBuilder.Append("        OrderDO.OrderType = " + ordertype.ToString() + ";\r\n");
	templateBuilder.Append("        OrderDO.OrderID = " + orderid.ToString() + ";\r\n");
	templateBuilder.Append("        OrderDO.MoneyDecimal = " + config.MoneyDecimal.ToString().Trim() + ";\r\n");
	templateBuilder.Append("        OrderDO.QuantityDecimal = " + config.QuantityDecimal.ToString().Trim() + ";\r\n");
	templateBuilder.Append("        OrderDO.EditDefaultPrice = '" + EditDefaultPrice.ToString() + "'=='False'?false:true;\r\n");

	if (CheckUserPopedoms("X") || CheckUserPopedoms("3-1-1-9") || CheckUserPopedoms("3-1-2-9") || CheckUserPopedoms("3-2-1-9") || CheckUserPopedoms("3-2-2-9") || CheckUserPopedoms("3-2-3-9") || CheckUserPopedoms("3-2-4-9") || CheckUserPopedoms("3-2-5-9") || CheckUserPopedoms("3-3-1-9") || CheckUserPopedoms("3-3-2-9") || CheckUserPopedoms("3-3-3-9"))
	{

	templateBuilder.Append("        OrderDO.ShowPrice = true;\r\n");

	}	//end if


	if (Act == "v")
	{

	templateBuilder.Append("        OrderDO.Steps = " + oi.oSteps.ToString().Trim() + ";\r\n");
	templateBuilder.Append("        $().ready(function(){\r\n");
	templateBuilder.Append("            OrderDO.ReSetDataList();\r\n");
	templateBuilder.Append("        });\r\n");

	}	//end if


	if (IsMOrder == true)
	{


	if (_ms.mExpName!=null)
	{

	templateBuilder.Append("        OrderDO.IsMOrder = true;\r\n");
	templateBuilder.Append("        OrderDO.ExpID = '" + _ms.mExpName.ToString().Trim() + "';\r\n");
	templateBuilder.Append("        OrderDO.mExpNO = '" + _ms.mExpNO.ToString().Trim() + "';\r\n");
	templateBuilder.Append("        OrderDO.m_configid = '" + _ms.m_ConfigInfoID.ToString().Trim() + "';\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("        //调拨单用\r\n");
	templateBuilder.Append("        OrderDO.ini();\r\n");

	if (Act == "v" )
	{

	templateBuilder.Append("        OrderDO.sel_StorageIDB = " + oi.StoresSupplierID.ToString().Trim() + ";\r\n");

	}	//end if

	templateBuilder.Append("        addTableListener(document.getElementById(\"tBoxsb\"),0,0);\r\n");
	templateBuilder.Append("    </" + "script>\r\n");
	templateBuilder.Append("    <object id=\"LODOP\" classid=\"clsid:2105C259-1E0C-4534-8141-A753534CB4CA\" width=0 height=0>\r\n");
	templateBuilder.Append("        <embed id=\"LODOP_EM\" type=\"application/x-print-lodop\" width=0 height=0 pluginspage=\"/public/install_lodop.exe\"></embed>\r\n");
	templateBuilder.Append("    </object>\r\n");

	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
