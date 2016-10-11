<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.mproduct_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:17. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/dialog.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/jTable.js\" language=\"javascript\">\r\n");


	if (ShowMSign == true)
	{

	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("dialog(\"授权[" + M_Config.m_Name.ToString().Trim() + "] " + M_Config.StoresName.ToString().Trim() + "\",'iframe:" + config.Taobao_Api_Authorize.ToString().Trim() + "" + M_Config.m_AppKey.ToString().Trim() + "',550,450,\"iframe\",'parent.HidBox();');\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}
	else
	{


	if (GoodsCatLastTimeDay>5)
	{

	templateBuilder.Append("	<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("		dialog(\"更新商品类目[" + M_Config.m_Name.ToString().Trim() + "] " + M_Config.StoresName.ToString().Trim() + "\",'iframe:/mgoodscat_do-" + M_Config.m_ConfigInfoID.ToString().Trim() + "-download.aspx',500,250,\"iframe\",'parent.HidBox();');\r\n");
	templateBuilder.Append("	</" + "script>\r\n");

	}	//end if


	}	//end if




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

	templateBuilder.Append("<script src=\"/public/js/m_product_do.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");

	if (Act=="DownLoad")
	{


	templateBuilder.Append("            <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\" id=\"tBox\" >\r\n");
	templateBuilder.Append("              <thead >\r\n");
	templateBuilder.Append("              <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                <td width=\"5%\" align=\"center\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"\" onclick=\"javascript:selectCheck(document.getElementById('form1'),this);\"/></td>\r\n");
	templateBuilder.Append("                <td width=\"30%\">商品名称</td>\r\n");
	templateBuilder.Append("                <td>对应系统产品名称</td>\r\n");
	templateBuilder.Append("                <td width=\"15%\">更新时间</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              </thead>\r\n");

	if (dList != null)
	{

	templateBuilder.Append("              <tbody id=\"dloop\">\r\n");

	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("              <tr id=\"tr_" + dl["num_iid"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("                <td align=\"center\" width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" title=\"" + dl["title"].ToString().Trim() + "\" id=\"ch_" + dl["num_iid"].ToString().Trim() + "\" value=\"" + dl["num_iid"].ToString().Trim() + "\"  cid=\"" + dl["cid"].ToString().Trim() + "\"/></td>\r\n");
	templateBuilder.Append("                <td width=\"30%\">" + dl["title"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                <td id=\"loop_" + dl["num_iid"].ToString().Trim() + "\" pid=\"" + dl["outer_id"].ToString().Trim() + "\">\r\n");

	if (dl["outer_name"].ToString().Trim()!="")
	{

	templateBuilder.Append("                <a href=\"javascript:void(0);\" onClick=\"javascript:M_Product_do.ShowProductTree('loop_" + dl["num_iid"].ToString().Trim() + "');\">" + dl["outer_name"].ToString().Trim() + "</a>\r\n");

	}
	else
	{

	templateBuilder.Append("               <a href=\"javascript:void(0);\" onClick=\"javascript:M_Product_do.ShowProductTree('loop_" + dl["num_iid"].ToString().Trim() + "');\">[未绑定]</a>\r\n");

	}	//end if

	templateBuilder.Append("                </td>\r\n");
	templateBuilder.Append("                <td width=\"15%\">" + dl["modified"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");

	}	//end loop

	templateBuilder.Append("              </tbody>\r\n");

	}	//end if

	templateBuilder.Append("              <tfoot>\r\n");
	templateBuilder.Append("              <tr>\r\n");
	templateBuilder.Append("                <td colspan=\"4\">\r\n");

	if (pageindex>1)
	{

	templateBuilder.Append("                <a href=\"javascript:void(0);\" onclick=\"M_Product_do.PageUp();\"><-上一页</a>\r\n");

	}	//end if

	templateBuilder.Append("                <a href=\"javascript:void(0);\" onclick=\"M_Product_do.PageDown();\">下一页-></a></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </tfoot>\r\n");
	templateBuilder.Append("            </table>\r\n");
	templateBuilder.Append("            <div style=\"height:30px\"></div>\r\n");
	templateBuilder.Append("            <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"center\">\r\n");
	templateBuilder.Append("                    <input type=\"button\" name=\"bt_download\" id=\"bt_download\" value=\" 下载选中 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("                    <input type=\"button\" name=\"bt_cancel\" id=\"bt_cancel\" value=\" 取消 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </div>\r\n");



	}	//end if


	if (Act=="UpdateNum")
	{


	templateBuilder.Append("            <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\" id=\"tBox\" >\r\n");
	templateBuilder.Append("              <thead >\r\n");
	templateBuilder.Append("              <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                <td width=\"5%\" align=\"center\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"\" onclick=\"javascript:selectCheck(document.getElementById('form1'),this);\"/></td>\r\n");
	templateBuilder.Append("                <td >商品名称</td>\r\n");
	templateBuilder.Append("                <td width=\"20%\">数量</td>\r\n");
	templateBuilder.Append("                <td width=\"20%\">更新时间</td>\r\n");
	templateBuilder.Append("              </tr>\r\n");
	templateBuilder.Append("              </thead>\r\n");

	if (dList != null)
	{

	templateBuilder.Append("  <tbody id=\"dloop\">\r\n");

	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("  <tr id=\"tr_" + dl["num_iid"].ToString().Trim() + "\" pid=\"" + dl["outer_id"].ToString().Trim() + "\" num_iid=\"" + dl["num_iid"].ToString().Trim() + "\"  title=\"" + dl["title"].ToString().Trim() + "\" pname=\"" + dl["pName"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("	<td align=\"center\" width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" title=\"" + dl["title"].ToString().Trim() + "\" id=\"ch_" + dl["num_iid"].ToString().Trim() + "\" value=\"" + dl["num_iid"].ToString().Trim() + "\"  cid=\"" + dl["cid"].ToString().Trim() + "\"/></td>\r\n");
	templateBuilder.Append("	<td >" + dl["title"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("	<td  width=\"20%\" align=\"right\" id=\"loop_" + dl["num_iid"].ToString().Trim() + "\">\r\n");
	templateBuilder.Append("	<a href=\"javascript:void(0);\" id=\"a_" + dl["num_iid"].ToString().Trim() + "\" onclick=\"javascript:M_Product_do.ShowNum('tr_" + dl["num_iid"].ToString().Trim() + "');\"> " + dl["mNum"].ToString().Trim() + " </a>\r\n");
	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("	<td width=\"20%\" align=\"right\">" + dl["modified"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");

	}	//end loop

	templateBuilder.Append("  </tbody>\r\n");

	}	//end if

	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div style=\"height:30px\"></div>\r\n");
	templateBuilder.Append("<div id=\"footer_tool\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("	<tr>\r\n");
	templateBuilder.Append("	  <td align=\"center\">\r\n");
	templateBuilder.Append("		<input type=\"button\" name=\"bt_updatenum\" id=\"bt_updatenum\" style=\"width:150px\" value=\" 更新选中(更新到商城) \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("		<input type=\"button\" name=\"bt_cancel\" id=\"bt_cancel\" value=\" 取消 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("	  </td>\r\n");
	templateBuilder.Append("	</tr>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("</div>\r\n");



	}	//end if


	if (Act=="Edit")
	{


	templateBuilder.Append("            <table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\" id=\"tBox\" >\r\n");
	templateBuilder.Append("              <thead >\r\n");
	templateBuilder.Append("              <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                <td colspan=\"4\"><b>" + mGoods.title.ToString().Trim() + "(" + mGoods.ProductsName.ToString().Trim() + ")</b></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              <tr class=\"tBar\">\r\n");
	templateBuilder.Append("                <td width=\"2%\" align=\"center\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"\" onclick=\"javascript:selectCheck(document.getElementById('form1'),this);\"/></td>\r\n");
	templateBuilder.Append("                <td width=\"30%\" >属性</td>\r\n");
	templateBuilder.Append("                <td width=\"30%\">值</td>\r\n");
	templateBuilder.Append("                <td>说明</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </thead>\r\n");
	templateBuilder.Append("  <tbody id=\"dloop\">\r\n");
	templateBuilder.Append("  <tr  >\r\n");
	templateBuilder.Append("	<td align=\"center\" width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"cid\" /></td>\r\n");
	templateBuilder.Append("	<td width=\"30%\" >叶子类目id</td>\r\n");
	templateBuilder.Append("	<td  width=\"30%\" ><textarea name=\"cid\" id=\"cid\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.cid.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("	<td >&nbsp;</td>\r\n");
	templateBuilder.Append("	</tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("      <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"props\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">商品属性列表</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"props\" id=\"props\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.props.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>格式:pid:vid;pid:vid。属性的pid调用taobao.itemprops.get取得，属性值的vid用taobao.itempropvalues.get取得vid。   如果该类目下面没有属性，可以不用填写。如果有属性，必选属性必填，其他非必选属性可以选择不填写.属性不能超过35对。所有属性加起来包括分割符不能超过549字节，单个属性没有限制。   如果有属性是可输入的话，则用字段input_str填入属性的值。 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"num\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">商品数量</td>\r\n");
	templateBuilder.Append("       <td width=\"30%\"><textarea name=\"num\" id=\"num\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.num.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>取值范围：大于零的整数，并需要等于所有Sku数量的和 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"price\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">商品价格</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"price\" id=\"price\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.price.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>取值范围:0-100000000;精确到2位小数;单位:元。如:200.07，表示:200元7分。需要在正确的价格区间内。 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"title\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">宝贝标题</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"title\" id=\"title\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.title.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>不能超过60字节,受违禁词控制 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"desc\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">商品描述</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"desc\" id=\"desc\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.m_desc.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>字数要大于5个字节，小于25000个字节 ，受违禁词控制 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"location_state\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">所在地省份</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"location_state\" id=\"location_state\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\"></textarea></td>\r\n");
	templateBuilder.Append("      <td>如浙江 具体可以下载http://dl.open.taobao.com/sdk/商品城市列表.rar 取到 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"location_city\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">所在地城市</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"location_city\" id=\"location_city\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\"></textarea></td>\r\n");
	templateBuilder.Append("      <td>如杭州 具体可以下载http://dl.open.taobao.com/sdk/商品城市列表.rar 取到 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"post_fee\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">平邮费用</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"post_fee\" id=\"post_fee\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.post_fee.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>取值范围:0-100000000;精确到2位小数;单位:元。如:5.07，表示:5元7分,   注:post_fee,express_fee,ems_fee需一起填写 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"express_fee\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">快递费用</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"express_fee\" id=\"express_fee\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.express_fee.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>取值范围:0-100000000;精确到2位小数;单位:元。如:15.07，表示:15元7分 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"ems_fee\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">ems费用</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"ems_fee\" id=\"ems_fee\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.ems_fee.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>取值范围:0-100000000;精确到2位小数;单位:元。如:25.07，表示:25元7分 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"list_time\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">上架时间</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"list_time\" id=\"list_time\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.list_time.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>如2008-05-26 09:12:00 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"increment\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">加价幅度</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"increment\" id=\"increment\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.increment.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>如果为0，代表系统代理幅度 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"image\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">商品图片</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"image\" id=\"image\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\"></textarea></td>\r\n");
	templateBuilder.Append("      <td>类型:JPG,GIF;最大长度:500k <br />\r\n");
	templateBuilder.Append("        支持的文件类型：gif,jpg,jpeg,png </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"stuff_status\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">商品新旧程度</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"stuff_status\" id=\"stuff_status\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.stuff_status.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>可选值:new（全新）,unused（闲置）,second（二手）。 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"auction_point\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">商品的积分返点比例</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"auction_point\" id=\"auction_point\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.auction_point.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>如：5 表示返点比例0.5%. 注意：返点比例必须是&gt;0的整数，而且最大是90,即为9%.B商家在发布非虚拟商品时，返点必须是   5的倍数，即0.5%的倍数。其它是1的倍数，即0.1%的倍数。 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"property_alias\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">属性值别名</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"property_alias\" id=\"property_alias\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.property_alias.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>如pid:vid:别名;pid1:vid1:别名1， pid:属性id vid:值id。总长度不超过512字节 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"input_pids\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">用户自行输入的类目属性ID串</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"input_pids\" id=\"input_pids\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.input_pids.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>结构：&quot;pid1,pid2,pid3&quot;，如：&quot;20000&quot;（表示品牌） 注：通常一个类目下用户可输入的关键属性不超过1个。 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"sku_quantities\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">更新的Sku的数量串</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"sku_quantities\" id=\"sku_quantities\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\"></textarea></td>\r\n");
	templateBuilder.Append("      <td>结构如：num1,num2,num3 如:2,3,4 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"sku_prices\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">更新的Sku的价格串</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"sku_prices\" id=\"sku_prices\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\"></textarea></td>\r\n");
	templateBuilder.Append("      <td>结构如：10.00,5.00,… 精确到2位小数;单位:元。如:200.07，表示:200元7分 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"sku_properties\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">更新的Sku的属性串</td>\r\n");
	templateBuilder.Append("       <td width=\"30%\"><textarea name=\"sku_properties\" id=\"sku_properties\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\"></textarea></td>\r\n");
	templateBuilder.Append("      <td>调用taobao.itemprops.get获取类目属性，如果属性是销售属性，再用taobao.itempropvalues.get取得vid。格式:pid:vid;pid:vid。该字段内的销售属性也需要在props字段填写   . 规则：如果该SKU存在旧商品，则修改；否则新增Sku。如果更新时有对Sku进行操作，则Sku的properties一定要传入。 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"seller_cids\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">重新关联商品与店铺类目</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"seller_cids\" id=\"seller_cids\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.seller_cids.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>结构:&quot;,cid1,cid2,...,&quot;，如果店铺类目存在二级类目，必须传入子类目cids。 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"postage_id\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">宝贝所属的运费模板ID</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"postage_id\" id=\"postage_id\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.postage_id.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>模板可以通过taobao.postages.get获得 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"outer_id\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">商家绑定商品编码</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"outer_id\" id=\"outer_id\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.outer_id.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"product_id\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">商品所属的产品ID</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"product_id\" id=\"product_id\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.product_id.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>(B商家发布商品需要用) </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"pic_path\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">商品主图需要关联的图片空间的相对url</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"pic_path\" id=\"pic_path\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\"></textarea></td>\r\n");
	templateBuilder.Append("      <td>这个url所对应的图片必须要属于当前用户。pic_path和image只需要传入一个,如果两个都传，默认选择pic_path </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"auto_fill\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">代充商品类型</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"auto_fill\" id=\"auto_fill\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.auto_fill.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>只有少数类目下的商品可以标记上此字段，具体哪些类目可以上传可以通过taobao.itemcat.features.get获得。在代充商品的类目下，不传表示不标记商品类型（交易搜索中就不能通过标记搜到相关的交易了）。可选类型：   no_mark(不做类型标记) time_card(点卡软件代充) fee_card(话费软件代充) </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"sku_outer_ids\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">Sku的外部id串</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"sku_outer_ids\" id=\"sku_outer_ids\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\"></textarea></td>\r\n");
	templateBuilder.Append("      <td>结构如：1234,1342,… sku_properties, sku_quantities, sku_prices,   sku_outer_ids在输入数据时要一一对应，如果没有sku_outer_ids也要写上这个参数，入参是&quot;,&quot;(这个是两个sku的示列，逗号数应该是sku个数减1)；该参数最大长度是512个字节 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"is_taobao\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">是否在淘宝上显示</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"is_taobao\" id=\"is_taobao\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.is_taobao.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td> </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"is_ex\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">是否在外店显示</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"is_ex\" id=\"is_ex\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.is_ex.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td> </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"is_3D\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">是否是3D</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"is_3D\" id=\"is_3D\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.is_3D.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td> </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"is_replace_sku\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">是否替换sku</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"is_replace_sku\" id=\"is_replace_sku\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\"></textarea></td>\r\n");
	templateBuilder.Append("      <td> </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"input_str\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">用户自行输入的子属性名和属性值</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"input_str\" id=\"input_str\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.input_str.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>结构:&quot;父属性值;一级子属性名;一级子属性值;二级子属性名;自定义输入值,....&quot;,如：&ldquo;耐克;耐克系列;科比系列;科比系列;2K5,Nike乔丹鞋;乔丹系列;乔丹鞋系列;乔丹鞋系列;json5&rdquo;，多个自定义属性用','分割，input_str需要与input_pids一一对应，注：通常一个类目下用户可输入的关键属性不超过1个。所有属性别名加起来不能超过3999字节。 </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"lang\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">商品文字的版本</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"lang\" id=\"lang\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\"></textarea></td>\r\n");
	templateBuilder.Append("      <td>繁体传入&rdquo;zh_HK&rdquo;，简体传入&rdquo;zh_CN&rdquo; </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"has_discount\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">支持会员打折</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"has_discount\" id=\"has_discount\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.has_discount.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>可选值:true,false; </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"has_showcase\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">橱窗推荐</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"has_showcase\" id=\"has_showcase\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.has_showcase.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>可选值:true,false; </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"approve_status\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">商品上传后的状态</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"approve_status\" id=\"approve_status\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.approve_status.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>可选值:onsale（出售中）,instock（库中） </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"freight_payer\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">运费承担方式</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"freight_payer\" id=\"freight_payer\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.freight_payer.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>运费承担方式。可选值:seller（卖家承担）,buyer(买家承担); </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"valid_thru\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">有效期</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"valid_thru\" id=\"valid_thru\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.valid_thru.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>可选值:7,14;单位:天; </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"has_invoice\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">是否有发票</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"has_invoice\" id=\"has_invoice\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.has_invoice.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>可选值:true,false (商城卖家此字段必须为true) </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"has_warranty\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">是否有保修</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"has_warranty\" id=\"has_warranty\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.has_warranty.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>可选值:true,false; </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"after_sale_id\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">售后服务说明模板id</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"after_sale_id\" id=\"after_sale_id\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\"></textarea></td>\r\n");
	templateBuilder.Append("      <td> </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"sell_promise\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">是否承诺退换货服务</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"sell_promise\" id=\"sell_promise\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.sell_promise.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td>虚拟商品无须设置此项! </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"cod_postage_id\" /></td>\r\n");
	templateBuilder.Append("      <td width=\"30%\">货到付款运费模板ID</td>\r\n");
	templateBuilder.Append("      <td width=\"30%\"><textarea name=\"cod_postage_id\" id=\"cod_postage_id\" cols=\"45\" rows=\"5\" style=\"width:90%;height:90%\">" + mGoods.cod_postage_id.ToString().Trim() + "</textarea></td>\r\n");
	templateBuilder.Append("      <td></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  </tbody>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<div style=\"height:30px\"></div>\r\n");
	templateBuilder.Append("<div id=\"footer_tool\">\r\n");
	templateBuilder.Append("  <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("	<tr>\r\n");
	templateBuilder.Append("	  <td align=\"center\">\r\n");
	templateBuilder.Append("		<input type=\"button\" name=\"bt_edit\" id=\"bt_edit\" style=\"width:150px\" value=\" 更新选中(更新到商城) \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("		<input type=\"button\" name=\"bt_cancel\" id=\"bt_cancel\" value=\" 取消 \" class=\"B_INPUT\">\r\n");
	templateBuilder.Append("	  </td>\r\n");
	templateBuilder.Append("	</tr>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("</div>\r\n");



	}	//end if

	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var tf = new TableFixed(\"tBox\");\r\n");
	templateBuilder.Append("tf.Clone();\r\n");
	templateBuilder.Append("var M_Product_do = new TM_Product_do();\r\n");
	templateBuilder.Append("M_Product_do.MConfigID = " + M_Config.m_ConfigInfoID.ToString().Trim() + ";\r\n");
	templateBuilder.Append("M_Product_do.PageIndex = " + pageindex.ToString() + ";\r\n");
	templateBuilder.Append("M_Product_do.ActStr = '" + Act.ToString() + "';\r\n");
	templateBuilder.Append("M_Product_do.ini();\r\n");
	templateBuilder.Append("function HidBox()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	M_Product_do.HidUserBox();\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("function ReCall(rObj)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	M_Product_do.numReCall(rObj);\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("function SetProductID(reObj,treObj)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	M_Product_do.SetProductID(reObj,treObj);\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("addTableListener(document.getElementById(\"tBoxs\"),0,0);\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
