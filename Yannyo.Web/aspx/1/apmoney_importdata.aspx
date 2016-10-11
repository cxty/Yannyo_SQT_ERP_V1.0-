<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.apmoney_importdata" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:48:49. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/comm.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/xml.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("	<script src=\"public/js/apmoney_importdata.js\" language=\"javascript\" type=\"text/javascript\"></" + "script>\r\n");

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

	templateBuilder.Append("<form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("<div class=\"toolbar\">\r\n");
	templateBuilder.Append("<INPUT TYPE=\"hidden\" NAME=\"Act\" id=\"Act\" value=\"" + Act.ToString() + "\" />\r\n");
	templateBuilder.Append("截止日期:\r\n");
	 aspxrewriteurl = eDate.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("<input name=\"eDate\" id=\"eDate\" onclick=\"new Calendar().show(this);\" type=\"text\" value=\"" + aspxrewriteurl.ToString() + "\" style=\"width:90px\" />\r\n");
	templateBuilder.Append("<input type=\"button\" id=\"button5\" style=\"margin:5px\" class=\"B_INPUT\" value=\"查看\" onclick=\"javascript:Apmoney_ImportdataManage.Search();\"  />\r\n");
	templateBuilder.Append("<input type=\"button\" id=\"button5\" style=\"margin:5px\" class=\"B_INPUT\" value=\"确定导入\" onclick=\"javascript:Apmoney_ImportdataManage.OK();\"  />\r\n");
	templateBuilder.Append("<input type=\"button\" id=\"button6\" style=\"margin:5px\" class=\"B_INPUT\" value=\"退出\" onclick=\"javascript:parent.HidBox();\"  />\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<div class=\"datalist\">\r\n");
	templateBuilder.Append("        <table width=\"630\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\" align=\"left\">\r\n");
	templateBuilder.Append("          <tr class=\"tBar\">\r\n");
	templateBuilder.Append("            <td >名称</td>\r\n");
	templateBuilder.Append("			<td width=\"70px\">入库额</td>\r\n");
	templateBuilder.Append("			<td width=\"70px\">退货额</td>\r\n");
	templateBuilder.Append("			<td width=\"70px\">新增应付</td>\r\n");
	templateBuilder.Append("			<td width=\"70px\">累计应付</td>\r\n");
	templateBuilder.Append("            <td width=\"70px\">累计实付</td>\r\n");
	templateBuilder.Append("			<td width=\"100px\">实际应付</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("        </table>\r\n");

	if (dList != null)
	{

	templateBuilder.Append("		  <div style=\"overflow:scroll;height:400px;overflow-x:hidden;clear:left;\" align=\"left\">\r\n");
	templateBuilder.Append("		  <table width=\"630px\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\"  >\r\n");

	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;


	if (decimal.Parse(dl["tMoney"].ToString()) != 0)
	{

	templateBuilder.Append("          <tr >\r\n");
	templateBuilder.Append("			<td align=\"left\">" + dl["sName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			<td width=\"70px\" align=\"right\">" + dl["DeliveryMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			<td width=\"70px\" align=\"right\">" + dl["ReturnMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			<td width=\"70px\" align=\"right\">\r\n");
	templateBuilder.Append("			<INPUT TYPE=\"text\" NAME=\"_nMoney_" + loop_count.ToString() + "\" id=\"_nMoney_" + loop_count.ToString() + "\" value=\"" + dl["nMoney"].ToString().Trim() + "\" style=\"width:55px;text-align:right;\">\r\n");
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("			<td width=\"70px\" align=\"right\">" + dl["AMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			<td width=\"70px\" align=\"right\">" + dl["ActualMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td width=\"100px\" align=\"right\">\r\n");
	templateBuilder.Append("			<input name=\"_SupplierID_" + loop_count.ToString() + "\" id=\"_SupplierID_" + loop_count.ToString() + "\" type=\"hidden\" value=\"" + dl["SupplierID"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("			<INPUT TYPE=\"text\" NAME=\"_tMoney_" + loop_count.ToString() + "\" id=\"_tMoney_" + loop_count.ToString() + "\" value=\"" + dl["tMoney"].ToString().Trim() + "\" style=\"width:85px;text-align:right;\">\r\n");
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	 loop_count = loop_count+1;
	

	}	//end if


	}	//end loop

	templateBuilder.Append("			</table>\r\n");
	templateBuilder.Append("			</div>\r\n");
	templateBuilder.Append("			<input name=\"loop_count\" id=\"loop_count\" type=\"hidden\" value=\"" + loop_count.ToString() + "\">\r\n");

	}	//end if

	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("	<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("	var Apmoney_ImportdataManage = new TApmoney_ImportdataManage();\r\n");
	templateBuilder.Append("	Apmoney_ImportdataManage.ini();\r\n");
	templateBuilder.Append("	function HidBox()\r\n");
	templateBuilder.Append("	{\r\n");
	templateBuilder.Append("		Apmoney_ImportdataManage.HidUserBox();\r\n");
	templateBuilder.Append("		location.reload();\r\n");
	templateBuilder.Append("	}\r\n");
	templateBuilder.Append("	</" + "script>\r\n");

	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
