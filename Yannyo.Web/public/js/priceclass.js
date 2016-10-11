/*
author:yangangol
*/

$(document).ready(function () {
    //树
    $("#tTree").jstree({

        "json_data": { "ajax": {
            "url": "/Services/CAjax.aspx",
            "data": function (n) {
                return {
                    "do": "DataClass",
                    "doValue": "select",
                    "DataType": "PriceClass",
                    "NOCaches": 0,
                    "pid": n.attr ? n.attr("id").replace("t_", "") : -1
                };
            }
        }
        },
        "core": {
            "initially_open": ["t_0"]
        },


        "plugins": ["themes", "json_data", "ui", "crrm", "types", "dnd", "hotkeys", "dnd", "contextmenu"]

    }).bind("create.jstree", function (e, data) {
        $.post(
				"/Services/CAjax.aspx?do=DataClass&doValue=create&DataType=PriceClass",
				{
				    "pid": data.rslt.parent.attr("id").replace("t_", ""),
				    "position": data.rslt.position,
				    "ClassName": data.rslt.name
				},
				function (r) {
				    if (r.status) {
				        $(data.rslt.obj).attr("id", "t_" + r.id);
				    }
				    else {
				        $.jstree.rollback(data.rlbk);
				    }
				}
			);
    }).bind("rename.jstree", function (e, data) {
        $.post(
				"/Services/CAjax.aspx?do=DataClass&doValue=rename&DataType=PriceClass",
				{
				    "cid": data.rslt.obj.attr("id").replace("t_", ""),
				    "pid": data.rslt.obj.attr("pid"),
				    "ClassName": data.rslt.new_name
				},
				function (r) {
				    if (!r.status) {
				        $.jstree.rollback(data.rlbk);
				    }
				}
			);
    }).bind("remove.jstree", function (e, data) {
        data.rslt.obj.each(function () {
            $.ajax({
                async: false,
                type: 'POST',
                url: "/Services/CAjax.aspx?do=DataClass&doValue=remove&DataType=PriceClass",
                data: {
                    "pid": this.pid,
                    "cid": this.id.replace("t_", "")
                },
                success: function (r) {
                    if (!r.status) {
                        data.inst.refresh();
                    }
                }
            });
        });
    }).bind("click.jstree", function (e) {
        //获得点击的节点ID
        var sObj = null;
        if (e.target.nodeName == 'A') {
            sObj = e.target.parentNode;
        }
        else {
            sObj = e.target;
        }
        var clickID = $(sObj).attr('id').replace("t_", "");
        if (clickID != '') {
            $('#tSel').val($(sObj).children('a').first().text());
            $("#dClassID").val(clickID);
            //调用点击节点后的值
            getDetails(clickID);
        }
        sObj = null;
    });
    $("#tTree").jstree('open_all');
    if ($("#tSel").val() == '') {
        //全选
        $("#Checkbox1").click(function () {
            $("#edTable tr:gt(0)").each(function () {
                $(this).find(".checkID").get(0).checked = $("#Checkbox1").get(0).checked;
            });
        });
    }
    //批量删除
    $("#btn_delete").click(function () {
        var objs = document.getElementsByName("checkID");
        var Content = "";
        for (var i = 0; i < objs.length; i++) {
            if (objs[i].type == "checkbox") {
                if (objs[i].checked) {
                    Content += objs[i].value + ",";
                }
                else {
                    jAlert("请选择需要删除的项！", "友情提示");
                }
            }
        }
        if (Content != '') {
            jConfirm('是否确认删除选中项？删除后将无法恢复！', '友情提示', function (r) {
                if (r) {
                    $.post("/priceclass.aspx?Act=del&trNode=" + Content, '', function (data) {
                        if (data == "1") {
                            //刷新页面
                            sObj = -1;
                            getDetails(sObj);
                            ReLoadTree(sObj);
                        }
                        if (data == "0") {
                            jAlert("数据删除失败，请重新操作！", "友情提示");
                        }
                        if (data == "-1") {
                            jAlert("操作错误！", "友情提示");
                        }
                    });
                }
            });
        }
    });

    //添加
    $("#add_folder").click(function () {
        var dClassID = $("#dClassID").val();
        var dClassName = $("#tSel").val();
        if (dClassName != '') {
            this.PageBox = dialog("添加价格分类", "iframe:priceclass_edit.aspx?Act=add&classID=" + dClassID, "450px", "350px", "iframe");
        }
        else {
            jAlert("请选择需要添加分类的节点！", "友情提示");
        }
    });

});

$("#Checkbox1").live("click", function () {
    $("#edTable tr:gt(0)").each(function () {
        $(this).find(".checkID").get(0).checked = $("#Checkbox1").get(0).checked;
    });
});

