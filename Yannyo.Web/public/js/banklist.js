/**
 * @author Cxty
 */
function TBankList()
{
	this.PageBox = null;
}
TBankList.prototype.ini = function () {

    $('#bt_del').click(function () {
        var checkbox = $("input[name=cCheck]");
        var tValue = '';
        for (var i = 0; i < checkbox.length; i++) {
            if (checkbox[i].name == "cCheck") {
                e = checkbox[i];
                if (e.checked == true) {
                    tValue += e.value + ',';
                }
            }
        }
        if (Trim(tValue) != '') {
            BankList.PageBox = dialog("删除", 'iframe:/bank_do_Del-' + tValue + '.aspx', 450, 200, "iframe", 'HidBox();');
        }
        tValue = null;

    });
    $('#bt_add').click(function () {
        BankList.PageBox = dialog("添加", 'iframe:/bank_do-Add.aspx', 450, 300, "iframe", 'HidBox();');
    });
}
TBankList.prototype.ShowDelBox = function(idStr) {
    jConfirm('确定删除此条数据吗？','友情提示',function(r){
       if(r)
       {
        this.PageBox = dialog("删除",'iframe:/bank_do_Del-'+idStr+'.aspx',450,200,"iframe",'HidBox();');
       }
    });
}
TBankList.prototype.ShowEditBox = function(idStr)
{
	this.PageBox = dialog("修改",'iframe:/bank_do_Edit-'+idStr+'.aspx',450,300,"iframe",'HidBox();');
}
TBankList.prototype.HidBox = function()
{
	CloseBox();
	location=location;
}
TBankList.prototype.ShowSetBeginBox = function(idStr)
{
	this.PageBox = dialog("修改",'iframe:/bank_do_Edit-'+idStr+'.aspx?Begin=1',450,300,"iframe",'HidBox();');
}
