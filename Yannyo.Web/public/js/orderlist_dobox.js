/**
 * cxty@qq.com
 */
function TOrderDOBox()
{
	this.OrdeType = 0;
	this.ProductID = 0;
	this.StorageID = null;
	this.StorageInfo = null;
	this.ProductInfo = null;
	this.Quantity = null;
	this.Price = null;
	
	this.StorageIDB = null;
	this.StorageInfoB = null;
	
	this.ProductObj = null;
	this.ProductObjB = null;
	this.Good = 0;//可开单数量
	this.GoodB = 0;//b仓库可开单数量

	this.MoneyDecimal=0;
	this.QuantityDecimal=0;
	this.StoresID = 0;
	
	this.ShowMStock=false;
	this.MaxStock = -1;//当前客户配额,负义为不限
	
	this.PriceClassIDObj = null;//价格分类对象
	
	this.tObj = '';

	this.NOPrice = false;
	this.EditDefaultPrice = false;
}
TOrderDOBox.prototype.ini = function(){
	
    this.EditDefaultPrice = parent.OrderDO.EditDefaultPrice;
    $('#Price').attr('readonly', true);
    $('#SumMoney').attr('readonly', true);

    if (this.EditDefaultPrice) {
        $('#Price').attr('readonly', false);
        $('#SumMoney').attr('readonly', false);
    }

	if(this.tObj || this.OrdeType == 5 || this.OrdeType == 6 || this.OrdeType == 10)
	{
		this.NOPrice = true;
		$('#Price').val(0);
	}

	//指定价格分类
	$("#category_c").mcDropdown("#categorymenu_c",{select:function(mObj,reData){
		if(mObj)
		{
			if (Number(mObj) > 0) {
				$('#PriceClassID').val(mObj);
				//获取价格
				$.getJSON('/Services/CAjax.aspx?do=GetProductsPrice&ProductID='+OrderDOBox.ProductID+'&PriceClassID='+mObj,function(data){
					if(data)
					{
						if(data.results.DefaultPrice)
						{
							if(!OrderDOBox.NOPrice){
								$('#Price').val(data.results.DefaultPrice);
							}
							
						}
						if (data.results.IsEdit) {

						    $('#Price').attr('readonly', false);
						    $('#SumMoney').attr('readonly', false);

						} else {
						    if (OrderDOBox.EditDefaultPrice) {

						        $('#Price').attr('readonly', false);
						        $('#SumMoney').attr('readonly', false);

						    } else {

						        $('#Price').attr('readonly', true);
						        $('#SumMoney').attr('readonly', true);

						    }

						}
					}
				});
			}
		}
	}});

	
	
	this.StorageID = $('#StorageID');
	this.StorageInfo = $('#StorageInfo');
	this.ProductInfo = $('#ProductInfo');
	this.Quantity = $('#Quantity');
	this.Price = $('#Price');
	this.PriceClassIDObj = $("#category_c").mcDropdown();
	this.StoresID = parent.getStoresID();
	//选中默认
	$('#StorageID').val(parent.getStorageID());
	
	if (this.OrdeType != 9) 
	{
		$('#StorageID').change(function(){
			var tUrl = '';
			switch(OrderDOBox.OrdeType)
			{
				case 1:case 2:
					OrderDOBox.ShowMStock = false;
					tUrl = 'SupplierID='+OrderDOBox.StoresID;
				break;
				case 3:case 4:case 5:case 6:case 7:
					OrderDOBox.ShowMStock = true;
					tUrl = 'StoresID='+OrderDOBox.StoresID;	
				break;
			}
			
			$.getJSON('/Services/CAjax.aspx?do=GetProducts&'+tUrl+'&ProductID=' + OrderDOBox.ProductID + '&StorageID=' + $(this).children('option:selected').val(), function(data){
				OrderDOBox.ProductObj = data;
				OrderDOBox.good = 0;
				
				if (data.results.StorageInfo != null) {
					OrderDOBox.good = Number(data.results.StorageInfo.BeginningStorage);
					if (data.results.StorageInfo.NowStorage) {
						OrderDOBox.good = OrderDOBox.good + Number(data.results.StorageInfo.NowStorage) + Number(data.results.StorageInfo.StorageIn)  - Number(data.results.StorageInfo.StorageBad) - Number(data.results.StorageInfo.StorageOut);
						$('#StorageInfo').html('可开单:' + Number(OrderDOBox.good).toFixed(OrderDOBox.QuantityDecimal) +
												'<br/>库存点:' + (Number(data.results.StorageInfo.NowStorage)+Number(data.results.StorageInfo.BeginningStorage)+Number(data.results.StorageInfo.StorageIn)- Number(data.results.StorageInfo.StorageOut)).toFixed(OrderDOBox.QuantityDecimal) + 
												'<br/>入库未核销:' + Number(data.results.StorageInfo.StorageIn).toFixed(OrderDOBox.QuantityDecimal) + 
												'<br/>出库未核销:' + Number(data.results.StorageInfo.StorageOut).toFixed(OrderDOBox.QuantityDecimal) + 
												'<br/>不可用:' + Number(data.results.StorageInfo.StorageBad).toFixed(OrderDOBox.QuantityDecimal)
												);
						if (OrderDOBox.ShowMStock) {
							if (data.results.MS_Nums) {
								if (data.results.MS_Nums != '') {
									var _tms = '';
									for (var _i=0; _i < data.results.MS_Nums.length; _i++) {
										if (data.results.MS_Nums[_i].StorageID == data.results.StorageInfo.StorageID) {
											_tms += Number(data.results.MS_Nums[_i].m_Num).toFixed(OrderDOBox.QuantityDecimal);
											OrderDOBox.MaxStock = Number(data.results.MS_Nums[_i].m_Num);
											break;
										}
									}
									if (_tms != '') {
										$('#MStockInfo').html(_tms);
									}else{
										OrderDOBox.MaxStock = -1;
										$('#MStockInfo').html('不限');
									}
								}else{
									OrderDOBox.MaxStock = -1;
									$('#MStockInfo').html('不限');
								}
							}else{
								OrderDOBox.MaxStock = -1;
								$('#MStockInfo').html('不限');
							}
						}
						
						$('#pUnits').html(data.results.pUnits);
						$('#pUnits_b').html(data.results.pUnits);
						$('#pMaxUnits').html(data.results.pMaxUnits);
						$('#pToBoxNo').html(data.results.pToBoxNo);
						
					}
					else 
					{
						$('#StorageInfo').html('无可用数据.');
					}
				}
				else {
					$('#StorageInfo').html('无可用数据.');
				}
				if(!OrderDOBox.NOPrice){
					//默认价格
					$('#Price').val(data.results.DefaultPrice);
				}
				//价格体系分类
				OrderDOBox.PriceClassIDObj.setValue(data.results.PriceClassID);
				
				switch (OrderDOBox.OrdeType) {
					case 1:
					case 4:
					case 8://增加库存操作不需要验证实际库存,入库,销售退货,调整
					$('#Quantity').keyup(function(){
							
								$('#MaxQuantity').val((Number($(this).val())/Number($('#pToBoxNo').html())).toFixed(OrderDOBox.QuantityDecimal));
								$('#Quantity_b').val($(this).val());
						});
					$('#Quantity_b').keyup(function(){
							
								$('#MaxQuantity').val((Number($(this).val())/Number($('#pToBoxNo').html())).toFixed(OrderDOBox.QuantityDecimal));
								$('#Quantity').val($(this).val());
						});
						break;
					case 2:
					case 3:
					case 5:
					case 6:
					case 7:
					case 10://减少库存操作需要验证实际库存,采购退货,销售发货,赠品,样品,代购,坏货
						$('#Quantity').keyup(function(){
							//if (Number($(this).val()) > 0) {
								if (Number($(this).val()) > OrderDOBox.good) {
									jAlert('不能超过可开单数量,可开单数量为:' + OrderDOBox.good,'提示');
									$(this).val(OrderDOBox.good);
								}else{
									//是否超过配额
									if(OrderDOBox.MaxStock>-1)
									{
										if (Number($(this).val()) > OrderDOBox.MaxStock) {
											jAlert('不能超过配额数量,该客户配额为:' + OrderDOBox.MaxStock,'提示');
											$(this).val(OrderDOBox.MaxStock);
										}
									}
								}
							//}else{
							//	alert('数量必须大于 0 ');
							//	$(this).val(1);
							//}
							$('#Quantity_b').val($(this).val());
						});
						$('#Quantity_b').keyup(function(){
							//if (Number($(this).val()) > 0) {
								if (Number($(this).val()) > OrderDOBox.good) {
									jAlert('不能超过可开单数量,可开单数量为:' + OrderDOBox.good,'提示');
									$(this).val(OrderDOBox.good);
								}else{
									//是否超过配额
									if(OrderDOBox.MaxStock>-1)
									{
										if (Number($(this).val()) > OrderDOBox.MaxStock) {
											jAlert('不能超过配额数量,该客户配额为:' + OrderDOBox.MaxStock,'提示');
											$(this).val(OrderDOBox.MaxStock);
										}
									}
								}
							//}else{
							//	alert('数量必须大于 0 ');
							//	$(this).val(1);
							//}
							$('#Quantity').val($(this).val());
						});
						break;
				}
				
				$('#Quantity').keyup(function(){

								$('#MaxQuantity').val((Number($(this).val())/Number($('#pToBoxNo').html())));
								$('#Quantity_b').val($(this).val());
								
								$('#Price').keyup();
						});
				$('#Quantity_b').keyup(function(){

								$('#MaxQuantity').val((Number($(this).val())/Number($('#pToBoxNo').html())));
								$('#Quantity').val($(this).val());
								
								$('#Price').keyup();
						});
				$('#MaxQuantity').keyup(function(){
							
							$('#Quantity').val((Number($(this).val())*Number($('#pToBoxNo').html())));
							$('#Quantity').keyup();
							
							$('#Quantity_b').val((Number($(this).val())*Number($('#pToBoxNo').html())));
							$('#Quantity_b').keyup();
							
							$('#Price').keyup();
						});
				$('#Price').keyup(function(){
					$('#SumMoney').val(Number($(this).val())*Number($('#Quantity').val()));
				});
				$('#SumMoney').keyup(function(){
					$('#Price').val(Number($(this).val())/Number($('#Quantity').val()));
				});
				$('#ProductInfo').html(data.results.pName + '(' + data.results.pBarcode + ')');
			});
		});
	}
	else
	{
		this.StorageIDB = $('#StorageIDB');
		this.StorageInfoB = $('#StorageInfoB');
		
		//选中默认
		$('#StorageIDB').val(parent.getStorageIDB());
		
		$('#StorageID').change(function(){
			
			$.getJSON('/Services/CAjax.aspx?do=GetProducts&ProductID=' + OrderDOBox.ProductID + '&StorageID=' + $(this).children('option:selected').val(), function(data){
				OrderDOBox.ProductObj = data;
				OrderDOBox.good = 0;
				if (data.results.StorageInfo != null) {
					OrderDOBox.good = Number(data.results.StorageInfo.BeginningStorage);
					if (data.results.StorageInfo.NowStorage) {
						OrderDOBox.good = OrderDOBox.good + Number(data.results.StorageInfo.NowStorage) + Number(data.results.StorageInfo.StorageIn) - Number(data.results.StorageInfo.StorageOut) - Number(data.results.StorageInfo.StorageBad);
						$('#StorageInfo').html('可开单:' + Number(OrderDOBox.good).toFixed(OrderDOBox.QuantityDecimal) + '<br/>库存点:' + Number(data.results.StorageInfo.NowStorage).toFixed(OrderDOBox.QuantityDecimal) + '<br/>入库未核销:' + Number(data.results.StorageInfo.StorageIn).toFixed(OrderDOBox.QuantityDecimal) + '<br/>出库未核销:' + Number(data.results.StorageInfo.StorageOut).toFixed(OrderDOBox.QuantityDecimal) + '<br/>不可用:' + Number(data.results.StorageInfo.StorageBad).toFixed(OrderDOBox.QuantityDecimal));
					}
					else {
						$('#StorageInfo').html('无可用数据.');
					}
				}
				else {
					$('#StorageInfo').html('无可用数据.');
				}

				$('#Quantity').keyup(function(){
					if (Number($(this).val()) > OrderDOBox.good) {
						alert('不能超过可开单数量,可开单数量为:' + OrderDOBox.good);
						$(this).val(OrderDOBox.good);
						$(this).keyup();
					}
				});

				$('#ProductInfo').html(data.results.pName + '(' + data.results.pBarcode + ')');
			});
			$('#StorageIDB').change();
		});
		$('#StorageIDB').change(function(){
			$.getJSON('/Services/CAjax.aspx?do=GetProducts&ProductID=' + OrderDOBox.ProductID + '&StorageID=' + $(this).children('option:selected').val(), function(data){
				OrderDOBox.ProductObjB = data;
				OrderDOBox.goodB = 0;
				if (data.results.StorageInfo != null) {
					OrderDOBox.goodB = Number(data.results.StorageInfo.BeginningStorage);
					if (data.results.StorageInfo.NowStorage) {
						OrderDOBox.goodB = OrderDOBox.goodB + Number(data.results.StorageInfo.NowStorage) + Number(data.results.StorageInfo.StorageIn) - Number(data.results.StorageInfo.StorageOut) - Number(data.results.StorageInfo.StorageBad);
						$('#StorageInfoB').html('可开单:' + Number(OrderDOBox.goodB).toFixed(OrderDOBox.QuantityDecimal) + '<br/>库存点:' + Number(data.results.StorageInfo.NowStorage).toFixed(OrderDOBox.QuantityDecimal) + '<br/>入库未核销:' + Number(data.results.StorageInfo.StorageIn).toFixed(OrderDOBox.QuantityDecimal) + '<br/>出库未核销:' + Number(data.results.StorageInfo.StorageOut).toFixed(OrderDOBox.QuantityDecimal) + '<br/>不可用:' + Number(data.results.StorageInfo.StorageBad).toFixed(OrderDOBox.QuantityDecimal));
					}
					else {
						$('#StorageInfoB').html('无可用数据.');
					}
				}
				else {
					$('#StorageInfoB').html('无可用数据.');
				}

				$('#ProductInfoB').html(data.results.pName + '(' + data.results.pBarcode + ')');
			});
		});
	}
	
	$('#StorageID').change();
	
	if (this.ShowMStock) {
		$('#MStockInfoBox').show();
	}else{
		$('#MStockInfoBox').hide();
	}
	
}