//获得post节点值
function getDetails(cID) {
    //1.点击节点post
    $.post("/priceclass.aspx?Act=getNode&classID=" + cID, "", function (data) {
        if (data != '') {

            //返回json数据
            var dataObj = eval("(" + data + ")");
            var dobjClassID = [];
            var dobjClassName = [];
            var dobjOrder = [];
            var dobjPTime = [];
            var dobjPName = [];
            //将json对象分割为数组
            dobj = dataObj.cDetails.pid.split(',');
            dobjClassName = dataObj.cDetails.pname.split(',');
            dobjOrder = dataObj.cDetails.porder.split(',');
            dobjPTime = dataObj.cDetails.ptime.split(',');
            if (cID == "tTree") {
                dobjPName = dataObj.cDetails.parentName.split(',');
            }
            //移除原有数据表
            $("#edTable").remove();
            //创建新表
            var tContent = "";
            var parName = "";
            if (dobjPName != '') {
                var tTable = "<table id='edTable' width='100%' border='0' cellspacing='2' cellpadding='2'>" +
                    "<tr class='tBar' align='center'>" +
                    "<td align='center' style='width:5%'><input id='Checkbox1' class='B_Check' name='Checkbox1' type='checkbox'  style='width:25px'/></td>" +
                    "<td style='width:25%'>名称</td>" +
                    "<td style='width:20%'>上级分类</td>" +
                    "<td style='width:10%'>排序</td>" +
                    "<td style='width:20%'>操作时间</td>" +
                    "<td style='width:20%'>操作</td></tr>";

                for (var i = 0; i < dobj.length; i++) {
                    if (dobjPName[i].toString() == '') {
                        parName = "顶级";
                    }
                    else {
                        parName = dobjPName[i].toString();
                    }
                    tContent += "<tr class='tBar' align='center' style='font-weight:normal'>" +
                          "<td style='width:5%'>" +
                          "<input  class='checkID' name='checkID' type='checkbox' value=\"" + dobj[i].toString() + "\" style='width:25px'/></td>" +
                          "<td align='left' style='width:25%'>" + dobjClassName[i].toString() + "</td>" +
                          "<td align='left' style='width:20%'>" + parName + "</td>" +
                          "<td style='width:10%'>" + dobjOrder[i].toString() + "</td>" +
                          "<td style='width:20%'>" + dobjPTime[i].toString() + "</td>" +
                          "<td style='width:20%'>" +
                          "<a onclick='upDate(" + dobj[i].toString() + ")' style='cursor:pointer'>修改</a>&nbsp;&nbsp;<a class='remove' onclick='delData(" + dobj[i].toString() + "," + dataObj.cDetails.parentID + ",\"" + dobjClassName[i].toString() + "\")' style='cursor:pointer'>删除</a></td>";
                }

            }
            else {
                var tTable = "<table id='edTable' width='100%' border='0' cellspacing='2' cellpadding='2'>" +
                    "<tr class='tBar' align='center'>" +
                    "<td align='center' style='width:5%'><input id='Checkbox1' class='B_Check' name='Checkbox1' type='checkbox'  style='width:25px'/></td>" +
                    "<td style='width:25%'>名称</td>" +
                    "<td style='width:15%'>排序</td>" +
                    "<td style='width:25%'>操作时间</td>" +
                    "<td style='width:30%'>操作</td></tr>";


                for (var i = 0; i < dobj.length; i++) {
                    if (dobj[i].toString() != '') {
                        tContent += "<tr class='tBar' align='center' style='font-weight:normal'>" +
                          "<td style='width:5%'>" +
                          "<input  class='checkID' name='checkID' type='checkbox' value=\"" + dobj[i].toString() + "\" style='width:25px'/></td>" +
                          "<td align='left' style='width:25%'>" + dobjClassName[i].toString() + "</td>" +
                          "<td style='width:15%'>" + dobjOrder[i].toString() + "</td>" +
                          "<td style='width:25%'>" + dobjPTime[i].toString() + "</td>" +
                          "<td style='width:30%'>" +
                          "<a onclick='upDate(" + dobj[i].toString() + ")' style='cursor:pointer'>修改</a>&nbsp;&nbsp;<a class='remove' onclick='delData(" + dobj[i].toString() + "," + dataObj.cDetails.parentID + ",\"" + dobjClassName[i].toString() + "\")' style='cursor:pointer'>删除</a></td>";
                    }
                }
            }
            var bTable = "</table>";
            $("div#divOne").append(tTable + tContent + bTable);
        }
    });
}

//删除数据
function delData(sObj, sParentID, sName) {
    if (sObj) {
        jConfirm('是否确认删除选中【' + sName + '】？删除后将无法恢复！', '友情提示', function (r) {
            if (r) {
                if (sObj == '') {
                    jAlert("选择错误，请核对后重新选择！", "友情提示");
                }
                else {
                    $.post("/priceclass.aspx?Act=del&trNode=" + sObj, '', function (data) {
                        if (data == "1") {
                            if ($("#tSel").val() == '') {
                                //刷新页面
                                sObj = -1;
                            }
                            else {
                                sObj = sParentID;
                            }
                            $("#tSel").attr("value", "");
                            getDetails(sObj);
                            ReLoadTree(sObj);
                        }
                        if (data == "0") {
                            jAlert("数据删除失败，请重新操作！", "友情提示");
                        }
                        if (data == "-1") {
                            jAlert("操作错误！", "友情提示");
                        }
                    });

                }
            }
        });
    }
    else {
        jAlert("请选择需要删除分类的节点！", "友情提示");
    }
}

//修改数据
function upDate(cID) {
    if (cID) {
        this.PageBox = dialog("修改价格分类", "iframe:priceclass_edit.aspx?Act=update&classID=" + cID, "450px", "350px", "iframe");
    }
    else {
        jAlert("请选择需要修改分类的节点！", "友情提示");
    }
}

//刷新指定节点
function ReLoadTree(cID) {
    $("#tTree").jstree('refresh');
}
//关闭
function HidBox() {
    CloseBox();
    location = location;
}