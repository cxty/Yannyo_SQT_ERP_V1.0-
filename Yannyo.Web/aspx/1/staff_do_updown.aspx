<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.staff_do_updown" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:42. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/comm.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/xml.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery-1.3.2.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");

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

	templateBuilder.Append("<script src=\"public/js/staff_do_updown.js\" language=\"javascript\" type=\"text/javascript\"></" + "script>\r\n");
	templateBuilder.Append("    <div class=\"main\" id=\"usermanage\">\r\n");

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

	templateBuilder.Append("       <form action=\"\" method=\"post\" name=\"form1\" id=\"form1\"> \r\n");
	templateBuilder.Append("       <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("	   <tr>\r\n");
	templateBuilder.Append("		 <td width=\"20%\" class=\"ltd\">人员名称:</td>\r\n");
	templateBuilder.Append("		 <td class=\"rtd\"><b>" + si.sName.ToString().Trim() + "</b></td>\r\n");
	templateBuilder.Append("	   </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td width=\"20%\" class=\"ltd\">\r\n");

	if (Act=="Up")
	{

	templateBuilder.Append("上岗时间\r\n");

	}	//end if


	if (Act=="Down")
	{

	templateBuilder.Append("离岗时间\r\n");

	}	//end if

	templateBuilder.Append(":</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\"><input name=\"aDate\" id=\"aDate\" onClick=\"new Calendar().show(this);\" type=\"text\" >\r\n");
	templateBuilder.Append("<INPUT TYPE=\"hidden\" NAME=\"tSidStr\" id=\"tSidStr\"></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");

	if (si.sType == 1 || si.sType==2)
	{

	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">选择门店</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\">\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("          <tr class=\"tBar\">\r\n");
	templateBuilder.Append("            <td width=\"5%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"\" onClick=\"javascript:selectCheck(document.getElementById('form1'),this);\"/></td>\r\n");
	templateBuilder.Append("            <td >门店客户名称</td>\r\n");

	if (Act=="Down")
	{

	templateBuilder.Append("			<td width=\"20%\">上岗时间</td>\r\n");

	}	//end if

	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("		  <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\">\r\n");

	if (dList != null)
	{

	templateBuilder.Append("		  <div style=\"overflow:scroll;height:280px;overflow-x:hidden;\">\r\n");
	templateBuilder.Append("		  <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\"  >\r\n");

	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("          <tr >\r\n");
	templateBuilder.Append("            <td width=\"5%\">\r\n");
	templateBuilder.Append("			<input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"" + dl["StoresID"].ToString().Trim() + "\" />\r\n");
	templateBuilder.Append("            </td>\r\n");

	if (Act=="Up")
	{

	templateBuilder.Append("			<td >" + dl["sName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	if (Act=="Down")
	{

	templateBuilder.Append("			<td >" + dl["StoresName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	if (Act=="Down")
	{

	templateBuilder.Append("            <td width=\"20%\">\r\n");
	templateBuilder.Append("			" + dl["bdate"].ToString().Trim() + "\r\n");
	templateBuilder.Append("			</td>\r\n");

	}	//end if

	templateBuilder.Append("          </tr>\r\n");

	}	//end loop

	templateBuilder.Append("			</table>\r\n");
	templateBuilder.Append("			</div>\r\n");

	}	//end if

	templateBuilder.Append("		  </td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");

	}	//end if

	templateBuilder.Append("</table>    \r\n");
	templateBuilder.Append("<div style=\"height:30px\"></div>\r\n");
	templateBuilder.Append("            <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"center\">\r\n");
	templateBuilder.Append("                  	<input type=\"button\" id=\"button5\" style=\"margin:5px\" class=\"B_INPUT\" value=\"确定\" onClick=\"javascript:Staff_do_updown.OKGo();\"  />\r\n");
	templateBuilder.Append("<input type=\"button\" id=\"button6\" style=\"margin:5px\" class=\"B_INPUT\" value=\"退出\" onClick=\"javascript:parent.HidBox();\"  />\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </div>\r\n");
	templateBuilder.Append("</form>\r\n");

	}	//end if

	templateBuilder.Append("    </div>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var Staff_do_updown = new TStaff_do_updown();\r\n");
	templateBuilder.Append("Staff_do_updown.Act = '" + Act.ToString() + "';\r\n");

	if (si.sType == 1 || si.sType==2)
	{

	templateBuilder.Append("Staff_do_updown.IsNoList = true;\r\n");

	}	//end if

	templateBuilder.Append("Staff_do_updown.ini();\r\n");
	templateBuilder.Append("function HidBox()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	Staff_do_updown.HidUserBox();\r\n");
	templateBuilder.Append("	location.reload();\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
