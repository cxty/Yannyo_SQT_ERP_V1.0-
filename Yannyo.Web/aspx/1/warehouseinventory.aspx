<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.warehouseinventory" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:50. 
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


	templateBuilder.Append("<script src=\"/public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/warehouseinventory.js\"></" + "script>\r\n");
	templateBuilder.Append("<script language=\"javascript\" src=\"/public/js/jTable.js\"></" + "script>\r\n");

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

	templateBuilder.Append(" <form action=\"\" method=\"post\" name=\"bForm\" id=\"bForm\">\r\n");
	templateBuilder.Append("   <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\"  style=\"font-size:12pt\">\r\n");
	templateBuilder.Append("              <tr>\r\n");
	templateBuilder.Append("                <td colspan=\"6\" align=\"center\"><h2>" + si.sName.ToString().Trim() + "盘点数据</h2></td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr >\r\n");
	templateBuilder.Append("                <td align=\"right\">仓管员:</td>\r\n");
	templateBuilder.Append("                <td align=\"left\"><input type=\"text\" id=\"ManagerName\" name=\"ManagerName\" value=\"" + si.ManagerName.ToString().Trim() + "\" readonly=\"readonly\" /></td>\r\n");
	templateBuilder.Append("                <td align=\"right\">联系电话:</td>\r\n");
	templateBuilder.Append("                <td align=\"left\"><input type=\"text\" id=\"sTel\" name=\"sTel\" value=\"" + si.sTel.ToString().Trim() + "\" readonly=\"readonly\" /></td>\r\n");
	templateBuilder.Append("                <td align=\"right\">仓库地址:</td>\r\n");
	templateBuilder.Append("                <td align=\"left\"><input type=\"text\" id=\"sAddress\" name=\"sAddress\" value=\"" + si.sAddress.ToString().Trim() + "\" readonly=\"readonly\" /></td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr>\r\n");
	templateBuilder.Append("                <td align=\"right\">库存点:</td>\r\n");
	templateBuilder.Append("                <td width=\"200\" align=\"left\"><input type=\"text\" id=\"atime\" name=\"atime\"  \r\n");
	 aspxrewriteurl = time.ToString("yyyy-MM-dd");
	
	templateBuilder.Append(" value=\"" + aspxrewriteurl.ToString() + " \" readonly=\"readonly\" /></td>\r\n");
	templateBuilder.Append("                <td align=\"right\">盘点时间:</td>\r\n");
	templateBuilder.Append("                <td width=\"200\" align=\"left\">\r\n");
	templateBuilder.Append("                <input type=\"text\" id=\"dtime\" name=\"dtime\" onclick=\"new Calendar().show(this);\" style=\"width:150px\"/>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td align=\"right\">盘点人:\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td width=\"200\" align=\"left\"><input type=\"text\" id=\"InventoryName\" name=\"InventoryName\"style=\"width:150px\"/></td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              <tr >\r\n");
	templateBuilder.Append("                <td colspan=\"6\" valign=\"top\">\r\n");
	templateBuilder.Append("                <span style=\"color:Red\">注意：盘点库存不填写，默认值将为“0”</span>\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("            </table>\r\n");
	templateBuilder.Append("   <div id=\"space\"></div>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tBox\" id=\"tBox\">\r\n");
	templateBuilder.Append("          <thead  > \r\n");
	templateBuilder.Append("          <tr class=\"tBar\">\r\n");
	templateBuilder.Append("			<td width=\"10%\">条码</td>\r\n");
	templateBuilder.Append("			<td >名称</td>\r\n");
	templateBuilder.Append("			<td width=\"10%\" align=\"right\">库存</td>\r\n");
	templateBuilder.Append("			<td width=\"10%\" align=\"right\">入库未核销</td>\r\n");
	templateBuilder.Append("			<td width=\"10%\" align=\"right\">出库未核销</td>\r\n");
	templateBuilder.Append("			<td width=\"10%\" align=\"right\">不可用库存</td>\r\n");
	templateBuilder.Append("			<td width=\"10%\" align=\"right\">盘点库存</td>\r\n");
	templateBuilder.Append("			<td width=\"10%\" align=\"right\">盘亏盘盈</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("		  </thead>\r\n");
	templateBuilder.Append("          <tbody id=\"dLoop\">\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("          <tr id=\"tr_" + dl__loop__id.ToString() + "\">\r\n");
	templateBuilder.Append("			<td align=\"left\">" + dl["pBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			<td align=\"left\">\r\n");
	templateBuilder.Append("            " + dl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			<td align=\"right\" id=\"pStorage_" + dl__loop__id.ToString() + "\">\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(dl["Beginning"])+Convert.ToDecimal(dl["pStorage"])+Convert.ToDecimal(dl["pStorageIn"])-Convert.ToDecimal(dl["pStorageOut"])),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "\r\n");
	 SumA = decimal.Round(SumA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("			<td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["pStorageIn"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "\r\n");
	 SumB = decimal.Round(SumB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("			<td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["pStorageOut"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "\r\n");
	 SumC = decimal.Round(SumC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("			<td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["StorageBad"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "\r\n");
	 SumD = decimal.Round(SumD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("			<td align=\"right\" class=\"text_dl\">\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(dl["Beginning"])+Convert.ToDecimal(dl["pStorage"])+Convert.ToDecimal(dl["pStorageIn"])-Convert.ToDecimal(dl["pStorageOut"])),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("             <input type=\"text\" class=\"tpPList\" style=\"width:90%\" id=\"pNum_" + dl__loop__id.ToString() + "\" pid=\"" + dl["ProductsID"].ToString().Trim() + "\" pOquantity=\"" + aspxrewriteurl.ToString() + "\" name=\"pNum_" + dl__loop__id.ToString() + "\" />\r\n");
	templateBuilder.Append("             <input type=\"hidden\" id=\"pName\" name=\"pName\" value=\"" + dl["pName"].ToString().Trim() + "\"/>\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" id=\"pNumB_" + dl__loop__id.ToString() + "\"></td>\r\n");
	templateBuilder.Append("          </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("          </tbody>\r\n");
	templateBuilder.Append("           <tr>\r\n");
	templateBuilder.Append("            <td height=\"80\" colspan=\"8\" align=\"left\">&nbsp;</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("		<div style=\"height:60px;width:100%\"></div>\r\n");
	templateBuilder.Append("		<div id=\"footer_tool\">\r\n");
	templateBuilder.Append("			<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:100%\">\r\n");
	templateBuilder.Append("				<tr style=\"height:30px\">\r\n");
	templateBuilder.Append("				  <td width=\"10%\" align=\"center\"  >合计：</td>\r\n");
	templateBuilder.Append("				  <td align=\"center\"  >&nbsp;</td>\r\n");
	templateBuilder.Append("				  <td width=\"10%\" align=\"right\"  >" + SumA.ToString() + "</td>\r\n");
	templateBuilder.Append("				  <td width=\"10%\" align=\"right\"  >" + SumB.ToString() + "</td>\r\n");
	templateBuilder.Append("				  <td width=\"10%\" align=\"right\"  >" + SumC.ToString() + "</td>\r\n");
	templateBuilder.Append("				  <td width=\"10%\" align=\"right\"  >" + SumD.ToString() + "</td>\r\n");
	templateBuilder.Append("				  <td width=\"10%\" align=\"right\"  id=\"sum_pnum\">&nbsp;</td>\r\n");
	templateBuilder.Append("                  <td width=\"10%\" align=\"right\"  id=\"sum_pnum_b\">&nbsp;</td>\r\n");
	templateBuilder.Append("		      </tr>\r\n");
	templateBuilder.Append("				<tr >\r\n");
	templateBuilder.Append("					<td colspan=\"8\" align=\"center\"  >\r\n");
	templateBuilder.Append("					<input type=\"hidden\" id=\"reValue\" name=\"reValue\" />\r\n");
	templateBuilder.Append("					<input type=\"button\" id=\"listLog\" name=\"listLog\" value=\"提交\" style=\"margin:5px\" class=\"B_INPUT\" />\r\n");
	templateBuilder.Append("					<input type=\"reset\"  id=\"reset\" name=\"reset\" value=\"重填\"  style=\"margin:5px\" class=\"B_INPUT\" />\r\n");
	templateBuilder.Append("					</td>\r\n");
	templateBuilder.Append("				</tr>\r\n");
	templateBuilder.Append("			</table>\r\n");
	templateBuilder.Append("</div>\r\n");

	}	//end if

	templateBuilder.Append("</form>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var tf = new TableFixed(\"tBox\");\r\n");
	templateBuilder.Append("tf.Clone();\r\n");
	templateBuilder.Append("var warehouseinventory_add_list = new Twarehouseinventory_add_list();\r\n");
	templateBuilder.Append("warehouseinventory_add_list.ini();\r\n");
	templateBuilder.Append("addTableListener(document.getElementById(\"tBoxs\"), 0, 0);\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
