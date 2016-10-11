//明细及总账
$(document).ready(function () {
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

    //打开科目树
    $("#subject").click(function () {
        $("#winType").fadeIn("slow");
    });

    //关闭科目选择
    $("#winClose").click(function () {
        $("#winType").fadeOut("slow");
    });
    $("#res_btn").click(function () {
        $("#winType").fadeOut("slow");
    });
    //提交
    $("#btn_submit").click(function () {
        $("#seType").val($("#sType").children('option:selected').val());
        $("#get_status").val($("#status").children('option:selected').val());
        var subject = $("#subject").val();
        if (subject != '') {
            $("div#winAll").fadeIn("slow");
            $("#bForm").submit();
        }
        else {
            jAlert("科目选择错误，请核对后重新选择！", "友情提示");
        }
    });

    //科目选择点击确定
    $("#win_btn").click(function () {
        var getTreeNode = $("#treeNode").jstree('get_checked');

        var ids = "";
        for (i = 0; i < getTreeNode.size(); i++) {
            ids += getTreeNode[i].id.replace('t_', '') + ',';
            var sName = $("#treeNode").jstree('get_text');
        }
        if (ids == "") {
            jAlert("请选择科目！", "友情提示");
        }
        else {
            $("#winType").fadeOut("slow");
            $("#subject").val(sName);
            $("#subject_hd").val(ids);

        }
    });

    //科目树
    $("#treeNode").jstree({
        "json_data": { "ajax": {
            "url": "/Services/CAjax.aspx",
            "data": function (n) {
                return {
                    "do": "DataClass",
                    "doValue": "select",
                    "DataType": "FeesSubjectClass",
                    "NOCaches": 0,
                    "pid": n.attr ? n.attr("id").replace("t_", "") : -1
                };
            }
        }
        },
        "core": {
            "initially_open": ["t_0"]
        },
        "ui": {},
        "lang": {
            loading: "加载中……"
        },

        "plugins": ["themes", "json_data", "ui", "crrm", "types", "dnd", "hotkeys", "dnd", "contextmenu", "cCode", "checkbox", "data"]

    });
});