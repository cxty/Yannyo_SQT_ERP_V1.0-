<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.orderlist_do_nofull" %>
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

	templateBuilder.Append("<script src=\"public/js/orderlist_do_nofull.js\" language=\"javascript\" type=\"text/javascript\"></" + "script>\r\n");
	templateBuilder.Append("<form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");

	if (oi!=null)
	{

	templateBuilder.Append("<h2>单据编号:" + oi.oOrderNum.ToString().Trim() + "</h2>\r\n");

	if (dList!=null)
	{

	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"tBox\" id=\"tBoxs\">\r\n");
	templateBuilder.Append("<thead>\r\n");
	templateBuilder.Append("    <tr class=\"tBar\">\r\n");
	templateBuilder.Append("      <td width=\"10%\" align=\"center\">差额来源</td>\r\n");
	templateBuilder.Append("      <td align=\"center\">商品名称</td>\r\n");
	templateBuilder.Append("      <td width=\"10%\" align=\"center\">开单数</td>\r\n");
	templateBuilder.Append("      <td width=\"10%\" align=\"center\">到货数</td>\r\n");
	templateBuilder.Append("      <td width=\"10%\" align=\"center\">差额</td>\r\n");
	templateBuilder.Append("      <td width=\"20%\" align=\"center\">差额去向</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append(" </thead>\r\n");
	templateBuilder.Append(" <tbody>\r\n");

	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("      <td width=\"10%\">\r\n");
	templateBuilder.Append("      <input type=\"hidden\" id=\"s_StorageID_" + dl__loop__id.ToString() + "\" name=\"s_StorageID_" + dl__loop__id.ToString() + "\" value=\"" + dl["StorageID"].ToString().Trim() + "\"/>\r\n");
	templateBuilder.Append("      " + dl["sName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("      <td>\r\n");
	templateBuilder.Append("      <input type=\"hidden\" id=\"ProductsID_" + dl__loop__id.ToString() + "\" name=\"ProductsID_" + dl__loop__id.ToString() + "\" value=\"" + dl["ProductsID"].ToString().Trim() + "\"/>\r\n");
	templateBuilder.Append("      " + dl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("      <td width=\"10%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oldQuantity"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("		  " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("      </td>\r\n");
	templateBuilder.Append("      <td width=\"10%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("		  " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("      </td>\r\n");
	templateBuilder.Append("      <td width=\"10%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oldQuantity"])-Convert.ToDecimal(dl["oQuantity"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("		  " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("       <input type=\"hidden\" id=\"Quantity_" + dl__loop__id.ToString() + "\" name=\"Quantity_" + dl__loop__id.ToString() + "\" value=\"" + aspxrewriteurl.ToString() + "\"/>\r\n");
	templateBuilder.Append("      </td>\r\n");
	templateBuilder.Append("      <td width=\"20%\">\r\n");
	templateBuilder.Append("      <select id=\"t_StorageID_" + dl__loop__id.ToString() + "\" name=\"t_StorageID_" + dl__loop__id.ToString() + "\" >\r\n");
	templateBuilder.Append("	   <option value=\"-1\">回原仓库</option>\r\n");

	if (StorageList!=null)
	{


	int sl__loop__id=0;
	foreach(DataRow sl in StorageList.Rows)
	{
		sl__loop__id++;


	if (sl["StorageID"].ToString()!=dl["StorageID"].ToString())
	{

	templateBuilder.Append("        <option value=\"" + sl["StorageID"].ToString().Trim() + "\">" + sl["sName"].ToString().Trim() + "</option>\r\n");

	}	//end if


	}	//end loop


	}	//end if

	templateBuilder.Append("      </select></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	}	//end loop

	templateBuilder.Append("    </tbody>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  <input type=\"hidden\" id=\"loop_count\" name=\"loop_count\" value=\"" + dl__loop__id.ToString() + "\" />\r\n");

	}	//end if

	templateBuilder.Append(" <div id=\"footer_tool\">\r\n");
	templateBuilder.Append(" <input type=\"button\" id=\"Sub_button\" name=\"Sub_button\" style=\"margin:5px\" class=\"B_INPUT\" value=\" 确 定 \" />\r\n");
	templateBuilder.Append(" </div>\r\n");

	}	//end if

	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var Orderlist_do_nofull = new TOrderlist_do_nofull();\r\n");
	templateBuilder.Append("Orderlist_do_nofull.ini();\r\n");
	templateBuilder.Append("var gvn=$('#tBoxs').clone(true).removeAttr(\"id\");\r\n");
	templateBuilder.Append("    $(gvn).find(\"tr:not(:first)\").remove();\r\n");
	templateBuilder.Append("    $('#tBoxs').before(gvn);\r\n");
	templateBuilder.Append("    $('#tBoxs').find(\"tr:first\").remove();\r\n");
	templateBuilder.Append("    $('#tBoxs').wrap(\"<div style='height:250px; overflow-y: scroll;overflow-x:hidden; overflow: auto; padding: 0;margin: 0;'></div>\");\r\n");
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
