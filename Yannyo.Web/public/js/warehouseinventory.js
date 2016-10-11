/**
 *author yangangol
*/

function Twarehouseinventory_add_list() {

}

Twarehouseinventory_add_list.prototype.ini = function () {
    $('#listLog').click(function () {
        if ($('#dtime').val() != '') {
            if ($('#InventoryName').val() != '') {
				jConfirm('你确定提交表单信息吗?','提示',function(r){
					if(r)
					{
						var re = warehouseinventory_add_list.checkF();
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
	$('#reset').click(function(){
		warehouseinventory_add_list.sum_num();
	});
	this.binTr();
	this.sum_num();
}
Twarehouseinventory_add_list.prototype.binTr = function(){
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
					warehouseinventory_add_list.sum_num();
				}).bind("paste",function(){
					CheckNumber($(this));
					var _tid = $(this).attr('id').replace('pNum_','');
					$('#pNumB_'+_tid).html(Number($(this).val())-Number($('#pStorage_'+_tid).html()));
					warehouseinventory_add_list.sum_num();
				});
			}
		}
	}
	
}
Twarehouseinventory_add_list.prototype.sum_num = function()
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
Twarehouseinventory_add_list.prototype.checkF = function () {
    var tBoxs_input = $('.tpPList');
    var oQuantity = 0;
    var pid = 0;
    var pnum = 0;
    var _Json = '';
    if (tBoxs_input) {
        for (var i = 0; i < tBoxs_input.length; i++) {
            if (tBoxs_input[i]) {
                pid = $(tBoxs_input[i]).attr('pid');
                pnum = $(tBoxs_input[i]).val();
                oQuantity = $(tBoxs_input[i]).attr('pOquantity');
                if (/^[-\+]?\d+(\.\d+)?$/.test(pid)) {
                    if (pnum == "") {
                        pnum = 0;
                        _Json += '{"stocktakeid":"0","pid":"' + pid + '","pnum":"' + pnum + '","oQuantity":"' + oQuantity + '"},';
                    }
                    else {
                        _Json += '{"stocktakeid":"0","pid":"' + pid + '","pnum":"' + pnum + '","oQuantity":"' + oQuantity + '"},';
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