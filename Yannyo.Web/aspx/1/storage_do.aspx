<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.storage_do" %>
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/Cxty_XTool.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"/public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.mcdropdown.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.bgiframe.js\"></" + "script>\r\n");
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
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("					<td width=\"20%\" align=\"right\" class=\"ltd\">名称</td>\r\n");
	templateBuilder.Append("					<td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("						<INPUT TYPE=\"text\" NAME=\"sName\" id=\"sName\" showtitle=\"可填写少于50个的中英文字符\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("						/>\r\n");
	templateBuilder.Append("					</td>\r\n");
	templateBuilder.Append("				</tr>\r\n");
	templateBuilder.Append("                	<tr>\r\n");
	templateBuilder.Append("                  <td width=\"20%\" align=\"right\" class=\"ltd\">分类</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input type=\"hidden\" id=\"StorageClassID\" name=\"StorageClassID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.StorageClassID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("                  <input type=\"text\" name=\"category\" id=\"category\" value=\"\" />\r\n");
	templateBuilder.Append("                     <ul id=\"categorymenu\" class=\"mcdropdown_menu\">" + strStorage.ToString() + "</ul>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr id=\"APObjType_A_box\">\r\n");
	templateBuilder.Append("                  <td width=\"20%\" align=\"right\" class=\"ltd\">代码</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sCode\" id=\"sCode\" type=\"text\" showtitle=\"可用数字编号表示\"\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sCode.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("				 </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr id=\"APObjType_B_box\">\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">管理员</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("				  <input name=\"StaffName\" id=\"StaffName\" type=\"text\" showtitle=\"人事管理中的人员名称(*检索)\"\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.ManagerName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("				  <INPUT TYPE=\"hidden\" NAME=\"sManager\" id=\"sManager\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sManager.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">联系电话</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("				  <input name=\"sTel\" id=\"sTel\" type=\"text\" showtitle=\"仓库的联系电话\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sTel.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("				  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">地址</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("				  <input name=\"sAddress\" id=\"sAddress\" type=\"text\" showtitle=\"仓库的具体地址\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sAddress.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("				  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">备注</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("<TEXTAREA NAME=\"sRemake\" id=\"sRemake\" style=\"width:90%;\r\n");
	templateBuilder.Append("height:170px;\">\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("" + si.sRemake.ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("</TEXTAREA>\r\n");
	templateBuilder.Append("				  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">状态:</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"sState\" type=\"checkbox\" value=\"0\" id=\"sState\" class=\"B_Check\"\r\n");

	if (Act=="Edit")
	{


	if (si.sState.ToString() == "0")
	{

	templateBuilder.Append("                                checked=\"checked\"\r\n");

	}	//end if


	}
	else
	{

	templateBuilder.Append("                                checked=\"checked\"\r\n");

	}	//end if

	templateBuilder.Append("                          />\r\n");
	templateBuilder.Append("                            正常</td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
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
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("    $(document).ready(function () {\r\n");
	templateBuilder.Append("        $(\"#category\").mcDropdown(\"#categorymenu\");\r\n");
	templateBuilder.Append("    });\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("    $(document).ready(function (){\r\n");
	templateBuilder.Append("        var dd = $(\"#category\").mcDropdown();\r\n");
	templateBuilder.Append("		dd.setValue(" + si.StorageClassID.ToString().Trim() + ");\r\n");
	templateBuilder.Append("    });\r\n");

	}	//end if

	templateBuilder.Append("$().ready(function(){\r\n");
	templateBuilder.Append("	$('#StaffName').autocomplete('Services/CAjax.aspx',{ \r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetStaffList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'StaffName':function(){return $('#StaffName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value    \r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted) {\r\n");
	templateBuilder.Append("			$(\"#sManager\").val((formatted!=null)?formatted:\"0\");\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("});\r\n");
	templateBuilder.Append("	function CheckF() {\r\n");
	templateBuilder.Append("	    var dd = $(\"#category\").mcDropdown();\r\n");
	templateBuilder.Append("	    var ddarray = dd.getValue();\r\n");
	templateBuilder.Append("	    if (Sys.getObj('sName').value == '') {\r\n");
	templateBuilder.Append("	        jAlert(\"仓库名称不能为空!\", \"友情提示\");\r\n");
	templateBuilder.Append("	    } else if (ddarray[0].toString() =='') {\r\n");
	templateBuilder.Append("	        jAlert(\"请选择仓库分类!\", \"友情提示\");\r\n");
	templateBuilder.Append("        } else if (Sys.getObj('sCode').value == '') {\r\n");
	templateBuilder.Append("	        jAlert(\"仓库编号不能为空!\", \"友情提示\");\r\n");
	templateBuilder.Append("	    } else if (Sys.getObj('sManager').value == '') {\r\n");
	templateBuilder.Append("	        jAlert(\"管理员不能为空!\", \"友情提示\");\r\n");
	templateBuilder.Append("	    } else {\r\n");
	templateBuilder.Append("	        Sys.getObj('StorageClassID').value = Number(ddarray[0]);\r\n");
	templateBuilder.Append("	        Sys.getObj('bForm').submit();\r\n");
	templateBuilder.Append("	    }\r\n");
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
