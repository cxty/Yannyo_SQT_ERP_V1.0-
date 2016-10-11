<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.mrecallmsg" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:17. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/dialog.js\"></" + "script>\r\n");


	if (ShowMSign == true)
	{

	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("dialog(\"授权[" + M_Config.m_Name.ToString().Trim() + "] " + M_Config.StoresName.ToString().Trim() + "\",'iframe:" + config.Taobao_Api_Authorize.ToString().Trim() + "" + M_Config.m_AppKey.ToString().Trim() + "',550,450,\"iframe\",'parent.HidBox();');\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}
	else
	{


	if (GoodsCatLastTimeDay>5)
	{

	templateBuilder.Append("	<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("		dialog(\"更新商品类目[" + M_Config.m_Name.ToString().Trim() + "] " + M_Config.StoresName.ToString().Trim() + "\",'iframe:/mgoodscat_do-" + M_Config.m_ConfigInfoID.ToString().Trim() + "-download.aspx',500,250,\"iframe\",'parent.HidBox();');\r\n");
	templateBuilder.Append("	</" + "script>\r\n");

	}	//end if


	}	//end if




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

	templateBuilder.Append("<script src=\"/public/js/mrecallmsg.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>备注\r\n");
	templateBuilder.Append("      <input class=\"B_Check\" name=\"flag\" type=\"radio\" id=\"flag_0\" value=\"0\" \r\n");

	if (flag==0)
	{

	templateBuilder.Append("      checked\r\n");

	}	//end if

	templateBuilder.Append("      >\r\n");
	templateBuilder.Append("      <img src=\"/images/op/op_memo_0.png\" width=\"12\" height=\"12\">\r\n");
	templateBuilder.Append("      &nbsp;&nbsp;\r\n");
	templateBuilder.Append("       <input class=\"B_Check\" type=\"radio\" name=\"flag\" id=\"flag_1\" value=\"1\"\r\n");

	if (flag==1)
	{

	templateBuilder.Append("      checked\r\n");

	}	//end if

	templateBuilder.Append("      >\r\n");
	templateBuilder.Append("      <img src=\"/images/op/op_memo_1.png\" width=\"12\" height=\"12\">\r\n");
	templateBuilder.Append("      &nbsp;&nbsp;\r\n");
	templateBuilder.Append("      <input class=\"B_Check\" type=\"radio\" name=\"flag\" id=\"flag_2\" value=\"2\"\r\n");

	if (flag==2)
	{

	templateBuilder.Append("      checked\r\n");

	}	//end if

	templateBuilder.Append("      >\r\n");
	templateBuilder.Append("      <img src=\"/images/op/op_memo_2.png\" width=\"12\" height=\"12\">\r\n");
	templateBuilder.Append("      &nbsp;&nbsp;\r\n");
	templateBuilder.Append("      <input class=\"B_Check\" type=\"radio\" name=\"flag\" id=\"flag_3\" value=\"3\"\r\n");

	if (flag==3)
	{

	templateBuilder.Append("      checked\r\n");

	}	//end if

	templateBuilder.Append("      >\r\n");
	templateBuilder.Append("      <img src=\"/images/op/op_memo_3.png\" width=\"12\" height=\"12\">\r\n");
	templateBuilder.Append("      &nbsp;&nbsp;\r\n");
	templateBuilder.Append("      <input class=\"B_Check\" type=\"radio\" name=\"flag\" id=\"flag_4\" value=\"4\"\r\n");

	if (flag==4)
	{

	templateBuilder.Append("      checked\r\n");

	}	//end if

	templateBuilder.Append("      >\r\n");
	templateBuilder.Append("      <img src=\"/images/op/op_memo_4.png\" width=\"12\" height=\"12\">\r\n");
	templateBuilder.Append("      &nbsp;&nbsp;\r\n");
	templateBuilder.Append("      <input class=\"B_Check\" type=\"radio\" name=\"flag\" id=\"flag_5\" value=\"5\"\r\n");

	if (flag==5)
	{

	templateBuilder.Append("      checked\r\n");

	}	//end if

	templateBuilder.Append("      >\r\n");
	templateBuilder.Append("      <img src=\"/images/op/op_memo_5.png\" width=\"12\" height=\"12\">\r\n");
	templateBuilder.Append("      </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"center\"><textarea name=\"tMsg\" id=\"tMsg\" style=\"width:98%;\r\n");
	templateBuilder.Append("    height:150px\">\r\n");

	if (Act=="TradeMemo")
	{

	templateBuilder.Append("" + mTrade.seller_memo.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("</textarea></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div style=\"height:30px\"></div>\r\n");
	templateBuilder.Append("            <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"center\">\r\n");
	templateBuilder.Append("                    <input type=\"button\" name=\"bt_ok\" id=\"bt_ok\" value=\" 确定 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("                    <input type=\"button\" name=\"bt_cancel\" id=\"bt_cancel\" value=\" 取消 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </div>\r\n");
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var M_ReCallMsg = new TM_ReCallMsg();\r\n");
	templateBuilder.Append("M_ReCallMsg.MConfigID = " + M_Config.m_ConfigInfoID.ToString().Trim() + ";\r\n");
	templateBuilder.Append("M_ReCallMsg.Act = '" + Act.ToString() + "';\r\n");
	templateBuilder.Append("M_ReCallMsg.ini();\r\n");
	templateBuilder.Append("function HidBox()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	M_ReCallMsg.HidUserBox();\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("window.onscroll =function()\r\n");
	templateBuilder.Append("	{	\r\n");
	templateBuilder.Append("		var t = document.body.getBoundingClientRect().top;\r\n");
	templateBuilder.Append("		var head=document.getElementById(\"col_head\");\r\n");
	templateBuilder.Append("		if((t+document.getElementById(\"shiyan\").offsetTop)<0)\r\n");
	templateBuilder.Append("		{\r\n");
	templateBuilder.Append("			head.style.position=\"absolute\";\r\n");
	templateBuilder.Append("			document.getElementById(\"col_head\").style.top = (-t) +\"px\";\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("		else\r\n");
	templateBuilder.Append("		{\r\n");
	templateBuilder.Append("			head.style.position=\"\";\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	}\r\n");
	templateBuilder.Append("addTableListener(document.getElementById(\"tBoxs\"),0,0);\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
