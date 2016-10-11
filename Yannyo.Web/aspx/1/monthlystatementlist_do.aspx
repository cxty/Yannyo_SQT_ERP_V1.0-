<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.monthlystatementlist_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:15. 
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
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/dialog.js \"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.cookie.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.hotkeys.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.jstree.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.maskedinput-1.2.2.min.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/monthlystatementlist_do.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/LodopFuncs.js\" type=\"text/javascript\" ></" + "script>\r\n");

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

	templateBuilder.Append("        <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"3\"><table border=\"0\" cellspacing=\"3\" cellpadding=\"3\">\r\n");
	templateBuilder.Append("  <tr>\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("  <td width=\"100\" align=\"left\">账单号:<br />\r\n");
	templateBuilder.Append(" <b> " + ms.sCode.ToString().Trim() + "</b>\r\n");
	templateBuilder.Append("  </td>\r\n");

	}	//end if

	templateBuilder.Append("    <td align=\"left\">账单类型:<br />\r\n");
	templateBuilder.Append("      <select name=\"sType\" id=\"sType\" >\r\n");
	templateBuilder.Append("        <option value=\"2\"\r\n");

	if (Act=="Edit")
	{


	if (ms.sType==2)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if


	}
	else
	{


	if (sType==2)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append(">应收</option>\r\n");
	templateBuilder.Append("        <option value=\"1\"\r\n");

	if (Act=="Edit")
	{


	if (ms.sType==1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if


	}
	else
	{


	if (sType==1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append(">应付</option>\r\n");
	templateBuilder.Append("<option value=\"3\"\r\n");

	if (Act=="Edit")
	{


	if (ms.sType==3)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if


	}
	else
	{


	if (sType==3)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append(">其他</option>\r\n");
	templateBuilder.Append("      </select></td>\r\n");
	templateBuilder.Append("   <td align=\"left\" class=\"aBt\">对账单位:<br />\r\n");
	templateBuilder.Append("	<input name=\"sObjectType\" id=\"sObjectType\" type=\"hidden\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("       value=\"" + ms.sObjectType.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("	<input name=\"sObjectID\" id=\"sObjectID\" type=\"hidden\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("       value=\"" + ms.sObjectID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("	<input name=\"sObjectName\" type=\"text\" id=\"sObjectName\"\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("    value=\"" + ms.sObjectName.ToString().Trim() + "\" 	\r\n");

	}	//end if

	templateBuilder.Append("  />\r\n");
	templateBuilder.Append("	<a href=\"#\" id=\"toobjbt\"></a>\r\n");
	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("	<select name=\"sObjectType\" id=\"sObjectType\">\r\n");
	templateBuilder.Append(" <option value=\"0\" \r\n");

	if (Act=="Edit")
	{


	if (ms.sObjectType==0)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append(" >客户</option>\r\n");
	templateBuilder.Append(" <option value=\"3\"\r\n");

	if (Act=="Edit")
	{


	if (ms.sObjectType==3)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append(">╚结算系统</option>\r\n");
	templateBuilder.Append("  <option value=\"1\"\r\n");

	if (Act=="Edit")
	{


	if (ms.sObjectType==1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append(">供应商</option>\r\n");
	templateBuilder.Append("  <option value=\"2\"\r\n");

	if (Act=="Edit")
	{


	if (ms.sObjectType==2)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append(">人员</option>\r\n");
	templateBuilder.Append("  </select>-->\r\n");
	templateBuilder.Append("  </td>\r\n");
	templateBuilder.Append("    <td align=\"left\"><span id=\"sObject\"></span><br />\r\n");
	templateBuilder.Append("<!--<input name=\"sObjectName\" id=\"sObjectName\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ms.sObjectName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("      <input name=\"sObjectID\" id=\"sObjectID\" type=\"hidden\"\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("       value=\"" + ms.sObjectID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("        />--></td>\r\n");
	templateBuilder.Append("    <td align=\"left\">对账时间:<br /><input name=\"sDateTime\" id=\"sDateTime\" \r\n");

	if (Act=="Edit")
	{

	 aspxrewriteurl = Convert.ToDateTime(ms.sDateTime.ToString()).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("    value=\"" + aspxrewriteurl.ToString() + "\"\r\n");

	}	//end if

	templateBuilder.Append("     type=\"text\"  readonly=\"readonly\"/></td>\r\n");
	templateBuilder.Append("    <td align=\"left\">是否已开票:<br />\r\n");
	templateBuilder.Append("      <select name=\"sReceiptState\" id=\"sReceiptState\" >\r\n");
	templateBuilder.Append("        <option value=\"1\"\r\n");

	if (Act=="Edit")
	{


	if (ms.sReceiptState==1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append(">已开</option>\r\n");
	templateBuilder.Append("        <option value=\"2\"\r\n");

	if (Act=="Edit")
	{


	if (ms.sReceiptState==2)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if


	}
	else
	{

	templateBuilder.Append("	selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">未开</option>\r\n");
	templateBuilder.Append("      </select></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td width=\"40%\" valign=\"top\"><table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" class=\"tBox\" id=\"tBoxs\">\r\n");
	templateBuilder.Append("      <thead>\r\n");
	templateBuilder.Append("      <tr class=\"tBar\">\r\n");
	templateBuilder.Append("        <td colspan=\"7\"><input type=\"button\"  name=\"subbutton_add_order\" id=\"subbutton_add_order\" value=\" 单据列表 + \" class=\"B_INPUT\"></td>\r\n");
	templateBuilder.Append("      </tr>\r\n");
	templateBuilder.Append("      <tr class=\"tBar\">\r\n");
	templateBuilder.Append("        <td width=\"10%\">单号</td>\r\n");
	templateBuilder.Append("        <td width=\"15%\">单据类型</td>\r\n");
	templateBuilder.Append("        <td width=\"15%\">客户</td>\r\n");
	templateBuilder.Append("        <td >业务员</td>\r\n");
	templateBuilder.Append("        <td width=\"15%\" align=\"right\">单据时间</td>\r\n");
	templateBuilder.Append("        <td width=\"10%\" align=\"right\">金额</td>\r\n");
	templateBuilder.Append("        <td width=\"10%\" align=\"center\">操作</td>\r\n");
	templateBuilder.Append("      </tr>\r\n");
	templateBuilder.Append("      </thead>\r\n");
	templateBuilder.Append("      <tbody id=\"orderLoop\">\r\n");
	templateBuilder.Append("      </tbody>\r\n");
	templateBuilder.Append("    </table></td>\r\n");
	templateBuilder.Append("    <td width=\"40%\" valign=\"top\" id=\"certificate_box\"><table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" class=\"tBox\" id=\"tBoxs2\">\r\n");
	templateBuilder.Append("      <thead>\r\n");
	templateBuilder.Append("      <tr class=\"tBar\">\r\n");
	templateBuilder.Append("        <td colspan=\"6\"><input type=\"button\" name=\"subbutton_add_certificate\" id=\"subbutton_add_certificate\" value=\" 凭证列表 + \" class=\"B_INPUT\"></td>\r\n");
	templateBuilder.Append("      </tr>\r\n");
	templateBuilder.Append("      <tr class=\"tBar\">\r\n");
	templateBuilder.Append("        <td width=\"10%\">凭证号</td>\r\n");
	templateBuilder.Append("        <td width=\"15%\">凭证类型</td>\r\n");
	templateBuilder.Append("        <td>经办人</td>\r\n");
	templateBuilder.Append("        <td width=\"20%\" align=\"right\">凭证时间</td>\r\n");
	templateBuilder.Append("        <td width=\"15%\" align=\"right\">金额</td>\r\n");
	templateBuilder.Append("        <td width=\"10%\" align=\"center\">操作</td>\r\n");
	templateBuilder.Append("      </tr>\r\n");
	templateBuilder.Append("      </thead>\r\n");
	templateBuilder.Append("      <tbody id=\"certificateLoop\">\r\n");
	templateBuilder.Append("      </tbody>\r\n");
	templateBuilder.Append("    </table></td>\r\n");
	templateBuilder.Append("    <td width=\"20%\" valign=\"top\" id=\"money_box\">\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" class=\"tBox\" id=\"tBoxs3\">\r\n");
	templateBuilder.Append("     <thead>\r\n");
	templateBuilder.Append("      <tr class=\"tBar\">\r\n");
	templateBuilder.Append("        <td colspan=\"3\"><input type=\"button\" name=\"subbutton_add_money\" id=\"subbutton_add_money\" value=\" 金额列表 + \" class=\"B_INPUT\"></td>\r\n");
	templateBuilder.Append("      </tr>\r\n");
	templateBuilder.Append("      <tr class=\"tBar\">\r\n");
	templateBuilder.Append("        <td align=\"right\">金额</td>\r\n");
	templateBuilder.Append("        <td width=\"20%\" align=\"right\">发生时间</td>\r\n");
	templateBuilder.Append("        <td width=\"10%\" align=\"center\">操作</td>\r\n");
	templateBuilder.Append("      </tr>\r\n");
	templateBuilder.Append("      </thead>\r\n");
	templateBuilder.Append("      <tbody id=\"moneyLoop\">\r\n");
	templateBuilder.Append("      </tbody>\r\n");
	templateBuilder.Append("    </table></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div style=\"height:50px\">\r\n");
	templateBuilder.Append("<object id=\"LODOP\" classid=\"clsid:2105C259-1E0C-4534-8141-A753534CB4CA\" width=0 height=0> \r\n");
	templateBuilder.Append("	<embed id=\"LODOP_EM\" type=\"application/x-print-lodop\" width=0 height=0 pluginspage=\"/public/install_lodop.exe\"></embed>\r\n");
	templateBuilder.Append("</object></div>\r\n");
	templateBuilder.Append("<div id=\"footer_tool\">\r\n");
	templateBuilder.Append("<div style=\"width:100%\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("	  <td width=\"25%\"  align=\"left\">合计</td>\r\n");
	templateBuilder.Append("	  <td width=\"15%\"  align=\"right\" id=\"SumOrderMoney\">0.00</td>\r\n");
	templateBuilder.Append("	  <td width=\"40%\" align=\"right\" id=\"SumCertificateMoney\" >0.00</td>\r\n");
	templateBuilder.Append("	  <td width=\"20%\" align=\"right\" id=\"SumPayMoney\" >0.00</td>\r\n");
	templateBuilder.Append("     </tr>\r\n");
	templateBuilder.Append("     <!--\r\n");
	templateBuilder.Append("	<tr >\r\n");
	templateBuilder.Append("	  <td colspan=\"5\" align=\"left\">\r\n");
	templateBuilder.Append("      <div style=\"height:1px\"></div>\r\n");
	templateBuilder.Append("      <table border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"2\">\r\n");
	templateBuilder.Append("	    <tr class=\"tBar\">\r\n");
	templateBuilder.Append("	      <td align=\"left\">上期余额:\r\n");
	templateBuilder.Append("	        <br>	    <input name=\"sUpMoney\" id=\"sUpMoney\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ms.sUpMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" /></td>\r\n");
	templateBuilder.Append("	      <td align=\"left\">本期新增金额:\r\n");
	templateBuilder.Append("	        <br>	    <input name=\"sThisMoney\" id=\"sThisMoney\" type=\"text\" readonly\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ms.sThisMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" /></td>\r\n");
	templateBuilder.Append("<td align=\"left\" >实际对账金额:<br>\r\n");
	templateBuilder.Append("  <input name=\"sMoney\" id=\"sMoney\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("    value=\"" + ms.sMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" /></td>\r\n");

	if (Act!="Add")
	{

	templateBuilder.Append("	  <td align=\"left\" >已到款金额:<br>\r\n");
	templateBuilder.Append("            <input name=\"sToMoney\" id=\"sToMoney\" type=\"text\" readonly \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("    value=\"" + ms.sToMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("    <input type=\"hidden\" id=\"sBalanceMoney\" name=\"sBalanceMoney\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("    value=\"" + ms.sBalanceMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("    />\r\n");
	templateBuilder.Append("    </td>\r\n");

	}	//end if

	templateBuilder.Append("	      </tr>\r\n");

	if (Act!="Add")
	{

	templateBuilder.Append("	    <tr class=\"tBar\">\r\n");
	templateBuilder.Append("	      <td colspan=\"4\" align=\"left\" id=\"SumTxt\">本期应收金额: <span id=\"y_money\">0.00</span> ,本期余额:<span id=\"t_sBalanceMoney\">\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("	        " + ms.sBalanceMoney.ToString().Trim() + "\r\n");

	}
	else
	{

	templateBuilder.Append("            0.00\r\n");

	}	//end if

	templateBuilder.Append(" </span>,差额处理: <span id=\"c_money\">0.00</span> </td>\r\n");
	templateBuilder.Append("	      </tr>\r\n");

	}	//end if

	templateBuilder.Append("	    </table></td>\r\n");
	templateBuilder.Append("	  </tr>\r\n");
	templateBuilder.Append("	-->\r\n");
	templateBuilder.Append("    </table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<input name=\"sUpMoney\" id=\"sUpMoney\" type=\"hidden\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ms.sUpMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("<input name=\"sThisMoney\" id=\"sThisMoney\" type=\"hidden\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ms.sThisMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("<input name=\"sToMoney\" id=\"sToMoney\" type=\"hidden\"  \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("    value=\"" + ms.sToMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("<input type=\"hidden\" id=\"sBalanceMoney\" name=\"sBalanceMoney\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("    value=\"" + ms.sBalanceMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("    />\r\n");
	templateBuilder.Append("<input type=\"hidden\" name=\"MonthlyStatementDataJson\" id=\"MonthlyStatementDataJson\" >\r\n");

	if (Act=="Add")
	{

	templateBuilder.Append("<input type=\"button\" name=\"subbutton_add\" id=\"subbutton_add\" value=\" 保存对账单 \" class=\"B_INPUT\">\r\n");

	}
	else
	{


	if (ms.sState==0)
	{


	if (ms.sSteps<1)
	{

	templateBuilder.Append("<input type=\"button\" name=\"subbutton_d\" id=\"subbutton_d\" value=\" 对账确认 \" class=\"B_INPUT\">-&gt;\r\n");

	}	//end if


	if (ms.sSteps<2)
	{

	templateBuilder.Append("<input type=\"button\" name=\"subbutton_m\" id=\"subbutton_m\" value=\" 完成收付款 \" class=\"B_INPUT\">-&gt;\r\n");

	}	//end if


	if (ms.sSteps<3)
	{

	templateBuilder.Append("<input type=\"button\" name=\"subbutton_e\" id=\"subbutton_e\" value=\" 结账 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("&nbsp;&nbsp;&nbsp;&nbsp;\r\n");

	}	//end if


	if (ms.sSteps<2)
	{

	templateBuilder.Append("<input type=\"button\" name=\"subbutton_edit\" id=\"subbutton_edit\" value=\" 保存更新 \" class=\"B_INPUT\">\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("<input type=\"button\" name=\"subbutton_log\" id=\"subbutton_log\" value=\" 操作记录 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("<input type=\"button\" name=\"subbutton_print\" id=\"subbutton_print\" value=\" 打  印 \" class=\"B_INPUT\">\r\n");

	if (ms.sSteps<=2)
	{

	templateBuilder.Append("<input type=\"button\" name=\"subbutton_invalid\" id=\"subbutton_invalid\" value=\" 作  废 \" class=\"B_INPUT\">\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("</form>        \r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var MonthlyStatementList_do = new TMonthlyStatementList_do();\r\n");
	templateBuilder.Append("MonthlyStatementList_do.DepartmentsJsonStr = '" + DepartmentsJson.ToString() + "';\r\n");
	templateBuilder.Append("MonthlyStatementList_do.SupplierJsonStr = '" + SupplierJson.ToString() + "';\r\n");
	templateBuilder.Append("MonthlyStatementList_do.CustomersJsonStr = '" + CustomersJson.ToString() + "';\r\n");
	templateBuilder.Append("MonthlyStatementList_do.PaymentSystemJsonStr = '" + PaymentSystemJson.ToString() + "';\r\n");
	templateBuilder.Append("MonthlyStatementList_do.PrintPageWidth = '" + config.PrintPageWidth.ToString().Trim() + "';\r\n");
	templateBuilder.Append("MonthlyStatementList_do.UserCode = '" + UserCode.ToString() + "';\r\n");
	templateBuilder.Append("MonthlyStatementList_do.MonthlyStatementDataJsonStr='" + MonthlyStatementDataJsonStr.ToString() + "';\r\n");
	templateBuilder.Append("MonthlyStatementList_do.sType=" + sType.ToString() + ";\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("MonthlyStatementList_do.MonthlyStatementID = " + MonthlyStatementID.ToString() + ";\r\n");
	templateBuilder.Append("MonthlyStatementList_do.IsEdit = true;\r\n");
	templateBuilder.Append("MonthlyStatementList_do.sSteps = " + ms.sSteps.ToString().Trim() + ";\r\n");

	}	//end if

	templateBuilder.Append("MonthlyStatementList_do.ini();	\r\n");
	templateBuilder.Append("function HidBox()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	MonthlyStatementList_do.HidUserBox();\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
