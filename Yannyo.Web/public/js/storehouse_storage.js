function StorehouseStorageManage() {
    this.PageBox = null;
    this.PageForm = null;

	if (document.all) {
        this.dw = $(document).width() - 20;
        this.dh = $(window).height() - 80;
    }
    else {
        this.dw = $(document).width() - 20 + 'px';
        this.dh = $(window).height() - 80 + 'px';
    }
}
StorehouseStorageManage.prototype.ini = function () {
    this.PageForm = document.getElementById('form1');
}
StorehouseStorageManage.prototype.HidUserBox = function () {
	//SysComm.HiddenPageBox(this.PageBox);
    CloseBox();
    $("#form1").animate({ opacity: "0.5" }, "normal", function () { $(this).show(); location = location; });
}
StorehouseStorageManage.prototype.ShowAddUserBox = function () {
    this.PageBox = dialog("新建门店仓库数据", 'iframe:/storehousestorage_do-Add.aspx', 450, 400, "iframe", 'HidBox();'); // SysComm.ShowPageBox('sales_do-Add.aspx',450,400);
}
StorehouseStorageManage.prototype.ShowAddPriceUserBox = function () {
    this.PageBox = dialog("新建门店产品单价数据", 'iframe:/storehousestorageprice_do-Add.aspx', 450, 400, "iframe", 'HidBox();'); // SysComm.ShowPageBox('sales_do-Add.aspx',450,400);
}
StorehouseStorageManage.prototype.ShowimportdataBox = function () {
   jConfirm('导入库数据，最小单位为天【匹配数据后】请勿再次导入相同数据！确定导入数据吗？','导入提示',function(r){
    if(r){
     this.PageBox = dialog("导入仓库数据", 'iframe:/storehousestorageadd.aspx', 500, 450, "iframe", 'HidBox();');
    }
   });
}

StorehouseStorageManage.prototype.ShowSyndataBox = function () {
    this.PageBox = dialog("匹配门店仓库数据", 'iframe:/storehousestorage_syndata.aspx', 500, 200, "iframe", 'HidBox();'); //SysComm.ShowPageBox('sales_syndata.aspx',450,400);
}
StorehouseStorageManage.prototype.ShowSyndataPriceBox = function () {
    this.PageBox = dialog("匹配门店产品单价数据", 'iframe:/StorehouseStoragPrice_Syndata.aspx', 500, 200, "iframe", 'HidBox();'); //SysComm.ShowPageBox('sales_syndata.aspx',450,400);
}
StorehouseStorageManage.prototype.ShowSynPricedataBox = function () {
    this.PageBox = dialog("导入产品价格数据", 'iframe:/storehouseproductspriceinfo.aspx', 500, 450, "iframe", 'HidBox();'); //SysComm.ShowPageBox('sales_syndata.aspx',450,400);
}
StorehouseStorageManage.prototype.ShowimportdataListBox = function () {

    jConfirm('执行【导入仓库数据】后，请勿同一天再次表单提交数据！确定表单提交数据吗？', '表单提交提示', function (r) {
        if (r) {
            this.PageBox = dialog("表单增加门店仓库数据", 'iframe:storehousestorage_add_list.aspx', this.dw, this.dh, "iframe", 'HidBox;');
        }
    });
}
StorehouseStorageManage.prototype.Delt = function () {
    var tValue = '';
    for (var i = 0; i < this.PageForm.elements.length; i++) {
        if (this.PageForm.elements[i].name == "cCheck") {
            e = this.PageForm.elements[i];
            if (e.checked == true) {
                tValue += e.value + ',';
            }
        }
    }
    if (Trim(tValue) != '') {
        jConfirm('确定删除选中数据吗？', '删除提示', function (r) {
            if (r) {
                this.PageBox = dialog("删除门店仓库数据", 'iframe:storehousestorage_do_Del-' + tValue + '.aspx', 500, 200, "iframe", 'HidBox();');
            }
        });
    }
    tValue = null;
}
StorehouseStorageManage.prototype.ShowDelUserBox = function (idStr) {
    jConfirm('确定删除该条数据吗？', '删除提示', function (r) {
     if(r){
      this.PageBox = dialog("删除门店仓库数据", 'iframe:storehousestorage_do_Del-' + idStr + '.aspx', 500, 200, "iframe", 'HidBox();');
     }
    });
}
StorehouseStorageManage.prototype.ShowEditUserBox = function (idStr) {
    this.PageBox = dialog("修改门店仓库数据", 'iframe:storehousestorage_do_Edit-' + idStr + '.aspx', 450, 400, "iframe", 'HidBox();'); //SysComm.ShowPageBox('sales_do_Edit-'+idStr+'.aspx',450,400);
}
StorehouseStorageManage.prototype.DeltPrice = function () {
    var tValue = '';
    for (var i = 0; i < this.PageForm.elements.length; i++) {
        if (this.PageForm.elements[i].name == "cCheck") {
            e = this.PageForm.elements[i];
            if (e.checked == true) {
                tValue += e.value + ',';
            }
        }
    }
    if (Trim(tValue) != '') {
        jConfirm('确定删除选中数据吗？', '删除提示', function (r) {
            if (r) {
                this.PageBox = dialog("删除门店产品单价数据", 'iframe:storehousestorageprice_do_Del-' + tValue + '.aspx', 500, 200, "iframe", 'HidBox();');
            }
        });
    }
    tValue = null;
}
StorehouseStorageManage.prototype.ShowDelPriceUserBox = function (idStr) {
    jConfirm('确定删除该条数据吗？', '删除提示', function (r) {
        if (r) {
            this.PageBox = dialog("删除门店产品单价数据", 'iframe:storehousestorageprice_do_Del-' + idStr + '.aspx', 500, 200, "iframe", 'HidBox();');
        }
    });
}

StorehouseStorageManage.prototype.ShowEditPriceUserBox = function (idStr) {
    this.PageBox = dialog("修改门店产品单价数据", 'iframe:storehousestorageprice_do_Edit-' + idStr + '.aspx', this.dw, this.dh, "iframe", 'HidBox();'); //SysComm.ShowPageBox('sales_do_Edit-'+idStr+'.aspx',450,400);
}

StorehouseStorageManage.prototype.ShowImportData = function () {
    if (document.all) {
        this.dw = $(document).width() - 20;
        this.dh = $(window).height() - 80;
    }
    else {
        this.dw = $(document).width() - 20 + 'px';
        this.dh = $(window).height() - 80 + 'px';
    }
    this.PageBox = dialog("查询客户库存导入数据详情", 'iframe:storehousestorageselected.aspx', this.dw, this.dh, "iframe", 'HidBox;');
}