<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.storehousestorage_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:47. 
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
	templateBuilder.Append("<script src=\"/public/js/jquery.js\" type=\"text/javascript\" language=\"javascript\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"/public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"/public/js/myFrontPageJs/storage.js\" type=\"text/javascript\" language=\"javascript\"></" + "script>\r\n");

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

	templateBuilder.Append("            <form action=\"\" method=\"post\" enctype=\"multipart/form-data\" name=\"bForm\" id=\"bForm\">\r\n");
	templateBuilder.Append("              <table border=\"0\" cellspacing=\"2\" cellpadding=\"2\" style=\"width: 440px;font-size:9pt;\">\r\n");
	templateBuilder.Append("                <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                 <td>门店名称：<input type=\"text\" style=\"width:150px\" id=\"SName\" name=\"SName\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.SName.ToString().Trim() + "\" disabled=\"disabled\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"可填写少于50个的数字或中英文字符\"/>\r\n");
	templateBuilder.Append("                 <INPUT TYPE=\"hidden\" NAME=\"StoresID\" id=\"StoresID\" />\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                  <td>仓库名称：<input id=\"stName\"  name=\"stName\" disabled=\"disabled\" type=\"text\" style=\"width:150px\" value=\"默认值\" showtitle=\"可填写少于50个的数字或中英文字符\"/>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr id=\"time\" class=\"tBar\">\r\n");
	 aspxrewriteurl = sDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("                  <td class=\"style1\">时间选择：<input name=\"sDateTime\" id=\"sDateTime\" onclick=\"new Calendar().show(this);\" type=\"text\"  style=\"width:150px;\"  \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.PAppendTime.ToString().Trim() + "\" disabled=\"disabled\"\r\n");

	}
	else
	{

	templateBuilder.Append("value=\"" + aspxrewriteurl.ToString() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                <td align=\"left\">商品编号：<input type=\"text\" style=\"width:150px\" id=\"proCode\" name=\"proCode\"\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("disabled=\"disabled\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"允许为空\"/>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                  </tr>\r\n");
	templateBuilder.Append("                  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                   <td align=\"left\">商品名称：<input type=\"text\" id=\"pName\" name=\"pName\" style=\"width:150px;\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.PName.ToString().Trim() + "\" disabled=\"disabled\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"输入*可检索\" />\r\n");
	templateBuilder.Append("                   <INPUT TYPE=\"hidden\" NAME=\"ProductID\" id=\"ProductID\" >\r\n");
	templateBuilder.Append("                   </td>\r\n");
	templateBuilder.Append("                  </tr>\r\n");
	templateBuilder.Append("                  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                   <td align=\"left\">商品条码：<input type=\"text\" id=\"pBarcode\" name=\"pBarcode\" style=\"width:150px;\"\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("disabled=\"disabled\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"允许为空\"/> \r\n");
	templateBuilder.Append("                  </tr>\r\n");
	templateBuilder.Append("                  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                   <td align=\"left\">商品品牌：<input type=\"text\" id=\"pBrand\" name=\"pBrand\" style=\"width:150px;\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("disabled=\"disabled\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"允许为空\"/>\r\n");
	templateBuilder.Append("                   </td>\r\n");
	templateBuilder.Append("                  </tr> \r\n");
	templateBuilder.Append("                  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                   <td align=\"left\">商品规格：<input type=\"text\" id=\"pStandred\" name=\"pStandred\" style=\"width:150px;\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("disabled=\"disabled\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"允许为空\"/>\r\n");
	templateBuilder.Append("                   </td>\r\n");
	templateBuilder.Append("                  </tr>\r\n");
	templateBuilder.Append("                  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                   <td align=\"left\">商品数量：<input type=\"text\" id=\"pNum\" name=\"pNum\" style=\"width:150px;\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.PNum.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"只能填写数字格式\" />\r\n");
	templateBuilder.Append("                   </td>\r\n");
	templateBuilder.Append("                  </tr>\r\n");
	templateBuilder.Append("                  <tr class=\"tBar\"> \r\n");
	templateBuilder.Append("                  <td align=\"left\">商品单价：<input type=\"text\" id=\"pMoney\" name=\"pMoney\" style=\"width:150px;\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.PMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"只能填写数字格式\" />\r\n");
	templateBuilder.Append("                   </td>\r\n");
	templateBuilder.Append("                  </tr>\r\n");
	templateBuilder.Append("                <tr id=\"submit\" class=\"tBar\">\r\n");
	templateBuilder.Append("                  <td colspan=\"2\" align=\"left\">\r\n");
	templateBuilder.Append("                  <input type=\"hidden\" name=\"text_form\" /> <!--隐藏表单-->\r\n");
	templateBuilder.Append("                  <input type=\"button\" id=\"btn_submit\" style=\"margin-left:100px\" class=\"B_INPUT\" value=\"确定\" onclick=\"javascript:CheckF();\"/>\r\n");
	templateBuilder.Append("                  <input type=\"button\" id=\"button2\" style=\"margin-left:5px\" class=\"B_INPUT\" value=\"取消\" onclick=\"javascript:window.parent.HidBox();\"/></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr id=\"loading\" style=\"display:none;\">\r\n");
	templateBuilder.Append("                  <td colspan=\"2\" align=\"left\"><img src=\"/images/loading.gif\" alt=\"\" />数据处理中,该过程需要10-30分钟,请不要刷新,切换或关闭此页面!</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </form>\r\n");
	templateBuilder.Append("			<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("			    $(\"#btn_submit\").click(function () {\r\n");
	templateBuilder.Append("			        var SName = $(\"#SName\").val();\r\n");
	templateBuilder.Append("			        var pName = $(\"#pName\").val();\r\n");
	templateBuilder.Append("			        var pNum = $(\"#pNum\").val();\r\n");
	templateBuilder.Append("			        var pMoney = $(\"#pMoney\").val();\r\n");
	templateBuilder.Append("			        if (SName != '') {\r\n");
	templateBuilder.Append("			            if (pName != '') {\r\n");
	templateBuilder.Append("			                if (pNum != '') {\r\n");
	templateBuilder.Append("			                    if (pNum != '') {\r\n");
	templateBuilder.Append("			                        $(\"#bForm\").submit();\r\n");
	templateBuilder.Append("			                    }\r\n");
	templateBuilder.Append("			                    else {\r\n");
	templateBuilder.Append("			                        jAlert(\"商品单价不能为空！\", \"友情提示\");\r\n");
	templateBuilder.Append("			                    }\r\n");
	templateBuilder.Append("			                }\r\n");
	templateBuilder.Append("			                else {\r\n");
	templateBuilder.Append("			                    jAlert(\"商品数量不能为空！\", \"友情提示\");\r\n");
	templateBuilder.Append("			                }\r\n");
	templateBuilder.Append("			            }\r\n");
	templateBuilder.Append("			            else {\r\n");
	templateBuilder.Append("			                jAlert(\"商品名称不能为空！\", \"友情提示\");\r\n");
	templateBuilder.Append("			            }\r\n");
	templateBuilder.Append("			        }\r\n");
	templateBuilder.Append("			        else {\r\n");
	templateBuilder.Append("			            jAlert(\"门店名称不能为空！\", \"友情提示\");\r\n");
	templateBuilder.Append("			        }\r\n");
	templateBuilder.Append("			    });\r\n");
	templateBuilder.Append("            </" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	Response.Write(templateBuilder.ToString());
}
</script>
