<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.dataanalysis" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:03. 
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
	templateBuilder.Append("<link rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/default.css\" type=\"text/css\" media=\"all\"  />\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/index.css\" type=\"text/css\" media=\"all\"  />\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"templates/" + templatepath.ToString() + "/toolbar.css\" />\r\n");
	templateBuilder.Append("" + link.ToString() + "\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/comm.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/swfobject.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/menu.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/dialog.js\"></" + "script>\r\n");
	templateBuilder.Append("<link type=\"text/css\" rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/syntax/!style.css\"/>\r\n");
	templateBuilder.Append("<link type=\"text/css\" rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/!style.css\"/>\r\n");
	templateBuilder.Append("<link type=\"text/css\" rel=\"stylesheet\" href=\"templates/" + templatepath.ToString() + "/syntax/style.css\"/>\r\n");
	templateBuilder.Append("<!--\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"templates/" + templatepath.ToString() + "/syntax/!script.js\"></" + "script>\r\n");
	templateBuilder.Append("-->\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.alerts.js\"></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.alerts.css\"></link>\r\n");
	templateBuilder.Append("" + script.ToString() + "\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/public.js\"></" + "script>\r\n");
	templateBuilder.Append("</head>\r\n");


	templateBuilder.Append("<body>\r\n");
	templateBuilder.Append("<div class=\"top\">\r\n");
	templateBuilder.Append("  <div class=\"top_inner\">\r\n");
	templateBuilder.Append("    <div class=\"sitelink\">\r\n");

	if (userid>0)
	{

	templateBuilder.Append("	<a>您好 " + username.ToString() + " </a><span class=\"separator\">|</span>\r\n");
	templateBuilder.Append("	<a href=\"https://docs.google.com/a/bdu9.com\" target=\"_blank\">企业文档</a> <span class=\"separator\">|</span> <a href=\"https://mail.google.com/a/bdu9.com\" target=\"_blank\">企业邮箱</a> <span class=\"separator\">|</span> <a href=\"mailto:cxty@qq.com\">反馈</a> \r\n");
	templateBuilder.Append("	<span class=\"separator\">|</span> <a href=\"javascript:void(0);\" id=\"top_edit_pwd\">修改密码</a>\r\n");
	templateBuilder.Append("	<span class=\"separator\">|</span> <a href=\"javascript:void(0);\" id=\"top_clear_caches\">清理缓存</a>	\r\n");
	templateBuilder.Append("	<span class=\"separator\">|</span> <a href=\"logout.aspx\">退出系统</a>\r\n");

	}	//end if

	templateBuilder.Append("	</div>\r\n");
	templateBuilder.Append("   <span class=\"logo\">" + config.Systitle.ToString().Trim() + "</span>\r\n");
	templateBuilder.Append("  </div>\r\n");

	if (userid>0)
	{


	templateBuilder.Append("<div class=\"mainnav\">\r\n");
	templateBuilder.Append("<!-- 菜单 START -->\r\n");
	templateBuilder.Append("<div id=\"menubar\">\r\n");
	templateBuilder.Append("	<ul id=\"t_menus\" class=\"menus\">\r\n");
	templateBuilder.Append("		<li class=\"current-cat\"><a title=\"Home\" href=\"default.aspx\">首页</a></li>\r\n");

	if (CheckUserPopedoms("X"))
	{

	templateBuilder.Append("		<li class=\"cat-item cat-item-1\"><a href=\"javascript:void(0);\" title=\"系统管理平台\">管理平台</a>\r\n");
	templateBuilder.Append("			<ul class=\"children\">\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-11\"><a href=\"javascript:void(0);\" >操作员管理</a>\r\n");
	templateBuilder.Append("					<ul class=\"children\">\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-113\"><a href=\"usermanageclass.aspx\">系统用户组</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-111\"><a href=\"usermanage.aspx?Act=Add\">添加新操作员</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-112\"><a href=\"usermanage.aspx\">操作员列表</a></li>\r\n");
	templateBuilder.Append("					</ul>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-12\"><a href=\"javascript:void(0);\" >系统配置</a>\r\n");
	templateBuilder.Append("					<ul class=\"children\">\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-121\"><a href=\"config.aspx\">基础配置</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-126\"><a href=\"orderfield.aspx\" >单据自定义字段</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-127\"><a href=\"productfield.aspx\" >商品自定义字段</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-122\"><a href=\"mconfig.aspx\">网店配置</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-123\"><a href=\"datatomail.aspx\">导出数据邮件转发</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-124\"><a href=\"config-recache.aspx\">重建缓存</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-125\"><a href=\"logs.aspx\">操作记录</a></li>\r\n");
	templateBuilder.Append("					</ul>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("			</ul>\r\n");
	templateBuilder.Append("		</li>\r\n");

	}	//end if

	templateBuilder.Append("		<li class=\"cat-item cat-item-2\"><a href=\"javascript:void(0);\" >基础数据</a>\r\n");
	templateBuilder.Append("			<ul class=\"children\">\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-21\">\r\n");
	templateBuilder.Append("					<a href=\"javascript:void(0);\" >分类体系</a>\r\n");
	templateBuilder.Append("					<ul class=\"children\">\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-211\"><a href=\"productclass.aspx\" >商品分类</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-212\"><a href=\"DepartmentsClass.aspx\" >部门分类</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-213\"><a href=\"SupplierClass.aspx\" >供货商分类</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-214\"><a href=\"CustomersClass.aspx\" >客户分类</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-215\"><a href=\"diqu.aspx\" >地区分类</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-216\"><a href=\"PriceClass.aspx\" >价格分类</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-218\"><a href=\"storageclass.aspx\" >仓库分类</a></li>\r\n");
	templateBuilder.Append("						<!--<li class=\"cat-item cat-item-219\"><a href=\"feessubjectclass.aspx\" >科目设置</a></li>-->\r\n");
	templateBuilder.Append("					</ul>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-22\"><a href=\"javascript:void(0);\" >基础档案</a>\r\n");
	templateBuilder.Append("					<ul class=\"children\">\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-221\"><a href=\"storage.aspx\" >仓库档案</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-222\"><a href=\"products.aspx\" >商品档案</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-223\"><a href=\"supplier.aspx\" >供货商档案</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-224\"><a href=\"stores.aspx\" >客户档案</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-225\"><a href=\"yhsys.aspx\" >超市系统</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-226\"><a href=\"paymentsystem.aspx\" >结算系统</a></li>\r\n");
	templateBuilder.Append("						<!--<li class=\"cat-item cat-item-227\"><a href=\"banklist.aspx\" >资金帐户</a></li>-->\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-228\">\r\n");
	templateBuilder.Append("							<a href=\"productpool.aspx\" >产品联营</a>\r\n");
	templateBuilder.Append("						</li>\r\n");
	templateBuilder.Append("					</ul>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-23\"><a href=\"javascript:void(0);\" >价格管理</a>\r\n");
	templateBuilder.Append("					<ul class=\"children\">\r\n");
	templateBuilder.Append("						<!--<li class=\"cat-item cat-item-232\"><a href=\"#\" >供应商价格</a></li>-->\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-233\"><a href=\"priceclassdefaultprice.aspx\" >价格类型默认价格</a></li>\r\n");
	templateBuilder.Append("					</ul>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-24\"><a href=\"javascript:void(0);\" >期初数据</a>\r\n");
	templateBuilder.Append("					<ul class=\"children\">\r\n");
	templateBuilder.Append("						<!--<li class=\"cat-item cat-item-241\"><a href=\"supplier_apmoney.aspx\" >应付期初设置</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-242\"><a href=\"stores_armoney.aspx\" >应收期初设置</a></li>-->\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-243\"><a href=\"Products_Beginning.aspx\" >期初商品设置</a></li>\r\n");
	templateBuilder.Append("						<!--<li class=\"cat-item cat-item-244\"><a href=\"banklist_Beginning.aspx\" >资金帐户期初设置</a></li>-->\r\n");
	templateBuilder.Append("					</ul>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("			</ul>\r\n");
	templateBuilder.Append("		</li>\r\n");
	templateBuilder.Append("		<li class=\"cat-item cat-item-3\"><a href=\"javascript:void(0);\" >日常业务</a>\r\n");
	templateBuilder.Append("			<ul class=\"children\">\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-31\">\r\n");
	templateBuilder.Append("					<a href=\"javascript:void(0);\" >采购</a>\r\n");
	templateBuilder.Append("					<ul class=\"children\">\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-311\"><a href=\"orderlist-1.aspx\" >采购入库</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-312\"><a href=\"orderlist-2.aspx\" >采购退货</a></li>\r\n");
	templateBuilder.Append("					</ul>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-32\">\r\n");
	templateBuilder.Append("                    <a href=\"javascript:void(0);\" >销售</a>\r\n");
	templateBuilder.Append("                    <ul class=\"children\">\r\n");
	templateBuilder.Append("                        <li class=\"cat-item cat-item-321\"><a href=\"orderlist-3.aspx\" >销售发货</a></li>\r\n");
	templateBuilder.Append("                        <li class=\"cat-item cat-item-322\"><a href=\"orderlist-4.aspx\" >销售退货</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-323\"><a href=\"orderlist-5.aspx\" >赠品</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-324\"><a href=\"orderlist-6.aspx\" >样品</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-325\"><a href=\"orderlist-7.aspx\" >代购</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-326\"><a href=\"orderlist-11.aspx\" >换货</a></li>\r\n");
	templateBuilder.Append("                    </ul>\r\n");
	templateBuilder.Append("                </li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-33\">\r\n");
	templateBuilder.Append("                    <a href=\"javascript:void(0);\" >仓库</a>\r\n");
	templateBuilder.Append("                    <ul class=\"children\">\r\n");
	templateBuilder.Append("                        <li class=\"cat-item cat-item-331\"><a href=\"orderlist-8.aspx\" >库存调整</a></li>\r\n");
	templateBuilder.Append("                        <li class=\"cat-item cat-item-332\"><a href=\"orderlist-9.aspx\" >库存调拨</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-333\"><a href=\"orderlist-10.aspx\" >坏货报损</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-337\"><a href=\"warehouseinventory_view.aspx\" >库存盘点</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-338\"><a href=\"storage_order.aspx\" >出入库</a></li>\r\n");
	templateBuilder.Append("                    </ul>\r\n");
	templateBuilder.Append("                </li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-34\">\r\n");
	templateBuilder.Append("                    <a href=\"javascript:void(0);\" >其他</a>\r\n");
	templateBuilder.Append("                    <ul class=\"children\">\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-344\"><a href=\"sales.aspx\" >客户销售数据</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-345\"><a href=\"storehousestorageview.aspx\" >客户库存数据</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-346\"><a href=\"stockproduct_invoicing.aspx\" >进销存数据调整</a></li>\r\n");
	templateBuilder.Append("                    </ul>\r\n");
	templateBuilder.Append("                </li>\r\n");
	templateBuilder.Append("			</ul>\r\n");
	templateBuilder.Append("		</li>\r\n");
	templateBuilder.Append("		<li class=\"cat-item cat-item-4\"><a href=\"javascript:void(0);\" >人事管理</a>\r\n");
	templateBuilder.Append("			<ul class=\"children\">\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-41\">\r\n");
	templateBuilder.Append("					<a href=\"staff.aspx\" >人员档案</a>\r\n");
	templateBuilder.Append("					" + DepartmentsClassToolBarHTML.ToString() + "\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-42\">\r\n");
	templateBuilder.Append("                    <a href=\"staffstores.aspx\" >人员变动记录</a>\r\n");
	templateBuilder.Append("                </li>\r\n");
	templateBuilder.Append("			</ul>\r\n");
	templateBuilder.Append("		</li>\r\n");
	templateBuilder.Append("		<!--\r\n");
	templateBuilder.Append("		<li class=\"cat-item cat-item-5\"><a href=\"javascript:void(0);\" >产品管理</a>\r\n");
	templateBuilder.Append("			<ul class=\"children\">\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-51\">\r\n");
	templateBuilder.Append("					<a href=\"products.aspx\" >产品档案</a>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-53\">\r\n");
	templateBuilder.Append("                    <a href=\"productpool.aspx\" >产品联营</a>\r\n");
	templateBuilder.Append("                </li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-54\">\r\n");
	templateBuilder.Append("                    <a href=\"stockproduct.aspx\" >产品库存</a>\r\n");
	templateBuilder.Append("                </li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-55\">\r\n");
	templateBuilder.Append("                    <a href=\"stockproduct_invoicing.aspx\" >进销存数据调整</a>\r\n");
	templateBuilder.Append("                </li>\r\n");
	templateBuilder.Append("			</ul>\r\n");
	templateBuilder.Append("		</li>\r\n");
	templateBuilder.Append("		-->\r\n");
	templateBuilder.Append("		<li class=\"cat-item cat-item-6\"><a href=\"javascript:void(0);\" >财务信息</a>\r\n");
	templateBuilder.Append("			<ul class=\"children\">\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-63\">\r\n");
	templateBuilder.Append("					<a href=\"javascript:void(0);\" >基础设置</a>\r\n");
	templateBuilder.Append("					<ul class=\"children\">\r\n");
	templateBuilder.Append("                        <li class=\"cat-item cat-item-631\"><a href=\"/feessubjectclass.aspx\" >科目设置</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-632\"><a href=\"/banklist.aspx\" >资金帐户</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-633\"><a href=\"/stores_armoney.aspx\" >应收期初</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-633\"><a href=\"/supplier_apmoney.aspx\" >应付期初</a></li>\r\n");
	templateBuilder.Append("                    </ul>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-61\">\r\n");
	templateBuilder.Append("					<a href=\"javascript:void(0);\" >对账单管理</a>\r\n");
	templateBuilder.Append("					<ul class=\"children\">\r\n");
	templateBuilder.Append("                        <li class=\"cat-item cat-item-611\"><a href=\"/monthlystatementlist-2.aspx\" >应收对账单</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-612\"><a href=\"/monthlystatementlist-1.aspx\" >应付对账单</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-613\"><a href=\"/monthlystatementlist-3.aspx\" >其他对账单</a></li>\r\n");
	templateBuilder.Append("                    </ul>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("                <li class=\"cat-item cat-item-62\">\r\n");
	templateBuilder.Append("					<a href=\"certificatelist.aspx\" >凭证管理</a>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-64\"><a href=\"javascript:void(0);\" >财务分析</a>\r\n");
	templateBuilder.Append("					<ul class=\"children\">\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-641\"><a href=\"report_certificate_summary.aspx\" >凭证汇总</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-642\"><a href=\"cost_details.aspx\" >费用统计</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-643\"><a href=\"occurrence_forehead_balance.aspx\" >发生额及余额</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-644\"><a href=\"occurrence_forehead_balance_do.aspx\" >明细及总账</a></li>\r\n");
	templateBuilder.Append("						<!--\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-7231\"><a href=\"money_out.aspx\" >费用</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-7231\"><a href=\"money_in.aspx\" >收入</a></li>-->\r\n");
	templateBuilder.Append("						<!--<li class=\"cat-item cat-item-7232\"><a href=\"dataanalysis_H2.aspx\" >应收应付</a></li>-->\r\n");
	templateBuilder.Append("						<!--\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-7233\">\r\n");
	templateBuilder.Append("							<a href=\"bankmoney.aspx\" >现金银行</a>\r\n");
	templateBuilder.Append("						</li>\r\n");
	templateBuilder.Append("						-->\r\n");
	templateBuilder.Append("						<!--\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-7234\"><a href=\"dataanalysis_H4.aspx\" >实时库存</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-7235\"><a href=\"dataanalysis_H5.aspx\" >固定资产</a></li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-7236\"><a href=\"dataanalysis_H6.aspx\" >净资产</a></li>\r\n");
	templateBuilder.Append("						-->\r\n");
	templateBuilder.Append("					</ul>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("				<!--\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-63\">\r\n");
	templateBuilder.Append("					<a href=\"certificatedata.aspx\" >收入支出</a>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("                <li class=\"cat-item cat-item-65\"><a href=\"purchasingreceivables.aspx\" >应收款项</a></li>\r\n");
	templateBuilder.Append("                <li class=\"cat-item cat-item-66\"><a href=\"purchasingpayment.aspx\" >应付款项</a></li>\r\n");
	templateBuilder.Append("				-->\r\n");
	templateBuilder.Append("			</ul>\r\n");
	templateBuilder.Append("		</li>\r\n");

	if (config.Taobao_Open==1)
	{

	templateBuilder.Append("		<li class=\"cat-item cat-item-8\"><a href=\"javascript:void(0);\" >网店管理</a>\r\n");

	if (MConfigList!=null)
	{

	templateBuilder.Append("				<ul class=\"children\">\r\n");

	int mcl__loop__id=0;
	foreach(DataRow mcl in MConfigList.Rows)
	{
		mcl__loop__id++;

	templateBuilder.Append("						<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "\">\r\n");
	templateBuilder.Append("							<a href=\"javascript:void(0);\" >" + mcl["StoresName"].ToString().Trim() + "(" + mcl["m_Name"].ToString().Trim() + ")</a>\r\n");
	templateBuilder.Append("							<ul class=\"children\">\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "1\">\r\n");
	templateBuilder.Append("									<a href=\"mproduct-" + mcl["m_ConfigInfoID"].ToString().Trim() + ".aspx\" >商品管理</a>\r\n");
	templateBuilder.Append("								</li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "3\">\r\n");
	templateBuilder.Append("									<a href=\"mtrade-" + mcl["m_ConfigInfoID"].ToString().Trim() + ".aspx\" >交易管理</a>\r\n");
	templateBuilder.Append("									<ul class=\"children\">\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "21\"><a href=\"mtrade-" + mcl["m_ConfigInfoID"].ToString().Trim() + "-1.aspx\" >等待付款订单</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "22\"><a href=\"mtrade-" + mcl["m_ConfigInfoID"].ToString().Trim() + "-2.aspx\" >等待发货订单</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "23\"><a href=\"mtrade-" + mcl["m_ConfigInfoID"].ToString().Trim() + "-3.aspx\" >等待收货订单</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "23\"><a href=\"mtrade-" + mcl["m_ConfigInfoID"].ToString().Trim() + "-4.aspx\" >等待确认订单</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "23\"><a href=\"mtrade-" + mcl["m_ConfigInfoID"].ToString().Trim() + "-5.aspx\" >交易成功</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "23\"><a href=\"mtrade-" + mcl["m_ConfigInfoID"].ToString().Trim() + "-6.aspx\" >交易关闭</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "23\"><a href=\"mtrade-" + mcl["m_ConfigInfoID"].ToString().Trim() + "-7.aspx\" >交易被淘宝关闭</a></li>\r\n");
	templateBuilder.Append("									</ul>\r\n");
	templateBuilder.Append("								</li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "5\">\r\n");
	templateBuilder.Append("									<a href=\"mrefund-" + mcl["m_ConfigInfoID"].ToString().Trim() + ".aspx\" >退款管理</a>\r\n");
	templateBuilder.Append("									<ul class=\"children\">\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "31\"><a href=\"mrefund-" + mcl["m_ConfigInfoID"].ToString().Trim() + "-0.aspx\" >未处理退款</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "32\"><a href=\"mrefund-" + mcl["m_ConfigInfoID"].ToString().Trim() + "-1.aspx\" >同意的退款</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "33\"><a href=\"mrefund-" + mcl["m_ConfigInfoID"].ToString().Trim() + "-2.aspx\" >拒绝的退款</a></li>\r\n");
	templateBuilder.Append("									</ul>\r\n");
	templateBuilder.Append("								</li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "4\">\r\n");
	templateBuilder.Append("									<a href=\"javascript:void(0);\" >客户服务</a>\r\n");
	templateBuilder.Append("									<ul class=\"children\">\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "41\"><a href=\"mmembers-" + mcl["m_ConfigInfoID"].ToString().Trim() + ".aspx\" >客户信息</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "42\"><a href=\"mmembers-push-" + mcl["m_ConfigInfoID"].ToString().Trim() + ".aspx\" >信息推送</a></li>\r\n");
	templateBuilder.Append("									</ul>\r\n");
	templateBuilder.Append("								</li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "6\">\r\n");
	templateBuilder.Append("									<a href=\"javascript:void(0);\" >数据分析</a>\r\n");
	templateBuilder.Append("									<ul class=\"children\">\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "61\"><a href=\"mdataanalysis-" + mcl["m_ConfigInfoID"].ToString().Trim() + ".aspx\" >经营概况</a></li>\r\n");
	templateBuilder.Append("									</ul>\r\n");
	templateBuilder.Append("								</li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "7\">\r\n");
	templateBuilder.Append("									<a href=\"javascript:void(0);\" >网店配置</a>\r\n");
	templateBuilder.Append("									<ul class=\"children\">\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-8" + mcl__loop__id.ToString() + "71\"><a href=\"mexpresstemplates-" + mcl["m_ConfigInfoID"].ToString().Trim() + ".aspx\" >快递运单模板</a></li>\r\n");
	templateBuilder.Append("									</ul>\r\n");
	templateBuilder.Append("								</li>\r\n");
	templateBuilder.Append("							</ul>\r\n");
	templateBuilder.Append("						</li>\r\n");

	}	//end loop

	templateBuilder.Append("				</ul>\r\n");

	}	//end if

	templateBuilder.Append("		</li>\r\n");

	}	//end if

	templateBuilder.Append("		<li class=\"cat-item cat-item-7\"><a href=\"javascript:void(0);\" >数据分析</a>\r\n");
	templateBuilder.Append("			<ul class=\"children\">\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-71\">\r\n");
	templateBuilder.Append("					<a href=\"javascript:void(0);\" >客户数据</a>\r\n");
	templateBuilder.Append("					<ul class=\"children\">\r\n");
	templateBuilder.Append("                        <li class=\"cat-item cat-item-711\"><a href=\"javascript:void(0);\" >销售数据分析</a>\r\n");
	templateBuilder.Append("							<ul class=\"children\">\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7111\"><a href=\"customers_dataanalysis-1.aspx\" >客户</a>\r\n");
	templateBuilder.Append("									<ul class=\"children\">\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-71111\"><a href=\"customers_dataanalysis-1-1.aspx\" >联营</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-71112\"><a href=\"customers_dataanalysis-1-2.aspx\" >购销</a></li>\r\n");
	templateBuilder.Append("									</ul>\r\n");
	templateBuilder.Append("								</li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7112\"><a href=\"customers_dataanalysis-2.aspx\" >业务员</a>\r\n");
	templateBuilder.Append("									<ul class=\"children\">\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-71121\"><a href=\"customers_dataanalysis-2-1.aspx\" >联营</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-71122\"><a href=\"customers_dataanalysis-2-2.aspx\" >购销</a></li>\r\n");
	templateBuilder.Append("									</ul>\r\n");
	templateBuilder.Append("								</li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7113\"><a href=\"customers_dataanalysis-3.aspx\" >促销员</a>\r\n");
	templateBuilder.Append("									<ul class=\"children\">\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-71131\"><a href=\"customers_dataanalysis-3-1.aspx\" >联营</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-71132\"><a href=\"customers_dataanalysis-3-2.aspx\" >购销</a></li>\r\n");
	templateBuilder.Append("									</ul>\r\n");
	templateBuilder.Append("								</li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7114\"><a href=\"customers_dataanalysis-4.aspx\" >产品</a>\r\n");
	templateBuilder.Append("									<ul class=\"children\">\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-71141\"><a href=\"customers_dataanalysis-4-1.aspx\" >联营</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-71142\"><a href=\"customers_dataanalysis-4-2.aspx\" >购销</a></li>\r\n");
	templateBuilder.Append("									</ul>\r\n");
	templateBuilder.Append("								</li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7115\"><a href=\"customers_dataanalysis-5.aspx\" >品牌</a>\r\n");
	templateBuilder.Append("									<ul class=\"children\">\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-71151\"><a href=\"customers_dataanalysis-5-1.aspx\" >联营</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-71152\"><a href=\"customers_dataanalysis-5-2.aspx\" >购销</a></li>\r\n");
	templateBuilder.Append("									</ul>\r\n");
	templateBuilder.Append("								</li>\r\n");
	templateBuilder.Append("                                <li class=\"cat-item cat-item-7116\"><a href=\"customers_dataanalysis-7.aspx\" >客户商品</a>\r\n");
	templateBuilder.Append("									<ul class=\"children\">\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-71161\"><a href=\"customers_dataanalysis-7-1.aspx\" >联营</a></li>\r\n");
	templateBuilder.Append("										<li class=\"cat-item cat-item-71162\"><a href=\"customers_dataanalysis-7-2.aspx\" >购销</a></li>\r\n");
	templateBuilder.Append("									</ul>\r\n");
	templateBuilder.Append("								</li>\r\n");
	templateBuilder.Append("								<!--<li class=\"cat-item cat-item-7116\"><a href=\"customers_dataanalysis-6.aspx\" >超市系统</a></li>-->\r\n");
	templateBuilder.Append("							</ul>\r\n");
	templateBuilder.Append("						</li>\r\n");
	templateBuilder.Append("						<!--\r\n");
	templateBuilder.Append("                        <li class=\"cat-item cat-item-712\">\r\n");
	templateBuilder.Append("                        <a href=\"javascript:void(0);\" >客户进销存</a>\r\n");
	templateBuilder.Append("                        <ul class=\"children\">\r\n");
	templateBuilder.Append("						  <li class=\"cat-item cat-item-7121\"><a href=\"report_storehousestorage.aspx?id=0\" >联表查询</a></li>\r\n");
	templateBuilder.Append("                          <li class=\"cat-item cat-item-7122\"><a href=\"report_storehousestorage.aspx?id=1\" >人员门店</a></li>\r\n");
	templateBuilder.Append("                        </ul>\r\n");
	templateBuilder.Append("					   </li>\r\n");
	templateBuilder.Append("					   <li class=\"cat-item cat-item-713\">\r\n");
	templateBuilder.Append("						<a href=\"javascript:void(0);\" >联营产品</a>\r\n");
	templateBuilder.Append("						<ul class=\"children\">\r\n");
	templateBuilder.Append("							<li class=\"cat-item cat-item-7131\"><a href=\"associated_details.aspx\" >联表库存</a></li>\r\n");
	templateBuilder.Append("						</ul>\r\n");
	templateBuilder.Append("					   </li>\r\n");
	templateBuilder.Append("					   -->\r\n");
	templateBuilder.Append("                    </ul>\r\n");
	templateBuilder.Append("				</li>\r\n");
	templateBuilder.Append("				<li class=\"cat-item cat-item-72\">\r\n");
	templateBuilder.Append("                    <a href=\"javascript:void(0);\" >企业数据</a>\r\n");
	templateBuilder.Append("					<ul class=\"children\">\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-725\"><a href=\"javascript:void(0);\" >销售统计</a>\r\n");
	templateBuilder.Append("							<ul class=\"children\">\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7251\"><a href=\"report_sales-1.aspx\" >商品统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7252\"><a href=\"report_sales-2.aspx\" >客户统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7253\"><a href=\"report_sales-3.aspx\" >结算系统统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7254\"><a href=\"report_sales-4.aspx\" >业务员统计<br>(按岗位变动)</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7260\"><a href=\"report_sales-7.aspx\" >业务员统计<br>(按单据记录)</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7255\"><a href=\"report_sales-5.aspx\" >促销员统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7256\"><a href=\"report_sales-6.aspx\" >地区统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7257\"><a href=\"buy_sales_details.aspx\" >购销统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7258\"><a href=\"products_sales.aspx\" >产品日均销量</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7259\"><a href=\"products_sales_details.aspx\" >图表统计</a></li>\r\n");
	templateBuilder.Append("							</ul>\r\n");
	templateBuilder.Append("						</li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-729\"><a href=\"javascript:void(0);\" >发出商品统计</a>\r\n");
	templateBuilder.Append("							<ul class=\"children\">\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7291\"><a href=\"report_sales_out-1.aspx\" >商品统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7292\"><a href=\"report_sales_out-2.aspx\" >客户统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7293\"><a href=\"report_sales_out-3.aspx\" >结算系统统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7294\"><a href=\"report_sales_out-4.aspx\" >业务员统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7295\"><a href=\"report_sales_out-5.aspx\" >促销员统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7296\"><a href=\"report_sales_out-6.aspx\" >地区统计</a></li>\r\n");
	templateBuilder.Append("							</ul>\r\n");
	templateBuilder.Append("						</li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-730\"><a href=\"javascript:void(0);\" >备货商品统计</a>\r\n");
	templateBuilder.Append("							<ul class=\"children\">\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7301\"><a href=\"report_sales_verify-1.aspx\" >商品统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7302\"><a href=\"report_sales_verify-2.aspx\" >客户统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7303\"><a href=\"report_sales_verify-3.aspx\" >结算系统统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7304\"><a href=\"report_sales_verify-4.aspx\" >业务员统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7305\"><a href=\"report_sales_verify-5.aspx\" >促销员统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7306\"><a href=\"report_sales_verify-6.aspx\" >地区统计</a></li>\r\n");
	templateBuilder.Append("							</ul>\r\n");
	templateBuilder.Append("						</li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-726\"><a href=\"javascript:void(0);\" >进货统计</a>\r\n");
	templateBuilder.Append("							<ul class=\"children\">\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7261\"><a href=\"report_purchase-1.aspx\" >商品进货统计</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7262\"><a href=\"report_purchase-2.aspx\" >供应商进货统计</a></li>\r\n");
	templateBuilder.Append("							</ul>\r\n");
	templateBuilder.Append("						</li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-728\"><a href=\"javascript:void(0);\" >出货统计</a>\r\n");
	templateBuilder.Append("							<ul class=\"children\">\r\n");
	templateBuilder.Append("								<!--<li class=\"cat-item cat-item-7281\"><a href=\"report_out-1.aspx\" >商品出货统计</a></li>-->\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7282\"><a href=\"report_sales-8.aspx?dType=6\" >商品出货统计明细</a></li>\r\n");
	templateBuilder.Append("								<!--<li class=\"cat-item cat-item-7283\"><a href=\"report_out-2.aspx\" >客户出货统计</a></li>-->\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7284\"><a href=\"report_sales-9.aspx?dType=6\" >客户出货统计明细</a></li>\r\n");
	templateBuilder.Append("							</ul>\r\n");
	templateBuilder.Append("						</li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-727\"><a href=\"javascript:void(0);\" >仓库统计</a>\r\n");
	templateBuilder.Append("							<ul class=\"children\">\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7271\"><a href=\"report_invoicing.aspx\" >进销存报表</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7275\"><a href=\"stockproduct.aspx\" >商品实时库存</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7276\"><a href=\"stockproduct_log.aspx\" >库存商品明细账</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7277\"><a href=\"productsloss.aspx\" >报损统计</a></li>\r\n");
	templateBuilder.Append("                                <li class=\"cat-item cat-item-7278\"><a href=\"storage_order_list.aspx\" >日常明细统计</a></li>\r\n");

	if (CheckUserPopedoms("X"))
	{

	templateBuilder.Append("                                <li class=\"cat-item cat-item-7279\"><a href=\"product_price.aspx\" >商品成本维护</a></li>\r\n");

	}	//end if

	templateBuilder.Append("							</ul>\r\n");
	templateBuilder.Append("						</li>\r\n");
	templateBuilder.Append("						<!--\r\n");
	templateBuilder.Append("                        <li class=\"cat-item cat-item-721\"><a href=\"dataanalysis_E.aspx\" >利润分析</a>\r\n");
	templateBuilder.Append("							<ul class=\"children\">\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7211\"><a href=\"dataanalysis_E1.aspx\" >客户</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7212\"><a href=\"dataanalysis_E2.aspx\" >人员</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7213\"><a href=\"dataanalysis_E4.aspx\" >产品</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7214\"><a href=\"dataanalysis_E5.aspx\" >品牌</a></li>\r\n");
	templateBuilder.Append("							</ul>\r\n");
	templateBuilder.Append("						</li>\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-722\"><a href=\"dataanalysis_F.aspx\" >毛利分析</a>\r\n");
	templateBuilder.Append("							<ul class=\"children\">\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7221\"><a href=\"dataanalysis_F1.aspx\" >客户</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7222\"><a href=\"dataanalysis_F2.aspx\" >人员</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7223\"><a href=\"dataanalysis_F4.aspx\" >产品</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7224\"><a href=\"dataanalysis_F5.aspx\" >品牌</a></li>\r\n");
	templateBuilder.Append("							</ul>\r\n");
	templateBuilder.Append("						</li>\r\n");
	templateBuilder.Append("                        -->\r\n");
	templateBuilder.Append("						<li class=\"cat-item cat-item-724\"><a href=\"javascript:void(0);\" >人员岗位分析</a>\r\n");
	templateBuilder.Append("							<ul class=\"children\">\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7241\"><a href=\"personnel_statistics.aspx\" >月报表</a></li>\r\n");
	templateBuilder.Append("								<li class=\"cat-item cat-item-7242\"><a href=\"personnel_statistics_details.aspx\" >入离职报表</a></li>\r\n");
	templateBuilder.Append("							</ul>\r\n");
	templateBuilder.Append("						</li>\r\n");
	templateBuilder.Append("                    </ul>\r\n");
	templateBuilder.Append("                </li>\r\n");
	templateBuilder.Append("			</ul>\r\n");
	templateBuilder.Append("		</li>\r\n");
	templateBuilder.Append("	</ul>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<!-- 菜单 END -->\r\n");
	templateBuilder.Append("</div>\r\n");



	}	//end if

	templateBuilder.Append("</div>\r\n");


	templateBuilder.Append("<script src=\"public/JSClass/FusionCharts.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/Cxty_XTool.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.mcdropdown.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.bgiframe.js\"></" + "script>\r\n");
	templateBuilder.Append("<link type=\"text/css\" href=\"templates/" + templatepath.ToString() + "/css/jquery.mcdropdown.css\" rel=\"stylesheet\" media=\"all\" />\r\n");
	templateBuilder.Append("<script src=\"public/js/DataAnalysis.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<style type=\"text/css\">\r\n");
	templateBuilder.Append(".menu_list {	\r\n");
	templateBuilder.Append("	width: 135px;\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append(".menu_head {\r\n");
	templateBuilder.Append("	padding: 5px 10px;\r\n");
	templateBuilder.Append("	cursor: pointer;\r\n");
	templateBuilder.Append("	position: relative;\r\n");
	templateBuilder.Append("	margin:1px;\r\n");
	templateBuilder.Append("    background: #eef4d3 url(images/left.png) center right no-repeat;\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append(".menu_body {\r\n");
	templateBuilder.Append("	display:none;\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append(".menu_body a{\r\n");
	templateBuilder.Append("  display:block;\r\n");
	templateBuilder.Append("  color:#006699;\r\n");
	templateBuilder.Append("  background-color:#EFEFEF;\r\n");
	templateBuilder.Append("  padding-left:10px;\r\n");
	templateBuilder.Append("  text-decoration:none;\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append(".menu_body a:hover{\r\n");
	templateBuilder.Append("  color: #000000;\r\n");
	templateBuilder.Append("  text-decoration:underline;\r\n");
	templateBuilder.Append("  }\r\n");
	templateBuilder.Append("</style>\r\n");
	templateBuilder.Append("    <div class=\"main\" id=\"usermanage\">\r\n");

	if (page_err!=0)
	{


	templateBuilder.Append("<div id=\"err\">\r\n");
	templateBuilder.Append("	<h1>出现了" + page_err.ToString() + "个错误</h1>\r\n");
	templateBuilder.Append("	<p class=\"errorback\">" + msgbox_text.ToString() + "</p>\r\n");
	templateBuilder.Append("	<p class=\"errorback\">\r\n");
	templateBuilder.Append("		<script type=\"text/javascript\">\r\n");
	templateBuilder.Append("			if(" + msgbox_showbacklink.ToString() + ")\r\n");
	templateBuilder.Append("			{\r\n");
	templateBuilder.Append("				document.write(\"<a href=\\\"" + msgbox_backlink.ToString() + "\\\">返回上一步</a> \");\r\n");
	templateBuilder.Append("			}\r\n");
	templateBuilder.Append("		</" + "script>\r\n");
	templateBuilder.Append("	</p>\r\n");
	templateBuilder.Append("</div>\r\n");



	}
	else
	{

	templateBuilder.Append("<div class=\"left_toolbar\" >\r\n");
	templateBuilder.Append("<ul>\r\n");
	templateBuilder.Append("<li><b><a href=\"dataanalysis_H.aspx\">概况</a></b></li>\r\n");
	templateBuilder.Append("<li><b>永辉数据</b>\r\n");
	templateBuilder.Append("	<ul>\r\n");
	templateBuilder.Append("    	<li>\r\n");
	templateBuilder.Append("			<div id=\"firstpane_1\" class=\"menu_list\">\r\n");
	templateBuilder.Append("			<p class=\"menu_head\">\r\n");
	templateBuilder.Append("			<a href=\"dataanalysis_A.aspx\" \r\n");

	if (Act=="A")
	{

	templateBuilder.Append("			class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">销售数据分析</a></p>\r\n");
	templateBuilder.Append("				<div class=\"menu_body\">\r\n");
	templateBuilder.Append("					<a href=\"dataanalysis_A1.aspx\" \r\n");

	if (Act=="A1")
	{

	templateBuilder.Append("					class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">客户、门店</a>\r\n");
	templateBuilder.Append("					<a href=\"dataanalysis_A2.aspx\" \r\n");

	if (Act=="A2")
	{

	templateBuilder.Append("					class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">业务员</a>\r\n");
	templateBuilder.Append("					<a href=\"dataanalysis_A3.aspx\" \r\n");

	if (Act=="A3")
	{

	templateBuilder.Append("					class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">促销员</a>\r\n");
	templateBuilder.Append("					<a href=\"dataanalysis_A4.aspx\" \r\n");

	if (Act=="A4")
	{

	templateBuilder.Append("					class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">产品</a>\r\n");
	templateBuilder.Append("					<a href=\"dataanalysis_A5.aspx\" \r\n");

	if (Act=="A5")
	{

	templateBuilder.Append("					class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">品牌</a>\r\n");
	templateBuilder.Append("					<a href=\"dataanalysis_A6.aspx\" \r\n");

	if (Act=="A6")
	{

	templateBuilder.Append("					class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">系统</a>\r\n");
	templateBuilder.Append("				</div>\r\n");
	templateBuilder.Append("			</div>\r\n");
	templateBuilder.Append("		</li>\r\n");
	templateBuilder.Append("    </ul>\r\n");
	templateBuilder.Append("</li>\r\n");
	templateBuilder.Append("<li><b>公司数据</b>\r\n");
	templateBuilder.Append("	<ul>\r\n");
	templateBuilder.Append("			<li>\r\n");
	templateBuilder.Append("				<div id=\"firstpane_2\" class=\"menu_list\">\r\n");
	templateBuilder.Append("				<p class=\"menu_head\">\r\n");
	templateBuilder.Append("				<a href=\"dataanalysis_E.aspx\" \r\n");

	if (Act=="E")
	{

	templateBuilder.Append("				class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">利润分析</a></p>\r\n");
	templateBuilder.Append("					<div class=\"menu_body\">\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_E1.aspx\" \r\n");

	if (Act=="E1")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">客户、门店</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_E2.aspx\" \r\n");

	if (Act=="E2")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">业务员</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_E3.aspx\" \r\n");

	if (Act=="E3")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">促销员</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_E4.aspx\" \r\n");

	if (Act=="E4")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">产品</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_E5.aspx\" \r\n");

	if (Act=="E5")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">品牌</a>\r\n");
	templateBuilder.Append("					</div>\r\n");
	templateBuilder.Append("				</div>\r\n");
	templateBuilder.Append("			</li>\r\n");
	templateBuilder.Append("			<li>\r\n");
	templateBuilder.Append("				<div id=\"firstpane_3\" class=\"menu_list\">\r\n");
	templateBuilder.Append("				<p class=\"menu_head\">\r\n");
	templateBuilder.Append("				<a href=\"dataanalysis_F.aspx\" \r\n");

	if (Act=="F")
	{

	templateBuilder.Append("				class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">毛利分析</a></p>\r\n");
	templateBuilder.Append("					<div class=\"menu_body\">\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_F1.aspx\" \r\n");

	if (Act=="F1")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">客户、门店</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_F2.aspx\" \r\n");

	if (Act=="F2")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">业务员</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_F3.aspx\" \r\n");

	if (Act=="F3")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">促销员</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_F4.aspx\" \r\n");

	if (Act=="F4")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">产品</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_F5.aspx\" \r\n");

	if (Act=="F5")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">品牌</a>\r\n");
	templateBuilder.Append("					</div>\r\n");
	templateBuilder.Append("				</div>\r\n");
	templateBuilder.Append("			</li>\r\n");
	templateBuilder.Append("			<li>\r\n");
	templateBuilder.Append("			<div id=\"firstpane_6\" class=\"menu_list\">\r\n");
	templateBuilder.Append("			<p class=\"menu_head\">\r\n");
	templateBuilder.Append("			<a href=\"dataanalysis_H.aspx\" \r\n");

	if (Act=="H")
	{

	templateBuilder.Append("			class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">财务分析</a></p>\r\n");
	templateBuilder.Append("					<div class=\"menu_body\">\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_H1.aspx\" \r\n");

	if (Act=="H1")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">费用/收入</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_H2.aspx\" \r\n");

	if (Act=="H2")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">应收应付</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_H4.aspx\" \r\n");

	if (Act=="H4")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">现金银行</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_H3.aspx\" \r\n");

	if (Act=="H3")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">实时库存</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_H5.aspx\" \r\n");

	if (Act=="H5")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">固定资产</a>\r\n");
	templateBuilder.Append("						<a href=\"dataanalysis_H6.aspx\" \r\n");

	if (Act=="H6")
	{

	templateBuilder.Append("						class = \"sed\"\r\n");

	}	//end if

	templateBuilder.Append(">净资产</a>\r\n");
	templateBuilder.Append("					</div>\r\n");
	templateBuilder.Append("			</div></li>\r\n");
	templateBuilder.Append("		</ul>\r\n");
	templateBuilder.Append("</li>\r\n");
	templateBuilder.Append("</ul>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<div class=\"right_box\">\r\n");
	templateBuilder.Append("<form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");

	if (Act!="H3" && Act!="H4" && Act!="H2" && Act!="H6" && Act!="H")
	{


	templateBuilder.Append("<div class=\"toolbar\">\r\n");
	templateBuilder.Append("    	<div style=\"float:left\">\r\n");
	templateBuilder.Append("        <ul>\r\n");
	templateBuilder.Append("			<li>\r\n");
	templateBuilder.Append("            	时间：<br/><input style=\"width:60px\" name=\"bDateTime\" id=\"bDateTime\" onclick=\"new Calendar().show(this);\" value=\"" + bDateTime.ToString() + "\" type=\"text\" />-<input style=\"width:60px\" name=\"eDateTime\" id=\"eDateTime\" onclick=\"new Calendar().show(this);\" value=\"" + eDateTime.ToString() + "\" type=\"text\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("            <li id=\"StoresName_box\">\r\n");
	templateBuilder.Append("                门店、客户：<input name=\"StoresName\" id=\"StoresName\" type=\"text\" value=\"" + StoresName.ToString() + "\" />\r\n");
	templateBuilder.Append("                <INPUT TYPE=\"hidden\" NAME=\"StoresID\" id=\"StoresID\" value=\"" + StoresID.ToString() + "\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("			<li id=\"YHsysName_box\">\r\n");
	templateBuilder.Append("                系统：<input name=\"YHsysName\" id=\"YHsysName\" type=\"text\" value=\"" + YHsysName.ToString() + "\" />\r\n");
	templateBuilder.Append("                <INPUT TYPE=\"hidden\" NAME=\"YHsysID\" id=\"YHsysID\" value=\"" + YHsysID.ToString() + "\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("            <li id=\"StaffName_box\">\r\n");
	templateBuilder.Append("                业务员：<input name=\"StaffName\" id=\"StaffName\" type=\"text\" value=\"" + StaffName.ToString() + "\" />\r\n");
	templateBuilder.Append("                <INPUT TYPE=\"hidden\" NAME=\"StaffID\" id=\"StaffID\" value=\"" + StaffID.ToString() + "\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("            <li id=\"StaffNameB_Box\">\r\n");
	templateBuilder.Append("                促销员：<input name=\"StaffNameB\" id=\"StaffNameB\" type=\"text\" value=\"" + StaffNameB.ToString() + "\" />\r\n");
	templateBuilder.Append("                <INPUT TYPE=\"hidden\" NAME=\"StaffIDB\" id=\"StaffIDB\" value=\"" + StaffIDB.ToString() + "\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("			<li id=\"ProductName_Box\">\r\n");
	templateBuilder.Append("                产品：<input name=\"ProductName\" id=\"ProductName\" type=\"text\" value=\"" + ProductName.ToString() + "\" />\r\n");
	templateBuilder.Append("                <INPUT TYPE=\"hidden\" NAME=\"ProductID\" id=\"ProductID\" value=\"" + ProductID.ToString() + "\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("            <li id=\"pBrand_box\">\r\n");
	templateBuilder.Append("                品牌：<input name=\"pBrand\" id=\"pBrand\" type=\"text\" value=\"" + pBrand.ToString() + "\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("            <li id=\"RegionBox_Box\">\r\n");
	templateBuilder.Append("            	<nobr>地区：\r\n");
	templateBuilder.Append("				<input type=\"hidden\" id=\"RegionID\" name=\"RegionID\" \r\n");
	templateBuilder.Append("                  value=\"" + RegionID.ToString() + "\"\r\n");
	templateBuilder.Append("                  />\r\n");
	templateBuilder.Append("                  <input type=\"text\" name=\"category\" id=\"category\" value=\"\" />\r\n");
	templateBuilder.Append("                  <ul id=\"categorymenu\" class=\"mcdropdown_menu\">" + Region.ToString() + "</ul>\r\n");
	templateBuilder.Append("				  <script language=\"javascript\" type=\"text/javascript\">\r\n");

	if (RegionID>0)
	{

	templateBuilder.Append("					$(document).ready(function (){\r\n");
	templateBuilder.Append("					var dd = $(\"#category\").mcDropdown();\r\n");
	templateBuilder.Append("							dd.setValue(" + RegionID.ToString() + ");\r\n");
	templateBuilder.Append("					});\r\n");

	}	//end if

	templateBuilder.Append("				  </" + "script>\r\n");
	templateBuilder.Append("                  </td>\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("        <ul>\r\n");
	templateBuilder.Append("        </div>\r\n");
	templateBuilder.Append("        <div style=\"float:left;clear:left\"><nobr><input type=\"button\" value=\"确定\" style=\"margin:5px;width:80px\" class=\"B_INPUT\" onclick=\"javascript:DataAnalysis.CheckF();\" />\r\n");
	templateBuilder.Append("        <input type=\"button\" value=\"重置分析条件\" onclick=\"javascript:DataAnalysis.ReSet();\" style=\"margin:5px;width:80px\" class=\"B_INPUT\"/></nobr></div>\r\n");
	templateBuilder.Append("    </div>\r\n");



	}	//end if


	if (Act=="H")
	{


	templateBuilder.Append("<div class=\"toolbar\">\r\n");
	templateBuilder.Append("    	<div style=\"float:left\">\r\n");
	templateBuilder.Append("        <ul>\r\n");
	templateBuilder.Append("			<li>\r\n");
	templateBuilder.Append("            	时间点：<br/><input style=\"width:60px\" name=\"eDateTime\" id=\"eDateTime\" onclick=\"new Calendar().show(this);\" value=\"" + eDateTime.ToString() + "\" type=\"text\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("        <ul>\r\n");
	templateBuilder.Append("        </div>\r\n");
	templateBuilder.Append("        <div style=\"float:left;clear:left\"><nobr><input type=\"button\" value=\"确定\" style=\"margin:5px;width:80px\" class=\"B_INPUT\" onclick=\"javascript:DataAnalysis.CheckF();\" />\r\n");
	templateBuilder.Append("        <input type=\"button\" value=\"重置分析条件\" onclick=\"javascript:DataAnalysis.ReSet();\" style=\"margin:5px;width:80px\" class=\"B_INPUT\"/></nobr></div>\r\n");
	templateBuilder.Append("    </div>\r\n");



	}	//end if


	if (Act=="H3")
	{


	templateBuilder.Append("<div class=\"toolbar\">\r\n");
	templateBuilder.Append("    	<div style=\"float:left\">\r\n");
	templateBuilder.Append("        <ul>\r\n");
	templateBuilder.Append("			<li id=\"ProductName_Box\">\r\n");
	templateBuilder.Append("                产品：<input name=\"ProductName\" id=\"ProductName\" type=\"text\" value=\"" + ProductName.ToString() + "\" />\r\n");
	templateBuilder.Append("                <INPUT TYPE=\"hidden\" NAME=\"ProductID\" id=\"ProductID\" value=\"" + ProductID.ToString() + "\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("			<li>\r\n");
	templateBuilder.Append("            	库存时间点：<br/><input style=\"width:60px\" name=\"eDateTime\" id=\"eDateTime\" onclick=\"new Calendar().show(this);\" value=\"" + eDateTime.ToString() + "\" type=\"text\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("        <ul>\r\n");
	templateBuilder.Append("        </div>\r\n");
	templateBuilder.Append("        <div style=\"float:left;clear:left\"><nobr><input type=\"button\" value=\"确定\" style=\"margin:5px;width:80px\" class=\"B_INPUT\" onclick=\"javascript:DataAnalysis.CheckF();\" />\r\n");
	templateBuilder.Append("        <input type=\"button\" value=\"重置分析条件\" onclick=\"javascript:DataAnalysis.ReSet();\" style=\"margin:5px;width:80px\" class=\"B_INPUT\"/></nobr></div>\r\n");
	templateBuilder.Append("    </div>\r\n");



	}	//end if


	if (Act=="H2")
	{


	templateBuilder.Append("<div class=\"toolbar\">\r\n");
	templateBuilder.Append("    	<div style=\"float:left\">\r\n");
	templateBuilder.Append("        <ul>\r\n");
	templateBuilder.Append("			<li>\r\n");
	templateBuilder.Append("            	时间点：<br/><input style=\"width:60px\" name=\"eDateTime\" id=\"eDateTime\" onclick=\"new Calendar().show(this);\" value=\"" + eDateTime.ToString() + "\" type=\"text\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("        <ul>\r\n");
	templateBuilder.Append("        </div>\r\n");
	templateBuilder.Append("        <div style=\"float:left;clear:left\"><nobr><input type=\"button\" value=\"确定\" style=\"margin:5px;width:80px\" class=\"B_INPUT\" onclick=\"javascript:DataAnalysis.CheckF();\" />\r\n");
	templateBuilder.Append("        <input type=\"button\" value=\"重置分析条件\" onclick=\"javascript:DataAnalysis.ReSet();\" style=\"margin:5px;width:80px\" class=\"B_INPUT\"/></nobr></div>\r\n");
	templateBuilder.Append("    </div>\r\n");



	}	//end if


	if (Act=="H4")
	{


	templateBuilder.Append("<div class=\"toolbar\">\r\n");
	templateBuilder.Append("    	<div style=\"float:left\">\r\n");
	templateBuilder.Append("        <ul>\r\n");
	templateBuilder.Append("			<li>\r\n");
	templateBuilder.Append("            	时间点：<br/><input style=\"width:60px\" name=\"eDateTime\" id=\"eDateTime\" onclick=\"new Calendar().show(this);\" value=\"" + eDateTime.ToString() + "\" type=\"text\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("        <ul>\r\n");
	templateBuilder.Append("        </div>\r\n");
	templateBuilder.Append("        <div style=\"float:left;clear:left\"><nobr><input type=\"button\" value=\"确定\" style=\"margin:5px;width:80px\" class=\"B_INPUT\" onclick=\"javascript:DataAnalysis.CheckF();\" />\r\n");
	templateBuilder.Append("        <input type=\"button\" value=\"重置分析条件\" onclick=\"javascript:DataAnalysis.ReSet();\" style=\"margin:5px;width:80px\" class=\"B_INPUT\"/></nobr></div>\r\n");
	templateBuilder.Append("    </div>\r\n");



	}	//end if


	if (Act=="H6")
	{


	templateBuilder.Append("<div class=\"toolbar\">\r\n");
	templateBuilder.Append("    	<div style=\"float:left\">\r\n");
	templateBuilder.Append("        <ul>\r\n");
	templateBuilder.Append("			<li>\r\n");
	templateBuilder.Append("            	时间点：<br/><input style=\"width:60px\" name=\"eDateTime\" id=\"eDateTime\" onclick=\"new Calendar().show(this);\" value=\"" + eDateTime.ToString() + "\" type=\"text\" />\r\n");
	templateBuilder.Append("            </li>\r\n");
	templateBuilder.Append("        <ul>\r\n");
	templateBuilder.Append("        </div>\r\n");
	templateBuilder.Append("        <div style=\"float:left;clear:left\"><nobr><input type=\"button\" value=\"确定\" style=\"margin:5px;width:80px\" class=\"B_INPUT\" onclick=\"javascript:DataAnalysis.CheckF();\" />\r\n");
	templateBuilder.Append("        <input type=\"button\" value=\"重置分析条件\" onclick=\"javascript:DataAnalysis.ReSet();\" style=\"margin:5px;width:80px\" class=\"B_INPUT\"/></nobr></div>\r\n");
	templateBuilder.Append("    </div>\r\n");



	}	//end if

	templateBuilder.Append("    <div class=\"datalist\">\r\n");

	if (Act=="H")
	{


	templateBuilder.Append("<div id=\"datalist_A\">\r\n");
	templateBuilder.Append("		<div class=\"dlist\">\r\n");

	if (ispost)
	{

	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"5\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\"><h3><b>现金明细 " + eDateTime.ToString() + "</b></h3></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\">\r\n");
	 AllSumValue = 0;
	
	templateBuilder.Append("		<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("          <tr class=\"tBar\">\r\n");

	if (BankMoneyList != null)
	{


	int bl__loop__id=0;
	foreach(DataRow bl in BankMoneyList.Rows)
	{
		bl__loop__id++;

	templateBuilder.Append("					<td >" + bl["bName"].ToString().Trim() + "</td>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("          </tr>\r\n");

	if (BankMoneyList != null)
	{

	templateBuilder.Append("          <tr>\r\n");

	if (BankMoneyList != null)
	{


	int bl__loop__id=0;
	foreach(DataRow bl in BankMoneyList.Rows)
	{
		bl__loop__id++;

	templateBuilder.Append("					<td  align=\"right\">\r\n");
	 AllSumValue = AllSumValue+decimal.Parse(bl["BankMoney"].ToString());
	
	 ReHTML = bl["BankMoney"].ToString();
	
	templateBuilder.Append("					" + ReHTML.ToString() + "\r\n");
	templateBuilder.Append("					</td>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("          </tr>\r\n");

	}	//end if

	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("	<td align=\"right\">\r\n");
	templateBuilder.Append("			" + AllSumValue.ToString() + "\r\n");
	 BankMoney_Sum = AllSumValue;
	
	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"5\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\"><h3><b>应收款(公司) " + eDateTime.ToString() + "</b></h3></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\">\r\n");

	if (ispost)
	{

	 AllSumValue = 0;
	
	 AllSumValue1 = 0;
	
	 AllSumValue2 = 0;
	
	 AllSumValue3 = 0;
	
	 AllSumValue4 = 0;
	
	 AllSumValue5 = 0;
	
	templateBuilder.Append("			<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("				<tr class=\"tBar\">\r\n");
	templateBuilder.Append("					<td >门店、客户</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计新增应收金额<br>(未完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计新增应收金额<br>(已完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">实际对账金额<br>(已完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">实际已收款金额<br>(已完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">剩余应收金额</td>\r\n");
	templateBuilder.Append("				</tr>\r\n");

	if (ARMoney_E_List != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in ARMoney_E_List.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("					  <tr>\r\n");
	templateBuilder.Append("						<td >" + dl["sName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["ASumAMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BSumAMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BSumBMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BSumActualMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SYMoney"].ToString().Trim() + "</td>\r\n");
	 AllSumValue1 = AllSumValue1+decimal.Parse(dl["ASumAMoney"].ToString());
	
	 AllSumValue2 = AllSumValue2+decimal.Parse(dl["BSumAMoney"].ToString());
	
	 AllSumValue3 = AllSumValue3+decimal.Parse(dl["BSumBMoney"].ToString());
	
	 AllSumValue4 = AllSumValue4+decimal.Parse(dl["BSumActualMoney"].ToString());
	
	 AllSumValue5 = AllSumValue5+decimal.Parse(dl["SYMoney"].ToString());
	
	templateBuilder.Append("					  </tr>\r\n");

	}	//end loop

	 AllSumValue = AllSumValue5;
	

	}	//end if

	templateBuilder.Append("				  <tr>\r\n");
	templateBuilder.Append("					<td>合计:</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue1.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue2.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue3.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue4.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue5.ToString() + "</td>\r\n");
	templateBuilder.Append("				  </tr>\r\n");
	templateBuilder.Append("			</table>\r\n");

	}	//end if

	 ARMoney_E_Sum = AllSumValue;
	
	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <!--<tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("	<td align=\"right\">\r\n");
	templateBuilder.Append("			" + AllSumValue.ToString() + "\r\n");
	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>-->\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"5\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\"><h3><b>应收款(结算系统) " + eDateTime.ToString() + "</b></h3></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\">\r\n");

	if (ispost)
	{

	 AllSumValue = 0;
	
	 AllSumValue1 = 0;
	
	 AllSumValue2 = 0;
	
	 AllSumValue3 = 0;
	
	 AllSumValue4 = 0;
	
	 AllSumValue5 = 0;
	
	templateBuilder.Append("			<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("				<tr class=\"tBar\">\r\n");
	templateBuilder.Append("					<td >结算系统</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计新增应收金额<br>(未完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计新增应收金额<br>(已完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">实际对账金额<br>(已完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">实际已收款金额<br>(已完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">剩余应收金额</td>\r\n");
	templateBuilder.Append("				</tr>\r\n");

	if (ARMoney_PaySystem_List != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in ARMoney_PaySystem_List.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("					  <tr>\r\n");
	templateBuilder.Append("						<td >" + dl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["ASumAMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BSumAMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BSumBMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BSumActualMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SYMoney"].ToString().Trim() + "</td>\r\n");
	 AllSumValue1 = AllSumValue1+decimal.Parse(dl["ASumAMoney"].ToString());
	
	 AllSumValue2 = AllSumValue2+decimal.Parse(dl["BSumAMoney"].ToString());
	
	 AllSumValue3 = AllSumValue3+decimal.Parse(dl["BSumBMoney"].ToString());
	
	 AllSumValue4 = AllSumValue4+decimal.Parse(dl["BSumActualMoney"].ToString());
	
	 AllSumValue5 = AllSumValue5+decimal.Parse(dl["SYMoney"].ToString());
	
	templateBuilder.Append("					  </tr>\r\n");

	}	//end loop

	 AllSumValue = AllSumValue5;
	

	}	//end if

	templateBuilder.Append("				  <tr>\r\n");
	templateBuilder.Append("					<td>合计:</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue1.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue2.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue3.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue4.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue5.ToString() + "</td>\r\n");
	templateBuilder.Append("				  </tr>\r\n");
	templateBuilder.Append("			</table>\r\n");

	}	//end if

	 APMoney_PaySystem_Sum = AllSumValue;
	
	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <!--<tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("	<td align=\"right\">\r\n");
	templateBuilder.Append("			" + AllSumValue.ToString() + "\r\n");
	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>-->\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"5\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\"><h3><b>应收款(个人) " + eDateTime.ToString() + "</b></h3></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\">\r\n");

	if (ispost)
	{

	 AllSumValue = 0;
	
	 AllSumValue1 = 0;
	
	 AllSumValue2 = 0;
	
	 AllSumValue3 = 0;
	
	 AllSumValue4 = 0;
	
	 AllSumValue5 = 0;
	
	templateBuilder.Append("			<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("				<tr class=\"tBar\">\r\n");
	templateBuilder.Append("					<td >姓名</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计新增应收金额<br>(未完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计新增应收金额<br>(已完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">实际对账金额<br>(已完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">实际已收款金额<br>(已完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">剩余应收金额</td>\r\n");
	templateBuilder.Append("				</tr>\r\n");

	if (ARMoney_P_List != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in ARMoney_P_List.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("					  <tr>\r\n");
	templateBuilder.Append("						<td >" + dl["sName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["ASumAMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BSumAMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BSumBMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BSumActualMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SYMoney"].ToString().Trim() + "</td>\r\n");
	 AllSumValue1 = AllSumValue1+decimal.Parse(dl["ASumAMoney"].ToString());
	
	 AllSumValue2 = AllSumValue2+decimal.Parse(dl["BSumAMoney"].ToString());
	
	 AllSumValue3 = AllSumValue3+decimal.Parse(dl["BSumBMoney"].ToString());
	
	 AllSumValue4 = AllSumValue4+decimal.Parse(dl["BSumActualMoney"].ToString());
	
	 AllSumValue5 = AllSumValue5+decimal.Parse(dl["SYMoney"].ToString());
	
	templateBuilder.Append("					  </tr>\r\n");

	}	//end loop

	 AllSumValue = AllSumValue5;
	

	}	//end if

	templateBuilder.Append("				  <tr>\r\n");
	templateBuilder.Append("					<td>合计:</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue1.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue2.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue3.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue4.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue5.ToString() + "</td>\r\n");
	templateBuilder.Append("				  </tr>\r\n");
	templateBuilder.Append("			</table>\r\n");

	}	//end if

	 ARMoney_P_Sum = AllSumValue;
	
	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <!--<tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("	<td align=\"right\">\r\n");
	templateBuilder.Append("			" + AllSumValue.ToString() + "\r\n");
	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>-->\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"5\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\"><h3><b>应付款(公司) " + eDateTime.ToString() + "</b></h3></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("<tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\">\r\n");

	if (ispost)
	{

	 AllSumValue = 0;
	
	 AllSumValue1 = 0;
	
	 AllSumValue2 = 0;
	
	 AllSumValue3 = 0;
	
	 AllSumValue4 = 0;
	
	 AllSumValue5 = 0;
	
	templateBuilder.Append("			<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("				<tr class=\"tBar\">\r\n");
	templateBuilder.Append("					<td >姓名</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计应付金额</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计已付金额</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计其他已付金额</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">剩余应付金额</td>\r\n");
	templateBuilder.Append("				</tr>\r\n");

	if (APMoney_E_List != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in APMoney_E_List.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("					  <tr>\r\n");
	templateBuilder.Append("						<td >" + dl["sName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SumNPMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SumPayMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SumOtherMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SYMoney"].ToString().Trim() + "</td>\r\n");
	 AllSumValue1 = AllSumValue1+decimal.Parse(dl["SumNPMoney"].ToString());
	
	 AllSumValue2 = AllSumValue2+decimal.Parse(dl["SumPayMoney"].ToString());
	
	 AllSumValue3 = AllSumValue3+decimal.Parse(dl["SumOtherMoney"].ToString());
	
	 AllSumValue4 = AllSumValue4+decimal.Parse(dl["SYMoney"].ToString());
	
	templateBuilder.Append("					  </tr>\r\n");

	}	//end loop

	 AllSumValue = AllSumValue4;
	

	}	//end if

	templateBuilder.Append("			</table>\r\n");

	}	//end if

	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("	<td align=\"right\">\r\n");
	templateBuilder.Append("			" + AllSumValue.ToString() + "\r\n");
	 APMoney_E_Sum = AllSumValue;
	
	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"5\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\"><h3><b>应付款(个人) " + eDateTime.ToString() + "</b></h3></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\">\r\n");

	if (ispost)
	{

	 AllSumValue = 0;
	
	 AllSumValue1 = 0;
	
	 AllSumValue2 = 0;
	
	 AllSumValue3 = 0;
	
	 AllSumValue4 = 0;
	
	 AllSumValue5 = 0;
	
	templateBuilder.Append("			<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("				<tr class=\"tBar\">\r\n");
	templateBuilder.Append("					<td >姓名</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计应付金额</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计已付金额</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计其他已付金额</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">剩余应付金额</td>\r\n");
	templateBuilder.Append("				</tr>\r\n");

	if (APMoney_P_List != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in APMoney_P_List.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("					  <tr>\r\n");
	templateBuilder.Append("						<td >" + dl["sName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SumNPMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SumPayMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SumOtherMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SYMoney"].ToString().Trim() + "</td>\r\n");
	 AllSumValue1 = AllSumValue1+decimal.Parse(dl["SumNPMoney"].ToString());
	
	 AllSumValue2 = AllSumValue2+decimal.Parse(dl["SumPayMoney"].ToString());
	
	 AllSumValue3 = AllSumValue3+decimal.Parse(dl["SumOtherMoney"].ToString());
	
	 AllSumValue4 = AllSumValue4+decimal.Parse(dl["SYMoney"].ToString());
	
	templateBuilder.Append("					  </tr>\r\n");

	}	//end loop

	 AllSumValue = AllSumValue4;
	

	}	//end if

	templateBuilder.Append("				  <tr>\r\n");
	templateBuilder.Append("					<td>小计:</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue1.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue2.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue3.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue4.ToString() + "</td>\r\n");
	templateBuilder.Append("				  </tr>\r\n");
	templateBuilder.Append("			</table>\r\n");

	}	//end if

	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("	<td align=\"right\">\r\n");
	templateBuilder.Append("			" + AllSumValue.ToString() + "\r\n");
	 APMoney_P_Sum = AllSumValue;
	
	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"5\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"2\"><h3><b>库存 " + eDateTime.ToString() + "</b></h3></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("	<td colspan=\"2\">\r\n");

	if (ispost)
	{

	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("			<tr class=\"tBar\">\r\n");
	templateBuilder.Append("				<td width=\"2%\">排名</td>\r\n");
	templateBuilder.Append("				<td width=\"10%\">名称</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">品牌</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">库存量</td>\r\n");
	templateBuilder.Append("				<td width=\"3%\">箱数</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">金额</td>\r\n");
	templateBuilder.Append("			</tr>\r\n");

	if (StockDataList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in StockDataList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("			  <tr>\r\n");
	templateBuilder.Append("				<td >" + dl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td >" + dl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td >" + dl["pBrand"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["S_QUANTITY"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">\r\n");
	 aspxrewriteurl = (decimal.Parse(dl["S_QUANTITY"].ToString()) / decimal.Parse(dl["pToBoxNo"].ToString())).ToString("0.00");
	
	templateBuilder.Append("				" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("				</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["sumPrice"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			  </tr>\r\n");
	 AllSumValue = AllSumValue+decimal.Parse(dl["sumPrice"].ToString());
	

	}	//end loop


	}	//end if

	templateBuilder.Append("		</table>\r\n");

	}	//end if

	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("	<td align=\"right\">\r\n");
	templateBuilder.Append("			" + AllSumValue.ToString() + "\r\n");
	 StockData_Sum = AllSumValue;
	
	templateBuilder.Append("	</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"5\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td><h3>固定资产 " + eDateTime.ToString() + "</h3></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"5\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td><h3>净资产 " + eDateTime.ToString() + "</h3></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>\r\n");
	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td width=\"50%\" align=\"center\">项目</td>\r\n");
	templateBuilder.Append("    <td align=\"center\">金额</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>现金</td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = (BankMoney_Sum).ToString("0.00");
	
	templateBuilder.Append("	" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>应收款</td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = (ARMoney_E_Sum+ARMoney_P_Sum+APMoney_PaySystem_Sum).ToString("0.00");
	
	templateBuilder.Append("	" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>应付款</td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = (APMoney_E_Sum+APMoney_P_Sum).ToString("0.00");
	
	templateBuilder.Append("	" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>库存</td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = (StockData_Sum).ToString("0.00");
	
	templateBuilder.Append("	" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>固定资产</td>\r\n");
	templateBuilder.Append("    <td align=\"right\">0</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>合计:</td>\r\n");
	templateBuilder.Append("    <td align=\"right\">\r\n");
	 aspxrewriteurl = (BankMoney_Sum+(ARMoney_E_Sum+ARMoney_P_Sum)-(APMoney_E_Sum+APMoney_P_Sum)+StockData_Sum).ToString("0.00");
	
	templateBuilder.Append("	" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");

	}	//end if

	templateBuilder.Append("		</div>\r\n");
	templateBuilder.Append("	</div>\r\n");



	}	//end if


	if (Act=="A" || Act=="E" || Act=="F" )
	{

	templateBuilder.Append("        <div id=\"datalist_A\">\r\n");
	templateBuilder.Append("		<div class=\"toolbar_X\">\r\n");
	templateBuilder.Append("			<ul>\r\n");

	if (Act=="E" || Act=="F")
	{

	templateBuilder.Append("					<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_G\" value=\"7\" \r\n");

	if (ShowType==7)
	{

	templateBuilder.Append("					checked\r\n");

	}	//end if

	templateBuilder.Append(" ><a >综合(含公司费用)</a></li>\r\n");

	}	//end if

	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_A\" value=\"1\" \r\n");

	if (ShowType==1)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append(" ><a >门店/客户</a></li>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_B\" value=\"2\" \r\n");

	if (ShowType==2)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append("  ><a >业务员</a></li>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_C\" value=\"3\" \r\n");

	if (ShowType==3)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append("  ><a >促销员</a></li>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_D\" value=\"4\" \r\n");

	if (ShowType==4)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append("  ><a >产品</a></li>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_E\" value=\"5\" \r\n");

	if (ShowType==5)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append("  ><a >品牌</a></li>\r\n");

	if (Act=="A")
	{

	templateBuilder.Append("					<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_F\" value=\"6\" \r\n");

	if (ShowType==6)
	{

	templateBuilder.Append("					checked\r\n");

	}	//end if

	templateBuilder.Append("  ><a >系统</a></li>\r\n");

	}	//end if

	templateBuilder.Append("			</ul>\r\n");
	templateBuilder.Append("		</div>\r\n");

	if (Act=="A")
	{


	templateBuilder.Append("<div class=\"dlist\">\r\n");

	if (ispost)
	{

	templateBuilder.Append("	<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("	<tr class=\"tBar\">\r\n");
	templateBuilder.Append("		<td width=\"5%\">排名</td>\r\n");
	templateBuilder.Append("		<td >名称</td>\r\n");
	templateBuilder.Append("		<td width=\"10%\">销售额</td>\r\n");
	templateBuilder.Append("		<td width=\"5%\">占比</td>\r\n");

	if (ShowType==4)
	{

	templateBuilder.Append("		<td width=\"10%\">销售量</td>\r\n");

	}	//end if


	if (ShowType==6)
	{

	templateBuilder.Append("		<td width=\"5%\">门店数</td>\r\n");
	templateBuilder.Append("		<td width=\"10%\">平均销售额</td>\r\n");

	}	//end if

	templateBuilder.Append("	  </tr>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("	  <tr>\r\n");
	templateBuilder.Append("		<td >" + dl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("		<td >" + dl[0].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		<td align=\"right\">" + dl[1].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		<td align=\"right\">\r\n");
	 aspxrewriteurl = (decimal.Parse(dl[1].ToString()) / AllSumValue).ToString("P");
	
	templateBuilder.Append("		" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("		</td>\r\n");

	if (ShowType==4 || ShowType==6)
	{

	templateBuilder.Append("		<td align=\"right\">\r\n");
	templateBuilder.Append("		" + dl[2].ToString().Trim() + "\r\n");
	templateBuilder.Append("		</td>\r\n");

	if (ShowType==6)
	{

	templateBuilder.Append("			<td align=\"right\">\r\n");

	if (int.Parse(dl[2].ToString())!=0)
	{

	 aspxrewriteurl = (decimal.Parse(dl[1].ToString()) / int.Parse(dl[2].ToString())).ToString("f2");
	
	templateBuilder.Append("				" + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("				0.00%\r\n");

	}	//end if

	templateBuilder.Append("			</td>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("	  </tr>\r\n");

	}	//end loop

	templateBuilder.Append("	  <tr>\r\n");
	templateBuilder.Append("		<td >合计</td>\r\n");
	templateBuilder.Append("		<td align=\"right\"></td>\r\n");
	templateBuilder.Append("		<td align=\"right\">" + AllSumValue.ToString() + "</td>\r\n");
	templateBuilder.Append("		<td align=\"right\"></td>\r\n");

	if (ShowType==4 || ShowType==6)
	{

	templateBuilder.Append("		<td align=\"right\"></td>\r\n");

	if (ShowType==6)
	{

	templateBuilder.Append("			<td align=\"right\"></td>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("	  </tr>\r\n");

	}	//end if

	templateBuilder.Append("	</table>\r\n");

	}	//end if

	templateBuilder.Append("</div>\r\n");



	}	//end if


	if (Act=="E" || Act=="F")
	{


	if (ShowType==7)
	{

	templateBuilder.Append("					<div class=\"toolbar_X\">\r\n");

	templateBuilder.Append("<ul>\r\n");
	templateBuilder.Append("	<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"AShowType\" id=\"AShowType_A\" value=\"0\" \r\n");

	if (AShowType==0)
	{

	templateBuilder.Append("	checked\r\n");

	}	//end if

	templateBuilder.Append(" ><a >比例（饼图）</a></li>\r\n");
	templateBuilder.Append("	<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"AShowType\" id=\"AShowType_A\" value=\"1\" \r\n");

	if (AShowType==1)
	{

	templateBuilder.Append("	checked\r\n");

	}	//end if

	templateBuilder.Append(" ><a >日</a></li>\r\n");
	templateBuilder.Append("	<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"AShowType\" id=\"AShowType_B\" value=\"2\" \r\n");

	if (AShowType==2)
	{

	templateBuilder.Append("	checked\r\n");

	}	//end if

	templateBuilder.Append("  ><a >月</a></li>\r\n");
	templateBuilder.Append("	<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"AShowType\" id=\"AShowType_C\" value=\"3\" \r\n");

	if (AShowType==3)
	{

	templateBuilder.Append("	checked\r\n");

	}	//end if

	templateBuilder.Append("  ><a >年</a></li>\r\n");
	templateBuilder.Append("</ul>\r\n");


	templateBuilder.Append("					</div>\r\n");
	templateBuilder.Append("					<div class=\"dlist\">\r\n");

	if (ispost)
	{

	templateBuilder.Append("							<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("								<tr class=\"tBar\">\r\n");
	templateBuilder.Append("									<td width=\"5%\">销售额</td>\r\n");

	if (Act=="E")
	{

	templateBuilder.Append("									<td width=\"5%\">公司费用</td>\r\n");

	}	//end if

	templateBuilder.Append("									<td width=\"5%\">销售费用</td>\r\n");
	templateBuilder.Append("									<td width=\"5%\">赠品</td>\r\n");
	templateBuilder.Append("									<td width=\"5%\">坏货</td>\r\n");
	templateBuilder.Append("									<td width=\"5%\">退货</td>\r\n");
	templateBuilder.Append("									<td width=\"5%\">成本</td>\r\n");

	if (Act=="E")
	{

	templateBuilder.Append("									<td width=\"5%\">利润</td>\r\n");

	}	//end if


	if (Act=="F")
	{

	templateBuilder.Append("									<td width=\"5%\">毛利</td>\r\n");

	}	//end if

	templateBuilder.Append("								</tr>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("								  <tr>\r\n");
	templateBuilder.Append("									<td align=\"right\">" + dl[0].ToString().Trim() + "</td>\r\n");

	if (Act=="E")
	{

	templateBuilder.Append("									<td align=\"right\">" + dl[6].ToString().Trim() + "</td>\r\n");

	}	//end if

	templateBuilder.Append("									<td align=\"right\">" + dl[5].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("									<td align=\"right\">" + dl[4].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("									<td align=\"right\">" + dl[3].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("									<td align=\"right\">" + dl[2].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("									<td align=\"right\">" + dl[1].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("									<td align=\"right\">\r\n");

	if (Act=="E")
	{

	 aspxrewriteurl = (decimal.Parse(dl[0].ToString())-decimal.Parse(dl[1].ToString())-decimal.Parse(dl[5].ToString())-decimal.Parse(dl[6].ToString())).ToString();
	

	}	//end if


	if (Act=="F")
	{

	 aspxrewriteurl = (decimal.Parse(dl[0].ToString())-decimal.Parse(dl[1].ToString())-decimal.Parse(dl[5].ToString())).ToString();
	

	}	//end if

	templateBuilder.Append("									" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("									</td>\r\n");
	templateBuilder.Append("								  </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("							</table>\r\n");

	}	//end if

	templateBuilder.Append("					</div>\r\n");
	templateBuilder.Append("					<div id=\"datalist_E\">\r\n");
	templateBuilder.Append("						<div class=\"dlist\">\r\n");
	templateBuilder.Append("						" + ReHTML.ToString() + "\r\n");
	templateBuilder.Append("						</div>\r\n");
	templateBuilder.Append("					</div>\r\n");

	}
	else if (ShowType==4 || ShowType==5)
	{


	templateBuilder.Append("<div class=\"dlist\">\r\n");

	if (ispost)
	{

	templateBuilder.Append("		<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("			<tr class=\"tBar\">\r\n");
	templateBuilder.Append("				<td width=\"2%\">排名</td>\r\n");

	if (ShowType==4)
	{

	templateBuilder.Append("				<td width=\"10%\">产品</td>\r\n");

	}	//end if


	if (ShowType==5)
	{

	templateBuilder.Append("				<td width=\"10%\">品牌</td>\r\n");

	}	//end if

	templateBuilder.Append("				<td width=\"5%\">销售额</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">销售量</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">坏货</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">退货</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">成本</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">利润</td>\r\n");
	templateBuilder.Append("			</tr>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("			  <tr>\r\n");
	templateBuilder.Append("				<td >" + dl__loop__id.ToString() + "</td>\r\n");

	if (ShowType==4)
	{

	templateBuilder.Append("				<td >" + dl[1].ToString().Trim() + "</td>\r\n");

	}	//end if


	if (ShowType==5)
	{

	templateBuilder.Append("				<td >" + dl[0].ToString().Trim() + "</td>\r\n");

	}	//end if

	templateBuilder.Append("				<td align=\"right\">" + dl["S_TOTAL"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["S_QUANTITY"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["BadgoodsFees"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["ReturnsFees"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["CostFees"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["Profit"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			  </tr>\r\n");

	}	//end loop

	templateBuilder.Append("			  <tr>\r\n");
	templateBuilder.Append("				<td >合计</td>\r\n");
	templateBuilder.Append("				<td align=\"right\"></td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllSales.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + ALLS_QUANTITY.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllBadgoodsFees.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllReturnsFees.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllCostFees.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllProfit.ToString() + "</td>\r\n");
	templateBuilder.Append("			  </tr>\r\n");

	}	//end if

	templateBuilder.Append("		</table>\r\n");

	}	//end if

	templateBuilder.Append("</div>\r\n");



	}
	else
	{


	templateBuilder.Append("<div class=\"dlist\">\r\n");

	if (ispost)
	{

	templateBuilder.Append("		<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("			<tr class=\"tBar\">\r\n");
	templateBuilder.Append("				<td width=\"2%\">排名</td>\r\n");

	if (ShowType==1)
	{

	templateBuilder.Append("					<td width=\"10%\">门店、客户</td>\r\n");

	}	//end if


	if (ShowType==2)
	{

	templateBuilder.Append("					<td width=\"10%\">业务员</td>\r\n");

	}	//end if


	if (ShowType==3)
	{

	templateBuilder.Append("					<td width=\"10%\">促销员</td>\r\n");

	}	//end if


	if (ShowType==4)
	{

	templateBuilder.Append("					<td width=\"10%\">产品</td>\r\n");

	}	//end if


	if (ShowType==5)
	{

	templateBuilder.Append("					<td width=\"10%\">品牌</td>\r\n");

	}	//end if


	if (ShowType==6)
	{

	templateBuilder.Append("					<td width=\"10%\">系统</td>\r\n");

	}	//end if

	templateBuilder.Append("				<td width=\"5%\">销售额</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">销售费用</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">赠品</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">坏货</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">退货</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">成本</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">利润</td>\r\n");
	templateBuilder.Append("			</tr>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("			  <tr>\r\n");
	templateBuilder.Append("				<td >" + dl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td >" + dl["sName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["Sales"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["SalesFees"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["GiftsFees"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["BadgoodsFees"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["ReturnsFees"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["CostFees"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["Profit"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			  </tr>\r\n");

	}	//end loop

	templateBuilder.Append("			  <tr>\r\n");
	templateBuilder.Append("				<td >合计</td>\r\n");
	templateBuilder.Append("				<td align=\"right\"></td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllSales.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllSalesFees.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllGiftsFees.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllBadgoodsFees.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllReturnsFees.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllCostFees.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllProfit.ToString() + "</td>\r\n");
	templateBuilder.Append("			  </tr>\r\n");

	}	//end if

	templateBuilder.Append("		</table>\r\n");

	}	//end if

	templateBuilder.Append("</div>\r\n");



	}	//end if


	}	//end if

	templateBuilder.Append("        </div>\r\n");

	}	//end if


	if (Act=="H1")
	{


	templateBuilder.Append("<div id=\"datalist_A\">\r\n");
	templateBuilder.Append("		<div class=\"toolbar_X\">\r\n");
	templateBuilder.Append("			<ul>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_H\" value=\"8\" \r\n");

	if (ShowType==8)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append(" ><a >公司费用</a></li>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_I\" value=\"9\" \r\n");

	if (ShowType==9)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append(" ><a >销售费用</a></li>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_I\" value=\"10\" \r\n");

	if (ShowType==10)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append(" ><a >收入</a></li>\r\n");
	templateBuilder.Append("			</ul>\r\n");
	templateBuilder.Append("		</div>\r\n");
	templateBuilder.Append("		<div class=\"dlist\">\r\n");

	if (ispost)
	{

	templateBuilder.Append("			<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("				<tr class=\"tBar\">\r\n");
	templateBuilder.Append("					<td width=\"5%\">排名</td>\r\n");

	if (ShowType==8 || ShowType==10)
	{

	templateBuilder.Append("					<td >科目</td>\r\n");

	}	//end if


	if (ShowType==9)
	{

	templateBuilder.Append("					<td >门店、客户</td>\r\n");

	}	//end if

	templateBuilder.Append("					<td width=\"10%\">费用</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">占比</td>\r\n");
	templateBuilder.Append("				</tr>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("					  <tr>\r\n");
	templateBuilder.Append("						<td >" + dl__loop__id.ToString() + "</td>\r\n");

	if (ShowType==9)
	{

	templateBuilder.Append("						<td ><a href=\"dataanalysisfee-" + dl[2].ToString().Trim() + ".aspx?bDate=" + bDateTime.ToString() + "&eDate=" + eDateTime.ToString() + "\" target=\"_blank\">" + dl[0].ToString().Trim() + "</a></td>\r\n");

	}
	else if (ShowType==8)
	{

	templateBuilder.Append("						<td ><a href=\"dataanalysisfee-com-" + dl[2].ToString().Trim() + ".aspx?bDate=" + bDateTime.ToString() + "&eDate=" + eDateTime.ToString() + "\" target=\"_blank\">" + dl[0].ToString().Trim() + "</a></td>\r\n");

	}
	else
	{

	templateBuilder.Append("						<td >" + dl[0].ToString().Trim() + "</td>\r\n");

	}	//end if

	templateBuilder.Append("						<td align=\"right\">" + dl[1].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">\r\n");

	if (decimal.Parse(dl[1].ToString())>0)
	{

	 aspxrewriteurl = (decimal.Parse(dl[1].ToString()) / AllSumValue).ToString("p");
	
	templateBuilder.Append("						" + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("						0.00%\r\n");

	}	//end if

	templateBuilder.Append("						</td>\r\n");
	templateBuilder.Append("					  </tr>\r\n");

	}	//end loop

	templateBuilder.Append("				  <tr>\r\n");
	templateBuilder.Append("					<td>合计:</td>\r\n");
	templateBuilder.Append("					<td></td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td></td>\r\n");
	templateBuilder.Append("				  </tr>\r\n");

	}	//end if

	templateBuilder.Append("			</table>\r\n");

	}	//end if

	templateBuilder.Append("		</div>\r\n");
	templateBuilder.Append("	</div>\r\n");



	}	//end if


	if (Act=="H2")
	{

	templateBuilder.Append("	<!--应收应付-->\r\n");
	templateBuilder.Append("    <div id=\"datalist_B\">\r\n");
	templateBuilder.Append("		<div class=\"dlist\">\r\n");

	templateBuilder.Append("<div id=\"datalist_A\">\r\n");
	templateBuilder.Append("		<div class=\"toolbar_X\">\r\n");
	templateBuilder.Append("			<ul>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_H\" value=\"1\" \r\n");

	if (ShowType==1)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append(" ><a >客户应收</a></li>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_I\" value=\"2\" \r\n");

	if (ShowType==2)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append(" ><a >个人应收</a></li>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_I\" value=\"3\" \r\n");

	if (ShowType==3)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append(" ><a >供货商应付</a></li>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_I\" value=\"4\" \r\n");

	if (ShowType==4)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append(" ><a >个人应付</a></li>\r\n");
	templateBuilder.Append("			</ul>\r\n");
	templateBuilder.Append("		</div>\r\n");
	templateBuilder.Append("		<div class=\"dlist\">\r\n");

	if (ispost)
	{

	templateBuilder.Append("			<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("				<tr class=\"tBar\">\r\n");
	templateBuilder.Append("					<td width=\"5%\">排名</td>\r\n");

	if (ShowType==2 || ShowType==4)
	{

	templateBuilder.Append("					<td >姓名</td>\r\n");

	}	//end if


	if (ShowType==1)
	{

	templateBuilder.Append("					<td >门店、客户</td>\r\n");

	}	//end if


	if (ShowType==3)
	{

	templateBuilder.Append("					<td >供货商</td>\r\n");

	}	//end if


	if (ShowType==1 || ShowType==2)
	{

	templateBuilder.Append("					<td width=\"10%\">累计新增应收金额<br>(未完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计新增应收金额<br>(已完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">实际对账金额<br>(已完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">实际已收款金额<br>(已完成)</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">剩余应收金额</td>\r\n");

	}	//end if


	if (ShowType==3 || ShowType==4)
	{

	templateBuilder.Append("					<td width=\"10%\">累计应付金额</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计已付金额</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">累计其他已付金额</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">剩余应付金额</td>\r\n");

	}	//end if

	templateBuilder.Append("				</tr>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("					  <tr>\r\n");
	templateBuilder.Append("						<td >" + dl__loop__id.ToString() + "</td>\r\n");

	if (ShowType==1 || ShowType==4)
	{

	templateBuilder.Append("						<td >" + dl["sName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	if (ShowType==0)
	{

	templateBuilder.Append("						<td >" + dl["sName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	if (ShowType==3)
	{

	templateBuilder.Append("						<td >" + dl["sName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	if (ShowType==2)
	{

	templateBuilder.Append("						<td >" + dl["sName"].ToString().Trim() + "</td>\r\n");

	}	//end if


	if (ShowType==1 || ShowType==2)
	{

	templateBuilder.Append("						<td align=\"right\">" + dl["ASumAMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BSumAMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BSumBMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BSumActualMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SYMoney"].ToString().Trim() + "</td>\r\n");

	}	//end if


	if (ShowType==3 || ShowType==4)
	{

	templateBuilder.Append("						<td align=\"right\">" + dl["SumPMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SumPayMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SumOtherMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["SYMoney"].ToString().Trim() + "</td>\r\n");

	}	//end if

	templateBuilder.Append("					  </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("				  <tr>\r\n");
	templateBuilder.Append("					<td>合计:</td>\r\n");
	templateBuilder.Append("					<td></td>\r\n");

	if (ShowType==1 || ShowType==2)
	{

	templateBuilder.Append("					<td align=\"right\">" + AllSumValue1.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue2.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue3.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue4.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue5.ToString() + "</td>\r\n");

	}	//end if


	if (ShowType==3 || ShowType==4)
	{

	templateBuilder.Append("					<td align=\"right\">" + AllSumValue1.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue2.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue3.ToString() + "</td>\r\n");
	templateBuilder.Append("					<td align=\"right\">" + AllSumValue4.ToString() + "</td>\r\n");

	}	//end if

	templateBuilder.Append("				  </tr>\r\n");
	templateBuilder.Append("			</table>\r\n");

	}	//end if

	templateBuilder.Append("		</div>\r\n");
	templateBuilder.Append("	</div>\r\n");


	templateBuilder.Append("		</div>\r\n");
	templateBuilder.Append("    </div>\r\n");

	}	//end if


	if (Act=="H3")
	{

	templateBuilder.Append("	<!--库存-->\r\n");
	templateBuilder.Append("    <div id=\"datalist_B\">\r\n");
	templateBuilder.Append("		<div class=\"dlist\">\r\n");

	templateBuilder.Append("<div class=\"dlist\">\r\n");

	if (ispost)
	{

	templateBuilder.Append("		<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("			<tr class=\"tBar\">\r\n");
	templateBuilder.Append("				<td width=\"2%\">排名</td>\r\n");
	templateBuilder.Append("				<td width=\"10%\">名称</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">品牌</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">库存量</td>\r\n");
	templateBuilder.Append("				<td width=\"3%\">规格</td>\r\n");
	templateBuilder.Append("				<td width=\"3%\">单位</td>\r\n");
	templateBuilder.Append("				<td width=\"3%\">装箱数</td>\r\n");
	templateBuilder.Append("				<td width=\"3%\">箱数</td>\r\n");
	templateBuilder.Append("				<td width=\"5%\">金额</td>\r\n");
	templateBuilder.Append("			</tr>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("			  <tr>\r\n");
	templateBuilder.Append("				<td >" + dl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("				<td >" + dl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td >" + dl["pBrand"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">\r\n");
	 aspxrewriteurl = (decimal.Parse(dl["S_QUANTITY"].ToString())+decimal.Parse(dl["pDoDayQuantity"].ToString())).ToString();
	
	templateBuilder.Append("			" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("				</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["pStandard"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["pUnits"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["pToBoxNo"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">\r\n");
	 aspxrewriteurl = ((decimal.Parse(dl["S_QUANTITY"].ToString())+decimal.Parse(dl["pDoDayQuantity"].ToString())) / decimal.Parse(dl["pToBoxNo"].ToString())).ToString("0.00");
	
	templateBuilder.Append("				" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("				</td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + dl["sumPrice"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("			  </tr>\r\n");

	}	//end loop

	templateBuilder.Append("			  <tr>\r\n");
	templateBuilder.Append("				<td >合计</td>\r\n");
	templateBuilder.Append("				<td align=\"right\"></td>\r\n");
	templateBuilder.Append("				<td align=\"right\"></td>\r\n");
	templateBuilder.Append("				<td align=\"right\"></td>\r\n");
	templateBuilder.Append("				<td align=\"right\"></td>\r\n");
	templateBuilder.Append("				<td align=\"right\"></td>\r\n");
	templateBuilder.Append("				<td align=\"right\"></td>\r\n");
	templateBuilder.Append("				<td align=\"right\"></td>\r\n");
	templateBuilder.Append("				<td align=\"right\">" + AllSumValue.ToString() + "</td>\r\n");
	templateBuilder.Append("			  </tr>\r\n");

	}	//end if

	templateBuilder.Append("		</table>\r\n");

	}	//end if

	templateBuilder.Append("</div> \r\n");


	templateBuilder.Append("		</div>\r\n");
	templateBuilder.Append("    </div>\r\n");

	}	//end if


	if (Act=="H4")
	{

	templateBuilder.Append("	<!--库存-->\r\n");
	templateBuilder.Append("    <div id=\"datalist_B\">\r\n");
	templateBuilder.Append("		<div class=\"dlist\">\r\n");

	templateBuilder.Append("<div class=\"dlist\">\r\n");

	if (ispost)
	{

	templateBuilder.Append("		<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("          <tr class=\"tBar\">\r\n");
	templateBuilder.Append("			<td width=\"5%\">日期</td>\r\n");

	if (fList != null)
	{


	int fl__loop__id=0;
	foreach(DataRow fl in fList.Rows)
	{
		fl__loop__id++;

	templateBuilder.Append("					<td >" + fl["bName"].ToString().Trim() + "</td>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("			<td width=\"5%\">合计</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("			<td><nobr>" + dl["tdate"].ToString().Trim() + "</nobr></td>\r\n");
	 AllSumValue = 0;
	

	if (fList != null)
	{


	int fl__loop__id=0;
	foreach(DataRow fl in fList.Rows)
	{
		fl__loop__id++;

	templateBuilder.Append("					<td  align=\"right\">\r\n");
	 AllSumValue = AllSumValue+decimal.Parse(dl["Bank_"+(fl__loop__id-1).ToString()].ToString());
	
	 ReHTML = dl["Bank_"+(fl__loop__id-1).ToString()].ToString();
	
	templateBuilder.Append("					" + ReHTML.ToString() + "\r\n");
	templateBuilder.Append("					</td>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("            <td align=\"right\">\r\n");
	templateBuilder.Append("			" + AllSumValue.ToString() + "\r\n");
	templateBuilder.Append("			</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("        </table>\r\n");

	}	//end if

	templateBuilder.Append("</div>\r\n");


	templateBuilder.Append("		</div>\r\n");
	templateBuilder.Append("    </div>\r\n");

	}	//end if


	if (Act=="H6")
	{

	templateBuilder.Append("	<!--净资产-->\r\n");
	templateBuilder.Append("    <div id=\"datalist_B\">\r\n");
	templateBuilder.Append("		<div class=\"dlist\">\r\n");

	templateBuilder.Append("<div id=\"datalist_A\">\r\n");
	templateBuilder.Append("		<div class=\"dlist\">\r\n");

	if (ispost)
	{

	templateBuilder.Append("			<table width=\"100%\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("				<tr class=\"tBar\">\r\n");
	templateBuilder.Append("					<td width=\"10%\">现金银行</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">库存</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">固定资产</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">个人应收</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">公司应收</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">个人应付</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">公司应付</td>\r\n");
	templateBuilder.Append("					<td width=\"10%\">净资产</td>\r\n");
	templateBuilder.Append("				</tr>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("					  <tr>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["BankMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["StockMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">0</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["ARMoney_A"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["ARMoney_B"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["APMoney_A"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["APMoney_B"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("						<td align=\"right\">" + dl["NetAssetsMoney"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("					  </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("			</table>\r\n");

	}	//end if

	templateBuilder.Append("		</div>\r\n");
	templateBuilder.Append("	</div>\r\n");


	templateBuilder.Append("		</div>\r\n");
	templateBuilder.Append("    </div>\r\n");

	}	//end if


	if (Act=="A1" || Act=="A2" || Act=="A3" || Act=="A4" || Act=="A5" || Act=="A6" || Act=="E1" || Act=="E2" || Act=="E3" || Act=="E4" || Act=="E5" || Act=="E6" || Act=="F1" || Act=="F2" || Act=="F3" || Act=="F4" || Act=="F5" || Act=="F6" || Act=="G1" || Act=="G2" || Act=="G3" || Act=="G4" || Act=="G5" || Act=="G6")
	{

	templateBuilder.Append("    <div id=\"datalist_A1\">\r\n");
	templateBuilder.Append("		<div class=\"toolbar_X\">\r\n");
	templateBuilder.Append("			<span>\r\n");
	templateBuilder.Append("			选择\r\n");

	if (Act=="A1" || Act=="E1" || Act=="F1" || Act=="G1")
	{

	templateBuilder.Append("				客户、门店:\r\n");

	}	//end if


	if (Act=="A2" || Act=="E2" || Act=="F2" || Act=="G2")
	{

	templateBuilder.Append("				业务员:\r\n");

	}	//end if


	if (Act=="A3" || Act=="E3" || Act=="F3" || Act=="G3")
	{

	templateBuilder.Append("				促销员:\r\n");

	}	//end if


	if (Act=="A4" || Act=="E4" || Act=="F4" || Act=="G4")
	{

	templateBuilder.Append("				产品:\r\n");

	}	//end if


	if (Act=="A5" || Act=="E5" || Act=="F5" || Act=="G5")
	{

	templateBuilder.Append("				品牌:\r\n");

	}	//end if


	if (Act=="A6" || Act=="E6" || Act=="F6" || Act=="G6")
	{

	templateBuilder.Append("				系统:\r\n");

	}	//end if

	templateBuilder.Append("				<INPUT TYPE=\"text\" NAME=\"A_Value\" id=\"A_Value\" onClick=\"javascript:DataAnalysis.ShowTitleBox('" + Act.ToString() + "');\" value=\"" + A_Value.ToString() + "\">\r\n");
	templateBuilder.Append("				<INPUT TYPE=\"hidden\" NAME=\"A_Value_ID\" id=\"A_Value_ID\" value=\"" + A_Value_ID.ToString() + "\" />\r\n");
	templateBuilder.Append("			</span>\r\n");
	templateBuilder.Append("			<ul>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_A\" value=\"1\" \r\n");

	if (ShowType==1)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append(" ><a >日</a></li>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_B\" value=\"2\" \r\n");

	if (ShowType==2)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append("  ><a >月</a></li>\r\n");
	templateBuilder.Append("				<li><INPUT class=\"B_Check\" TYPE=\"radio\" NAME=\"ShowType\" id=\"ShowType_C\" value=\"3\" \r\n");

	if (ShowType==3)
	{

	templateBuilder.Append("				checked\r\n");

	}	//end if

	templateBuilder.Append("  ><a >年</a></li>\r\n");
	templateBuilder.Append("			</ul>\r\n");
	templateBuilder.Append("		</div>\r\n");
	templateBuilder.Append("		<div class=\"dlist\">\r\n");
	templateBuilder.Append("		" + ReHTML.ToString() + "\r\n");
	templateBuilder.Append("		</div>\r\n");
	templateBuilder.Append("    </div>\r\n");

	}	//end if

	templateBuilder.Append("    </div>\r\n");
	templateBuilder.Append("</form>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("$().ready(function(){\r\n");
	templateBuilder.Append("	$('#StoresName').autocomplete('Services/CAjax.aspx',{\r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetStoresList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'StoresName':function(){return $('#StoresName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value    \r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted) {\r\n");
	templateBuilder.Append("			$(\"#StoresID\").val((formatted!=null)?formatted:\"0\");      \r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("	$('#StaffName').autocomplete('Services/CAjax.aspx',{ \r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetStaffList',\r\n");
	templateBuilder.Append("			'sType':1,\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'StaffName':function(){return $('#StaffName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value    \r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted) {\r\n");
	templateBuilder.Append("			$(\"#StaffID\").val((formatted!=null)?formatted:\"0\");\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("	  $('#StaffNameB').autocomplete('Services/CAjax.aspx',{ \r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetStaffList',\r\n");
	templateBuilder.Append("			'sType':2,\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'StaffName':function(){return $('#StaffNameB').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value    \r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted) {\r\n");
	templateBuilder.Append("			$(\"#StaffIDB\").val((formatted!=null)?formatted:\"0\");\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("	  $('#ProductName').autocomplete('Services/CAjax.aspx',{ \r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetProductsList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'ProductsName':function(){return $('#ProductName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value    \r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted) {\r\n");
	templateBuilder.Append("			$(\"#ProductID\").val((formatted!=null)?formatted:\"0\");\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("	  $('#YHsysName').autocomplete('Services/CAjax.aspx',{ \r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetYHsysList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'YHsysName':function(){return $('#YHsysName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value +\"(\"+ tArray[i].info+\")\",    \r\n");
	templateBuilder.Append("					value:tArray[i].id,    \r\n");
	templateBuilder.Append("					result:tArray[i].value    \r\n");
	templateBuilder.Append("					};    \r\n");
	templateBuilder.Append("				  }\r\n");
	templateBuilder.Append("			   return rows; \r\n");
	templateBuilder.Append("			 },\r\n");
	templateBuilder.Append("		formatItem: function(row, i, max) {  \r\n");
	templateBuilder.Append("			   return row;\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatMatch: function(row, i, max) {\r\n");
	templateBuilder.Append("					return row.value; \r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		formatResult: function(row) { \r\n");
	templateBuilder.Append("					return row.value;\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  }).result(function(event, data, formatted) {\r\n");
	templateBuilder.Append("			$(\"#YHsysID\").val((formatted!=null)?formatted:\"0\");\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("});\r\n");
	templateBuilder.Append("function BuildRegionTool(_nodes,tObj)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	var tHTML='';\r\n");
	templateBuilder.Append("	if(_nodes && tObj)\r\n");
	templateBuilder.Append("	{\r\n");
	templateBuilder.Append("		tObjs = new TCxty_XTool(13,'',_nodes,null,null,'RegionSelect');\r\n");
	templateBuilder.Append("		tObj.innerHTML = tObjs;\r\n");

	if (Act!="")
	{

	templateBuilder.Append("		tObjs.setValue('" + RegionID.ToString() + "');\r\n");

	}	//end if

	templateBuilder.Append("	}\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("var DataAnalysis= new TDataAnalysis();\r\n");
	templateBuilder.Append("DataAnalysis.ini();\r\n");
	templateBuilder.Append("function HidBox()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	DataAnalysis.HidUserBox();\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("function ReValue(valueArray)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	DataAnalysis.ReValue(valueArray);\r\n");
	templateBuilder.Append("}\r\n");

	if (Act=="A" || Act=="E" || Act=="F" || Act=="H1" | Act=="E1" || Act=="E2" || Act=="E3" || Act=="E4" || Act=="E5" || Act=="E6" || Act=="F1" || Act=="F2" || Act=="F3" || Act=="F4" || Act=="F5" || Act=="F6")
	{

	templateBuilder.Append("if(DataAnalysis.StoresName_Box)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	DataAnalysis.StoresName_Box.style.display = 'none';\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("if(DataAnalysis.StaffName_Box)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	DataAnalysis.StaffName_Box.style.display = 'none';\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("if(DataAnalysis.StaffNameB_Box)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	DataAnalysis.StaffNameB_Box.style.display = 'none';\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("if(DataAnalysis.pBrand_Box)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	DataAnalysis.pBrand_Box.style.display = 'none';\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("if(DataAnalysis.YHsysName_Box)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	DataAnalysis.YHsysName_Box.style.display = 'none';\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("if(DataAnalysis.ProductName_Box)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	DataAnalysis.ProductName_Box.style.display = 'none';\r\n");
	templateBuilder.Append("}\r\n");

	}	//end if


	if (Act=="A" || Act=="A1" || Act=="A2" || Act=="A3" || Act=="A4" || Act=="A5" || Act=="A6")
	{

	templateBuilder.Append("f_1();\r\n");

	}	//end if


	if (Act=="E" || Act=="E1" || Act=="E2" || Act=="E3" || Act=="E4" || Act=="E5" || Act=="E6")
	{

	templateBuilder.Append("f_2();\r\n");

	}	//end if


	if (Act=="F" || Act=="F1" || Act=="F2" || Act=="F3" || Act=="F4" || Act=="F5" || Act=="F6")
	{

	templateBuilder.Append("f_3();\r\n");

	}	//end if


	if (Act=="H" || Act=="H1" || Act=="H2" || Act=="H3" || Act=="H4" || Act=="H5" || Act=="H6" || Act=="H7")
	{

	templateBuilder.Append("f_6();\r\n");

	}	//end if

	templateBuilder.Append("</" + "script>\r\n");
	templateBuilder.Append("    </div>\r\n");

	}	//end if


	templateBuilder.Append("<div class=\"copyright\">\r\n");
	templateBuilder.Append("Powered by <a href=\"http://www.yannyo.com\">燕游商企通 v1.0</a> , 闽ICP备09018556号<br />\r\n");
	templateBuilder.Append("<p id=\"debuginfo\">\r\n");

	if (config.Debug!=0)
	{

	templateBuilder.Append("	Processed in " + this.Processtime.ToString().Trim() + " second(s)\r\n");

	if (isguestcachepage==1)
	{

	templateBuilder.Append("		(Cached).\r\n");

	}
	else if (querycount>1)
	{

	templateBuilder.Append("		 , " + querycount.ToString() + " queries.\r\n");

	}
	else
	{

	templateBuilder.Append("				, " + querycount.ToString() + " query.\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("</p>\r\n");
	templateBuilder.Append("</div>\r\n");



	templateBuilder.Append("</body>\r\n");
	templateBuilder.Append("</html>\r\n");



	if (1==2)
	{

	templateBuilder.Append("销售部分： \r\n");
	templateBuilder.Append("财务分析：\r\n");
	templateBuilder.Append("1，每月费用\r\n");
	templateBuilder.Append("2，每月收入\r\n");
	templateBuilder.Append("3，实时库存\r\n");
	templateBuilder.Append("    体现 总数（包括可销售，不可销售），箱数，金额（成本）\r\n");
	templateBuilder.Append("4，应收应付\r\n");
	templateBuilder.Append("    个人应收 应付，公司应收 应付\r\n");
	templateBuilder.Append("5，现金银行\r\n");
	templateBuilder.Append("    体现明细 总数\r\n");
	templateBuilder.Append("6，固定资产\r\n");
	templateBuilder.Append("    总数和明细\r\n");
	templateBuilder.Append("7，净资产\r\n");
	templateBuilder.Append("    净资产=现金银行+库存+固定资产+个人应收+公司应收-个人应付-公司应付\r\n");

	}	//end if


	Response.Write(templateBuilder.ToString());
}
</script>