TOrderDOBox.prototype.CheckF = function()
{
	if (Number($('#Quantity').val()) != 0) {
		if (/^[-\+]?\d+(\.\d+)?$/.test($('#Price').val())) {
			if($('#StorageID').children('option:selected').val()!=$('#StorageIDB').children('option:selected').val()){
				var reJson = jQuery.parseJSON('{"StorageInfo":{"id":"' + $('#StorageID').children('option:selected').val() + '","name":"' + $('#StorageID').children('option:selected').text() + '",'+
				'"idB":"'+$('#StorageIDB').children('option:selected').val()+'","nameB":"'+$('#StorageIDB').children('option:selected').text()+'"},' +
				'"ProductInfo":{"id":"' +this.ProductObj.results.ProductsID +'","Barcode":"' +this.ProductObj.results.pBarcode +'","name":"' +this.ProductObj.results.pName +'",' +'"ToBoxNo":"' +this.ProductObj.results.pToBoxNo +'","pUnits":"'+this.ProductObj.results.pUnits+'","pMaxUnits":"'+this.ProductObj.results.pMaxUnits+'","pProducer":"'+this.ProductObj.results.pProducer+'","pExpireDay":"'+this.ProductObj.results.pExpireDay+'","Price":"' +$('#Price').val() +'","Quantity":"' +$('#Quantity').val() +'","Good":"' +this.good +'",'+
				'"GoodB":"' +this.goodB +'","PriceClassID":"'+$('#PriceClassID').val()+'","IsGifts":"'+ (this.tObj?parent.getProdictID():0)+'","MS_Nums":{"StorageID":"'+$('#StorageID').children('option:selected').val()+'","StorageName":"'+$('#StorageID').children('option:selected').text()+'","ProductsID":"'+this.ProductObj.results.ProductsID+'","m_Num":"'+OrderDOBox.MaxStock+'"}}}');
				
				parent.setStorageID($('#StorageID').children('option:selected').val());
				parent.setStorageIDB($('#StorageIDB').children('option:selected').val());
				parent.AddBoxRe(reJson);
				parent.HidUserBox();
			}else{
				jAlert('请选择不同的目标调拨仓库!','提示');
			}
		}else{
			jAlert('请输入价格','提示');
			$('#Price').focus();
		}
	}else{
		jAlert('数量不能为 0 ','提示');
		$('#Quantity').focus();
	}
	
}
