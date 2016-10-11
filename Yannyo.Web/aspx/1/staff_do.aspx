<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.staff_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:42. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.mcdropdown.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.bgiframe.js\"></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" rev=\"stylesheet\" href=\"/public/js/jquery-ui.css\" />\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery-ui.min.js\"></" + "script>\r\n");
	templateBuilder.Append("<link type=\"text/css\" href=\"templates/" + templatepath.ToString() + "/css/jquery.mcdropdown.css\" rel=\"stylesheet\" media=\"all\" />\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.maskedinput-1.2.2.min.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/dialog.js\"></" + "script>\r\n");

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

	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/staff_do.js\"></" + "script>\r\n");
	templateBuilder.Append("        <script type=\"text/javascript\" src=\"/public/js/jquery.uploadify/jquery.uploadify.js\"></" + "script>\r\n");
	templateBuilder.Append("		<script type=\"text/javascript\" src=\"/public/js/jquery.uploadify/swfobject.js\"></" + "script>\r\n");
	templateBuilder.Append("		<link rel=\"stylesheet\" rev=\"stylesheet\" href=\"/public/js/jquery.uploadify/uploadify.css\" />\r\n");
	templateBuilder.Append("            <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("            <div id=\"tabs\" >\r\n");
	templateBuilder.Append("            	<ul>\r\n");
	templateBuilder.Append("					<li><a href=\"#tabs-1\">&nbsp;基础信息&nbsp;</a></li>\r\n");
	templateBuilder.Append("                    <li><a href=\"#tabs-2\">&nbsp;详细信息&nbsp;</a></li>\r\n");
	templateBuilder.Append("                    <li><a href=\"#tabs-3\">&nbsp;教育背景&nbsp;</a></li>\r\n");
	templateBuilder.Append("                    <li><a href=\"#tabs-4\">&nbsp;工作背景&nbsp;</a></li>\r\n");
	templateBuilder.Append("                    <li><a href=\"#tabs-5\">&nbsp;家庭情况&nbsp;</a></li>\r\n");
	templateBuilder.Append("                    <li><a href=\"#tabs-6\">&nbsp;面试考评&nbsp;</a></li>\r\n");
	templateBuilder.Append("                </ul>\r\n");
	templateBuilder.Append("                <div id=\"tabs-1\">\r\n");
	templateBuilder.Append("                	<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td width=\"20%\" align=\"right\" class=\"ltd\">姓名</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                          <input name=\"sName\" id=\"sName\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"可填写少于50个的中英文字符\"\r\n");
	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">部门</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                          <input type=\"hidden\" id=\"DepartmentsClassID\" name=\"DepartmentsClassID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.DepartmentsClassID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("                          />\r\n");
	templateBuilder.Append("                          <input type=\"text\" name=\"category\" id=\"category\" value=\"\" />\r\n");
	templateBuilder.Append("                          <ul id=\"categorymenu\" class=\"mcdropdown_menu\">" + DepartmentsClass.ToString() + "</ul>\r\n");
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td  align=\"right\" class=\"ltd\">性别</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                          <INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"sSex\" value=\"男\"\r\n");

	if (Act=="Edit")
	{


	if (si.sSex == "男")
	{

	templateBuilder.Append("                                checked\r\n");

	}	//end if


	}
	else
	{

	templateBuilder.Append("                                checked\r\n");

	}	//end if

	templateBuilder.Append("                          >男\r\n");
	templateBuilder.Append("                          <INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"sSex\" value=\"女\"\r\n");

	if (Act=="Edit")
	{


	if (si.sSex == "女")
	{

	templateBuilder.Append("                            checked\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          >女\r\n");
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td width=\"20%\" align=\"right\" class=\"ltd\">身份证</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                          <input name=\"sCarID\" id=\"sCarID\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sCarID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"请填写有效身份证信息\"\r\n");
	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td width=\"20%\" align=\"right\" class=\"ltd\">电话</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                          <input name=\"sTel\" id=\"sTel\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sTel.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("   showtitle=\"请填写有效联系电话\"\r\n");
	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("                          <td width=\"20%\" align=\"right\" class=\"ltd\">Email</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                          <input name=\"sEmail\" id=\"sEmail\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sEmail.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"请填写有效邮箱地址\"\r\n");
	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                      </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td  align=\"right\" class=\"ltd\">类型</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                          <select name=\"sType\" id=\"sType\">\r\n");
	templateBuilder.Append("                            <option value=\"0\" \r\n");

	if (Act=="Edit")
	{


	if (si.sType.ToString() == "0")
	{

	templateBuilder.Append("                            selected\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                            >公司</option>\r\n");
	templateBuilder.Append("                            <option value=\"1\"\r\n");

	if (Act=="Edit")
	{


	if (si.sType.ToString() == "1")
	{

	templateBuilder.Append("                            selected\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          >业务员</option>\r\n");
	templateBuilder.Append("                            <option value=\"2\"\r\n");

	if (Act=="Edit")
	{


	if (si.sType.ToString() == "2")
	{

	templateBuilder.Append("                            selected\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                            >促销员</option>\r\n");
	templateBuilder.Append("                            <option value=\"3\"\r\n");

	if (Act=="Edit")
	{


	if (si.sType.ToString() == "3")
	{

	templateBuilder.Append("                            selected\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                            >其他</option>\r\n");
	templateBuilder.Append("                          </select>\r\n");
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
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
	templateBuilder.Append("                  </table>\r\n");
	templateBuilder.Append("                </div>\r\n");
	templateBuilder.Append("                <div id=\"tabs-2\">\r\n");
	templateBuilder.Append("                <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td width=\"20%\" align=\"right\" class=\"ltd\">出生日期</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                          <input name=\"sBirthDay\" id=\"sBirthDay\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("                          value=\"" + sd.sBirthDay.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                          <td colspan=\"4\" rowspan=\"7\" align=\"center\" class=\"rtd\">\r\n");
	templateBuilder.Append("                          <input type=\"hidden\" id=\"sPhotos\" name=\"sPhotos\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sPhotos.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append(" />\r\n");
	templateBuilder.Append("                          <div id=\"sPic\">\r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{


	if (sd.sPhotos!="")
	{

	templateBuilder.Append("						  <img src=\"" + sd.sPhotos.ToString().Trim() + "\" style=\"width:98%\" onClick=\"javascript:window.open('" + sd.sPhotos.ToString().Trim() + "');\"/>\r\n");

	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("                          </div>\r\n");
	templateBuilder.Append("                          <div id=\"sPic_bt\">\r\n");
	templateBuilder.Append("                            <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                              <tr>\r\n");
	templateBuilder.Append("                                <td align=\"right\" valign=\"middle\"><input type=\"button\" id=\"bt_pic_camera\" style=\"margin:5px\" class=\"B_INPUT\" value=\"摄像头\" /></td>\r\n");
	templateBuilder.Append("                                <td align=\"left\" valign=\"middle\"><input id=\"file_upload\" type=\"file\" name=\"PicData\" /></td>\r\n");
	templateBuilder.Append("                              </tr>\r\n");
	templateBuilder.Append("                            </table>\r\n");
	templateBuilder.Append("                          </div>\r\n");
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">政治面貌</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"sPolitical\" id=\"sPolitical\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sPolitical.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">籍贯</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"sBirthplace\" id=\"sBirthplace\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sBirthplace.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">出生地</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"sHometown\" id=\"sHometown\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sHometown.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">最高学历</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"sEducation\" id=\"sEducation\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sEducation.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">专业</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"sProfessional\" id=\"sProfessional\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sProfessional.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td width=\"20%\" align=\"right\" class=\"ltd\">身体状况</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"sHealth\" id=\"sHealth\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sHealth.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">身高</td>\r\n");
	templateBuilder.Append("                          <td width=\"10%\" align=\"left\" class=\"rtd\"><input name=\"sHeight\" id=\"sHeight\" type=\"text\" \r\n");

	if (Act=="edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sHeight.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          />\r\n");
	templateBuilder.Append("                          cm</td>\r\n");
	templateBuilder.Append("                          <td width=\"20%\" align=\"right\" class=\"ltd\">体重</td>\r\n");
	templateBuilder.Append("                          <td colspan=\"3\" align=\"left\" class=\"rtd\"><input name=\"sWeight\" id=\"sWeight\" type=\"text\" \r\n");

	if (Act=="edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sWeight.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          />\r\n");
	templateBuilder.Append("                          kg</td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">技能特长</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"sSpecialty\" id=\"sSpecialty\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sSpecialty.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">兴趣爱好</td>\r\n");
	templateBuilder.Append("                          <td colspan=\"3\" align=\"left\" class=\"rtd\"><input name=\"sHobbies\" id=\"sHobbies\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sHobbies.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">联系地址</td>\r\n");
	templateBuilder.Append("                          <td colspan=\"5\" align=\"left\" class=\"rtd\"><input name=\"sContactAddress\" id=\"sContactAddress\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sContactAddress.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">就业情况</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"sEmployment\" id=\"sEmployment\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sEmployment.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">可报道时间</td>\r\n");
	templateBuilder.Append("                          <td colspan=\"3\" align=\"left\" class=\"rtd\"><input name=\"sCanBeDate\" id=\"sCanBeDate\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("                          value=\"" + sd.sCanBeDate.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">期望待遇</td>\r\n");
	templateBuilder.Append("                          <td colspan=\"5\" align=\"left\" class=\"rtd\"><input name=\"sTreatment\" id=\"sTreatment\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sd!=null)
	{

	templateBuilder.Append("value=\"" + sd.sTreatment.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                </table>\r\n");
	templateBuilder.Append("                </div>\r\n");
	templateBuilder.Append("                <div id=\"tabs-3\">\r\n");
	templateBuilder.Append("                <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("                <tbody>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"left\" >\r\n");
	templateBuilder.Append("                              <ul id=\"EduDataList\">\r\n");
	templateBuilder.Append("                              </ul>\r\n");
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                 </tbody>\r\n");
	templateBuilder.Append("                 <tfoot>\r\n");
	templateBuilder.Append("                 	<tr>\r\n");
	templateBuilder.Append("                          <td align=\"center\"><a href=\"javascript:void(0);\" id=\"EduData_bt\">添加</a></td>\r\n");
	templateBuilder.Append("                   </tr>\r\n");
	templateBuilder.Append("                 </tfoot>\r\n");
	templateBuilder.Append("                 </table>\r\n");
	templateBuilder.Append("                </div>\r\n");
	templateBuilder.Append("                <div id=\"tabs-4\">\r\n");
	templateBuilder.Append("                  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("                    <tbody>\r\n");
	templateBuilder.Append("                      <tr>\r\n");
	templateBuilder.Append("                        <td align=\"left\" >\r\n");
	templateBuilder.Append("                        <ul id=\"WorkDataList\">\r\n");
	templateBuilder.Append("                        </ul>\r\n");
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                      </tr>\r\n");
	templateBuilder.Append("                    </tbody>\r\n");
	templateBuilder.Append("                    <tfoot>\r\n");
	templateBuilder.Append("                      <tr>\r\n");
	templateBuilder.Append("                        <td align=\"center\"><a href=\"javascript:void(0);\" id=\"WorkData_bt\">添加</a></td>\r\n");
	templateBuilder.Append("                      </tr>\r\n");
	templateBuilder.Append("                    </tfoot>\r\n");
	templateBuilder.Append("                  </table>\r\n");
	templateBuilder.Append("                </div>\r\n");
	templateBuilder.Append("                <div id=\"tabs-5\">\r\n");
	templateBuilder.Append("                  <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("                    <tbody>\r\n");
	templateBuilder.Append("                      <tr>\r\n");
	templateBuilder.Append("                        <td align=\"left\" >\r\n");
	templateBuilder.Append("                        <ul id=\"FamilyDataList\">\r\n");
	templateBuilder.Append("                        </ul>\r\n");
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                      </tr>\r\n");
	templateBuilder.Append("                    </tbody>\r\n");
	templateBuilder.Append("                    <tfoot>\r\n");
	templateBuilder.Append("                      <tr>\r\n");
	templateBuilder.Append("                        <td align=\"center\" ><a href=\"javascript:void(0);\" id=\"FamilyData_bt\">添加</a></td>\r\n");
	templateBuilder.Append("                      </tr>\r\n");
	templateBuilder.Append("                    </tfoot>\r\n");
	templateBuilder.Append("                  </table>\r\n");
	templateBuilder.Append("                </div>\r\n");
	templateBuilder.Append("                <div id=\"tabs-6\">\r\n");
	templateBuilder.Append("                <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">面试时间</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"aDateTime\" id=\"aDateTime\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sad!=null)
	{

	 aspxrewriteurl = DateTime.Parse(sad.aDateTime.ToString()).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("                          value=\"" + aspxrewriteurl.ToString() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">综合评价</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"aEvaluation\" id=\"aEvaluation\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sad!=null)
	{

	templateBuilder.Append("value=\"" + sad.aEvaluation.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td width=\"20%\" align=\"right\" class=\"ltd\">形象</td>\r\n");
	templateBuilder.Append("                          <td width=\"30%\" align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                          <input name=\"aWearing\" id=\"aWearing\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sad!=null)
	{

	templateBuilder.Append("value=\"" + sad.aWearing.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                          <td width=\"20%\" align=\"right\" class=\"ltd\">教育</td>\r\n");
	templateBuilder.Append("                          <td width=\"30%\" align=\"left\" class=\"rtd\"><input name=\"aEducation\" id=\"aEducation\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sad!=null)
	{

	templateBuilder.Append("value=\"" + sad.aEducation.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">工作经验</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"aWork\" id=\"aWork\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sad!=null)
	{

	templateBuilder.Append("value=\"" + sad.aWork.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">沟通能力</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"aCommunication\" id=\"aCommunication\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sad!=null)
	{

	templateBuilder.Append("value=\"" + sad.aCommunication.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">自信心</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"aConfidence\" id=\"aConfidence\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sad!=null)
	{

	templateBuilder.Append("value=\"" + sad.aConfidence.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">领导能力</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"aLeadership\" id=\"aLeadership\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sad!=null)
	{

	templateBuilder.Append("value=\"" + sad.aLeadership.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">工作稳定性</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"aJobstability\" id=\"aJobstability\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sad!=null)
	{

	templateBuilder.Append("value=\"" + sad.aJobstability.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">计算机操作</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"aComputer\" id=\"aComputer\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sad!=null)
	{

	templateBuilder.Append("value=\"" + sad.aComputer.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">英语水平</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"aEnglish\" id=\"aEnglish\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sad!=null)
	{

	templateBuilder.Append("value=\"" + sad.aEnglish.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">笔试成绩</td>\r\n");
	templateBuilder.Append("                          <td align=\"left\" class=\"rtd\"><input name=\"aWritten\" id=\"aWritten\" type=\"text\" \r\n");

	if (Act=="Edit")
	{


	if (sad!=null)
	{

	templateBuilder.Append("value=\"" + sad.aWritten.ToString().Trim() + "\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                          /></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                        <tr>\r\n");
	templateBuilder.Append("                          <td align=\"right\" class=\"ltd\">备注</td>\r\n");
	templateBuilder.Append("                          <td colspan=\"3\" align=\"left\" class=\"rtd\"><textarea name=\"aEvaluationMSG\" id=\"aEvaluationMSG\" style=\"width:90%\" cols=\"45\" rows=\"10\"></textarea></td>\r\n");
	templateBuilder.Append("                        </tr>\r\n");
	templateBuilder.Append("                 </table>\r\n");
	templateBuilder.Append("                </div>\r\n");
	templateBuilder.Append("            </div>\r\n");
	templateBuilder.Append("<div style=\"height:30px\"></div>\r\n");
	templateBuilder.Append("            <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"center\">\r\n");
	templateBuilder.Append("					<INPUT TYPE=\"hidden\" NAME=\"EduDataListJson\" id=\"EduDataListJson\">\r\n");
	templateBuilder.Append("					<INPUT TYPE=\"hidden\" NAME=\"WorkDataListJson\" id=\"WorkDataListJson\">\r\n");
	templateBuilder.Append("					<INPUT TYPE=\"hidden\" NAME=\"FamilyDataListJson\" id=\"FamilyDataListJson\">\r\n");
	templateBuilder.Append("                  	<input type=\"button\" id=\"bt_s\" style=\"margin:5px\" class=\"B_INPUT\" value=\"确定\" />\r\n");
	templateBuilder.Append("                  	<input type=\"button\" id=\"bt_c\" style=\"margin:5px\" class=\"B_INPUT\" value=\"取消\"  />\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </div>\r\n");
	templateBuilder.Append("            </form>\r\n");
	templateBuilder.Append("            <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("			$(document).ready(function (){\r\n");
	templateBuilder.Append("				$(\"#tabs\").tabs();\r\n");
	templateBuilder.Append("				$('#sBirthDay').mask('9999-99-99');\r\n");
	templateBuilder.Append("				$('#sCanBeDate').mask('9999-99-99');\r\n");
	templateBuilder.Append("				$('#aDateTime').mask('9999-99-99');\r\n");
	templateBuilder.Append("				$(\"#category\").mcDropdown(\"#categorymenu\");\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("				var dd = $(\"#category\").mcDropdown();\r\n");
	templateBuilder.Append("				dd.setValue(" + si.DepartmentsClassID.ToString().Trim() + ");\r\n");

	}	//end if

	templateBuilder.Append("			});\r\n");
	templateBuilder.Append("			var Staff_do = new TStaff_do();\r\n");
	templateBuilder.Append("			Staff_do.EduDataListJsonStr = '" + EduDataListJson.ToString() + "';\r\n");
	templateBuilder.Append("			Staff_do.WorkDataListJsonStr = '" + WorkDataListJson.ToString() + "';\r\n");
	templateBuilder.Append("			Staff_do.FamilyDataListJsonStr = '" + FamilyDataListJson.ToString() + "';\r\n");
	templateBuilder.Append("			Staff_do.StaffID=" + StaffID.ToString() + ";\r\n");
	templateBuilder.Append("			Staff_do.ReCode = '" + ucode.ToString() + "';\r\n");
	templateBuilder.Append("			Staff_do.ini();\r\n");
	templateBuilder.Append("			</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
