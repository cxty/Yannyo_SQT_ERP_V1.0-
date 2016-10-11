<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.orderprint_add" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:26. 
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

	templateBuilder.Append("<div id=\"print_box\">\r\n");
	templateBuilder.Append("<form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\" class=\"print_box\">    \r\n");

	            foreach(DataTable dList in OrderListDataSet.Tables)
	            {
	            pageindex++;
	            
	templateBuilder.Append("			<DIV \r\n");

	if (pageindex>1)
	{

	templateBuilder.Append("            STYLE=\"page-break-before:always\"\r\n");

	}	//end if

	templateBuilder.Append("            >\r\n");
	templateBuilder.Append("            <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("              <tr>\r\n");
	templateBuilder.Append("                <td height=\"110\" colspan=\"2\" align=\"center\">&nbsp;</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr>\r\n");
	templateBuilder.Append("                <td colspan=\"2\" align=\"center\" style=\"font-size:18px\">\r\n");
	 aspxrewriteurl = oi.oOrderDateTime.ToString("yyyy  MM  dd");
	
	templateBuilder.Append("                " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr>\r\n");
	templateBuilder.Append("                <td width=\"120\">&nbsp;</td>\r\n");
	templateBuilder.Append("                <td style=\"font-size:18px\">" + oi.StoresSupplierName.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr>\r\n");
	templateBuilder.Append("                <td height=\"45\" colspan=\"2\">&nbsp;</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("            </table>\r\n");

	if (dList!=null)
	{

	templateBuilder.Append("            <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"  >\r\n");

	int ol__loop__id=0;
	foreach(DataRow ol in dList.Rows)
	{
		ol__loop__id++;


	if (ol["IsGifts"].ToString() =="0")
	{

	templateBuilder.Append("                    <tr>\r\n");
	templateBuilder.Append("                    <td width=\"50\" height=\"35\">\r\n");
	templateBuilder.Append("                    </td>\r\n");
	templateBuilder.Append("                      <td width=\"150\">\r\n");
	 aspxrewriteurl = Utils.CutString(ol["ProductsName"].ToString(),0,15);
	
	templateBuilder.Append("                      " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("                      <td width=\"70\" align=\"center\" >1*" + ol["ProductsToBoxNo"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                      <td width=\"60\" align=\"center\">" + ol["ProductsUnits"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                      <td width=\"60\" align=\"center\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oQuantity"]),2).ToString();
	
	templateBuilder.Append("                      <nobr>" + aspxrewriteurl.ToString() + "</nobr>\r\n");
	templateBuilder.Append("                      </td>\r\n");
	templateBuilder.Append("                      <td width=\"70\"  align=\"center\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oPrice"]),2).ToString();
	
	templateBuilder.Append("                                  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("                      </td>\r\n");
	templateBuilder.Append("                      <td width=\"70\" align=\"center\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(ol["oMoney"]),2).ToString();
	
	templateBuilder.Append("                                  <nobr>" + aspxrewriteurl.ToString() + "&nbsp;</nobr>\r\n");
	templateBuilder.Append("                      </td>\r\n");
	templateBuilder.Append("                        <td width=\"60\" align=\"center\">\r\n");
	templateBuilder.Append("                        <nobr>" + ol["ProductsAddress"].ToString().Trim() + "</nobr>\r\n");
	templateBuilder.Append("                        </td>\r\n");

	if (OrderFieldList!=null)
	{


	if (OrderFieldValueList!=null)
	{


	int ofl__loop__id=0;
	foreach(DataRow ofl in OrderFieldList.Rows)
	{
		ofl__loop__id++;


	if (ofl["fPrintAdd"].ToString()=="0")
	{

	templateBuilder.Append("              <td width=\"70\" align=\"center\" ><nobr>\r\n");

	int ofvl__loop__id=0;
	foreach(DataRow ofvl in OrderFieldValueList.Rows)
	{
		ofvl__loop__id++;


	if (ofvl["OrderListID"].ToString() == ol["OrderListID"].ToString() && ofvl["OrderFieldID"].ToString()==ofl["OrderFieldID"].ToString())
	{

	templateBuilder.Append("                                        " + ofvl["oFieldValue"].ToString().Trim() + "\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("                                </nobr>\r\n");
	templateBuilder.Append("                      </td>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if

	templateBuilder.Append("              </tr>\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("</table>\r\n");

	if (ol__loop__id < config.PrintAddRow)
	{

	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"  >\r\n");

	                    for(int k=1;k<(config.PrintAddRow-ol__loop__id);k++)
	                    {
	                    
	templateBuilder.Append("                    <tr>\r\n");
	templateBuilder.Append("                    <td height=\"20\">&nbsp;</td>\r\n");
	templateBuilder.Append("                  </tr>\r\n");

	                    }
	                    
	templateBuilder.Append("              </table>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("            <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("              <tr>\r\n");
	templateBuilder.Append("                <td height=\"40\"  align=\"right\" style=\"font-size:18px\">" + print_ui.StaffName.ToString().Trim() + "&nbsp;&nbsp;</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("            </table>\r\n");
	templateBuilder.Append("            <br>\r\n");
	templateBuilder.Append("            <br>\r\n");
	templateBuilder.Append("            <div STYLE=\"page-break-before:always;height:10px\"></div>\r\n");
	templateBuilder.Append("            </DIV>\r\n");

	            }
	            
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("</div>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
