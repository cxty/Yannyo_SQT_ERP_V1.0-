<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.t" %>
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
	templateBuilder.Append("<html>\r\n");
	templateBuilder.Append("<head>\r\n");
	templateBuilder.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n");
	templateBuilder.Append("<title>MESSAGER���</title>\r\n");
	templateBuilder.Append("<script src=\"jquery-1.3.2.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"jquery.messager.js\"></" + "script>\r\n");
	templateBuilder.Append("<script>\r\n");
	templateBuilder.Append("$(document).ready(function(){\r\n");
	templateBuilder.Append("    $.messager.show(0,'����һ��Jquery Messager��Ϣ���������');\r\n");
	templateBuilder.Append("    $(\"#showMessager300x200\").click(function(){\r\n");
	templateBuilder.Append("        $.messager.lays(300, 200);\r\n");
	templateBuilder.Append("        $.messager.show(0, '300x200����Ϣ');\r\n");
	templateBuilder.Append("    });\r\n");
	templateBuilder.Append("    $(\"#showMessagerFadeIn\").click(function(){\r\n");
	templateBuilder.Append("        $.messager.anim('fade', 2000);\r\n");
	templateBuilder.Append("        $.messager.show(0, 'fadeIn������Ϣ');\r\n");
	templateBuilder.Append("    });\r\n");
	templateBuilder.Append("    $(\"#showMessagerShow\").click(function(){\r\n");
	templateBuilder.Append("        $.messager.anim('show', 1000);\r\n");
	templateBuilder.Append("        $.messager.show(0, 'show������Ϣ');\r\n");
	templateBuilder.Append("    });\r\n");
	templateBuilder.Append("    $(\"#showMessagerDim\").click(function(){\r\n");
	templateBuilder.Append("        $.messager.show('<font color=red>�Զ������</font>', '<font color=green style=\"font-size:14px;font-weight:bold;\">�Զ�������</font>');\r\n");
	templateBuilder.Append("    });\r\n");
	templateBuilder.Append("    $(\"#showMessagerSec\").click(function(){\r\n");
	templateBuilder.Append("        $.messager.show(0, 'һ���ӹر���Ϣ', 1000);\r\n");
	templateBuilder.Append("    });\r\n");
	templateBuilder.Append("});\r\n");
	templateBuilder.Append("</" + "script>\r\n");
	templateBuilder.Append("<style type=\"text/css\">\r\n");
	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("body,td,th { font-size: 12px; }\r\n");
	templateBuilder.Append("body { background-color: #fefefe; }\r\n");
	templateBuilder.Append("p    { width:80%; height:auto; padding:10px; background-color:#D6F097; border:solid 1px #FF9900; color:#333; margin-left:auto; margin-right:auto;}\r\n");
	templateBuilder.Append("input    { background-color:#F5D99E; color:#333; border:solid 1px #993300; font-size:12px;}\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("</style></head>\r\n");
	templateBuilder.Append("<body>\r\n");
	templateBuilder.Append("<h2>JQUEYR PLUGIN - Messager ��Ȩ���� &copy; <a href=\"http://www.corrie.net.cn\" target=\"_blank\">www.corrie.net.cn</a>�Ը�</h2>\r\n");
	templateBuilder.Append("<p><input type=\"button\" id=\"showMessager300x200\" value=\"��ʾһ��300x200����Ϣ\" /></p>\r\n");
	templateBuilder.Append("<p><input type=\"button\" id=\"showMessagerFadeIn\" value=\"��ʾһ��fadeIn������Ϣ\" /></p>\r\n");
	templateBuilder.Append("<p><input type=\"button\" id=\"showMessagerShow\" value=\"��ʾһ��show������Ϣ\" /></p>\r\n");
	templateBuilder.Append("<p><input type=\"button\" id=\"showMessagerDim\" value=\"��ʾ�������ݺͱ�����Ϣ\" /></p>\r\n");
	templateBuilder.Append("<p><input type=\"button\" id=\"showMessagerSec\" value=\"һ���ӹر���Ϣ\" /></p>\r\n");
	templateBuilder.Append("<div>���ۼ��������κ������뷢�ʼ����ǳ����ţ�corrie#sina.com</div>\r\n");
	templateBuilder.Append("<div align=\"center\"><!-- *** Vdoing Code *** -->\r\n");
	templateBuilder.Append("<script type=\"text/javascript\">var wea_sid = 13864;</" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" charset=\"UTF-8\" src=\"http://s.vdoing.com/u/27/13864.js\"></" + "script>\r\n");
	templateBuilder.Append("<noscript><a href=\"http://www.vdoing.com\" title=\"Vdoing StatsX No.13864\"><img src=\"http://simg.vdoing.com/m/13864/x01.gif?noscript\" border=\"0\"></a></noscript>\r\n");
	templateBuilder.Append("<!-- *** End of Vdoing Code *** --> </div>\r\n");
	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");

	Response.Write(templateBuilder.ToString());
}
</script>
