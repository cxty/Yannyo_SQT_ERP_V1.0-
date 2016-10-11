<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.products_sales_storehouse" %>
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
	templateBuilder.Append("<script src=\"/public/js/jquery.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<script src=\"/public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script src=\"/public/js/myFrontPageJs/products_sales.js\" type=\"text/javascript\" language=\"javascript\" ></" + "script>\r\n");
	templateBuilder.Append("        <form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("          <div>\r\n");
	templateBuilder.Append("           <table border=\"0\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%; background-color:#cccccc\">\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("             <td colspan=\"5\">\r\n");
	templateBuilder.Append("             <span style=\"font-size:11pt\">\r\n");
	templateBuilder.Append("             <b>[统计类型：</b>\r\n");

	if (sID==0)
	{

	templateBuilder.Append("              <b>时间段]</b>\r\n");

	}	//end if


	if (sID==1)
	{

	templateBuilder.Append("              <b>年统计]</b>\r\n");

	}	//end if


	if (sID==2)
	{

	templateBuilder.Append("              <b>月统计]</b>\r\n");

	}	//end if

	templateBuilder.Append("             <b>[统计时间：</b>\r\n");

	if (sID==0)
	{

	templateBuilder.Append("             <b>\r\n");
	 aspxrewriteurl = bDate.ToString("yyyy年MM月dd日");
	
	templateBuilder.Append("" + aspxrewriteurl.ToString() + "至\r\n");
	 aspxrewriteurl = eDate.ToString("yyyy年MM月dd日");
	
	templateBuilder.Append("" + aspxrewriteurl.ToString() + "]</b>\r\n");

	}	//end if


	if (sID==1)
	{

	templateBuilder.Append("             <b>\r\n");
	 aspxrewriteurl = bDate.ToString("yyyy");
	
	templateBuilder.Append("" + aspxrewriteurl.ToString() + "年]</b>\r\n");

	}	//end if


	if (sID==2)
	{

	templateBuilder.Append("             <b>\r\n");
	 aspxrewriteurl = bDate.ToString("yyyy年MM");
	
	templateBuilder.Append("" + aspxrewriteurl.ToString() + "月]</b>\r\n");

	}	//end if

	templateBuilder.Append("             </span>\r\n");
	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("            <tr>\r\n");
	templateBuilder.Append("             <td colspan=\"8\"><hr /></td>\r\n");
	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("           </table>\r\n");
	templateBuilder.Append("           <div id=\"space\"></div>\r\n");
	templateBuilder.Append("           <div class=\"datalist\">\r\n");
	templateBuilder.Append("           <table id=\"title_space\" class=\"tBox\" border=\"0\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%\">\r\n");
	templateBuilder.Append("            <tr class=\"tBar\">\r\n");
	templateBuilder.Append("              <td align=\"center\" rowspan=\"2\" style=\"width:5%;height:30px\"><span style=\"font-size:larger\"><b>编号</b></span></td>\r\n");
	templateBuilder.Append("              <td align=\"center\" rowspan=\"2\" style=\"width:13%\"><span style=\"font-size:larger\"><b>门店名称</b></span></td>\r\n");
	templateBuilder.Append("              <td align=\"center\" rowspan=\"2\" style=\"width:30%\"><span style=\"font-size:larger\"><b>商品名称</b></span></td>\r\n");
	templateBuilder.Append("              <td align=\"center\" rowspan=\"2\" style=\"width:10%\"><span style=\"font-size:larger\"><b>商品条码</b></span></td>\r\n");

	if (sID==2)
	{

	templateBuilder.Append("              <td align=\"center\" colspan=\"3\" style=\"width:21%\"><span style=\"font-size:larger\"><b>购销日均销量</b></span></td>\r\n");

	}
	else
	{

	templateBuilder.Append("              <td align=\"center\" colspan=\"2\" style=\"width:21%\"><span style=\"font-size:larger\"><b>购销日均销量</b></span></td>\r\n");

	}	//end if


	if (sID==2)
	{

	templateBuilder.Append("              <td align=\"center\" colspan=\"3\" style=\"width:21%\"><span style=\"font-size:larger\"><b>客户日均销量</b></span></td>\r\n");

	}
	else
	{

	templateBuilder.Append("              <td align=\"center\" colspan=\"2\" style=\"width:21%\"><span style=\"font-size:larger\"><b>客户日均销量</b></span></td>\r\n");

	}	//end if

	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("            <tr class=\"tBar\">\r\n");
	templateBuilder.Append("              <!--购销日均销量-->\r\n");
	templateBuilder.Append("              <td align=\"center\" style=\"width:7%\"><b>日均销量</b></td>\r\n");
	templateBuilder.Append("              <td align=\"center\" style=\"width:7%\"><b>同比销量</b></td>\r\n");

	if (sID==2)
	{

	templateBuilder.Append("              <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("              <td align=\"center\" style=\"width:7%\"><b>环比销量</b></td>\r\n");
	templateBuilder.Append("              </div>\r\n");

	}	//end if

	templateBuilder.Append("              <!--门店日均销量-->\r\n");
	templateBuilder.Append("              <td align=\"center\" style=\"width:7%\"><b>日均销量</b></td>\r\n");
	templateBuilder.Append("              <td align=\"center\" style=\"width:7%\"><b>同比销量</b></td>\r\n");

	if (sID==2)
	{

	templateBuilder.Append("              <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("              <td align=\"center\" style=\"width:7%\"><b>环比销量</b></td>\r\n");
	templateBuilder.Append("              </div>\r\n");

	}	//end if

	templateBuilder.Append("            </tr>\r\n");
	templateBuilder.Append("           </table>\r\n");
	templateBuilder.Append("           </div>\r\n");
	templateBuilder.Append("           <table id=\"tBoxs\"  class=\"tBox\" border=\"0\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%\">\r\n");

	if (sList !=null)
	{


	int sl__loop__id=0;
	foreach(DataRow sl in sList.Rows)
	{
		sl__loop__id++;

	 tList = Products_sales_storehouse_basis(pID,sl["StoresID"].ToString().Trim(),bDate,eDate,sID);
	
	templateBuilder.Append("             <tr>\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:5%\">" + sl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("              <td align=\"left\"  style=\"width:13%\">" + sl["sName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("              <td align=\"left\"  style=\"width:30%\">" + pName.ToString() + "</td>\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:10%\">" + pBarcode.ToString() + "</td>\r\n");

	if (sID!=2)
	{

	templateBuilder.Append("              <!--[购销]日均销量-->\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:10.5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(sl["oQuantity"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 sumA = decimal.Round(sumA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("              </td>\r\n");

	if (tList !=null)
	{


	int tl__loop__id=0;
	foreach(DataRow tl in tList.Rows)
	{
		tl__loop__id++;

	templateBuilder.Append("              <!--[购销]同比销量-->\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:10.5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(tl["oQuantity"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("              " + aspxrewriteurl.ToString() + "\r\n");
	 sumAA = decimal.Round(sumAA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("              </td>             \r\n");

	}	//end loop


	}
	else
	{

	templateBuilder.Append("              <td align=\"center\"  style=\"width:10.5%\">0.00</td>\r\n");

	}	//end if


	}
	else
	{

	 hList = Products_sales_storehouse_annulus(pID,sl["StoresID"].ToString().Trim(),bDate,eDate,sID);
	
	templateBuilder.Append("             <!--[购销]日均销量-->\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:7%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(sl["oQuantity"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 sumA = decimal.Round(sumA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("              </td>\r\n");

	if (tList !=null)
	{


	int tl__loop__id=0;
	foreach(DataRow tl in tList.Rows)
	{
		tl__loop__id++;

	templateBuilder.Append("              <!--[购销]同比销量-->\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:7%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(tl["oQuantity"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("              " + aspxrewriteurl.ToString() + "\r\n");
	 sumAA = decimal.Round(sumAA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("              </td>\r\n");

	}	//end loop


	}
	else
	{

	templateBuilder.Append("              <td align=\"center\"  style=\"width:7%\">0.00</td>\r\n");

	}	//end if


	if (hList !=null)
	{


	int hl__loop__id=0;
	foreach(DataRow hl in hList.Rows)
	{
		hl__loop__id++;

	templateBuilder.Append("               <!--[购销]环比销量-->\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:7%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(hl["oQuantity"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("              " + aspxrewriteurl.ToString() + "\r\n");
	 sumAAA = decimal.Round(sumAAA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("              </td>\r\n");

	}	//end loop


	}
	else
	{

	templateBuilder.Append("              <td align=\"center\"  style=\"width:7%\">0.00</td>\r\n");

	}	//end if


	}	//end if


	if (sID!=2)
	{

	templateBuilder.Append("              <!--[门店]日均销量-->\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:10.5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(sl["sNum"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 sumB = decimal.Round(sumB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             </td>\r\n");

	if (tList !=null)
	{


	int tl__loop__id=0;
	foreach(DataRow tl in tList.Rows)
	{
		tl__loop__id++;

	templateBuilder.Append("              <!--[门店]同比销量-->\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:10.5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(tl["sNum"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("              " + aspxrewriteurl.ToString() + "\r\n");
	 sumBB = decimal.Round(sumBB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("              </td>\r\n");

	}	//end loop


	}
	else
	{

	templateBuilder.Append("              <td align=\"center\"  style=\"width:10.5%\">0.00</td>\r\n");

	}	//end if


	}
	else
	{

	 hList = Products_sales_storehouse_annulus(pID,sl["StoresID"].ToString().Trim(),bDate,eDate,sID);
	
	templateBuilder.Append("              <!--[门店]日均销量-->\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:7%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(sl["sNum"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 sumB = decimal.Round(sumB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("              </td>\r\n");

	if (tList !=null)
	{


	int tl__loop__id=0;
	foreach(DataRow tl in tList.Rows)
	{
		tl__loop__id++;

	templateBuilder.Append("              <!--[门店]同比销量-->\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:7%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(tl["sNum"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("              " + aspxrewriteurl.ToString() + "\r\n");
	 sumBB = decimal.Round(sumBB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("              </td>\r\n");

	}	//end loop


	}
	else
	{

	templateBuilder.Append("              <td align=\"center\"  style=\"width:7%\">0.00</td>\r\n");

	}	//end if


	if (hList !=null)
	{


	int hl__loop__id=0;
	foreach(DataRow hl in hList.Rows)
	{
		hl__loop__id++;

	templateBuilder.Append("              <!--[门店]环比销量-->\r\n");
	templateBuilder.Append("              <td align=\"center\"  style=\"width:7%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(hl["sNum"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("              " + aspxrewriteurl.ToString() + "\r\n");
	 sumBBB = decimal.Round(sumBBB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("              </td>\r\n");

	}	//end loop


	}
	else
	{

	templateBuilder.Append("              <td align=\"center\"  style=\"width:7%\">0.00</td>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("             </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("         <tr>\r\n");
	templateBuilder.Append("           <td align=\"center\" colspan=\"4\"><span style=\"font-size:larger\"><b>门店单品日均销量合计</b></span></td>\r\n");
	templateBuilder.Append("           <!--购销-->\r\n");
	templateBuilder.Append("           <td align=\"center\"  style=\"width:7%\"><b>" + sumA.ToString() + "</b></td>\r\n");
	templateBuilder.Append("           <td align=\"center\"  style=\"width:7%\"><b>" + sumAA.ToString() + "</b></td>\r\n");

	if (sID==2)
	{

	templateBuilder.Append("           <td align=\"center\"  style=\"width:7%\"><b>" + sumAAA.ToString() + "</b></td>\r\n");

	}	//end if

	templateBuilder.Append("           <!--客户销售-->\r\n");
	templateBuilder.Append("           <td align=\"center\"  style=\"width:7%\"><b>" + sumB.ToString() + "</b></td>\r\n");
	templateBuilder.Append("           <td align=\"center\"  style=\"width:7%\"><b>" + sumBB.ToString() + "</b></td>\r\n");

	if (sID==2)
	{

	templateBuilder.Append("           <td align=\"center\"  style=\"width:7%\"><b>" + sumBBB.ToString() + "</b></td>\r\n");

	}	//end if

	templateBuilder.Append("         </tr>\r\n");
	templateBuilder.Append("         </table>\r\n");
	templateBuilder.Append("        </div>\r\n");
	templateBuilder.Append("        </form>\r\n");

	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
