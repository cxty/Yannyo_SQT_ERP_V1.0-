<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.bank" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:48:50. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/comm.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/xml.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery-1.3.2.js\"></" + "script>\r\n");

	if (ispost)
	{


	if (page_err==0)
	{


	templateBuilder.Append("<div id=\"mes\">\r\n");
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


	templateBuilder.Append("<div id=\"err\">\r\n");
	templateBuilder.Append("	<h1>出现了" + page_err.ToString() + "个错误</h1>\r\n");
	templateBuilder.Append("	<p class=\"errorback\">" + msgbox_text.ToString() + "</p>\r\n");
	templateBuilder.Append("	<p class=\"errorback\">\r\n");
	templateBuilder.Append("		<script type=\"text/javascript\">\r\n");
	templateBuilder.Append("			if(" + msgbox_showbacklink.ToString() + ")\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				document.write(\"<a href=\\\"" + msgbox_backlink.ToString() + "\\\">返回上一步</a> \");\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		</" + "script>\r\n");
	templateBuilder.Append("	</p>\r\n");
	templateBuilder.Append("</div>\r\n");



	}	//end if


	}
	else
	{

	templateBuilder.Append("<script src=\"public/js/bank.js\" language=\"javascript\" type=\"text/javascript\"></" + "script>\r\n");
	templateBuilder.Append("    <div class=\"main\" id=\"usermanage\">\r\n");

	if (page_err!=0)
	{


	templateBuilder.Append("<div id=\"err\">\r\n");
	templateBuilder.Append("	<h1>出现了" + page_err.ToString() + "个错误</h1>\r\n");
	templateBuilder.Append("	<p class=\"errorback\">" + msgbox_text.ToString() + "</p>\r\n");
	templateBuilder.Append("	<p class=\"errorback\">\r\n");
	templateBuilder.Append("		<script type=\"text/javascript\">\r\n");
	templateBuilder.Append("			if(" + msgbox_showbacklink.ToString() + ")\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				document.write(\"<a href=\\\"" + msgbox_backlink.ToString() + "\\\">返回上一步</a> \");\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		</" + "script>\r\n");
	templateBuilder.Append("	</p>\r\n");
	templateBuilder.Append("</div>\r\n");



	}
	else
	{

	templateBuilder.Append("<div class=\"toolbar\">\r\n");
	templateBuilder.Append("<input type=\"button\" id=\"button1\" style=\"margin:5px\" class=\"B_INPUT\" value=\"删除选中\" onclick=\"javascript:Bank.Delt();\"  />\r\n");
	templateBuilder.Append("<input type=\"button\" id=\"button5\" style=\"margin:5px\" class=\"B_INPUT\" value=\"添加\" onclick=\"javascript:Bank.ShowAddBankBox();\"  />\r\n");
	templateBuilder.Append("<input type=\"button\" id=\"button6\" style=\"margin:5px\" class=\"B_INPUT\" value=\"退出\" onclick=\"javascript:parent.HidBox();\"  />\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<div class=\"datalist\">\r\n");
	templateBuilder.Append("    <form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("        <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\" id=\"tBoxs\">\r\n");
	templateBuilder.Append("          <tr class=\"tBar\">\r\n");
	templateBuilder.Append("            <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"\" onclick=\"javascript:selectCheck(document.getElementById('form1'),this);\"/></td>\r\n");
	templateBuilder.Append("            <td >名称</td>\r\n");
	templateBuilder.Append("            <td width=\"20%\">操作</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("		  <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\">\r\n");

	if (dList != null)
	{

	templateBuilder.Append("		  <div style=\"overflow:scroll;height:200px;overflow-x:hidden;\">\r\n");
	templateBuilder.Append("		  <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\"  >\r\n");

	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("          <tr >\r\n");
	templateBuilder.Append("            <td width=\"2%\">\r\n");
	templateBuilder.Append("            <input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"" + dl["BankID"].ToString().Trim() + "\" />\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("			<td ><a href=\"javascript:void(0);\" onclick=\"javascript:Bank.ShowEditBox(" + dl["BankID"].ToString().Trim() + ");\">" + dl["bName"].ToString().Trim() + "</a></td>\r\n");
	templateBuilder.Append("            <td width=\"20%\">\r\n");
	templateBuilder.Append("			<a href=\"javascript:void(0);\" onclick=\"javascript:Bank.ShowEditBox(" + dl["BankID"].ToString().Trim() + ");\">修改</a> \r\n");
	templateBuilder.Append("			<a href=\"javascript:void(0);\" onclick=\"javascript:Bank.ShowDelBox(" + dl["BankID"].ToString().Trim() + ");\">删除</a> \r\n");
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");

	}	//end loop

	templateBuilder.Append("			</table>\r\n");
	templateBuilder.Append("			</div>\r\n");
	templateBuilder.Append("			<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"3\">\r\n");

	if (PageBarHTML!=null)
	{

	templateBuilder.Append("" + PageBarHTML.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("          </table>\r\n");

	}	//end if

	templateBuilder.Append("		  </td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("    </form>\r\n");
	templateBuilder.Append("</div>\r\n");

	}	//end if

	templateBuilder.Append("    </div>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var Bank = new TBank();\r\n");
	templateBuilder.Append("Bank.ini();\r\n");
	templateBuilder.Append("function HidBox()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	Bank.HidUserBox();\r\n");
	templateBuilder.Append("	location.reload();\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("addTableListener(document.getElementById(\"tBoxs\"),0,0);\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
