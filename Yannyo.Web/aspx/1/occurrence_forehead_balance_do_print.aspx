<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.occurrence_forehead_balance_do_print" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:21. 
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
	templateBuilder.Append("        <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\">\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("               <td height=\"40\" colspan=\"2\" align=\"center\">\r\n");
	templateBuilder.Append("                <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:70%\">\r\n");
	templateBuilder.Append("                  <tr class=\"print_box_top\">\r\n");
	templateBuilder.Append("                    <td width=\"25%\" align=\"center\"></td>\r\n");
	templateBuilder.Append("                    <td align=\"center\"><b><span style=\"font-size:x-large; text-decoration:underline\"><nobr>\r\n");

	if (sType==0)
	{

	templateBuilder.Append("" + className.ToString() + "明细账\r\n");

	}	//end if


	if (sType==1)
	{

	templateBuilder.Append("" + zNode.ToString() + "总账\r\n");

	}	//end if

	templateBuilder.Append("</nobr></span></b></td>\r\n");
	templateBuilder.Append("                    <td width=\"25%\" align=\"center\">&nbsp;</td>\r\n");
	templateBuilder.Append("                  </tr>\r\n");
	templateBuilder.Append("                  <tr>\r\n");
	templateBuilder.Append("                    <td colspan=\"2\" align=\"center\"></td>\r\n");
	templateBuilder.Append("                    <td align=\"left\">页号：1-" + rCount.ToString() + "</td>\r\n");
	templateBuilder.Append("                   </tr>\r\n");
	templateBuilder.Append("                  <tr>\r\n");
	templateBuilder.Append("                    <td align=\"center\">&nbsp;</td>\r\n");
	templateBuilder.Append("                    <td align=\"center\">月份：" + bTime.ToString() + "-" + eTime.ToString() + "</td>\r\n");
	templateBuilder.Append("                    <td align=\"left\"><nobr>本币名称：人民币</nobr></td>\r\n");
	templateBuilder.Append("                  </tr>\r\n");
	templateBuilder.Append("                  </table>\r\n");
	templateBuilder.Append("               </td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("                <td align=\"left\">科目：\r\n");

	if (sType==0)
	{

	templateBuilder.Append("" + fatherNode.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("" + zNode.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("(" + classCode.ToString() + ")</td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("              <td>\r\n");
	templateBuilder.Append("           <table border=\"1\" cellpadding=\"1\" cellspacing=\"0\" style=\"width: 100%\">\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("                <td colspan=\"2\" align=\"center\" style=\"width: 10%;\">\r\n");
	templateBuilder.Append("                    <span style=\"font-size: 11pt\">\r\n");
	templateBuilder.Append("                     " + getYear.ToString() + "年\r\n");
	templateBuilder.Append("                    </span>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td rowspan=\"2\" align=\"center\" style=\"width: 5%;\">\r\n");
	templateBuilder.Append("                    <span style=\"font-size: 11pt\">凭证号数</span>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td rowspan=\"2\" align=\"center\" style=\"width: 35%;\">\r\n");
	templateBuilder.Append("                    <span style=\"font-size: 11pt\">摘要</span>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td rowspan=\"2\" align=\"center\" style=\"width: 15%;\">\r\n");
	templateBuilder.Append("                    <span style=\"font-size: 11pt\">借方</span>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td rowspan=\"2\" align=\"center\" style=\"width: 15%;\">\r\n");
	templateBuilder.Append("                    <span style=\"font-size: 11pt\">贷方</span>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td rowspan=\"2\" align=\"center\" style=\"width: 5%;\">\r\n");
	templateBuilder.Append("                    <span style=\"font-size: 11pt\">方向</span>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td rowspan=\"2\" align=\"center\" style=\"width: 15%;\">\r\n");
	templateBuilder.Append("                    <span style=\"font-size: 11pt\">余额</span>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("              <td align=\"center\" style=\"width: 5%;\">月</td>\r\n");
	templateBuilder.Append("              <td align=\"center\" style=\"width: 5%;\">日</td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("             <!--上年结转-->\r\n");

	if (rCount==1)
	{


	if (tl)
	{

	 cAccountMoney = ycAccountMoney;
	

	}
	else
	{


	if (ysCost !=null)
	{


	int yl__loop__id=0;
	foreach(DataRow yl in ysCost.Rows)
	{
		yl__loop__id++;

	 cAccountMoney = Convert.ToDecimal(yl["cAccountMoney"].ToString().Trim());
	

	}	//end loop


	}	//end if


	}	//end if

	templateBuilder.Append("            <!--上页结转-->\r\n");

	}
	else
	{

	 cAccountMoney = upDate;
	

	}	//end if

	 sumC = 0;
	
	 sumJ = 0;
	
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 35%;\">\r\n");

	if (rCount==1)
	{


	if (oneMonth==1)
	{

	templateBuilder.Append("上年结转\r\n");

	}
	else
	{

	templateBuilder.Append("期初余额\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");

	}
	else
	{

	templateBuilder.Append("                结转上页\r\n");

	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 15%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 15%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 5%;\">\r\n");
	templateBuilder.Append("                <!--上年结转-->\r\n");

	if (rCount==1)
	{

	 oMoney = decimal.Round(cAccountMoney,2);
	

	if (classDirection==0)
	{


	if (oMoney>0)
	{

	templateBuilder.Append("借\r\n");

	}	//end if


	if (oMoney<0)
	{

	templateBuilder.Append("贷\r\n");

	}	//end if


	}	//end if


	if (classDirection==1)
	{


	if (oMoney<0)
	{

	templateBuilder.Append("借\r\n");

	}	//end if


	if (oMoney>0)
	{

	templateBuilder.Append("贷\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                <!--上页结转-->\r\n");

	}
	else
	{


	if (upDate>0)
	{

	templateBuilder.Append("借\r\n");

	}	//end if


	if (upDate<0)
	{

	templateBuilder.Append("贷\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\">\r\n");

	if (rCount==1)
	{

	templateBuilder.Append("                <!--上年结转-->\r\n");

	if (classDirection==0)
	{


	if (oMoney>0)
	{

	templateBuilder.Append("" + oMoney.ToString() + "\r\n");

	}
	else
	{

	 oMoney = decimal.Round(-oMoney,2);
	
	templateBuilder.Append("" + oMoney.ToString() + " \r\n");

	}	//end if


	}	//end if


	if (classDirection==1)
	{


	if (oMoney>0)
	{

	templateBuilder.Append("" + oMoney.ToString() + "\r\n");

	}
	else
	{

	 oMoney = decimal.Round(-oMoney,2);
	
	templateBuilder.Append("" + oMoney.ToString() + " \r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                <!--上页结转-->\r\n");

	}
	else
	{


	if (upDate>0)
	{

	templateBuilder.Append("" + upDate.ToString() + "\r\n");

	}
	else
	{

	 upDate = decimal.Round(-upDate,2);
	
	templateBuilder.Append("" + upDate.ToString() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                &nbsp;</td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	 tLoopid = 1;
	
	 sumA = 0;
	
	 sumAA = 0;
	
	templateBuilder.Append("           <!--明细统计-->\r\n");

	if (sType==0)
	{


	if (dtm!=null)
	{


	int cl__loop__id=0;
	foreach(DataRow cl in dtm.Rows)
	{
		cl__loop__id++;

	 cdtMonth = cl["Cmonth"].ToString();
	
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                    <td align=\"left\"  style=\"width: 5%;\">" + cl["Cmonth"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                    <td align=\"left\" style=\"width: 5%;\">" + cl["Cday"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                    <td align=\"left\" style=\"width: 5%;\"><nobr>\r\n");
	 aspxrewriteurl = (cl["pzCode"].ToString()).PadLeft(config.CertificateCodeLen,'0');
	
	templateBuilder.Append("" + aspxrewriteurl.ToString() + "</nobr>\r\n");
	templateBuilder.Append("                    </td>\r\n");
	templateBuilder.Append("                    <td align=\"left\" style=\"width: 35%;\"><nobr>" + cl["cdName"].ToString().Trim() + "</nobr></td>\r\n");
	templateBuilder.Append("                    <!--借方-->\r\n");
	templateBuilder.Append("                    <td align=\"right\" style=\"width: 15%;\">\r\n");
	 JDirection = decimal.Round(Convert.ToDecimal(cl["cdMoney"].ToString().Trim()),2);
	

	if (JDirection==0)
	{


	}
	else
	{

	templateBuilder.Append("                                " + JDirection.ToString() + "\r\n");

	}	//end if

	 sumA = decimal.Round(sumA+JDirection,2);
	
	 sumB = decimal.Round(sumB+JDirection,2);
	
	templateBuilder.Append("                    &nbsp;</td>\r\n");
	templateBuilder.Append("                    <!--贷方-->\r\n");
	templateBuilder.Append("                    <td align=\"right\" style=\"width: 15%;\">\r\n");
	 DDirection = decimal.Round(Convert.ToDecimal(cl["cdMoneyB"].ToString().Trim()),2);
	

	if (DDirection==0)
	{


	}
	else
	{

	templateBuilder.Append("                                " + DDirection.ToString() + "\r\n");

	}	//end if

	 sumAA = decimal.Round(sumAA+DDirection,2);
	
	 sumBB = decimal.Round(sumBB+DDirection,2);
	
	templateBuilder.Append("                    &nbsp;</td>\r\n");
	templateBuilder.Append("                    <!--余额在借方-->\r\n");

	if (classDirection==0)
	{

	templateBuilder.Append("                         <!--贷方为0-->\r\n");

	if (DDirection==0)
	{

	templateBuilder.Append("                              <!--余额大于0在借方或结存余额大于0-->\r\n");

	if (sumC>=0 || cAccountMoney>=0)
	{

	 aspxrewriteurl = decimal.Round(cAccountMoney+Convert.ToDecimal(cl["cdMoney"].ToString().Trim()),2).ToString();
	
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}
	else
	{

	templateBuilder.Append("                              <!--余额小于0在贷方或结存余额大于0-->\r\n");
	 aspxrewriteurl = decimal.Round(cAccountMoney+Convert.ToDecimal(cl["cdMoneyA"].ToString().Trim()),2).ToString();
	
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}	//end if


	}	//end if

	templateBuilder.Append("                         <!--借方为0-->\r\n");

	if (JDirection==0)
	{

	templateBuilder.Append("                              <!--余额大于0在借方或结存余额大于0-->\r\n");

	if (sumC>=0 || cAccountMoney>=0)
	{

	 aspxrewriteurl = decimal.Round(cAccountMoney+Convert.ToDecimal(cl["cdMoneyBB"].ToString().Trim()),2).ToString();
	
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}
	else
	{

	templateBuilder.Append("                              <!--余额小于0在贷方或结存余额大于0-->\r\n");
	 aspxrewriteurl = decimal.Round(cAccountMoney+Convert.ToDecimal(cl["cdMoneyB"].ToString().Trim()),2).ToString();
	
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}	//end if


	}	//end if


	if (DDirection !=0 && JDirection !=0)
	{

	templateBuilder.Append("                             <!--余额大于0在借方或结存余额大于0-->\r\n");

	if (sumC>=0 || cAccountMoney>=0)
	{

	 aspxrewriteurl = decimal.Round(cAccountMoney+Convert.ToDecimal(cl["cdMoney"].ToString().Trim())-Convert.ToDecimal(cl["cdMoneyB"].ToString().Trim()),2).ToString();
	
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}
	else
	{

	 aspxrewriteurl = decimal.Round(cAccountMoney+Convert.ToDecimal(cl["cdMoneyB"].ToString().Trim())-Convert.ToDecimal(cl["cdMoney"].ToString().Trim()),2).ToString();
	
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("                     <!--余额在贷方-->\r\n");

	if (classDirection==1)
	{

	 cAccountMoney = decimal.Round(-cAccountMoney);
	
	templateBuilder.Append("                         <!--贷方无数据-->\r\n");

	if (DDirection==0)
	{

	templateBuilder.Append("                            <!--余额大于0在借方或结存余额大于0-->\r\n");

	if (sumC<0 || cAccountMoney<=0)
	{

	 aspxrewriteurl = decimal.Round(cAccountMoney+Convert.ToDecimal(cl["cdMoney"].ToString().Trim()),2).ToString();
	
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}
	else
	{

	 aspxrewriteurl = decimal.Round(-cAccountMoney+Convert.ToDecimal(cl["cdMoney"].ToString().Trim()),2).ToString();
	
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}	//end if


	}	//end if

	templateBuilder.Append("                         <!--借方无数据-->\r\n");

	if (JDirection==0)
	{

	templateBuilder.Append("                            <!--余额小于0在贷方方或结存余额大于0-->\r\n");

	if (sumC>=0 || cAccountMoney<=0)
	{

	 aspxrewriteurl = decimal.Round(cAccountMoney+Convert.ToDecimal(cl["cdMoneyBB"].ToString().Trim()),2).ToString();
	
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}
	else
	{

	 aspxrewriteurl = decimal.Round(cAccountMoney+Convert.ToDecimal(cl["cdMoneyB"].ToString().Trim()),2).ToString();
	
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}	//end if


	}	//end if


	if (DDirection !=0 && JDirection !=0)
	{


	if (sumC<=0 || cAccountMoney<=0)
	{

	 aspxrewriteurl = decimal.Round(cAccountMoney-Convert.ToDecimal(cl["cdMoneyB"].ToString().Trim())+Convert.ToDecimal(cl["cdMoney"].ToString().Trim()),2).ToString();
	
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}
	else
	{

	 aspxrewriteurl = decimal.Round(cAccountMoney+Convert.ToDecimal(cl["cdMoney"].ToString().Trim())-Convert.ToDecimal(cl["cdMoneyB"].ToString().Trim()),2).ToString();
	
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("                    <!--借贷关系判断-->\r\n");
	templateBuilder.Append("                    <td align=\"center\" style=\"width: 5%;\">\r\n");

	if (sumC>0)
	{

	templateBuilder.Append("借\r\n");

	}	//end if


	if (sumC<0)
	{

	templateBuilder.Append("贷\r\n");

	}	//end if

	templateBuilder.Append("                    </td>\r\n");
	templateBuilder.Append("                    <!--余额-->\r\n");
	templateBuilder.Append("                    <td align=\"right\" style=\"width: 15%;\">\r\n");

	if (sumC>0)
	{

	templateBuilder.Append("" + sumC.ToString() + "\r\n");

	}	//end if


	if (sumC<0)
	{

	 sumCC = decimal.Round(-sumC,2);
	
	templateBuilder.Append("" + sumCC.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("                    &nbsp;</td>\r\n");
	templateBuilder.Append("                </tr> \r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 5%;\">\r\n");
	templateBuilder.Append("               " + cdtMonth.ToString() + "\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 35%;\"><b>本月合计</b></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\">\r\n");

	if (sumA==0)
	{

	templateBuilder.Append("<b>0.00</b>\r\n");

	}
	else
	{

	templateBuilder.Append("                    <b>" + sumA.ToString() + "</b>\r\n");

	}	//end if

	templateBuilder.Append("                &nbsp;</td>\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\">\r\n");

	if (sumAA==0)
	{

	templateBuilder.Append("<b>0.00</b>\r\n");

	}
	else
	{

	templateBuilder.Append("                    <b>" + sumAA.ToString() + "</b>\r\n");

	}	//end if

	templateBuilder.Append("                &nbsp;</td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 5%;\">\r\n");

	if (sumC>0)
	{

	templateBuilder.Append("<b>借</b>\r\n");

	}	//end if


	if (sumC<0)
	{

	templateBuilder.Append("<b>贷</b>\r\n");

	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\">\r\n");

	if (sumC>0)
	{

	templateBuilder.Append("<b>" + sumC.ToString() + "</b>\r\n");

	}	//end if


	if (sumC<0)
	{

	 sumCC = decimal.Round(-sumC,2);
	
	templateBuilder.Append("<b>" + sumCC.ToString() + "</b>\r\n");

	}	//end if

	templateBuilder.Append("                &nbsp;</td>      \r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 5%;\">\r\n");
	templateBuilder.Append("                " + cdtMonth.ToString() + "\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 35%;\"><b>本月累计</b></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\">\r\n");

	if (sumB==0)
	{

	templateBuilder.Append("<b>0.00</b>\r\n");

	}
	else
	{

	templateBuilder.Append("                    <b>" + sumB.ToString() + "</b>\r\n");

	}	//end if

	templateBuilder.Append("                &nbsp;</td>\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\">\r\n");

	if (sumBB==0)
	{

	templateBuilder.Append("<b>0.00</b>\r\n");

	}
	else
	{

	templateBuilder.Append("                    <b>" + sumBB.ToString() + "</b>\r\n");

	}	//end if

	templateBuilder.Append("                &nbsp;</td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 5%;\">\r\n");

	if (sumC>0)
	{

	templateBuilder.Append("<b>借</b>\r\n");

	}	//end if


	if (sumC<0)
	{

	templateBuilder.Append("<b>贷</b>\r\n");

	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\">\r\n");

	if (sumC>0)
	{

	templateBuilder.Append("<b>" + sumC.ToString() + "</b>\r\n");

	}	//end if


	if (sumC<0)
	{

	 sumCC = decimal.Round(-sumC,2);
	
	templateBuilder.Append("<b>" + sumCC.ToString() + "</b>\r\n");

	}	//end if

	templateBuilder.Append("                &nbsp;</td>\r\n");
	templateBuilder.Append("            </tr> \r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"8\">\r\n");
	templateBuilder.Append("            <div style=\"page-break-after: always\"></div>\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            </tr>\r\n");

	}	//end if


	if (nTable !=null)
	{


	int ml__loop__id=0;
	foreach(DataRow ml in nTable.Rows)
	{
		ml__loop__id++;

	 obj = getMonthCostTotalDetails(subjectID,bDate,eDate,ml["oMonth"].ToString().Trim(),sType,status);
	
	templateBuilder.Append("               <!--总账明细-->\r\n");

	if (sType==1)
	{

	templateBuilder.Append("               <tr>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 5%;\">\r\n");
	 pMonth = Convert.ToDecimal(ml["oMonth"].ToString());
	

	if (pMonth>0 && pMonth<10)
	{

	templateBuilder.Append("0" + ml["oMonth"].ToString().Trim() + "\r\n");

	}
	else
	{

	templateBuilder.Append("                 " + ml["oMonth"].ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 35%;\"><b>本月合计</b></td>\r\n");
	templateBuilder.Append("                <!--借方-->\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\">\r\n");
	 moneyA = decimal.Round(Convert.ToDecimal(cdMoney),2);
	
	 sumD = decimal.Round(sumD+moneyA,2);
	

	if (moneyA==0)
	{


	}
	else
	{

	templateBuilder.Append("                 <b>" + moneyA.ToString() + "</b>\r\n");

	}	//end if

	templateBuilder.Append("                &nbsp;</td>\r\n");
	templateBuilder.Append("                <!--贷方-->\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\">\r\n");
	 moneyB = decimal.Round(Convert.ToDecimal(cdMoneyB),2);
	
	 sumDD = decimal.Round(sumDD+moneyB,2);
	

	if (moneyB==0)
	{


	}
	else
	{

	templateBuilder.Append("                 <b>" + moneyB.ToString() + "</b>\r\n");

	}	//end if

	templateBuilder.Append("                &nbsp;</td>\r\n");
	templateBuilder.Append("                <!--余额大于0：余额+借方-贷方-->\r\n");

	if (sumE>0 ||cAccountMoney>=0)
	{

	 aspxrewriteurl = decimal.Round(cAccountMoney+moneyA-moneyB,2).ToString();
	
	 sumE = decimal.Round(sumE+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	
	templateBuilder.Append("                <!--余额小于0：余额+贷方-借方-->\r\n");

	}
	else
	{

	 cAccountMoney = decimal.Round(-cAccountMoney,2);
	
	 aspxrewriteurl = decimal.Round(cAccountMoney+moneyB-moneyA,2).ToString();
	
	 sumE = decimal.Round(sumE+Convert.ToDecimal(aspxrewriteurl),2);
	
	 cAccountMoney = 0;
	

	}	//end if

	templateBuilder.Append("                <td align=\"center\" style=\"width: 5%;\">\r\n");

	if (sumE>0)
	{

	templateBuilder.Append("借\r\n");

	}	//end if


	if (sumE<0)
	{

	templateBuilder.Append("贷\r\n");

	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\">\r\n");

	if (sumE>0)
	{

	templateBuilder.Append("" + sumE.ToString() + "\r\n");

	}	//end if


	if (sumE<0)
	{

	 sumCC = decimal.Round(-sumE,2);
	
	templateBuilder.Append("" + sumCC.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("                &nbsp;</td>      \r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("               <tr>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 5%;\">\r\n");
	 pMonth = Convert.ToDecimal(ml["oMonth"].ToString());
	

	if (pMonth>0 && pMonth<10)
	{

	templateBuilder.Append("0" + ml["oMonth"].ToString().Trim() + "\r\n");

	}
	else
	{

	templateBuilder.Append("                 " + ml["oMonth"].ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 35%;\">\r\n");

	if (Convert.ToInt32(maxList)==Convert.ToInt32(ml["oMonth"].ToString()))
	{

	templateBuilder.Append("                 本年累计\r\n");

	}
	else
	{

	templateBuilder.Append("                <b>本月累计</b>\r\n");

	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                  <td align=\"right\" style=\"width: 15%;\">\r\n");

	if (sumD==0)
	{


	}
	else
	{


	if (Convert.ToInt32(maxList)==Convert.ToInt32(ml["oMonth"].ToString()))
	{

	templateBuilder.Append("                 " + sumD.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("<b>" + sumD.ToString() + "</b>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                 &nbsp;</td>\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\">\r\n");

	if (sumDD==0)
	{


	}
	else
	{


	if (Convert.ToInt32(maxList)==Convert.ToInt32(ml["oMonth"].ToString()))
	{

	templateBuilder.Append("" + sumDD.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("<b>" + sumDD.ToString() + "</b>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                 &nbsp;</td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 5%;\">\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\"></td>\r\n");
	templateBuilder.Append("            </tr> \r\n");

	}	//end if


	}	//end loop


	}	//end if


	if (sType==0)
	{

	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("             <td align=\"center\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 5%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"left\" style=\"width: 35%;\">\r\n");

	if (dTable==rCount)
	{

	templateBuilder.Append("                结转下年\r\n");

	}
	else
	{

	templateBuilder.Append("                结转下页\r\n");

	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 15%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 15%;\"></td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width: 5%;\">\r\n");

	if (sumC>0)
	{

	templateBuilder.Append("借\r\n");

	}	//end if


	if (sumC<0)
	{

	templateBuilder.Append("贷\r\n");

	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"right\" style=\"width: 15%;\">\r\n");

	if (sumC>0)
	{

	templateBuilder.Append("" + sumC.ToString() + "\r\n");

	}	//end if


	if (sumC<0)
	{

	 sumCC = decimal.Round(-sumC,2);
	
	templateBuilder.Append("" + sumCC.ToString() + "\r\n");

	}	//end if

	 upDate = sumC;
	
	templateBuilder.Append("                &nbsp;</td>\r\n");
	templateBuilder.Append("            </tr>\r\n");

	}	//end if

	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("            <tr><td></td></tr>\r\n");
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
