<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.cost_details_gifts" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:48:55. 
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
	templateBuilder.Append("<script src=\"/public/js/myFrontPageJs/costdetails.js\" type=\"text/javascript\" language=\"javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<script src=\"/public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("        <form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("          <div>\r\n");
	templateBuilder.Append("          <input type=\"hidden\" id=\"sid\" name=\"sid\" value=\"" + sID.ToString() + "\" />\r\n");
	templateBuilder.Append("          <input type=\"hidden\" id=\"pid\" name=\"pid\" value=\"" + pID.ToString() + "\" />\r\n");
	templateBuilder.Append("          <input type=\"hidden\" id=\"bDate\" name=\"bDate\" value=\"" + bDate.ToString() + "\" />\r\n");
	templateBuilder.Append("          <input type=\"hidden\" id=\"eDate\" name=\"eDate\" value=\"" + eDate.ToString() + "\" />\r\n");
	templateBuilder.Append("          <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\" style=\"background-color:#cccccc\">\r\n");
	templateBuilder.Append("           <tr>\r\n");
	templateBuilder.Append("             <td align=\"left\" style=\"width:35%;height:30px;\">\r\n");
	templateBuilder.Append("              <span style=\"font-size:11pt\"><b>查询日期：\r\n");
	 aspxrewriteurl = bDate.ToString("yyyy年MM月dd日");
	
	templateBuilder.Append("[" + aspxrewriteurl.ToString() + "]至 \r\n");
	 aspxrewriteurl = eDate.ToString("yyyy年MM月dd日");
	
	templateBuilder.Append("[" + aspxrewriteurl.ToString() + "]\r\n");
	templateBuilder.Append("              </b></span>\r\n");
	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("           </tr>\r\n");
	templateBuilder.Append("          </table>\r\n");
	templateBuilder.Append("           <div id=\"space\"></div>\r\n");
	templateBuilder.Append("           <div class=\"datalist\">\r\n");
	templateBuilder.Append("           <table id=\"title_space\" border=\"0\"  class=\"tBox\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%\">\r\n");
	templateBuilder.Append("             <tr class=\"tBar\">\r\n");
	templateBuilder.Append("               <td align=\"center\" rowspan=\"2\" style=\"width:5%;height:30px;\"><span style=\"font-size:larger\"><b>编号</b></span></td>\r\n");
	templateBuilder.Append("               <td align=\"center\" rowspan=\"2\" style=\"width:15%;height:30px;\"><span style=\"font-size:larger\"><b>门店名称</b></span></td>\r\n");
	templateBuilder.Append("               <td align=\"center\" rowspan=\"2\" style=\"width:20%;height:30px;\"><span style=\"font-size:larger\"><b>商品名称</b></span></td>\r\n");
	templateBuilder.Append("               <td align=\"center\" rowspan=\"2\" style=\"width:15%;height:30px;\"><span style=\"font-size:larger\"><b>商品条码</b></span></td>\r\n");
	templateBuilder.Append("               <td align=\"center\" colspan=\"2\" style=\"width:20%;height:15px;\"><span style=\"font-size:larger\"><b>商品数量</b></span></td>\r\n");
	templateBuilder.Append("               <td align=\"center\"  style=\"width:10%;height:15px;\"><span style=\"font-size:larger\"><b>发生金额</b></span></td>\r\n");
	templateBuilder.Append("               <td align=\"center\"  colspan=\"2\" style=\"width:15%;height:30px;\"><span style=\"font-size:larger\"><b>操作日期</b></span></td>\r\n");
	templateBuilder.Append("             </tr>\r\n");
	templateBuilder.Append("             <tr class=\"tBar\">\r\n");
	templateBuilder.Append("               <td align=\"center\" style=\"width:10%;height:15px;\"><span style=\"font-size:11pt\"><b>赠品单数量</b></span></td>\r\n");
	templateBuilder.Append("               <td align=\"center\" style=\"width:10%;height:15px;\"><span style=\"font-size:11pt\"><b>销售单数量</b></span></td>\r\n");
	templateBuilder.Append("               <td align=\"center\" style=\"width:10%;height:15px;\"><span style=\"font-size:11pt\"><b>赠品金额</b></span></td>\r\n");
	templateBuilder.Append("               <td align=\"center\" style=\"width:7.5%;height:15px;\"><span style=\"font-size:11pt\"><b>赠品时间</b></span></td>\r\n");
	templateBuilder.Append("               <td align=\"center\" style=\"width:7.5%;height:15px;\"><span style=\"font-size:11pt\"><b>销售时间</b></span></td>\r\n");
	templateBuilder.Append("             </tr>\r\n");
	templateBuilder.Append("           </table>\r\n");
	templateBuilder.Append("           </div>\r\n");
	templateBuilder.Append("           <table id=\"tBoxs\"  class=\"tBox\" border=\"0\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%\">\r\n");

	if (gList !=null)
	{


	int gl__loop__id=0;
	foreach(DataRow gl in gList.Rows)
	{
		gl__loop__id++;

	templateBuilder.Append("           <tr>\r\n");
	templateBuilder.Append("               <td align=\"center\" style=\"width:5%;\">" + gl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("               <td align=\"center\" style=\"width:15%;\">" + sName.ToString() + "</td>\r\n");
	templateBuilder.Append("               <td align=\"center\" style=\"width:20%;\">" + pName.ToString() + "</td>\r\n");
	templateBuilder.Append("               <td align=\"center\" style=\"width:15%;\">" + pBarcode.ToString() + "</td>\r\n");
	templateBuilder.Append("               <td align=\"center\" style=\"width:10%;\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(gl["oQuantity"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("                      " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("               </td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width:10%;\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(gl["SoQuantity"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("                      " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("               <td align=\"center\" style=\"width:10%;\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(gl["oMoney"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("                      " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("               </td>\r\n");
	templateBuilder.Append("               <td align=\"center\" style=\"width:7.5%;\">\r\n");

	if (gl["gAppendTime"].ToString()=="null")
	{

	templateBuilder.Append("无\r\n");

	}
	else
	{

	templateBuilder.Append("               " + gl["gAppendTime"].ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("               </td>\r\n");
	templateBuilder.Append("                <td align=\"center\" style=\"width:7.5%;\">\r\n");

	if (gl["zpAppendTime"].ToString()=="null")
	{

	templateBuilder.Append("无\r\n");

	}
	else
	{

	templateBuilder.Append("               " + gl["zpAppendTime"].ToString().Trim() + "\r\n");

	}	//end if

	templateBuilder.Append("               </td>\r\n");
	templateBuilder.Append("             </tr>\r\n");

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
