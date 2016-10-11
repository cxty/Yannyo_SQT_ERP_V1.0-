<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.importdata" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:11. 
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
	templateBuilder.Append("<script src=\"public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<script language=\"javascript\" src=\"public/js/jTable.js\"></" + "script>\r\n");
	templateBuilder.Append("<script language=\"javascript\" src=\"public/js/importdata.js\"></" + "script>\r\n");

	if (ispost)
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


	if (steps==2)
	{


	templateBuilder.Append("<h2>第二步 核对提交数据</h2>\r\n");
	templateBuilder.Append("                <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\" id=\"tBoxs\">\r\n");
	templateBuilder.Append("                <thead >\r\n");
	templateBuilder.Append("                <tr class=\"tBar\">\r\n");
	templateBuilder.Append("               	  <td>门店编码</td>\r\n");
	templateBuilder.Append("                    <td>门店名</td>\r\n");
	templateBuilder.Append("                    <td>商品编码</td>\r\n");
	templateBuilder.Append("                    <td>商品条码</td>\r\n");
	templateBuilder.Append("                    <td>商品名称</td>\r\n");
	templateBuilder.Append("                    <td>品牌名称</td>\r\n");
	templateBuilder.Append("                    <td width=\"8%\" align=\"center\">商品规格</td>\r\n");
	templateBuilder.Append("                  	<td width=\"8%\" align=\"center\">单位</td>\r\n");
	templateBuilder.Append("                    <td width=\"8%\" align=\"right\">件装数</td>\r\n");
	templateBuilder.Append("                    <td width=\"8%\" align=\"right\">销售数量</td>\r\n");
	templateBuilder.Append("                    <td width=\"8%\" align=\"right\">销售金额</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                </thead>\r\n");
	templateBuilder.Append("                <tbody>\r\n");

	if (dList!=null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("                <tr id=\"tr_" + dl__loop__id.ToString() + "\" sStoresID=\"" + dl[0].ToString().Trim() + "\" sStoresName=\"" + dl[1].ToString().Trim() + "\" sProductsName=\"" + dl[4].ToString().Trim() + "\" sNum=\"" + dl[9].ToString().Trim() + "\" sPrice=\"" + dl[10].ToString().Trim() + "\" pBarcode=\"" + dl[3].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("               	  <td>" + dl[0].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                    <td>" + dl[1].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                    <td>" + dl[2].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                    <td>" + dl[3].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                    <td>" + dl[4].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                    <td>" + dl[5].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                    <td width=\"8%\" align=\"center\">" + dl[6].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                  	<td width=\"8%\" align=\"center\">" + dl[7].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                    <td width=\"8%\" align=\"right\">" + dl[8].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                    <td width=\"8%\" align=\"right\">" + dl[9].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                    <td width=\"8%\" align=\"right\">" + dl[10].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("                </tbody>\r\n");
	templateBuilder.Append("                </table>\r\n");
	templateBuilder.Append("<div style=\"height:40px\"></div>\r\n");
	templateBuilder.Append("            <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td width=\"45%\" align=\"center\">\r\n");

	if (dList!=null)
	{

	templateBuilder.Append("                  共<b id=\"add_count\">" + dList.Rows.Count.ToString().Trim() + "</b>条&nbsp;\r\n");
	templateBuilder.Append("                  成功提交<b><span id=\"add_ok\">0</span></b>条\r\n");

	}	//end if

	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                  <td align=\"left\"><input type=\"button\" id=\"bt_sub\" style=\"margin:5px\" class=\"B_INPUT\" value=\" 提交数据 \" />\r\n");
	templateBuilder.Append("                  <input type=\"button\" id=\"bt_re\" style=\"margin:5px\" class=\"B_INPUT\" value=\" 撤销数据 \" />\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("                <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("				var tf = new TableFixed(\"tBoxs\");\r\n");
	templateBuilder.Append("				tf.Clone();\r\n");
	templateBuilder.Append("                addTableListener(document.getElementById(\"tBoxs\"),0,0);\r\n");
	templateBuilder.Append("				</" + "script>\r\n");



	}	//end if


	}	//end if


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


	if (steps==1)
	{


	templateBuilder.Append("<form action=\"\" method=\"post\" enctype=\"multipart/form-data\" name=\"bForm\" id=\"bForm\">\r\n");
	templateBuilder.Append("            <h2>第一步 上传数据</h2>\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"2\">\r\n");
	templateBuilder.Append("				<tr id=\"Box_A\">\r\n");
	templateBuilder.Append("                  <td  align=\"right\">时间</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\">\r\n");
	templateBuilder.Append("				  <INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"sDateTime_S\" id=\"sDateTime_A\" value=\"0\" onClick=\"javascript:CheckR();\" checked>日数据（请选择日期）\r\n");
	templateBuilder.Append("                  <input name=\"sDateTime\" id=\"sDateTime\" onClick=\"new Calendar().show(this);\" type=\"text\">\r\n");
	templateBuilder.Append("				  <!--<br/>\r\n");
	templateBuilder.Append("				  <INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"sDateTime_S\" id=\"sDateTime_B\" value=\"1\" onClick=\"javascript:CheckR();\" >月数据（文件含表头、时间）-->\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr id=\"Box_B\">\r\n");
	templateBuilder.Append("                  <td  align=\"right\">文件</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\"><input name=\"fi\" type=\"file\" showtitle=\"须上传标准Excel文件!数字部分格式需转换为<普通>,为非默认格式.\" style=\"height:25px\">\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("                <tr id=\"Box_C\">\r\n");
	templateBuilder.Append("                  <td colspan=\"2\" align=\"center\"><br/>\r\n");
	templateBuilder.Append("<p><font color=\"#FF0000\"><b>操作提示:</b></font><br/>\r\n");
	templateBuilder.Append("<ul>\r\n");
	templateBuilder.Append("<li>1.打开下载的Excel文件, 点菜单栏&quot;文件&quot; -&gt;&quot;另存为&quot; -&gt;保存类型选择为&quot;Excel 97-2003 工作簿(*.xls)&quot; -&gt;覆盖原文件.\r\n");
	templateBuilder.Append("<li>2.打开另存的文件,选中数字列-&gt;右键鼠标选择&quot;设置单元格格式&quot;-&gt;在弹出的对话框中选择第一个标签页&quot;数字&quot;-&gt;在分类栏中选择&quot;常规&quot;-&gt;点击&quot;确定按钮&quot;-&gt;保存并退出文档.<br />\r\n");
	templateBuilder.Append("<img src=\"/images/e_001.png\" >\r\n");
	templateBuilder.Append("</ul>\r\n");
	templateBuilder.Append("</p>\r\n");
	templateBuilder.Append("				  <input type=\"button\" id=\"bt_step_a\" style=\"margin:5px\" class=\"B_INPUT\" value=\"下一步\" /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr id=\"Box_D\" style=\"display:none;\">\r\n");
	templateBuilder.Append("                  <td colspan=\"2\" align=\"center\"><img src=\"images/loading.gif\" />数据处理中,该过程需要10-30分钟,请不要刷新,切换或关闭此页面!</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("              </form>\r\n");



	}	//end if


	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var Importdata = new TImportdata();\r\n");
	templateBuilder.Append("Importdata.setps = " + steps.ToString() + ";\r\n");
	 aspxrewriteurl = sDateTime.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("Importdata.sDateTime = '" + aspxrewriteurl.ToString() + "';\r\n");
	templateBuilder.Append("Importdata.ini();\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
