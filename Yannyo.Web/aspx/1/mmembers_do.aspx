<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.mmembers_do" %>
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
	templateBuilder.Append("<script src=\"public/js/jTable.js\" language=\"javascript\"></" + "script>\r\n");


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

	templateBuilder.Append("<script src=\"/public/js/mmembers_do.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");

	if (Act=="DownLoad")
	{


	templateBuilder.Append("            <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\" id=\"tBox\" >\r\n");
	templateBuilder.Append("              <thead >\r\n");
	templateBuilder.Append("              <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                <td width=\"5%\" align=\"center\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"\" onclick=\"javascript:selectCheck(document.getElementById('form1'),this);\"/></td>\r\n");
	templateBuilder.Append("                <td width=\"30%\">会员ID</td>\r\n");
	templateBuilder.Append("                <td>昵称</td>\r\n");
	templateBuilder.Append("                <td width=\"15%\">级别</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              </thead>\r\n");

	if (dList != null)
	{

	templateBuilder.Append("              <tbody id=\"dloop\">\r\n");

	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("              <tr id=\"tr_" + dl["buyer_id"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("                <td align=\"center\" width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" \r\n");
	templateBuilder.Append("                title=\"" + dl["buyer_nick"].ToString().Trim() + "\" \r\n");
	templateBuilder.Append("                id=\"ch_" + dl["buyer_id"].ToString().Trim() + "\" \r\n");
	templateBuilder.Append("                value=\"" + dl["buyer_id"].ToString().Trim() + "\" \r\n");
	templateBuilder.Append("                buyer_nick=\"" + dl["buyer_nick"].ToString().Trim() + "\" \r\n");
	templateBuilder.Append("                trade_amount=\"" + dl["trade_amount"].ToString().Trim() + "\" \r\n");
	templateBuilder.Append("                trade_count=\"" + dl["trade_count"].ToString().Trim() + "\" \r\n");
	templateBuilder.Append("                laste_time=\"" + dl["laste_time"].ToString().Trim() + "\" \r\n");
	templateBuilder.Append("                status=\"" + dl["status"].ToString().Trim() + "\"/></td>\r\n");
	templateBuilder.Append("                <td width=\"30%\">" + dl["buyer_id"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                <td >\r\n");
	templateBuilder.Append("                " + dl["buyer_nick"].ToString().Trim() + "\r\n");

	if (Convert.ToBoolean(dl["is_new"].ToString()) == false)
	{

	templateBuilder.Append("                <span style=\"color:#F00\">[新]</span>\r\n");

	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td width=\"15%\">" + dl["member_grade"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");

	}	//end loop

	templateBuilder.Append("              </tbody>\r\n");

	}	//end if

	templateBuilder.Append("              <tfoot>\r\n");
	templateBuilder.Append("              <tr>\r\n");
	templateBuilder.Append("                <td colspan=\"4\">\r\n");

	if (pageindex>1)
	{

	templateBuilder.Append("                <a href=\"javascript:void(0);\" onclick=\"M_Members_do.PageUp();\"><-上一页</a>\r\n");

	}	//end if

	templateBuilder.Append("                <a href=\"javascript:void(0);\" onclick=\"M_Members_do.PageDown();\">下一页-></a></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </tfoot>\r\n");
	templateBuilder.Append("            </table>\r\n");
	templateBuilder.Append("            <div style=\"height:30px\"></div>\r\n");
	templateBuilder.Append("            <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"center\">\r\n");
	templateBuilder.Append("                    <input type=\"button\" name=\"bt_download\" id=\"bt_download\" value=\" 下载选中 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("                    <input type=\"button\" name=\"bt_cancel\" id=\"bt_cancel\" value=\" 取消 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </div>\r\n");



	}	//end if


	if (Act=="Edit")
	{





	}	//end if

	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var tf = new TableFixed(\"tBox\");\r\n");
	templateBuilder.Append("tf.Clone();\r\n");
	templateBuilder.Append("var M_Members_do = new TM_Members_do();\r\n");
	templateBuilder.Append("M_Members_do.MConfigID = " + M_Config.m_ConfigInfoID.ToString().Trim() + ";\r\n");
	templateBuilder.Append("M_Members_do.PageIndex = " + pageindex.ToString() + ";\r\n");
	templateBuilder.Append("M_Members_do.ActStr = '" + Act.ToString() + "';\r\n");
	templateBuilder.Append("M_Members_do.ini();\r\n");
	templateBuilder.Append("function HidBox()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	M_Members_do.HidUserBox();\r\n");
	templateBuilder.Append("}\r\n");
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
