<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.report_certificate_summary_print" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:33. 
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

	templateBuilder.Append("        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("          <tr class=\"print_box_top\">\r\n");
	templateBuilder.Append("            <td colspan=\"2\" align=\"center\"><b>凭证汇总表</b></td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("          <tr class=\"print_box_top\">\r\n");
	templateBuilder.Append("            <td colspan=\"2\">单位名称:" + config.CompanyName.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("          <tr class=\"print_box_top\">\r\n");
	templateBuilder.Append("            <td>凭证范围:" + bDate.ToString() + "~" + eDate.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">共" + cCount.ToString() + "张</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"2\">\r\n");
	templateBuilder.Append("            <table width=\"100%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \" style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("<thead>\r\n");
	templateBuilder.Append("  <tr >\r\n");
	templateBuilder.Append("    <td width=\"10%\">科目代码</td>\r\n");
	templateBuilder.Append("    <td width=\"20%\">科目名称</td>\r\n");
	templateBuilder.Append("    <td width=\"15%\" align=\"right\">借方金额</td>\r\n");
	templateBuilder.Append("    <td width=\"15%\" align=\"right\">贷方金额</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</thead>\r\n");
	templateBuilder.Append("<tbody id=\"dloop\">\r\n");

	if (dList!=null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("  <tr >\r\n");
	templateBuilder.Append("    <td>" + dl["cCode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td width=\"20%\">" + dl["cClassName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td width=\"20%\" align=\"right\" >" + dl["cdMoney"].ToString().Trim() + "&nbsp;\r\n");
	 cdMoneySum = Convert.ToDecimal(cdMoneySum+Convert.ToDecimal(dl["cdMoney"]));
	
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"10%\" align=\"right\">" + dl["cdMoneyB"].ToString().Trim() + "&nbsp;\r\n");
	 cdMoneyBSum = Convert.ToDecimal(cdMoneyBSum+Convert.ToDecimal(dl["cdMoneyB"]));
	
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	}	//end loop

	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("	<td>合计</td>\r\n");
	templateBuilder.Append("    <td width=\"20%\">&nbsp;</td>\r\n");
	templateBuilder.Append("    <td width=\"20%\" align=\"right\">" + cdMoneySum.ToString() + "&nbsp;</td>\r\n");
	templateBuilder.Append("    <td width=\"10%\" align=\"right\">" + cdMoneyBSum.ToString() + "&nbsp;</td>\r\n");
	templateBuilder.Append("</tr>\r\n");

	}	//end if

	templateBuilder.Append("</tbody>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("        打印时间:" + DateTime.Now.ToString().Trim() + "\r\n");
	templateBuilder.Append("        <br><br>\r\n");
	templateBuilder.Append("        <div style=\"page-break-after: always\"></div>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
