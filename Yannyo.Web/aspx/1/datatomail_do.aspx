<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.datatomail_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:06. 
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

	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/datatomail_do.js\"></" + "script>  \r\n");
	templateBuilder.Append("        <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("        <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"3\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td width=\"30%\" align=\"right\">数据类型:</td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	templateBuilder.Append("    <select name=\"dDataType\" id=\"dDataType\">\r\n");

	if (DataTypes != null)
	{


	int dt__loop__id=0;
	foreach(DataRow dt in DataTypes.Rows)
	{
		dt__loop__id++;

	templateBuilder.Append("    <option value=\"" + dt["id"].ToString().Trim() + "\" \r\n");

	if (Act=="Edit")
	{


	if (dt["id"].ToString() == dtm.dDataType.ToString())
	{

	templateBuilder.Append("    selected\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("    >" + dt["name"].ToString().Trim() + "</option>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("    </select>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"right\">统计类型:</td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	templateBuilder.Append("    <select name=\"dDateType\" id=\"dDateType\">\r\n");
	templateBuilder.Append("    <option value=\"1\"\r\n");

	if (Act=="Edit")
	{


	if (1 == dtm.dDateType)
	{

	templateBuilder.Append("    selected\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("    >日</option>\r\n");
	templateBuilder.Append("    <option value=\"2\"\r\n");

	if (Act=="Edit")
	{


	if (2 == dtm.dDateType)
	{

	templateBuilder.Append("    selected\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("    >周</option>\r\n");
	templateBuilder.Append("    <option value=\"3\"\r\n");

	if (Act=="Edit")
	{


	if (3 == dtm.dDateType)
	{

	templateBuilder.Append("    selected\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("    >月</option>\r\n");
	templateBuilder.Append("    </select></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"right\">收件人邮箱:</td>\r\n");
	templateBuilder.Append("    <td><input type=\"text\" name=\"dEmail\" id=\"dEmail\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append(" value =\"" + dtm.dEmail.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append("></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"right\">状态:</td>\r\n");
	templateBuilder.Append("    <td><input name=\"dState\" type=\"radio\" id=\"radio\" value=\"0\" class=\"B_Check\" \r\n");

	if (Act=="Edit")
	{


	if (dtm.dState==0)
	{

	templateBuilder.Append("    checked\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("    >正常\r\n");
	templateBuilder.Append("    <input name=\"dState\" type=\"radio\" id=\"radio\" value=\"1\" class=\"B_Check\" \r\n");

	if (Act=="Edit")
	{


	if (dtm.dState==1)
	{

	templateBuilder.Append("    checked\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("    >屏蔽</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("        <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("      <input type=\"button\" id=\"bt_ok\" style=\"margin:5px\" class=\"B_INPUT\" value=\"确定\" />\r\n");
	templateBuilder.Append("        	<input type=\"button\" id=\"bt_cl\" style=\"margin:5px\" class=\"B_INPUT\" value=\"取消\"  />\r\n");
	templateBuilder.Append("        </div>\r\n");
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var DataToMail_Do = new TDataToMail_Do();\r\n");
	templateBuilder.Append("DataToMail_Do.ini();\r\n");
	templateBuilder.Append("function HidBox()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	DataToMail_Do.HidUserBox();\r\n");
	templateBuilder.Append("	location=location;\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("//addTableListener(document.getElementById(\"tBoxs\"),0,0);\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
