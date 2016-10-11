/**
 * @author yangangol
 */
function TStoreHouseStorage_add_list()
{
	
}
TStoreHouseStorage_add_list.prototype.ini = function () {

    $('#listLog').click(function () {
        if ($('#SName').val() != '') {
            if ($('#sDate').val() != '') {
                if (confirm('您确定要提交表单信息到库吗？')) {
                    var re = StoreHouseStorage_add_list.CheckF();
                    if (re) {
                        $('#reValue').val(re);
                        $('#bForm').submit();
                    }
                }
            }
            else {
                alert('请选择添加日期！');
            }
        }
        else {
            alert("门店名称不能为空！");
        }
    });
}
TStoreHouseStorage_add_list.prototype.CheckF = function () {
    var tBoxs_input = $('input:.tpPList'); //.children('input');
    var pid = 0;
    var pnum = 0;
    var pMoney = 0;
    var _Json = '';
    if (tBoxs_input) {
        for (var i = 0; i < tBoxs_input.length; i++) {
            if (tBoxs_input[i]) {
                pid = $(tBoxs_input[i]).attr('pid');
                pnum = $(tBoxs_input[i]).val();
                pMoney = $(tBoxs_input[i]).attr('pMoney');
                if (/^[-\+]?\d+(\.\d+)?$/.test(pid)) {
                    if (pnum == "") {
                        pnum = 0;
                        _Json += '{"pid":"' + pid + '","pnum":"' + pnum + '，"pMoney":"' + pMoney + '""},';
                    }
                    else {
                        _Json += '{"pid":"' + pid + '","pnum":"' + pnum + '，"pMoney":"' + pMoney + '""},';
                    }
                }
            }
        }
        if (_Json != '') {
            _Json = '{"StoreHouseStorage":[' + _Json.substring(0, _Json.length - 1) + ']}';
        }
    }
    return _Json;
}
