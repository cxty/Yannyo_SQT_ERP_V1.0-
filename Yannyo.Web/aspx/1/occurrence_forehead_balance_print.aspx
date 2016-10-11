<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.occurrence_forehead_balance_print" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:22. 
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


	            foreach(DataTable dtm in dsDetails.Tables)
	            {
	            rCount++;
	            
	templateBuilder.Append("<div id=\"print_box\" style=\"margin-left:100px; margin-right:25px; margin-top:30px\">\r\n");
	templateBuilder.Append("    <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\" class=\"print_box\">\r\n");
	templateBuilder.Append("        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("               <td height=\"40\" colspan=\"2\" align=\"center\">\r\n");
	templateBuilder.Append("                <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:70%\">\r\n");
	templateBuilder.Append("                  <tr>\r\n");
	templateBuilder.Append("                    <td width=\"25%\" align=\"center\"></td>\r\n");
	templateBuilder.Append("                    <td align=\"center\"><span style=\"font-size:x-large; text-decoration:underline\"><nobr><b>发生额及余额表</b></nobr></span></td>\r\n");
	templateBuilder.Append("                    <td width=\"25%\" align=\"center\">&nbsp;</td>\r\n");
	templateBuilder.Append("                  </tr>\r\n");
	templateBuilder.Append("                  <tr>\r\n");
	templateBuilder.Append("                    <td colspan=\"2\" align=\"center\"></td>\r\n");
	templateBuilder.Append("                    <td align=\"left\">页号：1-" + rCount.ToString() + "</td>\r\n");
	templateBuilder.Append("                    </tr>\r\n");
	templateBuilder.Append("                  <tr>\r\n");
	templateBuilder.Append("                    <td align=\"center\">&nbsp;</td>\r\n");
	templateBuilder.Append("                    <td align=\"center\">月份：" + bTime.ToString() + "-" + eTime.ToString() + "</td>\r\n");
	templateBuilder.Append("                    <td align=\"left\"><nobr>本币名称：人民币</nobr></td>\r\n");
	templateBuilder.Append("                  </tr>\r\n");
	templateBuilder.Append("                  </table>\r\n");
	templateBuilder.Append("               </td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("              <td>\r\n");
	templateBuilder.Append("               <table width=\"100%\"  border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \" style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("             <tr>\r\n");
	templateBuilder.Append("               <td align=\"center\" rowspan=\"2\" style=\"width:8%;\">科目编码</td>\r\n");
	templateBuilder.Append("               <td align=\"center\" rowspan=\"2\" style=\"width:26%;\">科目名称</td>\r\n");
	templateBuilder.Append("               <td align=\"center\" colspan=\"2\" style=\"width:20%;height:20px;line-height:20px\">期初余额</td>\r\n");
	templateBuilder.Append("               <td align=\"center\" colspan=\"2\" style=\"width:20%;height:20px;line-height:20px\">本期发生</td>\r\n");
	templateBuilder.Append("               <td align=\"center\" colspan=\"2\" style=\"width:20%;height:20px;line-height:20px\">期末余额</td>\r\n");
	templateBuilder.Append("             </tr>\r\n");
	templateBuilder.Append("             <tr>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width:11%; height:20px;line-height:20px\">借方</td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width:11%; height:20px;line-height:20px\">贷方</td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width:11%; height:20px;line-height:20px\">借方</td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width:11%; height:20px;line-height:20px\">贷方</td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width:11%; height:20px;line-height:20px\">借方</td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width:11%; height:20px;line-height:20px\">贷方</td>\r\n");
	templateBuilder.Append("             </tr>\r\n");

	if (sType==0)
	{


	if (dtm !=null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dtm.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("               <td align=\"left\" style=\"width:14%;\"><nobr>" + dl["cCode"].ToString().Trim() + "</nobr></td>\r\n");
	templateBuilder.Append("               <td align=\"left\" style=\"width:20%;\"><nobr>\r\n");
	 aspxrewriteurl = GetFeesSubjectClassParentStr(int.Parse(dl["FeesSubjectClassID"].ToString()),">");
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("               </nobr></td>\r\n");
	templateBuilder.Append("               <!--期初余额借方-->\r\n");
	templateBuilder.Append("               <td align=\"right\" style=\"width:11%\"><nobr>\r\n");
	 oMoney = decimal.Round(Convert.ToDecimal(dl["cAccountMoney"].ToString().Trim()),2);
	

	if (dl["cDirection"].ToString()=="0")
	{


	if (oMoney==0)
	{


	}
	else
	{


	if (oMoney>0)
	{

	templateBuilder.Append("" + oMoney.ToString() + "\r\n");

	}	//end if


	}	//end if


	}	//end if


	if (dl["cDirection"].ToString()=="1")
	{


	if (oMoney==0)
	{


	}
	else
	{


	if (oMoney<0)
	{

	 oMoney = decimal.Round(Convert.ToDecimal(-oMoney),2);
	
	templateBuilder.Append("                          " + oMoney.ToString() + "\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("               &nbsp;</nobr></td>\r\n");
	templateBuilder.Append("                <!--期初余额贷方-->\r\n");
	templateBuilder.Append("               <td align=\"right\" style=\"width:11%\"><nobr>\r\n");
	 oMoney = decimal.Round(Convert.ToDecimal(dl["cAccountMoney"].ToString().Trim()),2);
	

	if (dl["cDirection"].ToString()=="0")
	{


	if (oMoney==0)
	{


	}
	else
	{


	if (oMoney<0)
	{

	 oMoney = decimal.Round(Convert.ToDecimal(-oMoney),2);
	
	templateBuilder.Append("                          " + oMoney.ToString() + "\r\n");

	}	//end if


	}	//end if


	}	//end if


	if (dl["cDirection"].ToString()=="1")
	{


	if (oMoney==0)
	{


	}
	else
	{


	if (oMoney>0)
	{

	templateBuilder.Append("" + oMoney.ToString() + "\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("               &nbsp;</nobr></td>\r\n");
	templateBuilder.Append("                <!--本期发生借方-->\r\n");
	templateBuilder.Append("               <td align=\"right\" style=\"width:11%\"><nobr>\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["JcdMoney"].ToString().Trim()),2).ToString();
	

	if (aspxrewriteurl=="0.00")
	{


	}
	else
	{

	templateBuilder.Append("                          " + aspxrewriteurl.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("               &nbsp;</nobr></td>\r\n");
	templateBuilder.Append("               <!--本期发生贷方-->\r\n");
	templateBuilder.Append("               <td align=\"right\" style=\"width:11%\"><nobr>\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["DcdMoney"].ToString().Trim()),2).ToString();
	

	if (aspxrewriteurl=="0.00")
	{


	}
	else
	{

	templateBuilder.Append("                          " + aspxrewriteurl.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("              &nbsp;</nobr></td>\r\n");
	templateBuilder.Append("              <!--期末余额借方-->\r\n");
	templateBuilder.Append("               <td align=\"right\" style=\"width:11%\"><nobr>\r\n");

	if (dl["cDirection"].ToString()=="0")
	{


	if (Convert.ToInt32(dl["oMoney"])>0)
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("                          " + aspxrewriteurl.ToString() + "\r\n");

	}	//end if


	}	//end if


	if (dl["cDirection"].ToString()=="1")
	{


	if (Convert.ToInt32(dl["iMoney"])<0)
	{

	 jAcount = decimal.Round(-Convert.ToDecimal(dl["iMoney"].ToString().Trim()),2);
	
	templateBuilder.Append("" + jAcount.ToString() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("               &nbsp;</nobr></td>\r\n");
	templateBuilder.Append("               <!--期末余额贷方-->\r\n");
	templateBuilder.Append("               <td align=\"right\" style=\"width:11%\"><nobr>\r\n");

	if (dl["cDirection"].ToString()=="0")
	{


	if (Convert.ToInt32(dl["oMoney"])<0)
	{

	 jAcount = decimal.Round(-Convert.ToDecimal(dl["oMoney"].ToString().Trim()),2);
	
	templateBuilder.Append("" + jAcount.ToString() + "\r\n");

	}	//end if


	}	//end if


	if (dl["cDirection"].ToString()=="1")
	{


	if (Convert.ToInt32(dl["iMoney"])>0)
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["iMoney"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("                          " + aspxrewriteurl.ToString() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("               &nbsp;</nobr></td>\r\n");
	templateBuilder.Append("            </tr>\r\n");

	}	//end loop


	}	//end if


	}	//end if

	templateBuilder.Append("          <!--按科目打印-->\r\n");

	if (sType==1 && sCost !=null)
	{


	if (newTable !=null)
	{


	int cl__loop__id=0;
	foreach(DataRow cl in newTable.Rows)
	{
		cl__loop__id++;

	 obj = getClassDetails(cl["FeesSubjectClassID"].ToString().Trim());
	
	templateBuilder.Append("             <tr>\r\n");
	templateBuilder.Append("               <td align=\"left\" style=\"width:14%;\"><nobr>" + cl["cCode"].ToString().Trim() + "</nobr></td>\r\n");
	templateBuilder.Append("               <td align=\"left\" style=\"width:20%;\"><nobr>" + cl["cClassName"].ToString().Trim() + "</nobr></td>\r\n");
	templateBuilder.Append("                <!--期初余额借方-->\r\n");
	templateBuilder.Append("               <td align=\"right\" style=\"width:9%\"><nobr>\r\n");
	 oMoney = decimal.Round(cAccountMoney,2);
	
	templateBuilder.Append("                   <!--科目方向为借：余额>0-->\r\n");

	if (cl["cDirection"].ToString()=="0")
	{


	if (oMoney==0)
	{


	}
	else
	{


	if (oMoney>0)
	{

	templateBuilder.Append("                                " + oMoney.ToString() + "\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("                   <!--科目方向为贷：余额<0-->\r\n");

	if (cl["cDirection"].ToString()=="1")
	{


	if (oMoney==0)
	{


	}
	else
	{


	if (oMoney<0)
	{

	 oMoney = decimal.Round(Convert.ToDecimal(-oMoney),2);
	
	templateBuilder.Append("" + oMoney.ToString() + "\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("               &nbsp;</nobr></td>\r\n");
	templateBuilder.Append("                <!--期初余额贷方-->\r\n");
	templateBuilder.Append("               <td align=\"right\" style=\"width:9%\"><nobr>\r\n");
	 qMoney = decimal.Round(cAccountMoney,2);
	
	templateBuilder.Append("                   <!--科目方向为借：余额<0-->\r\n");

	if (cl["cDirection"].ToString()=="0")
	{


	if (qMoney==0)
	{


	}
	else
	{


	if (qMoney<0)
	{

	 qMoney = decimal.Round(Convert.ToDecimal(-qMoney),2);
	
	templateBuilder.Append("" + qMoney.ToString() + "\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("                   <!--科目方向为贷：余额>0-->\r\n");

	if (cl["cDirection"].ToString()=="1")
	{


	if (qMoney==0)
	{


	}
	else
	{


	if (qMoney>0)
	{

	templateBuilder.Append("                          " + qMoney.ToString() + "\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("               &nbsp;</nobr></td>\r\n");
	templateBuilder.Append("                <!--本期发生借方-->\r\n");
	templateBuilder.Append("               <td align=\"right\" style=\"width:9%\"><nobr>\r\n");
	 bMoney = decimal.Round(JcdMoney,2);
	

	if (bMoney==0)
	{


	}
	else
	{

	templateBuilder.Append("                          " + bMoney.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("               &nbsp;</nobr></td>\r\n");
	templateBuilder.Append("               <!--本期发生贷方-->\r\n");
	templateBuilder.Append("               <td align=\"right\" style=\"width:9%\"><nobr>\r\n");
	 bMoneyd = decimal.Round(DcdMoney,2);
	

	if (bMoneyd==0)
	{


	}
	else
	{

	templateBuilder.Append("                          " + bMoneyd.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("              &nbsp;</nobr></td>\r\n");
	templateBuilder.Append("              <!--期末余额借方-->\r\n");
	templateBuilder.Append("               <td align=\"right\" style=\"width:9%\"><nobr>\r\n");

	if (cl["cDirection"].ToString()=="0")
	{


	if (OMoney>0)
	{

	 jAcount = decimal.Round(OMoney,2);
	
	templateBuilder.Append("                        " + jAcount.ToString() + "\r\n");

	}	//end if


	}	//end if


	if (cl["cDirection"].ToString()=="1")
	{


	if (iMoney<0)
	{

	 jAcount = decimal.Round(-Convert.ToDecimal(iMoney),2);
	
	templateBuilder.Append("                        " + jAcount.ToString() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("              &nbsp;</nobr></td>\r\n");
	templateBuilder.Append("               <!--期末余额贷方-->\r\n");
	templateBuilder.Append("               <td align=\"right\" style=\"width:9%\"><nobr>\r\n");

	if (cl["cDirection"].ToString()=="0")
	{


	if (OMoney<0)
	{

	 DAcount = decimal.Round(-Convert.ToDecimal(OMoney),2);
	
	templateBuilder.Append("                       " + DAcount.ToString() + "\r\n");

	}	//end if


	}	//end if


	if (cl["cDirection"].ToString()=="1")
	{


	if (iMoney>0)
	{

	 DAcount = decimal.Round(iMoney,2);
	
	templateBuilder.Append("                        " + DAcount.ToString() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("               &nbsp;</nobr></td>\r\n");
	templateBuilder.Append("             </tr>\r\n");

	}	//end loop


	}	//end if


	}	//end if

	templateBuilder.Append("           </table>\r\n");
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("    </form>\r\n");
	templateBuilder.Append("     <div style=\"page-break-after: always\">\r\n");
	templateBuilder.Append("     <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("       <tr>\r\n");
	templateBuilder.Append("         <td>&nbsp;核算单位：" + config.CompanyName.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("         <td>制表：" + uiName.StaffName.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("         <td align=\"right\">打印时间：" + pTime.ToString() + "&nbsp;&nbsp;&nbsp;</td>\r\n");
	templateBuilder.Append("       </tr>\r\n");
	templateBuilder.Append("     </table>\r\n");
	templateBuilder.Append("    </div>\r\n");
	templateBuilder.Append("</div><br /><br />\r\n");
     
	                }
	          

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
