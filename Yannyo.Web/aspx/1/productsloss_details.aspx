<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.productsloss_details" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:29. 
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
	templateBuilder.Append("<script src=\"/public/js/jquery.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<script src=\"/public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script src=\"/public/js/myFrontPageJs/productsLoss.js\" type=\"text/javascript\" language=\"javascript\" ></" + "script>\r\n");
	templateBuilder.Append("        <form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("          <div>\r\n");
	templateBuilder.Append("           <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" style=\"background-color:#cccccc\">\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("             <td align=\"left\" style=\"height:30px;\">\r\n");
	templateBuilder.Append("             <span style=\"font-size:11pt\"><b>查询日期：[" + sDate.ToString() + "至" + tDate.ToString() + "]</b></span>\r\n");
	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("             </tr>\r\n");
	templateBuilder.Append("           </table>\r\n");
	templateBuilder.Append("          </div>\r\n");
	templateBuilder.Append("          <div>\r\n");
	templateBuilder.Append("           <div id=\"space\"></div>\r\n");
	templateBuilder.Append("           <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" class=\"tBox\" id=\"get_data\">\r\n");
	templateBuilder.Append("            <tr class=\"tBar\">\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:10%\">仓库名称</td>\r\n");
	templateBuilder.Append("             <td align=\"center\" colspan=\"2\"  style=\"width:30%\">商品名称</td>\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:10%\">商品条码</td>\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:10%\">单据编号</td>\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:5%\">数量</td>\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:5%\">金额</td>\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:15%\">单据时间</td>\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:15%\">创建时间</td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("           </table>\r\n");
	templateBuilder.Append("           <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" class=\"tBox\" id=\"tBoxs\">\r\n");

	if (pList !=null)
	{


	int pl__loop__id=0;
	foreach(DataRow pl in pList.Rows)
	{
		pl__loop__id++;

	templateBuilder.Append("           <tr>\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:10%\">" + storehouseName.ToString() + "</td>\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:5%\">" + pl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("             <td align=\"left\"  style=\"width:25%\">" + productsName.ToString() + "</td>\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:10%\">\r\n");

	if (productsBarcode.ToString()=="")
	{

	templateBuilder.Append("             No coding\r\n");

	}
	else
	{

	templateBuilder.Append("             " + productsBarcode.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:10%\">" + pl["oOrderNum"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("             <td align=\"right\"  style=\"width:5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["oQuantity"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("                  " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("             <td align=\"right\"  style=\"width:5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["oMoney"].ToString().Trim()),2).ToString();
	

	if (Show=="1")
	{

	templateBuilder.Append("                  " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("                无权限\r\n");

	}	//end if

	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:15%\">\r\n");
	 aspxrewriteurl = Convert.ToDateTime(pl["oOrderDateTime"].ToString().Trim()).ToString("yyyy-MM-dd");
	
	templateBuilder.Append("               " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("             <td align=\"center\"  style=\"width:15%\">" + pl["oAppendTime"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("           </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("           </table>\r\n");
	templateBuilder.Append("          </div>\r\n");
	templateBuilder.Append("        </form>\r\n");

	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
