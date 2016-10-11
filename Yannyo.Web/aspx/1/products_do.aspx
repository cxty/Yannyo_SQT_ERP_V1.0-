<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.products_do" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:30. 
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
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.mcdropdown.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.bgiframe.js\"></" + "script>\r\n");
	templateBuilder.Append("<link type=\"text/css\" href=\"templates/" + templatepath.ToString() + "/css/jquery.mcdropdown.css\" rel=\"stylesheet\" media=\"all\" />\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.jUploader-1.01.min.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/product_do.js \"></" + "script>\r\n");

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

	templateBuilder.Append("            <form name=\"bForm\" id=\"bForm\" action=\"\" method=\"post\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"dBox\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">条码</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"pBarcode\" id=\"pBarcode\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.pBarcode.ToString().Trim() + "\" oldvalue=\"" + pi.pBarcode.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"只能填写数字格式\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">名称</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"pName\" id=\"pName\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.pName.ToString().Trim() + "\" oldvalue=\"" + pi.pName.ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"可填写少于50个的中英文字符\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">品牌</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"pBrand\" id=\"pBrand\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.pBrand.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"商品的品牌\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">分类</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input type=\"hidden\" id=\"ProductClassID\" name=\"ProductClassID\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.ProductClassID.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("                  <input type=\"text\" name=\"category\" id=\"category\" value=\"\" />\r\n");
	templateBuilder.Append("                  <ul id=\"categorymenu\" class=\"mcdropdown_menu\">" + ProductClassStr.ToString() + "</ul>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">规格</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"pStandard\" id=\"pStandard\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.pStandard.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"商品的规格\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">小单位</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"pUnits\" id=\"pUnits\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.pUnits.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"商品的最小计算单位\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">大单位</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"pMaxUnits\" id=\"pMaxUnits\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.pMaxUnits.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"商品的最大计算单位\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">装件数</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">1*\r\n");
	templateBuilder.Append("                  <input name=\"pToBoxNo\" id=\"pToBoxNo\" style=\"width:30px\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.pToBoxNo.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"商品每件装箱的数量\"\r\n");
	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("                  入</td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">默认成本</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"pPrice\" id=\"pPrice\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.pPrice.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"只能填写数字格式\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">默认售价</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"pSellingPrice\" id=\"pSellingPrice\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.pSellingPrice.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"只能填写数字格式\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">生产厂家</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"pProducer\" id=\"pProducer\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.pProducer.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"商品的生产厂商\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">保质期</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"pExpireDay\" id=\"pExpireDay\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.pExpireDay.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"商品的保质期\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td  align=\"right\" class=\"ltd\">产地</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("                  <input name=\"pAddress\" id=\"pAddress\" type=\"text\" \r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("value=\"" + pi.pAddress.ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(" showtitle=\"商品的出产地方\"\r\n");
	templateBuilder.Append("                  /></td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("				<tr>\r\n");
	templateBuilder.Append("                  <td align=\"right\" class=\"ltd\">状态:</td>\r\n");
	templateBuilder.Append("                  <td align=\"left\" class=\"rtd\">\r\n");
	templateBuilder.Append("				  <input name=\"pState\" type=\"checkbox\" value=\"0\" id=\"pState\" class=\"B_Check\"\r\n");

	if (Act=="Edit")
	{


	if (pi.pState.ToString() == "0")
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
	templateBuilder.Append("                <tr><td colspan=\"2\" align=\"center\" >自定义字段:<input type=\"hidden\" id=\"ProductFieldValue\" name=\"ProductFieldValue\"/></td></tr>\r\n");
	templateBuilder.Append("                <tbody id=\"ProductField\">\r\n");
	templateBuilder.Append("                </tbody>\r\n");
	templateBuilder.Append("                </table>\r\n");
	templateBuilder.Append("            <div style=\"height:50px\"></div>\r\n");
	templateBuilder.Append("            <div id=\"footer_tool\">\r\n");
	templateBuilder.Append("              <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                  <td align=\"center\">\r\n");
	templateBuilder.Append("                  	<input type=\"button\" id=\"button1\" style=\"margin:5px\" class=\"B_INPUT\" value=\"确定\" onClick=\"javascript:CheckF();\"/>\r\n");
	templateBuilder.Append("                  	<input type=\"button\" id=\"button2\" style=\"margin:5px\" class=\"B_INPUT\" value=\"取消\" onClick=\"javascript:window.parent.HidBox();\" />\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("                </tr>\r\n");
	templateBuilder.Append("              </table>\r\n");
	templateBuilder.Append("            </div>\r\n");
	templateBuilder.Append("            </form>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var ProductDo = new TProductDo();\r\n");
	templateBuilder.Append("$(document).ready(function (){\r\n");
	templateBuilder.Append("	$(\"#category\").mcDropdown(\"#categorymenu\",{\r\n");
	templateBuilder.Append("		select:function(){\r\n");
	templateBuilder.Append("			var ddarray = this.getValue();\r\n");
	templateBuilder.Append("			if(ddarray.length>0)\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				ProductDo.iniField(Number(ddarray[0]));\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	});\r\n");
	templateBuilder.Append("	ProductDo.ProductFieldValue = '" + ProductFieldValueList_Json.ToString() + "';\r\n");
	templateBuilder.Append("	ProductDo.ini();\r\n");
	templateBuilder.Append("});\r\n");

	if (Act=="Edit")
	{

	templateBuilder.Append("$(document).ready(function (){\r\n");
	templateBuilder.Append("var dd = $(\"#category\").mcDropdown();\r\n");
	templateBuilder.Append("		dd.setValue(" + pi.ProductClassID.ToString().Trim() + ");\r\n");
	templateBuilder.Append("});\r\n");

	}	//end if

	templateBuilder.Append("$().ready(function(){\r\n");
	templateBuilder.Append("$('#pBarcode').autocomplete('Services/CAjax.aspx',{ \r\n");
	templateBuilder.Append("			width: 200,\r\n");
	templateBuilder.Append("			scroll: true,\r\n");
	templateBuilder.Append("			autoFill: true,\r\n");
	templateBuilder.Append("			scrollHeight: 200,\r\n");
	templateBuilder.Append("			matchContains: true,\r\n");
	templateBuilder.Append("			dataType: 'json',\r\n");
	templateBuilder.Append("			extraParams:{\r\n");
	templateBuilder.Append("				'do':'GetProductsList',\r\n");
	templateBuilder.Append("				'RCode':Math.random(),\r\n");
	templateBuilder.Append("				'ProductsName':function(){return $('#pBarcode').val();}\r\n");
	templateBuilder.Append("			},\r\n");
	templateBuilder.Append("			parse: function(data) {\r\n");
	templateBuilder.Append("					var rows = [];  \r\n");
	templateBuilder.Append("					var tArray = data.results;\r\n");
	templateBuilder.Append("					 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("					  rows[rows.length] = {    \r\n");
	templateBuilder.Append("						data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("						value:tArray[i].value,\r\n");
	templateBuilder.Append("						code:tArray[i].info,    \r\n");
	templateBuilder.Append("						result:tArray[i].info    \r\n");
	templateBuilder.Append("						};    \r\n");
	templateBuilder.Append("					  }\r\n");
	templateBuilder.Append("				   return rows; \r\n");
	templateBuilder.Append("				 },\r\n");
	templateBuilder.Append("			formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("				   return row;\r\n");
	templateBuilder.Append("			},\r\n");
	templateBuilder.Append("			formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("						return row[i].code; \r\n");
	templateBuilder.Append("			},\r\n");
	templateBuilder.Append("			formatResult: function(row) { \r\n");
	templateBuilder.Append("						return row.code;\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		  }).result(function(event, data, formatted) {\r\n");
	templateBuilder.Append("				$(\"#pName\").val((formatted!=null)?formatted:\"\");\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		  );\r\n");
	templateBuilder.Append("});\r\n");
	templateBuilder.Append("			function CheckF()\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				var dd = $(\"#category\").mcDropdown();\r\n");
	templateBuilder.Append("				ProductDo.sub_form();\r\n");
	templateBuilder.Append("				if(dd!=''){\r\n");
	templateBuilder.Append("				var ddarray = dd.getValue();\r\n");
	templateBuilder.Append("				if(ddarray.length>0)\r\n");
	templateBuilder.Append("				{\r\n");
	templateBuilder.Append("					if(Number(ddarray[0])>0){\r\n");
	templateBuilder.Append("						Sys.getObj('ProductClassID').value = Number(ddarray[0]);\r\n");
	templateBuilder.Append("					if(Sys.getObj('pBarcode').value != '')\r\n");
	templateBuilder.Append("					{\r\n");
	templateBuilder.Append("						if(Sys.getObj('pName').value != '')\r\n");
	templateBuilder.Append("						{\r\n");
	templateBuilder.Append("							if(Sys.getObj('pBrand').value != '')\r\n");
	templateBuilder.Append("							{\r\n");
	templateBuilder.Append("									if(Sys.getObj('pUnits').value != '')\r\n");
	templateBuilder.Append("									{\r\n");
	templateBuilder.Append("										if(Sys.getObj('pToBoxNo').value != '')\r\n");
	templateBuilder.Append("										{\r\n");
	templateBuilder.Append("											if(Sys.getObj('pPrice').value != '')\r\n");
	templateBuilder.Append("											{\r\n");
	templateBuilder.Append("												Sys.getObj('bForm').submit();\r\n");
	templateBuilder.Append("											}\r\n");
	templateBuilder.Append("											else\r\n");
	templateBuilder.Append("											{\r\n");
	templateBuilder.Append("												alert('默认成本不能为空!');	\r\n");
	templateBuilder.Append("											}\r\n");
	templateBuilder.Append("										}\r\n");
	templateBuilder.Append("										else\r\n");
	templateBuilder.Append("										{\r\n");
	templateBuilder.Append("											alert('装件数不能为空!');	\r\n");
	templateBuilder.Append("										}\r\n");
	templateBuilder.Append("									}\r\n");
	templateBuilder.Append("									else\r\n");
	templateBuilder.Append("									{\r\n");
	templateBuilder.Append("										alert('单位不能为空!');	\r\n");
	templateBuilder.Append("									}\r\n");
	templateBuilder.Append("							}\r\n");
	templateBuilder.Append("							else\r\n");
	templateBuilder.Append("							{\r\n");
	templateBuilder.Append("								alert('品牌不能为空!');	\r\n");
	templateBuilder.Append("							}\r\n");
	templateBuilder.Append("						}\r\n");
	templateBuilder.Append("						else\r\n");
	templateBuilder.Append("						{\r\n");
	templateBuilder.Append("							alert('名称不能为空!');	\r\n");
	templateBuilder.Append("						}\r\n");
	templateBuilder.Append("					}\r\n");
	templateBuilder.Append("					else\r\n");
	templateBuilder.Append("					{\r\n");
	templateBuilder.Append("						alert('条码不能为空!');	\r\n");
	templateBuilder.Append("					}\r\n");
	templateBuilder.Append("					}else\r\n");
	templateBuilder.Append("				{\r\n");
	templateBuilder.Append("					alert('请选择产品分类!');	\r\n");
	templateBuilder.Append("				}\r\n");
	templateBuilder.Append("				}else\r\n");
	templateBuilder.Append("				{\r\n");
	templateBuilder.Append("					alert('请选择产品分类!');	\r\n");
	templateBuilder.Append("				}\r\n");
	templateBuilder.Append("				}else\r\n");
	templateBuilder.Append("				{\r\n");
	templateBuilder.Append("					alert('请选择产品分类!');	\r\n");
	templateBuilder.Append("				}\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("			</" + "script>\r\n");

	}	//end if


	}	//end if


	}	//end if


	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	Response.Write(templateBuilder.ToString());
}
</script>
