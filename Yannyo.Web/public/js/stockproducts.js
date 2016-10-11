/**
 * cxty@qq.com
 */
function TStockProductsManage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
	this.sDate = '';
}
TStockProductsManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
	$('#bt_print').click(function(){
		var sDate = $('#sDate').val();
		var StorageID = $('#StorageID').val();
		
		if (sDate != '') {
			//if (Number(StorageID) > 0) {
				window.open('', "top");
				setTimeout(window.open('/stockproduct_print.aspx?sDate=' + $('#sDate').val() + '&StorageID=' + StorageID, "top"), 100);
				return false;
			//}else{
			//	jAlert('请选择仓库.','提示');
			//}
		}else{
			jAlert('请选择时间点.','提示');
		}
	});

	$('#sertch').click(function () {
	    if (document.all) {
	        dw = $(document).width() - 20;
	        dh = $(window).height() - 80;
	    }
	    else {
	        dw = $(document).width() - 20 + 'px';
	        dh = $(window).height() - 80 + 'px';
	    }
	    this.PageBox = dialog("查询盘点数据", 'iframe:warehouseinventorylist.aspx', dw, dh, "iframe", 'HidBox;'); 
	});
	
	$('#cls_z').click(function(){
		var _Show = $(this).val()!='过滤零数据';
		var __Show = false;
		var tr = $('#tBox').children('tbody').children('tr');
		if(tr)
		{
			for(var i=0;i<tr.length;i++)
			{
				if($(tr[i]).children('.l_a'))
				{
					__Show = false;
					for(var j=0;j<$(tr[i]).children('.l_a').length;j++)
					{
						if($(tr[i]).children('.l_a')[j])
						{
							if(Number($($(tr[i]).children('.l_a')[j]).text())!=0)
							{
								__Show = true;
							}
						}
					}
					if (!__Show) {
						if (_Show) {
							$(tr[i]).show();
						}
						else {
							$(tr[i]).hide();
						}
					}
				}
			}
		}
		
		$(this).val($(this).val()=='过滤零数据'?'显示零数据':'过滤零数据');
	});
	
}
TStockProductsManage.prototype.ShowEditBox = function(pid)
{
	this.PageBox = dialog("修改不可用库存",'iframe:stockproduct_do_Edit-'+pid+'.aspx',450,350,"iframe",'HidBox();');
}
TStockProductsManage.prototype.ShowUpdateBox = function (pid) {
    this.PageBox = dialog("修改盘点数据", 'iframe:warehouseinventory_do_Edit-'+pid+'.aspx', 450, 350, "iframe", 'HidBox();');
}
TStockProductsManage.prototype.HidUserBox = function()
{
	//SysComm.HiddenPageBox(this.PageBox);
	CloseBox();
	location=location;
}
TStockProductsManage.prototype.Search = function () {
    var StorageClassName = $("#StorageClassName").val();
    //if (StorageClassName == '') {
        //jAlert("请选择仓库分类！","友情提示");
    //}
    //else {
        this.Act.value = "Search";
        location = 'stockproduct.aspx?Act=Search&StorageID=' + $('#StorageID').val() + '&sDate=' + $('#sDate').val() + '&ProductID=' + $('#ProductID').val() + '&S_key=' + $('#S_key').val() + '&StorageClassName=' + $("#StorageClassName").val() + '&StorageClassNum=' + $("#StorageClassNum").val();
    //}
    //this.PageForm.submit();
}
//TStockProductsManage.prototype.ShowAddDataListBox = function () {
//    if (document.all) {
//        dw = $(document).width() - 20;
//        dh = $(window).height() - 80;
//    }
//    else {
//        dw = $(document).width() - 20 + 'px';
//        dh = $(window).height() - 80 + 'px';
//    }
//    this.PageBox = dialog("表单增加仓库盘点数据", 'iframe:warehouseinventory.aspx', dw, dh, "iframe", 'HidBox;');
//}
