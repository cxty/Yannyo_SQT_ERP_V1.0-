<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.feessubjectclass_do_move" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:09. 
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

	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/jquery.js\"></" + "script>\r\n");
	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/jquery.cookie.js\"></" + "script>\r\n");
	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/jquery.hotkeys.js\"></" + "script>\r\n");
	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/jquery.jstree.js\"></" + "script>\r\n");
	templateBuilder.Append("        <link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("        <link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/popup.tree.css\"></link>\r\n");
	templateBuilder.Append("        <script type=\"text/javascript\" language=\"javascript\" src=\"/public/js/myFrontPageJs/feessubjectclass_do_move.js\"></" + "script>\r\n");
	templateBuilder.Append("       <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" style=\"background-color:#EDEDED\">\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td align=\"left\" colspan=\"3\" style=\"width:100%;background-color:#cccccc\"><b>当前选择:" + sName.ToString() + "</b>\r\n");
	templateBuilder.Append("    <input type=\"hidden\" id=\"FeesSubjectID\" name=\"FeesSubjectID\" />\r\n");
	templateBuilder.Append("    <input type=\"hidden\" id=\"FeesSubjectName\" name=\"FeesSubjectName\" />\r\n");
	templateBuilder.Append("    <input type=\"hidden\" id=\"sFeeID\" name=\"sFeeID\" value=\"" + sID.ToString() + "\" />\r\n");
	templateBuilder.Append("    <input type=\"hidden\" id=\"lastName\" name=\"lastName\"  value=\"" + sName.ToString() + "\" />\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"3\"></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("  <td style=\"width:48%\">\r\n");
	templateBuilder.Append("  <div align=\"center\" style=\"height:372px;width:100%; overflow-y:scroll;background-color:#ffffff; border:1px solid #cccccc\">\r\n");
	templateBuilder.Append("    <table id=\"edTable\" width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\">\r\n");
	templateBuilder.Append("        <tr class=\"tBar\">\r\n");
	templateBuilder.Append("            <td width=\"1%\" rowspan=\"2\" align=\"center\" style=\"width:10%\"><input type=\"checkbox\" id=\"cheAll\" name=\"cheAll\" style=\"width:25px\"/></td>\r\n");
	templateBuilder.Append("            <td align=\"center\" rowspan=\"2\" style=\"width:25%\">凭证编号</td>\r\n");
	templateBuilder.Append("            <td align=\"center\" colspan=\"2\" style=\"width:35%\">凭证金额</td>\r\n");
	templateBuilder.Append("            <td align=\"center\" rowspan=\"2\" style=\"width:15%\">经办人</td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("        <tr class=\"tBar\">\r\n");
	templateBuilder.Append("            <td align=\"center\">金额</td>\r\n");
	templateBuilder.Append("            <td align=\"center\"><nobr>借贷关系</nobr></td>\r\n");
	templateBuilder.Append("        </tr>\r\n");

	if (cList !=null)
	{


	int cl__loop__id=0;
	foreach(DataRow cl in cList.Rows)
	{
		cl__loop__id++;

	templateBuilder.Append("        <tr class=\"tBar\" style=\"font-weight:normal\">\r\n");
	templateBuilder.Append("            <td align=\"center\" style=\"width:10%\"><input type=\"checkbox\" class=\"checkID\" name=\"checkID\" value=\"" + cl["CertificateDataID"].ToString().Trim() + "\" style=\"width:25px\"/></td>\r\n");
	templateBuilder.Append("            <td align=\"left\" style=\"width:15%\">\r\n");
	templateBuilder.Append("<nobr>\r\n");
	 aspxrewriteurl = Convert.ToDateTime(cl["cDateTime"]).ToString("yyyyMMdd")+"-"+(cl["cNumber"].ToString()).PadLeft(config.CertificateCodeLen,'0');
	
	templateBuilder.Append("" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("</nobr>\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\"><nobr>\r\n");

	if (cl["cdMoney"].ToString() !="0.0000")
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(cl["cdMoney"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("            " + aspxrewriteurl.ToString() + "\r\n");

	}	//end if


	if (cl["cdMoneyB"].ToString() !="0.0000")
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(cl["cdMoneyB"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("            " + aspxrewriteurl.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</nobr>\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"center\">\r\n");

	if (cl["cdMoney"].ToString() !="0.0000")
	{

	templateBuilder.Append("借方\r\n");

	}	//end if


	if (cl["cdMoneyB"].ToString() !="0.0000")
	{

	templateBuilder.Append("贷方\r\n");

	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"center\" style=\"width:15%\">" + cl["sName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("    </table>\r\n");
	templateBuilder.Append("    </div>\r\n");
	templateBuilder.Append("  </td>\r\n");
	templateBuilder.Append("  <td align=\"center\" style=\"width:4%\"><b>→</b></td>\r\n");
	templateBuilder.Append("   <td style=\"width:48%\">\r\n");
	templateBuilder.Append("      <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\">\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td>\r\n");
	templateBuilder.Append("              <div id=\"treeNode\" class=\"treeNode\" style=\"width:100%;height:370px; border:1px solid #cccccc; overflow-y:scroll\"></div>\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("      </table>\r\n");
	templateBuilder.Append("  </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("  <td colspan=\"3\" style=\"background-color:#EDEDED\">注意：将左边科目下凭证号选中后，选中右边科目，将会将左边所选凭证数据移至后边所选科目下！</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("   <div style=\" width:100%; position:fixed;bottom:0px; background-color:#8E8E8E;\">\r\n");
	templateBuilder.Append("    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:100%\">\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"2\" align=\"center\"><input type=\"button\" name=\"bt_ok\" id=\"bt_ok\" value=\" 确定 \" class=\"B_INPUT\">&nbsp; &nbsp;<input type=\"button\" name=\"bt_cancel\" id=\"bt_cancel\" value=\" 取消 \" class=\"B_INPUT\" onClick=\"javascript:window.parent.HidBox();\"></td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("    </table>\r\n");
	templateBuilder.Append("    </div>\r\n");
	templateBuilder.Append("     <div id=\"winAll\">\r\n");
	templateBuilder.Append("          <div id=\"winLoding\"><img alt=\"\" id=\"images\" src=\"/images/loading17.gif\" style=\"visibility:visible\"/>数据移动中...</div>\r\n");
	templateBuilder.Append("         </div>  \r\n");
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" language=\"javascript\">\r\n");
	templateBuilder.Append("    $(document).ready(function () { \r\n");
	templateBuilder.Append("        //科目树\r\n");
	templateBuilder.Append("        $(\"#treeNode\").jstree({   \r\n");
	templateBuilder.Append("            \"json_data\":{\"data\":[{\"data\":\"科目\",\"state\":\"closed\",\"children\":[" + FeesSubjectJson.ToString() + "]}\r\n");
	templateBuilder.Append("					]}, \r\n");
	templateBuilder.Append("	    \"types\" : {  \r\n");
	templateBuilder.Append("			\"valid_children\" : [ \"dt\" ],  \r\n");
	templateBuilder.Append("			\"types\" : {\r\n");
	templateBuilder.Append("				\"dt\" : {\r\n");
	templateBuilder.Append("					\"icon\" : { \r\n");
	templateBuilder.Append("					\"image\" : \"/images/dot.png\" \r\n");
	templateBuilder.Append("				},\r\n");
	templateBuilder.Append("					\"valid_children\" : [ \"default\" ],\r\n");
	templateBuilder.Append("					\"max_depth\" : 2,\r\n");
	templateBuilder.Append("					\"hover_node\" : true,\r\n");
	templateBuilder.Append("					\"open_node\":false,\r\n");
	templateBuilder.Append("					\"select_node\" : true\r\n");
	templateBuilder.Append("				},\r\n");
	templateBuilder.Append("			\"root\":{\r\n");
	templateBuilder.Append("				    \"valid_children\" : [ \"default\" ],\r\n");
	templateBuilder.Append("				    \"hover_node\" : false,\r\n");
	templateBuilder.Append("				    \"select_node\" : function () {return false;}\r\n");
	templateBuilder.Append("				}      \r\n");
	templateBuilder.Append("			}  \r\n");
	templateBuilder.Append("	    }, \r\n");
	templateBuilder.Append("        \"core\" : { \r\n");
	templateBuilder.Append("				\"initially_open\" : [ \"t_0\" ]\r\n");
	templateBuilder.Append("			},	\r\n");
	templateBuilder.Append("		\"ui\":{},\r\n");
	templateBuilder.Append("		\"lang\":{     \r\n");
	templateBuilder.Append("                 loading : \"加载中……\"    \r\n");
	templateBuilder.Append("             },\r\n");
	templateBuilder.Append("	    \"plugins\" : [ \"themes\", \"json_data\", \"ui\", \"crrm\", \"types\", \"hotkeys\",\"cCode\"],\r\n");
	templateBuilder.Append("	}).bind(\"select_node.jstree\", function (e,data) {\r\n");
	templateBuilder.Append("		var sID = data.rslt.obj.attr(\"id\").replace('t_','');\r\n");
	templateBuilder.Append("        var sName = data.rslt.obj.context.text;\r\n");
	templateBuilder.Append("        $(\"#FeesSubjectID\").val(sID);\r\n");
	templateBuilder.Append("        $(\"#FeesSubjectName\").val(sName);\r\n");
	templateBuilder.Append("	    });\r\n");
	templateBuilder.Append("    });\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
