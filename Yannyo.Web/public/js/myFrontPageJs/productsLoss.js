//报损统计
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
    $("#submit_btn").click(function () {
        //获取联营下拉值赋值到input中
        var Associated = $('#Associated').children('option:selected').val();
        document.getElementById("_Associated").value = Associated;
        //提交表单
        if ($("#sDate").val() > $("#stDate").val()) {
            jAlert("日期选择错误，请重新选择日期！", "友情提示");
        }
        else {
            $("div#winAll").fadeIn("slow");
            var t = $('#bForm');
            t.submit();
        }
    });
    //导出数据
    $("#export_data").click(function () {
        var sDate = $("#sDate").val();
        var stDate = $("#stDate").val();
        var _Associated = $("#Associated").children('option:selected').val();
        var _url = '/productsloss.aspx?Act=act&_Associated=' + _Associated + '&sDate=' + sDate + '&stDate=' + stDate;
        window.open('', "top");
        setTimeout(window.open(_url, "top"), 100);
    });
});

function sendInfo(sid, sName, pid, pName, pBarcode, sDate, stDate) {
    if (document.all) {
        this.dw = $(document).width() - 100;
        this.dh = $(window).height() - 100;
    }
    else {
        this.dw = $(document).width() - 100 + 'px';
        this.dh = $(window).height() - 100 + 'px';
    }
    this.PageBox = dialog("报损数据详情", 'iframe:/productsloss_details.aspx?act=act&sid=' + escape(sid) + '&sname=' + escape(sName) + '&pid=' + escape(pid) + '&pname=' + pName + '&pbard=' + escape(pBarcode) + '&sDate=' + sDate + '&stDate=' + stDate, this.dw, this.dh, "iframe", '');
}