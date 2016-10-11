$(document).ready(function () {
    //页面表格监听
    addTableListener(document.getElementById("tBoxs"), 0, 0);
    window.onscroll = function () {
        var t = document.body.getBoundingClientRect().top;

        var head = document.getElementById("get_data");
        if ((t + document.getElementById("space").offsetTop) < 0) {

            head.style.position = "absolute";
            document.getElementById("get_data").style.top = (-t) + "px";
        }
        else {
            head.style.position = "";
            //$("col_head").addClass("");
        }
    }
   //=======================导入仓库盘点数据信息=================================
   //获得门店
    $('#SName').autocomplete('Services/CAjax.aspx', {
        width: 200,
        scroll: true,
        autoFill: true,
        scrollHeight: 200,
        matchContains: true,
        dataType: 'json',
        extraParams: {
            'do': 'GetStoresList',
            'RCode': Math.random(),
            'StoresName': function () { return $('#SName').val(); }
        },
        parse: function (data) {
            var rows = [];
            var tArray = data.results;
            for (var i = 0; i < tArray.length; i++) {
                rows[rows.length] = {
                    data: tArray[i].value + "(" + tArray[i].info + ")",
                    value: tArray[i].id,
                    result: tArray[i].value,
                    sCode: tArray[i].info,
                    CustomersClassID: tArray[i].CustomersClassID,
                    CustomersClassName: tArray[i].CustomersClassName,
                    PriceClassID: tArray[i].PriceClassID,
                    PriceClassName: tArray[i].PriceClassName,
                    sType: tArray[i].sType,
                    sIsFZYH: tArray[i].sIsFZYH,
                    YHsysName: tArray[i].YHsysName,
                    sContact: tArray[i].sContact,
                    sTel: tArray[i].sTel,
                    sAddress: tArray[i].sAddress,
                    StaffID: tArray[i].StaffID,
                    StaffName: tArray[i].StaffName
                };
            }
            return rows;
        },
        formatItem: function (row, i, max) {
            return row;
        },
        formatMatch: function (row, i, max) {
            return row.value;
        },
        formatResult: function (row) {
            return row.value;
        }
    }).result(function (event, data, formatted, row) {

        $("#StoresID").val((formatted != null) ? formatted : "0");
    }
  );

    //=============================获得产品=============================
    $('#pName').autocomplete('Services/CAjax.aspx', {

        width: 200,
        scroll: true,
        autoFill: true,
        scrollHeight: 200,
        matchContains: true,
        dataType: 'json',
        extraParams: {
            'do': 'GetProductsList',
            'RCode': Math.random(),
            'ProductsName': function () { return $('#pName').val(); }
        },
        parse: function (data) {
            var rows = [];
            var tArray = data.results;
            for (var i = 0; i < tArray.length; i++) {
                rows[rows.length] = {
                    data: tArray[i].value + "(" + tArray[i].info + ")",
                    value: tArray[i].id,
                    result: tArray[i].value
                };
            }
            return rows;
        },
        formatItem: function (row, i, max) {
            return row;
        },
        formatMatch: function (row, i, max) {
            return row.value;
        },
        formatResult: function (row) {
            return row.value;
        }
    }).result(function (event, data, formatted) {
        $("#ProductID").val((formatted != null) ? formatted : "0");
    }
  );
    //===========================联营库存========================
    $("#tjType").change(function () {
        var t_count = $("#tjType").children('option:selected').val();
        if (t_count == 0) {
            $("#div_region").removeAttr("style");
            $("#div_region").attr("style", "visibility:hidden");
        }
        if (t_count == 1) {
            $("#div_region").removeAttr("style");
            $("#div_region").attr("style", "visibility:visible");
        }

    });
    $(window).load(function () {
        var t_count = $("#tjType").children('option:selected').val();
        if (t_count == 1) {
            $("#div_region").removeAttr("style");
            $("#div_region").attr("style", "visibility:visible");
        }
    });
    //查询提交
    $("#submit_btn").click(function () {
        $("div#winAll").fadeIn("slow");
        $("#reginID").val($("#sel_regionName").children('option:selected').val());
        $("#aID").val($("#Associated").children('option:selected').val());
        $("#tType").val($("#tjType").children('option:selected').val());
        $('#bForm').submit();
    });

    //导出
    $("#export_data").click(function () {
        var _url = '/associated_details.aspx?Act=Export&Date=' + $("#bDate").val() + '&tjType=' + $("#tjType").children('option:selected').val() + '&Associated=' + $("#Associated").children('option:selected').val() + '&reginID=' + $("#sel_regionName").children('option:selected').val();
        window.open('', "top");
        setTimeout(window.open(_url, "top"), 100);
    });
});
//============================联营库存=========================
function sendInFo(sID, aID, sDate, sName) {
    if (document.all) {
        this.dw = $(document).width() - 100;
        this.dh = $(window).height() - 100;
    }
    else {
        this.dw = $(document).width() - 100 + 'px';
        this.dh = $(window).height() - 100 + 'px';
    }
    this.PageBox = dialog("联营库存产品详情", 'iframe:/associated_details_do.aspx?sid=' + sID + '&aid=' + aID + '&sDate=' + sDate + '&sName=' + sName + '', this.dw, this.dh, "iframe", '');
}