<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.bank_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:48:51. 
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

	templateBuilder.Append("        <script type=\"text/javascript\" language=\"javascript\" src=\"/public/js/jquery.js\"></" + "script>\r\n");
	templateBuilder.Append("        <script src=\"/public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("        <link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("         <link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/popup.tree.css\"></link>\r\n");
	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/jquery.autocomplete.js \"></" + "script>         \r\n");
	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/jquery.cookie.js\"></" + "script>\r\n");
	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/jquery.hotkeys.js\"></" + "script>\r\n");
	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/jquery.jstree.js\"></" + "script>\r\n");
	templateBuilder.Append("            <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td width=\"20%\" align=\"right\" class=\"ltd\">科目选择:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                   <input type=\"text\" id=\"FeesSubject\" name=\"FeesSubject\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + ba.CAccountName.ToString().Trim() + "\" disabled=\"disabled\"\r\n");

	}	//end if

	templateBuilder.Append("/><input \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"为只读项\"\r\n");

	}
	else
	{

	templateBuilder.Append("value=\"点击文本框选择科目\"\r\n");

	}	//end if

	templateBuilder.Append("  style=\"color:White; background-color:#FF9900; border:1px solid #FF6600;width:120px\"/>\r\n");
	templateBuilder.Append("                   <input type=\"hidden\" id=\"FeesSubjectID\" name=\"FeesSubjectID\" />\r\n");
	templateBuilder.Append("                   <input type=\"hidden\" id=\"cName\" name=\"cName\" />\r\n");
	templateBuilder.Append("                   <input type=\"hidden\" id=\"act\" name=\"act\" value=\"" + Act.ToString() + "\" />\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td width=\"20%\" align=\"right\" class=\"ltd\">日期选择:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	 aspxrewriteurl = bAppendTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("                   <input name=\"bAppendTime\" id=\"bAppendTime\" type=\"text\" disabled=\"disabled\" value=\"" + aspxrewriteurl.ToString() + "\" onclick=\"new Calendar().show(this);\" /><input value=\"为只读项\"  style=\"color:White; background-color:#FF9900; border:1px solid #FF6600;width:120px\"/>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                 <td width=\"20%\" align=\"right\" class=\"ltd\">期初金额:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	 cMoney = decimal.Round(Convert.ToDecimal(ba.CAccountMoney),2);
	
	templateBuilder.Append("                   <input type=\"text\" id=\"beginMoney\" name=\"beginMoney\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + cMoney.ToString() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"只能填写数字格式\"/>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("           <div style=\"height:30px\"></div>\r\n");
	templateBuilder.Append("            <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"center\">\r\n");
	templateBuilder.Append("                   	<input type=\"button\" id=\"btnSubmit\" style=\"margin:5px;cursor:pointer\" class=\"B_INPUT\" value=\"确定\" />\r\n");
	templateBuilder.Append("                    <input type=\"button\" id=\"button2\" style=\"margin:5px;cursor:pointer\" class=\"B_INPUT\" value=\"取消\" onclick=\"javascript:window.parent.HidBox();\" />\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </div>\r\n");
	templateBuilder.Append("            <!--科目树-->\r\n");
	templateBuilder.Append("            <div id=\"winTreeType\">\r\n");
	templateBuilder.Append("              <div style=\"height:10px\"></div>\r\n");
	templateBuilder.Append("              <div style=\"background-color:#AABE4D; width:400px;height:28px; line-height:28px\"><span style=\"color:White;font-size:larger; padding-left:10px\"><b>科目选择</b></span><span id=\"winClose\">关闭</span></div>\r\n");
	templateBuilder.Append("              <div id=\"treeNode\"></div>\r\n");
	templateBuilder.Append("           </div>\r\n");
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("          <script type=\"text/javascript\" language=\"javascript\">\r\n");
	templateBuilder.Append("              $(document).ready(function () {\r\n");
	templateBuilder.Append("                  //页面加载时候付初值\r\n");
	templateBuilder.Append("                  $(window).load(function(){\r\n");
	templateBuilder.Append("                    if('" + Act.ToString() + "'!='Edit')\r\n");
	templateBuilder.Append("                    {\r\n");
	templateBuilder.Append("                     $(\"#beginMoney\").attr(\"value\",\"0.00\");\r\n");
	templateBuilder.Append("                    }\r\n");
	templateBuilder.Append("                  });\r\n");
	templateBuilder.Append("                 $(\"#beginMoney\").click(function(){\r\n");
	templateBuilder.Append("                      var inputDom=$(\"#beginMoney\").get(0);\r\n");
	templateBuilder.Append("                      inputDom.select();\r\n");
	templateBuilder.Append("                 });\r\n");
	templateBuilder.Append("                 $(\"#btnSubmit\").click(function () {\r\n");
	templateBuilder.Append("                      var getClassName = $(\"#FeesSubject\").val(); //科目名称\r\n");
	templateBuilder.Append("                      var getBeginMoney = $(\"#beginMoney\").val(); //期初金额\r\n");
	templateBuilder.Append("                      var getFeesSubjectID=$(\"#FeesSubjectID\").val();//科目编号\r\n");
	templateBuilder.Append("                      var getrr=$(\"#FeesSubjectID\").val();\r\n");
	templateBuilder.Append("                      var getCheckName=$(\"#cName\").val();\r\n");
	templateBuilder.Append("                      var getbAppendTime=$(\"#bAppendTime\").val();\r\n");
	templateBuilder.Append("                      var myDate=new Date();\r\n");
	templateBuilder.Append("                      var myDateTime=myDate.format(\"yyyy-MM-dd\");\r\n");
	templateBuilder.Append("                          if (getClassName != '') {\r\n");
	templateBuilder.Append("                              if (getBeginMoney != '') {\r\n");
	templateBuilder.Append("                                 if(getFeesSubjectID !=0) {\r\n");
	templateBuilder.Append("                                     if(getbAppendTime > myDateTime)\r\n");
	templateBuilder.Append("                                     {\r\n");
	templateBuilder.Append("                                       jAlert(\"日期选择错误，不能大于当前日期!\", \"友情提示\");\r\n");
	templateBuilder.Append("                                     }\r\n");
	templateBuilder.Append("                                     else{\r\n");
	templateBuilder.Append("                                      jConfirm('确定添加本条数据吗？', '友情提示', function (r) {\r\n");
	templateBuilder.Append("			                                if (r) {\r\n");
	templateBuilder.Append("			                                     $(\"#bForm\").submit();\r\n");
	templateBuilder.Append("			                                }\r\n");
	templateBuilder.Append("			                            });    \r\n");
	templateBuilder.Append("                                     }        \r\n");
	templateBuilder.Append("                                  }\r\n");
	templateBuilder.Append("                                  else{\r\n");
	templateBuilder.Append("                                      if('" + Act.ToString() + "'=='Edit')\r\n");
	templateBuilder.Append("                                      {\r\n");
	templateBuilder.Append("                                           jConfirm('确定修改本条数据吗？', '友情提示', function (r) {\r\n");
	templateBuilder.Append("			                                if (r) {\r\n");
	templateBuilder.Append("			                                     $(\"#bForm\").submit();\r\n");
	templateBuilder.Append("			                                }\r\n");
	templateBuilder.Append("			                            });   \r\n");
	templateBuilder.Append("                                      }\r\n");
	templateBuilder.Append("                                      else{\r\n");
	templateBuilder.Append("                                          jAlert(\"请正确选择科目!\", \"友情提示\");\r\n");
	templateBuilder.Append("                                      }\r\n");
	templateBuilder.Append("                                  } \r\n");
	templateBuilder.Append("                              }\r\n");
	templateBuilder.Append("                              else {\r\n");
	templateBuilder.Append("                                 jAlert(\"请正确设置期初金额!\", \"友情提示\"); \r\n");
	templateBuilder.Append("                              }\r\n");
	templateBuilder.Append("                         }\r\n");
	templateBuilder.Append("						 else\r\n");
	templateBuilder.Append("						 {\r\n");
	templateBuilder.Append("						    jAlert(\"科目名称不能为空，请核对后重新选择!\", \"友情提示\");\r\n");
	templateBuilder.Append("						 }\r\n");
	templateBuilder.Append("                  });\r\n");
	templateBuilder.Append("                  //关闭科目选择\r\n");
	templateBuilder.Append("                  $(\"#winClose\").click(function(){\r\n");
	templateBuilder.Append("                    $(\"#winTreeType\").fadeOut(\"slow\");\r\n");
	templateBuilder.Append("                  });\r\n");
	templateBuilder.Append("                  //弹出科目选择\r\n");
	templateBuilder.Append("                  $(\"#FeesSubject\").click(function(){\r\n");
	templateBuilder.Append("                      $(\"#winTreeType\").fadeIn(\"slow\");\r\n");
	templateBuilder.Append("                  });\r\n");
	templateBuilder.Append("              //科目树\r\n");
	templateBuilder.Append("            $(\"#treeNode\").jstree({   \r\n");
	templateBuilder.Append("               \"json_data\":{\"data\":[{\"data\":\"科目\",\"state\":\"closed\",\"children\":[" + FeesSubjectJson.ToString() + "]}\r\n");
	templateBuilder.Append("						]}, \r\n");
	templateBuilder.Append("	        \"types\" : {  \r\n");
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
	templateBuilder.Append("					\"valid_children\" : [ \"default\" ],\r\n");
	templateBuilder.Append("					\"hover_node\" : false,\r\n");
	templateBuilder.Append("					\"select_node\" : function () {return false;}\r\n");
	templateBuilder.Append("				 }  \r\n");
	templateBuilder.Append("			 }  \r\n");
	templateBuilder.Append("		}, \r\n");
	templateBuilder.Append("	 \"plugins\" : [ \"themes\", \"json_data\", \"ui\", \"crrm\", \"types\", \"hotkeys\",\"cCode\"] \r\n");
	templateBuilder.Append("	}).bind(\"select_node.jstree\", function (e,data) {\r\n");
	templateBuilder.Append("		var sID = data.rslt.obj.attr(\"id\").replace('t_','');\r\n");
	templateBuilder.Append("		var sName = data.rslt.obj.context.text;\r\n");
	templateBuilder.Append("        $(\"#FeesSubject\").val(sName);\r\n");
	templateBuilder.Append("        $(\"#FeesSubjectID\").val(sID);\r\n");
	templateBuilder.Append("        $(\"#winTreeType\").fadeOut(\"slow\");\r\n");
	templateBuilder.Append("	 });\r\n");
	templateBuilder.Append("   });\r\n");
	templateBuilder.Append("       function chooseOne(cb){      \r\n");
	templateBuilder.Append("         var obj = document.getElementsByName(\"cbox\");      \r\n");
	templateBuilder.Append("         for (i=0; i<obj.length; i++){        \r\n");
	templateBuilder.Append("             if (obj[i]!=cb) obj[i].checked = false;      \r\n");
	templateBuilder.Append("             else obj[i].checked = true;      \r\n");
	templateBuilder.Append("         }      \r\n");
	templateBuilder.Append("    } \r\n");
	templateBuilder.Append("          </" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
