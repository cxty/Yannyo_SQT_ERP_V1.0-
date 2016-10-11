<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.storehousestorage_add_list" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:47. 
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


	templateBuilder.Append("<script src=\"/public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/storehousestorage_add_list.js \"></" + "script>\r\n");
	templateBuilder.Append("    <div class=\"main\" id=\"OrderList\">\r\n");

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

	templateBuilder.Append("<form action=\"\" method=\"post\" name=\"bForm\" id=\"bForm\">   \r\n");
	templateBuilder.Append("<div class=\"toolbar\">\r\n");
	templateBuilder.Append("<table border=\"0\" cellspacing=\"2\" cellpadding=\"0\" style=\"font-size:9pt;width:100%\" >\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"left\" valign=\"middle\" style=\"width:23%;\">门店名称：\r\n");
	templateBuilder.Append("                    <input type=\"text\" name=\"SName\" id=\"SName\" style=\"width:100px\"/>\r\n");
	templateBuilder.Append("                    <INPUT TYPE=\"hidden\" NAME=\"StoresID\" id=\"StoresID\" value=\"" + StoresID.ToString() + "\" />\r\n");
	templateBuilder.Append("                    <span style=\"color:Red\">*可检索</span>\r\n");
	templateBuilder.Append("                 </td>\r\n");
	templateBuilder.Append("    <td align=\"left\" valign=\"middle\" style=\"width:25%;\">日期选择：\r\n");
	templateBuilder.Append("    <input name=\"sDate\" id=\"sDate\" type=\"text\" value=\"" + aspxrewriteurl.ToString() + "\" onclick=\"new Calendar().show(this);\" readonly=\"readonly\"/>\r\n");
	templateBuilder.Append("    </td> \r\n");
	templateBuilder.Append("    <td><b><span style=\"color:Red\">注意：[期初结存]不填写数量，提交表单以后，凡是空项数据全部为“0”</span></b></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<div id=\"space\"></div>\r\n");
	templateBuilder.Append("<div id=\"col_head\" style=\"width:100%\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\"  style=\"font-size:10pt;\">\r\n");
	templateBuilder.Append("<thead >\r\n");
	templateBuilder.Append("          <tr class=\"tBar\" style=\"height:30px\">\r\n");
	templateBuilder.Append("            <td width=\"5%\" align=\"center\" rowspan=\"2\"><b>序号</b></td>\r\n");
	templateBuilder.Append("            <td width=\"10%\" align=\"center\" rowspan=\"2\"><b>商品条码</b></td>\r\n");
	templateBuilder.Append("			<td  align=\"center\" rowspan=\"2\"><b>商品名称</b></td>\r\n");
	templateBuilder.Append("			<td width=\"20%\" align=\"center\" colspan=\"2\"><b>期初结存</b></td>\r\n");
	templateBuilder.Append("            <td width=\"20%\" align=\"center\" colspan=\"2\"><b>产品单价</b></td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("         </thead>\r\n");
	templateBuilder.Append("         </table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\" id=\"tBoxs\" style=\"font-size:10pt;\">\r\n");

	if (dList != null)
	{

	templateBuilder.Append("          <tbody>\r\n");

	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("          <tr style=\"height:30px\">\r\n");
	templateBuilder.Append("            <td align=\"center\" width=\"5%\">" + dl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"left\" width=\"10%\">" + dl["pBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"left\">" + dl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"center\" width=\"20%\">\r\n");
	templateBuilder.Append("             <input type=\"text\" class=\"tpPList\" id=\"pNum_" + dl__loop__id.ToString() + "\" pid=\"" + dl["ProductsID"].ToString().Trim() + "\" pMoney=\"pMoney_" + dl__loop__id.ToString() + "\" name=\"pName_" + dl__loop__id.ToString() + "\" />\r\n");
	templateBuilder.Append("             <input type=\"hidden\" id=\"pName\" name=\"pName\" value=\"" + dl["pName"].ToString().Trim() + "\"/>   \r\n");
	templateBuilder.Append("            </td> \r\n");
	templateBuilder.Append("             <td align=\"center\" width=\"20%\">\r\n");
	templateBuilder.Append("             <input type=\"text\" class=\"tpPList\" id=\"pMoney_\"  pMoney=\"pMoney_" + dl__loop__id.ToString() + "\"/>\r\n");
	templateBuilder.Append("            </td>   \r\n");
	templateBuilder.Append("          </tr>\r\n");

	}	//end loop

	templateBuilder.Append("          </tbody>\r\n");
	templateBuilder.Append("          <tfoot>\r\n");
	templateBuilder.Append("              <tr style=\"height:30px\">\r\n");
	templateBuilder.Append("                <td align=\"center\"><b>合计：</b></td>\r\n");
	templateBuilder.Append("                <td align=\"center\" colspan=\"2\"></td>\r\n");
	templateBuilder.Append("                <td align=\"center\"></td> \r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr><td></td></tr>\r\n");
	templateBuilder.Append("           </tfoot>\r\n");

	}	//end if

	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("        <div style=\" width:100%; position:fixed;bottom:0px; background-color:#8E8E8E;\">\r\n");
	templateBuilder.Append("            <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:100%\">\r\n");
	templateBuilder.Append("                <tr style=\"height:30px\">\r\n");
	templateBuilder.Append("                    <td align=\"center\"></td>\r\n");
	templateBuilder.Append("                    <td align=\"center\"  colspan=\"2\">\r\n");
	templateBuilder.Append("                    <input type=\"hidden\" id=\"reValue\" name=\"reValue\" />\r\n");
	templateBuilder.Append("                        <input type=\"button\" id=\"listLog\" name=\"listLog\" value=\"提交\" style=\"height:25px;width:40px\" />\r\n");
	templateBuilder.Append("                        <input type=\"reset\"  id=\"reset\" name=\"reset\" value=\"重填\"  style=\"height:25px;width:40px\" />\r\n");
	templateBuilder.Append("                    </td>\r\n");
	templateBuilder.Append("                    <td align=\"center\"></td> \r\n");
	templateBuilder.Append("                    </tr>\r\n");
	templateBuilder.Append("                    </table>\r\n");
	templateBuilder.Append("            </div>  \r\n");
	templateBuilder.Append("      <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("          var StoreHouseStorage_add_list = new TStoreHouseStorage_add_list();\r\n");
	templateBuilder.Append("          StoreHouseStorage_add_list.ini();\r\n");
	templateBuilder.Append("          addTableListener(document.getElementById(\"tBoxs\"), 0, 0);\r\n");
	templateBuilder.Append("          window.onscroll = function () {\r\n");
	templateBuilder.Append("              var t = document.body.getBoundingClientRect().top;\r\n");
	templateBuilder.Append("              var head = document.getElementById(\"col_head\");\r\n");
	templateBuilder.Append("              if ((t + document.getElementById(\"space\").offsetTop) < 0) {\r\n");
	templateBuilder.Append("                  head.style.position = \"absolute\";\r\n");
	templateBuilder.Append("                  document.getElementById(\"col_head\").style.top = (-t) + \"px\";\r\n");
	templateBuilder.Append("              }\r\n");
	templateBuilder.Append("              else {\r\n");
	templateBuilder.Append("                  head.style.position = \"\";\r\n");
	templateBuilder.Append("                  //$(\"col_head\").addClass(\"\");\r\n");
	templateBuilder.Append("              }\r\n");
	templateBuilder.Append("          }\r\n");
	templateBuilder.Append("          $().ready(function () {\r\n");
	templateBuilder.Append("              $('#SName').autocomplete('Services/CAjax.aspx', {\r\n");
	templateBuilder.Append("                  width: 200,\r\n");
	templateBuilder.Append("                  scroll: true,\r\n");
	templateBuilder.Append("                  autoFill: true,\r\n");
	templateBuilder.Append("                  scrollHeight: 200,\r\n");
	templateBuilder.Append("                  matchContains: true,\r\n");
	templateBuilder.Append("                  dataType: 'json',\r\n");
	templateBuilder.Append("                  extraParams: {\r\n");
	templateBuilder.Append("                      'do': 'GetStoresInfoList',\r\n");
	templateBuilder.Append("                      'RCode': Math.random(),\r\n");
	templateBuilder.Append("                      'StoresName': function () { return $('#SName').val(); }\r\n");
	templateBuilder.Append("                  },\r\n");
	templateBuilder.Append("                  parse: function (data) {\r\n");
	templateBuilder.Append("                      var rows = [];\r\n");
	templateBuilder.Append("                      var tArray = data.results;\r\n");
	templateBuilder.Append("                      for (var i = 0; i < tArray.length; i++) {\r\n");
	templateBuilder.Append("                          rows[rows.length] = {\r\n");
	templateBuilder.Append("                              data: tArray[i].value + \"(\" + tArray[i].info + \")\",\r\n");
	templateBuilder.Append("                              value: tArray[i].id,\r\n");
	templateBuilder.Append("                              result: tArray[i].value,\r\n");
	templateBuilder.Append("                              sCode: tArray[i].info,\r\n");
	templateBuilder.Append("                              CustomersClassID: tArray[i].CustomersClassID,\r\n");
	templateBuilder.Append("                              CustomersClassName: tArray[i].CustomersClassName,\r\n");
	templateBuilder.Append("                              PriceClassID: tArray[i].PriceClassID,\r\n");
	templateBuilder.Append("                              PriceClassName: tArray[i].PriceClassName,\r\n");
	templateBuilder.Append("                              sType: tArray[i].sType,\r\n");
	templateBuilder.Append("                              sIsFZYH: tArray[i].sIsFZYH,\r\n");
	templateBuilder.Append("                              YHsysName: tArray[i].YHsysName,\r\n");
	templateBuilder.Append("                              sContact: tArray[i].sContact,\r\n");
	templateBuilder.Append("                              sTel: tArray[i].sTel,\r\n");
	templateBuilder.Append("                              sAddress: tArray[i].sAddress,\r\n");
	templateBuilder.Append("                              StaffID: tArray[i].StaffID,\r\n");
	templateBuilder.Append("                              StaffName: tArray[i].StaffName\r\n");
	templateBuilder.Append("                          };\r\n");
	templateBuilder.Append("                      }\r\n");
	templateBuilder.Append("                      return rows;\r\n");
	templateBuilder.Append("                  },\r\n");
	templateBuilder.Append("                  formatItem: function (row, i, max) {\r\n");
	templateBuilder.Append("                      return row;\r\n");
	templateBuilder.Append("                  },\r\n");
	templateBuilder.Append("                  formatMatch: function (row, i, max) {\r\n");
	templateBuilder.Append("                      return row.value;\r\n");
	templateBuilder.Append("                  },\r\n");
	templateBuilder.Append("                  formatResult: function (row) {\r\n");
	templateBuilder.Append("                      return row.value;\r\n");
	templateBuilder.Append("                  }\r\n");
	templateBuilder.Append("              }).result(function (event, data, formatted, row) {\r\n");
	templateBuilder.Append("                  $(\"#StoresID\").val((formatted != null) ? formatted : \"0\");\r\n");
	templateBuilder.Append("              }\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("          });              \r\n");
	templateBuilder.Append("      </" + "script>\r\n");
	templateBuilder.Append("    </form>\r\n");
	templateBuilder.Append("    </div>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
