<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.storage_order_print" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:46. 
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

	templateBuilder.Append("<div id=\"print_box\">\r\n");
	templateBuilder.Append("            <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\" class=\"print_box\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr class=\"print_box_top\">\r\n");
	templateBuilder.Append("                  <td align=\"center\">\r\n");
	templateBuilder.Append("&nbsp;\r\n");
	templateBuilder.Append("" + config.CompanyName.ToString().Trim() + "\r\n");
	 aspxrewriteurl = GetOrderType(ordertype.ToString());
	
	templateBuilder.Append("                  " + aspxrewriteurl.ToString() + "单\r\n");

	if (oi.oState==1)
	{

	templateBuilder.Append("                  	(已经作废)\r\n");

	}
	else
	{

	templateBuilder.Append("                      <br>注:*内部配货用*\r\n");

	}	//end if

	templateBuilder.Append("&nbsp;\r\n");
	templateBuilder.Append("<br><br>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"left\" valign=\"top\" >\r\n");
	templateBuilder.Append("                  <!--采购-->\r\n");

	if (ordertype==1 || ordertype ==2)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"98%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>单号:<br />" + oi.oOrderNum.ToString().Trim() + "\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    <td>供货商:<br />\r\n");
	templateBuilder.Append("" + oi.StoresSupplierName.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = oi.oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("日期:<br />" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("    <td align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"98%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("	<tr >\r\n");
	templateBuilder.Append("	  <td width=\"30\" align=\"center\">仓库</td>\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">条码</td>\r\n");
	templateBuilder.Append("	  <td align=\"center\">商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"30\" align=\"center\">包装量</td>\r\n");
	templateBuilder.Append("	  <td width=\"50\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("	  <td width=\"50\" align=\"center\">件数</td>\r\n");
	templateBuilder.Append("	</tr>\r\n");

	if (OrderList!=null)
	{


	int ol__loop__id=0;
	foreach(DataRow ol in OrderList.Rows)
	{
		ol__loop__id++;

	templateBuilder.Append("		<tr>\r\n");
	templateBuilder.Append("		  <td >" + ol["StorageName"].ToString().Trim() + "&nbsp;</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsBarcode"].ToString().Trim() + "&nbsp;</td>\r\n");
	templateBuilder.Append("		  <td>\r\n");

	if (ol["IsGifts"].ToString() !="0")
	{

	templateBuilder.Append("		  (赠)\r\n");

	}	//end if

	templateBuilder.Append("		  " + ol["ProductsName"].ToString().Trim() + "&nbsp;</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsToBoxNo"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td  align=\"right\">\r\n");
	 sumQuantityM = Convert.ToDecimal(sumQuantityM+Convert.ToDecimal(ol["oQuantity"]));
	
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oQuantity"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "" + ol["ProductsUnits"].ToString().Trim() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("<td  align=\"right\">\r\n");
	 sumQuantityB = Convert.ToDecimal(sumQuantityB+Convert.ToDecimal(ol["oQuantity"])/Convert.ToDecimal(ol["ProductsToBoxNo"]));
	
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oQuantity"])/Convert.ToDecimal(ol["ProductsToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "" + ol["ProductsMaxUnits"].ToString().Trim() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("		</tr>\r\n");

	}	//end loop

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("    <td colspan=\"3\"></td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	}	//end if

	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");



	}	//end if

	templateBuilder.Append("                  <!--销售-->\r\n");

	if (ordertype==3 || ordertype == 4 || ordertype==5 || ordertype==6 || ordertype==7 || ordertype==11)
	{


	if (IsMOrder == true)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"98%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>发货单号:" + oi.oOrderNum.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td> 网店名称:\r\n");
	templateBuilder.Append("" + oi.StoresSupplierName.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td> 买家:\r\n");
	templateBuilder.Append("      " + BuyerName.ToString() + " </td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = oi.oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("      日期:\r\n");
	templateBuilder.Append("      " + aspxrewriteurl.ToString() + " </td>\r\n");
	templateBuilder.Append("    <td rowspan=\"5\" align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>\r\n");
	templateBuilder.Append("联系人:" + _ms.receiver_name.ToString().Trim() + "\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td colspan=\"3\"> 联系电话:" + _ms.receiver_mobile.ToString().Trim() + " " + _ms.receiver_phone.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>网店订单号:" + oi.oCustomersOrderID.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td colspan=\"3\"> 送货地址:" + _ms.receiver_state.ToString().Trim() + "" + _ms.receiver_city.ToString().Trim() + "" + _ms.receiver_district.ToString().Trim() + " " + oi.oCustomersAddress.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	if (_mxsp!=null)
	{

	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>物流公司:" + _mxsp.mExpName.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td colspan=\"3\">运单号:" + _ms.mExpNO.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	}	//end if

	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>企业注册号:" + config.RegistrationNo.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\">单位地址：" + config.Address.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td>电话：" + config.Phone.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"98%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("	<tr >\r\n");
	templateBuilder.Append("	  <!--<td width=\"50\">仓库</td>-->\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">条码</td>\r\n");
	templateBuilder.Append("	  <td align=\"center\">商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"30\" align=\"center\">包装量</td>\r\n");
	templateBuilder.Append("	 <td width=\"50\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("	  <td width=\"50\" align=\"center\">件数</td>\r\n");
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
	templateBuilder.Append("		</tr>\r\n");

	}	//end loop

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\"></td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	}	//end if

	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");



	}
	else
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"98%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>单号:" + oi.oOrderNum.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td> 客 户:\r\n");
	templateBuilder.Append("" + oi.StoresSupplierName.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td> 业务员:\r\n");
	templateBuilder.Append("      " + oi.StaffName.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = oi.oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("      日期:\r\n");
	templateBuilder.Append("      " + aspxrewriteurl.ToString() + " </td>\r\n");
	templateBuilder.Append("    <td rowspan=\"4\" align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>\r\n");
	templateBuilder.Append("联系人:" + oi.oCustomersContact.ToString().Trim() + "\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td> 联系电话:" + oi.oCustomersTel.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\">\r\n");
	templateBuilder.Append("      地址:" + oi.oCustomersAddress.ToString().Trim() + "    </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>客户订单号:" + oi.oCustomersOrderID.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td colspan=\"3\">客户指定门店:" + oi.oCustomersNameB.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>企业注册号:" + config.RegistrationNo.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\">单位地址：" + config.Address.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td>电话：" + config.Phone.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"98%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("	<tr >\r\n");
	templateBuilder.Append("	  <!--<td width=\"50\">仓库</td>-->\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">条码</td>\r\n");
	templateBuilder.Append("	  <td align=\"center\">商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">包装量</td>\r\n");
	templateBuilder.Append("	 <td width=\"50\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("	  <td width=\"50\" align=\"center\">件数</td>\r\n");
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
	templateBuilder.Append("		</tr>\r\n");

	}	//end loop

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\"></td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	}	//end if

	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");



	}	//end if


	}	//end if

	templateBuilder.Append("                  <!--调整,坏货-->\r\n");

	if (ordertype==8 || ordertype==10)
	{





	}	//end if

	templateBuilder.Append("                  <!--调拨-->\r\n");

	if (ordertype==9)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"98%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>单号:<br />" + oi.oOrderNum.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = oi.oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("      日期:<br />" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("    <td align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"99%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("	<tr >\r\n");
	templateBuilder.Append("	  <td width=\"60\" align=\"center\">仓库</td>\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">条码</td>\r\n");
	templateBuilder.Append("	  <td align=\"center\">商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"30\" align=\"center\">包装量</td>\r\n");
	templateBuilder.Append("	  <td width=\"45\" align=\"center\">数量<br>(小单位)</td>\r\n");
	templateBuilder.Append("	  <td width=\"45\" align=\"center\">数量<br>(大单位)</td>\r\n");
	templateBuilder.Append("	</tr>\r\n");

	if (OrderList!=null)
	{


	int ol__loop__id=0;
	foreach(DataRow ol in OrderList.Rows)
	{
		ol__loop__id++;

	templateBuilder.Append("		<tr>\r\n");
	templateBuilder.Append("		  <td >" + ol["StorageName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td>\r\n");

	if (ol["IsGifts"].ToString() !="0")
	{

	templateBuilder.Append("		  (赠)\r\n");

	}	//end if

	templateBuilder.Append("		  " + ol["ProductsName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td align=\"right\">" + ol["ProductsToBoxNo"].ToString().Trim() + "</td>\r\n");
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
	templateBuilder.Append("		</tr>\r\n");

	}	//end loop

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("    <td colspan=\"3\"></td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	}	//end if

	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");



	}	//end if

	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("			</form>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<div style=\"page-break-after: always\"></div>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
