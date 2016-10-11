<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.certificate_print" %>
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


	        foreach(DataTable dt in CertificateDataSet.Tables)
	        {
	        cdMoneySum = 0;
	        cdMoneyBSum = 0;
	        pageindex++;
	        
	templateBuilder.Append("<div  style=\"page-break-after:always;\">\r\n");
	templateBuilder.Append("<div id=\"print_box\" style=\"margin-left:50px;margin-top:50px;margin-right:30px;\">\r\n");
	templateBuilder.Append("        	<form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\" class=\"print_box\">\r\n");
	templateBuilder.Append("            <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr >\r\n");
	templateBuilder.Append("                  <td height=\"40\" colspan=\"2\" align=\"center\">\r\n");
	templateBuilder.Append("                  <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n");
	templateBuilder.Append("                  <tr><td width=\"10\" align=\"center\">\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                    <td align=\"center\" style=\"font-size:24px\"><span style=\"font-size:x-large; text-decoration:underline\">记账凭证</span></td>\r\n");
	templateBuilder.Append("                    <td width=\"10\" align=\"center\">&nbsp;</td>\r\n");
	templateBuilder.Append("                  </tr>\r\n");
	templateBuilder.Append("                  <tr>\r\n");
	templateBuilder.Append("                    <td align=\"center\">&nbsp;</td>\r\n");
	templateBuilder.Append("                    <td align=\"center\"><b>\r\n");
	 aspxrewriteurl = ci.cDateTime.ToString("yyyy 年 MM 月 dd 日");
	
	templateBuilder.Append("                " + aspxrewriteurl.ToString() + "</b></td>\r\n");
	templateBuilder.Append("                    <td align=\"center\">&nbsp;</td>\r\n");
	templateBuilder.Append("                  </tr>\r\n");
	templateBuilder.Append("                  </table>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr >\r\n");
	templateBuilder.Append("                <td align=\"left\">核算单位:" + config.CompanyName.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                <td align=\"right\">\r\n");
	templateBuilder.Append("<nobr>\r\n");
	 aspxrewriteurl = (ci.cNumber.ToString()).PadLeft(config.CertificateCodeLen,'0');
	
	templateBuilder.Append("第" + aspxrewriteurl.ToString() + "号\r\n");
	templateBuilder.Append("—\r\n");
	 aspxrewriteurl = (pageindex.ToString()).PadLeft(config.CertificateCodeLen,'0');
	
	templateBuilder.Append("(" + aspxrewriteurl.ToString() + "/\r\n");
	 aspxrewriteurl = (CertificateDataSet.Tables.Count.ToString()).PadLeft(config.CertificateCodeLen,'0');
	
	templateBuilder.Append("" + aspxrewriteurl.ToString() + ")\r\n");
	templateBuilder.Append("</nobr>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("              <td colspan=\"2\" align=\"left\" valign=\"top\" >\r\n");
	templateBuilder.Append("              <table width=\"100%\"  border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \" style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                    <td width=\"20%\" height=\"30\" align=\"center\" style=\"font-size:18px\">摘 要</td>\r\n");
	templateBuilder.Append("                  <td align=\"center\" style=\"font-size:18px\">会 计 科 目</td>\r\n");
	templateBuilder.Append("                  <td width=\"15%\" align=\"center\" style=\"font-size:18px\">借方金额</td>\r\n");
	templateBuilder.Append("                    <td width=\"15%\" align=\"center\" style=\"font-size:18px\">贷方金额</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");

	if (dt!=null)
	{


	int cdl__loop__id=0;
	foreach(DataRow cdl in dt.Rows)
	{
		cdl__loop__id++;

	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td height=\"50\">" + cdl["cdName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                  <td>\r\n");
	 aspxrewriteurl = GetFeesSubjectClassParentStr( int.Parse(cdl["FeesSubjectID"].ToString()),"\\");
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "&nbsp;&nbsp;" + cdl["ObjectName"].ToString().Trim() + "\r\n");
	templateBuilder.Append("				  </td>\r\n");
	templateBuilder.Append("                  <td align=\"right\">\r\n");

	if (Convert.ToDecimal(cdl["cdMoney"])!=0)
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(cdl["cdMoney"]),2).ToString();
	
	templateBuilder.Append("		 <nobr>" + aspxrewriteurl.ToString() + "&nbsp;&nbsp;</nobr>\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("                  <td align=\"right\">\r\n");

	if (Convert.ToDecimal(cdl["cdMoneyB"])!=0)
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(cdl["cdMoneyB"]),2).ToString();
	
	templateBuilder.Append("		 <nobr>" + aspxrewriteurl.ToString() + "&nbsp;&nbsp;</nobr>\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	 cdMoneySum = cdMoneySum+decimal.Parse(cdl["cdMoney"].ToString());
	
	 cdMoneyBSum = cdMoneyBSum+decimal.Parse(cdl["cdMoneyB"].ToString());
	

	}	//end loop


	if (cdl__loop__id < CertificateMAXRow)
	{


	                for(int k=0;k<(CertificateMAXRow-cdl__loop__id);k++)
	                {
	                
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                    <td height=\"50\" >&nbsp;</td>\r\n");
	templateBuilder.Append("                    <td >&nbsp;</td>\r\n");
	templateBuilder.Append("                    <td align=\"right\">&nbsp;</td>\r\n");
	templateBuilder.Append("                    <td align=\"right\">&nbsp;</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");

	                }
	                

	}	//end if

	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                <td height=\"30\">附单据数:" + ci.cRemake.ToString().Trim() + "张</td>\r\n");
	templateBuilder.Append("                <td>\r\n");
	 aspxrewriteurl = chang(cdMoneySum.ToString());
	
	templateBuilder.Append("                  合计:" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("                <td width=\"10%\" align=\"right\">\r\n");

	if (Convert.ToDecimal(cdMoneySum)!=0)
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(cdMoneySum),2).ToString();
	
	templateBuilder.Append("		 <nobr>" + aspxrewriteurl.ToString() + "&nbsp;&nbsp;</nobr>\r\n");

	}	//end if

	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("                    <td width=\"10%\" align=\"right\">\r\n");

	if (Convert.ToDecimal(cdMoneyBSum)!=0)
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(cdMoneyBSum),2).ToString();
	
	templateBuilder.Append("		 <nobr>" + aspxrewriteurl.ToString() + "&nbsp;&nbsp;</nobr>\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");

	}	//end if

	templateBuilder.Append("                </table></td>\r\n");
	templateBuilder.Append("             </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td colspan=\"2\" valign=\"top\" >\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td width=\"15%\">财务主管: </td>\r\n");
	templateBuilder.Append("    <td width=\"15%\">记账:</td>\r\n");
	templateBuilder.Append("    <td width=\"15%\">复核:\r\n");

	if (print_v_ui!=null)
	{


	if (print_v_ui.StaffName!=null)
	{

	templateBuilder.Append("" + print_v_ui.StaffName.ToString().Trim() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    <td width=\"15%\">出纳:</td>\r\n");
	templateBuilder.Append("    <td width=\"15%\">制单:" + print_ui.StaffName.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td width=\"15%\">经办人:" + ci.StaffName.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("            </table>\r\n");
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("        </div><br><br>\r\n");
	templateBuilder.Append("        </div>\r\n");

	        }
	        

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
