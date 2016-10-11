/**
 *author yangangol
*/

function Twarehouseinventory_do() {
	this.StorageID = 0;
}

Twarehouseinventory_do.prototype.ini = function () {
    $('#listLog').click(function () {
        if ($('#dtime').val() != '') {
            if ($('#InventoryName').val() != '') {
				jConfirm('你确定提交表单信息吗?','提示',function(r){
					if(r)
					{
						var re = warehouseinventory_do.checkF();
	                    if (re) {
	                        $('#reValue').val(re);
	                        $('#bForm').submit();
	                    }
	                    else {
	                        jAlert('列表中无任何数据,请重新选择!','提示');
	                    }
					}
				});
            }
            else {
                jAlert('盘点人的名称不能为空!','提示');
            }
        }
        else {
            jAlert('请选择盘点时间!','提示');
        }
    });
	//重填
	$('#reset').click(function(){
		warehouseinventory_do.sum_num();
	});
	//生成调整单
	$('#to_order').click(function(){
		var reData = '';
		reData = warehouseinventory_do.GetDataListToJson();
		if (reData) {
			jConfirm('确定生成调整单吗?生成后请进入调整单列表进行进一步操作!','提示',function(r){
				if(r)
				{
					$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
					$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
						$(this).show();
						$('#oOrderDateTime').val($('#dtime').val());
						$('#OrderListDataJson').val(reData);
						$('#bForm').attr('action','/orderlist_do-1-8.aspx');
						$('#bForm').submit();
					});
				}
			});
		}else{
			jAlert('没有任何商品,无法生成调整单!','提示');
		}
	});
	this.binTr();
	this.sum_num();
}
Twarehouseinventory_do.prototype.binTr = function(){
	var tr = $('#dLoop').children('tr');
	var tId = '';
	var pNum = null;
	var pNumB = null;
	var pStorage = null;
	if (tr) {
		if (tr.length > 0) {
			for (var i = 0; i < tr.length; i++) {
				tId = $(tr[i]).attr('id').replace('tr_', '');
				pNum = $('#pNum_'+tId);
				pNumB = $('#pNumB_'+tId);

				$(pNum).keyup(function(){
					CheckNumber($(this));
					var _tid = $(this).attr('id').replace('pNum_','');
					$('#pNumB_'+_tid).html(Number($(this).val())-Number($('#pStorage_'+_tid).html()));
					warehouseinventory_do.sum_num();
				}).bind("paste",function(){
					CheckNumber($(this));
					var _tid = $(this).attr('id').replace('pNum_','');
					$('#pNumB_'+_tid).html(Number($(this).val())-Number($('#pStorage_'+_tid).html()));
					warehouseinventory_do.sum_num();
				});
			}
		}
	}
	
}
Twarehouseinventory_do.prototype.sum_num = function()
{
	var tr = $('#dLoop').children('tr');
	var tSum = 0;
	var tSumB = 0;
	if (tr) {
		if (tr.length > 0) {
			for (var i = 0; i < tr.length; i++) {
				tId = $(tr[i]).attr('id').replace('tr_', '');
				CheckNumber($('#pNum_'+tId));
				$('#pNumB_'+tId).html(Number($('#pNum_'+tId).val())-Number($('#pStorage_'+tId).html()));
				tSum += Number($('#pNum_'+tId).val());
				tSumB += Number($('#pNumB_'+tId).html());
			}
		}
	}
	$('#sum_pnum').html(tSum);
	$('#sum_pnum_b').html(tSumB);
}
Twarehouseinventory_do.prototype.checkF = function () {
    var tBoxs_input = $('.tpPList');
    var oQuantity = 0;
    var pid = 0;
    var pnum = 0;
	var stocktakeid = 0;
    var _Json = '';
    if (tBoxs_input) {
        for (var i = 0; i < tBoxs_input.length; i++) {
            if (tBoxs_input[i]) {
                pid = $(tBoxs_input[i]).attr('pid');
                pnum = $(tBoxs_input[i]).val();
                oQuantity = $(tBoxs_input[i]).attr('sQuantity');
				stocktakeid = $(tBoxs_input[i]).attr('stocktakeid');
                if (/^[-\+]?\d+(\.\d+)?$/.test(pid)) {
                    if (pnum == "") {
                        pnum = 0;
                        _Json += '{"stocktakeid":"'+stocktakeid+'","pid":"' + pid + '","pnum":"' + pnum + '","oQuantity":"' + oQuantity + '"},';
                    }
                    else {
                        _Json += '{"stocktakeid":"'+stocktakeid+'","pid":"' + pid + '","pnum":"' + pnum + '","oQuantity":"' + oQuantity + '"},';
                    }
                }
            }
        }
        if (_Json != '') {
            _Json = '{"WarehouseInventory":[' + _Json.substring(0, _Json.length - 1) + ']}';
        }
    }
    return _Json;
}
//整理列表并返回数据
Twarehouseinventory_do.prototype.GetDataListToJson = function()
{
	var tBoxs_input = $('.tpPList');
	var tOrderListJson = '';
	var pid=0;
	var pnum=0;
	var oQuantity=0;
	if (tBoxs_input) {
		for (var i = 0; i < tBoxs_input.length; i++) {
			if (tBoxs_input[i]) {
				pid = $(tBoxs_input[i]).attr('pid');
                pnum = $(tBoxs_input[i]).val();
                oQuantity = $(tBoxs_input[i]).attr('sQuantity');
				if (/^[-\+]?\d+(\.\d+)?$/.test(pid)) {
					if (pnum == "") {
						pnum = 0;
					}
					if ((pnum - oQuantity) != 0) {
						tOrderListJson += '{"OrderListID":0,"OrderID":0,"StorageID":' + this.StorageID + ',' +
						'"ProductsID":' + pid + ',' +
						'"oQuantity":' + (pnum - oQuantity) + ',' +
						'"oPrice":0,' + '"oMoney":0,' + '"StoresSupplierID":0,' +
						'"IsPromotions":0,"oWorkType":0,"IsGifts":0,"PriceClassID":0,"oAppendTime":"\/Date(1289206775426+0800)\/"},';
					}
				}
				
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
		jAlert('列表中没有任何数据,请选择商品!','提示');
	}
	return tOrderListJson;
}
Twarehouseinventory_do.prototype.HidUserBox = function()
{
	CloseBox();
}
function CheckNumber(obj)
{

	if (obj) {
		var t = obj.val();
		if (/^[-\+]?\d+(\.\d+)?$/.test(t)) {
		
		}
		else 
			if (t.substr(t.length - 1) == '.') {
			
			}
			else {
			
				obj.val(0);
			}
	}

}