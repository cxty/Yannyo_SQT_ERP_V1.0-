<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.stockproduct_print" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:44. 
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

	templateBuilder.Append("        <form action=\"\" method=\"post\" name=\"form1\" id=\"form1\" class=\"print_box\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"5\" cellpadding=\"0\" >\r\n");
	templateBuilder.Append("              <tr class=\"print_box_top\">\r\n");
	templateBuilder.Append("                <td colspan=\"6\" align=\"center\">\r\n");
	 aspxrewriteurl = sDate.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("            " + si.sName.ToString().Trim() + " 库存盘点表</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr class=\"OrderListTool\">\r\n");
	templateBuilder.Append("                <td align=\"right\">仓管员:</td>\r\n");
	templateBuilder.Append("                <td align=\"left\" class=\"text_dl\">" + si.ManagerName.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                <td align=\"right\">联系电话:</td>\r\n");
	templateBuilder.Append("                <td align=\"left\" class=\"text_dl\">" + si.sTel.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                <td align=\"right\">地址:</td>\r\n");
	templateBuilder.Append("                <td align=\"left\" class=\"text_dl\">" + si.sAddress.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr class=\"OrderListTool\">\r\n");
	templateBuilder.Append("                <td align=\"right\">库存点:</td>\r\n");
	templateBuilder.Append("                <td width=\"200\" align=\"left\" class=\"text_dl\">" + aspxrewriteurl.ToString() + " </td>\r\n");
	templateBuilder.Append("                <td align=\"right\">盘点时间:</td>\r\n");
	templateBuilder.Append("                <td width=\"200\" align=\"left\" class=\"text_dl\">&nbsp;</td>\r\n");
	templateBuilder.Append("                <td align=\"right\">盘点人:</td>\r\n");
	templateBuilder.Append("                <td width=\"200\" align=\"left\" class=\"text_dl\">&nbsp;</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr >\r\n");
	templateBuilder.Append("                <td colspan=\"6\" valign=\"top\">\r\n");
	templateBuilder.Append("                <br/>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tBox\" id=\"tBoxs\">\r\n");
	templateBuilder.Append("          <tr >\r\n");
	templateBuilder.Append("			<td width=\"10%\">条码</td>\r\n");
	templateBuilder.Append("			<td >名称</td>\r\n");
	templateBuilder.Append("			<td width=\"10%\">库存</td>\r\n");
	templateBuilder.Append("			<td width=\"10%\">入库未核销</td>\r\n");
	templateBuilder.Append("			<td width=\"10%\">出库未核销</td>\r\n");
	templateBuilder.Append("			<td width=\"10%\">不可用库存</td>\r\n");
	templateBuilder.Append("			<td width=\"10%\">盘点库存</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("			<td align=\"left\">" + dl["pBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			<td align=\"left\">" + dl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			<td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(dl["Beginning"])+Convert.ToDecimal(dl["pStorage"])+Convert.ToDecimal(dl["pStorageIn"])-Convert.ToDecimal(dl["pStorageOut"])),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("			<td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["pStorageIn"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("			<td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["pStorageOut"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("			<td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["StorageBad"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("			<td align=\"right\" class=\"text_dl\">&nbsp;</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	 loop_count = loop_count+1;
	

	}	//end loop


	}	//end if

	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("            </table>\r\n");

	}	//end if

	templateBuilder.Append("</form>\r\n");
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
	templateBuilder.Append("<div style=\"page-break-after: always\"></div>\r\n");

	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
