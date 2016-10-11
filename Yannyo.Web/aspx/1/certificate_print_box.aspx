<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.certificate_print_box" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:48:53. 
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

	templateBuilder.Append("<script language=\"javascript\" src=\"public/js/jTable.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/certificate_print_box.js\" type=\"text/javascript\"></" + "script>        \r\n");
	templateBuilder.Append("<script src=\"public/js/LodopFuncs.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("<table border=\"0\" cellspacing=\"3\" cellpadding=\"3\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"left\">凭证时间:<br/><input name=\"cDateTimeB\" id=\"cDateTimeB\" style=\"width:80px\" value=\"" + cDateTimeB.ToString() + "\" type=\"text\" onClick=\"new Calendar().show(this);\" readonly=\"readonly\"/>-<input name=\"cDateTimeE\" id=\"cDateTimeE\" style=\"width:80px\" value=\"" + cDateTimeE.ToString() + "\" type=\"text\" onClick=\"new Calendar().show(this);\" readonly=\"readonly\"/></td>\r\n");
	templateBuilder.Append("	<td align=\"left\">凭证序号:<br/>\r\n");
	templateBuilder.Append("    <input name=\"cNumber\" id=\"cNumber\" value=\"" + cNumber.ToString() + "\" type=\"text\" style=\"width:50px\" /></td>\r\n");
	templateBuilder.Append("    <td align=\"left\">审核状态:<br/>\r\n");
	templateBuilder.Append("    <select id=\"cSteps\" name=\"cSteps\" >\r\n");
	templateBuilder.Append("    <option value=\"-1\" \r\n");

	if (cSteps==-1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(" >全部</option>\r\n");
	templateBuilder.Append("    <option value=\"0\" \r\n");

	if (cSteps==0)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">未审核</option>\r\n");
	templateBuilder.Append("    <option value=\"1\" \r\n");

	if (cSteps==1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">已审核</option>\r\n");
	templateBuilder.Append("    </select></td>\r\n");
	templateBuilder.Append("	<td align=\"left\">系统状态:<br/>\r\n");
	templateBuilder.Append("    <select id=\"cState\" name=\"cState\" >\r\n");
	templateBuilder.Append("    <option value=\"-1\" \r\n");

	if (cState==-1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(" >全部</option>\r\n");
	templateBuilder.Append("    <option value=\"0\" \r\n");

	if (cState==0)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">正常</option>\r\n");
	templateBuilder.Append("    <option value=\"1\" \r\n");

	if (cState==1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">作废</option>\r\n");
	templateBuilder.Append("    </select></td>\r\n");
	templateBuilder.Append("    <td align=\"left\">\r\n");
	templateBuilder.Append("	<input type=\"button\" id=\"button_Search\" name=\"button_Search\" style=\"margin:5px;width:120px\" class=\"B_INPUT\" value=\" 凭证查找 \"  />\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div class=\"datalist\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tBox\" id=\"tBoxs\">\r\n");
	templateBuilder.Append("<thead>\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("  <td width=\"1%\" align=\"center\"><input type=\"checkbox\" name=\"checkbox_b\" id=\"checkbox_b\" class=\"B_Check\"></td>\r\n");
	templateBuilder.Append("    <td>凭证编号</td>\r\n");
	templateBuilder.Append("    <td width=\"20%\">经办人</td>\r\n");
	templateBuilder.Append("    <td width=\"20%\" align=\"right\">金额</td>\r\n");
	templateBuilder.Append("    <td width=\"10%\" align=\"center\">步骤</td>\r\n");
	templateBuilder.Append("    <td width=\"10%\" align=\"center\">状态</td>\r\n");
	templateBuilder.Append("    <td width=\"10%\" align=\"right\">发生时间</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</thead>\r\n");
	templateBuilder.Append("<tbody id=\"dloop\">\r\n");

	if (dList!=null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("  <tr CertificateID=\"" + dl["CertificateID"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("    <td align=\"center\"><input type=\"checkbox\"\r\n");
	 aspxrewriteurl = Convert.ToDateTime(dl["cDateTime"]).ToString("yyyyMMdd")+"-"+(dl["cNumber"].ToString()).PadLeft(config.CertificateCodeLen,'0');
	
	templateBuilder.Append("    cCode=\"" + aspxrewriteurl.ToString() + "\"\r\n");
	 aspxrewriteurl = Convert.ToDateTime(dl["cAppendTime"]).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("    cAppendTime=\"" + aspxrewriteurl.ToString() + "\"\r\n");
	templateBuilder.Append("    cMoney=\"" + dl["cMoney"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("    cType=\"" + dl["cType"].ToString().Trim() + "\"\r\n");
	 aspxrewriteurl = (dl["cType"].ToString() == "0" ? "收款" : (dl["cType"].ToString() == "1") ? "付款" : dl["cType"].ToString() == "2"?"其他":"");
	
	templateBuilder.Append("    cTypeStr=\"" + aspxrewriteurl.ToString() + "\"\r\n");
	templateBuilder.Append("    UserID=\"" + dl["UserID"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("    UserName=\"" + dl["UserName"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("    UserStaffName=\"" + dl["UserStaffName"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("    StaffName=\"" + dl["StaffName"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("    StaffID=\"" + dl["StaffID"].ToString().Trim() + "\"\r\n");
	 aspxrewriteurl = Convert.ToDateTime(dl["cDateTime"]).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("    cDateTime=\"" + aspxrewriteurl.ToString() + "\"\r\n");
	templateBuilder.Append("    cObject=\"" + dl["cObject"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("    cObjectID=\"" + dl["cObjectID"].ToString().Trim() + "\"\r\n");
	templateBuilder.Append("     name=\"checkbox_b\" id=\"checkbox_b_" + dl__loop__id.ToString() + "\" value=\"" + dl["CertificateID"].ToString().Trim() + "\" class=\"B_Check\"></td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	 aspxrewriteurl = Convert.ToDateTime(dl["cDateTime"]).ToString("yyyyMMdd")+"-"+(dl["cNumber"].ToString()).PadLeft(config.CertificateCodeLen,'0');
	
	templateBuilder.Append("	" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("    <td width=\"20%\">" + dl["StaffName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td width=\"20%\" align=\"right\" class=\"loop_Money\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["cMoney"]),2).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"10%\" align=\"center\">\r\n");

	if (dl["cSteps"].ToString() == "0")
	{

	templateBuilder.Append("    <span style=\"color:#F00\" >未审核</span>\r\n");

	}
	else
	{

	templateBuilder.Append("    已审核\r\n");

	}	//end if

	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"10%\" align=\"center\">\r\n");

	if (dl["cState"].ToString() == "0")
	{

	templateBuilder.Append("    正常\r\n");

	}
	else
	{

	templateBuilder.Append("    <span style=\"color:#F00\" >作废</span>\r\n");

	}	//end if

	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"10%\" align=\"right\">\r\n");
	 aspxrewriteurl = Convert.ToDateTime(dl["cDateTime"]).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("</tbody>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div style=\"height:70px;\r\n");
	templateBuilder.Append("float:left\">\r\n");
	templateBuilder.Append("<object id=\"LODOP\" classid=\"clsid:2105C259-1E0C-4534-8141-A753534CB4CA\" width=0 height=0> \r\n");
	templateBuilder.Append("	<embed id=\"LODOP_EM\" type=\"application/x-print-lodop\" width=0 height=0 pluginspage=\"/public/install_lodop.exe\"></embed>\r\n");
	templateBuilder.Append("</object>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<div id=\"footer_tool\">\r\n");
	templateBuilder.Append("<div>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td><b>合计:" + SumMoney.ToString() + "</b></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"center\"><input type=\"button\" id=\"button_Print\" name=\"button_Print\" style=\"margin:5px;width:120px\" class=\"B_INPUT\" value=\" 打印选中凭证 \"  />&nbsp;\r\n");
	templateBuilder.Append("    <input type=\"button\" id=\"button_cl\" name=\"button_cl\" style=\"margin:5px;width:120px\" class=\"B_INPUT\" value=\" 取消 \"  /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("  <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("        var Certificate_print_box = new TCertificate_print_box();\r\n");
	templateBuilder.Append("		Certificate_print_box.UserCode = '" + UserCode.ToString() + "';\r\n");
	templateBuilder.Append("        Certificate_print_box.ini();\r\n");
	templateBuilder.Append("        addTableListener(document.getElementById(\"tBoxs\"),0,0);\r\n");
	templateBuilder.Append("        var tf = new TableFixed(\"tBoxs\");\r\n");
	templateBuilder.Append("        tf.Clone();\r\n");
	templateBuilder.Append("        </" + "script>\r\n");
	templateBuilder.Append("</form>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
