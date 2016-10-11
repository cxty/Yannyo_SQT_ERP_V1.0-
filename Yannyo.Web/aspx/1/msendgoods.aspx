<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.msendgoods" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:17. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/dialog.js\"></" + "script>\r\n");


	if (ShowMSign == true)
	{

	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("dialog(\"授权[" + M_Config.m_Name.ToString().Trim() + "] " + M_Config.StoresName.ToString().Trim() + "\",'iframe:" + config.Taobao_Api_Authorize.ToString().Trim() + "" + M_Config.m_AppKey.ToString().Trim() + "',550,450,\"iframe\",'parent.HidBox();');\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}
	else
	{


	if (GoodsCatLastTimeDay>5)
	{

	templateBuilder.Append("	<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("		dialog(\"更新商品类目[" + M_Config.m_Name.ToString().Trim() + "] " + M_Config.StoresName.ToString().Trim() + "\",'iframe:/mgoodscat_do-" + M_Config.m_ConfigInfoID.ToString().Trim() + "-download.aspx',500,250,\"iframe\",'parent.HidBox();');\r\n");
	templateBuilder.Append("	</" + "script>\r\n");

	}	//end if


	}	//end if




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

	templateBuilder.Append("        <script src=\"/public/js/msendgoods.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("<h2>订单商品信息</h2>\r\n");

	if (Act=="Edit")
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"tBox\" id=\"order_box\">\r\n");
	templateBuilder.Append("          <tr class=\"tBar\">\r\n");
	templateBuilder.Append("            <td width=\"15\" align=\"center\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"\" onClick=\"javascript:selectCheck(document.getElementById('form1'),this);\"/></td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\">商品名称</td>\r\n");
	templateBuilder.Append("            <td width=\"20%\">对应商品</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\">条码</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">单价</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">数量</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">应付金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">优惠金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">调整金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">实付金额</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");

	if (oList!=null)
	{


	int ol__loop__id=0;
	foreach(DataRow ol in oList.Rows)
	{
		ol__loop__id++;

	templateBuilder.Append("          <tr id=\"tr_" + ol__loop__id.ToString() + "\" pid=\"" + ol["outer_iid"].ToString().Trim() + "\" OrderListID=\"0\" OrderID=\"0\" StorageID=\"0\" payment=\"" + ol["payment"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("            <td width=\"24\" align=\"center\" ><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" tpid=\"c_" + ol__loop__id.ToString() + "\" value=\"" + ol["num_iid"].ToString().Trim() + "\"  />\r\n");
	templateBuilder.Append("           </td>\r\n");
	templateBuilder.Append("            <td width=\"25\" valign=\"middle\"> \r\n");

	if (ol["pic_path"].ToString().Trim()!="")
	{

	templateBuilder.Append("            <img src=\"" + ol["pic_path"].ToString().Trim() + "\" alt=\"" + ol["title"].ToString().Trim() + "\" width=\"50\" height=\"50\" />\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("            <td valign=\"middle\">" + ol["title"].ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("            <td width=\"20%\">" + ol["ProductsName"].ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\">" + ol["ProductsBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\" ><INPUT TYPE=\"hidden\" id=\"Price_" + ol__loop__id.ToString() + "\" name=\"Price_" + ol__loop__id.ToString() + "\" value=\"" + ol["price"].ToString().Trim() + "\">" + ol["price"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\" >\r\n");
	templateBuilder.Append("			<INPUT TYPE=\"hidden\" id=\"oQuantity_" + ol__loop__id.ToString() + "\" name=\"oQuantity_" + ol__loop__id.ToString() + "\" value=\"" + ol["num"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("			" + ol["num"].ToString().Trim() + "\r\n");
	 sum_a = sum_a+decimal.Parse(ol["num"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">" + ol["total_fee"].ToString().Trim() + "\r\n");
	 sum_b = sum_b+decimal.Parse(ol["total_fee"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">" + ol["discount_fee"].ToString().Trim() + "\r\n");
	 sum_c = sum_c+decimal.Parse(ol["discount_fee"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">" + ol["adjust_fee"].ToString().Trim() + "\r\n");
	 sum_d = sum_d+decimal.Parse(ol["adjust_fee"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\" id=\"sum_" + ol__loop__id.ToString() + "\">" + ol["payment"].ToString().Trim() + "\r\n");
	 sum_e = sum_e+decimal.Parse(ol["payment"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("          </tr>\r\n");

	}	//end loop

	 loop_count = ol__loop__id;
	

	}	//end if

	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\">合计:</td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\">&nbsp;</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">&nbsp;</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_a.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_b.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_c.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_d.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\" >" + sum_e.ToString() + "</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("        </table><br/>\r\n");
	templateBuilder.Append("<h2>实发商品信息</h2>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"tBox\" id=\"order_box\">\r\n");
	templateBuilder.Append("          <tr class=\"tBar\">\r\n");
	templateBuilder.Append("            <td width=\"15\" align=\"center\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"\" onClick=\"javascript:selectCheck(document.getElementById('form1'),this);\"/></td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\">商品名称</td>\r\n");
	templateBuilder.Append("            <td width=\"20%\">对应商品</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\">条码</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">单价</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">数量</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">应付金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">优惠金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">调整金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">实付金额</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("          <tbody id=\"order_loop\">\r\n");
	templateBuilder.Append("          </tbody>\r\n");
	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\">合计:</td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\">&nbsp;</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">&nbsp;</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_a.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_b.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_c.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_d.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\" id=\"SumMoney\">" + sum_e.ToString() + "</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("        </table><br/>\r\n");



	}
	else
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"tBox\" id=\"order_box\">\r\n");
	templateBuilder.Append("          <tr class=\"tBar\">\r\n");
	templateBuilder.Append("            <td width=\"15\" align=\"center\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"\" onClick=\"javascript:selectCheck(document.getElementById('form1'),this);\"/></td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\">商品名称</td>\r\n");
	templateBuilder.Append("            <td width=\"20%\">对应商品</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\">条码</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">单价</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">数量</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">应付金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">优惠金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">调整金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">实付金额</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("          <tbody id=\"order_loop\">\r\n");

	if (oList!=null)
	{


	int ol__loop__id=0;
	foreach(DataRow ol in oList.Rows)
	{
		ol__loop__id++;

	templateBuilder.Append("          <tr id=\"tr_" + ol__loop__id.ToString() + "\" pid=\"" + ol["outer_iid"].ToString().Trim() + "\" OrderListID=\"0\" OrderID=\"0\" StorageID=\"0\" payment=\"" + ol["payment"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("            <td width=\"24\" align=\"center\" ><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" tpid=\"c_" + ol__loop__id.ToString() + "\" value=\"" + ol["num_iid"].ToString().Trim() + "\"  />\r\n");
	templateBuilder.Append("           </td>\r\n");
	templateBuilder.Append("            <td width=\"25\" valign=\"middle\"> \r\n");

	if (ol["pic_path"].ToString().Trim()!="")
	{

	templateBuilder.Append("            <img src=\"" + ol["pic_path"].ToString().Trim() + "\" alt=\"" + ol["title"].ToString().Trim() + "\" width=\"50\" height=\"50\" />\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("            <td valign=\"middle\">" + ol["title"].ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("            <td width=\"20%\">" + ol["ProductsName"].ToString().Trim() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\">" + ol["ProductsBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\" ><INPUT TYPE=\"hidden\" id=\"Price_" + ol__loop__id.ToString() + "\" name=\"Price_" + ol__loop__id.ToString() + "\" value=\"" + ol["price"].ToString().Trim() + "\">" + ol["price"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\" >\r\n");
	templateBuilder.Append("			<INPUT TYPE=\"hidden\" id=\"oQuantity_" + ol__loop__id.ToString() + "\" name=\"oQuantity_" + ol__loop__id.ToString() + "\" value=\"" + ol["num"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("			" + ol["num"].ToString().Trim() + "\r\n");
	 sum_a = sum_a+decimal.Parse(ol["num"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">" + ol["total_fee"].ToString().Trim() + "\r\n");
	 sum_b = sum_b+decimal.Parse(ol["total_fee"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">" + ol["discount_fee"].ToString().Trim() + "\r\n");
	 sum_c = sum_c+decimal.Parse(ol["discount_fee"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">" + ol["adjust_fee"].ToString().Trim() + "\r\n");
	 sum_d = sum_d+decimal.Parse(ol["adjust_fee"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\" id=\"sum_" + ol__loop__id.ToString() + "\">" + ol["payment"].ToString().Trim() + "\r\n");
	 sum_e = sum_e+decimal.Parse(ol["payment"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("          </tr>\r\n");

	}	//end loop

	 loop_count = ol__loop__id;
	

	}	//end if

	templateBuilder.Append("          </tbody>\r\n");
	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\">合计:</td>\r\n");
	templateBuilder.Append("            <td colspan=\"2\">&nbsp;</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">&nbsp;</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_a.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_b.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_c.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_d.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\" id=\"SumMoney\">" + sum_e.ToString() + "</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("        </table><br/>\r\n");



	}	//end if

	templateBuilder.Append("<div class=\"OrdersB\" style=\"width:100%\">\r\n");
	templateBuilder.Append("<h2>物流信息</h2>\r\n");
	templateBuilder.Append("<div id=\"morder_address_box\" style=\"width:100%\">\r\n");
	templateBuilder.Append("<ul>\r\n");

	if (tList!=null)
	{


	int tl__loop__id=0;
	foreach(DataRow tl in tList.Rows)
	{
		tl__loop__id++;

	templateBuilder.Append("    	<li><input name=\"taddress\" type=\"radio\" value=\"\" class=\"B_Check\" id=\"taddress_" + tl__loop__id.ToString() + "\" \r\n");
	templateBuilder.Append("        receiver_name = \"" + tl["receiver_name"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("        receiver_state = \"" + tl["receiver_state"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("        receiver_city = \"" + tl["receiver_city"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("        receiver_district = \"" + tl["receiver_district"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("        receiver_address = \"" + tl["receiver_address"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("        receiver_zip = \"" + tl["receiver_zip"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("        receiver_mobile = \"" + tl["receiver_mobile"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("        receiver_phone = \"" + tl["receiver_phone"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("        ><label for=\"taddress_" + tl__loop__id.ToString() + "\">" + tl["receiver_name"].ToString().Trim() + "," + tl["receiver_state"].ToString().Trim() + "," + tl["receiver_city"].ToString().Trim() + "," + tl["receiver_district"].ToString().Trim() + "," + tl["receiver_zip"].ToString().Trim() + ",\r\n");
	templateBuilder.Append("    " + tl["receiver_address"].ToString().Trim() + ",手机:" + tl["receiver_mobile"].ToString().Trim() + ",电话号码:" + tl["receiver_phone"].ToString().Trim() + ",Email:" + tl["buyer_email"].ToString().Trim() + "</label></li>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("</ul>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td width=\"10%\" rowspan=\"2\" class=\"ltd\">收货地址:</td>\r\n");
	templateBuilder.Append("    <td colspan=\"5\" style=\"background-color: #EFEFEF;text-align: left;\" >省份:\r\n");
	templateBuilder.Append("      <input name=\"receiver_state\" id=\"receiver_state\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.receiver_state.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("      城市:\r\n");
	templateBuilder.Append("      <input name=\"receiver_city\" id=\"receiver_city\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.receiver_city.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("      地区:\r\n");
	templateBuilder.Append("      <input name=\"receiver_district\" id=\"receiver_district\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.receiver_district.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"3\" class=\"rtd\"><input name=\"receiver_address\" id=\"receiver_address\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.receiver_address.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" style=\"width:80%\"/>\r\n");
	templateBuilder.Append("      *</td>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">邮编:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\"><input name=\"receiver_zip\" id=\"receiver_zip\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.receiver_zip.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">收货人:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\"><input name=\"receiver_name\" id=\"receiver_name\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.receiver_name.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("    *</td>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">手机号码:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\"><input name=\"receiver_mobile\" id=\"receiver_mobile\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.receiver_mobile.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("    *</td>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">电话号码:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\"><input name=\"receiver_phone\" id=\"receiver_phone\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.receiver_phone.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"6\" class=\"rtd\">&nbsp;</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td class=\"ltd\" rowspan=\"2\">发件人地址:</td>\r\n");
	templateBuilder.Append("    <td colspan=\"5\" class=\"rtd\">省份:\r\n");
	templateBuilder.Append("      <input name=\"from_state\" id=\"from_state\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.from_state.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("      城市:\r\n");
	templateBuilder.Append("      <input name=\"from_city\" id=\"from_city\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.from_city.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("      地区:\r\n");
	templateBuilder.Append("      <input name=\"from_district\" id=\"from_district\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.from_district.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" /></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"3\" class=\"rtd\">\r\n");
	templateBuilder.Append("    <input name=\"from_address\" id=\"from_address\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.from_address.ToString().Trim() + "\" \r\n");

	}
	else
	{

	templateBuilder.Append(" value=\"" + Sender.sAddress.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" style=\"width:80%\" /></td>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">邮编:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\"><input name=\"from_zip\" id=\"from_zip\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.from_zip.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">发件人:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\">\r\n");
	templateBuilder.Append("    <input name=\"from_name\" id=\"from_name\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("    	value=\"" + SendGoods.from_name.ToString().Trim() + "\" \r\n");

	}
	else
	{

	templateBuilder.Append("     	value=\"" + Sender.sContact.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" /></td>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">手机号码:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\"><input name=\"from_mobile\" id=\"from_mobile\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("    	value=\"" + SendGoods.from_mobile.ToString().Trim() + "\" \r\n");

	}
	else
	{

	templateBuilder.Append("    	value=\"" + Sender.sTel.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append("    /></td>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">电话号码:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\"><input name=\"from_phone\" id=\"from_phone\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("    	value=\"" + SendGoods.from_phone.ToString().Trim() + "\" \r\n");

	}
	else
	{

	templateBuilder.Append("    	value=\"" + Sender.sTel.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">物流公司:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\">\r\n");
	templateBuilder.Append("    <select name=\"ExpName\" id=\"ExpName\">\r\n");

	if (eList!=null)
	{


	int el__loop__id=0;
	foreach(DataRow el in eList.Rows)
	{
		el__loop__id++;

	templateBuilder.Append("    <option value=\"" + el["m_ExpressTemplatesID"].ToString().Trim() + "\" \r\n");

	if (Act=="Edit")
	{


	if (SendGoods.mExpName.ToString() == el["m_ExpressTemplatesID"].ToString())
	{

	templateBuilder.Append("     selected\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("    >" + el["mExpName"].ToString().Trim() + "</option>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("    </select>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">运单号:</td>\r\n");
	templateBuilder.Append("    <td colspan=\"3\" class=\"rtd\"><input name=\"ExpNO\" id=\"ExpNO\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value=\"" + SendGoods.mExpNO.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">备注:</td>\r\n");
	templateBuilder.Append("    <td colspan=\"5\" class=\"rtd\">\r\n");
	templateBuilder.Append("    <textarea name=\"tMsg\" id=\"tMsg\" style=\"width:98%;height:150px\">\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("" + SendGoods.mMemo.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("    </textarea></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<div style=\"width:100%;height:30px;float:left\"></div>\r\n");
	templateBuilder.Append("            <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"center\">\r\n");
	templateBuilder.Append("                  <input type=\"hidden\" name=\"OrderListDataJson\" id=\"OrderListDataJson\" >\r\n");
	templateBuilder.Append("                  	<input type=\"button\" name=\"bt_add\" id=\"bt_add\" value=\" 添加商品 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("                    <input type=\"button\" name=\"bt_del\" id=\"bt_del\" value=\" 删除商品 \" class=\"B_INPUT\">&nbsp;&nbsp;\r\n");
	templateBuilder.Append("                    <input type=\"button\" name=\"bt_ok\" id=\"bt_ok\" value=\" 确定 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("                    <input type=\"button\" name=\"bt_cancel\" id=\"bt_cancel\" value=\" 取消 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </div>\r\n");
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var M_SendGoods = new TM_SendGoods();\r\n");
	templateBuilder.Append("M_SendGoods.MConfigID = " + M_Config.m_ConfigInfoID.ToString().Trim() + ";\r\n");
	templateBuilder.Append("M_SendGoods.ActStr = '" + Act.ToString() + "';\r\n");
	templateBuilder.Append("M_SendGoods.rowID = " + loop_count.ToString() + ";\r\n");
	templateBuilder.Append("M_SendGoods.StoresID = " + M_Config.StoresID.ToString().Trim() + ";\r\n");
	templateBuilder.Append("M_SendGoods.OrderListDataJsonStr = '" + OrderListDataJsonStr.ToString() + "';\r\n");
	templateBuilder.Append("M_SendGoods.ini();\r\n");
	templateBuilder.Append("function HidBox()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	M_SendGoods.HidUserBox();\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("addTableListener(document.getElementById(\"order_box\"),0,0);\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
