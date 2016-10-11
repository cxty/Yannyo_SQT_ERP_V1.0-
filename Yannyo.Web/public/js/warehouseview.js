/**
*yangangol 
*/

function TStockProductsManage() {
	if (document.all) {
		this.dw = $(document).width() - 20;
		this.dh = $(window).height() - 80;
	}
	else {
		this.dw = $(document).width() - 20 + 'px';
		this.dh = $(window).height() - 80 + 'px';
	}
}
TStockProductsManage.prototype.ini = function () {
    $('#add').click(function () {
        var sDate = $('#sDate').val();
        var StorageID = $('#StorageID').children('option:selected').val();

        if (sDate != '') {
            if (Number(StorageID) > 0) {
                
                StockProductsManage.PageBox = dialog("表单增加仓库盘点数据", 'iframe:warehouseinventory.aspx?sDate=' + sDate + '&StorageID=' + StorageID, StockProductsManage.dw, StockProductsManage.dh, "iframe", 'HidBox;');
                return false;
            } else {
                alert('请选择仓库.');
            }
        } else {
            alert('请选择时间点.');
        }
    });
    //var gvn = $('#tBoxs').clone(true).removeAttr("id");
    //$(gvn).find("tr:not(:first)").remove();
    //$('#tBoxs').before(gvn);
    //$('#tBoxs').find("tr:first").remove();
    //$('#tBoxs').wrap("<div style='height:400px; overflow-y: scroll;overflow-x:hidden; overflow: auto; padding: 0;margin: 0;'></div>");
}
TStockProductsManage.prototype.ShowHouseInventoryList = function (StockID) {
    //$().ready(function () {
        var storageID = $('#StorageName').val();
        var sUpdateTime = $('#sUpdateTime').val();

        this.page = dialog("查询盘点数据信息", 'iframe:warehouseinventorylist_Edit-' + StockID + '.aspx', this.dw, this.dh, "iframe", 'HidBox;');
    //});
    
}
TStockProductsManage.prototype.HidUserBox = function () {
	//    SysComm.HiddenPageBox(this.PageBox);
	CloseBox();
	//$("#form1").animate({ opacity: "0.5" }, "normal", function () { $(this).show(); location = location; });
}

