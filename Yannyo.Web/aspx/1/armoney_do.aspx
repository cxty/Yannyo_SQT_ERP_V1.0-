<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.armoney_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:48:49. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/Cxty_XTool.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<script src=\"public/js/bsn.AutoSuggest_2.1.3_comp.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" href=\"public/js/autosuggest_inquisitor.css\" type=\"text/css\" media=\"screen\" charset=\"utf-8\" />\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.autocomplete.js \"></" + "script>\r\n");

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

	templateBuilder.Append("            <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td colspan=\"2\" align=\"left\"><h1>应收信息</h1></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("					<td width=\"20%\" align=\"right\">应收对象</td>\r\n");
	templateBuilder.Append("					<td align=\"left\">\r\n");
	templateBuilder.Append("					<INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ARObjType\" id=\"ARObjType_A\" value=\"0\" onclick=\"javascript:CheckR();\" \r\n");

	if (Act=="Edit")
	{


	if (ai.ARObjType.ToString()=="0")
	{

	templateBuilder.Append("							checked\r\n");

	}	//end if


	}
	else
	{

	templateBuilder.Append("					checked\r\n");

	}	//end if

	templateBuilder.Append("					>门店/客户\r\n");
	templateBuilder.Append("					<INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ARObjType\" id=\"ARObjType_B\" value=\"1\" onclick=\"javascript:CheckR();\" \r\n");

	if (Act=="Edit")
	{


	if (ai.ARObjType.ToString()=="1")
	{

	templateBuilder.Append("							checked\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("					>个人\r\n");
	templateBuilder.Append("					<INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ARObjType\" id=\"ARObjType_C\" value=\"2\" onclick=\"javascript:CheckR();\" \r\n");

	if (Act=="Edit")
	{


	if (ai.ARObjType.ToString()=="2")
	{

	templateBuilder.Append("							checked\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("					>结算系统\r\n");
	templateBuilder.Append("					</td>\r\n");
	templateBuilder.Append("				</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\">开票日期</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\">\r\n");
	templateBuilder.Append("                  <input name=\"aOpenDate\" id=\"aOpenDate\" onclick=\"new Calendar().show(this);\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	 aspxrewriteurl = DateTime.Parse(ai.aOpenDate.ToString()).ToString("yyyy-MM-dd");
	

	}
	else
	{

	 aspxrewriteurl = DateTime.Now.ToString("yyyy-MM-dd");
	

	}	//end if

	templateBuilder.Append("						value=\"" + aspxrewriteurl.ToString() + "\"\r\n");
	templateBuilder.Append("				  >(结算时间点,自动计算新增金额)\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>	\r\n");
	templateBuilder.Append("                <tr id=\"ARObjType_A_box\">\r\n");
	templateBuilder.Append("                  <td width=\"20%\" align=\"right\">门店</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\">\r\n");
	templateBuilder.Append("                  <input name=\"StoresName\" id=\"StoresName\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ai.ARObjName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("				  <INPUT TYPE=\"hidden\" NAME=\"StoresID\" id=\"StoresID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ai.ARObjID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("				  检索可输入*(选中后再双击门店名称选择可自动计算金额)</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr id=\"ARObjType_B_box\">\r\n");
	templateBuilder.Append("                  <td  align=\"right\">人员</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\">\r\n");
	templateBuilder.Append("				  <input name=\"StaffName\" id=\"StaffName\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ai.ARObjName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("				  <INPUT TYPE=\"hidden\" NAME=\"StaffID\" id=\"StaffID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ai.ARObjID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("					检索可输入*</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr id=\"ARObjType_C_box\">\r\n");
	templateBuilder.Append("                  <td  align=\"right\">结算系统</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\">\r\n");
	templateBuilder.Append("				  <input name=\"PaymentSystemName\" id=\"PaymentSystemName\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ai.ARObjName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("				  <INPUT TYPE=\"hidden\" NAME=\"PaymentSystemID\" id=\"PaymentSystemID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ai.ARObjID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("					检索可输入*</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\">新增应收金额</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\">\r\n");
	templateBuilder.Append("				  <input name=\"aAMoney\" id=\"aAMoney\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ai.aAMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("				  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\">实际历史对账金额</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\">\r\n");
	templateBuilder.Append("				  <input name=\"aBMoney\" id=\"aBMoney\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ai.aBMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("				  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\">开票金额</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\">\r\n");
	templateBuilder.Append("                  <input name=\"aOpenMoney\" id=\"aOpenMoney\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ai.aOpenMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\">预计到款日期</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\">\r\n");
	templateBuilder.Append("                  <input name=\"aDate\" id=\"aDate\" onclick=\"new Calendar().show(this);\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	 aspxrewriteurl = DateTime.Parse(ai.aDate.ToString()).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("				  value=\"" + aspxrewriteurl.ToString() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\">实际收款日期</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\">\r\n");
	templateBuilder.Append("                  <input name=\"aActualDate\" id=\"aActualDate\" onclick=\"new Calendar().show(this);\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	 aspxrewriteurl = DateTime.Parse(ai.aActualDate.ToString()).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("				  value=\"" + aspxrewriteurl.ToString() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\">实际收款金额</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\">\r\n");
	templateBuilder.Append("				  <!--onkeydown=\"javascript:AutoValue();\" onkeyup=\"javascript:AutoValue();\" onchange=\"javascript:AutoValue();\"-->\r\n");
	templateBuilder.Append("                  <input name=\"aActualMoney\" id=\"aActualMoney\" type=\"text\"  \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ai.aActualMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\">操作步骤</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\">\r\n");
	templateBuilder.Append("                  <INPUT TYPE=\"checkbox\" NAME=\"aSteps\" value=\"2\" id=\"aSteps\" class=\"B_Check\"\r\n");

	if (ai.aSteps.ToString() == "2")
	{

	templateBuilder.Append("				   checked=\"checked\"\r\n");

	}	//end if

	templateBuilder.Append("				  >已完成\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td colspan=\"2\" align=\"center\">\r\n");
	templateBuilder.Append("				  <INPUT TYPE=\"hidden\" NAME=\"ARObjID\" id=\"ARObjID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ai.ARObjID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" >\r\n");
	templateBuilder.Append("				  <INPUT TYPE=\"hidden\" NAME=\"tValue\" id=\"tValue\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ai.aBMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("				  <input type=\"button\" id=\"button1\" style=\"margin:5px\" class=\"B_INPUT\" value=\"确定\" onClick=\"javascript:CheckF();\"/>\r\n");
	templateBuilder.Append("                  <input type=\"button\" id=\"button2\" style=\"margin:5px\" class=\"B_INPUT\" value=\"取消\" onClick=\"javascript:window.parent.HidBox();\" /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("$().ready(function(){\r\n");
	templateBuilder.Append("	$('#StoresName').autocomplete('Services/CAjax.aspx',{\r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetStoresList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'eDate':function(){return $('#aOpenDate').val()},\r\n");
	templateBuilder.Append("			'StoresName':function(){return $('#StoresName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value,\r\n");
	templateBuilder.Append("						ArMoney: tArray[i].ArMoney,\r\n");
	templateBuilder.Append("						NrMoney: tArray[i].NrMoney    \r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted, row) {\r\n");
	templateBuilder.Append("			$(\"#aAMoney\").val(row.NrMoney);\r\n");
	templateBuilder.Append("			$(\"#aBMoney\").val(row.ArMoney);\r\n");
	templateBuilder.Append("			$('#tValue').val(row.ArMoney);\r\n");
	templateBuilder.Append("			$(\"#StoresID\").val((formatted!=null)?formatted:\"0\");      \r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("	$('#StaffName').autocomplete('Services/CAjax.aspx',{ \r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetStaffList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'StaffName':function(){return $('#StaffName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value    \r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted) {\r\n");
	templateBuilder.Append("			$(\"#StaffID\").val((formatted!=null)?formatted:\"0\");\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("	  $('#PaymentSystemName').autocomplete('Services/CAjax.aspx',{ \r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetPaymentSystemList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'eDate':function(){return $('#aOpenDate').val()},\r\n");
	templateBuilder.Append("			'PaymentSystemName':function(){return $('#PaymentSystemName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value,\r\n");
	templateBuilder.Append("						NrMoney: tArray[i].NrMoney,\r\n");
	templateBuilder.Append("						ArMoney: tArray[i].tArray    \r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted, row) {\r\n");
	templateBuilder.Append("			$(\"#aAMoney\").val(row.NrMoney);\r\n");
	templateBuilder.Append("			$(\"#aBMoney\").val(row.ArMoney);\r\n");
	templateBuilder.Append("			$('#tValue').val(row.ArMoney);\r\n");
	templateBuilder.Append("			$(\"#PaymentSystemID\").val((formatted!=null)?formatted:\"0\");\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("});\r\n");
	templateBuilder.Append("function AutoValue()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	var sObj = document.getElementById('aActualMoney');\r\n");
	templateBuilder.Append("	var tObj = document.getElementById('aBMoney');\r\n");
	templateBuilder.Append("	var ttObj = document.getElementById('aOpenMoney');\r\n");
	templateBuilder.Append("	var vObj = document.getElementById('tValue');\r\n");
	templateBuilder.Append("	if(sObj && tObj && ttObj && vObj)\r\n");
	templateBuilder.Append("	{\r\n");
	templateBuilder.Append("		tObj.value = Number(vObj.value)-Number(sObj.value);\r\n");
	templateBuilder.Append("		ttObj.value = tObj.value;\r\n");
	templateBuilder.Append("	}\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("	function CheckR()\r\n");
	templateBuilder.Append("	{\r\n");
	templateBuilder.Append("		var ARObjType_A = Sys.getObj('ARObjType_A');\r\n");
	templateBuilder.Append("		var ARObjType_B = Sys.getObj('ARObjType_B');\r\n");
	templateBuilder.Append("		var ARObjType_C = Sys.getObj('ARObjType_C');\r\n");
	templateBuilder.Append("		var ARObjType_A_box = Sys.getObj('ARObjType_A_box');\r\n");
	templateBuilder.Append("		var ARObjType_B_box = Sys.getObj('ARObjType_B_box');\r\n");
	templateBuilder.Append("		var ARObjType_C_box = Sys.getObj('ARObjType_C_box');\r\n");
	templateBuilder.Append("		if(ARObjType_A.checked)\r\n");
	templateBuilder.Append("		{\r\n");
	templateBuilder.Append("			ARObjType_A_box.style.display = \"\";\r\n");
	templateBuilder.Append("			ARObjType_B_box.style.display = \"none\";\r\n");
	templateBuilder.Append("			ARObjType_C_box.style.display = \"none\";\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("		else if(ARObjType_B.checked)\r\n");
	templateBuilder.Append("		{\r\n");
	templateBuilder.Append("			ARObjType_A_box.style.display = \"none\";\r\n");
	templateBuilder.Append("			ARObjType_B_box.style.display = \"\";\r\n");
	templateBuilder.Append("			ARObjType_C_box.style.display = \"none\";\r\n");
	templateBuilder.Append("		}else if(ARObjType_C.checked)\r\n");
	templateBuilder.Append("		{\r\n");
	templateBuilder.Append("			ARObjType_A_box.style.display = \"none\";\r\n");
	templateBuilder.Append("			ARObjType_B_box.style.display = \"none\";\r\n");
	templateBuilder.Append("			ARObjType_C_box.style.display = \"\";\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("		ARObjType_A = null;\r\n");
	templateBuilder.Append("		ARObjType_B = null;\r\n");
	templateBuilder.Append("		ARObjType_C = null;\r\n");
	templateBuilder.Append("		ARObjType_A_box = null;\r\n");
	templateBuilder.Append("		ARObjType_B_box = null;\r\n");
	templateBuilder.Append("		ARObjType_C_box = null;\r\n");
	templateBuilder.Append("	}\r\n");
	templateBuilder.Append("	CheckR();\r\n");
	templateBuilder.Append("	function CheckF()\r\n");
	templateBuilder.Append("	{\r\n");
	templateBuilder.Append("		var ARObjType_A = Sys.getObj('ARObjType_A');\r\n");
	templateBuilder.Append("		var ARObjType_B = Sys.getObj('ARObjType_B');\r\n");
	templateBuilder.Append("		var ARObjType_C = Sys.getObj('ARObjType_C');\r\n");
	templateBuilder.Append("		if(ARObjType_A.checked)\r\n");
	templateBuilder.Append("		{\r\n");
	templateBuilder.Append("			if(Sys.getObj('StoresName').value == '')\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				alert('门店名称不能为空!');	\r\n");
	templateBuilder.Append("			}else\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				Sys.getObj('ARObjID').value=Sys.getObj('StoresID').value;\r\n");
	templateBuilder.Append("				Sys.getObj('bForm').submit();\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		}else  if(ARObjType_B.checked){\r\n");
	templateBuilder.Append("			if(Sys.getObj('StaffName').value == '')\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				alert('人员不能为空!');	\r\n");
	templateBuilder.Append("			}else\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				Sys.getObj('ARObjID').value=Sys.getObj('StaffID').value;\r\n");
	templateBuilder.Append("				Sys.getObj('bForm').submit();\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		}else  if(ARObjType_C.checked){\r\n");
	templateBuilder.Append("			if(Sys.getObj('PaymentSystemName').value == '')\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				alert('结算系统不能为空!');	\r\n");
	templateBuilder.Append("			}else\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				Sys.getObj('ARObjID').value=Sys.getObj('PaymentSystemID').value;\r\n");
	templateBuilder.Append("				Sys.getObj('bForm').submit();\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	}\r\n");
	templateBuilder.Append("	</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
