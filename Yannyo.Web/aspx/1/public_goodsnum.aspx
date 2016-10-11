<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.public_goodsnum" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:31. 
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

	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/public_goodsnum.js\"></" + "script>\r\n");
	templateBuilder.Append("<div id=\"shiyan\"></div>\r\n");
	templateBuilder.Append("<form name=\"form1\" id=\"form1\" method=\"post\" action=\"\">\r\n");
	templateBuilder.Append("<div id=\"col_head\" style=\"width:100%\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("  <thead >\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td colspan=\"2\"><b>" + mGoods.title.ToString().Trim() + "(" + mGoods.ProductsName.ToString().Trim() + ")</b></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td width=\"50%\">仓库</td>\r\n");
	templateBuilder.Append("    <td>数量(请填最小单位:" + mProducts.pUnits.ToString().Trim() + ")</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  </thead>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\" id=\"tBoxs\">\r\n");

	if (dList != null)
	{

	templateBuilder.Append("  <tbody id=\"dloop\">\r\n");

	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("  <tr >\r\n");
	templateBuilder.Append("    <td width=\"50%\">" + dl["sName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	templateBuilder.Append("      <input type=\"hidden\" name=\"m_StorageID_" + dl__loop__id.ToString() + "\" id=\"m_StorageID_" + dl__loop__id.ToString() + "\" value=\"" + dl["StorageID"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("      <input name=\"num_" + dl__loop__id.ToString() + "\" type=\"text\" id=\"num_" + dl__loop__id.ToString() + "\" value=\"" + dl["m_Num"].ToString().Trim() + "\" pToBoxNo=\"" + dl["pToBoxNo"].ToString().Trim() + "\" pUnits=\"" + dl["pUnits"].ToString().Trim() + "\" pMaxUnits=\"" + dl["pMaxUnits"].ToString().Trim() + "\" onKeyDown=\"javascript:Public_GoodsNum.onChange(this);\" onKeyUp=\"javascript:Public_GoodsNum.onChange(this);\" onKeyPress=\"javascript:Public_GoodsNum.onChange(this);\" style=\"width:50px\">\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");

	}	//end loop

	templateBuilder.Append("  </tbody>\r\n");

	}	//end if

	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div style=\"height:30px\"></div>\r\n");
	templateBuilder.Append("<div id=\"footer_tool\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("	<tr>\r\n");
	templateBuilder.Append("	  <td width=\"50%\" align=\"left\">合计:\r\n");

	if (dList != null)
	{

	templateBuilder.Append("	    <input type=\"hidden\" name=\"m_count\" id=\"m_count\" value=\"\">\r\n");

	}	//end if

	templateBuilder.Append("       </td>\r\n");
	templateBuilder.Append("	  <td align=\"left\"><span id=\"sum_num\"></span></td>\r\n");
	templateBuilder.Append("	  </tr>\r\n");
	templateBuilder.Append("	<tr>\r\n");
	templateBuilder.Append("	  <td colspan=\"2\" align=\"center\">\r\n");
	templateBuilder.Append("		<input type=\"button\" name=\"bt_updatenum\" id=\"bt_updatenum\" value=\" 确定 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("		<input type=\"button\" name=\"bt_cancel\" id=\"bt_cancel\" value=\" 取消 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("	  </td>\r\n");
	templateBuilder.Append("	</tr>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var Public_GoodsNum = new TPublic_GoodsNum();\r\n");
	templateBuilder.Append("Public_GoodsNum.reobj = '" + objstr.ToString() + "';\r\n");
	templateBuilder.Append("Public_GoodsNum.pUnits = '" + mProducts.pUnits.ToString().Trim() + "';\r\n");
	templateBuilder.Append("Public_GoodsNum.pMaxUnits = '" + mProducts.pMaxUnits.ToString().Trim() + "';\r\n");
	templateBuilder.Append("Public_GoodsNum.pToBoxNo = '" + mProducts.pToBoxNo.ToString().Trim() + "';\r\n");
	templateBuilder.Append("Public_GoodsNum.ini();\r\n");
	templateBuilder.Append("window.onscroll =function()\r\n");
	templateBuilder.Append("	{\r\n");
	templateBuilder.Append("		var t = document.body.getBoundingClientRect().top;\r\n");
	templateBuilder.Append("		var head=document.getElementById(\"col_head\");\r\n");
	templateBuilder.Append("		if((t+document.getElementById(\"shiyan\").offsetTop)<0)\r\n");
	templateBuilder.Append("		{\r\n");
	templateBuilder.Append("			head.style.position=\"absolute\";\r\n");
	templateBuilder.Append("			document.getElementById(\"col_head\").style.top = (-t) +\"px\";\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("		else\r\n");
	templateBuilder.Append("		{\r\n");
	templateBuilder.Append("			head.style.position=\"\";\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	}\r\n");
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
