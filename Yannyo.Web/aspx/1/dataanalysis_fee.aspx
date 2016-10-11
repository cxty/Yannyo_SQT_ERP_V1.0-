<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.dataanalysis_fee" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:04. 
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
	templateBuilder.Append("<link rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/default.css\" type=\"text/css\" media=\"all\"  />\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/index.css\" type=\"text/css\" media=\"all\"  />\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"templates/" + templatepath.ToString() + "/toolbar.css\" />\r\n");
	templateBuilder.Append("" + link.ToString() + "\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/comm.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/swfobject.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/menu.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/dialog.js\"></" + "script>\r\n");
	templateBuilder.Append("<link type=\"text/css\" rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/syntax/!style.css\"/>\r\n");
	templateBuilder.Append("<link type=\"text/css\" rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/!style.css\"/>\r\n");
	templateBuilder.Append("<link type=\"text/css\" rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/syntax/style.css\"/>\r\n");
	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"templates/" + templatepath.ToString() + "/syntax/!script.js\"></" + "script>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.alerts.js\"></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.alerts.css\"></link>\r\n");
	templateBuilder.Append("" + script.ToString() + "\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/public.js\"></" + "script>\r\n");
	templateBuilder.Append("</head>\r\n");


	templateBuilder.Append(" <body>\r\n");

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

	templateBuilder.Append("	<div class=\"datalist\">\r\n");

	if (StoresID>0)
	{


	if (si!=null)
	{

	templateBuilder.Append("		<h3 style=\"font-size:15px;font-weight:bold;\">客户:" + si.sName.ToString().Trim() + "   编号:" + si.sCode.ToString().Trim() + " (" + bDate.ToString() + " <-> " + eDate.ToString() + ")</h3>\r\n");

	}	//end if


	}	//end if


	if (Feeid>0)
	{


	if (fs!=null)
	{

	templateBuilder.Append("		<h3 style=\"font-size:15px;font-weight:bold;\">科目:" + fs.fName.ToString().Trim() + "  (" + bDate.ToString() + " <-> " + eDate.ToString() + ")</h3>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("			<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\" id=\"tBoxs\">\r\n");
	templateBuilder.Append("			  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("				<td width=\"10%\">科目</td>\r\n");
	templateBuilder.Append("				<td width=\"10%\">金额</td>\r\n");
	templateBuilder.Append("				<td width=\"10%\">经办人</td>\r\n");
	templateBuilder.Append("				<td width=\"15%\">备注</td>\r\n");
	templateBuilder.Append("				<td width=\"10%\">发生时间</td>\r\n");
	templateBuilder.Append("				<td width=\"10%\">创建时间</td>\r\n");
	templateBuilder.Append("			  </tr>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("			  <tr>\r\n");
	templateBuilder.Append("				<td>\r\n");
	templateBuilder.Append("				" + dl["FeesSubjectName"].ToString().Trim() + "\r\n");
	templateBuilder.Append("				</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">\r\n");
	templateBuilder.Append("				" + dl["mFees"].ToString().Trim() + "\r\n");
	templateBuilder.Append("				</td>\r\n");
	templateBuilder.Append("				<td>\r\n");
	templateBuilder.Append("				" + dl["StaffName"].ToString().Trim() + "\r\n");
	templateBuilder.Append("				</td>\r\n");
	templateBuilder.Append("				<td>\r\n");
	templateBuilder.Append("				" + dl["mRemark"].ToString().Trim() + "\r\n");
	templateBuilder.Append("				</td>\r\n");
	templateBuilder.Append("				<td align=\"center\">" + dl["mDateTime"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["mAppendTime"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			  </tr>\r\n");

	}	//end loop

	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("            <td>合计:</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + AllSumValue.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td>&nbsp;</td>\r\n");
	templateBuilder.Append("            <td>&nbsp;</td>\r\n");
	templateBuilder.Append("            <td>&nbsp;</td>\r\n");
	templateBuilder.Append("            <td>&nbsp;</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");

	}	//end if

	templateBuilder.Append("			</table>\r\n");
	templateBuilder.Append("	</div>\r\n");
	templateBuilder.Append("	<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("	addTableListener(document.getElementById(\"tBoxs\"),0,0);\r\n");
	templateBuilder.Append("	</" + "script>\r\n");

	}	//end if


	templateBuilder.Append("<div class=\"copyright\">\r\n");
	templateBuilder.Append("Powered by <a href=\"http://www.yannyo.com\">燕游商企通 v1.0</a> , 闽ICP备09018556号<br />\r\n");
	templateBuilder.Append("<p id=\"debuginfo\">\r\n");

	if (config.Debug!=0)
	{

	templateBuilder.Append("	Processed in " + this.Processtime.ToString().Trim() + " second(s)\r\n");

	if (isguestcachepage==1)
	{

	templateBuilder.Append("		(Cached).\r\n");

	}
	else if (querycount>1)
	{

	templateBuilder.Append("		 , " + querycount.ToString() + " queries.\r\n");

	}
	else
	{

	templateBuilder.Append("				, " + querycount.ToString() + " query.\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("</p>\r\n");
	templateBuilder.Append("</div>\r\n");



	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
