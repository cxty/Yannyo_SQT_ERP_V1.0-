<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.orderprint" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2016-03-09 22:07:24. 
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


	if (act == "pl")
	{



	if (oi_array.Count>0)
	{


		 for(int y=0;y<oi_array.Count;y++){
			OrderPrintObj _oo = ((OrderPrintObj)oi_array[y]);
			OrderListSet = _oo.OrderListSet;
			oi = _oo.Order;
			OrderFieldList = _oo.OrderFieldList;
			OrderFieldValueList = _oo.OrderFieldValueList;
			ordertype = _oo.Order.oType;
			ShowMoney = _oo.ShowMoney;
			print_ui = _oo.print_ui;
			print_v_ui = _oo.print_v_ui;
		 

	if (OrderListSet != null)
	{


					for(int x=0;x<OrderListSet.Tables.Count;x++){
						OrderList= OrderListSet.Tables[x];
						OrderFieldCount = 0;
						sumQuantityM = 0;
						sumQuantityB = 0;
						summoney = 0;
				
	templateBuilder.Append("	<div class=\"print_box\">\r\n");
	templateBuilder.Append("		<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("			<tr class=\"print_box_top\">\r\n");
	templateBuilder.Append("				<td align=\"center\">\r\n");
	templateBuilder.Append("					&nbsp;\r\n");
	templateBuilder.Append("					" + config.CompanyName.ToString().Trim() + "\r\n");
	 aspxrewriteurl = GetOrderType(ordertype.ToString());
	
	templateBuilder.Append("					" + aspxrewriteurl.ToString() + "单\r\n");

	if (oi.oState==1)
	{

	templateBuilder.Append("					(已经作废)\r\n");

	}
	else
	{


	if (ot=="d")
	{

	templateBuilder.Append("					<br>注:*配货用,单据审核后该打印单据即无效*\r\n");

	}	//end if

	templateBuilder.Append("					<!--\r\n");
	 aspxrewriteurl = GetOrderStpes(oi.oSteps.ToString());
	
	templateBuilder.Append("						(" + aspxrewriteurl.ToString() + ")-->\r\n");

	}	//end if

	templateBuilder.Append("					&nbsp;\r\n");
	templateBuilder.Append("					<br><br>\r\n");
	templateBuilder.Append("				</td>\r\n");
	templateBuilder.Append("			</tr>\r\n");
	templateBuilder.Append("			<tr>\r\n");
	templateBuilder.Append("				<td align=\"left\" valign=\"top\">\r\n");
	templateBuilder.Append("					<!--采购-->\r\n");

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
	templateBuilder.Append("      <td><nobr>第" + (x+1).ToString() + "/" + OrderListSet.Tables.Count.ToString().Trim() + "页</nobr></td>\r\n");
	templateBuilder.Append("   <!-- <td align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>-->\r\n");
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

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount+1);
	
	templateBuilder.Append("      	<td width=\"80\" align=\"center\">" + ofl["fName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	if (ShowMoney == true)
	{

	templateBuilder.Append("	  <td width=\"50\" align=\"center\">单价<br />\r\n");
	templateBuilder.Append("	    (元)</td>\r\n");

	}	//end if

	templateBuilder.Append("	  <td width=\"50\" align=\"center\">数量</td>\r\n");
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
	templateBuilder.Append("		  <td >" + ol["StorageName"].ToString().Trim() + "&nbsp;</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsBarcode"].ToString().Trim() + "&nbsp;</td>\r\n");
	templateBuilder.Append("		  <td>\r\n");

	if (ol["IsGifts"].ToString() !="0")
	{

	templateBuilder.Append("		  (赠)\r\n");

	}	//end if

	templateBuilder.Append("		  " + ol["ProductsName"].ToString().Trim() + "&nbsp;</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsToBoxNo"].ToString().Trim() + "</td>\r\n");

	if (OrderFieldList!=null)
	{


	if (OrderFieldValueList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	templateBuilder.Append("					<td >\r\n");

	int ofvl__loop__id=0;
	foreach(DataRow ofvl in OrderFieldValueList.Rows)
	{
		ofvl__loop__id++;


	if (ofvl["OrderListID"].ToString() == ol["OrderListID"].ToString() && ofvl["OrderFieldID"].ToString()==ofl["OrderFieldID"].ToString())
	{

	templateBuilder.Append("							" + ofvl["oFieldValue"].ToString().Trim() + "&nbsp;\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("					</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if


	if (ShowMoney == true)
	{

	templateBuilder.Append("		  <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oPrice"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");

	}	//end if

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

	if (ShowMoney == true)
	{

	templateBuilder.Append("		  <td  align=\"right\">\r\n");
	 summoney = summoney+Convert.ToDecimal(ol["oMoney"]);
	
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oMoney"]),2).ToString();
	
	templateBuilder.Append("		 <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("		 </td>\r\n");

	}	//end if

	templateBuilder.Append("		</tr>\r\n");

	}	//end loop


	if (ShowMoney == true)
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 4);
	

	}
	else
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 3);
	

	}	//end if

	 sumQuantityM_page = sumQuantityM_page + sumQuantityM;
	
	 sumQuantityB_page = sumQuantityB_page + sumQuantityB;
	
	 summoney_page = summoney_page + summoney;
	

	if (OrderListSet.Tables.Count > 1)
	{

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>小计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	if ((x+1) == OrderListSet.Tables.Count)
	{

	templateBuilder.Append("    	<tr>\r\n");
	templateBuilder.Append("        <td>合计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney_page,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("  </table>\r\n");

	if ((x+1) == OrderListSet.Tables.Count)
	{


	if (ShowMoney == true)
	{

	templateBuilder.Append("  <div><!--合计:&yen;" + summoney.ToString() + " &nbsp;&nbsp;&nbsp;&nbsp;-->大写:人民币" + summoney_str.ToString() + "</div>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div>\r\n");

	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>白联:存根联 </td>\r\n");
	templateBuilder.Append("        <td>红联:财务联 </td>\r\n");
	templateBuilder.Append("        <td>绿联:回单联 </td>\r\n");
	templateBuilder.Append("        <td>蓝联:客户联</td>\r\n");
	templateBuilder.Append("        <td>黄联:仓管联</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("" + Print_Foot.ToString() + "\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("        <tr style=\"font-weight:bold\">\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                制单:" + print_ui.StaffName.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                审核:\r\n");

	if (print_v_ui!=null)
	{


	if (print_v_ui.StaffName!=null)
	{

	templateBuilder.Append("                " + print_v_ui.StaffName.ToString().Trim() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>仓管员:</td>\r\n");
	templateBuilder.Append("            <td>送货员:</td>\r\n");
	templateBuilder.Append("            <td>客户签收:</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\" valign=\"top\">\r\n");
	templateBuilder.Append("                福建省工商行政管理机关提示： 该供货凭证可作为出货台账，请注意保存两年。 <br />\r\n");
	templateBuilder.Append("                备注:" + oi.oReMake.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\" align=\"center\" valign=\"top\"><!--<img src=\"/barcode.aspx?codestr=" + oi.oOrderNum.ToString().Trim() + "&codetype=UPC-A\" width=\"190\" height=\"46\" />--></td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");


	templateBuilder.Append("</div>\r\n");



	}	//end if

	templateBuilder.Append("					<!--销售-->\r\n");

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
	templateBuilder.Append("      <td><nobr>第" + (x+1).ToString() + "/" + OrderListSet.Tables.Count.ToString().Trim() + "页</nobr></td>\r\n");
	templateBuilder.Append("   <!-- <td rowspan=\"5\" align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>-->\r\n");
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

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount+1);
	
	templateBuilder.Append("      	<td width=\"50px\" align=\"center\">" + ofl["fName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


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

	if (OrderFieldList!=null)
	{


	if (OrderFieldValueList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	templateBuilder.Append("					<td >\r\n");

	int ofvl__loop__id=0;
	foreach(DataRow ofvl in OrderFieldValueList.Rows)
	{
		ofvl__loop__id++;


	if (ofvl["OrderListID"].ToString() == ol["OrderListID"].ToString() && ofvl["OrderFieldID"].ToString()==ofl["OrderFieldID"].ToString())
	{

	templateBuilder.Append("							" + ofvl["oFieldValue"].ToString().Trim() + "&nbsp;\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("					</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if


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
	 summoney = summoney+Convert.ToDecimal(ol["oMoney"]);
	
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

	 sumQuantityM_page = sumQuantityM_page + sumQuantityM;
	
	 sumQuantityB_page = sumQuantityB_page + sumQuantityB;
	
	 summoney_page = summoney_page + summoney;
	

	if (OrderListSet.Tables.Count > 1)
	{

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>小计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	if ((x+1) == OrderListSet.Tables.Count)
	{

	templateBuilder.Append("    	<tr>\r\n");
	templateBuilder.Append("        <td>合计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney_page,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("  </table>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("  <div><!--合计:&yen;" + summoney.ToString() + " &nbsp;&nbsp;&nbsp;&nbsp;-->大写:人民币" + summoney_str.ToString() + "</div>\r\n");

	}	//end if

	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div>\r\n");

	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>白联:存根联 </td>\r\n");
	templateBuilder.Append("        <td>红联:财务联 </td>\r\n");
	templateBuilder.Append("        <td>绿联:回单联 </td>\r\n");
	templateBuilder.Append("        <td>蓝联:客户联</td>\r\n");
	templateBuilder.Append("        <td>黄联:仓管联</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("" + Print_Foot.ToString() + "\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("        <tr style=\"font-weight:bold\">\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                制单:" + print_ui.StaffName.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                审核:\r\n");

	if (print_v_ui!=null)
	{


	if (print_v_ui.StaffName!=null)
	{

	templateBuilder.Append("                " + print_v_ui.StaffName.ToString().Trim() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>仓管员:</td>\r\n");
	templateBuilder.Append("            <td>送货员:</td>\r\n");
	templateBuilder.Append("            <td>客户签收:</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\" valign=\"top\">\r\n");
	templateBuilder.Append("                福建省工商行政管理机关提示： 该供货凭证可作为出货台账，请注意保存两年。 <br />\r\n");
	templateBuilder.Append("                备注:" + oi.oReMake.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\" align=\"center\" valign=\"top\"><!--<img src=\"/barcode.aspx?codestr=" + oi.oOrderNum.ToString().Trim() + "&codetype=UPC-A\" width=\"190\" height=\"46\" />--></td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");


	templateBuilder.Append("</div>\r\n");



	}
	else
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"98%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>单号:" + oi.oOrderNum.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = oi.oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("      日期:" + aspxrewriteurl.ToString() + " </td>\r\n");
	templateBuilder.Append("    <td><nobr>第" + (x+1).ToString() + "/" + OrderListSet.Tables.Count.ToString().Trim() + "页</nobr></td>\r\n");
	templateBuilder.Append("    <!--<td rowspan=\"4\" align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>-->\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td> 客 户:" + oi.StoresSupplierName.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td> 业务员:" + oi.StaffName.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td>&nbsp;</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td> 联系人:" + oi.oCustomersContact.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td> 地址:" + oi.oCustomersAddress.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td> 联系电话:" + oi.oCustomersTel.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>客户订单号:" + oi.oCustomersOrderID.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\">客户指定配送点:" + oi.oCustomersNameB.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>企业注册号:" + config.RegistrationNo.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td>单位地址：" + config.Address.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td>电话：" + config.Phone.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"98%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("	<tr >\r\n");
	templateBuilder.Append("	  <td width=\"50\">仓库</td>\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">条码</td>\r\n");
	templateBuilder.Append("	  <td align=\"center\">商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">包装量</td>\r\n");

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount+1);
	
	templateBuilder.Append("      	<td width=\"50px\" align=\"center\"><nobr>" + ofl["fName"].ToString().Trim() + "</nobr></td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


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
	templateBuilder.Append("		  <td width=\"80\">" + ol["StorageName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td>\r\n");

	if (ol["IsGifts"].ToString() !="0")
	{

	templateBuilder.Append("		  (赠)\r\n");

	}	//end if

	templateBuilder.Append("		  " + ol["ProductsName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td align=\"center\" >" + ol["ProductsToBoxNo"].ToString().Trim() + "</td>\r\n");

	if (OrderFieldList!=null)
	{


	if (OrderFieldValueList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	templateBuilder.Append("					<td >\r\n");

	int ofvl__loop__id=0;
	foreach(DataRow ofvl in OrderFieldValueList.Rows)
	{
		ofvl__loop__id++;


	if (ofvl["OrderListID"].ToString() == ol["OrderListID"].ToString() && ofvl["OrderFieldID"].ToString()==ofl["OrderFieldID"].ToString())
	{

	templateBuilder.Append("							" + ofvl["oFieldValue"].ToString().Trim() + "&nbsp;&nbsp;\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("					</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if


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
	 summoney = summoney+Convert.ToDecimal(ol["oMoney"]);
	
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oMoney"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("</td>\r\n");

	}	//end if

	templateBuilder.Append("		</tr>\r\n");

	}	//end loop


	if (ShowMoney == true)
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 4);
	

	}
	else
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 3);
	

	}	//end if

	 sumQuantityM_page = sumQuantityM_page + sumQuantityM;
	
	 sumQuantityB_page = sumQuantityB_page + sumQuantityB;
	
	 summoney_page = summoney_page + summoney;
	

	if (OrderListSet.Tables.Count > 1)
	{

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td >小计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	if ((x+1) == OrderListSet.Tables.Count)
	{

	templateBuilder.Append("    	<tr>\r\n");
	templateBuilder.Append("        <td >合计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney_page,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("  </table>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("  <div><!--合计:&yen;" + summoney.ToString() + " &nbsp;&nbsp;&nbsp;&nbsp;-->大写:人民币" + summoney_str.ToString() + "</div>\r\n");

	}	//end if

	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div>\r\n");

	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>白联:存根联 </td>\r\n");
	templateBuilder.Append("        <td>红联:财务联 </td>\r\n");
	templateBuilder.Append("        <td>绿联:回单联 </td>\r\n");
	templateBuilder.Append("        <td>蓝联:客户联</td>\r\n");
	templateBuilder.Append("        <td>黄联:仓管联</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("" + Print_Foot.ToString() + "\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("        <tr style=\"font-weight:bold\">\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                制单:" + print_ui.StaffName.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                审核:\r\n");

	if (print_v_ui!=null)
	{


	if (print_v_ui.StaffName!=null)
	{

	templateBuilder.Append("                " + print_v_ui.StaffName.ToString().Trim() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>仓管员:</td>\r\n");
	templateBuilder.Append("            <td>送货员:</td>\r\n");
	templateBuilder.Append("            <td>客户签收:</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\" valign=\"top\">\r\n");
	templateBuilder.Append("                福建省工商行政管理机关提示： 该供货凭证可作为出货台账，请注意保存两年。 <br />\r\n");
	templateBuilder.Append("                备注:" + oi.oReMake.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\" align=\"center\" valign=\"top\"><!--<img src=\"/barcode.aspx?codestr=" + oi.oOrderNum.ToString().Trim() + "&codetype=UPC-A\" width=\"190\" height=\"46\" />--></td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");


	templateBuilder.Append("</div>\r\n");



	}	//end if


	}	//end if

	templateBuilder.Append("					<!--调整,坏货-->\r\n");

	if (ordertype==8 || ordertype==10)
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
	templateBuilder.Append("      <td><nobr>第" + (x+1).ToString() + "/" + OrderListSet.Tables.Count.ToString().Trim() + "页</nobr></td>\r\n");
	templateBuilder.Append("    <!--<td align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>-->\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"98%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\" bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("	<tr >\r\n");
	templateBuilder.Append("	  <td width=\"30\" align=\"center\">仓库</td>\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">条码</td>\r\n");
	templateBuilder.Append("	  <td align=\"center\">商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"30\" align=\"center\">包装量</td>\r\n");

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount+1);
	
	templateBuilder.Append("      	<td width=\"50px\" align=\"center\">" + ofl["fName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


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
	templateBuilder.Append("		  <td >" + ol["StorageName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td>\r\n");

	if (ol["IsGifts"].ToString() !="0")
	{

	templateBuilder.Append("		  (赠)\r\n");

	}	//end if

	templateBuilder.Append("		  " + ol["ProductsName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsToBoxNo"].ToString().Trim() + "</td>\r\n");

	if (OrderFieldList!=null)
	{


	if (OrderFieldValueList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	templateBuilder.Append("					<td >\r\n");

	int ofvl__loop__id=0;
	foreach(DataRow ofvl in OrderFieldValueList.Rows)
	{
		ofvl__loop__id++;


	if (ofvl["OrderListID"].ToString() == ol["OrderListID"].ToString() && ofvl["OrderFieldID"].ToString()==ofl["OrderFieldID"].ToString())
	{

	templateBuilder.Append("							" + ofvl["oFieldValue"].ToString().Trim() + "&nbsp;\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("					</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if


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

	templateBuilder.Append("		  <td  align=\"right\">\r\n");
	 summoney = summoney+Convert.ToDecimal(ol["oMoney"]);
	
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oMoney"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("</td>\r\n");

	}	//end if

	templateBuilder.Append("		</tr>\r\n");

	}	//end loop


	if (ShowMoney == true)
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 4);
	

	}
	else
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 3);
	

	}	//end if

	 sumQuantityM_page = sumQuantityM_page + sumQuantityM;
	
	 sumQuantityB_page = sumQuantityB_page + sumQuantityB;
	
	 summoney_page = summoney_page + summoney;
	

	if (OrderListSet.Tables.Count > 1)
	{

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>小计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	if ((x+1) == OrderListSet.Tables.Count)
	{

	templateBuilder.Append("    	<tr>\r\n");
	templateBuilder.Append("        <td>合计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney_page,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("  </table>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("  <div><!--合计:&yen;" + summoney.ToString() + " &nbsp;&nbsp;&nbsp;&nbsp;-->大写:人民币" + summoney_str.ToString() + "</div>\r\n");

	}	//end if

	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div>\r\n");

	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>白联:存根联 </td>\r\n");
	templateBuilder.Append("        <td>红联:财务联 </td>\r\n");
	templateBuilder.Append("        <td>绿联:回单联 </td>\r\n");
	templateBuilder.Append("        <td>蓝联:客户联</td>\r\n");
	templateBuilder.Append("        <td>黄联:仓管联</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("" + Print_Foot.ToString() + "\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("        <tr style=\"font-weight:bold\">\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                制单:" + print_ui.StaffName.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                审核:\r\n");

	if (print_v_ui!=null)
	{


	if (print_v_ui.StaffName!=null)
	{

	templateBuilder.Append("                " + print_v_ui.StaffName.ToString().Trim() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>仓管员:</td>\r\n");
	templateBuilder.Append("            <td>送货员:</td>\r\n");
	templateBuilder.Append("            <td>客户签收:</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\" valign=\"top\">\r\n");
	templateBuilder.Append("                福建省工商行政管理机关提示： 该供货凭证可作为出货台账，请注意保存两年。 <br />\r\n");
	templateBuilder.Append("                备注:" + oi.oReMake.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\" align=\"center\" valign=\"top\"><!--<img src=\"/barcode.aspx?codestr=" + oi.oOrderNum.ToString().Trim() + "&codetype=UPC-A\" width=\"190\" height=\"46\" />--></td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");


	templateBuilder.Append("</div>\r\n");



	}	//end if

	templateBuilder.Append("					<!--调拨-->\r\n");

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
	templateBuilder.Append("      <td><nobr>第" + (x+1).ToString() + "/" + OrderListSet.Tables.Count.ToString().Trim() + "页</nobr></td>\r\n");
	templateBuilder.Append("    <!--<td align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>-->\r\n");
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

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount+1);
	
	templateBuilder.Append("      	<td width=\"50\" align=\"center\">" + ofl["fName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	if (ShowMoney == true)
	{

	templateBuilder.Append("	  <td width=\"45\" align=\"center\">单价<br>(元)</td>\r\n");

	}	//end if

	templateBuilder.Append("	  <td width=\"45\" align=\"center\">数量<br>(小单位)</td>\r\n");
	templateBuilder.Append("	  <td width=\"45\" align=\"center\">数量<br>(大单位)</td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("	  <td width=\"45\" align=\"center\">金额<br>(元)</td>\r\n");

	}	//end if

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

	if (OrderFieldList!=null)
	{


	if (OrderFieldValueList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	templateBuilder.Append("					<td >\r\n");

	int ofvl__loop__id=0;
	foreach(DataRow ofvl in OrderFieldValueList.Rows)
	{
		ofvl__loop__id++;


	if (ofvl["OrderListID"].ToString() == ol["OrderListID"].ToString() && ofvl["OrderFieldID"].ToString()==ofl["OrderFieldID"].ToString())
	{

	templateBuilder.Append("							" + ofvl["oFieldValue"].ToString().Trim() + "&nbsp;\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("					</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if


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

	templateBuilder.Append("		  <td  align=\"right\">\r\n");
	 summoney = summoney+Convert.ToDecimal(ol["oMoney"]);
	
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oMoney"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("</td>\r\n");

	}	//end if

	templateBuilder.Append("		</tr>\r\n");

	}	//end loop


	if (ShowMoney == true)
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 4);
	

	}
	else
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 3);
	

	}	//end if

	 sumQuantityM_page = sumQuantityM_page + sumQuantityM;
	
	 sumQuantityB_page = sumQuantityB_page + sumQuantityB;
	
	 summoney_page = summoney_page + summoney;
	

	if (OrderListSet.Tables.Count > 1)
	{

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>小计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	if ((x+1) == OrderListSet.Tables.Count)
	{

	templateBuilder.Append("    	<tr>\r\n");
	templateBuilder.Append("        <td>合计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney_page,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("  </table>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("  <div><!--合计:&yen;" + summoney.ToString() + " &nbsp;&nbsp;&nbsp;&nbsp;-->大写:人民币" + summoney_str.ToString() + "</div>\r\n");

	}	//end if

	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div>\r\n");

	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>白联:存根联 </td>\r\n");
	templateBuilder.Append("        <td>红联:财务联 </td>\r\n");
	templateBuilder.Append("        <td>绿联:回单联 </td>\r\n");
	templateBuilder.Append("        <td>蓝联:客户联</td>\r\n");
	templateBuilder.Append("        <td>黄联:仓管联</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("" + Print_Foot.ToString() + "\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("        <tr style=\"font-weight:bold\">\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                制单:" + print_ui.StaffName.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                审核:\r\n");

	if (print_v_ui!=null)
	{


	if (print_v_ui.StaffName!=null)
	{

	templateBuilder.Append("                " + print_v_ui.StaffName.ToString().Trim() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>仓管员:</td>\r\n");
	templateBuilder.Append("            <td>送货员:</td>\r\n");
	templateBuilder.Append("            <td>客户签收:</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\" valign=\"top\">\r\n");
	templateBuilder.Append("                福建省工商行政管理机关提示： 该供货凭证可作为出货台账，请注意保存两年。 <br />\r\n");
	templateBuilder.Append("                备注:" + oi.oReMake.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\" align=\"center\" valign=\"top\"><!--<img src=\"/barcode.aspx?codestr=" + oi.oOrderNum.ToString().Trim() + "&codetype=UPC-A\" width=\"190\" height=\"46\" />--></td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");


	templateBuilder.Append("</div>\r\n");



	}	//end if

	templateBuilder.Append("				</td>\r\n");
	templateBuilder.Append("			</tr>\r\n");
	templateBuilder.Append("		</table>\r\n");
	templateBuilder.Append("	</div>\r\n");
	templateBuilder.Append("	<p style=\"page-break-after:always\">&nbsp;</p>\r\n");

		}
		

	}	//end if


	}
	

	}	//end if




	}
	else
	{



	if (OrderListSet != null)
	{


				for(int x=0;x<OrderListSet.Tables.Count;x++){
					OrderList= OrderListSet.Tables[x];
					OrderFieldCount = 0;
					sumQuantityM = 0;
					sumQuantityB = 0;
					summoney = 0;
			
	templateBuilder.Append("<div class=\"print_box\">\r\n");
	templateBuilder.Append("	<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("		<tr class=\"print_box_top\">\r\n");
	templateBuilder.Append("			<td align=\"center\">\r\n");
	templateBuilder.Append("				&nbsp;\r\n");
	templateBuilder.Append("				" + config.CompanyName.ToString().Trim() + "\r\n");
	 aspxrewriteurl = GetOrderType(ordertype.ToString());
	
	templateBuilder.Append("				" + aspxrewriteurl.ToString() + "单\r\n");

	if (oi.oState==1)
	{

	templateBuilder.Append("				(已经作废)\r\n");

	}
	else
	{


	if (ot=="d")
	{

	templateBuilder.Append("				<br>注:*配货用,单据审核后该打印单据即无效*\r\n");

	}	//end if

	templateBuilder.Append("				<!--\r\n");
	 aspxrewriteurl = GetOrderStpes(oi.oSteps.ToString());
	
	templateBuilder.Append("					(" + aspxrewriteurl.ToString() + ")-->\r\n");

	}	//end if

	templateBuilder.Append("				&nbsp;\r\n");
	templateBuilder.Append("				<br><br>\r\n");
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("		</tr>\r\n");
	templateBuilder.Append("		<tr>\r\n");
	templateBuilder.Append("			<td align=\"left\" valign=\"top\">\r\n");
	templateBuilder.Append("				<!--采购-->\r\n");

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
	templateBuilder.Append("      <td><nobr>第" + (x+1).ToString() + "/" + OrderListSet.Tables.Count.ToString().Trim() + "页</nobr></td>\r\n");
	templateBuilder.Append("   <!-- <td align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>-->\r\n");
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

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount+1);
	
	templateBuilder.Append("      	<td width=\"80\" align=\"center\">" + ofl["fName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	if (ShowMoney == true)
	{

	templateBuilder.Append("	  <td width=\"50\" align=\"center\">单价<br />\r\n");
	templateBuilder.Append("	    (元)</td>\r\n");

	}	//end if

	templateBuilder.Append("	  <td width=\"50\" align=\"center\">数量</td>\r\n");
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
	templateBuilder.Append("		  <td >" + ol["StorageName"].ToString().Trim() + "&nbsp;</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsBarcode"].ToString().Trim() + "&nbsp;</td>\r\n");
	templateBuilder.Append("		  <td>\r\n");

	if (ol["IsGifts"].ToString() !="0")
	{

	templateBuilder.Append("		  (赠)\r\n");

	}	//end if

	templateBuilder.Append("		  " + ol["ProductsName"].ToString().Trim() + "&nbsp;</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsToBoxNo"].ToString().Trim() + "</td>\r\n");

	if (OrderFieldList!=null)
	{


	if (OrderFieldValueList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	templateBuilder.Append("					<td >\r\n");

	int ofvl__loop__id=0;
	foreach(DataRow ofvl in OrderFieldValueList.Rows)
	{
		ofvl__loop__id++;


	if (ofvl["OrderListID"].ToString() == ol["OrderListID"].ToString() && ofvl["OrderFieldID"].ToString()==ofl["OrderFieldID"].ToString())
	{

	templateBuilder.Append("							" + ofvl["oFieldValue"].ToString().Trim() + "&nbsp;\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("					</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if


	if (ShowMoney == true)
	{

	templateBuilder.Append("		  <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oPrice"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");

	}	//end if

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

	if (ShowMoney == true)
	{

	templateBuilder.Append("		  <td  align=\"right\">\r\n");
	 summoney = summoney+Convert.ToDecimal(ol["oMoney"]);
	
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oMoney"]),2).ToString();
	
	templateBuilder.Append("		 <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("		 </td>\r\n");

	}	//end if

	templateBuilder.Append("		</tr>\r\n");

	}	//end loop


	if (ShowMoney == true)
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 4);
	

	}
	else
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 3);
	

	}	//end if

	 sumQuantityM_page = sumQuantityM_page + sumQuantityM;
	
	 sumQuantityB_page = sumQuantityB_page + sumQuantityB;
	
	 summoney_page = summoney_page + summoney;
	

	if (OrderListSet.Tables.Count > 1)
	{

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>小计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	if ((x+1) == OrderListSet.Tables.Count)
	{

	templateBuilder.Append("    	<tr>\r\n");
	templateBuilder.Append("        <td>合计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney_page,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("  </table>\r\n");

	if ((x+1) == OrderListSet.Tables.Count)
	{


	if (ShowMoney == true)
	{

	templateBuilder.Append("  <div><!--合计:&yen;" + summoney.ToString() + " &nbsp;&nbsp;&nbsp;&nbsp;-->大写:人民币" + summoney_str.ToString() + "</div>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div>\r\n");

	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>白联:存根联 </td>\r\n");
	templateBuilder.Append("        <td>红联:财务联 </td>\r\n");
	templateBuilder.Append("        <td>绿联:回单联 </td>\r\n");
	templateBuilder.Append("        <td>蓝联:客户联</td>\r\n");
	templateBuilder.Append("        <td>黄联:仓管联</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("" + Print_Foot.ToString() + "\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("        <tr style=\"font-weight:bold\">\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                制单:" + print_ui.StaffName.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                审核:\r\n");

	if (print_v_ui!=null)
	{


	if (print_v_ui.StaffName!=null)
	{

	templateBuilder.Append("                " + print_v_ui.StaffName.ToString().Trim() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>仓管员:</td>\r\n");
	templateBuilder.Append("            <td>送货员:</td>\r\n");
	templateBuilder.Append("            <td>客户签收:</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\" valign=\"top\">\r\n");
	templateBuilder.Append("                福建省工商行政管理机关提示： 该供货凭证可作为出货台账，请注意保存两年。 <br />\r\n");
	templateBuilder.Append("                备注:" + oi.oReMake.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\" align=\"center\" valign=\"top\"><!--<img src=\"/barcode.aspx?codestr=" + oi.oOrderNum.ToString().Trim() + "&codetype=UPC-A\" width=\"190\" height=\"46\" />--></td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");


	templateBuilder.Append("</div>\r\n");



	}	//end if

	templateBuilder.Append("				<!--销售-->\r\n");

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
	templateBuilder.Append("      <td><nobr>第" + (x+1).ToString() + "/" + OrderListSet.Tables.Count.ToString().Trim() + "页</nobr></td>\r\n");
	templateBuilder.Append("   <!-- <td rowspan=\"5\" align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>-->\r\n");
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

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount+1);
	
	templateBuilder.Append("      	<td width=\"50px\" align=\"center\">" + ofl["fName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


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

	if (OrderFieldList!=null)
	{


	if (OrderFieldValueList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	templateBuilder.Append("					<td >\r\n");

	int ofvl__loop__id=0;
	foreach(DataRow ofvl in OrderFieldValueList.Rows)
	{
		ofvl__loop__id++;


	if (ofvl["OrderListID"].ToString() == ol["OrderListID"].ToString() && ofvl["OrderFieldID"].ToString()==ofl["OrderFieldID"].ToString())
	{

	templateBuilder.Append("							" + ofvl["oFieldValue"].ToString().Trim() + "&nbsp;\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("					</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if


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
	 summoney = summoney+Convert.ToDecimal(ol["oMoney"]);
	
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

	 sumQuantityM_page = sumQuantityM_page + sumQuantityM;
	
	 sumQuantityB_page = sumQuantityB_page + sumQuantityB;
	
	 summoney_page = summoney_page + summoney;
	

	if (OrderListSet.Tables.Count > 1)
	{

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>小计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	if ((x+1) == OrderListSet.Tables.Count)
	{

	templateBuilder.Append("    	<tr>\r\n");
	templateBuilder.Append("        <td>合计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney_page,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("  </table>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("  <div><!--合计:&yen;" + summoney.ToString() + " &nbsp;&nbsp;&nbsp;&nbsp;-->大写:人民币" + summoney_str.ToString() + "</div>\r\n");

	}	//end if

	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div>\r\n");

	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>白联:存根联 </td>\r\n");
	templateBuilder.Append("        <td>红联:财务联 </td>\r\n");
	templateBuilder.Append("        <td>绿联:回单联 </td>\r\n");
	templateBuilder.Append("        <td>蓝联:客户联</td>\r\n");
	templateBuilder.Append("        <td>黄联:仓管联</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("" + Print_Foot.ToString() + "\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("        <tr style=\"font-weight:bold\">\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                制单:" + print_ui.StaffName.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                审核:\r\n");

	if (print_v_ui!=null)
	{


	if (print_v_ui.StaffName!=null)
	{

	templateBuilder.Append("                " + print_v_ui.StaffName.ToString().Trim() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>仓管员:</td>\r\n");
	templateBuilder.Append("            <td>送货员:</td>\r\n");
	templateBuilder.Append("            <td>客户签收:</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\" valign=\"top\">\r\n");
	templateBuilder.Append("                福建省工商行政管理机关提示： 该供货凭证可作为出货台账，请注意保存两年。 <br />\r\n");
	templateBuilder.Append("                备注:" + oi.oReMake.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\" align=\"center\" valign=\"top\"><!--<img src=\"/barcode.aspx?codestr=" + oi.oOrderNum.ToString().Trim() + "&codetype=UPC-A\" width=\"190\" height=\"46\" />--></td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");


	templateBuilder.Append("</div>\r\n");



	}
	else
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td class=\"OrderListTool\">\r\n");
	templateBuilder.Append("<table width=\"98%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>单号:" + oi.oOrderNum.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = oi.oOrderDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("      日期:" + aspxrewriteurl.ToString() + " </td>\r\n");
	templateBuilder.Append("    <td><nobr>第" + (x+1).ToString() + "/" + OrderListSet.Tables.Count.ToString().Trim() + "页</nobr></td>\r\n");
	templateBuilder.Append("    <!--<td rowspan=\"4\" align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>-->\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td> 客 户:" + oi.StoresSupplierName.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td> 业务员:" + oi.StaffName.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td>&nbsp;</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td> 联系人:" + oi.oCustomersContact.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td> 地址:" + oi.oCustomersAddress.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td> 联系电话:" + oi.oCustomersTel.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>客户订单号:" + oi.oCustomersOrderID.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\">客户指定配送点:" + oi.oCustomersNameB.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>企业注册号:" + config.RegistrationNo.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td>单位地址：" + config.Address.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td>电话：" + config.Phone.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"98%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("	<tr >\r\n");
	templateBuilder.Append("	  <td width=\"50\">仓库</td>\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">条码</td>\r\n");
	templateBuilder.Append("	  <td align=\"center\">商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">包装量</td>\r\n");

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount+1);
	
	templateBuilder.Append("      	<td width=\"50px\" align=\"center\"><nobr>" + ofl["fName"].ToString().Trim() + "</nobr></td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


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
	templateBuilder.Append("		  <td width=\"80\">" + ol["StorageName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td>\r\n");

	if (ol["IsGifts"].ToString() !="0")
	{

	templateBuilder.Append("		  (赠)\r\n");

	}	//end if

	templateBuilder.Append("		  " + ol["ProductsName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td align=\"center\" >" + ol["ProductsToBoxNo"].ToString().Trim() + "</td>\r\n");

	if (OrderFieldList!=null)
	{


	if (OrderFieldValueList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	templateBuilder.Append("					<td >\r\n");

	int ofvl__loop__id=0;
	foreach(DataRow ofvl in OrderFieldValueList.Rows)
	{
		ofvl__loop__id++;


	if (ofvl["OrderListID"].ToString() == ol["OrderListID"].ToString() && ofvl["OrderFieldID"].ToString()==ofl["OrderFieldID"].ToString())
	{

	templateBuilder.Append("							" + ofvl["oFieldValue"].ToString().Trim() + "&nbsp;&nbsp;\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("					</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if


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
	 summoney = summoney+Convert.ToDecimal(ol["oMoney"]);
	
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oMoney"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("</td>\r\n");

	}	//end if

	templateBuilder.Append("		</tr>\r\n");

	}	//end loop


	if (ShowMoney == true)
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 4);
	

	}
	else
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 3);
	

	}	//end if

	 sumQuantityM_page = sumQuantityM_page + sumQuantityM;
	
	 sumQuantityB_page = sumQuantityB_page + sumQuantityB;
	
	 summoney_page = summoney_page + summoney;
	

	if (OrderListSet.Tables.Count > 1)
	{

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td >小计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	if ((x+1) == OrderListSet.Tables.Count)
	{

	templateBuilder.Append("    	<tr>\r\n");
	templateBuilder.Append("        <td >合计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney_page,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("  </table>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("  <div><!--合计:&yen;" + summoney.ToString() + " &nbsp;&nbsp;&nbsp;&nbsp;-->大写:人民币" + summoney_str.ToString() + "</div>\r\n");

	}	//end if

	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div>\r\n");

	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>白联:存根联 </td>\r\n");
	templateBuilder.Append("        <td>红联:财务联 </td>\r\n");
	templateBuilder.Append("        <td>绿联:回单联 </td>\r\n");
	templateBuilder.Append("        <td>蓝联:客户联</td>\r\n");
	templateBuilder.Append("        <td>黄联:仓管联</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("" + Print_Foot.ToString() + "\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("        <tr style=\"font-weight:bold\">\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                制单:" + print_ui.StaffName.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                审核:\r\n");

	if (print_v_ui!=null)
	{


	if (print_v_ui.StaffName!=null)
	{

	templateBuilder.Append("                " + print_v_ui.StaffName.ToString().Trim() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>仓管员:</td>\r\n");
	templateBuilder.Append("            <td>送货员:</td>\r\n");
	templateBuilder.Append("            <td>客户签收:</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\" valign=\"top\">\r\n");
	templateBuilder.Append("                福建省工商行政管理机关提示： 该供货凭证可作为出货台账，请注意保存两年。 <br />\r\n");
	templateBuilder.Append("                备注:" + oi.oReMake.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\" align=\"center\" valign=\"top\"><!--<img src=\"/barcode.aspx?codestr=" + oi.oOrderNum.ToString().Trim() + "&codetype=UPC-A\" width=\"190\" height=\"46\" />--></td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");


	templateBuilder.Append("</div>\r\n");



	}	//end if


	}	//end if

	templateBuilder.Append("				<!--调整,坏货-->\r\n");

	if (ordertype==8 || ordertype==10)
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
	templateBuilder.Append("      <td><nobr>第" + (x+1).ToString() + "/" + OrderListSet.Tables.Count.ToString().Trim() + "页</nobr></td>\r\n");
	templateBuilder.Append("    <!--<td align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>-->\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td>\r\n");
	templateBuilder.Append("  <table width=\"98%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\" bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("	<tr >\r\n");
	templateBuilder.Append("	  <td width=\"30\" align=\"center\">仓库</td>\r\n");
	templateBuilder.Append("	  <td width=\"40\" align=\"center\">条码</td>\r\n");
	templateBuilder.Append("	  <td align=\"center\">商品名称</td>\r\n");
	templateBuilder.Append("	  <td width=\"30\" align=\"center\">包装量</td>\r\n");

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount+1);
	
	templateBuilder.Append("      	<td width=\"50px\" align=\"center\">" + ofl["fName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


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
	templateBuilder.Append("		  <td >" + ol["StorageName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td>\r\n");

	if (ol["IsGifts"].ToString() !="0")
	{

	templateBuilder.Append("		  (赠)\r\n");

	}	//end if

	templateBuilder.Append("		  " + ol["ProductsName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		  <td >" + ol["ProductsToBoxNo"].ToString().Trim() + "</td>\r\n");

	if (OrderFieldList!=null)
	{


	if (OrderFieldValueList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	templateBuilder.Append("					<td >\r\n");

	int ofvl__loop__id=0;
	foreach(DataRow ofvl in OrderFieldValueList.Rows)
	{
		ofvl__loop__id++;


	if (ofvl["OrderListID"].ToString() == ol["OrderListID"].ToString() && ofvl["OrderFieldID"].ToString()==ofl["OrderFieldID"].ToString())
	{

	templateBuilder.Append("							" + ofvl["oFieldValue"].ToString().Trim() + "&nbsp;\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("					</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if


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

	templateBuilder.Append("		  <td  align=\"right\">\r\n");
	 summoney = summoney+Convert.ToDecimal(ol["oMoney"]);
	
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oMoney"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("</td>\r\n");

	}	//end if

	templateBuilder.Append("		</tr>\r\n");

	}	//end loop


	if (ShowMoney == true)
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 4);
	

	}
	else
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 3);
	

	}	//end if

	 sumQuantityM_page = sumQuantityM_page + sumQuantityM;
	
	 sumQuantityB_page = sumQuantityB_page + sumQuantityB;
	
	 summoney_page = summoney_page + summoney;
	

	if (OrderListSet.Tables.Count > 1)
	{

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>小计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	if ((x+1) == OrderListSet.Tables.Count)
	{

	templateBuilder.Append("    	<tr>\r\n");
	templateBuilder.Append("        <td>合计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney_page,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("  </table>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("  <div><!--合计:&yen;" + summoney.ToString() + " &nbsp;&nbsp;&nbsp;&nbsp;-->大写:人民币" + summoney_str.ToString() + "</div>\r\n");

	}	//end if

	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div>\r\n");

	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>白联:存根联 </td>\r\n");
	templateBuilder.Append("        <td>红联:财务联 </td>\r\n");
	templateBuilder.Append("        <td>绿联:回单联 </td>\r\n");
	templateBuilder.Append("        <td>蓝联:客户联</td>\r\n");
	templateBuilder.Append("        <td>黄联:仓管联</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("" + Print_Foot.ToString() + "\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("        <tr style=\"font-weight:bold\">\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                制单:" + print_ui.StaffName.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                审核:\r\n");

	if (print_v_ui!=null)
	{


	if (print_v_ui.StaffName!=null)
	{

	templateBuilder.Append("                " + print_v_ui.StaffName.ToString().Trim() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>仓管员:</td>\r\n");
	templateBuilder.Append("            <td>送货员:</td>\r\n");
	templateBuilder.Append("            <td>客户签收:</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\" valign=\"top\">\r\n");
	templateBuilder.Append("                福建省工商行政管理机关提示： 该供货凭证可作为出货台账，请注意保存两年。 <br />\r\n");
	templateBuilder.Append("                备注:" + oi.oReMake.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\" align=\"center\" valign=\"top\"><!--<img src=\"/barcode.aspx?codestr=" + oi.oOrderNum.ToString().Trim() + "&codetype=UPC-A\" width=\"190\" height=\"46\" />--></td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");


	templateBuilder.Append("</div>\r\n");



	}	//end if

	templateBuilder.Append("				<!--调拨-->\r\n");

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
	templateBuilder.Append("      <td><nobr>第" + (x+1).ToString() + "/" + OrderListSet.Tables.Count.ToString().Trim() + "页</nobr></td>\r\n");
	templateBuilder.Append("    <!--<td align=\"center\"><img src=\"qrcode-" + oi.OrderID.ToString().Trim() + ".aspx\" /></td>-->\r\n");
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

	if (OrderFieldList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount+1);
	
	templateBuilder.Append("      	<td width=\"50\" align=\"center\">" + ofl["fName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	if (ShowMoney == true)
	{

	templateBuilder.Append("	  <td width=\"45\" align=\"center\">单价<br>(元)</td>\r\n");

	}	//end if

	templateBuilder.Append("	  <td width=\"45\" align=\"center\">数量<br>(小单位)</td>\r\n");
	templateBuilder.Append("	  <td width=\"45\" align=\"center\">数量<br>(大单位)</td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("	  <td width=\"45\" align=\"center\">金额<br>(元)</td>\r\n");

	}	//end if

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

	if (OrderFieldList!=null)
	{


	if (OrderFieldValueList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrint"].ToString()=="0")
	{

	templateBuilder.Append("					<td >\r\n");

	int ofvl__loop__id=0;
	foreach(DataRow ofvl in OrderFieldValueList.Rows)
	{
		ofvl__loop__id++;


	if (ofvl["OrderListID"].ToString() == ol["OrderListID"].ToString() && ofvl["OrderFieldID"].ToString()==ofl["OrderFieldID"].ToString())
	{

	templateBuilder.Append("							" + ofvl["oFieldValue"].ToString().Trim() + "&nbsp;\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("					</td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if


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

	templateBuilder.Append("		  <td  align=\"right\">\r\n");
	 summoney = summoney+Convert.ToDecimal(ol["oMoney"]);
	
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oMoney"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("</td>\r\n");

	}	//end if

	templateBuilder.Append("		</tr>\r\n");

	}	//end loop


	if (ShowMoney == true)
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 4);
	

	}
	else
	{

	 OrderFieldCount = Convert.ToInt32(OrderFieldCount + 3);
	

	}	//end if

	 sumQuantityM_page = sumQuantityM_page + sumQuantityM;
	
	 sumQuantityB_page = sumQuantityB_page + sumQuantityB;
	
	 summoney_page = summoney_page + summoney;
	

	if (OrderListSet.Tables.Count > 1)
	{

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>小计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	if ((x+1) == OrderListSet.Tables.Count)
	{

	templateBuilder.Append("    	<tr>\r\n");
	templateBuilder.Append("        <td>合计:</td>\r\n");
	templateBuilder.Append("        <td colspan=\"" + OrderFieldCount.ToString() + "\"></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityM_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(sumQuantityB_page,config.QuantityDecimal).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("        <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(summoney_page,2).ToString();
	
	templateBuilder.Append("        <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("  </table>\r\n");

	if (ShowMoney == true)
	{

	templateBuilder.Append("  <div><!--合计:&yen;" + summoney.ToString() + " &nbsp;&nbsp;&nbsp;&nbsp;-->大写:人民币" + summoney_str.ToString() + "</div>\r\n");

	}	//end if

	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div>\r\n");

	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("        <td>白联:存根联 </td>\r\n");
	templateBuilder.Append("        <td>红联:财务联 </td>\r\n");
	templateBuilder.Append("        <td>绿联:回单联 </td>\r\n");
	templateBuilder.Append("        <td>蓝联:客户联</td>\r\n");
	templateBuilder.Append("        <td>黄联:仓管联</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("" + Print_Foot.ToString() + "\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:10px;\" class=\"print_othermsg\">\r\n");
	templateBuilder.Append("        <tr style=\"font-weight:bold\">\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                制单:" + print_ui.StaffName.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("                审核:\r\n");

	if (print_v_ui!=null)
	{


	if (print_v_ui.StaffName!=null)
	{

	templateBuilder.Append("                " + print_v_ui.StaffName.ToString().Trim() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td>仓管员:</td>\r\n");
	templateBuilder.Append("            <td>送货员:</td>\r\n");
	templateBuilder.Append("            <td>客户签收:</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\" valign=\"top\">\r\n");
	templateBuilder.Append("                福建省工商行政管理机关提示： 该供货凭证可作为出货台账，请注意保存两年。 <br />\r\n");
	templateBuilder.Append("                备注:" + oi.oReMake.ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\" align=\"center\" valign=\"top\"><!--<img src=\"/barcode.aspx?codestr=" + oi.oOrderNum.ToString().Trim() + "&codetype=UPC-A\" width=\"190\" height=\"46\" />--></td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"5\" valign=\"top\">&nbsp;</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");


	templateBuilder.Append("</div>\r\n");



	}	//end if

	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("		</tr>\r\n");
	templateBuilder.Append("	</table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<p style=\"page-break-after:always\">&nbsp;</p>\r\n");

	}
	

	}	//end if




	}	//end if


	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
