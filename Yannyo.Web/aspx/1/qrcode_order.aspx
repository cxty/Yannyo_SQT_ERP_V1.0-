<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.qrcode_order" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:32. 
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

	if (oi!=null)
	{

	templateBuilder.Append("            <h2>单据编号:" + oi.oOrderNum.ToString().Trim() + " 该单据打印时间:" + printdatetime.ToString() + "</h2>\r\n");

	if (oi.oType==3 || oi.oType==4 || oi.oType==5 || oi.oType==6 || oi.oType==7)
	{

	templateBuilder.Append("            <h2>单据信息:</h2>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"left\">单号:" + oi.oOrderNum.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td align=\"left\"> 客 户:\r\n");
	templateBuilder.Append("" + oi.StoresSupplierName.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td align=\"left\"> 业务员:\r\n");
	templateBuilder.Append("      " + oi.StaffName.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td align=\"left\">\r\n");
	 aspxrewriteurl = oi.oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("      日期:\r\n");
	templateBuilder.Append("      " + aspxrewriteurl.ToString() + " </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"left\">\r\n");
	templateBuilder.Append("联系人:" + oi.oCustomersContact.ToString().Trim() + "\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td align=\"left\"> 联系电话:" + oi.oCustomersTel.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\" align=\"left\">\r\n");
	templateBuilder.Append("      地址:" + oi.oCustomersAddress.ToString().Trim() + "    </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"left\">客户订单号:" + oi.oCustomersOrderID.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td colspan=\"3\" align=\"left\">客户指定门店:" + oi.oCustomersNameB.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"left\">企业注册号" + config.RegistrationNo.ToString().Trim() + ":</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\" align=\"left\">单位地址：" + config.Address.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td align=\"left\">电话：" + config.Phone.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<table width=\"98%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("	<tr >\r\n");
	templateBuilder.Append("	  <!--<td width=\"50\">仓库</td>-->\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">条码</td>\r\n");
	templateBuilder.Append("	  <td align=\"center\">商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">包装量</td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("	  <td width=\"50\" align=\"center\">单价<br />\r\n");
	templateBuilder.Append("	    (元)</td>\r\n");

	}	//end if

	templateBuilder.Append("	 <td width=\"50\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("	  <td width=\"50\" align=\"center\">件数</td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("	  <td width=\"50\" align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append("	</tr>\r\n");

	if (OrderList!=null)
	{


	int ol__loop__id=0;
	foreach(DataRow ol in OrderList.Rows)
	{
		ol__loop__id++;

	templateBuilder.Append("		<tr>\r\n");
	templateBuilder.Append("		  <!--<td width=\"80\">" + ol["StorageName"].ToString().Trim() + "</td>-->\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td>\r\n");

	if (ol["IsGifts"].ToString() !="0")
	{

	templateBuilder.Append("		  (赠)\r\n");

	}	//end if

	templateBuilder.Append("		  " + ol["ProductsName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td align=\"center\" >" + ol["ProductsToBoxNo"].ToString().Trim() + "</td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("		  <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oPrice"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("</td>\r\n");

	}	//end if

	templateBuilder.Append("		   <td  align=\"right\">\r\n");
	 sumQuantityM = Convert.ToDecimal(sumQuantityM+Convert.ToDecimal(ol["oQuantity"]));
	
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oQuantity"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "" + ol["ProductsUnits"].ToString().Trim() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("<td  align=\"right\">\r\n");
	 sumQuantityB = Convert.ToDecimal(sumQuantityB+Convert.ToDecimal(ol["oQuantity"])/Convert.ToDecimal(ol["ProductsToBoxNo"]));
	
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oQuantity"])/Convert.ToDecimal(ol["ProductsToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "" + ol["ProductsMaxUnits"].ToString().Trim() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("</td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("		  <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oMoney"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("</td>\r\n");

	}	//end if

	templateBuilder.Append("		</tr>\r\n");

	}	//end loop


	if (ShowMoney == true)
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 3);
	

	}
	else
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 2);
	

	}	//end if

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("    <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("    </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney,2).ToString();
	
	templateBuilder.Append("    <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("    </td>\r\n");

	}	//end if

	templateBuilder.Append("    </tr>\r\n");

	}	//end if

	templateBuilder.Append("  </table>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("  <div><!--合计:&yen;" + summoney.ToString() + " &nbsp;&nbsp;&nbsp;&nbsp;-->大写:人民币" + summoney_str.ToString() + "</div>\r\n");

	}	//end if


	}	//end if


	if (1==2)
	{

	templateBuilder.Append("            <h2>操作记录:</h2>\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tBox\" id=\"tBoxs\">\r\n");
	templateBuilder.Append("                <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                  <td width=\"25%\">操作时间</td>\r\n");
	templateBuilder.Append("                  <td width=\"20%\">操作员</td>\r\n");
	templateBuilder.Append("                  <td width=\"20%\">操作类型</td>\r\n");
	templateBuilder.Append("                  <td>备注</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("                <tr \r\n");

	if (printdatetime==dl["pAppendTime"].ToString())
	{

	templateBuilder.Append("                style=\"font-weight:bold;font-size:14px\"\r\n");

	}	//end if

	templateBuilder.Append("                >\r\n");
	templateBuilder.Append("                  <td>" + dl["pAppendTime"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                  <td>\r\n");

	if (dl["UserStaffName"].ToString()=="")
	{

	templateBuilder.Append("            " + dl["UserName"].ToString().Trim() + "\r\n");

	}
	else
	{

	templateBuilder.Append("            " + dl["UserStaffName"].ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                  <td>\r\n");

	if (dl["oType"].ToString() == "-1")
	{

	templateBuilder.Append("                  作废\r\n");

	}	//end if


	if (dl["oType"].ToString() == "0")
	{

	templateBuilder.Append("                  开单\r\n");

	}	//end if


	if (dl["oType"].ToString() == "1")
	{

	templateBuilder.Append("                  修改\r\n");

	}	//end if


	if (dl["oType"].ToString() == "2")
	{

	templateBuilder.Append("                  审核\r\n");

	}	//end if


	if (dl["oType"].ToString() == "3")
	{

	templateBuilder.Append("                  发货\r\n");

	}	//end if


	if (dl["oType"].ToString() == "4")
	{

	templateBuilder.Append("                  收货\r\n");

	}	//end if


	if (dl["oType"].ToString() == "5")
	{

	templateBuilder.Append("                  核销\r\n");

	}	//end if


	if (dl["oType"].ToString() == "6")
	{

	templateBuilder.Append("                  打印\r\n");

	}	//end if


	if (dl["oType"].ToString() == "7")
	{

	templateBuilder.Append("                  差额去向处理(调拨)\r\n");

	}	//end if


	if (dl["oType"].ToString() == "8")
	{

	templateBuilder.Append("                  差额转单处理\r\n");

	}	//end if


	if (dl["oType"].ToString() == "9")
	{

	templateBuilder.Append("                  随附凭证\r\n");

	}	//end if

	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                  <td>" + dl["oMsg"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("              </table>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("addTableListener(document.getElementById(\"tBoxs\"),0,0);\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
