<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.monthlystatementworkinglog" %>
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

	if (msi!=null)
	{

	templateBuilder.Append("            <h2>对账单号:" + msi.sCode.ToString().Trim() + "</h2>\r\n");
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

	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td>" + dl["mAppendTime"].ToString().Trim() + "</td>\r\n");
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

	if (dl["mType"].ToString() == "-1")
	{

	templateBuilder.Append("                  作废\r\n");

	}	//end if


	if (dl["mType"].ToString() == "0")
	{

	templateBuilder.Append("                  新开\r\n");

	}	//end if


	if (dl["mType"].ToString() == "1")
	{

	templateBuilder.Append("                  修改\r\n");

	}	//end if


	if (dl["mType"].ToString() == "2")
	{

	templateBuilder.Append("                  对账确认\r\n");

	}	//end if


	if (dl["mType"].ToString() == "3")
	{

	templateBuilder.Append("                  到款\r\n");

	}	//end if


	if (dl["mType"].ToString() == "4")
	{

	templateBuilder.Append("                  结账\r\n");

	}	//end if


	if (dl["mType"].ToString() == "5")
	{

	templateBuilder.Append("                  打印\r\n");

	}	//end if


	if (dl["mType"].ToString() == "6")
	{

	templateBuilder.Append("                  差额去向处理\r\n");

	}	//end if


	if (dl["mType"].ToString() == "7")
	{

	templateBuilder.Append("                  随附凭证\r\n");

	}	//end if

	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                  <td>" + dl["mMsg"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td colspan=\"4\">\r\n");

	if (PageBarHTML!=null)
	{

	templateBuilder.Append("" + PageBarHTML.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");

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
