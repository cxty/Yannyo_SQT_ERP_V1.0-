$(document).ready(function () {
    //全选
    $("#cheAll").click(function () {
        $("#edTable tr:gt(1)").each(function () {
            $(this).find(".checkID").get(0).checked = $("#cheAll").get(0).checked;
        });
    });
    //提交表单
    $("#bt_ok").click(function () {
        //判断左边是否有选中
        var objs = document.getElementsByName("checkID");
        var Content = "";
        for (var i = 0; i < objs.length; i++) {
            if (objs[i].type == "checkbox") {
                if (objs[i].checked) {
                    Content += objs[i].value + ",";
                }
            }
        }
        if (Content != '') {
            //判断右边的科目是否有选中
            var getTreeNode = $("#FeesSubjectID").val();
            var getTreeName = $("#FeesSubjectName").val();
            var sFeeID = $("#sFeeID").val();
            var lastName = $("#lastName").val();
            if (getTreeNode == sFeeID) {
                jAlert("无法将凭证信息移动至节点【" + getTreeName + "】下，请核对后重新选择！", "错误提示");
            }
            else {
                if (getTreeNode != '') {
                    jConfirm('是否将左边所选凭证移动至【' + getTreeName + '】科目下？', '友情提示', function (r) {
                        if (r) {
                            $("div#winAll").fadeIn("slow");
                            $.post('/feessubjectclass_do_move.aspx?Content=' + Content + '&treeNode=' + getTreeNode + '&sFeeID=' + sFeeID + '&getTreeName=' + getTreeName + '&lastName=' + lastName, '', function (data) {
                                $("div#winLoding").fadeOut("slow");

                                if (data > 0) {
                                    jConfirm('已经将凭证信息移动【' + data + '】条数据至【' + getTreeName + '】科目下！', '友情提示', function (r) {
                                        if (r) {
                                            $("div#winAll").fadeOut("slow");
                                            location = location;
                                        }
                                    });
                                }
                                else {
                                    jConfirm('移动凭证信息失败，请稍后重试！', '错误提示', function (r) {
                                        if (r) {
                                            $("div#winAll").fadeOut("slow");
                                            location = location;
                                        }
                                    });

                                }

                            });
                        }
                    });
                }
                else {
                    jAlert("请选择需要移动到科目的某个节点！", "友情提示");
                }
            }
        }
        else {
            jAlert("请选择需要移动的凭证！", "友情提示");
        }
    });

});
//关闭
function HidBox() {
    CloseBox();
    location = location;
}