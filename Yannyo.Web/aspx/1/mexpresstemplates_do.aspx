<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.mexpresstemplates_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:14. 
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

	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/m_expresstemplates_do.js\"></" + "script>\r\n");
	templateBuilder.Append("        <form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td width=\"15%\" align=\"right\" class=\"ltd\">系统模板:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\">\r\n");
	templateBuilder.Append("    <select id=\"PublicExpressTemplates\" name=\"PublicExpressTemplates\">\r\n");
	templateBuilder.Append("    <option value=\"-1\">请选择系统模板</option>\r\n");
	templateBuilder.Append("    </select></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"right\" class=\"ltd\">模板名称:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\"><input type=\"text\" name=\"mName\" id=\"mName\" style=\"width:90%;\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ExpressTemplates.mName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("      *</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"right\" class=\"ltd\">快递公司:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\"><input type=\"text\" name=\"mExpName\" id=\"mExpName\" style=\"width:90%;\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ExpressTemplates.mExpName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("      *</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"right\" class=\"ltd\">运单图片:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\"><input type=\"text\" name=\"mPic\" id=\"mPic\" style=\"width:90%;\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ExpressTemplates.mPIC.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("      *</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"right\" class=\"ltd\">运单尺寸:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\">宽:\r\n");
	templateBuilder.Append("      <input type=\"text\" name=\"mWidth\" id=\"mWidth\" style=\"width:50px\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ExpressTemplates.mWidth.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("      *\r\n");
	templateBuilder.Append("      mm 高:\r\n");
	templateBuilder.Append("      <input type=\"text\" name=\"mHeight\" id=\"mHeight\" style=\"width:50px\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ExpressTemplates.mHeight.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("      mm*</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td align=\"right\" class=\"ltd\">模板内容:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\">\r\n");
	templateBuilder.Append("    <textarea name=\"mData\" id=\"mData\" style=\"width:90%;height:200px;\" rows=\"25\">\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("" + ExpressTemplates.mData.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("</textarea>*\r\n");
	templateBuilder.Append("      <div class=\"ExpressTemplatesKey\">\r\n");
	templateBuilder.Append("    <ul>\r\n");
	templateBuilder.Append("    <li>发货单编号:&nbsp;&nbsp;<b><b>{</b></b>OrderID<b><b>}</b></b></li>\r\n");
	templateBuilder.Append("    <li>交易单编号:&nbsp;&nbsp;<b>{</b>MTradeInfoID<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>收货人姓名:&nbsp;&nbsp;<b>{</b>Receiver_name<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>收货人的所在省份:&nbsp;&nbsp;<b>{</b>Receiver_state<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>收货人的所在城市:&nbsp;&nbsp;<b>{</b>Receiver_city<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>收货人的所在地区:&nbsp;&nbsp;<b>{</b>Receiver_district<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>收货人的详细地址:&nbsp;&nbsp;<b>{</b>Receiver_address<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>收货人的邮编:&nbsp;&nbsp;<b>{</b>Receiver_zip<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>收货人的手机号码:&nbsp;&nbsp;<b>{</b>Receiver_mobile<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>收货人的电话号码:&nbsp;&nbsp;<b>{</b>Receiver_phone<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>发件人姓名:&nbsp;&nbsp;<b>{</b>From_name<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>发件公司名称:&nbsp;&nbsp;<b>{</b>From_company<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>发件人所在省份:&nbsp;&nbsp;<b>{</b>From_state<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>发件人所在城市:&nbsp;&nbsp;<b>{</b>From_city<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>发件人所在地区:&nbsp;&nbsp;<b>{</b>From_district<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>发件地址:&nbsp;&nbsp;<b>{</b>From_address<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>发件邮编:&nbsp;&nbsp;<b>{</b>From_zip<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>发件手机:&nbsp;&nbsp;<b>{</b>From_mobile<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>发件电话:&nbsp;&nbsp;<b>{</b>From_phone<b>}</b></li>\r\n");
	templateBuilder.Append("    <li>备注:&nbsp;&nbsp;<b>{</b>MMemo<b>}</b></li>\r\n");
	templateBuilder.Append("    </ul>\r\n");
	templateBuilder.Append("    </div>\r\n");
	templateBuilder.Append("      </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div style=\"height:50px\"></div>\r\n");
	templateBuilder.Append("<div id=\"footer_tool\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("      <td align=\"center\">\r\n");
	templateBuilder.Append("        <input type=\"button\" name=\"bt_ok\" id=\"bt_ok\" value=\" 确定 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("        <input type=\"button\" name=\"bt_cancel\" id=\"bt_cancel\" value=\" 取消 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("      </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var MexpressTemplates_do = new TMexpressTemplates_do();\r\n");
	templateBuilder.Append("MexpressTemplates_do.tExpJson = " + PublicExpressTemplatesJson.ToString() + ";\r\n");
	templateBuilder.Append("MexpressTemplates_do.ini();\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
