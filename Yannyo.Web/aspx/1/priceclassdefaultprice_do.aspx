<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.priceclassdefaultprice_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:27. 
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
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("					<td align=\"left\"><h3>商品:" + pi.pName.ToString().Trim() + " (" + pi.pBarcode.ToString().Trim() + ")</h3></td>\r\n");
	templateBuilder.Append("				</tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td style=\"height:200px;\r\n");
	templateBuilder.Append("                  overflow:scroll;\r\n");
	templateBuilder.Append("                  overflow-x:hidden;\">\r\n");

	if (dList!=null)
	{

	templateBuilder.Append("                  <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                    <tr>\r\n");
	templateBuilder.Append("                      <td align=\"center\">价格类型</td>\r\n");
	templateBuilder.Append("                      <td align=\"center\">价格</td>\r\n");
	templateBuilder.Append("                        <td align=\"center\">开单不可更改</td>\r\n");
	templateBuilder.Append("                    </tr>\r\n");

	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("                    <tr>\r\n");
	templateBuilder.Append("                      <td width=\"29%\" align=\"right\">" + dl["pClassName"].ToString().Trim() + ":</td>\r\n");
	templateBuilder.Append("                      <td width=\"60%\" align=\"left\">\r\n");
	templateBuilder.Append("                          <nobr>\r\n");
	templateBuilder.Append("                              <input type=\"hidden\" name=\"PriceClassID_" + dl__loop__id.ToString() + "\" id=\"PriceClassID_" + dl__loop__id.ToString() + "\" value=\"" + dl["PriceClassID"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("                              <input style=\"width:100%;\" type=\"text\" name=\"pPrice_" + dl__loop__id.ToString() + "\" id=\"pPrice_" + dl__loop__id.ToString() + "\" value=\"" + dl["pPrice"].ToString().Trim() + "\" showtitle=\"只能填写数字格式\">\r\n");
	templateBuilder.Append("                              </nobr>\r\n");
	templateBuilder.Append("                      </td>\r\n");
	templateBuilder.Append("                        <td width=\"10%\">\r\n");
	templateBuilder.Append("                            <input style=\"width:30px;\" type=\"checkbox\" name=\"pIsEdit_" + dl__loop__id.ToString() + "\" id=\"pIsEdit_" + dl__loop__id.ToString() + "\" value=\"1\"\r\n");

	if (dl["pIsEdit"].ToString()=="1")
	{

	templateBuilder.Append("                            checked\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                    </tr>\r\n");

	}	//end loop

	templateBuilder.Append("                  </table>\r\n");
	templateBuilder.Append("                  <input type=\"hidden\" name=\"Loop\" id=\"Loop\" value=\"" + dl__loop__id.ToString() + "\">\r\n");
	templateBuilder.Append("                  <input type=\"hidden\" name=\"pPrice\" id=\"pPrice\" value=\"\">\r\n");

	}	//end if

	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"center\"><input type=\"button\" id=\"button1\" style=\"margin:5px\" class=\"B_INPUT\" value=\"确定\" onClick=\"javascript:CheckF();\"/>\r\n");
	templateBuilder.Append("                  <input type=\"button\" id=\"button2\" style=\"margin:5px\" class=\"B_INPUT\" value=\"取消\" onClick=\"javascript:window.parent.HidBox();\" /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("	function CheckF()\r\n");
	templateBuilder.Append("	{\r\n");
	templateBuilder.Append("		var Loop = Number(Sys.getObj('Loop').value);\r\n");
	templateBuilder.Append("		if(Loop>0){\r\n");
	templateBuilder.Append("			var pPriceStr = '';\r\n");
	templateBuilder.Append("			for(var i=1;i<=Loop;i++){\r\n");
	templateBuilder.Append("				if(Sys.getObj('PriceClassID_'+i))\r\n");
	templateBuilder.Append("				{\r\n");
	templateBuilder.Append("					Sys.getObj('pPrice_'+i).value = Number(Sys.getObj('pPrice_'+i).value)?Number(Sys.getObj('pPrice_'+i).value):0;\r\n");
	templateBuilder.Append("					pPriceStr = pPriceStr + Sys.getObj('PriceClassID_' + i).value + ',' + Sys.getObj('pPrice_' + i).value + ',' + (Sys.getObj('pIsEdit_' + i).checked?'1':'0') + ';';\r\n");
	templateBuilder.Append("				}\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("			Sys.getObj('bForm').action = 'PriceClassDefaultPrice_do_Save-" + ProductsID.ToString() + ".aspx';\r\n");
	templateBuilder.Append("			Sys.getObj('pPrice').value=pPriceStr;\r\n");
	templateBuilder.Append("			Sys.getObj('bForm').submit();\r\n");
	templateBuilder.Append("			pPriceStr = null;\r\n");
	templateBuilder.Append("		}else{\r\n");
	templateBuilder.Append("			alert('无效的数据.');	\r\n");
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
