<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.stores_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:48. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/Cxty_XTool.js\"></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.mcdropdown.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.bgiframe.js\"></" + "script>\r\n");
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

	templateBuilder.Append("<link rel=\"stylesheet\" rev=\"stylesheet\" href=\"/public/js/jquery-ui.css\" />\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery-ui.min.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/stores_do.js\"></" + "script>\r\n");
	templateBuilder.Append("            <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("            <div id=\"tabs\" >\r\n");
	templateBuilder.Append("            	<ul>\r\n");
	templateBuilder.Append("					<li><a href=\"#tabs-1\">&nbsp;基础信息&nbsp;</a></li>\r\n");
	templateBuilder.Append("                    <li><a href=\"#tabs-2\">&nbsp;联系信息&nbsp;</a></li>\r\n");
	templateBuilder.Append("                    <li><a href=\"#tabs-3\">&nbsp;业务员&nbsp;</a></li>\r\n");
	templateBuilder.Append("					<li><a href=\"#tabs-4\">&nbsp;促销员&nbsp;</a></li>\r\n");
	templateBuilder.Append("                    <li><a href=\"#tabs-5\">&nbsp;财务信息&nbsp;</a></li>\r\n");
	templateBuilder.Append("                </ul>\r\n");
	templateBuilder.Append("			    <div id=\"tabs-1\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td width=\"20%\" align=\"right\" class=\"ltd\">客户名称</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sName\" id=\"sName\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sName.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"可填写少于50个的中英文字符\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">客户编号</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sCode\" id=\"sCode\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sCode.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"可填写少于50个的数字或英文字符\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">工商注册号</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sLicense\" id=\"sLicense\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sLicense.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"可填写少于50个的数字或英文字符\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">客户分类</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input type=\"hidden\" id=\"CustomersClassID\" name=\"CustomersClassID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.CustomersClassID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("                  <input type=\"text\" name=\"category\" id=\"category\" value=\"\" />\r\n");
	templateBuilder.Append("                  <ul id=\"categorymenu\" class=\"mcdropdown_menu\">" + CustomersClass.ToString() + "</ul>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">价格分类</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input type=\"hidden\" id=\"PriceClassID\" name=\"PriceClassID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.PriceClassID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("                  <input type=\"text\" name=\"category_c\" id=\"category_c\" value=\"\" />\r\n");
	templateBuilder.Append("                  <ul id=\"categorymenu_c\" class=\"mcdropdown_menu\">" + PriceClass.ToString() + "</ul>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">类型</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sType\" id=\"sType\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sType.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"客户等级类型,例如(A,B,C...)\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">所属超市系统</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("					<input type=\"text\" name=\"category_d\" id=\"category_d\" value=\"\" />\r\n");
	templateBuilder.Append("					<ul id=\"categorymenu_d\" class=\"mcdropdown_menu\">\r\n");

	if (YHsysList!=null)
	{


	int sl__loop__id=0;
	foreach(DataRow sl in YHsysList.Rows)
	{
		sl__loop__id++;

	templateBuilder.Append("							<li rel=\"" + sl["YHsysID"].ToString().Trim() + "\">" + sl["yName"].ToString().Trim() + "</li>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("					</ul>\r\n");
	templateBuilder.Append("				  <INPUT TYPE=\"hidden\" NAME=\"YHsysID\" id=\"YHsysID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.YHsysID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("				 </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">所属结算系统</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("					<input type=\"text\" name=\"category_e\" id=\"category_e\" value=\"\" />\r\n");
	templateBuilder.Append("					<ul id=\"categorymenu_e\" class=\"mcdropdown_menu\">\r\n");

	if (PaymentSystemList!=null)
	{


	int pl__loop__id=0;
	foreach(DataRow pl in PaymentSystemList.Rows)
	{
		pl__loop__id++;

	templateBuilder.Append("							<li rel=\"" + pl["PaymentSystemID"].ToString().Trim() + "\">" + pl["pName"].ToString().Trim() + "</li>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("					</ul>\r\n");
	templateBuilder.Append("				  <INPUT TYPE=\"hidden\" NAME=\"PaymentSystemID\" id=\"PaymentSystemID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.PaymentSystemID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");
	templateBuilder.Append("				  </td>\r\n");
	templateBuilder.Append("      </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">地区</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input type=\"hidden\" id=\"RegionID\" name=\"RegionID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.RegionID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("                  <input type=\"text\" name=\"category_b\" id=\"category_b\" value=\"\" />\r\n");
	templateBuilder.Append("                  <ul id=\"categorymenu_b\" class=\"mcdropdown_menu\">" + Region.ToString() + "</ul>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">是否为福州永辉系统:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\"><input name=\"sIsFZYH\" type=\"checkbox\" value=\"1\" id=\"sIsFZYH\" class=\"B_Check\"\r\n");

	if (Act=="Edit")
	{


	if (si.sIsFZYH.ToString() == "1")
	{

	templateBuilder.Append("                        checked=\"checked\"\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("                    是</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">状态:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\"><input name=\"sState\" type=\"checkbox\" value=\"0\" id=\"sState\" class=\"B_Check\"\r\n");

	if (Act=="Edit")
	{


	if (si.sState.ToString() == "0")
	{

	templateBuilder.Append("                        checked=\"checked\"\r\n");

	}	//end if


	}
	else
	{

	templateBuilder.Append("						checked=\"checked\"\r\n");

	}	//end if

	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("                    正常</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("                </div>\r\n");
	templateBuilder.Append("			    <div id=\"tabs-2\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td width=\"20%\"  align=\"right\" class=\"ltd\">联系人</td>\r\n");
	templateBuilder.Append("  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("  <input name=\"sContact\" id=\"sContact\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sContact.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"可填写少于20个中英文字符\"\r\n");
	templateBuilder.Append("  /></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td  align=\"right\" class=\"ltd\">联系电话</td>\r\n");
	templateBuilder.Append("  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("  <input name=\"sTel\" id=\"sTel\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sTel.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"客户的联系电话\"\r\n");
	templateBuilder.Append("  /></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td  align=\"right\" class=\"ltd\">地址</td>\r\n");
	templateBuilder.Append("  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("  <input name=\"sAddress\" id=\"sAddress\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sAddress.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"可填写少于50个中文字符\"\r\n");
	templateBuilder.Append("  /></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td  align=\"right\" class=\"ltd\">邮箱</td>\r\n");
	templateBuilder.Append("  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("  <input name=\"sEmail\" id=\"sEmail\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sEmail.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"客户的邮箱地址\"\r\n");
	templateBuilder.Append("  /></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("                </div>\r\n");
	templateBuilder.Append("			    <div id=\"tabs-3\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("<td width=\"20%\"  align=\"right\" class=\"ltd\">当前业务员</td>\r\n");
	templateBuilder.Append("<td align=\"left\" class=\"rtd\">\r\n");

	if (sti!=null)
	{


	if (sti.sName != null)
	{

	templateBuilder.Append("<a href=\"javascript:void(0);\">" + sti.sName.ToString().Trim() + "</a>\r\n");

	}
	else
	{

	templateBuilder.Append("<a href=\"javascript:void(0);\">设置业务员</a>\r\n");

	}	//end if


	}
	else
	{

	templateBuilder.Append("<a href=\"javascript:void(0);\">设置业务员</a>\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td  align=\"right\" valign=\"top\" class=\"ltd\">历史记录</td>\r\n");
	templateBuilder.Append("  <td align=\"left\" class=\"rtd\"><table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("  <thead>\r\n");
	templateBuilder.Append("    <tr class=\"tBar\">\r\n");
	templateBuilder.Append("      <td>业务员</td>\r\n");
	templateBuilder.Append("      <td width=\"20%\">上岗时间</td>\r\n");
	templateBuilder.Append("      <td width=\"20%\">离岗时间</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    </thead>\r\n");
	templateBuilder.Append("    <tbody>\r\n");

	if (StaffList!=null)
	{


	int sfl__loop__id=0;
	foreach(DataRow sfl in StaffList.Rows)
	{
		sfl__loop__id++;

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("      <td>" + sfl["StaffName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("      <td>\r\n");
	 aspxrewriteurl = DateTime.Parse(sfl["bdate"].ToString()).ToShortDateString().ToString();
	
	templateBuilder.Append("					" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("      <td> \r\n");

	if (DateTime.Parse(sfl["edate"].ToString())<=DateTime.Now)
	{

	 aspxrewriteurl = DateTime.Parse(sfl["edate"].ToString()).ToShortDateString().ToString();
	
	templateBuilder.Append("						" + aspxrewriteurl.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("    </tbody>\r\n");
	templateBuilder.Append("  </table></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("                </div>\r\n");
	templateBuilder.Append("<div id=\"tabs-4\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("<td width=\"20%\"  align=\"right\" class=\"ltd\">当前促销员</td>\r\n");
	templateBuilder.Append("<td align=\"left\" class=\"rtd\">\r\n");

	if (sti_b!=null)
	{


	if (sti_b.sName != null)
	{

	templateBuilder.Append("<a href=\"javascript:void(0);\">" + sti_b.sName.ToString().Trim() + "</a>\r\n");

	}
	else
	{

	templateBuilder.Append("<a href=\"javascript:void(0);\">设置促销员</a>\r\n");

	}	//end if


	}
	else
	{

	templateBuilder.Append("<a href=\"javascript:void(0);\">设置促销员</a>\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("  <td  align=\"right\" valign=\"top\" class=\"ltd\">历史记录</td>\r\n");
	templateBuilder.Append("  <td align=\"left\" class=\"rtd\"><table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\">\r\n");
	templateBuilder.Append("  <thead>\r\n");
	templateBuilder.Append("    <tr class=\"tBar\">\r\n");
	templateBuilder.Append("      <td>业务员</td>\r\n");
	templateBuilder.Append("      <td width=\"20%\">上岗时间</td>\r\n");
	templateBuilder.Append("      <td width=\"20%\">离岗时间</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    </thead>\r\n");
	templateBuilder.Append("    <tbody>\r\n");

	if (StaffList_b!=null)
	{


	int sfl_b__loop__id=0;
	foreach(DataRow sfl_b in StaffList_b.Rows)
	{
		sfl_b__loop__id++;

	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("      <td>" + sfl_b["StaffName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("      <td>\r\n");
	 aspxrewriteurl = DateTime.Parse(sfl_b["bdate"].ToString()).ToShortDateString().ToString();
	
	templateBuilder.Append("					" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("      <td> \r\n");

	if (DateTime.Parse(sfl_b["edate"].ToString())<=DateTime.Now)
	{

	 aspxrewriteurl = DateTime.Parse(sfl_b["edate"].ToString()).ToShortDateString().ToString();
	
	templateBuilder.Append("						" + aspxrewriteurl.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("    </tbody>\r\n");
	templateBuilder.Append("  </table></td>\r\n");
	templateBuilder.Append("</tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("                </div>\r\n");
	templateBuilder.Append("			    <div id=\"tabs-5\">\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("                  <td width=\"20%\"  align=\"right\" class=\"ltd\">对账日</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("          <input name=\"sDoDay\" id=\"sDoDay\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sDoDay.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"客户的对账日\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("      </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">期初应收款</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"sDoDayMoney\" id=\"sDoDayMoney\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + si.sDoDayMoney.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"只能填写数字格式\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                </table>\r\n");
	templateBuilder.Append("                </div>\r\n");
	templateBuilder.Append("<div style=\"height:35px\"></div>\r\n");
	templateBuilder.Append("            <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"center\">\r\n");
	templateBuilder.Append("                  	<input type=\"button\" id=\"bt_ok\" style=\"margin:5px\" class=\"B_INPUT\" value=\"确定\" />\r\n");
	templateBuilder.Append("                  <input type=\"button\" id=\"button2\" style=\"margin:5px\" class=\"B_INPUT\" value=\"取消\" onClick=\"javascript:window.parent.HidBox();\" />\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </div>\r\n");
	templateBuilder.Append("            </form>\r\n");
	templateBuilder.Append("            <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("$(document).ready(function (){\r\n");
	templateBuilder.Append("	$( \"#tabs\" ).tabs();\r\n");
	templateBuilder.Append("	$(\"#category\").mcDropdown(\"#categorymenu\");\r\n");
	templateBuilder.Append("	$(\"#category_b\").mcDropdown(\"#categorymenu_b\");\r\n");
	templateBuilder.Append("	$(\"#category_c\").mcDropdown(\"#categorymenu_c\");\r\n");
	templateBuilder.Append("	$(\"#category_d\").mcDropdown(\"#categorymenu_d\");\r\n");
	templateBuilder.Append("	$(\"#category_e\").mcDropdown(\"#categorymenu_e\");\r\n");
	templateBuilder.Append("});\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("$(document).ready(function (){\r\n");
	templateBuilder.Append("var dd = $(\"#category\").mcDropdown();\r\n");
	templateBuilder.Append("		dd.setValue(" + si.CustomersClassID.ToString().Trim() + ");\r\n");
	templateBuilder.Append("var dd_b = $(\"#category_b\").mcDropdown();\r\n");
	templateBuilder.Append("		dd_b.setValue(" + si.RegionID.ToString().Trim() + ");\r\n");
	templateBuilder.Append("var dd_c = $(\"#category_c\").mcDropdown();\r\n");
	templateBuilder.Append("		dd_c.setValue(" + si.PriceClassID.ToString().Trim() + ");\r\n");
	templateBuilder.Append("var dd_d = $(\"#category_d\").mcDropdown();\r\n");
	templateBuilder.Append("		dd_d.setValue(" + si.YHsysID.ToString().Trim() + ");\r\n");
	templateBuilder.Append("var dd_e = $(\"#category_e\").mcDropdown();\r\n");
	templateBuilder.Append("		dd_e.setValue(" + si.PaymentSystemID.ToString().Trim() + ");\r\n");
	templateBuilder.Append("});\r\n");

	}	//end if

	templateBuilder.Append("var Stores_do = new TStores_do();\r\n");
	templateBuilder.Append("Stores_do.ini();\r\n");
	templateBuilder.Append("			</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
