<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.associated_details_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:48:50. 
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
	templateBuilder.Append("<script src=\"/public/js/myFrontPageJs/storage.js\" type=\"text/javascript\" language=\"javascript\" ></" + "script>\r\n");
	templateBuilder.Append("        <form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("          <div>\r\n");
	templateBuilder.Append("           <table border=\"0\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%; background-color:#cccccc\">\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("             <td colspan=\"7\"><span style=\"font-size:11pt\"><b>截止日期：" + sDate.ToLongDateString().ToString().Trim() + "</b></span></td>          \r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("             <td colspan=\"8\"><hr /></td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("           </table>\r\n");
	templateBuilder.Append("           <table class=\"tBox\" border=\"0\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%\">\r\n");
	templateBuilder.Append("            <tr class=\"tBar\">\r\n");
	templateBuilder.Append("              <td align=\"center\"  rowspan=\"2\" style=\"width:5%\"><span style=\"font-size:larger\"><b>编号</b></span></td>\r\n");
	templateBuilder.Append("              <td align=\"center\"  rowspan=\"2\" style=\"width:15%\"><span style=\"font-size:larger\"><b>门店名称</b></span></td>\r\n");
	templateBuilder.Append("              <td align=\"center\"  rowspan=\"2\" style=\"width:25%\"><span style=\"font-size:larger\"><b>商品名称</b></span></td>\r\n");
	templateBuilder.Append("              <td align=\"center\"  rowspan=\"2\" style=\"width:15%\"><span style=\"font-size:larger\"><b>商品条码</b></span></td>\r\n");
	templateBuilder.Append("              <td align=\"center\"  rowspan=\"2\" style=\"width:10%\"><span style=\"font-size:larger\"><b>是否联营</b></span></td>\r\n");
	templateBuilder.Append("              <td align=\"center\"  rowspan=\"2\" style=\"width:10%\"><span style=\"font-size:larger\"><b>库存数量</b></span></td>\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:20%\" colspan=\"2\"><span style=\"font-size:larger\"><b>库存金额</b></span></td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("            <tr class=\"tBar\">\r\n");
	templateBuilder.Append("             <td align=\"right\" style=\"width:10%\"><b>销售金额</b></td>\r\n");
	templateBuilder.Append("             <td align=\"right\" style=\"width:10%\"><b>成本金额</b></td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("           </table>\r\n");
	templateBuilder.Append("           <table id=\"tBoxs\"  class=\"tBox\" border=\"0\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%\">\r\n");

	if (pList !=null)
	{


	int pl__loop__id=0;
	foreach(DataRow pl in pList.Rows)
	{
		pl__loop__id++;

	templateBuilder.Append("           <tr>\r\n");
	templateBuilder.Append("             <td align=\"center\" style=\"width:5%\">" + pl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("             <td align=\"center\" style=\"width:15%\">" + sName.ToString() + "</td>\r\n");
	templateBuilder.Append("             <td align=\"left\" style=\"width:25%\">" + pl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("             <td align=\"center\" style=\"width:15%\">" + pl["pBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("             <td align=\"center\" style=\"width:10%\">\r\n");

	if (aID==-1)
	{

	templateBuilder.Append("包含联营\r\n");

	}	//end if


	if (aID==0)
	{

	templateBuilder.Append("剔除联营\r\n");

	}	//end if


	if (aID==1)
	{

	templateBuilder.Append("仅含联营\r\n");

	}	//end if

	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("             <td align=\"center\" style=\"width:10%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["pRelityStorage"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("                  " + aspxrewriteurl.ToString() + "\r\n");
	 sumA = decimal.Round(sumA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("             <td align=\"right\" style=\"width:10%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["qMoney"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("                  " + aspxrewriteurl.ToString() + "\r\n");
	 sumB = decimal.Round(sumB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("             <td align=\"right\" style=\"width:10%\">\r\n");

	if (Show=="1")
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["pMoney"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("                  " + aspxrewriteurl.ToString() + "\r\n");
	 sumC = decimal.Round(sumC+Convert.ToDecimal(aspxrewriteurl),2);
	

	}
	else
	{

	templateBuilder.Append("             无权限\r\n");

	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("           </tr>\r\n");

	}	//end loop

	templateBuilder.Append("           <tr>\r\n");
	templateBuilder.Append("            <td align=\"center\" colspan=\"5\"><span style=\"font-size:larger\"><b>合&nbsp;&nbsp;计</b></span></td>\r\n");
	templateBuilder.Append("            <td align=\"center\">" + sumA.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sumB.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">\r\n");

	if (Show=="1")
	{

	templateBuilder.Append("            " + sumC.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("             无权限\r\n");

	}	//end if

	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("           </tr>\r\n");

	}	//end if

	templateBuilder.Append("           </table>\r\n");
	templateBuilder.Append("          </div>\r\n");
	templateBuilder.Append("        </form>\r\n");

	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
