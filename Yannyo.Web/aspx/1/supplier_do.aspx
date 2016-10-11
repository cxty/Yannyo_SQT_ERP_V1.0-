<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.supplier_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:49. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.mcdropdown.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.bgiframe.js\"></" + "script>\r\n");
	templateBuilder.Append("<link type=\"text/css\" href=\"templates/" + templatepath.ToString() + "/css/jquery.mcdropdown.css\" rel=\"stylesheet\" media=\"all\" />\r\n");

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
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td width=\"20%\" align=\"right\" class=\"ltd\">供应商名称</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sName\" id=\"sName\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"可填写少于50个的中英文字符\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">供应商编号</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sCode\" id=\"sCode\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sCode.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"可填写少于50个的数字或英文字符\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">工商注册号</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sLicense\" id=\"sLicense\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sLicense.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"可填写少于50个的数字或英文字符\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">供应商分类</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input type=\"hidden\" id=\"SupplierClassID\" name=\"SupplierClassID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.SupplierClassID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("                  <input type=\"text\" name=\"category\" id=\"category\" value=\"\" />\r\n");
	templateBuilder.Append("                  <ul id=\"categorymenu\" class=\"mcdropdown_menu\">" + SupplierClass.ToString() + "</ul>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">地址</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sAddress\" id=\"sAddress\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sAddress.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"供应商的具体地址\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">电话</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sTel\" id=\"sTel\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sTel.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"供应商的联系电话\"\r\n");
	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("				  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">联系人</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sLinkMan\" id=\"sLinkMan\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sLinkMan.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"供应商的联系人\"\r\n");
	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("				  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">对账日</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sDoDay\" id=\"sDoDay\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sDoDay.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"对账的日期\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">期初应付款</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sDoDayMoney\" id=\"sDoDayMoney\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sDoDayMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"只能填写数字格式\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("<div style=\"height:30px\"></div>\r\n");
	templateBuilder.Append("            <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"center\">\r\n");
	templateBuilder.Append("                  	<input type=\"button\" id=\"button1\" style=\"margin:5px\" class=\"B_INPUT\" value=\"确定\" onClick=\"javascript:CheckF();\"/>\r\n");
	templateBuilder.Append("                  <input type=\"button\" id=\"button2\" style=\"margin:5px\" class=\"B_INPUT\" value=\"取消\" onClick=\"javascript:window.parent.HidBox();\" />\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </div>\r\n");
	templateBuilder.Append("            </form>\r\n");
	templateBuilder.Append("            <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("$(document).ready(function (){\r\n");
	templateBuilder.Append("	$(\"#category\").mcDropdown(\"#categorymenu\");\r\n");
	templateBuilder.Append("});\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("$(document).ready(function (){\r\n");
	templateBuilder.Append("var dd = $(\"#category\").mcDropdown();\r\n");
	templateBuilder.Append("		dd.setValue(" + si.SupplierClassID.ToString().Trim() + ");\r\n");
	templateBuilder.Append("});\r\n");

	}	//end if

	templateBuilder.Append("			function CheckF()\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				var dd = $(\"#category\").mcDropdown();\r\n");
	templateBuilder.Append("				if(dd!=''){\r\n");
	templateBuilder.Append("					var ddarray = dd.getValue();\r\n");
	templateBuilder.Append("					if(ddarray.length>0)\r\n");
	templateBuilder.Append("					{\r\n");
	templateBuilder.Append("						if(Number(ddarray[0])>0){\r\n");
	templateBuilder.Append("							Sys.getObj('SupplierClassID').value = Number(ddarray[0]);\r\n");
	templateBuilder.Append("							if(Sys.getObj('sName').value != '')\r\n");
	templateBuilder.Append("							{\r\n");
	templateBuilder.Append("								Sys.getObj('bForm').submit();\r\n");
	templateBuilder.Append("							}else\r\n");
	templateBuilder.Append("							{\r\n");
	templateBuilder.Append("								alert('供货商名称不能为空!');	\r\n");
	templateBuilder.Append("							}\r\n");
	templateBuilder.Append("						}else\r\n");
	templateBuilder.Append("						{\r\n");
	templateBuilder.Append("							alert('请选择供货商分类!');	\r\n");
	templateBuilder.Append("						}\r\n");
	templateBuilder.Append("					}else\r\n");
	templateBuilder.Append("					{\r\n");
	templateBuilder.Append("						alert('请选择供货商分类!');	\r\n");
	templateBuilder.Append("					}\r\n");
	templateBuilder.Append("				}else\r\n");
	templateBuilder.Append("				{\r\n");
	templateBuilder.Append("					alert('请选择供货商分类!');	\r\n");
	templateBuilder.Append("				}\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("			</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
