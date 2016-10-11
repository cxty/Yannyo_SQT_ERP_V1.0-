<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.storehousestorageselected" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:46. 
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
	templateBuilder.Append("<script src=\"/public/js/jquery.js\" type=\"text/javascript\" language=\"javascript\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"/public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/Cxty_XTool.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"/public/js/myFrontPageJs/storage.js\" type=\"text/javascript\" language=\"javascript\"></" + "script>\r\n");
	templateBuilder.Append("        <form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("          <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" class=\"tBox\">\r\n");
	templateBuilder.Append("          <tr class=\"tBar\">\r\n");
	templateBuilder.Append("           <td align=\"center\" width=\"20%\">选择门店</td>\r\n");
	templateBuilder.Append("           <td align=\"center\" width=\"30%\">导入时间</td>\r\n");
	templateBuilder.Append("           <td align=\"center\" width=\"15%\">查询</td>\r\n");
	templateBuilder.Append("           <td align=\"center\" width=\"15%\">导出查询结果</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("           <tr class=\"tBar\">\r\n");
	templateBuilder.Append("            <td align=\"center\">\r\n");
	templateBuilder.Append("              <input type=\"text\" name=\"SName\" id=\"SName\" style=\"width:150px\" \r\n");

	if (ispost)
	{

	templateBuilder.Append("value=\"" + sName.ToString() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("                    <input type=\"hidden\"  name=\"StoresID\" id=\"StoresID\" \r\n");

	if (ispost)
	{

	templateBuilder.Append("value=\"" + sId.ToString() + "\"\r\n");

	}	//end if

	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("                    <span style=\"color:Red\">输入*可检索</span>\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"center\">\r\n");
	 aspxrewriteurl = bDate.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("             <input name=\"sDate\" id=\"sDate\" type=\"text\" value=\"" + aspxrewriteurl.ToString() + "\" onclick=\"new Calendar().show(this);\" />至\r\n");
	 aspxrewriteurl = eDate.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("             <input name=\"stDate\" id=\"stDate\" type=\"text\" value=\"" + aspxrewriteurl.ToString() + "\" onclick=\"new Calendar().show(this);\" />\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"center\">\r\n");
	templateBuilder.Append("             <input type=\"button\" id=\"selected_Data\" name=\"selected_Data\" value=\"确定\" onclick=\"javascript:checkF()\" style=\"width:60%;height:23px\" />\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"center\"><input type=\"button\" id=\"export\" name=\"export\" value=\"导出数据\" style=\"width:60%;height:25px\" /></td>\r\n");
	templateBuilder.Append("           </tr>\r\n");
	templateBuilder.Append("          </table>\r\n");
	templateBuilder.Append("    <div id=\"space\"></div>\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" class=\"tBox\" id=\"get_data\">\r\n");
	templateBuilder.Append("        <tr class=\"tBar\">\r\n");
	templateBuilder.Append("        <td width=\"10%;\" align=\"center\">序号</td>\r\n");
	templateBuilder.Append("	    <td width=\"10%\">商品条码</td>\r\n");
	templateBuilder.Append("	    <td width=\"20%\">商品名称</td>\r\n");
	templateBuilder.Append("        <td width=\"10%\" align=\"right\">数量</td>\r\n");
	templateBuilder.Append("        <td width=\"10%\" align=\"right\">金额</td>\r\n");
	templateBuilder.Append("        <td align=\"center\" width=\"20%\">导入时间</td> \r\n");
	templateBuilder.Append("        <td align=\"center\" width=\"20%\">系统时间</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");
	templateBuilder.Append("    <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" class=\"tBox\" id=\"data\">\r\n");
	templateBuilder.Append("        <tbody>\r\n");

	if (pList !=null)
	{


	int pl__loop__id=0;
	foreach(DataRow pl in pList.Rows)
	{
		pl__loop__id++;

	templateBuilder.Append("             <tr>\r\n");
	templateBuilder.Append("             <td align=\"center\" width=\"10%\">" + pl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("              <td width=\"10%\">\r\n");

	if (pl["pBarcode"].ToString() =="")
	{

	templateBuilder.Append("无条码\r\n");

	}	//end if

	templateBuilder.Append("" + pl["pBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("              <td width=\"20%\">" + pl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("              <td align=\"right\" width=\"10%\">" + pl["pRelityStorage"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("              <td align=\"right\" width=\"10%\">" + pl["pMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("              <td align=\"center\" width=\"20%\">\r\n");
	 aspxrewriteurl = DateTime.Parse(pl["pAppendTime"].ToString()).ToShortDateString().ToString();
	
	templateBuilder.Append("					" + aspxrewriteurl.ToString() + " </td>\r\n");
	templateBuilder.Append("              <td align=\"center\" width=\"20%\">\r\n");
	 aspxrewriteurl = DateTime.Parse(pl["pUpdateTime"].ToString()).ToShortDateString().ToString();
	
	templateBuilder.Append("					" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("             </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("        </tbody>\r\n");
	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("        <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("            function checkF() {\r\n");
	templateBuilder.Append("                var sName = $('#SName').val();\r\n");
	templateBuilder.Append("                var bDate = $(\"#sDate\").val();\r\n");
	templateBuilder.Append("                var eDate = $(\"#stDate\").val();\r\n");
	templateBuilder.Append("                if (sName != \"\") {\r\n");
	templateBuilder.Append("                    if (bDate <= eDate) {\r\n");
	templateBuilder.Append("                        $('#form1').submit();\r\n");
	templateBuilder.Append("                    }\r\n");
	templateBuilder.Append("                    else {\r\n");
	templateBuilder.Append("                        jAlert(\"日期选择错误，请重新选择！\", \"友情提示\");\r\n");
	templateBuilder.Append("                    }\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                else {\r\n");
	templateBuilder.Append("                    jAlert(\"门店名称不能为空，请重新输入！\", \"友情提示\");\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("            }\r\n");
	templateBuilder.Append("            //导出数据\r\n");
	templateBuilder.Append("            $(\"#export\").click(function () {\r\n");
	templateBuilder.Append("                var StoresID = $(\"#StoresID\").val();\r\n");
	templateBuilder.Append("                var bDate = $(\"#sDate\").val();\r\n");
	templateBuilder.Append("                var eDate = $(\"#stDate\").val();\r\n");
	templateBuilder.Append("                if (StoresID > 0) {\r\n");
	templateBuilder.Append("                    if (bDate <= eDate) {\r\n");
	templateBuilder.Append("                        var _url = '/storehousestorageselected.aspx?Act=act&StoresID=' + StoresID + '&sDate=' + bDate + '&stDate=' + eDate;\r\n");
	templateBuilder.Append("                        window.open('', \"top\");\r\n");
	templateBuilder.Append("                        setTimeout(window.open(_url, \"top\"), 100);\r\n");
	templateBuilder.Append("                    }\r\n");
	templateBuilder.Append("                    else {\r\n");
	templateBuilder.Append("                        jAlert(\"日期选择错误，请重新选择！\", \"友情提示\");\r\n");
	templateBuilder.Append("                    }\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                else {\r\n");
	templateBuilder.Append("                    jAlert(\"门店名称不能为空，请重新输入！\", \"友情提示\");\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("            });\r\n");
	templateBuilder.Append("        </" + "script>\r\n");
	templateBuilder.Append("      </form>\r\n");

	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
