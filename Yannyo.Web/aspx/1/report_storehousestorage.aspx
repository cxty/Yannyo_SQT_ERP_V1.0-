<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.report_storehousestorage" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:40. 
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

	templateBuilder.Append("<script src=\"/public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<script src=\"/public/js/jquery.js\" type=\"text/javascript\" language=\"javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<script src=\"/public/js/SerchWebSite.js\" type=\"text/javascript\" language=\"javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/jquery.autocomplete.css\"></link>\r\n");
	templateBuilder.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"/public/js/popup.tree.css\"></link>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/Cxty_XTool.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.autocomplete.js \"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.mcdropdown.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jquery.bgiframe.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/reportselect.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/reportselect_do.js\"></" + "script>\r\n");
	templateBuilder.Append("<script type=\"text/javascript\" src=\"/public/js/jTable.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"/public/js/myFrontPageJs/storage.js\" type=\"text/javascript\" language=\"javascript\"></" + "script>\r\n");

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

	templateBuilder.Append("<div class=\"main\" id=\"OrderList\">\r\n");
	templateBuilder.Append("<form action=\"\" method=\"post\" name=\"bForm\" id=\"bForm\">   \r\n");
	templateBuilder.Append("<div class=\"toolbar\" style=\"background-color:#cccccc\">\r\n");
	templateBuilder.Append("<input type=\"hidden\" id=\"reTypeValue\" name=\"reTypeValue\" />\r\n");
	templateBuilder.Append("<input type=\"hidden\" id=\"_associated\" name=\"_associated\" />\r\n");
	templateBuilder.Append("<table border=\"0\" cellspacing=\"2\" cellpadding=\"0\" style=\"font-size:10pt;width:100%\">\r\n");
	templateBuilder.Append("  <tr>\r\n");

	if (bType==1)
	{

	templateBuilder.Append("  <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("  <td style=\"width:60%\">年份选择:\r\n");

	if (yList !=null)
	{

	templateBuilder.Append("    <select name=\"s_year\" style=\"width:10%\">\r\n");

	int yl__loop__id=0;
	foreach(DataRow yl in yList.Rows)
	{
		yl__loop__id++;

	templateBuilder.Append("     <option>" + yl["sDateTime_year"].ToString().Trim() + "</option>\r\n");

	}	//end loop

	templateBuilder.Append("    </select>\r\n");

	}	//end if

	templateBuilder.Append("  </td>\r\n");
	templateBuilder.Append("  </div>\r\n");

	}	//end if


	if (bType==0)
	{

	templateBuilder.Append("  <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("   <td align=\"center\" style=\"width:10%;\">区域名称\r\n");

	if (List !=null)
	{

	templateBuilder.Append("   <select  style=\"width:80%\" id=\"rName\" name=\"rName\"  onchange=\"javascript:changeOptions();\">\r\n");
	templateBuilder.Append("   <option>选择全部</option>\r\n");

	int ddl__loop__id=0;
	foreach(DataRow ddl in List.Rows)
	{
		ddl__loop__id++;

	templateBuilder.Append("    <option>" + ddl["rName"].ToString().Trim() + "</option>\r\n");

	}	//end loop

	templateBuilder.Append("   </select>\r\n");

	}	//end if

	templateBuilder.Append("   </td>\r\n");
	templateBuilder.Append("   <td align=\"center\" style=\"width:15%;\">业务员\r\n");
	templateBuilder.Append("    <select style=\"width:80%\" id=\"staffName\" name=\"staffName\" onchange=\"javascript:changeOptionsStorage()\">\r\n");
	templateBuilder.Append("       <option>选择全部</option>\r\n");
	templateBuilder.Append("     </select>\r\n");
	templateBuilder.Append("   </td>\r\n");
	templateBuilder.Append("   <td align=\"center\" style=\"width:15%;\">门店名称\r\n");
	templateBuilder.Append("   <select style=\"width:100%;\" id=\"storageName\" name=\"storageName\" >\r\n");
	templateBuilder.Append("       <option>选择全部</option>\r\n");
	templateBuilder.Append("   </select>\r\n");
	templateBuilder.Append("   </td>\r\n");
	templateBuilder.Append("   <td align=\"center\" colspan=\"3\" style=\"width:30%;\">日期选择<br />\r\n");
	 aspxrewriteurl = sDate.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("    <input name=\"sDate\" id=\"sDate\" type=\"text\" value=\"" + aspxrewriteurl.ToString() + "\" style=\"width:175px\" onclick=\"new Calendar().show(this);\"  />至\r\n");
	 aspxrewriteurl = stDate.ToString("yyyy-MM-dd");
	
	templateBuilder.Append("    <input name=\"stDate\" id=\"stDate\" type=\"text\" value=\"" + aspxrewriteurl.ToString() + "\" style=\"width:175px\" onclick=\"new Calendar().show(this);\"/>\r\n");
	templateBuilder.Append("   </td>\r\n");
	templateBuilder.Append("   <td align=\"center\" style=\"width:7%;\">查看类型\r\n");
	templateBuilder.Append("   <select id=\"reType\" name=\"reType\" style=\"width:80%\">\r\n");
	templateBuilder.Append("        <option value=\"-1\"\r\n");

	if (reType==-1)
	{

	templateBuilder.Append("selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">全部</option>\r\n");
	templateBuilder.Append("        <option value=\"0\" \r\n");

	if (reType==0)
	{

	templateBuilder.Append("selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">进货</option>\r\n");
	templateBuilder.Append("        <option value=\"1\" \r\n");

	if (reType==1)
	{

	templateBuilder.Append("selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">销售</option>\r\n");
	templateBuilder.Append("        <option value=\"2\" \r\n");

	if (reType==2)
	{

	templateBuilder.Append("selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">库存</option>\r\n");
	templateBuilder.Append("    </select>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td align=\"center\">联营\r\n");
	templateBuilder.Append("    <select id=\"associated\" name=\"associated\" style=\"width:100%\">\r\n");
	templateBuilder.Append("        <option value=\"-1\"\r\n");

	if (_associated==-1)
	{

	templateBuilder.Append("selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">包含</option>\r\n");
	templateBuilder.Append("        <option value=\"0\" \r\n");

	if (_associated==0)
	{

	templateBuilder.Append("selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">剔除</option>\r\n");
	templateBuilder.Append("        <option value=\"1\" \r\n");

	if (_associated==1)
	{

	templateBuilder.Append("selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append(">仅联营</option>\r\n");
	templateBuilder.Append("    </select>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("   </div>\r\n");

	}	//end if

	templateBuilder.Append("   <td \r\n");

	if (bType==0)
	{

	templateBuilder.Append("align=\"center\" style=\"width:7%\"\r\n");

	}
	else
	{

	templateBuilder.Append("align=\"right\" style=\"width:15%\"\r\n");

	}	//end if

	templateBuilder.Append(">\r\n");

	if (bType==0)
	{

	templateBuilder.Append("查询\r\n");

	}
	else
	{


	}	//end if

	templateBuilder.Append("    <input type=\"button\"  id=\"btn_submit\" class=\"B_INPUT\" value=\" 确 定 \"/>\r\n");
	templateBuilder.Append("   </td>\r\n");
	templateBuilder.Append("   <td align=\"center\" style=\"width:7%\">\r\n");

	if (bType==0)
	{

	templateBuilder.Append("导出数据\r\n");
	templateBuilder.Append("   <input type=\"button\" id=\"export\" name=\"export\"   class=\"B_INPUT\" value=\"导出数据\" />\r\n");

	}	//end if

	templateBuilder.Append("   </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("</div>\r\n");

	if (bType==1)
	{

	templateBuilder.Append("  <div id=\"space\"></div>\r\n");
	templateBuilder.Append("  <table width=\"100%\" id=\"get_data\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("   <td rowspan=\"2\" align=\"center\" style=\"width:3%\" >序号</td>\r\n");
	templateBuilder.Append("   <td rowspan=\"2\" align=\"center\" style=\"width:5%\">业务员</td>\r\n");
	templateBuilder.Append("   <td rowspan=\"2\" align=\"center\" colspan=\"2\" style=\"width:20%\">客户名称</td>\r\n");
	templateBuilder.Append("   <td colspan=\"2\" align=\"center\" style=\"width:6%\">1月</td>\r\n");
	templateBuilder.Append("   <td colspan=\"2\" align=\"center\" style=\"width:6%\">2月</td>\r\n");
	templateBuilder.Append("   <td colspan=\"2\" align=\"center\" style=\"width:6%\">3月</td>\r\n");
	templateBuilder.Append("   <td colspan=\"2\" align=\"center\" style=\"width:6%\">4月</td>\r\n");
	templateBuilder.Append("   <td colspan=\"2\" align=\"center\" style=\"width:6%\">5月</td>\r\n");
	templateBuilder.Append("   <td colspan=\"2\" align=\"center\" style=\"width:6%\">6月</td>\r\n");
	templateBuilder.Append("   <td colspan=\"2\" align=\"center\" style=\"width:6%\">7月</td>\r\n");
	templateBuilder.Append("   <td colspan=\"2\" align=\"center\" style=\"width:6%\">8月</td>\r\n");
	templateBuilder.Append("   <td colspan=\"2\" align=\"center\" style=\"width:6%\">9月</td>\r\n");
	templateBuilder.Append("   <td colspan=\"2\" align=\"center\" style=\"width:6%\">10月</td>\r\n");
	templateBuilder.Append("   <td colspan=\"2\" align=\"center\" style=\"width:6%\">11月</td>\r\n");
	templateBuilder.Append("   <td colspan=\"2\" align=\"center\" style=\"width:6%\">12月</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr class=\"tBar\">\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">数量</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">金额</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">数量</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">金额</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">数量</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">金额</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">数量</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">金额</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">数量</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">金额</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">数量</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">金额</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">数量</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">金额</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">数量</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">金额</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">数量</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">金额</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">数量</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">金额</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">数量</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">金额</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">数量</td>\r\n");
	templateBuilder.Append("   <td style=\"width:3%\">金额</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  </table>\r\n");
	templateBuilder.Append("  <table width=\"100%\" id=\"tBoxs\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");

	if (ispost)
	{


	if (sList !=null)
	{


	int sl__loop__id=0;
	foreach(DataRow sl in sList.Rows)
	{
		sl__loop__id++;

	 SumE = 0;
	
	 SumEA = 0;
	
	 SumEB = 0;
	
	 SumEC = 0;
	
	 SumED = 0;
	
	 SumEE = 0;
	
	 SumEF = 0;
	
	 SumEG = 0;
	
	 SumEH = 0;
	
	 SumEI = 0;
	
	 SumEJ = 0;
	
	 SumEK = 0;
	
	 SumF = 0;
	
	 SumFA = 0;
	
	 SumFB = 0;
	
	 SumFC = 0;
	
	 SumFD = 0;
	
	 SumFE = 0;
	
	 SumFF = 0;
	
	 SumFG = 0;
	
	 SumFH = 0;
	
	 SumFI = 0;
	
	 SumFJ = 0;
	
	 SumFK = 0;
	
	 hList = stName(sl["sName"].ToString().Trim());
	
	 rList = rowList(sl["sName"].ToString().Trim());
	
	 fList = getStorage_Num(sDate.ToString("yyyy"),sl["sName"].ToString());
	
	 tLoopid = 1;
	
	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("           <td rowspan=\"" + rList.ToString() + "\" style=\"width:3%\">" + sl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("           <td rowspan=\"" + rList.ToString() + "\" style=\"width:5%;\">" + sl["sName"].ToString().Trim() + "</td>\r\n");

	if (hList==null)
	{

	templateBuilder.Append("           <td colspan=\"31\" align=\"center\">无信息</td>\r\n");

	}	//end if


	if (hList !=null)
	{


	int hl__loop__id=0;
	foreach(DataRow hl in hList.Rows)
	{
		hl__loop__id++;


	if ((tLoopid%2) == 0)
	{

	templateBuilder.Append("                 <tr>\r\n");

	}	//end if

	templateBuilder.Append("           <td style=\"width:3%\">" + hl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("           <td colspan=\"6\" style=\"width:17%\">" + hl["sName"].ToString().Trim() + "</td>\r\n");
	 pList = getProductsDetails(sDate.ToString("yyyy"),hl["sName"].ToString());
	

	if (ispost && bType.ToString()=="1")
	{

	 pList = getProductsDetails(s_year,hl["sName"].ToString());
	

	if (pList !=null)
	{


	int pl__loop__id=0;
	foreach(DataRow pl in pList.Rows)
	{
		pl__loop__id++;

	templateBuilder.Append("             <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("             <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum1"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumE = decimal.Round(SumE+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice1"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumF = decimal.Round(SumF+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td> \r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum2"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEA = decimal.Round(SumEA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice2"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFA = decimal.Round(SumFA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum3"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEB = decimal.Round(SumEB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice3"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFB = decimal.Round(SumFB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum4"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEC = decimal.Round(SumEC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice4"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFC = decimal.Round(SumFC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum5"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumED = decimal.Round(SumED+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice5"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFD = decimal.Round(SumFD+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum6"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEE = decimal.Round(SumEE+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice6"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFE = decimal.Round(SumFE+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum7"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEF = decimal.Round(SumEF+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice7"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFF = decimal.Round(SumFF+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum8"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEG = decimal.Round(SumEG+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice8"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFG = decimal.Round(SumFG+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum9"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEH = decimal.Round(SumEH+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice9"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFH = decimal.Round(SumFH+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum10"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEI = decimal.Round(SumEI+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice10"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFI = decimal.Round(SumFI+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum11"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEJ = decimal.Round(SumEJ+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice11"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFJ = decimal.Round(SumFJ+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum12"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEK = decimal.Round(SumEK+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice12"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFK = decimal.Round(SumFK+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td> \r\n");
	templateBuilder.Append("             </div>\r\n");

	}	//end loop


	}
	else
	{

	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");

	}	//end if


	}
	else
	{


	if (pList !=null)
	{


	int pl__loop__id=0;
	foreach(DataRow pl in pList.Rows)
	{
		pl__loop__id++;

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum1"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumE = decimal.Round(SumE+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice1"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumF = decimal.Round(SumF+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td> \r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum2"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEA = decimal.Round(SumEA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice2"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFA = decimal.Round(SumFA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum3"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEB = decimal.Round(SumEB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice3"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFB = decimal.Round(SumFB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum4"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEC = decimal.Round(SumEC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice4"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFC = decimal.Round(SumFC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum5"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumED = decimal.Round(SumED+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice5"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFD = decimal.Round(SumFD+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum6"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEE = decimal.Round(SumEE+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice6"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFE = decimal.Round(SumFE+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum7"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEF = decimal.Round(SumEF+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice7"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFF = decimal.Round(SumFF+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum8"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEG = decimal.Round(SumEG+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice8"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFG = decimal.Round(SumFG+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum9"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEH = decimal.Round(SumEH+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice9"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFH = decimal.Round(SumFH+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum10"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEI = decimal.Round(SumEI+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice10"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFI = decimal.Round(SumFI+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum11"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEJ = decimal.Round(SumEJ+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice11"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFJ = decimal.Round(SumFJ+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sNum12"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumEK = decimal.Round(SumEK+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" style=\"width:3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(pl["sPrice12"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumFK = decimal.Round(SumFK+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end loop


	}
	else
	{

	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");
	templateBuilder.Append("           <td align=\"right\" style=\"width:3%\">0.00</td>\r\n");

	}	//end if


	}	//end if


	if ((tLoopid%2) == 0)
	{

	templateBuilder.Append("   			</tr>\r\n");

	}	//end if

	 tLoopid = tLoopid+1;
	
	templateBuilder.Append("        </tr>\r\n");

	}	//end loop

	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("         <td colspan=\"3\" rowspan=\"3\" align=\"center\">" + sl["sName"].ToString().Trim() + "小计</td>\r\n");
	templateBuilder.Append("         <td colspan=\"6\" align=\"center\"><b>零售额增幅</b></td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>" + SumE.ToString() + "</span></td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>" + SumF.ToString() + "</span></td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumEA) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEA)-Convert.ToDecimal(SumE))/Convert.ToDecimal(SumEA),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumEA.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span></td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumFA) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFA)-Convert.ToDecimal(SumF))/Convert.ToDecimal(SumFA),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumFA.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span></td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumEB) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEB)-Convert.ToDecimal(SumEA))/Convert.ToDecimal(SumEB),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumEB.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumFB) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFB)-Convert.ToDecimal(SumFA))/Convert.ToDecimal(SumFB),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumFB.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumEC) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEC)-Convert.ToDecimal(SumEB))/Convert.ToDecimal(SumEC),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumEC.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumFC) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFC)-Convert.ToDecimal(SumFB))/Convert.ToDecimal(SumFC),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumFC.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumED) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumED)-Convert.ToDecimal(SumEC))/Convert.ToDecimal(SumED),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumED.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumFD) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFD)-Convert.ToDecimal(SumFC))/Convert.ToDecimal(SumFD),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumFD.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumEE) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEE)-Convert.ToDecimal(SumED))/Convert.ToDecimal(SumEE),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumEE.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumFE) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFE)-Convert.ToDecimal(SumFD))/Convert.ToDecimal(SumFE),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumFE.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumEF) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEF)-Convert.ToDecimal(SumEE))/Convert.ToDecimal(SumEF),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumEF.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumFF) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFF)-Convert.ToDecimal(SumFE))/Convert.ToDecimal(SumFF),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumFF.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumEG) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEG)-Convert.ToDecimal(SumEF))/Convert.ToDecimal(SumEG),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumEG.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumFG) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFG)-Convert.ToDecimal(SumFF))/Convert.ToDecimal(SumFG),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumFG.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumEH) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEH)-Convert.ToDecimal(SumEG))/Convert.ToDecimal(SumEH),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumEH.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumFH) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFH)-Convert.ToDecimal(SumFG))/Convert.ToDecimal(SumFH),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumFH.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("          </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumEI) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEI)-Convert.ToDecimal(SumEH))/Convert.ToDecimal(SumEI),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumEI.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumFI) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFI)-Convert.ToDecimal(SumFH))/Convert.ToDecimal(SumFI),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumFI.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumEJ) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEJ)-Convert.ToDecimal(SumEH))/Convert.ToDecimal(SumEJ),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumEJ.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumFJ) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFJ)-Convert.ToDecimal(SumFH))/Convert.ToDecimal(SumFJ),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumFJ.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumEK) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEK)-Convert.ToDecimal(SumEJ))/Convert.ToDecimal(SumEK),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumEK.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");

	if (Convert.ToDecimal(SumFK) !=0)
	{

	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFK)-Convert.ToDecimal(SumFJ))/Convert.ToDecimal(SumFK),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");

	}
	else
	{

	templateBuilder.Append("              " + SumFK.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("        </tr>\r\n");

	if (fList !=null)
	{


	int fl__loop__id=0;
	foreach(DataRow fl in fList.Rows)
	{
		fl__loop__id++;

	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("        <td colspan=\"6\" align=\"center\"><b>销售门店数增幅</b></td>\r\n");
	templateBuilder.Append("         <td align=\"right\" colspan=\"2\">" + fl["countStorage_1"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("         <td align=\"right\" colspan=\"2\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(fl["countStorage_2"].ToString().Trim())-Convert.ToDecimal(fl["countStorage_1"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\" colspan=\"2\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(fl["countStorage_3"].ToString().Trim())-Convert.ToDecimal(fl["countStorage_2"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\" colspan=\"2\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(fl["countStorage_4"].ToString().Trim())-Convert.ToDecimal(fl["countStorage_3"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\" colspan=\"2\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(fl["countStorage_5"].ToString().Trim())-Convert.ToDecimal(fl["countStorage_4"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\" colspan=\"2\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(fl["countStorage_6"].ToString().Trim())-Convert.ToDecimal(fl["countStorage_5"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\" colspan=\"2\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(fl["countStorage_7"].ToString().Trim())-Convert.ToDecimal(fl["countStorage_6"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\" colspan=\"2\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(fl["countStorage_8"].ToString().Trim())-Convert.ToDecimal(fl["countStorage_7"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\" colspan=\"2\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(fl["countStorage_9"].ToString().Trim())-Convert.ToDecimal(fl["countStorage_8"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\" colspan=\"2\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(fl["countStorage_10"].ToString().Trim())-Convert.ToDecimal(fl["countStorage_9"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\" colspan=\"2\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(fl["countStorage_11"].ToString().Trim())-Convert.ToDecimal(fl["countStorage_10"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\" colspan=\"2\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(fl["countStorage_12"].ToString().Trim())-Convert.ToDecimal(fl["countStorage_11"].ToString().Trim()),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("        </tr>\r\n");

	}	//end loop


	}	//end if

	templateBuilder.Append("        <tr>\r\n");
	templateBuilder.Append("         <td colspan=\"6\" align=\"center\"><b>店均零售额增幅</b></td>\r\n");
	templateBuilder.Append("         <td align=\"right\">0</td>\r\n");
	templateBuilder.Append("         <td align=\"right\">0</td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEA)/rList)-(Convert.ToDecimal(SumE)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFA)/rList)-(Convert.ToDecimal(SumF)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEB)/rList)-(Convert.ToDecimal(SumEA)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFB)/rList)-(Convert.ToDecimal(SumFA)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEC)/rList)-(Convert.ToDecimal(SumEB)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFC)/rList)-(Convert.ToDecimal(SumFB)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumED)/rList)-(Convert.ToDecimal(SumEC)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFD)/rList)-(Convert.ToDecimal(SumFC)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEE)/rList)-(Convert.ToDecimal(SumED)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFE)/rList)-(Convert.ToDecimal(SumFD)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEF)/rList)-(Convert.ToDecimal(SumEE)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFF)/rList)-(Convert.ToDecimal(SumFE)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEG)/rList)-(Convert.ToDecimal(SumEF)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFG)/rList)-(Convert.ToDecimal(SumFF)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEH)/rList)-(Convert.ToDecimal(SumEG)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFH)/rList)-(Convert.ToDecimal(SumFG)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEI)/rList)-(Convert.ToDecimal(SumEH)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFI)/rList)-(Convert.ToDecimal(SumFH)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEJ)/rList)-(Convert.ToDecimal(SumEI)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFJ)/rList)-(Convert.ToDecimal(SumFI)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumEK)/rList)-(Convert.ToDecimal(SumEJ)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("         <td align=\"right\"><span>\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(SumFK)/rList)-(Convert.ToDecimal(SumFJ)/rList),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</span>\r\n");
	templateBuilder.Append("         </td>\r\n");
	templateBuilder.Append("        </tr>\r\n");

	}	//end if


	}	//end loop


	}	//end if


	}	//end if

	templateBuilder.Append("  </table>\r\n");

	}	//end if


	if (bType==0)
	{

	templateBuilder.Append("<div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("   <div class=\"datalist\">\r\n");
	templateBuilder.Append("    <table width=\"60%\" id=\"select_data\" border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("     <tr class=\"tBar\">\r\n");
	templateBuilder.Append("       <td colspan=\"2\" width=\"15%\"><label>区域:" + get_rName.ToString() + "</label></td>\r\n");
	templateBuilder.Append("       <td  width=\"10%\"><label>业务员:\r\n");

	if (get_staffName=="-1")
	{

	templateBuilder.Append("选择全部\r\n");

	}
	else
	{

	templateBuilder.Append("" + get_staffName.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("       </label>\r\n");
	templateBuilder.Append("       </td>\r\n");
	templateBuilder.Append("       <td  width=\"15%\"><label>\r\n");
	templateBuilder.Append("       门店:\r\n");

	if (get_storageName=="-1")
	{

	templateBuilder.Append("选择全部\r\n");

	}
	else
	{

	templateBuilder.Append("" + get_storageName.ToString() + "\r\n");

	}	//end if

	templateBuilder.Append("       </label>\r\n");
	templateBuilder.Append("       </td>\r\n");
	templateBuilder.Append("       <td  width=\"10%\">\r\n");
	templateBuilder.Append("       <label>类型:\r\n");

	if (get_reTypeValue=="-1")
	{

	templateBuilder.Append("全部\r\n");

	}	//end if


	if (get_reTypeValue=="0")
	{

	templateBuilder.Append("进货\r\n");

	}	//end if


	if (get_reTypeValue=="1")
	{

	templateBuilder.Append("销售\r\n");

	}	//end if


	if (get_reTypeValue=="2")
	{

	templateBuilder.Append("库存\r\n");

	}	//end if

	templateBuilder.Append("       </label>\r\n");
	templateBuilder.Append("       </td>\r\n");
	templateBuilder.Append("       <td width=\"10%\">\r\n");
	templateBuilder.Append("        <label>联营:\r\n");

	if (associated=="-1")
	{

	templateBuilder.Append("包含\r\n");

	}	//end if


	if (associated=="0")
	{

	templateBuilder.Append("剔除\r\n");

	}	//end if


	if (associated=="1")
	{

	templateBuilder.Append("仅包含\r\n");

	}	//end if

	templateBuilder.Append("        </label>\r\n");
	templateBuilder.Append("       </td>\r\n");
	templateBuilder.Append("       <td colspan=\"12\"><label>查询日期:" + sDate.ToLongDateString().ToString().Trim() + "</label>—<label>" + stDate.ToLongDateString().ToString().Trim() + "</label>\r\n");
	templateBuilder.Append("       </td>\r\n");
	templateBuilder.Append("     </tr>\r\n");
	templateBuilder.Append("     </table>\r\n");
	templateBuilder.Append("<div id=\"space\"></div>\r\n");
	templateBuilder.Append(" <table width=\"100%\" id=\"get_data\" class=\"tBox\" border=\"0\"  cellspacing=\"2\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("     <thead>\r\n");
	templateBuilder.Append("         <tr class=\"tBar\">\r\n");
	templateBuilder.Append("            <td width=\"2%\" align=\"center\" rowspan=\"3\"><b>序号</b></td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"center\" rowspan=\"3\"><b>商品条码</b></td>    \r\n");
	templateBuilder.Append("	        <td width=\"15%\"align=\"center\" rowspan=\"3\"><b>商品名称</b></td>\r\n");
	templateBuilder.Append("            <td width=\"5%\" align=\"center\" rowspan=\"3\"><b>装件数</b></td>\r\n");

	if (reType==-1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <td width=\"15%\" align=\"center\" colspan=\"3\" rowspan=\"2\"><b>期初结存</b></td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==-1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <td width=\"30%\" align=\"center\" colspan=\"10\"><b>进货数量</b></td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==-1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <td width=\"15%\" align=\"center\" colspan=\"3\" rowspan=\"2\"><b>销售数量</b></td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==-1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("           <td width=\"10%\" align=\"center\" colspan=\"2\" rowspan=\"2\"><b>期末结存</b></td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==2)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("	        <td width=\"15%\" align=\"center\" colspan=\"3\"><b>期初结存</b></td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==0)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <td  width=\"30%\" align=\"center\" colspan=\"10\"><b>进货数量</b></td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <td width=\"15%\" align=\"center\" colspan=\"3\"><b>销售数量</b></td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");

	if (reType==-1)
	{

	templateBuilder.Append("        <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("        <tr align=\"center\" class=\"tBar\">\r\n");
	templateBuilder.Append("         <td colspan=\"2\">进货</td>\r\n");
	templateBuilder.Append("         <td colspan=\"2\">赠品</td>\r\n");
	templateBuilder.Append("         <td colspan=\"2\">样品</td>\r\n");
	templateBuilder.Append("         <td colspan=\"2\">退货</td>\r\n");
	templateBuilder.Append("         <td colspan=\"2\">小计</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        </div>\r\n");

	}	//end if


	if (reType==0)
	{

	templateBuilder.Append("        <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("        <tr align=\"center\">\r\n");
	templateBuilder.Append("         <td colspan=\"2\">进货</td>\r\n");
	templateBuilder.Append("         <td colspan=\"2\">赠品</td>\r\n");
	templateBuilder.Append("         <td colspan=\"2\">样品</td>\r\n");
	templateBuilder.Append("         <td colspan=\"2\">退货</td>\r\n");
	templateBuilder.Append("         <td colspan=\"2\">小计</td>\r\n");
	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("        </div>\r\n");

	}	//end if

	templateBuilder.Append("         <tr class=\"tBar\" style=\"width:100%\">\r\n");

	if (reType==2)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("	        <td width=\"5%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("	        <td width=\"5%\" align=\"right\" >件数</td>\r\n");
	templateBuilder.Append("            <td width=\"5%\" align=\"right\" >总金额</td>\r\n");
	templateBuilder.Append("           </div>\r\n");

	}	//end if


	if (reType==0)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >金额</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >金额</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >金额</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >金额</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >金额</td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <td width=\"5%\" align=\"right\">数量</td>\r\n");
	templateBuilder.Append("	        <td width=\"5%\" align=\"right\">件数</td>\r\n");
	templateBuilder.Append("            <td width=\"5%\" align=\"right\" >总金额</td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==-1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("	        <td width=\"5%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("	        <td width=\"5%\" align=\"right\" >件数</td>\r\n");
	templateBuilder.Append("            <td width=\"5%\" align=\"right\" >总金额</td>\r\n");
	templateBuilder.Append("           </div>\r\n");

	}	//end if


	if (reType==-1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >金额</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >金额</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >金额</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >金额</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("            <td width=\"3%\" align=\"right\" >金额</td>\r\n");
	templateBuilder.Append("             </div>\r\n");

	}	//end if


	if (reType==-1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <td width=\"5%\" align=\"right\">数量</td>\r\n");
	templateBuilder.Append("	        <td width=\"5%\" align=\"right\">件数</td>\r\n");
	templateBuilder.Append("            <td width=\"5%\" align=\"right\" >总金额</td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==-1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <td width=\"5%\" align=\"right\" >数量</td>\r\n");
	templateBuilder.Append("            <td width=\"5%\" align=\"right\" >件数</td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if

	templateBuilder.Append("        </tr>\r\n");
	templateBuilder.Append("       </table>\r\n");
	templateBuilder.Append("       <table width=\"100%\"  border=\"0\" cellspacing=\"2\" cellpadding=\"0\" class=\"tBox\">\r\n");
	templateBuilder.Append("        <tbody>\r\n");

	if (dList != null)
	{


	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("            <td align=\"center\" width=\"2%\" id=\"id\">" + dl__loop__id.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"left\"  width=\"8%\" id=\"pBarCode\">\r\n");
	templateBuilder.Append("            <a href=\"javascript:void(0);\" onclick=\"javascript:GetDataListDo.GetDataList('" + dl["ProductsID"].ToString().Trim() + "','" + dl["pName"].ToString().Trim() + "','" + dl["pBarcode"].ToString().Trim() + "','" + sDate.ToString() + "','" + stDate.ToString() + "');\">" + dl["pBarcode"].ToString().Trim() + "</a>\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"left\" width=\"15%\" id=\"pName\">\r\n");
	templateBuilder.Append("            <a href=\"javascript:void(0);\" onclick=\"javascript:GetDataListDo.GetDataList('" + dl["ProductsID"].ToString().Trim() + "','" + dl["pName"].ToString().Trim() + "','" + dl["pBarcode"].ToString().Trim() + "','" + sDate.ToString() + "','" + stDate.ToString() + "');\">" + dl["pName"].ToString().Trim() + "</a></td>\r\n");
	templateBuilder.Append("            <td align=\"center\" width=\"5%\" id=\"pToBoxNo\">" + dl["pToBoxNo"].ToString().Trim() + "</td> \r\n");

	if (reType==2)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">  \r\n");
	templateBuilder.Append("			<!--期初数量-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"5%\" id=\"rNum\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["RelityStorage"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumA = decimal.Round(SumA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <!--期初件数-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"5%\" id=\"rBox\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["RelityStorage"])/Convert.ToDecimal(dl["pToBoxNo"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumAA = decimal.Round(SumAA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("             <!--期初金额-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"5%\" id=\"rMoney\"> \r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["pPrice"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumAAA = decimal.Round(SumAAA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==0)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <!--进货-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\" id=\"iNum\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["InQuantity"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumB = decimal.Round(SumB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\" id=\"iMoney\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumBA = decimal.Round(SumBA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <!--赠品-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["GiveQuantity"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumBB = decimal.Round(SumBB+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["GivePrice"]),2).ToString();
	
	 SumBC = decimal.Round(SumBC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("             <!--样品-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["yQuantity"]),2).ToString();
	
	 SumBD = decimal.Round(SumBD+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["yPrice"]),2).ToString();
	
	 SumBE = decimal.Round(SumBE+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("             <!--退货-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["outQuantity"])).ToString();
	
	 SumBF = decimal.Round(SumBF+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["OutPrice"]),2).ToString();
	
	 SumBG = decimal.Round(SumBG+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("             <!--小计-->\r\n");
	templateBuilder.Append("             <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(dl["InQuantity"])+Convert.ToDecimal(dl["GiveQuantity"])+Convert.ToDecimal(dl["yQuantity"])-Convert.ToDecimal(dl["outQuantity"])),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumBH = decimal.Round(SumBH+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(dl["oMoney"])+Convert.ToDecimal(dl["GivePrice"])+Convert.ToDecimal(dl["yPrice"])-Convert.ToDecimal(dl["OutPrice"])),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumBI = decimal.Round(SumBI+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("             <!--销售数量-->\r\n");
	templateBuilder.Append("             <td align=\"right\" width=\"5%\" id=\"sNum\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["OutQuantity"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumC = decimal.Round(SumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <!--销售件数-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"5%\" id=\"sBox\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["OutQuantity"])/Convert.ToDecimal(dl["pToBoxNo"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumCC = decimal.Round(SumCC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("             <!--销售金额-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"5%\" id=\"sMoney\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["SalesPrice"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumCCC = decimal.Round(SumCCC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==-1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <!--期初数量-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["RelityStorage"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumA = decimal.Round(SumA+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <!--期初件数-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["RelityStorage"])/Convert.ToDecimal(dl["pToBoxNo"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumAA = decimal.Round(SumAA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("             <!--期初金额-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["pPrice"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumAAA = decimal.Round(SumAAA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==-1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <!--进货-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\" class=\"tdTextH\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["InQuantity"])).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumB = decimal.Round(SumB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["oMoney"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + " \r\n");
	 SumBA = decimal.Round(SumBA+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <!--赠品-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["GiveQuantity"])).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumBB = decimal.Round(SumBB+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("             </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["GivePrice"]),2).ToString();
	
	 SumBC = decimal.Round(SumBC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("             <!--样品-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["yQuantity"])).ToString();
	
	 SumBD = decimal.Round(SumBD+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["yPrice"]),2).ToString();
	
	 SumBE = decimal.Round(SumBE+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("             <!--退货-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["outQuantity1"])).ToString();
	
	 SumBF = decimal.Round(SumBF+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["OutPrice"]),2).ToString();
	
	 SumBG = decimal.Round(SumBG+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("             <!--小计-->\r\n");
	templateBuilder.Append("             <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(dl["InQuantity"])+Convert.ToDecimal(dl["GiveQuantity"])+Convert.ToDecimal(dl["yQuantity"])-Convert.ToDecimal(dl["outQuantity1"]))).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumBH = decimal.Round(SumBH+Convert.ToDecimal(aspxrewriteurl));
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"3%\">\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(dl["oMoney"])+Convert.ToDecimal(dl["GivePrice"])+Convert.ToDecimal(dl["yPrice"])-Convert.ToDecimal(dl["OutPrice"])),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumBI = decimal.Round(SumBI+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==-1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("             <!--销售数量-->\r\n");
	templateBuilder.Append("             <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["OutQuantity"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumC = decimal.Round(SumC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <!--销售件数-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["OutQuantity"])/Convert.ToDecimal(dl["pToBoxNo"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumCC = decimal.Round(SumCC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("             <!--销售金额-->\r\n");
	templateBuilder.Append("            <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["SalesPrice"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumCCC = decimal.Round(SumCCC+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if


	if (reType==-1)
	{

	templateBuilder.Append("            <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("            <!--期末数量-->\r\n");
	templateBuilder.Append("             <td align=\"right\" width=\"5%\" >\r\n");
	 aspxrewriteurl = decimal.Round(Convert.ToDecimal(dl["RelityStorage"])+Convert.ToDecimal(dl["InQuantity"])-Convert.ToDecimal             (dl["OutQuantity"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumD = decimal.Round(SumD+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <!--期末件数-->\r\n");
	templateBuilder.Append("             <td align=\"right\" width=\"5%\">\r\n");
	 aspxrewriteurl = decimal.Round((Convert.ToDecimal(dl["RelityStorage"])+Convert.ToDecimal(dl["InQuantity"])-Convert.ToDecimal             (dl["OutQuantity"]))/Convert.ToDecimal(dl["pToBoxNo"]),2).ToString();
	
	templateBuilder.Append("             " + aspxrewriteurl.ToString() + "\r\n");
	 SumDD = decimal.Round(SumDD+Convert.ToDecimal(aspxrewriteurl),2);
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            </div>\r\n");

	}	//end if

	templateBuilder.Append("          </tr>\r\n");

	}	//end loop

	templateBuilder.Append("          </tbody>\r\n");
	templateBuilder.Append("          <tfoot>\r\n");

	if (ispost)
	{

	templateBuilder.Append("              <tr style=\"height:30px\">\r\n");
	templateBuilder.Append("                <td align=\"center\"  colspan=\"4\"><span style=\"font-size:larger\"><b>合计：</b></span></td>\r\n");

	if (reType==-1)
	{

	templateBuilder.Append("                <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumAAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBD.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBE.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBF.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBG.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBH.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBI.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumCC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumCCC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumD.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumDD.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                </div>\r\n");

	}	//end if


	if (reType==2)
	{

	templateBuilder.Append("                <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumAAA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                </div>\r\n");

	}	//end if


	if (reType==0)
	{

	templateBuilder.Append("                <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("                 <td align=\"right\" ><span>" + SumB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBA.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBB.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBD.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBE.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBF.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBG.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBH.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumBI.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                </div>\r\n");

	}	//end if


	if (reType==1)
	{

	templateBuilder.Append("                <div style=\"visibility:visible\">\r\n");
	templateBuilder.Append("                 <td align=\"right\" ><span>" + SumC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumCC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                <td align=\"right\" ><span>" + SumCCC.ToString() + "</span></td>\r\n");
	templateBuilder.Append("                </div>\r\n");

	}	//end if

	templateBuilder.Append("              </tr>\r\n");

	}	//end if

	templateBuilder.Append("           </tfoot>\r\n");

	}	//end if

	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("        </div>\r\n");

	}	//end if

	templateBuilder.Append("      <div id=\"winAll\">\r\n");
	templateBuilder.Append("          <div id=\"winLoding\"><img alt=\"\" src=\"/images/loading99.gif\"/></div>\r\n");
	templateBuilder.Append("         </div>\r\n");
	templateBuilder.Append("      <script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("          var GetDataListDo = new getListOfRegion();\r\n");
	templateBuilder.Append("          GetDataListDo.ini();\r\n");
	templateBuilder.Append("          function HidBox() {\r\n");
	templateBuilder.Append("              GetDataListDo.HidUserBox();\r\n");
	templateBuilder.Append("              location.reload();\r\n");
	templateBuilder.Append("          }\r\n");
	templateBuilder.Append("          $(\"#btn_submit\").click(function(){\r\n");
	templateBuilder.Append("              var bTime = $('#sDate').val();\r\n");
	templateBuilder.Append("              var eTime = $('#stDate').val();\r\n");
	templateBuilder.Append("              var reType = $('#reType').children('option:selected').val();\r\n");
	templateBuilder.Append("              document.getElementById(\"reTypeValue\").value = reType;\r\n");
	templateBuilder.Append("              var _associated = $(\"#associated\").children('option:selected').val();\r\n");
	templateBuilder.Append("              document.getElementById(\"_associated\").value = _associated;\r\n");
	templateBuilder.Append("              if (eTime < bTime) {\r\n");
	templateBuilder.Append("                  alert(\"日期选择错误，请重新选择！\"); \r\n");
	templateBuilder.Append("              }\r\n");
	templateBuilder.Append("              else {\r\n");
	templateBuilder.Append("                 $(\"div#winAll\").fadeIn(\"slow\");\r\n");
	templateBuilder.Append("                 $('#bForm').submit();   \r\n");
	templateBuilder.Append("              }\r\n");
	templateBuilder.Append("         });\r\n");
	templateBuilder.Append("         //导出数据\r\n");
	templateBuilder.Append("         $(\"#export\").click(function () {\r\n");
	templateBuilder.Append("             var id = $.query.get('id');\r\n");
	templateBuilder.Append("             if (id == \"0\") {\r\n");
	templateBuilder.Append("                 var rName = $(\"#rName\").children('option:selected').val();\r\n");
	templateBuilder.Append("                 var staffName = $(\"#staffName\").children('option:selected').val();\r\n");
	templateBuilder.Append("                 var storageName = $(\"#storageName\").children('option:selected').val();\r\n");
	templateBuilder.Append("                 var sDate = $(\"#sDate\").val();\r\n");
	templateBuilder.Append("                 var stDate = $(\"#stDate\").val();\r\n");
	templateBuilder.Append("                 var reType = $(\"#reType\").children('option:selected').val();\r\n");
	templateBuilder.Append("                 var associated = $(\"#associated\").children('option:selected').val();\r\n");
	templateBuilder.Append("                 var _url = '/report_storehousestorage.aspx?Act=act&rName=' + rName + '&staffName=' + staffName + '&storageName=' + storageName + '&sDate=' + sDate + '&stDate=' + stDate + '&reType=' + reType + '&associated=' + associated + '&id=' + id;\r\n");
	templateBuilder.Append("                 window.open('', \"top\");\r\n");
	templateBuilder.Append("                 setTimeout(window.open(_url, \"top\"), 100);\r\n");
	templateBuilder.Append("             }\r\n");
	templateBuilder.Append("         });\r\n");
	templateBuilder.Append("     </" + "script>\r\n");
	templateBuilder.Append("    </form>\r\n");
	templateBuilder.Append("    </div>\r\n");

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
