//发生额及余额
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

    $("#className").click(function () {
        $("#winType").fadeIn("slow");
    });

    //页面加载
    $(window).load(function () {
        var getType = $("#selectType").children('option:selected').val();
        if (getType == 1) {
            $("#Feesubject").removeAttr("style");
            $("#Feesubject").attr("style", "visibility:visible");
        }
    });

    //查询类型
    $("#selectType").change(function () {
        var getType = $("#selectType").children('option:selected').val();
        if (getType == 1) {
            $("#Feesubject").removeAttr("style");
            $("#Feesubject").attr("style", "visibility:visible");
        }
        if (getType == 0) {
            $("#Feesubject").removeAttr("style");
            $("#Feesubject").attr("style", "visibility:hidden");
        }
    });

    //提交数据
    $("#btn_submit").click(function () {

        var selectType = $("#selectType").children('option:selected').val();
        $("#sType").val(selectType);
        var get_treeNode = $("#get_treeNode").val();
        var getClass = $("#className").val();
        var cookie_className_val = $("#cookie_className").val();
        var bDate = $("#bDate").val();
        var eDate = $("#eDate").val();
        var status = $("#status").children('option:selected').val();
        $("#get_status").val(status);
        if (bDate > eDate) {
            jAlert("日期选择错误，请核对后重新选择！", "友情提示");
        }
        else {
            if (selectType == 0) {
                $("div#winAll").fadeIn("slow");
                $("#bForm").submit();
            }
            if (selectType == 1) {
                if (getClass != '') {
                    if (get_treeNode != '') {
                        $("div#winAll").fadeIn("slow");
                        $("#bForm").submit();
                    }
                    else {
                        document.getElementById("get_treeNode").value = cookie_className_val;
                        $("div#winAll").fadeIn("slow");
                        $("#bForm").submit();
                    }
                }
                else {
                    jAlert("请选择科目！", "友情提示");
                }
            }
        }
    });

    //科目选择点击确定
    $("#win_btn").click(function () {
        $("#get_tree_Node").empty();
        var getTreeNode = $("#trTree").jstree('get_checked');

        var ids = "";
        for (i = 0; i < getTreeNode.size(); i++) {
            ids += getTreeNode[i].id.replace('t_', '') + ',';
            var sName = $("#trTree").jstree('get_text');
        }
        if (ids == "") {
            jAlert("请选择科目！", "友情提示");
        }
        else {
            $("#winType").fadeOut("slow");
            $("#get_treeNode").val(ids);
            $("#className").val(sName);
        }
    });


    //科目树
    $("#trTree").jstree({
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

    //关闭弹窗
    $("#winClose").click(function () {
        $("#winType").fadeOut("slow");
    });
    $("#res_btn").click(function () {
        $("#winType").fadeOut("slow");
    });

});

  