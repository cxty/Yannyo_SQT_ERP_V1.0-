<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.apmoney_bat" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:48:48. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/Cxty_XTool.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/apmoney_bat.js \"></" + "script>\r\n");

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
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" >\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td colspan=\"4\" align=\"left\"><h1>应付信息</h1></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("					<td width=\"20%\" align=\"right\">(1)应付对象</td>\r\n");
	templateBuilder.Append("					<td align=\"left\">\r\n");
	templateBuilder.Append("					<INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"APObjType\" id=\"APObjType_A\" value=\"2\" onclick=\"javascript:ApmoneyManage_Bat.CheckR();\" checked >供货商\r\n");
	templateBuilder.Append("					<INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"APObjType\" id=\"APObjType_B\" value=\"1\" onclick=\"javascript:ApmoneyManage_Bat.CheckR();\" >个人\r\n");
	templateBuilder.Append("					</td>\r\n");
	templateBuilder.Append("<td width=\"20%\" align=\"right\">\r\n");
	templateBuilder.Append("					(2)截止日期:</td>\r\n");
	templateBuilder.Append("					<td align=\"left\">\r\n");
	 aspxrewriteurl = eDate.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("<input name=\"eDate\" id=\"eDate\" onClick=\"new Calendar().show(this);ApmoneyManage_Bat.CheckR();\" type=\"text\" value=\"" + aspxrewriteurl.ToString() + "\" style=\"width:90px\" />\r\n");
	templateBuilder.Append("					</td>\r\n");
	templateBuilder.Append("				</tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("					<td colspan=\"4\" align=\"left\">\r\n");
	templateBuilder.Append("<table width=\"630px\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td width=\"100px\">\r\n");
	templateBuilder.Append("   	 <span id=\"tObj_Box\">供货商</span>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"80px\">新增应付金额</td>\r\n");
	templateBuilder.Append("    <td width=\"80px\">实际应付金额</td>\r\n");
	templateBuilder.Append("	<td width=\"80px\">已付金额</td>\r\n");
	templateBuilder.Append("	<td width=\"100px\">科目</td>\r\n");
	templateBuilder.Append("	<td width=\"80px\">发生时间</td>\r\n");
	templateBuilder.Append("    <td width=\"30px\">操作</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"7\">\r\n");
	templateBuilder.Append("    <div style=\"overflow:scroll;height:300px;overflow-x:hidden;clear:left;\" align=\"left\" id=\"tLoop_box\">\r\n");
	templateBuilder.Append("    </div>\r\n");
	templateBuilder.Append("	<INPUT TYPE=\"hidden\" NAME=\"Act\" id=\"Act\">\r\n");
	templateBuilder.Append("	<INPUT TYPE=\"hidden\" NAME=\"loop_count_obj\" id=\"loop_count_obj\">\r\n");
	templateBuilder.Append("	<input type=\"button\" id=\"button3\" style=\"margin:5px\" class=\"B_INPUT\" value=\"增加\" onClick=\"javascript:ApmoneyManage_Bat.Add();\" />\r\n");
	templateBuilder.Append("	<input type=\"button\" id=\"button1\" style=\"margin:5px\" class=\"B_INPUT\" value=\"(3)确定保存\" onClick=\"javascript:ApmoneyManage_Bat.CheckS();\"/>\r\n");
	templateBuilder.Append("    <input type=\"button\" id=\"button2\" style=\"margin:5px\" class=\"B_INPUT\" value=\"取消\" onClick=\"javascript:window.parent.HidBox();\" />\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("					</td>\r\n");
	templateBuilder.Append("				</tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </form>\r\n");
	templateBuilder.Append("    <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("	var ApmoneyManage_Bat = new TApmoneyManage_Bat();\r\n");
	templateBuilder.Append("	ApmoneyManage_Bat.ini();\r\n");
	templateBuilder.Append("	</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
