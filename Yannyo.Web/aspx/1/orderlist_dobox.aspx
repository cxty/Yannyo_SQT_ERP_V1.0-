<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.orderlist_dobox" %>
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


	templateBuilder.Append("<body >\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.mcdropdown.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.bgiframe.js\"></" + "script>\r\n");
	templateBuilder.Append("<link type=\"text/css\" href=\"templates/" + templatepath.ToString() + "/css/jquery.mcdropdown.css\" rel=\"stylesheet\" media=\"all\" />\r\n");

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

	templateBuilder.Append("		<script type=\"text/javascript\" src=\"public/js/orderlist_dobox.js \"></" + "script>\r\n");
	templateBuilder.Append("            <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");

	if (ordertype!=9)
	{

	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" class=\"dBox\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td width=\"20%\" align=\"right\" class=\"ltd\">商品名称:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" id=\"ProductInfo\" class=\"rtd\">&nbsp;</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">仓库:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <select id=\"StorageID\" name=\"StorageID\" >\r\n");

	if (StorageList!=null)
	{


	int sl__loop__id=0;
	foreach(DataRow sl in StorageList.Rows)
	{
		sl__loop__id++;

	templateBuilder.Append("                    <option value=\"" + sl["StorageID"].ToString().Trim() + "\">" + sl["sCode"].ToString().Trim() + "_" + sl["sName"].ToString().Trim() + "</option>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("                  </select></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">库存:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" id=\"StorageInfo\" class=\"rtd\">&nbsp;</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tbody id=\"MStockInfoBox\">\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("				  <td align=\"right\" class=\"ltd\">价格体系:</td>\r\n");
	templateBuilder.Append("				  <td align=\"left\" class=\"rtd\" >\r\n");
	templateBuilder.Append("                  <input type=\"text\" name=\"category_c\" id=\"category_c\" value=\"\" />\r\n");
	templateBuilder.Append("                  <ul id=\"categorymenu_c\" class=\"mcdropdown_menu\">" + PriceClass.ToString() + "</ul>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("			    </tr>\r\n");
	templateBuilder.Append("				<tr >\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">配额:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\" id=\"MStockInfo\">&nbsp;</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                </tbody>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">数量:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\"><input name=\"Quantity\" type=\"text\" id=\"Quantity\" style=\"width:60px\" value=\"0\"><span id=\"pUnits\" name=\"pUnits\"></span>/<span id=\"pToBoxNo\" name=\"pToBoxNo\"></span>=\r\n");
	templateBuilder.Append("                  <input name=\"MaxQuantity\" type=\"text\" id=\"MaxQuantity\" style=\"width:60px\" value=\"0\"><span id=\"pMaxUnits\" name=\"pMaxUnits\"></span></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td width=\"20%\" align=\"right\" class=\"ltd\">单价:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\"><input name=\"Price\" type=\"text\" id=\"Price\" style=\"width:60px\" value=\"0\">\r\n");
	templateBuilder.Append("                  *<input name=\"Quantity_b\" type=\"text\" id=\"Quantity_b\" style=\"width:60px\" value=\"0\"><span id=\"pUnits_b\" name=\"pUnits_b\"></span>\r\n");
	templateBuilder.Append("                  =<input name=\"SumMoney\" type=\"text\" id=\"SumMoney\" style=\"width:60px\" value=\"0\"></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("<div style=\"width:100%;height:30px;float:left\"></div>\r\n");
	templateBuilder.Append("                <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("					<input type=\"hidden\" id=\"PriceClassID\" name=\"PriceClassID\" value=\"0\">\r\n");
	templateBuilder.Append("                    <input type=\"button\" id=\"button1\" style=\"margin:5px\" class=\"B_INPUT\" value=\"确定\" onClick=\"javascript:OrderDOBox.CheckF();\"/>\r\n");
	templateBuilder.Append("                </div>\r\n");

	}
	else
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\">商品名称:</td>\r\n");
	templateBuilder.Append("                  <td colspan=\"3\" align=\"left\" id=\"ProductInfo\">&nbsp;</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td width=\"30%\" align=\"right\">仓库:</td>\r\n");
	templateBuilder.Append("                  <td width=\"20%\" align=\"left\"><select id=\"StorageID\" name=\"StorageID\" >\r\n");

	if (StorageList!=null)
	{


	int sl__loop__id=0;
	foreach(DataRow sl in StorageList.Rows)
	{
		sl__loop__id++;

	templateBuilder.Append("                    <option value=\"" + sl["StorageID"].ToString().Trim() + "\">" + sl["sCode"].ToString().Trim() + "_" + sl["sName"].ToString().Trim() + "</option>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("                  </select></td>\r\n");
	templateBuilder.Append("                  <td rowspan=\"2\" align=\"center\">-&gt;</td>\r\n");
	templateBuilder.Append("                  <td width=\"45%\" align=\"left\">\r\n");
	templateBuilder.Append("                  <select id=\"StorageIDB\" name=\"StorageIDB\" >\r\n");

	if (StorageList!=null)
	{


	int sl__loop__id=0;
	foreach(DataRow sl in StorageList.Rows)
	{
		sl__loop__id++;

	templateBuilder.Append("                    <option value=\"" + sl["StorageID"].ToString().Trim() + "\">" + sl["sCode"].ToString().Trim() + "_" + sl["sName"].ToString().Trim() + "</option>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("                  </select>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\">库存:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" id=\"StorageInfo\">&nbsp;</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" id=\"StorageInfoB\">&nbsp;</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\">数量:</td>\r\n");
	templateBuilder.Append("                  <td colspan=\"3\" align=\"left\"><input name=\"Quantity\" id=\"Quantity\" type=\"text\"></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td width=\"30%\" align=\"right\">单价:</td>\r\n");
	templateBuilder.Append("                  <td colspan=\"3\" align=\"left\"><input name=\"Price\" id=\"Price\" type=\"text\"></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td colspan=\"4\" align=\"center\"><input type=\"button\" id=\"button1\" style=\"margin:5px\" class=\"B_INPUT\" value=\"确定\" onClick=\"javascript:OrderDOBox.CheckF();\"/>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");



	}	//end if

	templateBuilder.Append("            </form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var OrderDOBox = new TOrderDOBox();\r\n");
	templateBuilder.Append("OrderDOBox.OrdeType = " + ordertype.ToString() + ";\r\n");
	templateBuilder.Append("OrderDOBox.ProductID = " + productid.ToString() + ";\r\n");
	templateBuilder.Append("OrderDOBox.MoneyDecimal = " + config.MoneyDecimal.ToString().Trim() + ";\r\n");
	templateBuilder.Append("OrderDOBox.QuantityDecimal = " + config.QuantityDecimal.ToString().Trim() + ";\r\n");
	templateBuilder.Append("OrderDOBox.tObj = '" + tObj.ToString() + "';\r\n");
	templateBuilder.Append("OrderDOBox.ini();\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
