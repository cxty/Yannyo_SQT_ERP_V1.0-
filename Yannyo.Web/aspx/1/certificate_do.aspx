<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.certificate_do" %>
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

	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/dialog.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/certificate_do.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.mcdropdown.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.bgiframe.js\"></" + "script>\r\n");
	templateBuilder.Append("<!--<script type=\"text/javascript\" src=\"public/js/jquery.json2xml.js\"></" + "script>-->\r\n");
	templateBuilder.Append("<link type=\"text/css\" href=\"templates/" + templatepath.ToString() + "/css/jquery.mcdropdown.css\" rel=\"stylesheet\" media=\"all\" />\r\n");
	templateBuilder.Append("<script src=\"public/js/LodopFuncs.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tableBox\">\r\n");
	templateBuilder.Append("  <tr >\r\n");
	templateBuilder.Append("    <td align=\"left\" valign=\"top\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellpadding=\"2\" cellspacing=\"0\">\r\n");
	templateBuilder.Append("      <tr class=\"tBar\">\r\n");
	templateBuilder.Append("        <td>  \r\n");
	templateBuilder.Append("<table  border=\"0\" cellpadding=\"2\" cellspacing=\"2\">\r\n");
	templateBuilder.Append("      <tr >\r\n");
	templateBuilder.Append("        <td width=\"200\">\r\n");
	templateBuilder.Append("        发生时间:\r\n");
	 aspxrewriteurl = cDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("<br /><input name=\"cDateTime\" type=\"text\" id=\"cDateTime\" onClick=\"new Calendar().show(this);\" value=\"" + aspxrewriteurl.ToString() + "\" readonly=\"readonly\"/>\r\n");
	templateBuilder.Append("          </td>\r\n");
	templateBuilder.Append("        <td>\r\n");
	templateBuilder.Append("        <nobr>序号:</nobr><br>\r\n");
	templateBuilder.Append("        <input type=\"text\" id=\"cNumber\" name=\"cNumber\" value=\"" + cNumber.ToString() + "\" />\r\n");
	templateBuilder.Append("          <input type=\"hidden\" id=\"cCode\" name=\"cCode\" value=\"" + cCode.ToString() + "\" />\r\n");
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td>附件张数:<br><input type=\"text\" name=\"cRemake\" id=\"cRemake\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ci.cRemake.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td class=\"aBt\">经办人:<br>\r\n");
	templateBuilder.Append("        <input type=\"hidden\" id=\"StaffID\" name=\"StaffID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ci.StaffID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("        />\r\n");
	templateBuilder.Append("        <input type=\"text\" id=\"StaffName\" name=\"StaffName\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ci.StaffName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("        /><a href=\"#\"  id=\"StaffID_bt\"></a>\r\n");
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("      </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\" id=\"tBoxs\">\r\n");
	templateBuilder.Append("<thead>\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td>摘要</td>\r\n");
	templateBuilder.Append("    <td width=\"20%\">科目</td>\r\n");
	templateBuilder.Append("    <td width=\"20%\">单位</td>\r\n");
	templateBuilder.Append("    <td width=\"10%\" align=\"right\">借方金额</td>\r\n");
	templateBuilder.Append("    <td width=\"10%\" align=\"right\">贷方金额</td>\r\n");
	templateBuilder.Append("    <td width=\"5%\" align=\"center\" >操作</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</thead>\r\n");
	templateBuilder.Append("<tbody id=\"dloop\">\r\n");
	templateBuilder.Append("</tbody>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div style=\"height:50px\"></div>\r\n");
	templateBuilder.Append("<div id=\"footer_tool\">\r\n");
	templateBuilder.Append("<div>\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("	<tr class=\"tBar\">\r\n");
	templateBuilder.Append("	  <td align=\"left\">合计</td>\r\n");
	templateBuilder.Append("	  <td width=\"10%\" align=\"right\" id=\"SumMoneyA\">&nbsp;</td>\r\n");
	templateBuilder.Append("	  <td width=\"10%\" align=\"right\" id=\"SumMoneyB\">&nbsp;</td>\r\n");
	templateBuilder.Append("	  <td width=\"5%\" align=\"right\" id=\"SumMoney\"></td>\r\n");
	templateBuilder.Append("     </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<input type=\"hidden\" name=\"cObject\" id=\"cObject\" \r\n");

	if (OrderID>0)
	{

	templateBuilder.Append("value=\"1\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("<input type=\"hidden\" name=\"NewPIC\" id=\"NewPIC\" value=\"\"/>\r\n");
	templateBuilder.Append("<input type=\"hidden\" name=\"cObjectID\" id=\"cObjectID\" value=\"" + OrderID.ToString() + "\" />\r\n");
	templateBuilder.Append("<input type=\"hidden\" name=\"cMoney\" id=\"cMoney\" value=\"\" />\r\n");
	templateBuilder.Append("<input type=\"hidden\" name=\"CertificateDataStr\" id=\"CertificateDataStr\" value=\"\"/>\r\n");

	if (Act == "Add")
	{

	templateBuilder.Append("<input type=\"button\" name=\"subbutton_add\" id=\"subbutton_add\" value=\" 添加摘要 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("<input type=\"button\" name=\"subbutton_save\" id=\"subbutton_save\" value=\" 保存凭证 \" class=\"B_INPUT\">\r\n");

	}	//end if


	if (Act == "Edit")
	{


	if (IsVerify == true)
	{


	if (ci.cState == 0)
	{


	if (IsVerifyLongTimeB == false)
	{

	templateBuilder.Append("				<input type=\"button\" name=\"subbutton_re_verify\" id=\"subbutton_re_verify\" value=\" 撤回重审 \" class=\"B_INPUT\">\r\n");

	}
	else
	{


	if (CheckUserPopedoms("X") || CheckUserPopedoms("6-5-8"))
	{

	templateBuilder.Append("					<input type=\"button\" name=\"subbutton_re_verify\" id=\"subbutton_re_verify\" value=\" 撤回重审 \" class=\"B_INPUT\">\r\n");

	}	//end if


	}	//end if


	if (IsVerifyLongTime == false)
	{

	templateBuilder.Append("				<input type=\"button\" name=\"subbutton_invalid\" id=\"subbutton_invalid\" value=\" 作  废 \" class=\"B_INPUT\">\r\n");

	}
	else
	{


	if (CheckUserPopedoms("X"))
	{

	templateBuilder.Append("					<input type=\"button\" name=\"subbutton_invalid\" id=\"subbutton_invalid\" value=\" 作  废 \" class=\"B_INPUT\">\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("    	<input type=\"button\" name=\"subbutton_print_t\" id=\"subbutton_print_t\" value=\" 打印凭证 \" class=\"B_INPUT\">\r\n");

	}
	else
	{

	templateBuilder.Append("    	<input type=\"button\" name=\"subbutton_add\" id=\"subbutton_add\" value=\" 添加摘要 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("		<input type=\"button\" name=\"subbutton_save\" id=\"subbutton_save\" value=\" 保存凭证 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("        <input type=\"button\" name=\"subbutton_verify\" id=\"subbutton_verify\" value=\" 审  核 \" class=\"B_INPUT\">\r\n");

	}	//end if

	templateBuilder.Append("    &nbsp;&nbsp;\r\n");
	templateBuilder.Append("    <input type=\"button\" name=\"subbutton_up\" id=\"subbutton_up\" value=\" 上一条 \" class=\"B_INPUT\">&nbsp;\r\n");
	templateBuilder.Append("    <input type=\"button\" name=\"subbutton_down\" id=\"subbutton_down\" value=\" 下一条 \" class=\"B_INPUT\">&nbsp;\r\n");
	templateBuilder.Append("    <input type=\"button\" name=\"subbutton_log\" id=\"subbutton_log\" value=\" 操作记录 \" class=\"B_INPUT\">\r\n");

	}	//end if

	templateBuilder.Append("<!--<input type=\"button\" name=\"subbutton_camera\" id=\"subbutton_camera\" value=\" 录入凭证原件 \" class=\"B_INPUT\">&nbsp;&nbsp;-->\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var Certificate_do = new TCertificate_do();\r\n");
	templateBuilder.Append("Certificate_do.OrderType = " + OrderType.ToString() + ";\r\n");
	templateBuilder.Append("Certificate_do.OrderID = " + OrderID.ToString() + ";\r\n");
	templateBuilder.Append("Certificate_do.PrintPageWidth = '" + config.PrintCertificatePageWidth.ToString().Trim() + "';\r\n");
	templateBuilder.Append("Certificate_do.CertificateDataJsonStr = '" + CertificateDataJsonStr.ToString() + "';\r\n");
	templateBuilder.Append("Certificate_do.Certificate_lock = " + config.Certificate_lock.ToString().Trim() + ";\r\n");
	templateBuilder.Append("Certificate_do.DepartmentsJsonStr = '" + DepartmentsJson.ToString() + "';\r\n");
	templateBuilder.Append("Certificate_do.SupplierJsonStr = '" + SupplierJson.ToString() + "';\r\n");
	templateBuilder.Append("Certificate_do.CustomersJsonStr = '" + CustomersJson.ToString() + "';\r\n");
	templateBuilder.Append("Certificate_do.FeesSubjectJsonStr = '" + FeesSubjectJson.ToString() + "';\r\n");
	templateBuilder.Append("Certificate_do.PaymentSystemJsonStr = '" + PaymentSystemJson.ToString() + "';\r\n");
	templateBuilder.Append("Certificate_do.CertificateID = " + CertificateID.ToString() + ";\r\n");
	templateBuilder.Append("Certificate_do.UserCode = '" + UserCode.ToString() + "';\r\n");
	 aspxrewriteurl = cDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("Certificate_do.OldcDateTime = '" + aspxrewriteurl.ToString() + "';\r\n");

	if (Act=="Add")
	{

	templateBuilder.Append("Certificate_do.IsAddNew = true;\r\n");

	}	//end if


	if (Act=="Edit")
	{

	templateBuilder.Append("Certificate_do.IsEdit = true;\r\n");

	}	//end if

	templateBuilder.Append("Certificate_do.ini();\r\n");
	templateBuilder.Append("function HidBox()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	Certificate_do.HidUserBox();\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("//单位回调\r\n");
	templateBuilder.Append("function cObjReCall(sID,sType,sName)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	HidBox();\r\n");
	templateBuilder.Append("	Certificate_do.ShowcObjectBox_ReCall(sID,sType,sName);\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("//科目对调\r\n");
	templateBuilder.Append("function sObjReCall(sID,sName)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	HidBox();\r\n");
	templateBuilder.Append("	Certificate_do.ShowFeesSubjectBox_ReCall(sID,sName);\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("<object id=\"LODOP\" classid=\"clsid:2105C259-1E0C-4534-8141-A753534CB4CA\" width=0 height=0> \r\n");
	templateBuilder.Append("	<embed id=\"LODOP_EM\" type=\"application/x-print-lodop\" width=0 height=0 pluginspage=\"/public/install_lodop.exe\"></embed>\r\n");
	templateBuilder.Append("</object>\r\n");

	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
