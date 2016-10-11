<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.dataanalysis_tvalue" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:05. 
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
	templateBuilder.Append("<script src=\"public/js/dataanalysis_tvalue.js\" type=\"text/javascript\" ></" + "script>\r\n");

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
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"left\"><h1>选择\r\n");

	if (Act=="A1" || Act=="E1" ||Act=="F1")
	{

	templateBuilder.Append("				客户、门店:\r\n");

	}	//end if


	if (Act=="A2" || Act=="E2" ||Act=="F2")
	{

	templateBuilder.Append("				业务员:\r\n");

	}	//end if


	if (Act=="A3" || Act=="E3" ||Act=="F3")
	{

	templateBuilder.Append("				促销员:\r\n");

	}	//end if


	if (Act=="A4" || Act=="E4" ||Act=="F4")
	{

	templateBuilder.Append("				产品:\r\n");

	}	//end if


	if (Act=="A5" || Act=="E5" ||Act=="F5")
	{

	templateBuilder.Append("				品牌:\r\n");

	}	//end if


	if (Act=="A6" || Act=="E6" ||Act=="F6")
	{

	templateBuilder.Append("				系统:\r\n");

	}	//end if

	templateBuilder.Append("</h1></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");

	if (dList != null)
	{

	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"left\" >\r\n");
	templateBuilder.Append("                  <ul style=\"height:310px;OVERFLOW:scroll\">\r\n");

	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;


	if (Act=="A1" || Act=="E1" ||Act=="F1")
	{

	templateBuilder.Append("                    	<li><input class=\"B_Check\" alt=\"" + dl["sName"].ToString().Trim() + "\" name=\"tValue\" type=\"checkbox\" value=\"" + dl["StoresID"].ToString().Trim() + "\">" + dl["sName"].ToString().Trim() + "</li>\r\n");

	}	//end if


	if (Act=="A2" || Act=="E2" ||Act=="F2")
	{

	templateBuilder.Append("                    	<li><input class=\"B_Check\" alt=\"" + dl["sName"].ToString().Trim() + "\" name=\"tValue\" type=\"checkbox\" value=\"" + dl["StaffID"].ToString().Trim() + "\">" + dl["sName"].ToString().Trim() + "</li>\r\n");

	}	//end if


	if (Act=="A3" || Act=="E3" ||Act=="F3")
	{

	templateBuilder.Append("                    	<li><input class=\"B_Check\" alt=\"" + dl["sName"].ToString().Trim() + "\" name=\"tValue\" type=\"checkbox\" value=\"" + dl["StaffID"].ToString().Trim() + "\">" + dl["sName"].ToString().Trim() + "</li>\r\n");

	}	//end if


	if (Act=="A4" || Act=="E4" ||Act=="F4")
	{

	templateBuilder.Append("                    	<li><input class=\"B_Check\" alt=\"" + dl["pName"].ToString().Trim() + "\" name=\"tValue\" type=\"checkbox\" value=\"" + dl["ProductsID"].ToString().Trim() + "\">" + dl["pName"].ToString().Trim() + "</li>\r\n");

	}	//end if


	if (Act=="A5" || Act=="E5" ||Act=="F5")
	{

	templateBuilder.Append("                    	<li><input class=\"B_Check\" alt=\"" + dl["pBrand"].ToString().Trim() + "\" name=\"tValue\" type=\"checkbox\" value=\"" + dl["pBrand"].ToString().Trim() + "\">" + dl["pBrand"].ToString().Trim() + "</li>\r\n");

	}	//end if


	if (Act=="A6" || Act=="E6" ||Act=="F6")
	{

	templateBuilder.Append("                    	<li><input class=\"B_Check\" alt=\"" + dl["yName"].ToString().Trim() + "\" name=\"tValue\" type=\"checkbox\" value=\"" + dl["YHsysID"].ToString().Trim() + "\">" + dl["yName"].ToString().Trim() + "</li>\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("                  </ul>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");

	}	//end if

	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"center\"><input type=\"button\" id=\"button1\" style=\"margin:5px\" class=\"B_INPUT\" value=\"确定\" onclick=\"javascript:DataAnalysis_tvalue.ReValue();\"/>\r\n");
	templateBuilder.Append("                  <input type=\"button\" id=\"button2\" style=\"margin:5px\" class=\"B_INPUT\" value=\"取消\" onClick=\"javascript:window.parent.HidBox();\" /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var DataAnalysis_tvalue = new TDataAnalysis_tvalue();\r\n");
	templateBuilder.Append("DataAnalysis_tvalue.ini();\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
