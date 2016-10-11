/**
 * cxty@qq.com
 */

var OrderField = null;
var OrderListDataJsonStr = null;

function TOrderDO()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
	this.OrderListLoop = null;
	this.rowID = 0;
	this.OrderType = 0;
	this.OrderID = 0;
	this.OrderFieldJson = null;
	this.OrderListDataJson = null;
	this.ShowEdit = false;
	this.MoneyDecimal = 2;//默认保留2位小数
	this.QuantityDecimal = 2;//默认保留2位小数
	this.PriceClassID = 0;//客户价格类型
	this.StoresID = 0;//客户编号
	this.Steps = 0;//单据流程
	this.ShowPrice = false;//是否显示价格
	this.tBoxsbIsSHow = false;//凭证列表是否显示中
	this.IsLoaded = false;//列表是否加载完成
	this.OnlyStorage = true;//是否列表中仅有一个仓库信息
	this.ListCount = 0;//列表条数
	this.UserCode = '';//多浏览器打印用

	this.EditDefaultPrice = false;//是否可以修改默认价格
	
	this.PrinterName = '';//默认打印机名称
	this.PrintPageWidth = '';//打印单据宽度
	this.PrintPageHeight = 0;//打印单据高度
	this.PrintAddPageWidth = '';//打印随附单据宽度
	this.Order_lock = 0;//是否锁定单据操作
	
	this.tID = -1;//当前选中行编号,买赠用
	this.sID = -1;//当前选中行编号,修改用
	
	this.IsMOrder = false;//是否为网购单
	this.ExpID = 0;//物流
	this.mExpNO = '';//物流运单号
	this.m_configid = '';//网购配置信息编号
	
	this.IsEditAct = false;//是否有更新
	
	this.ProductArray = new Array();
	
	this.sel_StorageID = 0;//选中仓库编号,暂存
	this.sel_StorageIDB = 0;//选中仓库编号,暂存
	
	//iPad,iPhone用
	this.old_y=0;
	this.yn=0;
	
	if(document.all)
	{
		this.dw = $(document).width()-20;
		this.dh = $(window).height()-80;
	}
	else
	{
		this.dw = document.body.clientWidth-20+'px';
		this.dh = $(window).height()-80+'px';
	}
	
	//{"OrderListJson":[{"OrderListID":0,"OrderID":0,"StorageID":0,"ProductsID":0,"oQuantity":0,"oPrice":0,"oMoney":0,"StoresSupplierID":0,"IsPromotions":0,"oWorkType":0,"oAppendTime":"\/Date(1289206775426+0800)\/","OrderFieldValueInfo":[{"OrderFieldValueID":0,"OrderFieldID":0,"OrderListID":0,"oFieldValue":null,"IsVerify":0,"oAppendTime":"\/Date(1289206775426+0800)\/"}]}]} 
}
TOrderDO.prototype.ini = function()
{

	getLodop(document.getElementById('LODOP'), document.getElementById('LODOP_EM'));
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
	this.OrderListLoop = $('#OrderListLoop');
	this.PrintPageHeight = (400+60);//头+尾，毫米乘以10
	$('#tBoxsb').hide();
	if (OrderField) {
		this.OrderFieldJson = jQuery.parseJSON(OrderField);
	}
	if(OrderListDataJsonStr)
	{
		this.OrderListDataJson = jQuery.parseJSON(OrderListDataJsonStr);
	}
	
	//新建
	$('#subbutton_add').click(function(){
		var StoresSupplierID = 0;
		var tMsg = '';
		var IsCheck = false;
		var CheckStaff = false;
		var CheckStaffed = false;
		var StaffID = 0;
		switch(OrderDO.OrderType)
		{
			case 1:case 2:
				StoresSupplierID = $('#SupplierID').val();
				tMsg = '供货商';
				IsCheck = true;
				CheckStaffed = true;
			break;
			case 3:case 4:case 5:case 6:case 7:case 11:
				StoresSupplierID = $('#StoresID').val();
				tMsg = '客户';
				StaffID = $('#StaffID').val();
				IsCheck = true;
				CheckStaff = true;
			break;
			case 9:
				StoresSupplierID = $('#StorageID').val();
				tMsg = '仓库';
				IsCheck = true;
				CheckStaffed = true;
			break;
		}

		var redata = '';
		if(IsCheck){
			if(CheckStaff){
				if (Number(StaffID) > 0) {
					CheckStaffed = true;
				}else{
					CheckStaffed = false;
					jAlert('请选择 业务员 !','提示');
					$('#StaffName').val('');
					$('#StaffName').focus();
				}
			}
			if(CheckStaffed){
				if (Number(StoresSupplierID) > 0) {
					$('#StoresSupplierID').val(StoresSupplierID);
					redata = OrderDO.GetDataListToJson();
				}
				else
				{
					jAlert('请选择'+tMsg+'!','提示');
					$('#SupplierName').val('');
					$('#SupplierName').focus();
				}
			}
		}
		else
		{
			redata = OrderDO.GetDataListToJson();
		}

		if (redata) {
			$('#OrderListDataJson').val(redata);
			$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
			$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
				$(this).show();
				$('#bForm').submit();
			});
		}
		
		StoresSupplierID = null;
		tMsg = null;
		redata = null;
	});
	//更新
	$('#subbutton_update').click(function(){
		jConfirm('是否 <b>更新并保存</b> 当前单据?','提示',function(r){
			if(r)
			{
				var StoresSupplierID = 0;
				var tMsg = '';
				var IsCheck = false;
				switch(OrderDO.OrderType)
				{
					case 1:case 2:
						StoresSupplierID = $('#SupplierID').val();
						tMsg = '供货商';
						IsCheck = true;
					break;
					case 3:case 4:case 5:case 6:case 7:case 11:
						StoresSupplierID = $('#StoresID').val();
						tMsg = '客户';
						IsCheck = true;
					break;
					case 9:
						StoresSupplierID = $('#StorageID').val();
						tMsg = '仓库';
						IsCheck = true;
					break;
				}
				var redata = '';
				if(IsCheck){
					if (Number(StoresSupplierID) > 0) {
						$('#StoresSupplierID').val(StoresSupplierID);
						redata = OrderDO.GetDataListToJson();
					}
					else
					{
						jAlert('请选择'+tMsg+'!','提示');
						$('#SupplierName').val('');
						$('#SupplierName').focus();
					}
				}
				else
				{
					redata = OrderDO.GetDataListToJson();
				}
		
				if (redata) {
					$('#OrderListDataJson').val(redata);
					//$('#bForm').arrt('action','/orderlist_do_e-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx');
					$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
					$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
						$(this).show();
						$('#bForm').submit();
					});
				}
				StoresSupplierID = null;
				tMsg = null;
				redata = null;
			}
		});
		
	});
	//审核
	$('#subbutton_verify').click(function(){
		if (!OrderDO.IsEditAct) {
			if (OrderDO.IsLoaded) {//列表是否加载完成
				jConfirm('是否确认 <b>审核</b> 操作?<br>提示:该操作不可逆,确认后将进入发货环节!', '提示', function(r){
					if (r) {
						if (OrderDO.GetDataListToJson()) {
							$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
							$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
								$.getJSON('/orderlist_do_s-' + OrderDO.OrderType + '-' + OrderDO.OrderID + '.aspx?format=json', function(data){
									if (data.results.state == 'True') {
										if(data.NextOrderID){
											jConfirm(data.results.msg+' \n 是否继续 审核 同类型的单据?','提示',function(r){
												if(r){
													location.href = '/orderlist_do_v-' + OrderDO.OrderType + '-' + data.NextOrderID + '.aspx';
												}else{
													location.href = '/orderlist_do_v-' + OrderDO.OrderType + '-' + OrderDO.OrderID + '.aspx';
												}
												
											});
										}else{
											jAlert(data.results.msg, '提示', function(){
												location.href = '/orderlist_do_v-' + OrderDO.OrderType + '-' + OrderDO.OrderID + '.aspx';
											});
										}
										
									}
									else {
										jAlert(data.results.msg, '提示',function(){
											location.href = '/orderlist_do_v-' + OrderDO.OrderType + '-' + OrderDO.OrderID + '.aspx';
										});
									}
								});
							});
						}
					}
				});
			}
			else {
				jAlert('请等待列表加载完毕再操作.谢谢!', '提示');
			}
		}else{
			jAlert('列表有修改,请先保存!', '提示');
		}
	});
	//发货
	$('#subbutton_delivery').click(function(){
		jConfirm('是否确认 <b>发货</b> 操作?<br>提示:该操作不可逆,确认后将进入收货环节!','提示',function(r){
			if(r)
			{
				var _MS = '';
				if(OrderDO.IsMOrder)
				{
					_MS = '&ExpID='+OrderDO.ExpID+'&ExpNO='+OrderDO.mExpNO;
				}
				$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
				$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
					$.getJSON('/orderlist_do_d-' + OrderDO.OrderType + '-' + OrderDO.OrderID + '.aspx?format=json'+_MS+'', function(data){
						if (data.results.state=='True') {
							jAlert(data.results.msg,'提示',function(){
								location.href = '/orderlist_do_v-' + OrderDO.OrderType + '-' + OrderDO.OrderID + '.aspx';
							});
						}
						else {
							jAlert(data.results.msg,'提示',function(){
								if(data.MS_Order)
								{
									if (!data.MS_Order.Exp) {
										dialog("填写物流信息", 'iframe:/msendgoods_exp.aspx?mconfigid=' + OrderDO.m_configid, "400px", "200px", "iframe");
									}
								}
							});
						}
					});
				});
			}
		});
	});
	//收货
	$('#subbutton_receiving').click(function(){
		$.getJSON('/Services/CAjax.aspx?format=json&do=CheckStorageProductLogCutLen&OrderID='+OrderDO.OrderID,function(data){
			if(data){
				var _alert = data.CutLen != 0? '该单据还有商品为完成收发货数量为<b>'+data.CutLen+'</b><br>':'';
				
				jConfirm('是否确认 <b>收货</b> 操作?<br>提示:'+_alert+'该操作不可逆,确认后将进入核销环节!','提示',function(r){
					if(r)
					{
						$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
						$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
							$.getJSON('/orderlist_do_r-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx?format=json',function(data){
								if(data.results.state)
								{
									jAlert(data.results.msg,'提示',function(){
										location.href = '/orderlist_do_v-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx';
									});
								}
								else
								{
									jAlert(data.results.msg,'提示');
								}
							});
						});
					}
				});
				
				
			}
		});
		
		
	});
	//核销
	$('#subbutton_verification').click(function(){
		jConfirm('是否确认 <b>收货</b> 操作?<br>提示:该操作不可逆,确认后将进入对账环节!','提示',function(r){
			if(r)
			{
				$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
				$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
					$.getJSON('/orderlist_do_vv-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx?format=json',function(data){
						if(data.results.state)
						{
							if(data.NextOrderID){
								jConfirm(data.results.msg+' \n 是否继续 核销 同类型的单据?','提示',function(r){
									if(r){
										location.href = '/orderlist_do_v-' + OrderDO.OrderType + '-' + data.NextOrderID + '.aspx';
									}else{
										location.href = '/orderlist_do_v-' + OrderDO.OrderType + '-' + OrderDO.OrderID + '.aspx';
									}
								});
							}else{
								jAlert(data.results.msg, '提示', function(){
									location.href = '/orderlist_do_v-' + OrderDO.OrderType + '-' + OrderDO.OrderID + '.aspx';
								});
							}
							/*
							jAlert(data.results.msg,'提示',function(){
								location.href = '/orderlist_do_v-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx';
							});
							*/
						}
						else
						{
							jAlert(data.results.msg,'提示');
						}
					});
				});
			}
		});
	});
	//打印
	$('#subbutton_print').click(function(){

		jConfirmYesNo('是否打印金额?<br>提示:每次打印系统都将留下打印记录!','提示',function(r){
			if (r) 
			{
				var ShowMoney = '';
				if (r=='no') {
					ShowMoney = '&ShowMoney=false';
				}
				var LODOP;
				try {
					LODOP = getLodop(document.getElementById('LODOP'), document.getElementById('LODOP_EM'));
					try {
						LODOP.PRINT_INIT("单据打印");
						LODOP.SET_PRINT_STYLE("FontSize", 12);
						LODOP.ADD_PRINT_URL(0, 0, "100%", "100%", '/orderprint-' + OrderDO.OrderType + '-' + OrderDO.OrderID + '.aspx?UserCode=' + OrderDO.UserCode + ShowMoney);
						
						var _printerName = LODOP.GET_PRINTER_NAME(-1);
						if(_printerName)
						{
							if(_printerName.indexOf(OrderDO.PrinterName)>-1){
								if(OrderDO.ListCount < 14){
									LODOP.SET_PRINT_PAGESIZE(3, OrderDO.PrintPageWidth, 0, "");
								}else{
									LODOP.SET_PRINT_PAGESIZE(3, OrderDO.PrintPageWidth, OrderDO.PrintPageHeight+OrderDO.ListCount*20, "");
								}
							}
						}
						
						LODOP.PREVIEW();
					}
					catch (e) {
						//jAlert('请安装打印控件![' + e + ']');
					}
					
					return false;
				} 
				catch (e) {
					window.open('', "top");
					setTimeout(window.open('/orderprint-' + OrderDO.OrderType + '-' + OrderDO.OrderID + '.aspx?UserCode=' + OrderDO.UserCode + ShowMoney, "top"), 100);
					return false;
				}
			}
		});
	});
	//打印订单
	$('#subbutton_print_t').click(function(){
		jConfirmYesNo('是否打印金额?<br>提示:每次打印系统都将留下打印记录!','提示',function(r){
			if (r) 
			{
				var ShowMoney = '';
				if (r=='no') {
					ShowMoney = '&ShowMoney=false';
				}

				var LODOP;
				try{
					LODOP=getLodop(document.getElementById('LODOP'),document.getElementById('LODOP_EM'));
					try {
						LODOP.PRINT_INIT("单据打印");
						LODOP.SET_PRINT_STYLE("FontSize",12);
	
						LODOP.ADD_PRINT_URL(0, 0, "100%", "100%",'/orderprint-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'-d.aspx?UserCode='+OrderDO.UserCode+ShowMoney);
						
						
						var _printerName = LODOP.GET_PRINTER_NAME(-1);
						
						if(_printerName)
						{
							if(_printerName.indexOf(OrderDO.PrinterName)>-1){
								if(OrderDO.ListCount < 14){
									LODOP.SET_PRINT_PAGESIZE(3, OrderDO.PrintPageWidth, 0, "");
								}else{
									LODOP.SET_PRINT_PAGESIZE(3, OrderDO.PrintPageWidth, OrderDO.PrintPageHeight+OrderDO.ListCount*20, "");
								}
							}
						}
						
						LODOP.PREVIEW();
	
					}catch(e){
						//jAlert('请安装打印控件![' + e + ']');		
					}
					
					return false;
				 }catch(e){
						window.open('', "top"); 
						setTimeout(window.open('/orderprint-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'-d.aspx?UserCode='+OrderDO.UserCode+ShowMoney, "top"), 100); 
						return false;
				 }
		 	}
		});
	});
	//打印网购运单
	$('#subbutton_print_exp').click(function(){
		window.open('', "top"); 
		setTimeout(window.open('/mexpress_print-'+OrderDO.m_configid+'-'+OrderDO.OrderID+'.aspx?UserCode='+OrderDO.UserCode, "top"), 100); 
		return false;
	});
	//打印随附单
	$('#subbutton_print_add').click(function(){
		jConfirm('是否确认打印随附单?<br>提示:每次打印系统都将留下打印记录!','提示',function(r){
			if (r) 
			{
				var LODOP;
				try{
					LODOP=getLodop(document.getElementById('LODOP'),document.getElementById('LODOP_EM'));
					try {
						LODOP.PRINT_INIT("单据打印");
						
						if(OrderDO.ListCount < 14){
						LODOP.SET_PRINT_PAGESIZE(3, OrderDO.PrintAddPageWidth, "0", "");
						}
						
						
						LODOP.SET_PRINT_STYLE("FontSize",12);
	
						LODOP.ADD_PRINT_URL(0, 0, "100%", "100%",'/orderprint_add-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx?UserCode='+OrderDO.UserCode);
						LODOP.PREVIEW();
	
					}catch(e){
						jAlert('请安装打印控件![' + e + ']');		
					}
					
					return false;
				 }catch(e){
						window.open('', "top"); 
						setTimeout(window.open('/orderprint_add-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx?UserCode='+OrderDO.UserCode, "top"), 100); 
						return false;
				 }
				 
				
			}
		});
	});
	//作废
	$('#subbutton_invalid').click(function(){
		jConfirm('是否确认 <b>作废</b> 操作?<br>提示:该操作不可逆,作废后的单据无法恢复!','提示',function(r){
			if(r)
			{
				$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
				$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
					$.getJSON('/orderlist_do_i-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx?format=json',function(data){
						if(data.results.state)
						{
							jAlert(data.results.msg,'提示',function(){
								location.href = '/orderlist_do_v-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx';
							});
						}
						else
						{
							jAlert(data.results.msg);
						}
					});
				});
			}
		});
	});
	//查看原始单据
	$('#subbutton_first').click(function(){
		location.href = '/orderlist_do_v_f-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx';
	});
	//查看单据操作记录
	$('#subbutton_log').click(function(){
		dialog("查看单据操作记录",'iframe:/orderworkinglog-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx',"500px","400px","iframe");
	});
	//返回
	$('#subbutton_return').click(function(){
		location.href = '/orderlist_do_v-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx';
	});
	//处理非全额收货
	$('#subbutton_isnofull').click(function(){
		dialog("处理非全额收货单据",'iframe:/orderlist_do_nofull-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx',"600px","420px","iframe");
	});
	//差额转新单
	$('#subbutton_isnofullandnotodo').click(function(){
		dialog("差额转新单处理,选择新单据类型",'iframe:/orderlist_do_nofull_do-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'-Do.aspx',"600px","420px","iframe");
	});
	//差额无需转新单
	$('#subbutton_isnofullandnotodo_no').click(function(){
		dialog("差额无需转新单处理",'iframe:/orderlist_do_nofull_do-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'-NODo.aspx',"300px","250px","iframe");
	});
	//预付款操作
	$('#subbutton_prepay').click(function(){
		dialog("预付款处理",'iframe:/certificate_do_box-'+OrderDO.OrderType+'-'+OrderDO.OrderID+'.aspx',OrderDO.dw,OrderDO.dh,"iframe");
	});
	//显示关闭随附凭证列表
	$('#CertificateList_tool').click(function(){
		OrderDO.SHCertificateList();
	});
	//iPad,iPhone增强
	if ((navigator.userAgent.match(/iPhone/i)) || (navigator.userAgent.match(/iPad/i)) || (navigator.userAgent.match(/Android/i))) {
		$('#tTree').before('<div>' +
		'<span id="tree_up"><img src="/images/up.gif" />向上滚动</span>' +
		'<span id="tree_down"><img src="/images/down.gif" />向下滚动</span>' +
		'</div>');
		$('#tree_up').click(function(){
			$('#tTree').scrollTop($('#tTree').scrollTop() - 10);
		});
		$('#tree_down').click(function(){
			$('#tTree').scrollTop($('#tTree').scrollTop() + 10);
		});
		$('#tTree').mousedown(function(event){
		OrderDO.old_y=event.clientY+this.scrollTop;
		OrderDO.yn=1;
		});
		$('#tTree').mousemove(function(event){
			if (OrderDO.yn == 1 ) {
				this.scrollTop = (OrderDO.old_y - event.clientY);
			}
		});
		$('#tTree').mouseup(function(){OrderDO.yn=0;});
	}
	
}
//显示隐藏凭证列表
TOrderDO.prototype.SHCertificateList = function()
{
	if (this.tBoxsbIsSHow) {
			$('#tBoxsb').hide();
			this.tBoxsbIsSHow = false;
		}else{
			$('#tBoxsb').show();
			this.tBoxsbIsSHow = true;
		}
}
//整理并返回列表内数据
TOrderDO.prototype.GetDataListToJson = function()
{
	var tr = $('#OrderListLoop_data').children('tbody').children('tr');
	var tOrderListJson = '';
	var tOrderFieldValueInfo = '';
	var tOrderField = '';
	var tId = '';
	this.OnlyStorage = true;
	if (tr.length > 0) {
		for (var i = 0; i < tr.length; i++) {
			if ($(tr[i]).attr('pid')>0) {
				if ($(tr[i]).attr('storageid') > 0) {
					tId = $(tr[i]).attr('id').replace('tr_', '');
					if(this.GetProductAllQuantity(Number($(tr[i]).attr('storageid')),Number($(tr[i]).attr('pid')),Number($('#oQuantity_' + tId).val()))<= Number($('#oQuantity_' + tId).attr('good')) || (',2,3,5,6,7,9,10,11,'.indexOf(',' + this.OrderType + ',') == -1)){
						if ((Number($('#oQuantity_' + tId).val()) <= Number($('#oQuantity_' + tId).attr('good'))) || (',2,3,5,6,7,9,10,11,'.indexOf(',' + this.OrderType + ',') == -1) || this.Steps == 3) {
						
							if (Number($('#oQuantity_' + tId).val()) != 0 || this.ShowEdit == true) {
								//提取自定义字段值
								tOrderField = $(tr[i]).children('td').children('.OrderField');
								tOrderFieldValueInfo = '';
								if (tOrderField) {
									for (var j = 0; j < tOrderField.length; j++) {
										tOrderFieldValueInfo += '{"OrderFieldValueID":' + $(tOrderField[j]).attr('OrderFieldValueID') + ',"OrderFieldID":' + $(tOrderField[j]).attr('OrderFieldID') + ',"OrderListID":' + $(tOrderField[j]).attr('OrderListID') + ',"oFieldValue":"' + $(tOrderField[j]).val() + '","IsVerify":0,"oAppendTime":"\/Date(1289206775426+0800)\/"},';
									}
									if (tOrderFieldValueInfo != '') {
										tOrderFieldValueInfo = ',"OrderFieldValueInfo":[' + tOrderFieldValueInfo.substring(0, tOrderFieldValueInfo.length - 1) + ']';
									}
								}
								var _PriceClassID = $(tr[i]).attr('PriceClassID');
								if (Number(_PriceClassID)) {
									_PriceClassID = Number(_PriceClassID);
								}
								else {
									_PriceClassID = 0;
								}
								if (this.OrderType != 9) {
									
									//判断是否有不同的仓库出现
									if (i > 0) {
										if ($(tr[i-1]).attr('StorageID')!=$(tr[i]).attr('StorageID')) {
											this.OnlyStorage = false;
										}
									}
									if (this.OnlyStorage) {
										tOrderListJson += '{"OrderListID":' + $(tr[i]).attr('OrderListID') + ',"OrderID":' + $(tr[i]).attr('OrderID') + ',"StorageID":' + $(tr[i]).attr('StorageID') + ',' +
										'"ProductsID":' +
										$(tr[i]).attr('pid') +
										',' +
										'"oQuantity":' +
										$('#oQuantity_' + tId).val() +
										',' +
										'"oPrice":' +
										$('#Price_' + tId).val() +
										',' +
										'"oMoney":' +
										Number($('#oQuantity_' + tId).val()) * Number($('#Price_' + tId).val()) +
										',' +
										'"StoresSupplierID":' +
										$('#StoresSupplierID').val() +
										',' +
										'"IsPromotions":0,"oWorkType":0,"IsGifts":' +
										$(tr[i]).attr('IsGifts') +
										',"PriceClassID":"' +
										_PriceClassID +
										'"' +
										',"oAppendTime":"\/Date(1289206775426+0800)\/"' +
										tOrderFieldValueInfo +
										'},';
									}else{
										jAlert('列表中只允许一个仓库.', '提示');
										return false;
									}
								}
								else {
									if (Number($(tr[i]).attr('StorageID')) != Number($(tr[i]).attr('StorageIDB'))) {
										//判断是否有不同的仓库出现
										if (i > 0) {
											if ($(tr[i-1]).attr('StorageID')!=$(tr[i]).attr('StorageID') || $(tr[i-1]).attr('StorageIDB')!=$(tr[i]).attr('StorageIDB')) {
												this.OnlyStorage = false;
											}
										}
										if (this.OnlyStorage) {
											tOrderListJson += '{"OrderListID":' + $(tr[i]).attr('OrderListID') + ',"OrderID":' + $(tr[i]).attr('OrderID') + ',"StorageID":' + $(tr[i]).attr('StorageID') + ',' +
											'"ProductsID":' +
											$(tr[i]).attr('pid') +
											',' +
											'"oQuantity":' +
											(0 - Number($('#oQuantity_' + tId).val())) +
											',' +
											'"oPrice":' +
											$('#Price_' + tId).val() +
											',' +
											'"oMoney":' +
											Number($('#oQuantity_' + tId).val()) * Number($('#Price_' + tId).val()) +
											',' +
											'"StoresSupplierID":' +
											$('#StoresSupplierID').val() +
											',' +
											'"IsPromotions":0,"oWorkType":0,"IsGifts":0,' +
											'"PriceClassID":"' +
											_PriceClassID +
											'"' +
											',"oAppendTime":"\/Date(1289206775426+0800)\/"' +
											tOrderFieldValueInfo +
											'},';
											
											tOrderListJson += '{"OrderListID":' + $(tr[i]).attr('OrderListIDB') + ',"OrderID":' + $(tr[i]).attr('OrderID') + ',"StorageID":' + $(tr[i]).attr('StorageIDB') + ',' +
											'"ProductsID":' +
											$(tr[i]).attr('pid') +
											',' +
											'"oQuantity":' +
											$('#oQuantity_' + tId).val() +
											',' +
											'"oPrice":' +
											$('#Price_' + tId).val() +
											',' +
											'"oMoney":' +
											Number($('#oQuantity_' + tId).val()) * Number($('#Price_' + tId).val()) +
											',' +
											'"StoresSupplierID":' +
											$('#StoresSupplierID').val() +
											',' +
											'"IsPromotions":0,"oWorkType":0,"IsGifts":0,' +
											'"PriceClassID":"' +
											_PriceClassID +
											'"' +
											',"oAppendTime":"\/Date(1289206775426+0800)\/"' +
											tOrderFieldValueInfo +
											'},';
										}else{
											jAlert('列表中来源与目标各只允许一个仓库.', '提示');
											return false;
										}
									}else{
										jAlert('仓库信息有错,无法更新,请刷新当前页面! <b>0</b> ', '提示');
										return false;
									}
								}
							}
							else {
								jAlert('商品数量不能为 <b>0</b> ', '提示');
								$('#oQuantity_' + tId).focus();
								return false;
							}
						}else{
							jAlert('<b>' + $('#pname_' + tId).text() + '</b> 单据总数不能超过可开单数量,可开单数量为:<b>' + $('#oQuantity_' + tId).attr('good') + '</b>', '提示');
							$('#oQuantity_' + tId).val(0);
							$('#oQuantity_' + tId).focus();
							return false;
						}
					}
					else {
						jAlert('<b>' + $('#pname_' + tId).text() + '</b> 不能超过可开单数量,可开单数量为:<b>' + $('#oQuantity_' + tId).attr('good') + '</b>', '提示');
						$('#oQuantity_' + tId).val(0);
						$('#oQuantity_' + tId).focus();
						return false;
					}
				}else{
					jAlert('商品仓库错误,请刷新页面,或更新仓库信息! ','提示');
					return false;
					break;
				}
			}else{
				jAlert('商品编号错误,请刷新页面! ','提示');
				return false;
				break;
			}
		}
		if (tOrderListJson != '') {
			tOrderListJson = '{"OrderListJson":['+ tOrderListJson.substring(0, tOrderListJson.length - 1)+']}';
		}
		else
		{
			return false;
		}
		
	}else{
		jAlert('单据列表中没有任何数据,请选择商品!','提示');
	}
	return tOrderListJson;
}
TOrderDO.prototype.HidUserBox = function()
{
	CloseBox();
	//location=location;
}
TOrderDO.prototype.Delt = function(tid)
{
	//是否删除非赠品
	if (Number($('#tr_' + tid).attr('IsGifts')) == 0) {
		//判断是否有赠品
		var tTr = $('#OrderListLoop_data').children('tbody').children('tr[IsGifts="' + $('#tr_' + tid).attr('pid') + '"]');
		if (tTr.length > 0) {
			jAlert('本商品下有附属赠品,无法删除!', '提示');
		}
		else {
			$('#tr_' + tid).remove();
			OrderDO.SumT();
		}
	}else{
		$('#tr_' + tid).remove();
		OrderDO.SumT();
	}
}
//买赠按钮
TOrderDO.prototype.AddZP = function(tid)
{
	if ($('#tr_' + tid)) {
		this.tID = tid;
		this.ShowProductTree(tid);
		//OrderDO.SumT();
	}
}
//产品基础信息数组
TOrderDO.prototype.AddProductToArray = function(re)
{
	if(re)
	{
		for (var p in this.ProductArray)
		{
			if(re.StorageInfo.id!=p.StorageInfo.id && re.ProductInfo.id!=p.ProductInfo.id)
			{
				this.ProductArray.push(re);
			}
		}
	}
}
//取列表中同仓库下的同商品数量
TOrderDO.prototype.GetProductAllQuantity = function(StorageID,ProductID,Quantity)
{
	var tr = $('#OrderListLoop_data').children('tbody').children('tr');
	var tId = '';
	var AllQuantity = 0;
	if (tr.length > 0) {
		for (var i = 0; i < tr.length; i++) {
			if ($(tr[i]).attr('pid') > 0) {
				if ($(tr[i]).attr('storageid') > 0) {
					tId = $(tr[i]).attr('id').replace('tr_', '');
					if(Number($(tr[i]).attr('pid'))==ProductID && Number($(tr[i]).attr('storageid'))==StorageID)
					{
						AllQuantity+=Number($('#oQuantity_' + tId).val());
					}
				}
			}
		}
	}
	return AllQuantity;
}
//产品选择框
TOrderDO.prototype.ShowProductTree = function(tid)
{
	this.PageBox=dialog("选择赠送商品","iframe:public_producttree.aspx?obj=tr_"+tid,450,this.dh,"iframe");
}
//产品选择回调
TOrderDO.prototype.SetProductID = function(reObj,treObj)
{
	if (reObj) {
		this.Add(reObj.id,treObj);
	}
}
//添加商品
TOrderDO.prototype.Add = function(pid,treObj)
{
	//是否选择了客户StoresID 或者 供应商SupplierID
	var _showbox = false;
	var _errMsg = '';
	switch (this.OrderType) {
		case 1:
		case 2:
			if(Number($('#SupplierID').val())>0){
				_showbox = true;
			}else{
				_showbox = false;
				_errMsg = '请选择供应商!';
				$('#SupplierName').focus();
			}
			break;
		case 3:case 4:case 5:case 6:case 7:case 11:
			if(Number($('#StoresID').val())>0){
				_showbox = true;
			}else{
				_showbox = false;
				_errMsg = '请选择客户!';
				$('#StoresName').focus();
			}
			break;
		case 9:
			if(Number($('#StorageID').val())>0){
				_showbox = true;
			}else{
				_showbox = false;
				_errMsg = '请选择仓库!';
				$('#StorageName').focus();
			}
			break;
		default:
			_showbox = true;
		break;
	}
	
	if (_showbox) {
		var tObj = treObj ? $('#' + treObj) : null;
		if (this.OrderListLoop) {
			pid = pid.replace('d_', '');
			if (!this.CheckProduct(pid, tObj)) {
				if (tObj) {
					this.PageBox = dialog("选择仓库", 'iframe:orderlist_dobox-' + this.OrderType + '-' + pid + '.aspx?tObj=' + tObj.attr('id'), "500px", "300px", "iframe");
				}
				else {
					this.PageBox = dialog("选择仓库", 'iframe:orderlist_dobox-' + this.OrderType + '-' + pid + '.aspx', "500px", "300px", "iframe");
				}
			}
			else {
				jAlert('列表中已存在该商品.', '提示');
			}
		}
	}else{
		jAlert(_errMsg, '提示');
	}
}
TOrderDO.prototype.AddBoxRe = function(re)
{
	if (re) {
		var _rid = 0;
		var tOrderField = '';
		var dt = $('#OrderListLoop_data');
		var newTR = null;
		var _dthtml = '';
		var _isnew = false;
		var tTr = null;//普通行
		var _tTr = null;//赠品行
		
		try{
			//this.AddProductToArray(re);
			//修改更新行操作
			if (this.sID!=-1) {
				_isnew = false;
				_rid = this.sID;
				tTr = $('#tr_'+_rid);
				_tTr = $('#tr_'+_rid);
			}
			else {
			
				//赠品附加
				if (re.ProductInfo.IsGifts > 0) {
					tTr = $(dt).children('tbody').children('tr[pid="' + re.ProductInfo.IsGifts + '"][IsGifts="0"]');
					if (tTr) {
						_tTr = $(tTr).find('tr[pid="' + re.ProductInfo.id + '"]');
						if (_tTr.length > 0) {
							_rid = $(_tTr).attr('id').replace('tr_', '');
						}
						else {
							_rid = this.rowID;
							_isnew = true;
						}
					}
					else {
						_rid = this.rowID;
						_isnew = true;
					}
				}
				else {
					if (this.OrderType != 9) {
						tTr = $(dt).children('tbody').children('tr[pid="' + re.ProductInfo.id + '"][IsGifts="0"]');
					}else{
						tTr = $(dt).children('tbody').children('tr[pid="' + re.ProductInfo.id + '"]');
					}
					try {
						if (tTr) {
							
							_rid = $(tTr).attr('id').replace('tr_', '');
							_isnew = false;
						}
						else {
							_rid = this.rowID;
							_isnew = true;
						}
					} 
					catch (e) {
						_rid = this.rowID;
						_isnew = true;
					}
				}
			}
			//自定义字段
			if(this.OrderFieldJson)
			{
				if(this.OrderFieldJson.OrderFieldList){
					var tfValue = '';
					var tStr = '';
					var tObjStr = '';
					for(var i=0;i<this.OrderFieldJson.OrderFieldList.length;i++)
					{
						tStr = this.OrderFieldJson.OrderFieldList[i].OrderField.fProductField;
						if (tStr) {
							//自定义字段,产品字段赋值
							for (var pro in re.ProductInfo) 
							{
								tObjStr = $.trim(pro);
								if ($.trim(tStr) == tObjStr) {
									tfValue = re.ProductInfo[tObjStr];
								}
							}
						}
						
						tOrderField+='<td width="80px"><input type="text" class="OrderField" OrderFieldValueID="0" OrderListID="0" ProductField="'+tStr+'" OrderFieldID="'+this.OrderFieldJson.OrderFieldList[i].OrderField.OrderFieldID+'" id="OrderField_' +
									_rid +'_'+this.OrderFieldJson.OrderFieldList[i].OrderField.OrderFieldID+
									'" name="OrderField_' +
									_rid +'_'+this.OrderFieldJson.OrderFieldList[i].OrderField.OrderFieldID+
									'" value="'+tfValue+'" title="'+tfValue+'" /></td>';
									
					}
					tObjStr = null;
					tStr = null;
					tfValue = null;
				}
			}
			
			//价格类型处理
			if(re.ProductInfo.PriceClassID)
			{
				re.ProductInfo.PriceClassID = Number(re.ProductInfo.PriceClassID);
			}else{
				re.ProductInfo.PriceClassID = 0;
			}
			
			if (this.OrderType != 9) {
				//设置默认仓库
				//this.sel_StorageID = re.StorageInfo.id;
				//有赠品附加
				if(re.ProductInfo.IsGifts>0){
					
					_dthtml = '<td width="80px" >'+re.StorageInfo.name+'</td><td width="100px">' +
					re.ProductInfo.Barcode +'</td>' +
					'<td id="pname_'+_rid+'"><a href="javascript:void(0);">&nbsp;&nbsp;(赠)' +re.ProductInfo.name +'</a></td><td width="30px">' +
					re.ProductInfo.ToBoxNo +'</td>' +
					'<td width="80px"><input type="text" style="width:40px" id="Price_' +_rid +'" name="Price_' +_rid +'" value="'+re.ProductInfo.Price+'" class="input_disabled" /></td>' +
					'<td width="80px"><nobr><input type="text" style="width:40px" MaxStock="'+re.ProductInfo.MS_Nums.m_Num+'" good="'+re.ProductInfo.Good+'" id="oQuantity_' +_rid +'" name="oQuantity_' +_rid +'" pToBoxNo="'+re.ProductInfo.ToBoxNo+'" oldvalue="'+re.ProductInfo.Quantity+'" value="'+re.ProductInfo.Quantity+'" />'+re.ProductInfo.pUnits+'</nobr></td>' +
					'<td width="80px" style="text-align:right;" id="sum_' +_rid +'">'+(this.ShowPrice?((Number(re.ProductInfo.Price)*Number(re.ProductInfo.Quantity))).toFixed(OrderDO.MoneyDecimal):'')+'</td>'+
					tOrderField+(this.ShowEdit?'<td width="50px" align="center"> <a href="javascript:void(0);" onclick="javascript:OrderDO.Delt('+_rid+')">删除</a></td>':'');
					
					if(!_isnew)
					{
						if (this.sID != -1) {//修改行操作
							_tTr.children().remove();
							_tTr.attr('StorageID',re.StorageInfo.id);
							jQuery(_dthtml).appendTo(_tTr);
						}
						else {
							jQuery(_dthtml).appendTo(_tTr);
						}
						newTR = tTr;
					}else{
						newTR = jQuery('<tr id="tr_' + _rid + '" OrderListID="0" OrderID="0" StorageID="'+re.StorageInfo.id+'" IsGifts="'+re.ProductInfo.IsGifts+'" PriceClassID="'+re.ProductInfo.PriceClassID+'" pid="' + re.ProductInfo.id + '" class="' + ((_rid % 2 != 0) ? 'trA' : 'trB') + '">' +
						_dthtml+'</tr>').insertAfter(tTr);
					
					}
					
				}else{
					var _showzp = false;//是否显示赠品按钮
					_showzp = (',1,2,3,4,'.indexOf(','+this.OrderType+',')>-1);
					_dthtml = '<td width="80px" >'+re.StorageInfo.name+'</td><td width="100px">' +
					re.ProductInfo.Barcode +'</td>' +
					'<td id="pname_'+_rid+'"><a href="javascript:void(0);">' +re.ProductInfo.name +'</a></td><td width="30px">' +
					re.ProductInfo.ToBoxNo +'</td>' +
					'<td width="80px"><input type="text" style="width:40px" id="Price_' +_rid +'" name="Price_' +_rid +'" value="'+re.ProductInfo.Price+'" '+((!this.ShowPrice)?'class="input_disabled"':'')+' /></td>' +
					'<td width="80px"><nobr><input type="text" style="width:40px" MaxStock="'+re.ProductInfo.MS_Nums.m_Num+'" good="'+re.ProductInfo.Good+'" id="oQuantity_' +_rid +'" name="oQuantity_' +_rid +'" pToBoxNo="'+re.ProductInfo.ToBoxNo+'" oldvalue="'+re.ProductInfo.Quantity+'" value="'+re.ProductInfo.Quantity+'" />'+re.ProductInfo.pUnits+'</nobr></td>' +
					'<td width="80px" style="text-align:right;" id="sum_' +_rid +'">'+(this.ShowPrice?((Number(re.ProductInfo.Price)*Number(re.ProductInfo.Quantity))).toFixed(OrderDO.MoneyDecimal):'')+'</td>'+
					tOrderField+(this.ShowEdit?'<td width="50px" align="center">'+((_showzp)?'<a href="javascript:void(0);" onclick="javascript:OrderDO.AddZP('+_rid+')">赠品</a>':'')+ '<a href="javascript:void(0);" onclick="javascript:OrderDO.Delt('+_rid+')">删除</a></td>':'');
					
					if(!_isnew)
					{
						if (this.sID != -1) {//修改行操作
							tTr.children().remove();
							tTr.attr('StorageID',re.StorageInfo.id);
							jQuery(_dthtml).appendTo(tTr);
						}
						else {
							jQuery(_dthtml).appendTo(tTr);
						}
						newTR = tTr;
					}else{
						
						newTR = jQuery('<tr id="tr_' + _rid + '" OrderListID="0" OrderID="0" StorageID="'+re.StorageInfo.id+'" IsGifts="0" PriceClassID="'+re.ProductInfo.PriceClassID+'" pid="' + re.ProductInfo.id + '" class="' + ((_rid % 2 != 0) ? 'trA' : 'trB') + '">' +
						_dthtml+'</tr>').appendTo(dt);
					
					}
					
				}
			}
			else
			{
				//查找是否有相同商品的
				if(!this.GetB(re))
				{
					_dthtml='<td width="100px" >来源:<span id="Storage_s_'+_rid+'">'+re.StorageInfo.name+'</span><br/>目标:<span id="Storage_t_'+_rid+'">'+re.StorageInfo.nameB+'</span></td><td width="100px">' +
					re.ProductInfo.Barcode +'</td>' +
					'<td>' +re.ProductInfo.name +'</td><td width="80px">' +
					re.ProductInfo.ToBoxNo +'</td>' +
					'<td width="80px"><input type="text" style="width:40px" id="Price_' +_rid +'" name="Price_' +_rid +'" value="'+re.ProductInfo.Price+'" /></td>' +
					'<td width="80px"><nobr><input type="text" style="width:40px" good="'+re.ProductInfo.Good+'" id="oQuantity_' +_rid +'" name="oQuantity_' +_rid +'" pToBoxNo="'+re.ProductInfo.ToBoxNo+'" oldvalue="'+re.ProductInfo.Quantity+'" value="'+re.ProductInfo.Quantity+'" />'+re.ProductInfo.pUnits+'</nobr></td>' +
					'<td width="80px" style="text-align:right;" id="sum_' +_rid +'">'+((Number(re.ProductInfo.Price)*Number(re.ProductInfo.Quantity))).toFixed(OrderDO.MoneyDecimal)+'</td>'+
					tOrderField+(this.ShowEdit?'<td width="50px" align="center"><a href="javascript:void(0);" onclick="javascript:OrderDO.Delt('+_rid+')">删除</a></td>':'');
					
					if (!_isnew) {
						jQuery(_dthtml).appendTo(tTr);
						newTR = tTr;
					}else{
						newTR = jQuery('<tr id="tr_' + _rid + '" OrderListID="0" OrderID="0" StorageID="'+re.StorageInfo.id+'" StorageIDB="'+re.StorageInfo.idB+'" pid="' + re.ProductInfo.id + '" class="' + ((_rid % 2 != 0) ? 'trA' : 'trB') + '">' +
						_dthtml+'</tr>').appendTo(dt);
					}
				}
				//this.sel_StorageID = re.StorageInfo.id;
				//this.sel_StorageIDB = re.StorageInfo.idB;
			}

			//重置时
			if (this.OrderListDataJson) {
				if (this.OrderListDataJson.OrderListJson) {
					if (re.ind!=undefined) {
						if (this.OrderType != 9) {
							$('#tr_' + _rid).attr('OrderListID', this.OrderListDataJson.OrderListJson[re.ind].OrderListID);
							$('#tr_' + _rid).attr('IsGifts', this.OrderListDataJson.OrderListJson[re.ind].IsGifts);
						}else{
							if (Number(this.OrderListDataJson.OrderListJson[re.ind].oQuantity) > 0) {
								$('#tr_' + _rid).attr('StorageIDB', this.OrderListDataJson.OrderListJson[re.ind].StorageID);
								$('#tr_' + _rid).attr('OrderListIDB', this.OrderListDataJson.OrderListJson[re.ind].OrderListID);
								$('#Storage_t_'+_rid).html(this.OrderListDataJson.OrderListJson[re.ind].StorageName);
							}
							else {
								$('#tr_' + _rid).attr('StorageID', this.OrderListDataJson.OrderListJson[re.ind].StorageID);
								$('#tr_' + _rid).attr('OrderListID', this.OrderListDataJson.OrderListJson[re.ind].OrderListID);
								$('#Storage_s_'+_rid).html(this.OrderListDataJson.OrderListJson[re.ind].StorageName);
							}
						}
						
						$('#tr_' + _rid).attr('OrderID',this.OrderListDataJson.OrderListJson[re.ind].OrderID);
						
						if (this.OrderListDataJson.OrderListJson[re.ind].OrderFieldValueInfo) {
							var _OrderFieldValueInfo = this.OrderListDataJson.OrderListJson[re.ind].OrderFieldValueInfo;
							for (var j = 0; j < _OrderFieldValueInfo.length; j++) {
								$('#OrderField_' + _rid + '_' + _OrderFieldValueInfo[j].OrderFieldID).attr('OrderFieldValueID',_OrderFieldValueInfo[j].OrderFieldValueID);
								$('#OrderField_' + _rid + '_' + _OrderFieldValueInfo[j].OrderFieldID).attr('OrderListID',_OrderFieldValueInfo[j].OrderListID);
								$('#OrderField_' + _rid + '_' + _OrderFieldValueInfo[j].OrderFieldID).val(_OrderFieldValueInfo[j].oFieldValue);
								$('#OrderField_' + _rid + '_' + _OrderFieldValueInfo[j].OrderFieldID).attr('title',_OrderFieldValueInfo[j].oFieldValue);
							}
							_OrderFieldValueInfo = null;
						}
						
					}
				}
			}
			
			if (this.ShowEdit) {
				//绑定自定义字段事件
				if (this.OrderFieldJson) {
					if (this.OrderFieldJson.OrderFieldList) {
						for (var k = 0; k < this.OrderFieldJson.OrderFieldList.length; k++) {
							switch (this.OrderFieldJson.OrderFieldList[k].OrderField.fType) {
								case 3:
								case "3":
									$('#OrderField_'+_rid +'_'+this.OrderFieldJson.OrderFieldList[k].OrderField.OrderFieldID).mask('9999-99-99');
									break;
								case 4:
								case "4":
									$('#OrderField_'+_rid +'_'+this.OrderFieldJson.OrderFieldList[k].OrderField.OrderFieldID).mask('99-99');
									break;
							}
							
						}
					}
				}
				
				//修改商品
				$('#pname_'+_rid).click(function(){
					var _p = $(this).parent();
					if(_p)
					{
						var isgifts = Number($(_p).attr('isgifts'));
						var pid = Number($(_p).attr('pid'));
						var sID = $(_p).attr('id');
						OrderDO.sID = Number(sID.replace('tr_',''));
	
						this.PageBox = dialog("选择仓库",'iframe:orderlist_dobox-'+OrderDO.OrderType+'-'+pid+'.aspx?tObj='+sID,"500px","300px","iframe"); 
						
					}
				});
				
				//可编辑状态
				//是否显示价格
				if (!this.ShowPrice) {
					$("#Price_" + _rid).attr('class', 'input_disabled');
					$('#sum_' + _rid).html('');
				}
				else {
				
					$("#Price_" + _rid).keyup(function(){
						OrderDO.IsEditAct = true;
						CheckNumber($(this));
						var tid = $(this).attr('id').replace('Price_', '');
						$('#sum_' + tid).html((Number($(this).val()) * Number($("#oQuantity_" + tid).val())).toFixed(OrderDO.MoneyDecimal));
						OrderDO.SumT();
					}).bind("paste", function(){
						OrderDO.IsEditAct = true;
						CheckNumber($(this));
						var tid = $(this).attr('id').replace('Price_', '');
						$('#sum_' + tid).html((Number($(this).val()) * Number($("#oQuantity_" + tid).val())).toFixed(OrderDO.MoneyDecimal));
						OrderDO.SumT();
					}).css("ime-mode", "disabled");
					
					$("#oQuantity_" + _rid).keyup(function(){
						if (Number($(this).attr('oldvalue')) != Number($(this).val())) {
							OrderDO.IsEditAct = true;
						}
						CheckNumber($(this));
						var _tid =  $(this).attr('id').replace('oQuantity_','');
						switch (OrderDO.OrderType) {
							case 1:
							case 4:
							case 8://增加库存操作不需要验证实际库存,入库,销售退货,调整
								break;
							case 2:
							case 3:
							case 5:
							case 6:
							case 7:
							case 10:
							case 11:
								//if (Number($(this).val()) > 0) {
									if (OrderDO.Steps == 3)//已发货,修改值可以小等于原值
									{
										if (Number($(this).attr('oldvalue')) < Number($(this).val())) {
											jAlert('<b>'+$('#pname_'+_tid).text()+'</b> 不能高于原数量:<b>' + $(this).attr('oldvalue')+'</b>','提示');
											$(this).val($(this).attr('oldvalue'));
										}
									}
									else {
										if (Number($(this).attr('good')) < Number($(this).val())) {
											jAlert('<b>'+$('#pname_'+_tid).text()+'</b> 不能超过可开单数量,可开单数量为:<b>' + $(this).attr('good')+'</b>','提示');
											$(this).val($(this).attr('good'));
										}else if (Number($(this).attr('MaxStock')) > -1) {
												if (Number($(this).attr('MaxStock')) < Number($(this).val())) {
													jAlert('<b>' + $('#pname_' + _tid).text() + '</b> 不能超过配额数量,可用配额数量为:<b>' + $(this).attr('MaxStock') + '</b>', '提示');
													$(this).val($(this).attr('MaxStock'));
												}
											
										}else{
											if (OrderDO.GetProductAllQuantity(Number($('#tr_'+_tid).attr('storageid')), Number($('#tr_'+_tid).attr('pid')), Number($(this).val())) > Number($(this).attr('good'))) {
												jAlert('<b>'+$('#pname_'+_tid).text()+'</b> 单据列表内总数不能超过可开单数量,可开单数量为:<b>' + $(this).attr('good')+'</b>','提示');
												$(this).val('0');
											}
										}
									}
								//}
								//else {
								//	alert('数量必须大于 0 ');
								//	$(this).val(1);
								//}
								break;
							case 9:
								if (Number($(this).val()) > 0) {
									if (Number($(this).attr('good')) < Number($(this).val())) {
										jAlert('<b>'+$('#pname_'+$(this).attr('id').replace('oQuantity_','')).text()+'</b> 不能超过可开单数量,可开单数量为:<b>' + $(this).attr('good')+'</b>','提示');
										$(this).val($(this).attr('good'));
									}
								}
								else {
									jAlert('调拨数量不能为负数!','提示');
									$(this).val(0);
								}
								break;
						}
						var tid = $(this).attr('id').replace('oQuantity_', '');
						$('#sum_' + tid).html((Number($(this).val()) * Number($("#Price_" + tid).val())).toFixed(OrderDO.MoneyDecimal));
						OrderDO.SumT();
					}).bind("paste", function(){
						OrderDO.IsEditAct = true;
						CheckNumber($(this));
						var _tid =  $(this).attr('id').replace('oQuantity_','');
						switch (OrderDO.OrderType) {
							case 1:
							case 4:
							case 8://增加库存操作不需要验证实际库存,入库,销售退货,调整
								break;
							case 2:
							case 3:
							case 5:
							case 6:
							case 7:
							case 10:
							case 11:
								//if (Number($(this).val()) > 0) {
									if (OrderDO.Steps == 3)//已发货,修改值可以小等于原值
									{
										if (Number($(this).attr('oldvalue')) < Number($(this).val())) {
											jAlert('<b>'+$('#pname_'+_tid).text()+'</b> 不能高于原数量:<b>' + $(this).attr('oldvalue')+'</b>','提示');
											$(this).val($(this).attr('oldvalue'));
										}
									}
									else {
										if (Number($(this).attr('good')) < Number($(this).val())) {
											jAlert('<b>'+$('#pname_'+_tid).text()+'</b> 不能超过可开单数量,可开单数量为:<b>' + $(this).attr('good')+'</b>','提示');
											$(this).val($(this).attr('good'));
										}else if (Number($(this).attr('MaxStock')) > -1) {
												if (Number($(this).attr('MaxStock')) < Number($(this).val())) {
													jAlert('<b>' + $('#pname_' + _tid).text() + '</b> 不能超过配额数量,可用配额数量为:<b>' + $(this).attr('MaxStock') + '</b>', '提示');
													$(this).val($(this).attr('MaxStock'));
												}
											
										}else{
											if (OrderDO.GetProductAllQuantity(Number($('#tr_'+_tid).attr('storageid')), Number($('#tr_'+_tid).attr('pid')), Number($(this).val())) > Number($(this).attr('good'))) {
												jAlert('<b>'+$('#pname_'+_tid).text()+'</b> 单据列表内总数不能超过可开单数量,可开单数量为:<b>' + $(this).attr('good')+'</b>','提示');
												$(this).val('0');
											}
										}
									}
								//}
								//else {
								//	alert('数量必须大于 0 ');
								//	$(this).val(1);
								//}
								break;
							case 9:
								if (Number($(this).val()) > 0) {
									if (Number($(this).attr('good')) < Number($(this).val())) {
										jAlert('<b>'+$('#pname_'+$(this).attr('id').replace('oQuantity_','')).text()+'</b> 不能超过可开单数量,可开单数量为:<b>' + $(this).attr('good')+'</b>','提示');
										$(this).val($(this).attr('good'));
									}
								}
								else {
									jAlert('调拨数量不能为负数!','提示');
									$(this).val(0);
								}
								break;
						}
						var tid = $(this).attr('id').replace('oQuantity_', '');
						$('#sum_' + tid).html((Number($(this).val()) * Number($("#Price_" + tid).val())).toFixed(OrderDO.MoneyDecimal));
						OrderDO.SumT();
					}).css("ime-mode", "disabled");
					
					if(',2,3,5,6,7,10,11,'.indexOf(',' + this.OrderType + ',') > -1){
						$("#oQuantity_" + _rid).keyup();
					}
					
				}
				
			}else{
				//不可编辑状态
				$('.OrderListTool :input').attr('readonly','readonly');
				$("#tr_" + _rid+' :input').attr('readonly','readonly');
				//是否显示价格
				if (!this.ShowPrice) {
					$("#Price_" + _rid).attr('class', 'input_disabled');
					$('#sum_' + _rid).html('');
				}
			}
			OrderDO.SumT();
			this.rowID++;
			
			dt = null;
		}finally{
			this.sID = -1;
		}
	}
}
//调拨单时的处理
TOrderDO.prototype.GetB = function(re)
{
	var isold = false;
	var tr = $('#OrderListLoop_data').children('tbody').children('tr');
	if (tr.length > 0) {
		for (var i = 0; i < tr.length; i++) {
			if ($(tr[i]).attr('pid')) {
				tId = $(tr[i]).attr('id').replace('tr_', '');
				if(re.ProductInfo.id == $(tr[i]).attr('pid'))
				{
					//alert(re.ind);
					//var _oQuantity = (re.ind)
					if(Number(this.OrderListDataJson.OrderListJson[re.ind].oQuantity)>0)
					{
						//$(tr).attr('StorageIDB',re.StorageInfo.id);

						document.getElementById('Storage_t_'+tId).innerHTML = re.StorageInfo.name;
						document.getElementById('oQuantity_'+tId).value = re.ProductInfo.Quantity;
						document.getElementById('sum_'+tId).innerHTML = ((Number(re.ProductInfo.Price)*Number(re.ProductInfo.Quantity))).toFixed(OrderDO.MoneyDecimal);

					}
					else
					{
						
						//$(tr).attr('StorageIDB',$(tr).attr('StorageID'));
						//$(tr).attr('StorageID',re.StorageInfo.id);
						
						$('#'+document.getElementById('oQuantity_'+tId).id).attr('good',re.ProductInfo.Good);
						document.getElementById('Storage_t_'+tId).innerHTML = document.getElementById('Storage_s_'+tId).innerHTML;
						document.getElementById('Storage_s_'+tId).innerHTML = re.StorageInfo.name;
						
					}
					isold = true;
				}
			}
		}
	}
	return isold;
}
TOrderDO.prototype.ReSetDataList = function()
{
	$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
			
	$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
		$(this).show();
	});
	this.IsLoaded = false;

	if(this.OrderListDataJson)
	{
		if (this.OrderListDataJson.OrderListJson) {
			this.ListCount = 0;
			for (var i = 0; i < this.OrderListDataJson.OrderListJson.length; i++) {
				if (this.OrderType != 9) {
					
					var dt = $('#OrderListLoop_data');
					//附属赠品
					if (this.OrderListDataJson.OrderListJson[i].IsGifts > 0) {
						var _pObj = dt.children('tbody').children('tr[pid="'+this.OrderListDataJson.OrderListJson[i].IsGifts+'"][IsGifts="0"]').first();
						if (!this.CheckProduct('d_' + this.OrderListDataJson.OrderListJson[i].ProductsID),_pObj.attr('id')) {
							//jQuery('<tr id="tr_' + this.rowID + '" OrderListID="0" OrderID="0" StorageID="' + this.OrderListDataJson.OrderListJson[i].StorageID + '" IsGifts="' + this.OrderListDataJson.OrderListJson[i].IsGifts + '" pid="' + this.OrderListDataJson.OrderListJson[i].ProductsID + '" class="' + ((this.rowID % 2 != 0) ? 'trA' : 'trB') + '"></tr>').insertAfter(_pObj);
							this.rowID++;
						}
					}
					else {
						if (!this.CheckProduct('d_' + this.OrderListDataJson.OrderListJson[i].ProductsID)) {
							jQuery('<tr id="tr_' + this.rowID + '" OrderListID="0" OrderID="0" StorageID="' + this.OrderListDataJson.OrderListJson[i].StorageID + '" IsGifts="' + this.OrderListDataJson.OrderListJson[i].IsGifts + '" PriceClassID="'+this.OrderListDataJson.OrderListJson[i].PriceClassID+'" pid="' + this.OrderListDataJson.OrderListJson[i].ProductsID + '" class="' + ((this.rowID % 2 != 0) ? 'trA' : 'trB') + '"></tr>').appendTo(dt);
							this.rowID++;
						}
					}
				}else{
					if (!this.CheckProduct_b('d_' + this.OrderListDataJson.OrderListJson[i].ProductsID)) {
//alert(this.OrderListDataJson.OrderListJson[i].ProductsID);
						if (this.OrderListDataJson.OrderListJson[i].oQuantity > 0) {
							jQuery('<tr id="tr_' + this.rowID + '" OrderListIDB="' + this.OrderListDataJson.OrderListJson[i].OrderListID + '" OrderID="0" StorageIDB="' + this.OrderListDataJson.OrderListJson[i].StorageID + '" QuantityB="' + this.OrderListDataJson.OrderListJson[i].oQuantity + '" IsGifts="0" PriceClassID="' + this.OrderListDataJson.OrderListJson[i].PriceClassID + '" pid="' + this.OrderListDataJson.OrderListJson[i].ProductsID + '" class="' + ((this.rowID % 2 != 0) ? 'trA' : 'trB') + '"></tr>').appendTo(dt);
							this.rowID++;
						}
						else {
							jQuery('<tr id="tr_' + this.rowID + '" OrderListID="' + this.OrderListDataJson.OrderListJson[i].OrderListID + '" OrderID="0" StorageID="' + this.OrderListDataJson.OrderListJson[i].StorageID + '" Quantity="' + this.OrderListDataJson.OrderListJson[i].oQuantity + '" IsGifts="0" PriceClassID="' + this.OrderListDataJson.OrderListJson[i].PriceClassID + '" pid="' + this.OrderListDataJson.OrderListJson[i].ProductsID + '" class="' + ((this.rowID % 2 != 0) ? 'trA' : 'trB') + '"></tr>').appendTo(dt);
							this.rowID++;
						}
					}
				}
				var _uStr = '';
				switch (OrderDO.OrderType) {
					case 1:
					case 2:
						_uStr = "&SupplierID="+$('#SupplierID').val();
						break;
					case 3:case 4:case 5:case 6:case 7:case 11:
						_uStr = "&StoresID="+$('#StoresID').val();
						break;
				}
				
				$.getJSON('/Services/CAjax.aspx?do=GetProducts'+_uStr+'&ProductID=' + this.OrderListDataJson.OrderListJson[i].ProductsID+'&StorageID='+this.OrderListDataJson.OrderListJson[i].StorageID+'&ind='+i, function(data,status){
					if (status != 'success') {
						jAlert('网络传输失败,请刷新该页面!', '提示');
						return;
					}
					else {
						var good = 0;
						if (data.results.StorageInfo) {
							good = Number(data.results.StorageInfo.BeginningStorage) + Number(data.results.StorageInfo.NowStorage) + Number(data.results.StorageInfo.StorageIn) - Number(data.results.StorageInfo.StorageOut) - Number(data.results.StorageInfo.StorageBad);
						}
						//整理配额数据
						var _MS_NumsStr = ',"MS_Nums":{"StorageID":"","StorageName":"","ProductsID":"","m_Num":"-1"}';
						switch (OrderDO.OrderType) {
							case 3:
							case 4:
							case 5:
							case 6:
							case 7:
							case 11:
								if (data.results.MS_Nums) {
									if (data.results.MS_Nums != '') {
										for (var _i = 0; _i < data.results.MS_Nums.length; _i++) {
											if (data.results.MS_Nums[_i].StorageID == data.results.StorageInfo.StorageID) {
												_MS_NumsStr = ',"MS_Nums":{"StorageID":"' + data.results.MS_Nums[_i].StorageID + '","StorageName":"' + data.results.MS_Nums[_i].StorageName + '","ProductsID":"' + data.results.MS_Nums[_i].ProductsID + '","m_Num":"' + data.results.MS_Nums[_i].m_Num + '"}';
												break;
											}
										}
									}
								}
								break;
						}
						var reJson = jQuery.parseJSON('{"ind":' + data.results.ind + ',"StorageInfo":{"id":"' + OrderDO.OrderListDataJson.OrderListJson[data.results.ind].StorageID + '","idB":"","name":"' + OrderDO.OrderListDataJson.OrderListJson[data.results.ind].StorageName + '","nameB":""},' +
						'"ProductInfo":{"id":"' +
						data.results.ProductsID +
						'","Barcode":"' +
						data.results.pBarcode +
						'","name":"' +
						data.results.pName +
						'",' +
						'"ToBoxNo":"' +
						data.results.pToBoxNo +
						'","pUnits":"' +
						data.results.pUnits +
						'","pMaxUnits":"' +
						data.results.pMaxUnits +
						'","pProducer":"' +
						data.results.pProducer +
						'","pExpireDay":"' +
						data.results.pExpireDay +
						'","Price":"' +
						OrderDO.OrderListDataJson.OrderListJson[data.results.ind].oPrice +
						'","Quantity":"' +
						OrderDO.OrderListDataJson.OrderListJson[data.results.ind].oQuantity +
						'",' +
						'"Good":"' +
						good +
						'","PriceClassID":"' +
						OrderDO.OrderListDataJson.OrderListJson[data.results.ind].PriceClassID +
						'","IsGifts":"' +
						OrderDO.OrderListDataJson.OrderListJson[data.results.ind].IsGifts +
						'"' +
						_MS_NumsStr +
						'}}');
						_MS_NumsStr = null;
						
						OrderDO.AddBoxRe(reJson);
						//判断列表是否加载完成
						OrderDO.ListCount++;
						if (OrderDO.ListCount >= OrderDO.OrderListDataJson.OrderListJson.length-1) {
							OrderDO.IsLoaded = true;
							$("#floatBoxBg").remove();
						}
					}
				});
				dt = null;
			}
		}
	}
}
//验证商品是否已添加
TOrderDO.prototype.CheckProduct = function(pid,tObj)
{
	tObj = tObj?$(tObj):null;//是否有附属赠品
	var revalue = false;
	if (this.OrderListLoop) {
		pid = pid.replace('d_', '');
		var tr = tObj? $('#OrderListLoop_data').children('tbody').children('tr[IsGifts="'+tObj.attr('pid')+'"]'): $('#OrderListLoop_data').children('tbody').children('tr[IsGifts="0"]');
		for(var i=0;i<tr.length;i++)
		{
			if ($(tr[i]).attr('pid')) {
				if (Number($(tr[i]).attr('pid')) == Number(pid)) {
					revalue = true;
					break;
				}
			}
		}
		tr = null;
	}
	return revalue;
}
TOrderDO.prototype.CheckProduct_b = function(pid)
{
	var revalue = false;
	if (this.OrderListLoop) {
		pid = pid.replace('d_', '');
		var tr = $('#OrderListLoop_data').children('tbody').children('tr');
		for(var i=0;i<tr.length;i++)
		{
			if ($(tr[i]).attr('pid')) {
				if (Number($(tr[i]).attr('pid')) == Number(pid)) {
					revalue = true;
					break;
				}
			}
		}
		tr = null;
	}
	return revalue;
}
TOrderDO.prototype.Print = function(oid)
{
	var ShowMoney = '';
	if(!confirm('是否打印金额?'))
	{
		ShowMoney = '?ShowMoney=false';
	}
	window.open('', "top"); 
	setTimeout(window.open('/orderprint-'+this.OrderType+'-'+oid+'.aspx'+ShowMoney, "top"), 100); 
	return false;
}
TOrderDO.prototype.Re = function(oid)
{
	location.href = '/orderlist_do-1-'+this.OrderType+'.aspx';
}
TOrderDO.prototype.Show = function(oid)
{
	location.href = '/orderlist_do_v-'+this.OrderType+'-'+oid+'.aspx';
}
//取客户/供应商编号
TOrderDO.prototype.getStoresID = function()
{
	var StoresSupplierID = 0;
	switch(this.OrderType)
		{
			case 1:case 2:
				StoresSupplierID = $('#SupplierID').val();

			break;
			case 3:case 4:case 5:case 6:case 7:case 11:
				StoresSupplierID = $('#StoresID').val();

			break;
		}
	return StoresSupplierID;
}
//合计金额
TOrderDO.prototype.SumT = function()
{
	var tM = 0;
	var tQ = 0;
	var tQQ = 0;
	var tr = $('#OrderListLoop_data').children('tbody').children('tr');
	var tId = '';
	if (tr) {
		if (tr.length > 0) {
			for (var i = 0; i < tr.length; i++) {
				tId = $(tr[i]).attr('id').replace('tr_','');
				tM+=Number($('#sum_'+tId).html());
				tQ+=Number($('#oQuantity_'+tId).val())/Number($('#oQuantity_'+tId).attr('pToBoxNo'));
				tQQ+=Number($('#oQuantity_'+tId).val());
				
				//重新定义行颜色
				$(tr[i]).css(((i % 2 != 0) ? 'trA' : 'trB'));
			}
		}
	}
	$('#SumMoney').html('<nobr>数量(最小单位):'+Number(tQQ).toFixed(2) + ',&nbsp;&nbsp;合:'+Number(tQ).toFixed(2) + '件,&nbsp;&nbsp;共:' + Number(tM).toFixed(2)+'元&nbsp;&nbsp;&nbsp;&nbsp;</nobr>');
	tQQ = null;
	tQ = null;
	tM = null;
	tr = null;
	tId =null;
}
function getStoresID()
{
	return OrderDO.getStoresID();
}
function getStorageID()
{
	return OrderDO.sel_StorageID;
}
function getStorageIDB()
{
	return OrderDO.sel_StorageIDB;
}
function setStorageID(sid)
{
	 OrderDO.sel_StorageID = sid;
}
function setStorageIDB(sid)
{
	 OrderDO.sel_StorageIDB = sid;
}
function AddBoxRe(reJson)
{
	OrderDO.AddBoxRe(reJson);
}
//取当前条数
function GetLoopLen()
{
	var tr = $('#OrderListLoop_data').children('tbody').children('tr');
	if(tr)
	{
		return tr.length;
	}else{
		return 0;
	}
}
function HidUserBox()
{
	OrderDO.HidUserBox();
}
function SetProductID(reObj,reobj)
{
	OrderDO.SetProductID(reObj,reobj);
}
function getProdictID()
{
	if (OrderDO.tID != -1) {
		var tObj = $('#tr_' + OrderDO.tID);
		return tObj ? tObj.attr('pid') : 0;
	}else{
		return 0;
	}
}
function CheckNumber(obj)
{
	var t = obj.val();
	if (/^[-\+]?\d+(\.\d+)?$/.test(t)) {
		
	}
	else if(t.substr(t.length-1)=='.')
	{
	
	}else
	{

		obj.val(0);
	}
}
//回调设置网购订单货运信息
function SetExp(exp)
{
	if(exp)
	{
		OrderDO.ExpID = exp.ExpID;
		OrderDO.mExpNO = exp.ExpNO;
		CloseBox();
		$('#subbutton_delivery').click();
	}
}

