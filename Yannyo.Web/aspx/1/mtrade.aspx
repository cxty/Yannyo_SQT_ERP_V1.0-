<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Yannyo.Web.mtrade" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Yannyo.Common" %>
<%@ Import namespace="Yannyo.Entity" %>

<script runat="server">
override protected void OnLoad(EventArgs e)
{

	/* 
		本页面代码由Yannyo模板引擎生成于 2015/6/2 16:49:18. 
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



	if (ispost)
	{


	if (page_err==0)
	{


	templateBuilder.Append("<div id=\"mes\">\r\n");
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



	}	//end if


	}
	else
	{

	templateBuilder.Append("    <div class=\"main\" >\r\n");

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



	templateBuilder.Append("<script language=\"javascript\" src=\"public/js/jTable.js\"></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/WebCalendar.js\" type=\"text/javascript\" ></" + "script>\r\n");
	templateBuilder.Append("<script src=\"public/js/mtrade.js\" language=\"javascript\" type=\"text/javascript\"></" + "script>\r\n");
	templateBuilder.Append("<form action=\"\" method=\"post\" name=\"form1\" id=\"form1\">\r\n");
	templateBuilder.Append("<div >\r\n");
	templateBuilder.Append("<div class=\"toolbar\">\r\n");
	templateBuilder.Append("  <table border=\"0\" cellspacing=\"3\" cellpadding=\"3\" >\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td>交易状态<br />\r\n");
	templateBuilder.Append("    <select name=\"status\" id=\"status\">\r\n");
	templateBuilder.Append("    <option value=\"-1\"\r\n");

	if (status == -1)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("     >所有</option>\r\n");
	templateBuilder.Append("      <option value=\"1\"\r\n");

	if (status == 1)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("      >等待买家付款</option>\r\n");
	templateBuilder.Append("      <option value=\"2\"\r\n");

	if (status == 2)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("      >等待卖家发货</option>\r\n");
	templateBuilder.Append("      <option value=\"3\"\r\n");

	if (status == 3)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("      >等待买家确认收货</option>\r\n");
	templateBuilder.Append("      <option value=\"4\"\r\n");

	if (status == 4)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("      >买家已签收</option>\r\n");
	templateBuilder.Append("      <option value=\"5\"\r\n");

	if (status == 5)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("      >交易成功</option>\r\n");
	templateBuilder.Append("      <option value=\"6\"\r\n");

	if (status == 6)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("      >交易关闭</option>\r\n");
	templateBuilder.Append("      <option value=\"7\"\r\n");

	if (status == 7)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("      >被淘宝关闭</option>\r\n");
	templateBuilder.Append("    </select></td>\r\n");
	templateBuilder.Append("    <td>发货状态<br />\r\n");
	templateBuilder.Append("	<select name=\"sendgoods\" id=\"sendgoods\">\r\n");
	templateBuilder.Append("	  <option value=\"-1\"\r\n");

	if (sendgoods == -1)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("      >所有</option>\r\n");
	templateBuilder.Append("	  <option value=\"0\"\r\n");

	if (sendgoods == 0)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("      >已开单</option>\r\n");
	templateBuilder.Append("	  <option value=\"1\"\r\n");

	if (sendgoods == 1)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("      >未发货</option>\r\n");
	templateBuilder.Append("	  <option value=\"2\"\r\n");

	if (sendgoods == 2)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("      >已发货</option>\r\n");
	templateBuilder.Append("    </select></td>\r\n");
	templateBuilder.Append("    <td>平价状态<br />\r\n");
	templateBuilder.Append("      <select name=\"rate\" id=\"rate\">\r\n");
	templateBuilder.Append("        <option value=\"-1\"\r\n");

	if (rate == -1)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("        >所有</option>\r\n");
	templateBuilder.Append("        <option value=\"0\"\r\n");

	if (rate == 0)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("        >买家未评价</option>\r\n");
	templateBuilder.Append("        <option value=\"1\"\r\n");

	if (rate == 1)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("        >买家经评价</option>\r\n");
	templateBuilder.Append("        <option value=\"2\"\r\n");

	if (rate == 2)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("        >卖家未评价</option>\r\n");
	templateBuilder.Append("        <option value=\"3\"\r\n");

	if (rate == 3)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("        >卖家已评价</option>\r\n");
	templateBuilder.Append("        <option value=\"4\"\r\n");

	if (rate == 4)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("        >双方未评价</option>\r\n");
	templateBuilder.Append("        <option value=\"5\"\r\n");

	if (rate == 5)
	{

	templateBuilder.Append("     selected=\"selected\"\r\n");

	}	//end if

	templateBuilder.Append("        >双方经评价</option>\r\n");
	templateBuilder.Append("      </select>\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td>交易时间<br /><input name=\"oDateTimeB\" id=\"oDateTimeB\" style=\"width:80px\" value=\"" + oDateTimeB.ToString() + "\" type=\"text\" onClick=\"new Calendar().show(this);\" readonly=\"readonly\"/>-<input name=\"oDateTimeE\" id=\"oDateTimeE\" style=\"width:80px\" value=\"" + oDateTimeE.ToString() + "\" type=\"text\" onClick=\"new Calendar().show(this);\" readonly=\"readonly\"/></td>\r\n");
	templateBuilder.Append("    <td>关键字<br /><input name=\"S_key\" id=\"S_key\" type=\"text\" value=\"" + S_key.ToString() + "\" /></td>\r\n");
	templateBuilder.Append("    <td><input type=\"button\" id=\"bt_Search\" style=\"margin:5px;\" class=\"B_INPUT\" value=\" 查找 \"  /></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("    <tr>\r\n");
	templateBuilder.Append("    <td colspan=\"6\"><input type=\"button\" id=\"bt_DownLoad\" style=\"margin:5px\" class=\"B_INPUT\" value=\"下载数据\" />\r\n");
	templateBuilder.Append("      <input type=\"button\" id=\"bt_Reload\" style=\"margin:5px\" class=\"B_INPUT\" value=\"更新选中\" />\r\n");
	templateBuilder.Append("      <input type=\"button\" id=\"bt_Delt\" style=\"margin:5px\" class=\"B_INPUT\" value=\"删除选中\" />\r\n");
	templateBuilder.Append("      <input type=\"button\" id=\"bt_Close\" style=\"margin:5px\" class=\"B_INPUT\" value=\"关闭选中\" />\r\n");
	templateBuilder.Append("      <input type=\"button\" id=\"bt_Union\" style=\"margin:5px;width:120px;\" class=\"B_INPUT\" value=\"合并开单发货\" />\r\n");
	templateBuilder.Append("      <input type=\"button\" id=\"bt_Good\" style=\"margin:5px\" class=\"B_INPUT\" value=\"平价选中\"  /></td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("</table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<div class=\"mtitleBox\"><span>客户:" + M_Config.StoresName.ToString().Trim() + "-网店:" + M_Config.m_Name.ToString().Trim() + " </span></div>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("<div class=\"datalist\">\r\n");
	templateBuilder.Append("        <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"tBox\" id=\"tBox\" >\r\n");
	templateBuilder.Append("        <thead>\r\n");
	templateBuilder.Append("          <tr class=\"tBar\">\r\n");
	templateBuilder.Append("            <td width=\"2%\"><input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"\" onclick=\"javascript:selectCheck(document.getElementById('form1'),this);\"/></td>\r\n");
	templateBuilder.Append("            <td >订单编号</td>\r\n");
	templateBuilder.Append("            <td width=\"10%\" >支付宝交易号</td>\r\n");
	templateBuilder.Append("            <td width=\"10%\">买家昵称</td>\r\n");
	templateBuilder.Append("            <td width=\"6%\" align=\"right\" >金额</td>\r\n");
	templateBuilder.Append("            <td width=\"6%\" align=\"right\" >运费</td>\r\n");
	templateBuilder.Append("            <td width=\"6%\" align=\"right\" >总金额</td>\r\n");
	templateBuilder.Append("            <td width=\"10%\" align=\"center\">交易状态</td>\r\n");
	templateBuilder.Append("            <td width=\"6%\" align=\"right\">成交时间</td>\r\n");
	templateBuilder.Append("            <td width=\"6%\" align=\"right\">更新时间</td>\r\n");
	templateBuilder.Append("            <td width=\"10%\" align=\"center\">操作</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("		</thead>\r\n");

	if (dList != null)
	{

	templateBuilder.Append("		  <tbody id=\"dloop\">\r\n");

	int dl__loop__id=0;
	foreach(DataRow dl in dList.Rows)
	{
		dl__loop__id++;

	templateBuilder.Append("          <tr id=\"tr_" + dl["tid"].ToString().Trim() + "\" >\r\n");
	templateBuilder.Append("          <td colspan=\"11\">\r\n");
	templateBuilder.Append("          <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" style=\"background:auto;\">\r\n");
	templateBuilder.Append("          <tr >\r\n");
	templateBuilder.Append("            <td width=\"2%\" >\r\n");
	templateBuilder.Append("            <input name=\"cCheck\" type=\"checkbox\" class=\"B_Check\" value=\"" + dl["m_TradeInfoID"].ToString().Trim() + "\" tid=\"" + dl["tid"].ToString().Trim() + "\" />\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("		    <td ><a>" + dl["tid"].ToString().Trim() + "</a></td>\r\n");
	templateBuilder.Append("		    <td width=\"10%\" >" + dl["alipay_no"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td width=\"10%\">" + dl["buyer_nick"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		    <td width=\"6%\" align=\"right\" id=\"total_fee_" + dl["tid"].ToString().Trim() + "\">" + dl["total_fee"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("		    <td width=\"6%\" align=\"right\" id=\"post_fee_" + dl["tid"].ToString().Trim() + "\">" + dl["post_fee"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td width=\"6%\" align=\"right\" id=\"all_fee_" + dl["tid"].ToString().Trim() + "\">\r\n");
	 aspxrewriteurl = (decimal.Parse(dl["total_fee"].ToString())+decimal.Parse(dl["post_fee"].ToString())).ToString();
	
	templateBuilder.Append("              " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td width=\"10%\" align=\"center\" id=\"status_" + dl["tid"].ToString().Trim() + "\">\r\n");
	 aspxrewriteurl = GetTradeStatus(dl["status"].ToString());
	
	templateBuilder.Append("              " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"6%\" align=\"right\">" + dl["created"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td width=\"6%\" align=\"right\" id=\"modified_" + dl["tid"].ToString().Trim() + "\">" + dl["modified"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td width=\"10%\" align=\"right\">\r\n");
	templateBuilder.Append("			<nobr>\r\n");

	if (GetTradeStatusIndex(dl["status"].ToString()) <= 1)
	{

	templateBuilder.Append("            <a href=\"javascript:void(0);\" onclick=\"javascript:M_Trade.Edit(" + dl["m_TradeInfoID"].ToString().Trim() + ");\"><nobr>调整金额</nobr></a>|\r\n");

	}	//end if


	            if (GetTradeStatusIndex(dl["status"].ToString()) == 2)
				{
	                M_SendGoodsInfo _ms = new M_SendGoodsInfo();
	                try
	                {
	                    _ms = GetSendGoods(dl["m_TradeInfoID"].ToString());
	                    if(_ms!=null)
	                    {
	                        
	templateBuilder.Append("                        	<a href=\"javascript:void(0);\" onclick=\"javascript:M_Trade.SHSendGoods(" + dl["m_TradeInfoID"].ToString().Trim() + ");\"><nobr id=\"syh_" + dl["tid"].ToString().Trim() + "\">发货单</nobr></a>|\r\n");

	                    }else{
	                        
	templateBuilder.Append("                            <a href=\"javascript:void(0);\" onclick=\"javascript:M_Trade.SendGoods(" + dl["m_TradeInfoID"].ToString().Trim() + ");\"><nobr>开单发货</nobr></a>|\r\n");

	                    }
	                }
	                finally
	                {
	                    _ms = null;
	                }
	            }else if(GetTradeStatusIndex(dl["status"].ToString()) > 2){
	            	
	templateBuilder.Append("                	<a href=\"javascript:void(0);\" onclick=\"javascript:M_Trade.SHSendGoods(" + dl["m_TradeInfoID"].ToString().Trim() + ");\"><nobr id=\"syh_" + dl["tid"].ToString().Trim() + "\">发货单</nobr></a>|\r\n");

	            }
	            
	templateBuilder.Append("			<a href=\"javascript:void(0);\" onclick=\"javascript:M_Trade.SHOrder($('#tr_" + dl["tid"].ToString().Trim() + "'));\"><nobr id=\"sh_" + dl["tid"].ToString().Trim() + "\">查看</nobr></a>|\r\n");
	templateBuilder.Append("            <a href=\"javascript:void(0);\" onclick=\"javascript:M_Trade.TradeMemo(" + dl["m_TradeInfoID"].ToString().Trim() + ");\"><nobr>备注</nobr></a>&nbsp;&nbsp;\r\n");
	templateBuilder.Append("            </nobr>\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("          </table>\r\n");
	templateBuilder.Append("          <div id=\"order_" + dl["tid"].ToString().Trim() + "\" class=\"Orders\"  >\r\n");

	 sum_a = 0;
	
	 sum_b = 0;
	
	 sum_c = 0;
	
	 sum_d = 0;
	
	 sum_e = 0;
	

	if (oList!=null)
	{

	templateBuilder.Append("          <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" class=\"tBox\" id=\"order_box_" + dl__loop__id.ToString() + "\">\r\n");
	templateBuilder.Append("          <tr class=\"tBar\">\r\n");
	templateBuilder.Append("            <td colspan=\"2\">商品名称</td>\r\n");
	templateBuilder.Append("            <td width=\"20%\">对应商品</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">单价</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">数量</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">应付金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">优惠金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">调整金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">实付金额</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">订单到期时间</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");

	int ol__loop__id=0;
	foreach(DataRow ol in oList.Rows)
	{
		ol__loop__id++;


	if (ol["m_TradeInfoID"].ToString() == dl["m_TradeInfoID"].ToString())
	{

	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("            <td width=\"50\" valign=\"middle\">\r\n");

	if (ol["pic_path"].ToString().Trim()!="")
	{

	templateBuilder.Append("            <img src=\"" + ol["pic_path"].ToString().Trim() + "\" alt=\"" + ol["title"].ToString().Trim() + "\" width=\"50\" height=\"50\" />\r\n");

	}	//end if

	templateBuilder.Append("</td>\r\n");
	templateBuilder.Append("            <td valign=\"middle\">" + ol["title"].ToString().Trim() + " </td>\r\n");
	templateBuilder.Append("            <td width=\"20%\">" + ol["ProductsName"].ToString().Trim() + "<br>\r\n");
	templateBuilder.Append("            " + ol["ProductsBarcode"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">" + ol["price"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">" + ol["num"].ToString().Trim() + "\r\n");
	 sum_a = sum_a+decimal.Parse(ol["num"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">" + ol["total_fee"].ToString().Trim() + "\r\n");
	 sum_b = sum_b+decimal.Parse(ol["total_fee"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">" + ol["discount_fee"].ToString().Trim() + "\r\n");
	 sum_c = sum_c+decimal.Parse(ol["discount_fee"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">\r\n");
	templateBuilder.Append("            " + ol["adjust_fee"].ToString().Trim() + "\r\n");
	 sum_d = sum_d+decimal.Parse(ol["adjust_fee"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">" + ol["payment"].ToString().Trim() + "\r\n");
	 sum_e = sum_e+decimal.Parse(ol["payment"].ToString());
	
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("            <td width=\"8%\" align=\"right\">\r\n");
	 aspxrewriteurl = FormatDateTime(ol["timeout_action_time"]);
	
	templateBuilder.Append("            " + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("            </td>\r\n");
	templateBuilder.Append("          </tr>\r\n");

	}	//end if


	}	//end loop

	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"2\">合计:</td>\r\n");
	templateBuilder.Append("            <td>&nbsp;</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">&nbsp;</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_a.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_b.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_c.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_d.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">" + sum_e.ToString() + "</td>\r\n");
	templateBuilder.Append("            <td align=\"right\">&nbsp;</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("        <table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\">\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td  class=\"ltd\">销售单单号:</td>\r\n");
	templateBuilder.Append("    <td  class=\"rtd\">&nbsp;</td>\r\n");
	templateBuilder.Append("    <td  class=\"ltd\">物流方式:</td>\r\n");
	templateBuilder.Append("    <td  class=\"rtd\">\r\n");
	 aspxrewriteurl = GetTradeShippingTypes(dl["shipping_type"].ToString());
	
	templateBuilder.Append("            " + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("    <td  class=\"ltd\">付款时间:</td>\r\n");
	templateBuilder.Append("    <td  class=\"rtd\">\r\n");
	 aspxrewriteurl = FormatDateTime(dl["pay_time"]);
	
	templateBuilder.Append("" + aspxrewriteurl.ToString() + "</td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td  class=\"ltd\">物流公司:</td>\r\n");
	templateBuilder.Append("    <td  class=\"rtd\">&nbsp;</td>\r\n");
	templateBuilder.Append("    <td  class=\"ltd\">运单号:</td>\r\n");
	templateBuilder.Append("    <td  class=\"rtd\">&nbsp;</td>\r\n");
	templateBuilder.Append("    <td  class=\"ltd\">确认时间:</td>\r\n");
	templateBuilder.Append("    <td  class=\"rtd\">\r\n");
	 aspxrewriteurl = FormatDateTime(dl["end_time"]);
	
	templateBuilder.Append("" + aspxrewriteurl.ToString() + "\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td  class=\"ltd\">收货地址:</td>\r\n");
	templateBuilder.Append("    <td colspan=\"5\" class=\"rtd\">" + dl["receiver_name"].ToString().Trim() + "," + dl["receiver_state"].ToString().Trim() + "," + dl["receiver_city"].ToString().Trim() + "," + dl["receiver_district"].ToString().Trim() + "," + dl["receiver_zip"].ToString().Trim() + "<br>\r\n");
	templateBuilder.Append("    " + dl["receiver_address"].ToString().Trim() + ",手机:" + dl["receiver_mobile"].ToString().Trim() + ",电话号码:" + dl["receiver_phone"].ToString().Trim() + ",Email:" + dl["buyer_email"].ToString().Trim() + "\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td  class=\"ltd\">买家留言:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\">" + dl["buyer_memo"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">买家平价:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\">\r\n");

	if (Convert.ToBoolean(dl["buyer_rate"])==true)
	{

	templateBuilder.Append("            是\r\n");

	}
	else
	{

	templateBuilder.Append("            否\r\n");

	}	//end if

	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td  class=\"ltd\">买家备注:</td>\r\n");
	templateBuilder.Append("    <td  class=\"rtd\">\r\n");
	templateBuilder.Append("    <img src=\"/images/op/op_memo_" + dl["buyer_flag"].ToString().Trim() + ".png\" />\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td  class=\"ltd\">卖家留言:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\">" + dl["seller_memo"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">卖家平价:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\">\r\n");

	if (Convert.ToBoolean(dl["seller_rate"])==true)
	{

	templateBuilder.Append("            是\r\n");

	}
	else
	{

	templateBuilder.Append("            否\r\n");

	}	//end if

	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("    <td  class=\"ltd\">卖家备注:</td>\r\n");
	templateBuilder.Append("    <td  class=\"rtd\">\r\n");
	templateBuilder.Append("    <img src=\"/images/op/op_memo_" + dl["seller_flag"].ToString().Trim() + ".png\" />\r\n");
	templateBuilder.Append("    </td>\r\n");
	templateBuilder.Append("  </tr>\r\n");
	templateBuilder.Append("  <tr>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">发票抬头:</td>\r\n");
	templateBuilder.Append("    <td class=\"rtd\">" + dl["invoice_name"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    <td class=\"ltd\">促销信息:</td>\r\n");
	templateBuilder.Append("    <td colspan=\"3\" class=\"rtd\">" + dl["promotion"].ToString().Trim() + "</td>\r\n");
	templateBuilder.Append("    </tr>\r\n");
	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("        addTableListener(document.getElementById(\"order_box_" + dl__loop__id.ToString() + "\"),0,0);\r\n");
	templateBuilder.Append("		</" + "script>\r\n");

	}	//end if



	templateBuilder.Append("          </div>\r\n");
	templateBuilder.Append("          </td>\r\n");
	templateBuilder.Append("          </tr>\r\n");

	}	//end loop

	templateBuilder.Append("		  </tbody>\r\n");
	templateBuilder.Append("		  <tfoot>\r\n");
	templateBuilder.Append("          <tr>\r\n");
	templateBuilder.Append("            <td colspan=\"11\">" + PageBarHTML.ToString() + "</td>\r\n");
	templateBuilder.Append("          </tr>\r\n");
	templateBuilder.Append("          </tfoot>\r\n");

	}	//end if

	templateBuilder.Append("        </table>\r\n");
	templateBuilder.Append("</div>\r\n");
	templateBuilder.Append("</form>        \r\n");
	templateBuilder.Append("<script language=\"javascript\" type=\"text/javascript\">\r\n");
	templateBuilder.Append("var tf = new TableFixed(\"tBox\");\r\n");
	templateBuilder.Append("tf.Clone();\r\n");
	templateBuilder.Append("var M_Trade = new TM_Trade();\r\n");
	templateBuilder.Append("M_Trade.MConfigID = " + M_Config.m_ConfigInfoID.ToString().Trim() + ";\r\n");
	templateBuilder.Append("M_Trade.ini();\r\n");
	templateBuilder.Append("function HidBox()\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	M_Trade.HidUserBox();\r\n");
	templateBuilder.Append("	location = location;\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("function Close_ReCallMsg(msg)\r\n");
	templateBuilder.Append("{\r\n");
	templateBuilder.Append("	if(msg)\r\n");
	templateBuilder.Append("	{\r\n");
	templateBuilder.Append("		M_Trade.Close(msg);\r\n");
	templateBuilder.Append("		M_Trade.HidUserBox();\r\n");
	templateBuilder.Append("	}\r\n");
	templateBuilder.Append("}\r\n");
	templateBuilder.Append("addTableListener(document.getElementById(\"tBoxs\"),0,0);\r\n");
	templateBuilder.Append("</" + "script>\r\n");

	}	//end if

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



	Response.Write(templateBuilder.ToString());
}
</script>
