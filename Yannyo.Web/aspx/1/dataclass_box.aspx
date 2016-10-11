<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.dataclass_box" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:05. 
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

	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/dataclass_box.js\"></" + "script>\r\n");
	templateBuilder.Append("<div id=\"treeBox\">\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var DataClass_box = new TDataClass_box();\r\n");
	templateBuilder.Append("DataClass_box.ini();\r\n");
	templateBuilder.Append("	$(\"#treeBox\").jstree({   \r\n");

	if (Act=="cObj")
	{

	templateBuilder.Append("	 \"json_data\":{\"data\":[{\"data\":\"客户\",\"state\":\"closed\",\"children\":[" + CustomersJson.ToString() + "]},\r\n");
	templateBuilder.Append("	 						{\"data\":\"供应商\",\"state\":\"closed\",\"children\":[" + SupplierJson.ToString() + "]},\r\n");
	templateBuilder.Append("							{\"data\":\"人员\",\"state\":\"closed\",\"children\":[" + DepartmentsJson.ToString() + "]}\r\n");
	templateBuilder.Append("						]}, \r\n");

	}	//end if


	if (Act=="sObj")
	{

	templateBuilder.Append("	\"json_data\":{\"data\":[{\"data\":\"科目\",\"state\":\"closed\",\"children\":[" + FeesSubjectJson.ToString() + "]}\r\n");
	templateBuilder.Append("						]}, \r\n");

	}	//end if

	templateBuilder.Append("	\"types\" : {  \r\n");
	templateBuilder.Append("			 \"valid_children\" : [ \"dt\" ],  \r\n");
	templateBuilder.Append("			 \"types\" : {\r\n");
	templateBuilder.Append("				 \"dt\" : {\r\n");
	templateBuilder.Append("					 \"icon\" : { \r\n");
	templateBuilder.Append("						\"image\" : \"/images/dot.png\" \r\n");
	templateBuilder.Append("					},\r\n");
	templateBuilder.Append("					 \"valid_children\" : [ \"default\" ],\r\n");
	templateBuilder.Append("					 \"max_depth\" : 2,\r\n");
	templateBuilder.Append("					 \"hover_node\" : true,\r\n");
	templateBuilder.Append("					 \"open_node\":false,\r\n");
	templateBuilder.Append("					 \"select_node\" : true\r\n");
	templateBuilder.Append("				 },\r\n");
	templateBuilder.Append("				\"root\":{\r\n");

	if (ShowType!="All")
	{

	templateBuilder.Append("					\"valid_children\" : [ \"default\" ],\r\n");
	templateBuilder.Append("					\"hover_node\" : false,\r\n");
	templateBuilder.Append("					\"select_node\" : function () {return false;}\r\n");

	}	//end if

	templateBuilder.Append("				 }  \r\n");
	templateBuilder.Append("			 }  \r\n");
	templateBuilder.Append("		}, \r\n");
	templateBuilder.Append("	 \"plugins\" : [ \"themes\", \"json_data\", \"ui\", \"crrm\", \"types\", \"hotkeys\"] \r\n");
	templateBuilder.Append("	}).bind(\"select_node.jstree\", function (e,data) {\r\n");

	if (Act=="cObj")
	{

	templateBuilder.Append("		var sID = data.rslt.obj.attr(\"id\").replace('d_','');\r\n");
	templateBuilder.Append("		var sType = data.rslt.obj.attr(\"otype\");\r\n");
	templateBuilder.Append("		var sName = data.rslt.obj.context.text;\r\n");
	templateBuilder.Append("		var isRoot = data.rslt.obj.attr(\"rel\") == 'root'?1:0;\r\n");

	if (ShowType!="All")
	{

	templateBuilder.Append("		DataClass_box.cObjReCall(sID,sType,sName);\r\n");

	}
	else
	{

	templateBuilder.Append("		DataClass_box.cObjReCall(sID,sType,sName,isRoot);\r\n");

	}	//end if


	}	//end if


	if (Act=="sObj")
	{

	templateBuilder.Append("		var sID = data.rslt.obj.attr(\"id\").replace('t_','');\r\n");
	templateBuilder.Append("		var sName = data.rslt.obj.context.text;\r\n");
	templateBuilder.Append("		DataClass_box.sObjReCall(sID,sName);\r\n");

	}	//end if

	templateBuilder.Append("		//alert(data.rslt.obj.attr(\"id\") + \":\" + data.rslt.obj.attr(\"rel\"));\r\n");
	templateBuilder.Append("	 });\r\n");
	templateBuilder.Append("	//$(\"#treeBox\").jstree('open_all');\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
