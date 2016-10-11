/**
 * @author Cxty
 */
function TStockProduct_invoicing()
{
	
}
TStockProduct_invoicing.prototype.ini = function()
{
	$('#bt_ok').click(function(){
		var sDate = $('#sDate').val();
		var StorageID = $('#StorageID').children('option:selected').val();
		
		if(sDate=='')
		{
			jAlert('请选择时间点!','提示');
		}else if(Number(StorageID)>0){
			$('#form1').submit();
		}else{
			jAlert('请选择仓库!','提示');
		}
	});
	$('#bt_reset').click(function(){
		var sDate = $('#sDate').val();
		if(sDate=='')
		{
			jAlert('请选择时间点!','提示');
		}else{
			jConfirm('分析数据较大,该过程大约需(1-2)分钟,请不要关闭本页面,确保网络顺畅,并耐心等待!<br><b>注意:请不要随意重置数据,重置后将直接反应到系统进销存报表,以及系统商品成本价相关数据.</b>', '提示', function(r){
				if (r) {
					$("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
					
					$("#floatBoxBg").animate({
						opacity: "0.5"
					}, "normal", function(){
						$(this).show();
						
						jQuery.post('/stockproduct_invoicing.aspx?act=reset&format=Json',{sDate:$('#sDate').val()},function(data){
							if(data)
							{
								jAlert(data.results.msg,'提示',function(){
									$("#floatBoxBg").hide();
								});
							}
						});
					});
				}
			});
		}
	});
	this.binTr();
}
TStockProduct_invoicing.prototype.binTr = function()
{
	var tr = $('#dLoop').children('tr');
	var tId = '';
	var eQuantity = null;
	var Price = null;
	var eMoney = null;
	
	var bQuantity = null;
	var bMoney = null;
	var InQuantity = null;
	var InMoney = null;
	var OutQuantity = null;
	var OutMoney = null;
	
	var bt_ok = null;
	
	if (tr) {
		if (tr.length > 0) {
			for (var i = 0; i < tr.length; i++) {
				tId = $(tr[i]).attr('id').replace('tr_','');
				//获取对象
				eQuantity = $('#eQuantity_'+tId);
				Price = $('#Price_'+tId);
				eMoney = $('#eMoney_'+tId);
				
				bQuantity = $('#bQuantity_'+tId);
				bMoney = $('#bMoney_'+tId);
				InQuantity = $('#InQuantity_'+tId);
				InMoney = $('#InMoney_'+tId);
				OutQuantity = $('#OutQuantity_'+tId);
				OutMoney = $('#OutMoney_'+tId);
				
				bt_ok = $('#bt_ok_'+tId);
				$(bt_ok).hide();
				
				//加事件
				$(eQuantity).keyup(function(){
					CheckNumber(eQuantity);
					var _tid = $(this).attr('id').replace('eQuantity_','');
					$('#eMoney_'+_tid).val(Number($(this).val())*Number($('#Price_'+_tid).val()));
					$('#bt_ok_'+_tid).show();
				}).bind("paste",function(){
					CheckNumber(eQuantity);
					var _tid = $(this).attr('id').replace('eQuantity_','');
					$('#eMoney_'+_tid).val(Number($(this).val())*Number($('#Price_'+_tid).val()));
					$('#bt_ok_'+_tid).show();
				});
				
				$(Price).keyup(function(){
					CheckNumber(Price);
					var _tid = $(this).attr('id').replace('Price_','');
					$('#eMoney_'+_tid).val(Number($('#eQuantity_'+_tid).val())*Number($(this).val()));
					$('#bt_ok_'+_tid).show();
				}).bind("paste",function(){
					CheckNumber(Price);
					var _tid = $(this).attr('id').replace('Price_','');
					$('#eMoney_'+_tid).val(Number($('#eQuantity_'+_tid).val())*Number($(this).val()));
					$('#bt_ok_'+_tid).show();
				});
				
				$(eMoney).keyup(function(){
					CheckNumber(eMoney);
					var _tid = $(this).attr('id').replace('eMoney_','');
					if (Number($('#eQuantity_' + _tid).val()) != 0) {
						$('#Price_' + _tid).val(Number($(this).val()) / Number($('#eQuantity_' + _tid).val()));
					}else{
						$('#Price_' + _tid).val(0);
					}
					$('#bt_ok_'+_tid).show();
				}).bind("paste",function(){
					CheckNumber(eMoney);
					var _tid = $(this).attr('id').replace('eMoney_','');
					if (Number($('#eQuantity_' + _tid).val()) != 0) {
						$('#Price_' + _tid).val(Number($(this).val()) / Number($('#eQuantity_' + _tid).val()));
					}else{
						$('#Price_' + _tid).val(0);
					}
					$('#bt_ok_'+_tid).show();
				});
				
				$(bQuantity).keyup(function(){
					CheckNumber(bQuantity);
					var _tid = $(this).attr('id').replace('bQuantity_','');
					$('#eQuantity_'+_tid).val(Number($(this).val())+Number($('#InQuantity_'+_tid).val())-Number($('#OutQuantity_'+tid).val()));
				}).bind("paste",function(){
					CheckNumber(bQuantity);
					var _tid = $(this).attr('id').replace('bQuantity_','');
					$('#eQuantity_'+_tid).val(Number($(this).val())+Number($('#InQuantity_'+_tid).val())-Number($('#OutQuantity_'+tid).val()));
				});
				$(bMoney).keyup(function(){
					CheckNumber(bMoney);
					var _tid = $(this).attr('id').replace('bMoney_','');
					$('#eMoney_'+_tid).val(Number($(this).val())+Number($('#InMoney_'+_tid).val())-Number($('#OutMoney_'+tid).val()));
				}).bind("paste",function(){
					CheckNumber(bMoney);
					var _tid = $(this).attr('id').replace('bMoney_','');
					$('#eMoney_'+_tid).val(Number($(this).val())+Number($('#InMoney_'+_tid).val())-Number($('#OutMoney_'+tid).val()));
				});
				
				$(InQuantity).keyup(function(){
					CheckNumber(InQuantity);
					var _tid = $(this).attr('id').replace('InQuantity_','');
					$('#eQuantity_'+_tid).val(Number($(this).val())+Number($('#bQuantity_'+_tid).val())-Number($('#OutQuantity_'+tid).val()));
				}).bind("paste",function(){
					CheckNumber(InQuantity);
					var _tid = $(this).attr('id').replace('InQuantity_','');
					$('#eQuantity_'+_tid).val(Number($(this).val())+Number($('#bQuantity_'+_tid).val())-Number($('#OutQuantity_'+tid).val()));
				});
				$(InMoney).keyup(function(){
					CheckNumber(InMoney);
					var _tid = $(this).attr('id').replace('InMoney_','');
					$('#eMoney_'+_tid).val(Number($(this).val())+Number($('#bMoney_'+_tid).val())-Number($('#OutMoney_'+tid).val()));
				}).bind("paste",function(){
					CheckNumber(InMoney);
					var _tid = $(this).attr('id').replace('InMoney_','');
					$('#eMoney_'+_tid).val(Number($(this).val())+Number($('#bMoney_'+_tid).val())-Number($('#OutMoney_'+tid).val()));
				});
				
				$(OutQuantity).keyup(function(){
					CheckNumber(OutQuantity);
					var _tid = $(this).attr('id').replace('OutQuantity_','');
					$('#eQuantity_'+_tid).val(Number($('#bQuantity_'+_tid).val())+Number($('#InQuantity_'+tid).val())-Number($(this).val()));
				}).bind("paste",function(){
					CheckNumber(OutQuantity);
					var _tid = $(this).attr('id').replace('OutQuantity_','');
					$('#eQuantity_'+_tid).val(Number($('#bQuantity_'+_tid).val())+Number($('#InQuantity_'+tid).val())-Number($(this).val()));
				});
				$(OutMoney).keyup(function(){
					CheckNumber(OutMoney);
					var _tid = $(this).attr('id').replace('OutMoney_','');
					$('#eMoney_'+_tid).val(Number($('#bMoney_'+_tid).val())+Number($('#InMoney_'+tid).val())-Number($(this).val()));
				}).bind("paste",function(){
					CheckNumber(OutMoney);
					var _tid = $(this).attr('id').replace('OutMoney_','');
					$('#eMoney_'+_tid).val(Number($('#bMoney_'+_tid).val())+Number($('#InMoney_'+tid).val())-Number($(this).val()));
				});
				
				//保存修改
				$(bt_ok).click(function(){
					var _tid = $(this).attr('id').replace('bt_ok_','');
					jQuery.post('/stockproduct_invoicing.aspx?act=update&format=Json',{'ReportInvoicingID':_tid,'eQuantity':$('#eQuantity_'+_tid).val(),'eMoney':$('#eMoney_'+_tid).val(),'bQuantity':$('#bQuantity_'+_tid).val(),'bMoney':$('#bMoney_'+_tid).val(),'InQuantity':$('#InQuantity_'+_tid).val(),'InMoney':$('#InMoney_'+_tid).val(),'OutQuantity':$('#OutQuantity_'+_tid).val(),'OutMoney':$('#OutMoney_'+_tid).val(),'Price':$('#Price_'+_tid).val()},function(data){
						if (data.results.state == 'True') {
							jAlert(data.results.msg,'提示');
							$('#bt_ok_'+data.results.ReportInvoicingID).hide();
						}else{
							jAlert(data.results.msg,'提示');
							$('#bt_ok_'+data.results.ReportInvoicingID).show();
						}
					});
				});
			}
		}
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
