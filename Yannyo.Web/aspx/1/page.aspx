<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.page" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:26. 
	*/

	base.OnLoad(e);
	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
	templateBuilder.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
	templateBuilder.Append("<head>\r\n");
	templateBuilder.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n");
	templateBuilder.Append("<title>模版生成</title>\r\n");
	templateBuilder.Append("</head>\r\n");
	templateBuilder.Append("<body>\r\n");

	if (page_err==0)
	{

	templateBuilder.Append("		<div >\r\n");
	templateBuilder.Append("		<form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");

	if (PageTemplatesList != null)
	{


	int ptl__loop__id=0;
	foreach(DataRow ptl in PageTemplatesList.Rows)
	{
		ptl__loop__id++;

	 aspxrewriteurl = ptl["PageName"].ToString();
	
	templateBuilder.Append("				<span>\r\n");
	templateBuilder.Append("				<nobr>\r\n");
	templateBuilder.Append("				<input name=\"page\" type=\"checkbox\" value=\"" + aspxrewriteurl.ToString() + "\" />" + aspxrewriteurl.ToString() + "\r\n");
	 aspxrewriteurl = ptl["PageExt"].ToString();
	
	templateBuilder.Append("" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("				</nobr>\r\n");
	templateBuilder.Append("				</span>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("		<br/>\r\n");
	templateBuilder.Append("		<input value=\"提交(生成选中模板文件)\" type=\"submit\" /><input type=\"button\" value=\"刷新\" onclick=\"javascript:location=location;\" /><input type=\"button\" value=\"全选\" onclick=\"javascript:cAll();\" />\r\n");
	templateBuilder.Append("		</form>\r\n");
	templateBuilder.Append("		</div>\r\n");

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

	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("function cAll()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("PageForm = document.getElementById('bForm');\r\n");
	templateBuilder.Append("for(var i=0 ;i<PageForm.elements.length;i++){ \r\n");
	templateBuilder.Append("        if(PageForm.elements[i].name=='page'){ \r\n");
	templateBuilder.Append("            PageForm.elements[i].checked = true;\r\n");
	templateBuilder.Append("        }\r\n");
	templateBuilder.Append("    }\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("</" + "script>\r\n");
	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");

	Response.Write(templateBuilder.ToString());
}
</script>
