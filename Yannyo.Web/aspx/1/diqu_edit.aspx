<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.diqu_edit" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:07. 
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

	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/jquery.js\"></" + "script>\r\n");
	templateBuilder.Append("          <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("          <input type=\"hidden\" id=\"tValue\" name=\"tValue\" />\r\n");
	templateBuilder.Append("          <input type=\"hidden\" id=\"lastName\" name=\"lastName\" \r\n");

	if (Act=="update")
	{

	templateBuilder.Append("value=\"" + pi.rName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("             <table id=\"tTable\" width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\">\r\n");
	templateBuilder.Append("              <tr class=\"tBar\">\r\n");
	templateBuilder.Append("               <td align=\"left\" colspan=\"3\"><span style=\"font-size:10pt\">\r\n");

	if (Act=="update")
	{

	templateBuilder.Append("当前选择：\r\n");

	}
	else
	{

	templateBuilder.Append("上级分类：\r\n");

	}	//end if


	if (regionClassID==0)
	{

	templateBuilder.Append("顶级\r\n");

	}
	else
	{

	templateBuilder.Append("" + pi.rName.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("</span></td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                <td align=\"left\">分类名称：<input showtitle=\"可填写少于50个的中英文字符\" type=\"text\" id=\"tName\" name=\"tName\" \r\n");

	if (Act=="update")
	{

	templateBuilder.Append(" value=\"" + pi.rName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("/></td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                <td align=\"left\">排&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序：<input type=\"text\" id=\"tOrder\" name=\"tOrder\" disabled=\"disabled\"  \r\n");

	if (Act=="update")
	{

	templateBuilder.Append("value=\"" + pi.rOrder.ToString().Trim() + "\"\r\n");

	}
	else
	{

	templateBuilder.Append("value=\"0\"\r\n");

	}	//end if

	templateBuilder.Append("/></td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                <td align=\"left\">操作时间：<input type=\"text\" id=\"tTime\" name=\"tTime\" disabled=\"disabled\" \r\n");

	if (Act=="update")
	{

	templateBuilder.Append(" value=\"" + pi.rAppendTime.ToString().Trim() + "\"\r\n");

	}
	else
	{

	templateBuilder.Append("value=\"" + dAppendTime.ToString() + "\"\r\n");

	}	//end if

	templateBuilder.Append("/></td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("            </table>\r\n");
	templateBuilder.Append("<div style=\"height:30px\"></div>\r\n");
	templateBuilder.Append("<div id=\"footer_tool\"><input type=\"button\" name=\"bt_ok\" id=\"bt_ok\" value=\" 确定 \" class=\"B_INPUT\" style=\"cursor:pointer\"/>&nbsp; &nbsp;<input type=\"button\" name=\"bt_cancel\" id=\"bt_cancel\" value=\" 取消 \" class=\"B_INPUT\" onClick=\"javascript:window.parent.HidBox();\" style=\"cursor:pointer\"/>\r\n");
	templateBuilder.Append("              </div>  \r\n");
	templateBuilder.Append("        </form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("    $(document).ready(function () {\r\n");
	templateBuilder.Append("        $(\"#tName\").click(function () {\r\n");
	templateBuilder.Append("            $(\"#tName\").get(0).select();\r\n");
	templateBuilder.Append("        });\r\n");
	templateBuilder.Append("        //提交数据\r\n");
	templateBuilder.Append("        $(\"#bt_ok\").click(function () {\r\n");
	templateBuilder.Append("            var tName = $(\"#tName\").val();\r\n");
	templateBuilder.Append("            var tOrder = $(\"#tOrder\").val();\r\n");
	templateBuilder.Append("            if (tName != '') {\r\n");
	templateBuilder.Append("                $(\"#bForm\").submit();\r\n");
	templateBuilder.Append("            }\r\n");
	templateBuilder.Append("            else {\r\n");
	templateBuilder.Append("                jAlert(\"请确保部门分类名称不为空！\", \"友情提示\");\r\n");
	templateBuilder.Append("            }\r\n");
	templateBuilder.Append("        });\r\n");
	templateBuilder.Append("    });\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
