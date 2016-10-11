/**
 * cxty@qq.com
 */

var OrderField = null;
var OrderListDataJsonStr = null;
var StorageOrderListJsonStr = null;

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
	this.StorageOrderListJson = null;
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
	
	this.PrintPageWidth = '';//打印单据宽度
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

	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
	this.OrderListLoop = $('#OrderListLoop');
	$('#tBoxsb').hide();
	if (OrderField) {
		this.OrderFieldJson = jQuery.parseJSON(OrderField);
	}
	if(OrderListDataJsonStr)
	{
		this.OrderListDataJson = jQuery.parseJSON(OrderListDataJsonStr);
	}
	if(StorageOrderListJsonStr){
		this.StorageOrderListJson = jQuery.parseJSON(StorageOrderListJsonStr);
	}
	//保存
	$('#subbutton_save').click(function(){
		
		var tMsg = '';
		var IsCheck = false;
		
		var redata = OrderDO.GetDataListToJson();
		

		if (redata) {
			$('#OrderListDataJson').val(redata);
			$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
			$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
				$(this).show();
				$('#bForm').submit();
			});
		}
		
		tMsg = null;
		redata = null;
	});
	
	//打印
	$('#subbutton_print').click(function(){

		jConfirmYesNo('是否打印?<br>提示:每次打印系统都将留下打印记录!','提示',function(r){
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
						LODOP.SET_PRINT_PAGESIZE(3, OrderDO.PrintPageWidth, "0", "");
						LODOP.SET_PRINT_STYLE("FontSize", 12);
						LODOP.ADD_PRINT_URL(0, 0, "100%", "100%", '/storage_order_print-' + OrderDO.OrderType + '-' + OrderDO.OrderID + '.aspx?UserCode=' + OrderDO.UserCode + ShowMoney);
						LODOP.PREVIEW();
					} 
					catch (e) {
						jAlert('请安装打印控件![' + e + ']');
					}
					
					return false;
				} 
				catch (e) {
					window.open('', "top");
					setTimeout(window.open('/storage_order_print-' + OrderDO.OrderType + '-' + OrderDO.OrderID + '.aspx?UserCode=' + OrderDO.UserCode + ShowMoney, "top"), 100);
					return false;
				}
			}
		});
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
					
					if (this.OrderType == 12 ||  (Number($('#oQuantity_s_' + tId).val()) <= Number($('#oQuantity_s_' + tId).attr('pQuantity'))))
					{
						tOrderListJson+='{"OrderListID":' + $(tr[i]).attr('OrderListID') + ',"OrderID":' + $(tr[i]).attr('OrderID') + ',"StorageID":' + $(tr[i]).attr('StorageID') + ',' +
										'"ProductsID":' + $(tr[i]).attr('pid') + ',' +
										'"pQuantity":'+Number($('#oQuantity_s_' + tId).val())+
										'},';
					}else{
						jAlert('<b>' + $('#pname_' + tId).text() + '</b> 不能超过剩余数量,剩余数量为:<b>' + $('#oQuantity_s_' + tId).attr('pQuantity') + '</b>', '提示');
						$('#oQuantity_s_' + tId).val(0);
						$('#oQuantity_s_' + tId).focus();
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
			
			if (this.OrderType != 9 ) {
				//设置默认仓库
				//this.sel_StorageID = re.StorageInfo.id;
				//有赠品附加
				if(re.ProductInfo.IsGifts>0){
					
					_dthtml = '<td width="80px" >'+re.StorageInfo.name+'</td><td width="100px">' +
					re.ProductInfo.Barcode +'</td>' +
					'<td id="pname_'+_rid+'"><a href="javascript:void(0);">&nbsp;&nbsp;(赠)' +re.ProductInfo.name +'</a></td>'+
					'<td width="80px">' + re.ProductInfo.ToBoxNo +'</td>' +
					'<td width="120px"><nobr><input type="hidden" style="width:40px" good="'+re.ProductInfo.Good+'" id="oQuantity_' +_rid +'" name="oQuantity_' +_rid +'" pToBoxNo="'+re.ProductInfo.ToBoxNo+'" oldvalue="'+re.ProductInfo.Quantity+'"   value="'+re.ProductInfo.Quantity+'" />'+re.ProductInfo.Quantity+re.ProductInfo.pUnits+'</nobr></td>' +
					'<td width="120px"><nobr><span id="oQuantity_tt_'+_rid +'">'+re.ProductInfo.sQuantity+'</span>'+re.ProductInfo.pUnits+'</nobr></td>'+
					'<td width="120px"><nobr><span id="oQuantity_ss_'+_rid +'">'+Number(re.ProductInfo.Quantity-re.ProductInfo.sQuantity)+'</span>'+re.ProductInfo.pUnits+'</nobr></td>'+
					'<td width="120px"><nobr><input type="text" style="width:40px" id="oQuantity_s_'+_rid +'" name="oQuantity_s_'+_rid +'" pQuantity="'+Number(re.ProductInfo.Quantity-re.ProductInfo.sQuantity)+'" />'+re.ProductInfo.pUnits+'</nobr></td>'+
					'';
					
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
					'<td id="pname_'+_rid+'"><a href="javascript:void(0);">' +re.ProductInfo.name +'</a></td>'+
					'<td width="80px">' +
					re.ProductInfo.ToBoxNo +'</td>' +
					'<td width="120px"><nobr><input type="hidden" style="width:40px" good="'+re.ProductInfo.Good+'" id="oQuantity_' +_rid +'" name="oQuantity_' +_rid +'" pToBoxNo="'+re.ProductInfo.ToBoxNo+'" oldvalue="'+re.ProductInfo.Quantity+'"  value="'+re.ProductInfo.Quantity+'" />'+re.ProductInfo.Quantity+re.ProductInfo.pUnits+'</nobr></td>' +
					'<td width="120px"><nobr><span id="oQuantity_tt_'+_rid +'">'+re.ProductInfo.sQuantity+'</span>'+re.ProductInfo.pUnits+'</nobr></td>'+
					'<td width="120px"><nobr><span id="oQuantity_ss_'+_rid +'">'+Number(re.ProductInfo.Quantity-re.ProductInfo.sQuantity)+'</span>'+re.ProductInfo.pUnits+'</nobr></td>'+
					'<td width="120px"><nobr><input type="text" style="width:40px" id="oQuantity_s_'+_rid +'" name="oQuantity_s_'+_rid +'" pQuantity="'+Number(re.ProductInfo.Quantity-re.ProductInfo.sQuantity)+'" />'+re.ProductInfo.pUnits+'</nobr></td>'+
					'';
					
					//数据调整
					if(this.OrderType == 12)
					{
						_dthtml = '<td width="80px" >'+re.StorageInfo.name+'</td><td width="100px">' +
									re.ProductInfo.Barcode +'</td>' +
									'<td id="pname_'+_rid+'"><a href="javascript:void(0);">' +re.ProductInfo.name +'</a></td>'+
									'<td width="80px">' +
									re.ProductInfo.ToBoxNo +'</td>' +
									'<td width="120px"><nobr><input type="hidden" style="width:40px" good="'+re.ProductInfo.Good+'" id="oQuantity_' +_rid +'" name="oQuantity_' +_rid +'" pToBoxNo="'+re.ProductInfo.ToBoxNo+'" oldvalue="'+re.ProductInfo.Quantity+'"  value="'+re.ProductInfo.Quantity+'" />'+re.ProductInfo.Quantity+re.ProductInfo.pUnits+'</nobr>'+
									'<input type="hidden" style="width:40px" id="oQuantity_s_'+_rid +'" name="oQuantity_s_'+_rid +'"  value="'+re.ProductInfo.Quantity+'" /></td>' +
									'';
					}
					
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
					'<td>' +re.ProductInfo.name +'</td>'+
					'<td width="80px">' + re.ProductInfo.ToBoxNo +'</td>' +
					'<td width="120px"><nobr><input type="hidden" style="width:40px" good="'+re.ProductInfo.Good+'" id="oQuantity_' +_rid +'" name="oQuantity_' +_rid +'" pToBoxNo="'+re.ProductInfo.ToBoxNo+'" oldvalue="'+re.ProductInfo.Quantity+'"  value="'+re.ProductInfo.Quantity+'" />'+re.ProductInfo.Quantity+re.ProductInfo.pUnits+'</nobr></td>' +
					'<td width="120px"><nobr><span id="oQuantity_tt_'+_rid +'">'+re.ProductInfo.sQuantity+'</span>'+re.ProductInfo.pUnits+'</nobr></td>'+
					'<td width="120px"><nobr><span id="oQuantity_ss_'+_rid +'">'+Number(re.ProductInfo.Quantity-re.ProductInfo.sQuantity)+'</span>'+re.ProductInfo.pUnits+'</nobr></td>'+
					'<td width="120px"><nobr><input type="text" style="width:40px" id="oQuantity_s_'+_rid +'" name="oQuantity_s_'+_rid +'" pQuantity="'+Number(re.ProductInfo.Quantity-re.ProductInfo.sQuantity)+'" />'+re.ProductInfo.pUnits+'</nobr></td>'+
					'';
					
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
						
						
						
					}
				}
			}
			
			
					
					$("#oQuantity_s_" + _rid).keyup(function(){
						
						CheckNumber($(this));
						var _tid =  $(this).attr('id').replace('oQuantity_s_','');
						switch (OrderDO.OrderType) {
							case 1:
							case 4:
							case 8:
							case 12://增加库存操作不需要验证实际库存,入库,销售退货,调整
								break;
							case 2:
							case 3:
							case 5:
							case 6:
							case 7:
							case 10:
							case 11:
							case 9:
							
								if(Number($(this).val())>Number($(this).attr('pQuantity')))
								{
									jAlert('<b>'+$('#pname_'+_tid).text()+'</b> 不能高于剩余数量:<b>' + $(this).attr('pQuantity')+'</b>','提示');
											$(this).val($(this).attr('pQuantity'));
								}
							
								
								break;
							
						}
						var tid = $(this).attr('id').replace('oQuantity_s_', '');
						//$('#sum_' + tid).html((Number($(this).val()) * Number($("#Price_" + tid).val())).toFixed(OrderDO.MoneyDecimal));
						OrderDO.SumT();
					}).bind("paste", function(){
						OrderDO.IsEditAct = true;
						CheckNumber($(this));
						var _tid =  $(this).attr('id').replace('oQuantity_s_','');
						switch (OrderDO.OrderType) {
							case 1:
							case 4:
							case 8:
							case 12://增加库存操作不需要验证实际库存,入库,销售退货,调整
								break;
							case 2:
							case 3:
							case 5:
							case 6:
							case 7:
							case 10:
							case 11:
							case 9:
							
								if(Number($(this).val())>Number($(this).attr('pQuantity')))
								{
									jAlert('<b>'+$('#pname_'+_tid).text()+'</b> 不能高于剩余数量:<b>' + $(this).attr('pQuantity')+'</b>','提示');
											$(this).val($(this).attr('pQuantity'));
								}
							
								
								break;
						}
						var tid = $(this).attr('id').replace('oQuantity_s_', '');
						//$('#sum_' + tid).html((Number($(this).val()) * Number($("#Price_" + tid).val())).toFixed(OrderDO.MoneyDecimal));
						OrderDO.SumT();
					}).css("ime-mode", "disabled");
					
					/*
					if(',2,3,5,6,7,10,11,'.indexOf(',' + this.OrderType + ',') > -1){
						$("#oQuantity_s_" + _rid).keyup();
					}
					*/
				
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
						//匹配发货记录
						var StorageObj = null;
						for(var s = 0;s<OrderDO.StorageOrderListJson.StorageOrderList.length;s++){
							if(OrderDO.StorageOrderListJson.StorageOrderList[s].OrderListID == OrderDO.OrderListDataJson.OrderListJson[data.results.ind].OrderListID)
							{
								StorageObj = OrderDO.StorageOrderListJson.StorageOrderList[s];
							}
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
						'","sQuantity":"'+StorageObj.pQuantity+
						'","Good":"' +
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
						if (OrderDO.ListCount == OrderDO.OrderListDataJson.OrderListJson.length) {
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
	$('#SumMoney').html('<nobr>数量(最小单位):'+Number(tQQ).toFixed(2) + ',&nbsp;&nbsp;合:'+Number(tQ).toFixed(2) + '件</nobr>');
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
								"pid" : n.attr ? n.attr("id").replace("t_","") : -1 
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