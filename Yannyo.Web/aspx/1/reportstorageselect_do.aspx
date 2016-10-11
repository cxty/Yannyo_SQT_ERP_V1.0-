<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.reportstorageselect_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:32. 
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


	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"/public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("        <form action=\"\" method=\"get\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("          <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" class=\"tBox\">\r\n");
	templateBuilder.Append("           <tr>\r\n");
	templateBuilder.Append("            <td style=\"width:70%\">\r\n");
	templateBuilder.Append("             选择日期：<label>" + bDate.ToLongDateString().ToString().Trim() + "至" + eDate.ToLongDateString().ToString().Trim() + "</label>\r\n");
	templateBuilder.Append("             <span style=\"color:Red\">注意：下面列表仅显示在日期范围内存在数据的区域！</span>\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td><input type=\"button\" id=\"export\" name=\"export\" onclick=\"javascript:toExcel('get_data',null)\" value=\"导出数据\" style=\"width:30%;height:25px\" /></td>\r\n");
	templateBuilder.Append("           </tr>\r\n");
	templateBuilder.Append("          </table>\r\n");
	templateBuilder.Append("          <div id=\"space\"></div>\r\n");
	templateBuilder.Append("        <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" class=\"tBox\" id=\"get_data\">\r\n");
	templateBuilder.Append("         <thead >\r\n");
	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("            <td width=\"10%\" rowspan=\"2\">地区</td>\r\n");
	templateBuilder.Append("			<td width=\"10%\" rowspan=\"2\">商品条码</td>\r\n");
	templateBuilder.Append("			<td width=\"20%\" rowspan=\"2\">商品名称</td>\r\n");
	templateBuilder.Append("            <td width=\"10%\" align=\"center\" colspan=\"2\">进货</td>\r\n");
	templateBuilder.Append("            <td width=\"10%\" align=\"center\" colspan=\"2\">销售</td>\r\n");
	templateBuilder.Append("            <td width=\"10%\" align=\"center\" colspan=\"2\">库存</td>  \r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("           <td width=\"5%\" align=\"center\">总数量</td>\r\n");
	templateBuilder.Append("           <td width=\"5%\" align=\"center\">总金额</td> \r\n");
	templateBuilder.Append("           <td width=\"5%\" align=\"center\">总数量</td>\r\n");
	templateBuilder.Append("           <td width=\"5%\" align=\"center\">总金额</td>\r\n");
	templateBuilder.Append("           <td width=\"5%\" align=\"center\">总数量</td>\r\n");
	templateBuilder.Append("           <td width=\"5%\" align=\"center\">总金额</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("        </thead>\r\n");
	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("        <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" class=\"tBox\">\r\n");
	templateBuilder.Append("        <tbody>\r\n");

	if (dList !=null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	 pList = getDetailsOfProducts(Convert.ToInt32(dl["RegionID"].ToString().Trim()),getData,bDate,eDate);
	

	if (pList !=null)
	{


	int pl__loop__id=0;
	foreach(DataRow pl in pList.Rows)
	{
		pl__loop__id++;

	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                <td width=\"10%\">" + dl["rName"].ToString().Trim() + "</td> \r\n");
	templateBuilder.Append("			    <td width=\"10%\">\r\n");

	if (getBarcode=="")
	{

	templateBuilder.Append("无条码\r\n");

	}
	else
	{

	templateBuilder.Append("" + getBarcode.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("			    <td width=\"20%\">" + getName.ToString() + "</td>\r\n");
	templateBuilder.Append("			    <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["InQuantity"]),2).ToString();
	
	templateBuilder.Append("                " + aspxrewriteurl.ToString() + "\r\n");
	 SumA = decimal.Round(SumA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("                </td>	\r\n");
	templateBuilder.Append("                <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["oMoney"]),2).ToString();
	
	templateBuilder.Append("                " + aspxrewriteurl.ToString() + "\r\n");
	 SumAA = decimal.Round(SumAA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["OutQuantity"]),2).ToString();
	
	templateBuilder.Append("                " + aspxrewriteurl.ToString() + "\r\n");
	 SumB = decimal.Round(SumB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["SalesPrice"]),2).ToString();
	
	templateBuilder.Append("                " + aspxrewriteurl.ToString() + "\r\n");
	 SumBB = decimal.Round(SumBB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["RelityStorage"]),2).ToString();
	
	templateBuilder.Append("                " + aspxrewriteurl.ToString() + "\r\n");
	 SumC = decimal.Round(SumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["pPrice"]),2).ToString();
	
	templateBuilder.Append("                " + aspxrewriteurl.ToString() + "\r\n");
	 SumCC = decimal.Round(SumCC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");

	}	//end loop


	}	//end if


	}	//end loop


	}	//end if

	templateBuilder.Append("         <tr>\r\n");
	templateBuilder.Append("           <td>合计：</td>\r\n");
	templateBuilder.Append("           <td colspan=\"2\"></td>\r\n");
	templateBuilder.Append("           <td align=\"right\">" + SumA.ToString() + "</td>\r\n");
	templateBuilder.Append("           <td align=\"right\">" + SumAA.ToString() + "</td>\r\n");
	templateBuilder.Append("           <td align=\"right\">" + SumB.ToString() + "</td>\r\n");
	templateBuilder.Append("           <td align=\"right\">" + SumBB.ToString() + "</td>\r\n");
	templateBuilder.Append("           <td align=\"right\">" + SumC.ToString() + "</td>\r\n");
	templateBuilder.Append("           <td align=\"right\">" + SumCC.ToString() + "</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("          </tbody>\r\n");
	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("        <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("            function checkF() {\r\n");
	templateBuilder.Append("                var bTime = $('#sDate').val();\r\n");
	templateBuilder.Append("                var eTime = $('#stDate').val();\r\n");
	templateBuilder.Append("                if (bTime > eTime) {\r\n");
	templateBuilder.Append("                    alert(\"时间选择错误，请重新选择！\");\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                else {\r\n");
	templateBuilder.Append("                    $('#form1').submit();\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("            }\r\n");
	templateBuilder.Append("            addTableListener(document.getElementById(\"tBoxs\"), 0, 0);\r\n");
	templateBuilder.Append("            window.onscroll = function () {\r\n");
	templateBuilder.Append("                var t = document.body.getBoundingClientRect().top;\r\n");
	templateBuilder.Append("                var head = document.getElementById(\"get_data\");\r\n");
	templateBuilder.Append("                if ((t + document.getElementById(\"space\").offsetTop) < 0) {\r\n");
	templateBuilder.Append("                    head.style.position = \"absolute\";\r\n");
	templateBuilder.Append("                    document.getElementById(\"get_data\").style.top = (-t) + \"px\";\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                else {\r\n");
	templateBuilder.Append("                    head.style.position = \"\";\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("            }\r\n");
	templateBuilder.Append("            function toExcel(inTblId, inWindow) {\r\n");
	templateBuilder.Append("                try {\r\n");
	templateBuilder.Append("                    var allStr = \"\";\r\n");
	templateBuilder.Append("                    var curStr = \"\";\r\n");
	templateBuilder.Append("                    if (inTblId != null && inTblId != \"\" && inTblId != \"null\") {\r\n");
	templateBuilder.Append("                        curStr = getTblData(inTblId, inWindow);\r\n");
	templateBuilder.Append("                    }\r\n");
	templateBuilder.Append("                    if (curStr != null) {\r\n");
	templateBuilder.Append("                        allStr += curStr;\r\n");
	templateBuilder.Append("                    }\r\n");
	templateBuilder.Append("                    else {\r\n");
	templateBuilder.Append("                        alert(\"你要导出的表不存在！\");\r\n");
	templateBuilder.Append("                        return;\r\n");
	templateBuilder.Append("                    }\r\n");
	templateBuilder.Append("                    var fileName = getExcelFileName();\r\n");
	templateBuilder.Append("                    doFileExport(fileName, allStr);\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                catch (e) {\r\n");
	templateBuilder.Append("                    alert(\"导出发生异常:\" + e.name + \"->\" + e.description + \"!\");\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("            }\r\n");
	templateBuilder.Append("            function getTblData(inTbl, inWindow) {\r\n");
	templateBuilder.Append("                var rows = 0;\r\n");
	templateBuilder.Append("                var tblDocument = document;\r\n");
	templateBuilder.Append("                if (!!inWindow && inWindow != \"\") {\r\n");
	templateBuilder.Append("                    if (!document.all(inWindow)) {\r\n");
	templateBuilder.Append("                        return null;\r\n");
	templateBuilder.Append("                    }\r\n");
	templateBuilder.Append("                    else {\r\n");
	templateBuilder.Append("                        tblDocument = eval(inWindow).document;\r\n");
	templateBuilder.Append("                    }\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                var curTbl = tblDocument.getElementById(inTbl);\r\n");
	templateBuilder.Append("                var outStr = \"\";\r\n");
	templateBuilder.Append("                if (curTbl != null) {\r\n");
	templateBuilder.Append("                    for (var j = 0; j < curTbl.rows.length; j++) {\r\n");
	templateBuilder.Append("                        for (var i = 0; i < curTbl.rows[j].cells.length; i++) {\r\n");
	templateBuilder.Append("                            if (i == 0 && rows > 0) {\r\n");
	templateBuilder.Append("                                outStr += \" \\t\";\r\n");
	templateBuilder.Append("                                rows -= 1;\r\n");
	templateBuilder.Append("                            }\r\n");
	templateBuilder.Append("                            outStr += curTbl.rows[j].cells[i].innerText + \"\\t\";\r\n");
	templateBuilder.Append("                            if (curTbl.rows[j].cells[i].colSpan > 1) {\r\n");
	templateBuilder.Append("                                for (var k = 0; k < curTbl.rows[j].cells[i].colSpan - 1; k++) {\r\n");
	templateBuilder.Append("                                    outStr += \" \\t\";\r\n");
	templateBuilder.Append("                                }\r\n");
	templateBuilder.Append("                            }\r\n");
	templateBuilder.Append("                            if (i == 0) {\r\n");
	templateBuilder.Append("                                if (rows == 0 && curTbl.rows[j].cells[i].rowSpan > 1) {\r\n");
	templateBuilder.Append("                                    rows = curTbl.rows[j].cells[i].rowSpan - 1;\r\n");
	templateBuilder.Append("                                }\r\n");
	templateBuilder.Append("                            }\r\n");
	templateBuilder.Append("                        }\r\n");
	templateBuilder.Append("                        outStr += \"\\r\\n\";\r\n");
	templateBuilder.Append("                    }\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                else {\r\n");
	templateBuilder.Append("                    outStr = null;\r\n");
	templateBuilder.Append("                    alert(inTbl + \"不存在!\");\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                return outStr;\r\n");
	templateBuilder.Append("            }\r\n");
	templateBuilder.Append("            function getExcelFileName() {\r\n");
	templateBuilder.Append("                var d = new Date();\r\n");
	templateBuilder.Append("                var curYear = d.getYear();\r\n");
	templateBuilder.Append("                var curMonth = \"\" + (d.getMonth() + 1);\r\n");
	templateBuilder.Append("                var curDate = \"\" + d.getDate();\r\n");
	templateBuilder.Append("                var curHour = \"\" + d.getHours();\r\n");
	templateBuilder.Append("                var curMinute = \"\" + d.getMinutes();\r\n");
	templateBuilder.Append("                var curSecond = \"\" + d.getSeconds();\r\n");
	templateBuilder.Append("                if (curMonth.length == 1) {\r\n");
	templateBuilder.Append("                    curMonth = \"0\" + curMonth;\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                if (curDate.length == 1) {\r\n");
	templateBuilder.Append("                    curDate = \"0\" + curDate;\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                if (curHour.length == 1) {\r\n");
	templateBuilder.Append("                    curHour = \"0\" + curHour;\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                if (curMinute.length == 1) {\r\n");
	templateBuilder.Append("                    curMinute = \"0\" + curMinute;\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                if (curSecond.length == 1) {\r\n");
	templateBuilder.Append("                    curSecond = \"0\" + curSecond;\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                var fileName = \"客户进销存数据\" + \"_\" + curYear + \"年\" + curMonth + \"月\" + curDate + \"日\" + \"_\" + curHour + \"点\" + curMinute + \"分\" + curSecond + \"秒\" + \".xls\";\r\n");
	templateBuilder.Append("                return fileName;\r\n");
	templateBuilder.Append("            }\r\n");
	templateBuilder.Append("            function doFileExport(inName, inStr) {\r\n");
	templateBuilder.Append("                var xlsWin = null;\r\n");
	templateBuilder.Append("                if (!!document.all(\"glbHideFrm\")) {\r\n");
	templateBuilder.Append("                    xlsWin = glbHideFrm;\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                else {\r\n");
	templateBuilder.Append("                    var width = 6;\r\n");
	templateBuilder.Append("                    var height = 4;\r\n");
	templateBuilder.Append("                    var openPara = \"left=\" + (window.screen.width / 2 - width / 2)\r\n");
	templateBuilder.Append("               + \",top=\" + (window.screen.height / 2 - height / 2)\r\n");
	templateBuilder.Append("               + \",scrollbars=no,width=\" + width + \",height=\" + height;\r\n");
	templateBuilder.Append("                    xlsWin = window.open(\"\", \"_blank\", openPara);\r\n");
	templateBuilder.Append("                }\r\n");
	templateBuilder.Append("                xlsWin.document.write(inStr);\r\n");
	templateBuilder.Append("                xlsWin.document.close();\r\n");
	templateBuilder.Append("                xlsWin.document.execCommand('Saveas', true, inName);\r\n");
	templateBuilder.Append("                xlsWin.close();\r\n");
	templateBuilder.Append("            }   \r\n");
	templateBuilder.Append("        </" + "script>\r\n");
	templateBuilder.Append("      </form>\r\n");

	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
