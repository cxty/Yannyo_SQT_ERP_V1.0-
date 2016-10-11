/**
 * @author Cxty
 */
function TM_SendGoods()
{
	this.rowID = 0;
	this.MConfigID = '';
	this.ActStr = '';
	this.PageBox = null;
	this.PageForm = null;
	this.StoresID = 0;
	this.OrderListDataJsonStr = '';
	this.OrderListDataJson = null;
	this.IsLoaded = false;
	this.ListCount = 0;
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
}
TM_SendGoods.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	
	if(this.OrderListDataJsonStr)
	{
		this.OrderListDataJson = jQuery.parseJSON(this.OrderListDataJsonStr);
		this.ReSetDataList();
	}
	
	$('#morder_address_box :radio').click(function(){
		$('#receiver_state').val($(this).attr('receiver_state'));
		$('#receiver_city').val($(this).attr('receiver_city'));
		$('#receiver_district').val($(this).attr('receiver_district'));
		$('#receiver_address').val($(this).attr('receiver_address'));
		$('#receiver_zip').val($(this).attr('receiver_zip'));
		$('#receiver_name').val($(this).attr('receiver_name'));
		$('#receiver_mobile').val($(this).attr('receiver_mobile'));
		$('#receiver_phone').val($(this).attr('receiver_phone'));
	});
	$('#bt_add').click(function()
	{
		M_SendGoods.ShowProductTree();
	});
	$('#bt_del').click(function()
	{
		M_SendGoods.Del();
	});
	$('#bt_ok').click(function()
	{
		M_SendGoods.Save();
	});
	$('#bt_cancel').click(function()
	{
		window.parent.HidBox();
	});
}
//计算总金额
TM_SendGoods.prototype.TSum = function()
{
	var tM = 0;
	var tr = $('#order_loop').children('tr');
	var tId = '';
	if (tr) {
		if (tr.length > 0) {
			for (var i = 0; i < tr.length; i++) {
				tId = $(tr[i]).attr('id').replace('tr_','');
				tM+=Number($('#sum_'+tId).html());
			}
		}
	}
	$('#SumMoney').html(Number(tM).toFixed(2));

	tM = null;
	tr = null;
	tId =null;
}
//弹出商品选择
TM_SendGoods.prototype.ShowProductTree = function()
{

	this.PageBox=dialog("选择商品","iframe:public_producttree.aspx",this.dw,this.dh,"iframe");

}
//添加商品
TM_SendGoods.prototype.Add = function(reObj,treObj)
{
	if(reObj)
	{
		if (!this.CheckProduct(reObj.id)) {
			this.PageBox = dialog("选择仓库", 'iframe:orderlist_dobox-3-' + reObj.id + '.aspx', "500px", "300px", "iframe");
		}else{
			jAlert(reObj.name+' 已在列表中!','提示');
		}
	}
}
//删除商品
TM_SendGoods.prototype.Del = function()
{
	for(var i=0 ;i<this.PageForm.elements.length;i++){ 
        if(this.PageForm.elements[i].name=="cCheck"){ 
            e=this.PageForm.elements[i];
            if(e.checked == true)
            {
				if($(e).val())
				{
					$('#tr_'+$(e).attr('tpid').replace('c_','')).hide(500,function()
					{
						$(this).remove();
					});
				}
            }
        }
    }
}
//保存
TM_SendGoods.prototype.Save = function()
{
	var reData = '';
	if($('#receiver_address').val())
	{
		if ($('#receiver_name').val()) {
			if ($('#receiver_mobile').val()) {
				reData = this.GetDataListToJson();
				if (reData) {
					$('#OrderListDataJson').val(reData);
					$('#form1').submit();
				}else{
					jAlert('没有选择任何商品,无法下单!','提示');
				}
			}else{
				jAlert('请填写收货人手机号码!','提示');
				$('#receiver_mobile').focus();
			}
		}else{
			jAlert('请填写收货人姓名!','提示');
			$('#receiver_name').focus();
		}
	}else{
		jAlert('请填写收货地址!','提示');
		$('#receiver_address').focus();
	}
	
}
//验证商品是否已添加
TM_SendGoods.prototype.CheckProduct = function(pid)
{
	var revalue = false;
	if (pid) {
		var tr = $('#order_loop').children('tr');
		for(var i=0;i<tr.length;i++)
		{
			if ($(tr[i]).attr('pid')) {
				if (Number($(tr[i]).attr('pid')) == Number(pid)) {
					revalue = true;
					break;
				}
			}
		}
		dt = null;
	}
	return revalue;
}
//添加商品列表项
TM_SendGoods.prototype.AddBoxRe = function(re)
{
	this.rowID++;
	
	if (re) {
		var dt = $('#order_loop');
		var newTR = null;
		var _dthtml = '';
		var _isnew = false;
		
		var tTr = $(dt).children('tr[pid="' + re.ProductInfo.id + '"]');
		
		try {
			if (tTr) {
				_rid = $(tTr).attr('id').replace('tr_', '');
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
		if(re.ProductInfo.PriceClassID)
		{
			re.ProductInfo.PriceClassID = Number(re.ProductInfo.PriceClassID);
		}else{
			re.ProductInfo.PriceClassID = 0;
		}
		_dthtml = '<td width="24" align="center" ><input name="cCheck" type="checkbox" class="B_Check" tpid="c_' + _rid + '" value="' + re.ProductInfo.id + '"  /></td>' +
		'<td width="25" valign="middle"> </td><td valign="middle"></td>' +
		'<td width="20%">' +
		re.ProductInfo.name +
		'</td>' +
		'<td width="8%">' +
		re.ProductInfo.Barcode +
		'</td>' +
		'<td width="8%" align="right"><input type="text" style="width:40px" id="Price_' +
		_rid +
		'" name="Price_' +
		_rid +
		'" value="' +
		re.ProductInfo.Price +
		'"></td>' +
		'<td width="8%" align="right"><nobr><input type="text" style="width:40px" MaxStock="' +
		re.ProductInfo.MS_Nums.m_Num +
		'" good="' +
		re.ProductInfo.Good +
		'" id="oQuantity_' +
		_rid +
		'" name="oQuantity_' +
		_rid +
		'" pToBoxNo="' +
		re.ProductInfo.ToBoxNo +
		'" oldvalue="' +
		re.ProductInfo.Quantity +
		'" value="' +
		re.ProductInfo.Quantity +
		'" />' +
		re.ProductInfo.pUnits +
		'</nobr></td>' +
		'<td width="8%" colspan="4" align="right" style="text-align:right;" id="sum_' +
		_rid +
		'">' +
		((Number(re.ProductInfo.Price) * Number(re.ProductInfo.Quantity))).toFixed(2) +
		'</td>';
		
		if (!_isnew) {
			jQuery(_dthtml).appendTo(tTr);
			newTR = tTr;
		}
		else {
		
			newTR = jQuery('<tr id="tr_' + _rid + '" OrderListID="0" OrderID="0" PriceClassID="'+re.ProductInfo.PriceClassID+'" StorageID="' + re.StorageInfo.id + '" pid="' + re.ProductInfo.id + '" class="' + ((_rid % 2 != 0) ? 'trB' : 'trA') + '">' +
			_dthtml +
			'</tr>').appendTo(dt);
			
		}
		
		$("#Price_" + _rid).keyup(function(){
			CheckNumber($(this));
			var tid = $(this).attr('id').replace('Price_', '');
			$('#sum_' + tid).html((Number($(this).val()) * Number($("#oQuantity_" + tid).val())).toFixed(2));
			M_SendGoods.TSum();
		}).bind("paste", function(){
			CheckNumber($(this));
			var tid = $(this).attr('id').replace('Price_', '');
			$('#sum_' + tid).html((Number($(this).val()) * Number($("#oQuantity_" + tid).val())).toFixed(2));
			M_SendGoods.TSum();
		}).css("ime-mode", "disabled");
		$("#oQuantity_" + _rid).keyup(function(){
			CheckNumber($(this));
			
			if (Number($(this).attr('good')) < Number($(this).val())) {
				jAlert('不能超过可开单数量,可开单数量为:' + $(this).attr('good'), '提示');
				$(this).val($(this).attr('good'));
			}
			else {
				if (Number($(this).attr('MaxStock')) > -1) {
					if (Number($(this).attr('MaxStock')) < Number($(this).val())) {
						jAlert('不能超过配额数量,可用配额为:' + $(this).attr('MaxStock'), '提示');
						$(this).val($(this).attr('MaxStock'));
					}
				}
			}
			var tid = $(this).attr('id').replace('oQuantity_', '');
			$('#sum_' + tid).html((Number($(this).val()) * Number($("#Price_" + tid).val())).toFixed(2));
			M_SendGoods.TSum();
		}).bind("paste", function(){
			CheckNumber($(this));
			
			if (Number($(this).attr('good')) < Number($(this).val())) {
				jAlert('不能超过可开单数量,可开单数量为:' + $(this).attr('good'), '提示');
				$(this).val($(this).attr('good'));
			}
			else {
				if (Number($(this).attr('MaxStock')) > -1) {
					if (Number($(this).attr('MaxStock')) < Number($(this).val())) {
						jAlert('不能超过配额数量,可用配额为:' + $(this).attr('MaxStock'), '提示');
						$(this).val($(this).attr('MaxStock'));
					}
				}
			}
			
			var tid = $(this).attr('id').replace('oQuantity_', '');
			$('#sum_' + tid).html((Number($(this).val()) * Number($("#Price_" + tid).val())).toFixed(2));
			M_SendGoods.TSum();
		}).css("ime-mode", "disabled");
		this.TSum();
		dt = null;
	}
}
//整理列表并返回数据
TM_SendGoods.prototype.GetDataListToJson = function()
{
	var tr = $('#order_loop').children('tr');
	var tOrderListJson = '';
	var tId = '';
	if (tr.length > 0) {
		for (var i = 0; i < tr.length; i++) {
			if ($(tr[i]).attr('pid')) {
				tId = $(tr[i]).attr('id').replace('tr_', '');
				tOrderListJson += '{"OrderListID":' + $(tr[i]).attr('OrderListID') + ',"OrderID":' + $(tr[i]).attr('OrderID') + ',"StorageID":' + $(tr[i]).attr('StorageID') + ',' +
							'"ProductsID":' +$(tr[i]).attr('pid') +',' +'"oQuantity":' +$('#oQuantity_' + tId).val() +',' +
							'"oPrice":' +$('#Price_' + tId).val() +',' +'"oMoney":' +Number($('#oQuantity_' + tId).val()) * Number($('#Price_' + tId).val()) +',' +
							'"StoresSupplierID":' +this.StoresID +',' +'"IsPromotions":0,"oWorkType":0,"IsGifts":0,"PriceClassID":'+$(tr[i]).attr('PriceClassID')+',"oAppendTime":"\/Date(1289206775426+0800)\/"},';
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
//重置列表
TM_SendGoods.prototype.ReSetDataList = function()
{
	this.IsLoaded = false;
	if (this.OrderListDataJson) {
		if (this.OrderListDataJson.OrderListJson) {
			this.rowID = 0;
			var dt = $('#order_loop');
			for (var i = 0; i < this.OrderListDataJson.OrderListJson.length; i++) {
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
						jQuery('<tr id="tr_' + this.rowID + '" OrderListID="0" OrderID="0" StorageID="' + this.OrderListDataJson.OrderListJson[i].StorageID + '" PriceClassID="'+this.OrderListDataJson.OrderListJson[i].PriceClassID+'" IsGifts="' + this.OrderListDataJson.OrderListJson[i].IsGifts + '" pid="' + this.OrderListDataJson.OrderListJson[i].ProductsID + '" class="' + ((this.rowID % 2 != 0) ? 'trA' : 'trB') + '"></tr>').appendTo(dt);
						this.rowID++;
					}
				}
				var _uStr = "&StoresID="+this.StoresID;
				$.getJSON('/Services/CAjax.aspx?do=GetProducts'+_uStr+'&ProductID=' + this.OrderListDataJson.OrderListJson[i].ProductsID+'&StorageID='+this.OrderListDataJson.OrderListJson[i].StorageID+'&ind='+i, function(data){
					var good = 0;
					if (data.results.StorageInfo) {
						good =Number(data.results.StorageInfo.BeginningStorage)+ Number(data.results.StorageInfo.NowStorage) + Number(data.results.StorageInfo.StorageIn) - Number(data.results.StorageInfo.StorageOut) - Number(data.results.StorageInfo.StorageBad);
					}
					//整理配额数据
					var _MS_NumsStr = ',"MS_Nums":{"StorageID":"","StorageName":"","ProductsID":"","m_Num":"-1"}';
					
					if (data.results.MS_Nums) {
						if (data.results.MS_Nums != '') {
							for (var _i=0; _i < data.results.MS_Nums.length; _i++) {
								if (data.results.MS_Nums[_i].StorageID == data.results.StorageInfo.StorageID) {
									_MS_NumsStr = ',"MS_Nums":{"StorageID":"'+data.results.MS_Nums[_i].StorageID+'","StorageName":"'+data.results.MS_Nums[_i].StorageName+'","ProductsID":"'+data.results.MS_Nums[_i].ProductsID+'","m_Num":"'+data.results.MS_Nums[_i].m_Num+'"}';
									break;
								}
							}
						}
					}
						
					var reJson = jQuery.parseJSON('{"ind":'+data.results.ind+',"StorageInfo":{"id":"'+M_SendGoods.OrderListDataJson.OrderListJson[data.results.ind].StorageID+'","idB":"","name":"'+M_SendGoods.OrderListDataJson.OrderListJson[data.results.ind].StorageName+'","nameB":""},'+
									'"ProductInfo":{"id":"'+data.results.ProductsID+'","Barcode":"'+data.results.pBarcode+'","name":"'+data.results.pName+'",'+
									'"ToBoxNo":"'+data.results.pToBoxNo+'","pUnits":"'+data.results.pUnits+'","pMaxUnits":"'+data.results.pMaxUnits+'","pProducer":"'+data.results.pProducer+'","pExpireDay":"'+data.results.pExpireDay+'","Price":"'+M_SendGoods.OrderListDataJson.OrderListJson[data.results.ind].oPrice+'","Quantity":"'+M_SendGoods.OrderListDataJson.OrderListJson[data.results.ind].oQuantity+'",'+
									'"Good":"'+good+'","PriceClassID":"'+M_SendGoods.OrderListDataJson.OrderListJson[data.results.ind].PriceClassID+'","IsGifts":"'+M_SendGoods.OrderListDataJson.OrderListJson[data.results.ind].IsGifts+'"'+_MS_NumsStr+'}}');
					_MS_NumsStr = null;
					M_SendGoods.AddBoxRe(reJson);
					//判断列表是否加载完成
					M_SendGoods.ListCount++;
					if(M_SendGoods.ListCount==M_SendGoods.OrderListDataJson.OrderListJson.length)
					{
						M_SendGoods.IsLoaded = true;
					}
				});
			}
			dt = null;
		}
	}
}
TM_SendGoods.prototype.HidUserBox = function()
{
	CloseBox();
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
//返回客户编号
function getStoresID()
{
	return M_SendGoods.StoresID;
}
function SetProductID(reObj,treObj)
{
	M_SendGoods.Add(reObj,treObj);
}
//添加商品
function AddBoxRe(reJson)
{
	M_SendGoods.AddBoxRe(reJson);
}
function HidUserBox()
{
	M_SendGoods.HidUserBox();
}