<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.monthlystatementprint" %>
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

	templateBuilder.Append("            <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\" class=\"print_box\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr class=\"print_box_top\">\r\n");
	templateBuilder.Append("                  <td align=\"center\">\r\n");
	templateBuilder.Append("" + config.CompanyName.ToString().Trim() + " 对账单\r\n");

	if (msi.sState==1)
	{

	templateBuilder.Append("                  	(已经作废)\r\n");

	}
	else
	{


	}	//end if

	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"left\" valign=\"top\" >\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td colspan=\"2\" class=\"OrderListTool\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>对账单号:<br />" + msi.sCode.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td>对账单位:<br />\r\n");
	templateBuilder.Append("" + msi.sObjectName.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td>\r\n");
	templateBuilder.Append("对账单日期:<br />\r\n");
	 aspxrewriteurl = msi.sDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("    <td rowspan=\"2\" align=\"right\"><img src=\"qrcode-d-" + msi.MonthlyStatementID.ToString().Trim() + ".aspx\" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <!--\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>上期余额:<br />" + msi.sUpMoney.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("    <td>本期新增金额:<br />" + msi.sThisMoney.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td>本期实际对账金额:<br />" + msi.sMoney.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    -->\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td width=\"50%\" valign=\"top\" ><table width=\"100%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("    <tr >\r\n");
	templateBuilder.Append("      <td colspan=\"5\"><b>单据列表</b></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("      <td width=\"10%\" align=\"center\">单号</td>\r\n");
	templateBuilder.Append("        <td width=\"15%\" align=\"center\">单据类型</td>\r\n");
	templateBuilder.Append("        <td align=\"center\" >业务员</td>\r\n");
	templateBuilder.Append("        <td width=\"15%\" align=\"center\">单据时间</td>\r\n");
	templateBuilder.Append("        <td width=\"15%\" align=\"center\">金额</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	if (msdList!=null)
	{


	int msdl__loop__id=0;
	foreach(DataRow msdl in msdList.Rows)
	{
		msdl__loop__id++;

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("      <td>" + msdl["oOrderNum"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("      <td>\r\n");
	 aspxrewriteurl = GetOrderType(msdl["oType"].ToString());
	
	templateBuilder.Append("      " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("      </td>\r\n");
	templateBuilder.Append("      <td>" + msdl["StaffName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("      <td align=\"right\">\r\n");
	 aspxrewriteurl = Convert.ToDateTime(msdl["oOrderDateTime"]).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("      &nbsp;" + aspxrewriteurl.ToString() + "&nbsp;</td>\r\n");
	templateBuilder.Append("      <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(msdl["oMoney"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	 SumA = SumA+Convert.ToDecimal(msdl["oMoney"]);
	
	templateBuilder.Append("      </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("      <td colspan=\"4\">合计</td>\r\n");
	templateBuilder.Append("      <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(SumA,2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("    <br></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td colspan=\"2\" valign=\"top\" >\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("    <tr >\r\n");
	templateBuilder.Append("      <td colspan=\"5\"><b>凭证列表</b></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("      <td width=\"15%\" align=\"center\">凭证号</td>\r\n");
	templateBuilder.Append("        <td align=\"center\">经办人</td>\r\n");
	templateBuilder.Append("        <td width=\"15%\" align=\"center\">凭证时间</td>\r\n");
	templateBuilder.Append("        <td width=\"15%\" align=\"center\">金额</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	if (msadList!=null)
	{


	int msadl__loop__id=0;
	foreach(DataRow msadl in msadList.Rows)
	{
		msadl__loop__id++;

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("      <td>" + msadl["cCode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("      <td>" + msadl["StaffName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("      <td align=\"right\">\r\n");
	 aspxrewriteurl = Convert.ToDateTime(msadl["cDateTime"]).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("      " + aspxrewriteurl.ToString() + "&nbsp;</td>\r\n");
	templateBuilder.Append("      <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(msadl["cMoney"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  <br></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td colspan=\"2\" valign=\"top\" >\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \" >\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("      <td colspan=\"3\"><b>收付款列表</b></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("      <td width=\"15%\" align=\"center\">发生金额</td>\r\n");
	templateBuilder.Append("        <td width=\"15%\" align=\"center\">发生时间</td>\r\n");
	templateBuilder.Append("        <td align=\"center\">备注</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");

	if (msmdList!=null)
	{


	int msmdl__loop__id=0;
	foreach(DataRow msmdl in msmdList.Rows)
	{
		msmdl__loop__id++;

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("      <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(msmdl["mMoney"]),2).ToString();
	
	templateBuilder.Append("		  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr></td>\r\n");
	templateBuilder.Append("      <td align=\"right\">\r\n");
	 aspxrewriteurl = Convert.ToDateTime(msmdl["mDateTime"]).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("        " + aspxrewriteurl.ToString() + "&nbsp;\r\n");
	templateBuilder.Append("      </td>\r\n");
	templateBuilder.Append("      <td>" + msmdl["mRemake"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("      </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  <br></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td colspan=\"2\"  >\r\n");
	templateBuilder.Append("  <div style=\"margin:5px\"></div>\r\n");
	templateBuilder.Append("  </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("			</form>\r\n");
	templateBuilder.Append("            <!--\r\n");
	templateBuilder.Append("<script language=\"JavaScript\">\r\n");
	templateBuilder.Append("var hkey_root,hkey_path,hkey_key\r\n");
	templateBuilder.Append("hkey_root=\"HKEY_CURRENT_USER\"\r\n");
	templateBuilder.Append("hkey_path=\"\\\\Software\\\\Microsoft\\\\Internet Explorer\\\\PageSetup\\\\\"\r\n");
	templateBuilder.Append("//设置网页打印的页眉页脚为空\r\n");
	templateBuilder.Append("function pagesetup_null(){\r\n");
	templateBuilder.Append("try{\r\n");
	templateBuilder.Append("var RegWsh = new ActiveXObject(\"WScript.Shell\")\r\n");
	templateBuilder.Append("hkey_key=\"header\"\r\n");
	templateBuilder.Append("RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,\"\")\r\n");
	templateBuilder.Append("hkey_key=\"footer\"\r\n");
	templateBuilder.Append("RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,\"\")\r\n");
	templateBuilder.Append("}catch(e){}\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("    </" + "script>\r\n");
	templateBuilder.Append("<OBJECT classid=\"CLSID:8856F961-340A-11D0-A96B-00C04FD705A2\" height=\"0\" id=\"wb\" name=\"wb\" width=\"0\"></OBJECT>\r\n");
	templateBuilder.Append("<script language=\"JavaScript\">\r\n");
	templateBuilder.Append("try\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	if(wb)\r\n");
	templateBuilder.Append("	{\r\n");
	templateBuilder.Append("		wb.execwb(7,1); \r\n");
	templateBuilder.Append("		window.close();\r\n");
	templateBuilder.Append("	}\r\n");
	templateBuilder.Append("	else\r\n");
	templateBuilder.Append("	{\r\n");
	templateBuilder.Append("		try{\r\n");
	templateBuilder.Append("			window.print();\r\n");
	templateBuilder.Append("		}catch(e){\r\n");
	templateBuilder.Append("			alert(\"打印控件启动失败,请查看帮助!\");\r\n");
	templateBuilder.Append("			window.open(\"help_print.html\",\"_blank\");\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	}\r\n");
	templateBuilder.Append("}catch(e){\r\n");
	templateBuilder.Append("	try{\r\n");
	templateBuilder.Append("		window.print();\r\n");
	templateBuilder.Append("	}catch(e){\r\n");
	templateBuilder.Append("		alert(\"打印控件启动失败,请查看帮助!\");\r\n");
	templateBuilder.Append("		window.open(\"help_print.html\",\"_blank\");\r\n");
	templateBuilder.Append("	}\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("</" + "script>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("<div style=\"page-break-after: always\"></div>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