$(function () {
 $("#tTree").jstree({   

		 "json_data":{"ajax":{
			"url":"/Services/CAjax.aspx",
			"data" : function (n) {

							return { 
								"do" : "DataClass",
								"doValue" : "SelectTreeAndData",
								"DataType" : "ProductClass",
								"pid" : n.attr ? n.attr("id").replace("t_","") : -1 ,
								"orderType":$('#hide_p').attr("checked") ? OrderDO.OrderType:0
							};

					}
		 }}, 
		 "core" : { 
				"initially_open" : [ "t_0" ]
			},

		"types" : {  
			 "valid_children" : [ "dt" ],  
			 "types" : {
				 "dt" : {
					 "icon" : { 
						"image" : "/images/dot.png" 
					},
					 "valid_children" : [ "default" ],
					 "max_depth" : 2,
					 "hover_node" : true,
					 "open_node":false,
					 "select_node" : true
				 },
				"root":{
					"valid_children" : [ "default" ],
					"hover_node" : false,
					"select_node" : function () {return false;}
				 }  
			 }  
		},  
		 "plugins" : [ "themes", "json_data", "ui", "crrm", "types","dnd", "hotkeys" ] 

	 }).bind("select_node.jstree", function (e,data) {

	 	if (GetLoopLen() >= 10) {
			jConfirmYesNo('列表已经达到 <b>10</b> 条,是否继续添加?<br>建议单据列表条数不要超过 <b>10</b> 条,否则会影响单据加载速度.','提示',function(r){
				if(r=='yes')
				{
					OrderDO.Add(data.rslt.obj.attr("id"));
				}
			});
		}else{
			OrderDO.Add(data.rslt.obj.attr("id"));
		}
		//alert(data.rslt.obj.attr("id") + ":" + data.rslt.obj.attr("rel"));
	 });

});