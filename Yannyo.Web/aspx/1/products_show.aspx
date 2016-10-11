<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.products_show" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:31. 
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
	templateBuilder.Append("<script type=\"text/javascript\" language=\"javascript\">\r\n");
	templateBuilder.Append("function img_show(img_str,sObj){\r\n");
	templateBuilder.Append("	if(img_str){\r\n");
	templateBuilder.Append("		var _img = img_str.split(',');\r\n");
	templateBuilder.Append("		for(var i=0;i<_img.length;i++){\r\n");
	templateBuilder.Append("			if(_img[i]){\r\n");
	templateBuilder.Append("				var _img_obj = $('<img src=\"'+_img[i]+'\" />')\r\n");
	templateBuilder.Append("				$('#'+sObj).append(_img_obj);\r\n");
	templateBuilder.Append("				_img_obj = null;\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	}\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("function file_show(file_str,sObj){\r\n");
	templateBuilder.Append("	if(file_str){\r\n");
	templateBuilder.Append("		var _file = file_str.split(',');\r\n");
	templateBuilder.Append("		for(var i=0;i<_file.length;i++){\r\n");
	templateBuilder.Append("			if(_file[i]){\r\n");
	templateBuilder.Append("				var _file_obj = $('<div src=\"'+_file[i]+'\" ><a href=\"'+_file[i]+'\" target=\"_blank\">'+_file[i]+'</a></div>')\r\n");
	templateBuilder.Append("				$('#'+sObj).append(_file_obj);\r\n");
	templateBuilder.Append("				_file_obj = null;\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	}\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("</" + "script>  \r\n");

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

	templateBuilder.Append("        <br>        <br>\r\n");
	templateBuilder.Append("            <div id=\"print_box\">\r\n");
	templateBuilder.Append("            <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\" class=\"print_box\">\r\n");
	templateBuilder.Append("            <h4 align=\"center\" style=\"font-size:24px\">" + config.CompanyName.ToString().Trim() + " 商品信息</h4><br>\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\"  bordercolor= \"#000000 \"   style= \"border-collapse:collapse; \">\r\n");
	templateBuilder.Append("                <tr >\r\n");
	templateBuilder.Append("                  <td width=\"20%\" align=\"right\"><strong>名称:</strong></td>\r\n");
	templateBuilder.Append("                  <td width=\"30%\">" + pi.pName.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                  <td width=\"20%\" align=\"right\"><strong>条码:</strong></td>\r\n");
	templateBuilder.Append("                  <td width=\"30%\">" + pi.pBarcode.ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr >\r\n");
	templateBuilder.Append("                  <td align=\"right\" ><strong>品牌:</strong></td>\r\n");
	templateBuilder.Append("                  <td >" + pi.pBrand.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                  <td align=\"right\" ><strong>分类:</strong></td>\r\n");
	templateBuilder.Append("                  <td >" + pi.ProductClass.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr >\r\n");
	templateBuilder.Append("                  <td align=\"right\" ><strong>小单位:</strong></td>\r\n");
	templateBuilder.Append("                  <td >" + pi.pUnits.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                  <td align=\"right\" ><strong>大单位:</strong></td>\r\n");
	templateBuilder.Append("                  <td >" + pi.pMaxUnits.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr >\r\n");
	templateBuilder.Append("                  <td align=\"right\" ><strong>规格:</strong></td>\r\n");
	templateBuilder.Append("                  <td >" + pi.pStandard.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                  <td align=\"right\" ><strong>装件数:</strong></td>\r\n");
	templateBuilder.Append("                  <td >1*" + pi.pToBoxNo.ToString().Trim() + "入</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr >\r\n");
	templateBuilder.Append("                  <td align=\"right\" ><strong>默认售价:</strong></td>\r\n");
	templateBuilder.Append("                  <td >" + pi.pSellingPrice.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                  <td align=\"right\" >&nbsp;</td>\r\n");
	templateBuilder.Append("                  <td >&nbsp;</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr >\r\n");
	templateBuilder.Append("                  <td align=\"right\" ><strong>生产厂家:</strong></td>\r\n");
	templateBuilder.Append("                  <td >" + pi.pProducer.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                  <td align=\"right\" ><strong>产地:</strong></td>\r\n");
	templateBuilder.Append("                  <td >" + pi.pAddress.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr >\r\n");
	templateBuilder.Append("                  <td align=\"right\" ><strong>保质期:</strong></td>\r\n");
	templateBuilder.Append("                  <td >" + pi.pExpireDay.ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                  <td >&nbsp;</td>\r\n");
	templateBuilder.Append("                  <td >&nbsp;</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");

	if (ProductFieldList !=null)
	{


	int pf__loop__id=0;
	foreach(DataRow pf in ProductFieldList.Rows)
	{
		pf__loop__id++;

	templateBuilder.Append("                <tr >\r\n");
	templateBuilder.Append("                  <td align=\"right\" ><strong>" + pf["pfName"].ToString().Trim() + ":</strong></td>\r\n");
	templateBuilder.Append("                  <td colspan=\"3\" class=\"x_box\" id=\"f_box_" + pf__loop__id.ToString() + "\">\r\n");

	if (pf["pfType"].ToString() == "3")
	{

	templateBuilder.Append("					  <script type=\"text/javascript\" language=\"javascript\">\r\n");
	templateBuilder.Append("                      img_show('" + pf["FieldValue"].ToString().Trim() + "','f_box_" + pf__loop__id.ToString() + "');\r\n");
	templateBuilder.Append("                      </" + "script>\r\n");

	}
	else
	{


	if (pf["pfType"].ToString() == "4")
	{

	templateBuilder.Append("                          <script type=\"text/javascript\" language=\"javascript\">\r\n");
	templateBuilder.Append("                          file_show('" + pf["FieldValue"].ToString().Trim() + "','f_box_" + pf__loop__id.ToString() + "');\r\n");
	templateBuilder.Append("                          </" + "script>\r\n");

	}
	else
	{

	templateBuilder.Append("                        " + pf["FieldValue"].ToString().Trim() + "\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </form>\r\n");
	templateBuilder.Append("        </div>\r\n");
	templateBuilder.Append("   <br><br>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
