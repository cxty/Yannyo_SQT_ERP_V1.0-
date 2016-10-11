<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.report_sales" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/12/11 10:59:21. 
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

	templateBuilder.Append("<script src=\"public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script language=\"javascript\" src=\"public/js/jTable.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"public/js/report_sales.js \"></" + "script>\r\n");
	templateBuilder.Append("    <div class=\"main\" id=\"OrderList\">\r\n");

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

	templateBuilder.Append("<form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">   \r\n");
	templateBuilder.Append("<div class=\"toolbar\">\r\n");
	templateBuilder.Append("<div class=\"toolbox\">\r\n");
	templateBuilder.Append("<table border=\"0\" cellspacing=\"2\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"9\" align=\"left\" valign=\"top\">指定单据:(多个单据请用英文逗号“,”隔开)<br />\r\n");
	templateBuilder.Append("    <input name=\"OrderNumber\" id=\"OrderNumber\" type=\"text\" value=\"" + OrderNumber.ToString() + "\" style=\"width:90%\" /></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("      <td align=\"left\" valign=\"top\">\r\n");
	templateBuilder.Append("          统计方式:<br />\r\n");
	templateBuilder.Append("          <select id=\"ReDateType\" name=\"ReDateType\">\r\n");
	templateBuilder.Append("              <option value=\"1\"\r\n");

	if (ReDateType==1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">操作时间</option>\r\n");
	templateBuilder.Append("              <option value=\"2\"\r\n");

	if (ReDateType==2)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">单据时间</option>\r\n");
	templateBuilder.Append("          </select>\r\n");
	templateBuilder.Append("      </td>\r\n");
	templateBuilder.Append("  <td align=\"left\" valign=\"top\">&nbsp;\r\n");

	if (dType!=2)
	{

	templateBuilder.Append("<input class=\"B_Check\" type=\"radio\" name=\"t_dtype\" id=\"_dtype_a\" value=\"1\" \r\n");

	if (dType==0 || dType==1 || dType==6)
	{

	templateBuilder.Append(" checked=\"checked\"\r\n");

	}	//end if

	templateBuilder.Append(" />\r\n");

	}	//end if

	templateBuilder.Append("    <label for=\"_dtype_a\">时间段</label> \r\n");

	if (dType!=2)
	{

	templateBuilder.Append("<input class=\"B_Check\" type=\"radio\" name=\"t_dtype\" id=\"_dtype_b\" value=\"3\" \r\n");

	if (dType==3 || dType==4 || dType==7)
	{

	templateBuilder.Append(" checked=\"checked\"\r\n");

	}	//end if

	templateBuilder.Append(" /><label for=\"_dtype_b\">时间点</label>\r\n");

	}	//end if

	templateBuilder.Append("    <br />\r\n");
	 aspxrewriteurl = bDate.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("    <span id=\"_dtype_box\"><input name=\"bDate\" id=\"bDate\" style=\"width:100px;\" value=\"" + aspxrewriteurl.ToString() + "\" type=\"text\" onClick=\"new Calendar().show(this);\" readonly/>-</span>\r\n");
	 aspxrewriteurl = eDate.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("    <input name=\"eDate\" id=\"eDate\" style=\"width:100px;\" value=\"" + aspxrewriteurl.ToString() + "\" type=\"text\" onClick=\"new Calendar().show(this);\" readonly/>  </td>\r\n");
	templateBuilder.Append("    <!--\r\n");

	if (dType==0)
	{

	templateBuilder.Append("	<td align=\"left\" valign=\"top\">\r\n");
	templateBuilder.Append("	单据状态:<br/>\r\n");
	templateBuilder.Append("	<select name=\"oSteps\" id=\"oSteps\">\r\n");
	templateBuilder.Append("          <option value=\"-1\" \r\n");

	if (oSteps==-1)
	{

	templateBuilder.Append("         selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("         >所有</option>\r\n");

	if (OrderStpes!=null)
	{


	int ol__loop__id=0;
	foreach(DataRow ol in OrderStpes.Rows)
	{
		ol__loop__id++;

	templateBuilder.Append("            <option value=\"" + ol["id"].ToString().Trim() + "\"\r\n");

	if (oSteps.ToString()==ol["id"].ToString())
	{

	templateBuilder.Append("             selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("            >" + ol["Name"].ToString().Trim() + "</option>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("          </select>\r\n");
	templateBuilder.Append("	</td>\r\n");

	}	//end if

	templateBuilder.Append("	-->\r\n");

	if (ReType==8 || ReType==9)
	{

	templateBuilder.Append("	<td align=\"left\" valign=\"top\">统计类型:<br />\r\n");
	templateBuilder.Append("    <select id=\"ReType\" name=\"ReType\" >\r\n");
	templateBuilder.Append("	<option value=\"8\" \r\n");

	if (ReType==8)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">商品</option>\r\n");
	templateBuilder.Append("    <option value=\"9\" \r\n");

	if (ReType==9)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">客户</option>\r\n");
	templateBuilder.Append("    </select>\r\n");
	templateBuilder.Append("    </td>\r\n");

	}
	else
	{

	templateBuilder.Append("    <td align=\"left\" valign=\"top\">销售类型:<br />\r\n");
	templateBuilder.Append("    <select id=\"ReType\" name=\"ReType\" >\r\n");
	templateBuilder.Append("	<option value=\"1\" \r\n");

	if (ReType==1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">商品</option>\r\n");
	templateBuilder.Append("    <option value=\"2\" \r\n");

	if (ReType==2)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">客户</option>\r\n");
	templateBuilder.Append("	<option value=\"3\" \r\n");

	if (ReType==3)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">结算系统</option>\r\n");
	templateBuilder.Append("	<option value=\"4\" \r\n");

	if (ReType==4)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">业务员(按岗位变动)</option>\r\n");
	templateBuilder.Append("	<option value=\"7\" \r\n");

	if (ReType==7)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">业务员(按单据记录)</option>\r\n");
	templateBuilder.Append("	<option value=\"5\" \r\n");

	if (ReType==5)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">促销员</option>\r\n");
	templateBuilder.Append("	<option value=\"6\" \r\n");

	if (ReType==6)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">地区</option>\r\n");
	templateBuilder.Append("    </select>\r\n");
	templateBuilder.Append("    </td>\r\n");

	}	//end if

	templateBuilder.Append("    <td align=\"left\" valign=\"top\">输出类型:<br />\r\n");
	templateBuilder.Append("    <select id=\"DateType\" name=\"DateType\" >\r\n");
	templateBuilder.Append("    <option value=\"0\" \r\n");

	if (DateType==0)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">列表</option>\r\n");
	templateBuilder.Append("	<!--\r\n");
	templateBuilder.Append("	<option value=\"1\" \r\n");

	if (DateType==1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">日</option>\r\n");
	templateBuilder.Append("    <option value=\"2\" \r\n");

	if (DateType==2)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">月</option>\r\n");
	templateBuilder.Append("    <option value=\"3\" \r\n");

	if (DateType==3)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">年</option>\r\n");
	templateBuilder.Append("	-->\r\n");
	templateBuilder.Append("    </select></td>\r\n");
	templateBuilder.Append("    <td align=\"left\" valign=\"top\">联营:<br />\r\n");
	templateBuilder.Append("    <select id=\"NOJoinSales\" name=\"NOJoinSales\" >\r\n");
	templateBuilder.Append("    <option value=\"0\" \r\n");

	if (NOJoinSales==0)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">包含</option>\r\n");
	templateBuilder.Append("	<option value=\"1\" \r\n");

	if (NOJoinSales==1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">剔除</option>\r\n");
	templateBuilder.Append("	<option value=\"2\" \r\n");

	if (NOJoinSales==2)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">仅联营</option>\r\n");
	templateBuilder.Append("    </select>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td>客户:<br /><input name=\"StoresName\" id=\"StoresName\" type=\"text\" \r\n");
	templateBuilder.Append("value=\"" + StoresName.ToString() + "\"\r\n");
	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("<INPUT TYPE=\"hidden\" NAME=\"StoresID\" id=\"StoresID\" \r\n");
	templateBuilder.Append("value=\"" + StoresID.ToString() + "\"\r\n");
	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("<td>开单员:<br /><input name=\"SingleMemberName\" id=\"SingleMemberName\" type=\"text\" \r\n");
	templateBuilder.Append("value=\"" + SingleMemberName.ToString() + "\"\r\n");
	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("<INPUT TYPE=\"hidden\" NAME=\"SingleMemberID\" id=\"SingleMemberID\" \r\n");
	templateBuilder.Append("value=\"" + SingleMemberID.ToString() + "\"\r\n");
	templateBuilder.Append("/>\r\n");
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("<td>结算系统:<br/>\r\n");
	templateBuilder.Append(" <select id=\"PaymentSystemID\" name=\"PaymentSystemID\" >\r\n");
	templateBuilder.Append(" <option value=\"0\" \r\n");

	if (PaymentSystemID==0)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">全部</option>\r\n");

	if (sSysList!=null)
	{


	int sl__loop__id=0;
	foreach(DataRow sl in sSysList.Rows)
	{
		sl__loop__id++;

	templateBuilder.Append("	<option value=\"" + sl["PaymentSystemID"].ToString().Trim() + "\" \r\n");

	if (PaymentSystemID== int.Parse(sl["PaymentSystemID"].ToString()))
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">" + sl["pName"].ToString().Trim() + "</option>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append(" </select>\r\n");
	templateBuilder.Append("	<td>计算成本:<br/>\r\n");
	templateBuilder.Append("	<select id=\"CostPrice\" name=\"CostPrice\" >\r\n");
	templateBuilder.Append("	<option value='1' \r\n");

	if (CostPrice==1)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">不计算</option>\r\n");
	templateBuilder.Append("	<option value='0' \r\n");

	if (CostPrice==0)
	{

	templateBuilder.Append(" selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">计算</option>\r\n");
	templateBuilder.Append("	</select></td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"10\" align=\"left\" valign=\"top\">&nbsp;  <input type=\"button\"  id=\"bt_sub\" class=\"B_INPUT\" value=\" 确 定 \"/>&nbsp;  \r\n");
	templateBuilder.Append("    <input type=\"button\" id=\"export_data\" name=\"export_data\" style=\"margin:5px\" class=\"B_INPUT\" value=\"导出数据\" /></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<div class=\"list_title\">\r\n");

	if (ReType>0)
	{


	if (ReType==1 || ReType==8)
	{

	templateBuilder.Append("商品\r\n");

	}	//end if


	if (ReType==2 || ReType==9)
	{

	templateBuilder.Append("客户\r\n");

	}	//end if


	if (ReType==3)
	{

	templateBuilder.Append("结算系统\r\n");

	}	//end if


	if (ReType==4)
	{

	templateBuilder.Append("业务员(按岗位变动统计)\r\n");

	}	//end if


	if (ReType==5)
	{

	templateBuilder.Append("促销员\r\n");

	}	//end if


	if (ReType==6)
	{

	templateBuilder.Append("地区\r\n");

	}	//end if


	if (ReType==7)
	{

	templateBuilder.Append("业务员(按单据记录统计)\r\n");

	}	//end if


	if (dType==0)
	{

	templateBuilder.Append("销售(验收核销后)\r\n");

	}	//end if


	if (dType==3)
	{

	 aspxrewriteurl = eDate.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("销售(验收核销后) 截止 " + aspxrewriteurl.ToString() + "\r\n");

	}	//end if


	if (dType==1)
	{

	templateBuilder.Append("发出商品(发货后,验收核销前)\r\n");

	}	//end if


	if (dType==4)
	{

	 aspxrewriteurl = eDate.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("发出商品(发货后,验收核销前) " + aspxrewriteurl.ToString() + "\r\n");

	}	//end if


	if (dType==2)
	{

	templateBuilder.Append("备货(审核后,发货前)\r\n");

	}	//end if


	if (dType==6 || dType==7)
	{

	templateBuilder.Append("出货\r\n");

	}	//end if


	if (DateType==0)
	{

	templateBuilder.Append(" 列表\r\n");

	}	//end if

	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<div id=\"shiyan\"></div>\r\n");

	if (ReType==1 || ReType==8)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" class=\"tBox\" id=\"tBox\">\r\n");
	templateBuilder.Append("<thead>\r\n");
	templateBuilder.Append(" <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td width=\"3%\" rowspan=\"2\" align=\"center\">序号</td>\r\n");
	templateBuilder.Append("    <td width=\"7%\" rowspan=\"2\" align=\"center\">商品条码</td>\r\n");
	templateBuilder.Append("    <td width=\"19%\"  rowspan=\"2\" align=\"center\">商品名称</td>\r\n");
	templateBuilder.Append("    <td width=\"3%\" rowspan=\"2\" align=\"center\">装件数</td>\r\n");
	templateBuilder.Append("    <td width=\"12%\" align=\"center\" colspan=\"3\">销售出货(含销售赠品)</td>\r\n");
	templateBuilder.Append("    <td width=\"12%\" align=\"center\" colspan=\"3\">销售退货</td>\r\n");
	templateBuilder.Append("	<td width=\"12%\" align=\"center\" \r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\"\r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\"\r\n");

	}	//end if

	templateBuilder.Append(">销售赠品</td>\r\n");
	templateBuilder.Append("    <td width=\"12%\" align=\"center\" \r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\"\r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\"\r\n");

	}	//end if

	templateBuilder.Append(">赠品单</td>\r\n");
	templateBuilder.Append("    <td width=\"12%\" align=\"center\" \r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\"\r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\"\r\n");

	}	//end if

	templateBuilder.Append(">样品单</td>\r\n");
	templateBuilder.Append("    <td width=\"12%\" align=\"center\" \r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\"\r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\"\r\n");

	}	//end if

	templateBuilder.Append(">坏货单</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\" width=\"12%\" align=\"center\" valign=\"middle\">销售额</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td width=\"4%\" rowspan=\"2\" align=\"center\" valign=\"middle\">销售成本</td>\r\n");

	}	//end if

	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td align=\"center\">件数</td>\r\n");
	templateBuilder.Append("    <td align=\"center\">金额</td>\r\n");
	templateBuilder.Append("    <td align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td align=\"center\">件数</td>\r\n");
	templateBuilder.Append("    <td align=\"center\">金额</td>\r\n");
	templateBuilder.Append("	<td align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append("    <td align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append("    <td align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append("    <td align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append("    <td align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td align=\"center\">金额</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</thead>\r\n");
	templateBuilder.Append(" <tbody>\r\n");

	if (dList!=null)
	{


	if (DateType==0)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td width=\"3%\" align=\"center\">" + dl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("    <td width=\"7%\" align=\"left\">" + dl["pBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td width=\"19%\" align=\"left\">" + dl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td width=\"3%\" align=\"center\">" + dl["pToBoxNo"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyAAA = Convert.ToDecimal(MoneyAAA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("   " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyAA = Convert.ToDecimal(MoneyAA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"]),2).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyA = Convert.ToDecimal(MoneyA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_t"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("     " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyBBB = Convert.ToDecimal(MoneyBBB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_t"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyBB = Convert.ToDecimal(MoneyBB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney_t"]),2).ToString();
	
	templateBuilder.Append("     " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyB = Convert.ToDecimal(MoneyB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("	<td width=\"4%\" align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_sz"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("     " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyIII = Convert.ToDecimal(MoneyIII+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_sz"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyII = Convert.ToDecimal(MoneyII+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_sz"]),2).ToString();
	
	templateBuilder.Append("     " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyI = Convert.ToDecimal(MoneyI+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");

	}	//end if

	templateBuilder.Append("    <td width=\"4%\" align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_z"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("     " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyCCC = Convert.ToDecimal(MoneyCCC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_z"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyCC = Convert.ToDecimal(MoneyCC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_z"]),2).ToString();
	
	templateBuilder.Append("     " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyC = Convert.ToDecimal(MoneyC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");

	}	//end if

	templateBuilder.Append("    <td width=\"4%\" align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_y"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyDDD = Convert.ToDecimal(MoneyDDD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_y"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyDD = Convert.ToDecimal(MoneyDD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*(Convert.ToDecimal(dl["oQuantity_y"])),2).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyD = Convert.ToDecimal(MoneyD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");

	}	//end if

	templateBuilder.Append("	<td width=\"4%\" align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_h"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyHHH = Convert.ToDecimal(MoneyHHH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_h"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyHH = Convert.ToDecimal(MoneyHH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*(Convert.ToDecimal(dl["oQuantity_h"])),2).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyH = Convert.ToDecimal(MoneyH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");

	}	//end if

	templateBuilder.Append("<td width=\"4%\" align=\"right\" class=\"dboxleft\"><!---+Convert.ToDecimal(dl[\"oQuantity_sz\"])--->\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity"])-Convert.ToDecimal(dl["oQuantity_t"])+Convert.ToDecimal(dl["oQuantity_z"])+Convert.ToDecimal(dl["oQuantity_y"])+Convert.ToDecimal(dl["oQuantity_h"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyFF = Convert.ToDecimal(MoneyFF+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"right\" >\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"])-Convert.ToDecimal(dl["oMoney_t"]),2).ToString();
	
	templateBuilder.Append("    " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyF = Convert.ToDecimal(MoneyF+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"right\" >\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*(Convert.ToDecimal(dl["oQuantity"])-Convert.ToDecimal(dl["oQuantity_t"])+Convert.ToDecimal(dl["oQuantity_z"])+Convert.ToDecimal(dl["oQuantity_y"])+Convert.ToDecimal(dl["oQuantity_h"])),2).ToString();
	
	templateBuilder.Append("     " + aspxrewriteurl.ToString() + "\r\n");
	 MoneyG = Convert.ToDecimal(MoneyG+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("    </td>\r\n");

	}	//end if

	templateBuilder.Append("  </tr>\r\n");

	}	//end loop


	}	//end if


	}	//end if

	templateBuilder.Append("</tbody>\r\n");
	templateBuilder.Append("<tfoot>\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td align=\"center\">合计:</td>\r\n");
	templateBuilder.Append("    <td colspan=\"3\" align=\"center\">&nbsp;</td>\r\n");
	templateBuilder.Append("    <td align=\"right\" class=\"dboxleft\"><span>" + MoneyAAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\" class=\"dboxleft\"><span>" + MoneyBBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("	<td align=\"right\" class=\"dboxleft\"><span>" + MoneyIII.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyII.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyI.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("    <td align=\"right\" class=\"dboxleft\"><span>" + MoneyCCC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyCC.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyC.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("    <td align=\"right\" class=\"dboxleft\"><span>" + MoneyDDD.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyDD.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyD.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("    <td align=\"right\" class=\"dboxleft\"><span>" + MoneyHHH.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyHH.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyH.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("    <td  align=\"right\" class=\"dboxleft\"><span>" + MoneyFF.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td  align=\"right\" ><span>" + MoneyF.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\" class=\"dboxleft\"><span>" + MoneyG.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</tfoot>\r\n");
	templateBuilder.Append("</table>\r\n");



	}	//end if


	if (ReType==2 || ReType==9)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"1\" class=\"tBox\" id=\"tBox\">\r\n");
	templateBuilder.Append("<thead>\r\n");
	templateBuilder.Append(" <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td width=\"3%\" rowspan=\"2\" align=\"center\">序号</td>\r\n");
	templateBuilder.Append("    <td  rowspan=\"2\" \r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("width=\"13%\"\r\n");

	}
	else
	{

	templateBuilder.Append("width=\"25%\"\r\n");

	}	//end if

	templateBuilder.Append(" align=\"center\">客户</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\" width=\"20%\" align=\"center\" >商品</td>\r\n");
	templateBuilder.Append("    <td align=\"center\" \r\n");
	templateBuilder.Append("   colspan=\"3\" \r\n");
	templateBuilder.Append("    >销售出货(含销售赠品)</td>\r\n");
	templateBuilder.Append("    <td align=\"center\" \r\n");
	templateBuilder.Append("    colspan=\"3\" \r\n");
	templateBuilder.Append("    >销售退货</td>\r\n");
	templateBuilder.Append("	<td align=\"center\"\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\" \r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\" \r\n");

	}	//end if

	templateBuilder.Append("     >销售赠品</td>\r\n");
	templateBuilder.Append("    <td align=\"center\"\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\" \r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\" \r\n");

	}	//end if

	templateBuilder.Append("     >赠品单</td>\r\n");
	templateBuilder.Append("    <td align=\"center\"\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\" \r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\" \r\n");

	}	//end if

	templateBuilder.Append("     >样品单</td>\r\n");
	templateBuilder.Append("    <td width=\"5%\" rowspan=\"2\" align=\"center\">销售额</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td width=\"5%\" rowspan=\"2\" align=\"center\">销售成本</td>\r\n");

	}	//end if

	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append(" <tr class=\"tBar\">\r\n");
	templateBuilder.Append("   <td align=\"center\" >条码</td>\r\n");
	templateBuilder.Append("   <td  align=\"center\" >名称</td>\r\n");
	templateBuilder.Append("   <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");
	templateBuilder.Append("   <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append("   <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append(" </tr>\r\n");
	templateBuilder.Append("</thead>\r\n");
	templateBuilder.Append(" <tbody>\r\n");

	if (cList!=null)
	{


	if (DateType==0)
	{

	 tLoopid_a = 0;
	

	int cl__loop__id=0;
	foreach(DataRow cl in cList.Rows)
	{
		cl__loop__id++;

	 bMoneyA = 0;
	
	 bMoneyAA = 0;
	
	 bMoneyAAA = 0;
	
	 bMoneyB = 0;
	
	 bMoneyBB = 0;
	
	 bMoneyBBB = 0;
	
	 bMoneyC = 0;
	
	 bMoneyCC = 0;
	
	 bMoneyCCC = 0;
	
	 bMoneyD = 0;
	
	 bMoneyDD = 0;
	
	 bMoneyDDD = 0;
	
	 bMoneyH = 0;
	
	 bMoneyHH = 0;
	
	 bMoneyHHH = 0;
	
	 bMoneyE = 0;
	
	 bMoneyF = 0;
	
	 bMoneyG = 0;
	
	 tLoopid = 1;
	

	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	 tLoopid_a = tLoopid_a+1;
	
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                <td  align=\"center\" valign=\"top\" \r\n");

	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("rowspan=\"" + cl["pCount"].ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">" + tLoopid_a.ToString() + "</td>\r\n");
	templateBuilder.Append("                <td  align=\"left\" valign=\"top\" \r\n");

	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("rowspan=\"" + cl["pCount"].ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">" + cl["sName"].ToString().Trim() + "</td>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;


	if ( Convert.ToInt32(dl["StoresID"].ToString()) == Convert.ToInt32(cl["StoresID"].ToString()))
	{


	if ((tLoopid%2) == 0)
	{

	templateBuilder.Append("<tr>\r\n");

	}	//end if

	templateBuilder.Append("                          <td  align=\"left\">" + dl["pBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                          <td  align=\"left\">" + dl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                          <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyAAA = Convert.ToDecimal(bMoneyAAA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                          <td  align=\"right\">\r\n");

	if (Convert.ToDecimal(dl["oQuantity"])!=0 && Convert.ToDecimal(dl["pToBoxNo"])!=0)
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                    " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	 aspxrewriteurl = "0";
	

	}	//end if

	 bMoneyAA = Convert.ToDecimal(bMoneyAA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                          <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"]),2).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyA = Convert.ToDecimal(bMoneyA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                          <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_t"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyBBB = Convert.ToDecimal(bMoneyBBB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                          <td  align=\"right\">\r\n");

	if (Convert.ToDecimal(dl["oQuantity_t"])!=0 && Convert.ToDecimal(dl["pToBoxNo"])!=0)
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_t"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	 aspxrewriteurl = "0";
	

	}	//end if

	 bMoneyBB = Convert.ToDecimal(bMoneyBB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                          <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney_t"]),2).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyB = Convert.ToDecimal(bMoneyB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                          <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_sz"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyHHH = Convert.ToDecimal(bMoneyHHH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                          <td align=\"right\">\r\n");

	if (Convert.ToDecimal(dl["oQuantity_sz"])!=0 && Convert.ToDecimal(dl["pToBoxNo"])!=0)
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_sz"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	 aspxrewriteurl = "0";
	

	}	//end if

	 bMoneyHH = Convert.ToDecimal(bMoneyHH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                          <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_sz"]),2).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyH = Convert.ToDecimal(bMoneyH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");

	}	//end if

	templateBuilder.Append("                          <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_z"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyCCC = Convert.ToDecimal(bMoneyCCC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                          <td align=\"right\">\r\n");

	if (Convert.ToDecimal(dl["oQuantity_z"])!=0 && Convert.ToDecimal(dl["pToBoxNo"])!=0)
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_z"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	 aspxrewriteurl = "0";
	

	}	//end if

	 bMoneyCC = Convert.ToDecimal(bMoneyCC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                          <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_z"]),2).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyC = Convert.ToDecimal(bMoneyC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");

	}	//end if

	templateBuilder.Append("                          <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_y"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyDDD = Convert.ToDecimal(bMoneyDDD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");
	templateBuilder.Append("                          <td  align=\"right\">\r\n");

	if (Convert.ToDecimal(dl["oQuantity_y"])!=0 && Convert.ToDecimal(dl["pToBoxNo"])!=0)
	{

	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_y"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	 aspxrewriteurl = "0";
	

	}	//end if

	 bMoneyDD = Convert.ToDecimal(bMoneyDD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                          <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_y"]),2).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyD = Convert.ToDecimal(bMoneyD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");

	}	//end if

	templateBuilder.Append("                          <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"])-Convert.ToDecimal(dl["oMoney_t"]),2).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyF = Convert.ToDecimal(bMoneyF+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                          <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*(Convert.ToDecimal(dl["oQuantity"])-Convert.ToDecimal(dl["oQuantity_t"])+Convert.ToDecimal(dl["oQuantity_z"])+Convert.ToDecimal(dl["oQuantity_y"])),2).ToString();
	
	templateBuilder.Append("                                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyG = Convert.ToDecimal(bMoneyG+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                          </td>\r\n");

	}	//end if


	if ((tLoopid%2) == 0)
	{

	templateBuilder.Append("</tr>\r\n");

	}	//end if

	 tLoopid = tLoopid+1;
	

	}	//end if


	}	//end loop


	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("<tr>\r\n");

	}	//end if

	templateBuilder.Append("                        <td colspan=\"2\" align=\"center\" class=\"tBar\">小计:</td>\r\n");
	templateBuilder.Append("                        <td align=\"right\" class=\"tBar dboxleft\">\r\n");
	templateBuilder.Append("                        <span>" + bMoneyAAA.ToString() + "</span>\r\n");
	 MoneyAAA = MoneyAAA+bMoneyAAA;
	
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyAA.ToString() + "</span>\r\n");
	 MoneyAA = MoneyAA+bMoneyAA;
	
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("                        <span>" + bMoneyA.ToString() + "</span>\r\n");
	 MoneyA = MoneyA+bMoneyA;
	
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar dboxleft\">\r\n");
	templateBuilder.Append("                        <span>" + bMoneyBBB.ToString() + "</span>\r\n");
	 MoneyBBB = MoneyBBB+bMoneyBBB;
	
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyBB.ToString() + "</span>\r\n");
	 MoneyBB = MoneyBB+bMoneyBB;
	
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyB.ToString() + "</span>\r\n");
	 MoneyB = MoneyB+bMoneyB;
	
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyHHH.ToString() + "</span>\r\n");
	 MoneyHHH = MoneyHHH+bMoneyHHH;
	
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyHH.ToString() + "</span>\r\n");
	 MoneyHH = MoneyHH+bMoneyHH;
	
	templateBuilder.Append("                        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyH.ToString() + "</span>\r\n");
	 MoneyH = MoneyH+bMoneyH;
	
	templateBuilder.Append("                        </td>\r\n");

	}	//end if

	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyCCC.ToString() + "</span>\r\n");
	 MoneyCCC = MoneyCCC+bMoneyCCC;
	
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyCC.ToString() + "</span>\r\n");
	 MoneyCC = MoneyCC+bMoneyCC;
	
	templateBuilder.Append("                        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyC.ToString() + "</span>\r\n");
	 MoneyC = MoneyC+bMoneyC;
	
	templateBuilder.Append("                        </td>\r\n");

	}	//end if

	templateBuilder.Append("                        <td align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyDDD.ToString() + "</span>\r\n");
	 MoneyDDD = MoneyDDD+bMoneyDDD;
	
	templateBuilder.Append("                        </td>\r\n");
	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyDD.ToString() + "</span>\r\n");
	 MoneyDD = MoneyDD+bMoneyDD;
	
	templateBuilder.Append("                        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyD.ToString() + "</span>\r\n");
	 MoneyD = MoneyD+bMoneyD;
	
	templateBuilder.Append("                        </td>\r\n");

	}	//end if

	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyF.ToString() + "</span>\r\n");
	 MoneyF = MoneyF+bMoneyF;
	
	templateBuilder.Append("                        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                        <td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyG.ToString() + "</span>\r\n");
	 MoneyG = MoneyG+bMoneyG;
	
	templateBuilder.Append("                        </td>\r\n");

	}	//end if


	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("</tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("                </tr>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if

	templateBuilder.Append("</tbody>\r\n");
	templateBuilder.Append("<tfoot>\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td colspan=\"4\" align=\"center\">合计:</td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyAAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyBBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("	<td align=\"right\"><span>" + MoneyHHH.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyHH.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyH.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("	<td align=\"right\"><span>" + MoneyCCC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyCC.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyC.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("	<td align=\"right\"><span>" + MoneyDDD.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyDD.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyD.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyF.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyG.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</tfoot>\r\n");
	templateBuilder.Append("</table>\r\n");



	}	//end if


	if (ReType==3)
	{


	templateBuilder.Append("<table width=\"100%\"  border=\"0\" cellpadding=\"1\" cellspacing=\"1\" class=\"tBox\" id=\"tBox\">\r\n");
	templateBuilder.Append("<thead>\r\n");
	templateBuilder.Append(" <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td width=\"3%\" rowspan=\"2\" align=\"center\">序号</td>\r\n");
	templateBuilder.Append("    <td \r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("width=\"13%\"\r\n");

	}
	else
	{

	templateBuilder.Append("width=\"25%\"\r\n");

	}	//end if

	templateBuilder.Append(" rowspan=\"2\"  align=\"center\">结算系统</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\" width=\"20%\"  align=\"center\" >商品</td>\r\n");
	templateBuilder.Append("    <td align=\"center\" \r\n");
	templateBuilder.Append("   colspan=\"3\"\r\n");
	templateBuilder.Append("    >销售</td>\r\n");
	templateBuilder.Append("    <td align=\"center\" \r\n");
	templateBuilder.Append("    colspan=\"3\" \r\n");
	templateBuilder.Append("    >退货</td>\r\n");
	templateBuilder.Append("    <td align=\"center\"\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\" \r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\"\r\n");

	}	//end if

	templateBuilder.Append("     >赠品</td>\r\n");
	templateBuilder.Append("    <td align=\"center\"\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\" \r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\" \r\n");

	}	//end if

	templateBuilder.Append("     >样品</td>\r\n");
	templateBuilder.Append("    <td width=\"5%\" rowspan=\"2\" align=\"center\">销售额</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td width=\"5%\" rowspan=\"2\" align=\"center\">销售成本</td>\r\n");

	}	//end if

	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append(" <tr class=\"tBar\">\r\n");
	templateBuilder.Append("   <td align=\"center\" >条码</td>\r\n");
	templateBuilder.Append("   <td align=\"center\" >名称</td>\r\n");
	templateBuilder.Append("   <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");
	templateBuilder.Append("   <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");
	templateBuilder.Append("   <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append(" </tr>\r\n");
	templateBuilder.Append("</thead>\r\n");
	templateBuilder.Append(" <tbody>\r\n");

	if (cList!=null)
	{


	if (DateType==0)
	{


	int cl__loop__id=0;
	foreach(DataRow cl in cList.Rows)
	{
		cl__loop__id++;

	 bMoneyA = 0;
	
	 bMoneyAA = 0;
	
	 bMoneyAAA = 0;
	
	 bMoneyB = 0;
	
	 bMoneyBB = 0;
	
	 bMoneyBBB = 0;
	
	 bMoneyC = 0;
	
	 bMoneyCC = 0;
	
	 bMoneyCCC = 0;
	
	 bMoneyD = 0;
	
	 bMoneyDD = 0;
	
	 bMoneyDDD = 0;
	
	 bMoneyE = 0;
	
	 bMoneyF = 0;
	
	 bMoneyG = 0;
	
	 tLoopid = 1;
	

	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td  align=\"center\" valign=\"top\" \r\n");

	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("rowspan=\"" + cl["pCount"].ToString().Trim() + "\" \r\n");

	}	//end if

	templateBuilder.Append(">" + cl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("    <td   align=\"left\" valign=\"top\" \r\n");

	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("rowspan=\"" + cl["pCount"].ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">" + cl["pName"].ToString().Trim() + "\r\n");
	templateBuilder.Append("    </td>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;


	if (dl["PaymentSystemID"].ToString() == cl["PaymentSystemID"].ToString())
	{


	if ((tLoopid%2) == 0)
	{

	templateBuilder.Append("    			<tr>\r\n");

	}	//end if

	templateBuilder.Append("              <td  align=\"left\">\r\n");
	templateBuilder.Append("        		" + dl["pBarcode"].ToString().Trim() + "\r\n");
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"left\">" + dl["ProductName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("              <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyAAA = Convert.ToDecimal(bMoneyAAA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyAA = Convert.ToDecimal(bMoneyAA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"]),2).ToString();
	
	templateBuilder.Append("              " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyA = Convert.ToDecimal(bMoneyA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_t"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("              " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyBBB = Convert.ToDecimal(bMoneyBBB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_t"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyBB = Convert.ToDecimal(bMoneyBB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney_t"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyB = Convert.ToDecimal(bMoneyB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_z"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyCCC = Convert.ToDecimal(bMoneyCCC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_z"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyCC = Convert.ToDecimal(bMoneyCC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_z"]),2).ToString();
	
	templateBuilder.Append("     			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyC = Convert.ToDecimal(bMoneyC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	}	//end if

	templateBuilder.Append("              <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_y"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyDDD = Convert.ToDecimal(bMoneyDDD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_y"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyDD = Convert.ToDecimal(bMoneyDD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_y"]),2).ToString();
	
	templateBuilder.Append("     			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyD = Convert.ToDecimal(bMoneyD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	}	//end if

	templateBuilder.Append("              <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"])-Convert.ToDecimal(dl["oMoney_t"]),2).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyF = Convert.ToDecimal(bMoneyF+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*(Convert.ToDecimal(dl["oQuantity"])-Convert.ToDecimal(dl["oQuantity_t"])+Convert.ToDecimal(dl["oQuantity_z"])+Convert.ToDecimal(dl["oQuantity_y"])),2).ToString();
	
	templateBuilder.Append("     			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyG = Convert.ToDecimal(bMoneyG+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	}	//end if


	if ((tLoopid%2) == 0)
	{

	templateBuilder.Append("   				</tr>\r\n");

	}	//end if

	 tLoopid = tLoopid+1;
	

	}	//end if


	}	//end loop


	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("<tr >\r\n");

	}	//end if

	templateBuilder.Append("      <td colspan=\"2\"  align=\"center\" class=\"tBar\">小计:</td>\r\n");
	templateBuilder.Append("      <td  align=\"right\" class=\"tBar dboxleft\" >\r\n");
	templateBuilder.Append("      <span>" + bMoneyAAA.ToString() + "</span>\r\n");
	 MoneyAAA = MoneyAAA+bMoneyAAA;
	
	templateBuilder.Append("      </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyAA.ToString() + "</span>\r\n");
	 MoneyAA = MoneyAA+bMoneyAA;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyA.ToString() + "</span>\r\n");
	 MoneyA = MoneyA+bMoneyA;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar dboxleft\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyBBB.ToString() + "</span>\r\n");
	 MoneyBBB = MoneyBBB+bMoneyBBB;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyBB.ToString() + "</span>\r\n");
	 MoneyBB = MoneyBB+bMoneyBB;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyB.ToString() + "</span>\r\n");
	 MoneyB = MoneyB+bMoneyB;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyCCC.ToString() + "</span>\r\n");
	 MoneyCCC = MoneyCCC+bMoneyCCC;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyCC.ToString() + "</span>\r\n");
	 MoneyCC = MoneyCC+bMoneyCC;
	
	templateBuilder.Append("        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td  align=\"right\" class=\"tBar\"><span>" + bMoneyC.ToString() + "</span>\r\n");
	 MoneyC = MoneyC+bMoneyC;
	
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        <td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyDDD.ToString() + "</span>\r\n");
	 MoneyDDD = MoneyDDD+bMoneyDDD;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyDD.ToString() + "</span>\r\n");
	 MoneyDD = MoneyDD+bMoneyDD;
	
	templateBuilder.Append("        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td  align=\"right\" class=\"tBar\"><span>" + bMoneyD.ToString() + "</span>\r\n");
	 MoneyD = MoneyD+bMoneyD;
	
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        <td   align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyF.ToString() + "</span>\r\n");
	 MoneyF = MoneyF+bMoneyF;
	
	templateBuilder.Append("        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyG.ToString() + "</span>\r\n");
	 MoneyG = MoneyG+bMoneyG;
	
	templateBuilder.Append("        </td>\r\n");

	}	//end if


	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("</tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("	</tr>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if

	templateBuilder.Append("</tbody>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<tfoot>\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td  colspan=\"4\" align=\"center\">合计:</td>\r\n");
	templateBuilder.Append("    <td  align=\"right\"><span>" + MoneyAAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td  align=\"right\"><span>" + MoneyAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td  align=\"right\"><span>" + MoneyA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td   align=\"right\"><span>" + MoneyBBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td   align=\"right\"><span>" + MoneyBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td   align=\"right\"><span>" + MoneyB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("	<td   align=\"right\"><span>" + MoneyCCC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td   align=\"right\"><span>" + MoneyCC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td   align=\"right\"><span>" + MoneyC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("	<td   align=\"right\"><span>" + MoneyDDD.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td   align=\"right\"><span>" + MoneyDD.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td   align=\"right\"><span>" + MoneyD.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td   align=\"right\"><span>" + MoneyF.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td  align=\"right\"><span>" + MoneyG.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</tfoot>\r\n");

	}	//end if

	templateBuilder.Append("</table>\r\n");



	}	//end if


	if (ReType==4 || ReType==5 || ReType==7)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"1\" class=\"tBox\" id=\"tBox\">\r\n");
	templateBuilder.Append("<thead>\r\n");
	templateBuilder.Append(" <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td width=\"3%\" rowspan=\"2\" align=\"center\">序号</td>\r\n");
	templateBuilder.Append("    <td  rowspan=\"2\" \r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("width=\"13%\"\r\n");

	}
	else
	{

	templateBuilder.Append("width=\"25%\"\r\n");

	}	//end if

	templateBuilder.Append(" align=\"center\">姓名</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\" width=\"20%\" align=\"center\" >商品</td>\r\n");
	templateBuilder.Append("    <td align=\"center\" \r\n");
	templateBuilder.Append("   colspan=\"3\" \r\n");
	templateBuilder.Append("    >销售出货(含销售赠品)</td>\r\n");
	templateBuilder.Append("    <td align=\"center\" \r\n");
	templateBuilder.Append("    colspan=\"3\" \r\n");
	templateBuilder.Append("    >销售退货</td>\r\n");
	templateBuilder.Append("	<td align=\"center\"\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\" \r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\" \r\n");

	}	//end if

	templateBuilder.Append("     >销售赠品</td>\r\n");
	templateBuilder.Append("    <td align=\"center\"\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\" \r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\" \r\n");

	}	//end if

	templateBuilder.Append("     >赠品单</td>\r\n");
	templateBuilder.Append("    <td align=\"center\"\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\" \r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\" \r\n");

	}	//end if

	templateBuilder.Append("     >样品单</td>\r\n");
	templateBuilder.Append("    <td width=\"5%\" rowspan=\"2\" align=\"center\">销售额</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td width=\"5%\" rowspan=\"2\" align=\"center\">销售成本</td>\r\n");

	}	//end if

	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append(" <tr class=\"tBar\">\r\n");
	templateBuilder.Append("   <td align=\"center\" >条码</td>\r\n");
	templateBuilder.Append("   <td  align=\"center\" >名称</td>\r\n");
	templateBuilder.Append("   <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");
	templateBuilder.Append("   <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append("   <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append(" </tr>\r\n");
	templateBuilder.Append("</thead>\r\n");
	templateBuilder.Append(" <tbody>\r\n");

	if (cList!=null)
	{


	if (DateType==0)
	{

	 tLoopid_a = 0;
	

	int cl__loop__id=0;
	foreach(DataRow cl in cList.Rows)
	{
		cl__loop__id++;

	 bMoneyA = 0;
	
	 bMoneyAA = 0;
	
	 bMoneyAAA = 0;
	
	 bMoneyB = 0;
	
	 bMoneyBB = 0;
	
	 bMoneyBBB = 0;
	
	 bMoneyC = 0;
	
	 bMoneyCC = 0;
	
	 bMoneyCCC = 0;
	
	 bMoneyD = 0;
	
	 bMoneyDD = 0;
	
	 bMoneyDDD = 0;
	
	 bMoneyH = 0;
	
	 bMoneyHH = 0;
	
	 bMoneyHHH = 0;
	
	 bMoneyE = 0;
	
	 bMoneyF = 0;
	
	 bMoneyG = 0;
	
	 tLoopid = 1;
	

	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	 tLoopid_a = tLoopid_a+1;
	
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td  align=\"center\" valign=\"top\" \r\n");

	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("rowspan=\"" + cl["pCount"].ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">" + tLoopid_a.ToString() + "</td>\r\n");
	templateBuilder.Append("    <td  align=\"left\" valign=\"top\" \r\n");

	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("rowspan=\"" + cl["pCount"].ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">" + cl["sName"].ToString().Trim() + "\r\n");
	templateBuilder.Append("    </td>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;


	if ( Convert.ToInt32(dl["StaffID"].ToString()) == Convert.ToInt32(cl["StaffID"].ToString()))
	{


	if ((tLoopid%2) == 0)
	{

	templateBuilder.Append("                    <tr>\r\n");

	}	//end if

	templateBuilder.Append("              <td  align=\"left\">\r\n");
	templateBuilder.Append("        		" + dl["pBarcode"].ToString().Trim() + "\r\n");
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"left\">" + dl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("              <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyAAA = Convert.ToDecimal(bMoneyAAA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyAA = Convert.ToDecimal(bMoneyAA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"]),2).ToString();
	
	templateBuilder.Append("              " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyA = Convert.ToDecimal(bMoneyA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_t"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("              " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyBBB = Convert.ToDecimal(bMoneyBBB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_t"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyBB = Convert.ToDecimal(bMoneyBB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney_t"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyB = Convert.ToDecimal(bMoneyB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("			  <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_sz"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyHHH = Convert.ToDecimal(bMoneyHHH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_sz"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyHH = Convert.ToDecimal(bMoneyHH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_sz"]),2).ToString();
	
	templateBuilder.Append("     			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyH = Convert.ToDecimal(bMoneyH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	}	//end if

	templateBuilder.Append("              <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_z"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyCCC = Convert.ToDecimal(bMoneyCCC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_z"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyCC = Convert.ToDecimal(bMoneyCC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_z"]),2).ToString();
	
	templateBuilder.Append("     			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyC = Convert.ToDecimal(bMoneyC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	}	//end if

	templateBuilder.Append("              <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_y"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyDDD = Convert.ToDecimal(bMoneyDDD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");
	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_y"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyDD = Convert.ToDecimal(bMoneyDD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_y"]),2).ToString();
	
	templateBuilder.Append("     			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyD = Convert.ToDecimal(bMoneyD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	}	//end if

	templateBuilder.Append("              <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"])-Convert.ToDecimal(dl["oMoney_t"]),2).ToString();
	
	templateBuilder.Append("    			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyF = Convert.ToDecimal(bMoneyF+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("              <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*(Convert.ToDecimal(dl["oQuantity"])-Convert.ToDecimal(dl["oQuantity_t"])+Convert.ToDecimal(dl["oQuantity_z"])+Convert.ToDecimal(dl["oQuantity_y"])),2).ToString();
	
	templateBuilder.Append("     			" + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyG = Convert.ToDecimal(bMoneyG+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("              </td>\r\n");

	}	//end if


	if ((tLoopid%2) == 0)
	{

	templateBuilder.Append("</tr>\r\n");

	}	//end if

	 tLoopid = tLoopid+1;
	

	}	//end if


	}	//end loop


	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("      <tr>\r\n");

	}	//end if

	templateBuilder.Append("      <td colspan=\"2\" align=\"center\" class=\"tBar\">小计:</td>\r\n");
	templateBuilder.Append("      <td align=\"right\" class=\"tBar dboxleft\">\r\n");
	templateBuilder.Append("      <span>" + bMoneyAAA.ToString() + "</span>\r\n");
	 MoneyAAA = MoneyAAA+bMoneyAAA;
	
	templateBuilder.Append("      </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyAA.ToString() + "</span>\r\n");
	 MoneyAA = MoneyAA+bMoneyAA;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyA.ToString() + "</span>\r\n");
	 MoneyA = MoneyA+bMoneyA;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar dboxleft\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyBBB.ToString() + "</span>\r\n");
	 MoneyBBB = MoneyBBB+bMoneyBBB;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyBB.ToString() + "</span>\r\n");
	 MoneyBB = MoneyBB+bMoneyBB;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyB.ToString() + "</span>\r\n");
	 MoneyB = MoneyB+bMoneyB;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("		<td  align=\"right\" class=\"tBar dboxleft\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyHHH.ToString() + "</span>\r\n");
	 MoneyHHH = MoneyHHH+bMoneyHHH;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyHH.ToString() + "</span>\r\n");
	 MoneyHH = MoneyHH+bMoneyHH;
	
	templateBuilder.Append("        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyH.ToString() + "</span>\r\n");
	 MoneyH = MoneyH+bMoneyH;
	
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        <td  align=\"right\" class=\"tBar dboxleft\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyCCC.ToString() + "</span>\r\n");
	 MoneyCCC = MoneyCCC+bMoneyCCC;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyCC.ToString() + "</span>\r\n");
	 MoneyCC = MoneyCC+bMoneyCC;
	
	templateBuilder.Append("        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyC.ToString() + "</span>\r\n");
	 MoneyC = MoneyC+bMoneyC;
	
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        <td align=\"right\" class=\"tBar dboxleft\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyDDD.ToString() + "</span>\r\n");
	 MoneyDDD = MoneyDDD+bMoneyDDD;
	
	templateBuilder.Append("        </td>\r\n");
	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyDD.ToString() + "</span>\r\n");
	 MoneyDD = MoneyDD+bMoneyDD;
	
	templateBuilder.Append("        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("        <span>" + bMoneyD.ToString() + "</span>\r\n");
	 MoneyD = MoneyD+bMoneyD;
	
	templateBuilder.Append("        </td>\r\n");

	}	//end if

	templateBuilder.Append("        <td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyF.ToString() + "</span>\r\n");
	 MoneyF = MoneyF+bMoneyF;
	
	templateBuilder.Append("        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("        <td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyG.ToString() + "</span>\r\n");
	 MoneyG = MoneyG+bMoneyG;
	
	templateBuilder.Append("        </td>\r\n");

	}	//end if


	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("</tr>\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("	</tr>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if

	templateBuilder.Append("</tbody>\r\n");
	templateBuilder.Append("<tfoot>\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td colspan=\"4\" align=\"center\">合计:</td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyAAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyBBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("	<td align=\"right\"><span>" + MoneyHHH.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyHH.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyH.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("	<td align=\"right\"><span>" + MoneyCCC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyCC.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyC.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("	<td align=\"right\"><span>" + MoneyDDD.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyDD.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyD.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyF.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyG.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</tfoot>\r\n");
	templateBuilder.Append("</table>\r\n");



	}	//end if


	if (ReType==6)
	{


	templateBuilder.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"1\" class=\"tBox\" id=\"tBox\">\r\n");
	templateBuilder.Append("<thead>\r\n");
	templateBuilder.Append(" <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td width=\"3%\" rowspan=\"2\" align=\"center\">序号</td>\r\n");
	templateBuilder.Append("    <td width=\"5%\" rowspan=\"2\" align=\"center\">地区</td>\r\n");
	templateBuilder.Append("    <td rowspan=\"2\" \r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("width=\"13%\"\r\n");

	}
	else
	{

	templateBuilder.Append("width=\"25%\"\r\n");

	}	//end if

	templateBuilder.Append(" align=\"center\">客户</td>\r\n");
	templateBuilder.Append("    <td colspan=\"2\" width=\"20%\" align=\"center\" >商品</td>\r\n");
	templateBuilder.Append("    <td align=\"center\" \r\n");
	templateBuilder.Append("   colspan=\"3\" \r\n");
	templateBuilder.Append("    >销售出货(含销售赠品)</td>\r\n");
	templateBuilder.Append("    <td align=\"center\" \r\n");
	templateBuilder.Append("    colspan=\"3\" \r\n");
	templateBuilder.Append("    >销售退货</td>\r\n");
	templateBuilder.Append("	<td align=\"center\"\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\" \r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\" \r\n");

	}	//end if

	templateBuilder.Append("     >销售赠品</td>\r\n");
	templateBuilder.Append("    <td align=\"center\"\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\" \r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\" \r\n");

	}	//end if

	templateBuilder.Append("     >赠品单</td>\r\n");
	templateBuilder.Append("    <td align=\"center\"\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("colspan=\"3\" \r\n");

	}
	else
	{

	templateBuilder.Append("colspan=\"2\" \r\n");

	}	//end if

	templateBuilder.Append("     >样品单</td>\r\n");
	templateBuilder.Append("    <td width=\"5%\" rowspan=\"2\" align=\"center\">销售额</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td width=\"5%\" rowspan=\"2\" align=\"center\">销售成本</td>\r\n");

	}	//end if

	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append(" <tr class=\"tBar\">\r\n");
	templateBuilder.Append("   <td align=\"center\" >条码</td>\r\n");
	templateBuilder.Append("   <td  align=\"center\" >名称</td>\r\n");
	templateBuilder.Append("   <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");
	templateBuilder.Append("   <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append("   <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">数量</td>\r\n");
	templateBuilder.Append("    <td width=\"4%\" align=\"center\">件数</td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td width=\"4%\" align=\"center\">金额</td>\r\n");

	}	//end if

	templateBuilder.Append(" </tr>\r\n");
	templateBuilder.Append("</thead>\r\n");
	templateBuilder.Append(" <tbody>\r\n");

	if (cList!=null && rList!=null)
	{


	if (DateType==0)
	{

	 tLoopid_a = 0;
	

	int rl__loop__id=0;
	foreach(DataRow rl in rList.Rows)
	{
		rl__loop__id++;

	 cMoneyA = 0;
	
	 cMoneyAA = 0;
	
	 cMoneyAAA = 0;
	
	 cMoneyB = 0;
	
	 cMoneyBB = 0;
	
	 cMoneyBBB = 0;
	
	 cMoneyC = 0;
	
	 cMoneyCC = 0;
	
	 cMoneyCCC = 0;
	
	 cMoneyD = 0;
	
	 cMoneyDD = 0;
	
	 cMoneyDDD = 0;
	
	 cMoneyH = 0;
	
	 cMoneyHH = 0;
	
	 cMoneyHHH = 0;
	
	 cMoneyE = 0;
	
	 cMoneyF = 0;
	
	 cMoneyG = 0;
	
	 tLoopid_b = 1;
	

	if (Convert.ToInt32(rl["pCount"].ToString())>0)
	{

	 tLoopid_a = tLoopid_a+1;
	
	templateBuilder.Append("                <tr>\r\n");
	templateBuilder.Append("                    <td  align=\"center\" valign=\"top\" \r\n");

	if (Convert.ToInt32(rl["pCount"].ToString())>0)
	{

	templateBuilder.Append("rowspan=\"" + rl["pCount"].ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">" + tLoopid_a.ToString() + "</td>\r\n");
	templateBuilder.Append("                    <td  align=\"left\" valign=\"top\" \r\n");

	if (Convert.ToInt32(rl["pCount"].ToString())>0)
	{

	templateBuilder.Append("rowspan=\"" + rl["pCount"].ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">" + rl["rName"].ToString().Trim() + "</td>\r\n");

	if ((tLoopid_b%2) == 0)
	{

	templateBuilder.Append("<tr>\r\n");

	}	//end if


	int cl__loop__id=0;
	foreach(DataRow cl in cList.Rows)
	{
		cl__loop__id++;

	 bMoneyA = 0;
	
	 bMoneyAA = 0;
	
	 bMoneyAAA = 0;
	
	 bMoneyB = 0;
	
	 bMoneyBB = 0;
	
	 bMoneyBBB = 0;
	
	 bMoneyC = 0;
	
	 bMoneyCC = 0;
	
	 bMoneyCCC = 0;
	
	 bMoneyD = 0;
	
	 bMoneyDD = 0;
	
	 bMoneyDDD = 0;
	
	 bMoneyH = 0;
	
	 bMoneyHH = 0;
	
	 bMoneyHHH = 0;
	
	 bMoneyE = 0;
	
	 bMoneyF = 0;
	
	 bMoneyG = 0;
	
	 tLoopid = 1;
	

	if (rl["RegionID"].ToString() == cl["RegionID"].ToString() && Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("                                <td align=\"left\" valign=\"top\" \r\n");

	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("rowspan=\"" + cl["pCount"].ToString().Trim() + "\"\r\n");

	}	//end if

	templateBuilder.Append(">" + cl["sName"].ToString().Trim() + "</td>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;


	if ( Convert.ToInt32(dl["StoresID"].ToString()) == Convert.ToInt32(cl["StoresID"].ToString()))
	{


	if ((tLoopid%2) == 0)
	{

	templateBuilder.Append("<tr>\r\n");

	}	//end if

	templateBuilder.Append("                                      <td  align=\"left\">" + dl["pBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                                      <td  align=\"left\">" + dl["pName"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("                                      <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyAAA = Convert.ToDecimal(bMoneyAAA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");
	templateBuilder.Append("                                      <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyAA = Convert.ToDecimal(bMoneyAA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");
	templateBuilder.Append("                                      <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"]),2).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyA = Convert.ToDecimal(bMoneyA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");
	templateBuilder.Append("                                      <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_t"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyBBB = Convert.ToDecimal(bMoneyBBB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");
	templateBuilder.Append("                                      <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_t"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyBB = Convert.ToDecimal(bMoneyBB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");
	templateBuilder.Append("                                      <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney_t"]),2).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyB = Convert.ToDecimal(bMoneyB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");
	templateBuilder.Append("                                      <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_sz"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyHHH = Convert.ToDecimal(bMoneyHHH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");
	templateBuilder.Append("                                      <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_sz"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyHH = Convert.ToDecimal(bMoneyHH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                                      <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_sz"]),2).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyH = Convert.ToDecimal(bMoneyH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");

	}	//end if

	templateBuilder.Append("                                      <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_z"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyCCC = Convert.ToDecimal(bMoneyCCC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");
	templateBuilder.Append("                                      <td align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_z"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyCC = Convert.ToDecimal(bMoneyCC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                                      <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_z"]),2).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyC = Convert.ToDecimal(bMoneyC+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");

	}	//end if

	templateBuilder.Append("                                      <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_y"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyDDD = Convert.ToDecimal(bMoneyDDD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");
	templateBuilder.Append("                                      <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oQuantity_y"])/Convert.ToDecimal(dl["pToBoxNo"]),config.QuantityDecimal).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyDD = Convert.ToDecimal(bMoneyDD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                                      <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*Convert.ToDecimal(dl["oQuantity_y"]),2).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyD = Convert.ToDecimal(bMoneyD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");

	}	//end if

	templateBuilder.Append("                                      <td  align=\"right\" class=\"dboxleft\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"])-Convert.ToDecimal(dl["oMoney_t"]),2).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyF = Convert.ToDecimal(bMoneyF+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                                      <td  align=\"right\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["CostPrice"])*(Convert.ToDecimal(dl["oQuantity"])-Convert.ToDecimal(dl["oQuantity_t"])+Convert.ToDecimal(dl["oQuantity_z"])+Convert.ToDecimal(dl["oQuantity_y"])),2).ToString();
	
	templateBuilder.Append("                                            " + aspxrewriteurl.ToString() + "\r\n");
	 bMoneyG = Convert.ToDecimal(bMoneyG+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("                                      </td>\r\n");

	}	//end if


	if ((tLoopid%2) == 0)
	{

	templateBuilder.Append("</tr>\r\n");

	}	//end if

	 tLoopid = tLoopid+1;
	

	}	//end if


	}	//end loop


	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("<tr>\r\n");

	}	//end if

	templateBuilder.Append("                                        <td colspan=\"2\" align=\"center\" class=\"tBar\">客户小计:</td>\r\n");
	templateBuilder.Append("                                        <td align=\"right\" class=\"tBar dboxleft\">\r\n");
	templateBuilder.Append("                                        <span>" + bMoneyAAA.ToString() + "</span>\r\n");
	 MoneyAAA = MoneyAAA+bMoneyAAA;
	
	 cMoneyAAA = cMoneyAAA+bMoneyAAA;
	
	templateBuilder.Append("                                        </td>\r\n");
	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyAA.ToString() + "</span>\r\n");
	 MoneyAA = MoneyAA+bMoneyAA;
	
	 cMoneyAA = cMoneyAA+bMoneyAA;
	
	templateBuilder.Append("                                        </td>\r\n");
	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar\">\r\n");
	templateBuilder.Append("                                        <span>" + bMoneyA.ToString() + "</span>\r\n");
	 MoneyA = MoneyA+bMoneyA;
	
	 cMoneyA = cMoneyA+bMoneyA;
	
	templateBuilder.Append("                                        </td>\r\n");
	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar dboxleft\">\r\n");
	templateBuilder.Append("                                        <span>" + bMoneyBBB.ToString() + "</span>\r\n");
	 MoneyBBB = MoneyBBB+bMoneyBBB;
	
	 cMoneyBBB = cMoneyBBB+bMoneyBBB;
	
	templateBuilder.Append("                                        </td>\r\n");
	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyBB.ToString() + "</span>\r\n");
	 MoneyBB = MoneyBB+bMoneyBB;
	
	 cMoneyBB = cMoneyBB+bMoneyBB;
	
	templateBuilder.Append("                                        </td>\r\n");
	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyB.ToString() + "</span>\r\n");
	 MoneyB = MoneyB+bMoneyB;
	
	 cMoneyB = cMoneyB+bMoneyB;
	
	templateBuilder.Append("                                        </td>\r\n");
	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyHHH.ToString() + "</span>\r\n");
	 MoneyHHH = MoneyHHH+bMoneyHHH;
	
	 cMoneyHHH = cMoneyHHH+bMoneyHHH;
	
	templateBuilder.Append("                                        </td>\r\n");
	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyHH.ToString() + "</span>\r\n");
	 MoneyHH = MoneyHH+bMoneyHH;
	
	 cMoneyHH = cMoneyHH+bMoneyHH;
	
	templateBuilder.Append("                                        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyH.ToString() + "</span>\r\n");
	 MoneyH = MoneyH+bMoneyH;
	
	 cMoneyH = cMoneyH+bMoneyH;
	
	templateBuilder.Append("                                        </td>\r\n");

	}	//end if

	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyCCC.ToString() + "</span>\r\n");
	 MoneyCCC = MoneyCCC+bMoneyCCC;
	
	 cMoneyCCC = cMoneyCCC+bMoneyCCC;
	
	templateBuilder.Append("                                        </td>\r\n");
	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyCC.ToString() + "</span>\r\n");
	 MoneyCC = MoneyCC+bMoneyCC;
	
	 cMoneyCC = cMoneyCC+bMoneyCC;
	
	templateBuilder.Append("                                        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyC.ToString() + "</span>\r\n");
	 MoneyC = MoneyC+bMoneyC;
	
	 cMoneyC = cMoneyC+bMoneyC;
	
	templateBuilder.Append("                                        </td>\r\n");

	}	//end if

	templateBuilder.Append("                                        <td align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyDDD.ToString() + "</span>\r\n");
	 MoneyDDD = MoneyDDD+bMoneyDDD;
	
	 cMoneyDDD = cMoneyDDD+bMoneyDDD;
	
	templateBuilder.Append("                                        </td>\r\n");
	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyDD.ToString() + "</span>\r\n");
	 MoneyDD = MoneyDD+bMoneyDD;
	
	 cMoneyDD = cMoneyDD+bMoneyDD;
	
	templateBuilder.Append("                                        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar\"><span>" + bMoneyD.ToString() + "</span>\r\n");
	 MoneyD = MoneyD+bMoneyD;
	
	 cMoneyD = cMoneyD+bMoneyD;
	
	templateBuilder.Append("                                        </td>\r\n");

	}	//end if

	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyF.ToString() + "</span>\r\n");
	 MoneyF = MoneyF+bMoneyF;
	
	 cMoneyF = cMoneyF+bMoneyF;
	
	templateBuilder.Append("                                        </td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                                        <td  align=\"right\" class=\"tBar dboxleft\"><span>" + bMoneyG.ToString() + "</span>\r\n");
	 MoneyG = MoneyG+bMoneyG;
	
	 cMoneyG = cMoneyG+bMoneyG;
	
	templateBuilder.Append("                                        </td>\r\n");

	}	//end if


	if (Convert.ToInt32(cl["pCount"].ToString())>0)
	{

	templateBuilder.Append("</tr>\r\n");

	}	//end if


	}	//end if


	if ((tLoopid_b%2) == 0)
	{

	templateBuilder.Append("</tr>\r\n");

	}	//end if

	 tLoopid_b = tLoopid_b+1;
	

	}	//end if


	}	//end loop

	templateBuilder.Append("<!--cl-->\r\n");

	if (Convert.ToInt32(rl["pCount"].ToString())>0)
	{

	templateBuilder.Append("<tr>\r\n");

	}	//end if

	templateBuilder.Append("                    <td colspan=\"3\" align=\"center\" class=\"tBar\">地区小计:</td>\r\n");
	templateBuilder.Append("                    <td align=\"right\" class=\"tBar dboxleft\"><span>" + cMoneyAAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar\"><span>" + cMoneyAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar\"><span>" + cMoneyA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar dboxleft\"><span>" + cMoneyBBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar\"><span>" + cMoneyBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar\"><span>" + cMoneyB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar dboxleft\"><span>" + cMoneyHHH.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar\"><span>" + cMoneyHH.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar\"><span>" + cMoneyH.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar dboxleft\"><span>" + cMoneyCCC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar\"><span>" + cMoneyCC.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar\"><span>" + cMoneyC.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("                    <td align=\"right\" class=\"tBar dboxleft\"><span>" + cMoneyDDD.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar\"><span>" + cMoneyDD.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar\"><span>" + cMoneyD.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar dboxleft\"><span>" + cMoneyF.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("                    <td  align=\"right\" class=\"tBar dboxleft\"><span>" + cMoneyG.ToString() + "</span></td>\r\n");

	}	//end if


	if (Convert.ToInt32(rl["pCount"].ToString())>0)
	{

	templateBuilder.Append("</tr>\r\n");

	}	//end if

	templateBuilder.Append("                    </tr>\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("<!--rl-->\r\n");

	}	//end if


	}	//end if

	templateBuilder.Append("</tbody>\r\n");
	templateBuilder.Append("<tfoot>\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("    <td colspan=\"5\" align=\"center\">合计:</td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyAAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyBBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("	<td align=\"right\"><span>" + MoneyHHH.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyHH.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyH.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("	<td align=\"right\"><span>" + MoneyCCC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyCC.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyC.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("	<td align=\"right\"><span>" + MoneyDDD.ToString() + "</span></td>\r\n");
	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyDD.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("<td align=\"right\"><span>" + MoneyD.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyF.ToString() + "</span></td>\r\n");

	if (ShowPrice==true)
	{

	templateBuilder.Append("    <td align=\"right\"><span>" + MoneyG.ToString() + "</span></td>\r\n");

	}	//end if

	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</tfoot>\r\n");
	templateBuilder.Append("</table>\r\n");



	}	//end if


	}	//end if

	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("addTableListener(document.getElementById(\"tBoxs\"),0,0);\r\n");
	templateBuilder.Append("var tf = new TableFixed(\"tBox\");\r\n");
	templateBuilder.Append("tf.Clone();//表格结构修改后应重新Clone一次\r\n");
	templateBuilder.Append("var Report_Sales = new TReport_Sales();\r\n");
	templateBuilder.Append("Report_Sales.dType = " + dType.ToString() + ";\r\n");
	templateBuilder.Append("Report_Sales.ini();\r\n");
	templateBuilder.Append("$().ready(function(){\r\n");
	templateBuilder.Append("	$('#StoresName').autocomplete('Services/CAjax.aspx',{\r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetStoresInfoList',\r\n");
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
	templateBuilder.Append("					result:tArray[i].value,\r\n");
	templateBuilder.Append("					sCode:tArray[i].info,\r\n");
	templateBuilder.Append("					CustomersClassID:tArray[i].CustomersClassID,\r\n");
	templateBuilder.Append("					CustomersClassName:tArray[i].CustomersClassName,\r\n");
	templateBuilder.Append("					PriceClassID:tArray[i].PriceClassID,\r\n");
	templateBuilder.Append("					PriceClassName:tArray[i].PriceClassName,\r\n");
	templateBuilder.Append("					sType:tArray[i].sType,\r\n");
	templateBuilder.Append("					sIsFZYH:tArray[i].sIsFZYH,\r\n");
	templateBuilder.Append("					YHsysName:tArray[i].YHsysName,\r\n");
	templateBuilder.Append("					sContact:tArray[i].sContact,\r\n");
	templateBuilder.Append("					sTel:tArray[i].sTel,\r\n");
	templateBuilder.Append("					sAddress:tArray[i].sAddress,\r\n");
	templateBuilder.Append("					StaffID:tArray[i].StaffID,\r\n");
	templateBuilder.Append("					StaffName:tArray[i].StaffName\r\n");
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
	templateBuilder.Append("	  }).result(function(event, data, formatted, row) {\r\n");
	templateBuilder.Append("			$(\"#StoresID\").val((formatted!=null)?formatted:\"0\");\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("	$('#SingleMemberName').autocomplete('Services/CAjax.aspx',{ \r\n");
	templateBuilder.Append("		width: 200,\r\n");
	templateBuilder.Append("		scroll: true,\r\n");
	templateBuilder.Append("		autoFill: true,\r\n");
	templateBuilder.Append("		scrollHeight: 200,\r\n");
	templateBuilder.Append("		matchContains: true,\r\n");
	templateBuilder.Append("		dataType: 'json',\r\n");
	templateBuilder.Append("		extraParams:{\r\n");
	templateBuilder.Append("			'do':'GetUserList',\r\n");
	templateBuilder.Append("			'RCode':Math.random(),\r\n");
	templateBuilder.Append("			'UserName':function(){return $('#SingleMemberName').val();}\r\n");
	templateBuilder.Append("		},\r\n");
	templateBuilder.Append("		parse: function(data) {\r\n");
	templateBuilder.Append("				var rows = [];  \r\n");
	templateBuilder.Append("				var tArray = data.results;\r\n");
	templateBuilder.Append("				 for(var i=0; i<tArray.length; i++){  \r\n");
	templateBuilder.Append("				  rows[rows.length] = {    \r\n");
	templateBuilder.Append("					data:tArray[i].value,    \r\n");
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
	templateBuilder.Append("			$(\"#SingleMemberID\").val((formatted!=null)?formatted:\"0\");\r\n");
	templateBuilder.Append("		}\r\n");
	templateBuilder.Append("	  );\r\n");
	templateBuilder.Append("});\r\n");
	templateBuilder.Append("</" + "script>\r\n");
	templateBuilder.Append("</form>\r\n");

	}	//end if


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



	Response.Write(templateBuilder.ToString());
}
</script>
