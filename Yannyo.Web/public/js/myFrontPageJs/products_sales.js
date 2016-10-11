//产品日均销量
$(document).ready(function () {
    //监听表格实现表头下拉滚动
    addTableListener(document.getElementById("tBoxs"), 0, 0);
    window.onscroll = function () {
        var t = document.body.getBoundingClientRect().top;

        var head = document.getElementById("title_space");
        if ((t + document.getElementById("space").offsetTop) < 0) {

            head.style.position = "absolute";
            document.getElementById("title_space").style.top = (-t) + "px";
        }
        else {
            head.style.position = "";
        }
    }


    //选择改变
    $("#tType").change(function () {
        var getValue = $("#tType").children('option:selected').val();
        if (getValue == "0") {
            $(".showOrhidden").removeAttr("style");
            $(".showOrhidden").attr("style", "visibility:visible");
        }
        if (getValue == "1") {
            $(".showOrhidden").removeAttr("style");
            $(".showOrhidden").attr("style", "visibility:hidden");
        }
        if (getValue == "2") {
            $(".showOrhidden").removeAttr("style");
            $(".showOrhidden").attr("style", "visibility:hidden");
        }
    });

    //查询提交
    $("#submit_btn").click(function () {
        $("div#winAll").fadeIn("slow");
        $("#reginID").val($("#tType").children('option:selected').val());
        $('#bForm').submit();
    });

    //导出数据
    $("#export_data").click(function () {
        var _url = '/products_sales.aspx?Act=act&bDate=' + $("#bDate").val() + '&eDate=' + $(".eDate").val();
        window.open('', "top");
        setTimeout(window.open(_url, "top"));
    });
});

function sendInFo(pID, pName, pBarcode, sID, bDate, eDate) {

    if (document.all) {
        this.dw = $(document).width() - 100;
        this.dh = $(window).height() - 100;
    }
    else {
        this.dw = $(document).width() - 100 + 'px';
        this.dh = $(window).height() - 100 + 'px';
    }
    this.PageBox = dialog("联营库存产品详情", 'iframe:/products_sales_storehouse.aspx?pid=' + pID + '&pname=' + pName + '&pbarcode=' + pBarcode + '&sid=' + sID + '&bDate=' + bDate + '&eDate=' + eDate + '', this.dw, this.dh, "iframe", '');
}