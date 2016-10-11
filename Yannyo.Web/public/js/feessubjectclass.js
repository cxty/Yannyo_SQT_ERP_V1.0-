/**
 * @author Cxty
 */
function TFeesSubjectClass()
{
	this.SelectObj = null;
	this.PageBox = null;
}
TFeesSubjectClass.prototype.ini = function()
{
    $("#muen input").click(function () {
		switch(this.id) {
			case "add_folder":
				//$("#tTree").jstree("create", null, "last", { "attr" : { "value" : this.id.toString().replace("t_", "") } });
				FeesSubjectClass.ShowAddBox(FeesSubjectClass.SelectObj);
				break;
			case "rename":
				FeesSubjectClass.ShowEditBox(FeesSubjectClass.SelectObj);
				break;
			default:
				$("#tTree").jstree(this.id);
				break;
		}
	});

	
}
//关闭
TFeesSubjectClass.prototype.HidBox = function()
{
	CloseBox();
	location=location;
}
//添加
TFeesSubjectClass.prototype.ShowAddBox = function(sObj)
{
	if(sObj)
	{
		this.SelectObj = sObj;
		this.PageBox = dialog("添加新科目", "iframe:feessubjectclass_do-Add.aspx?cParentID=" + $(sObj).attr('id').replace("t_", ""), "450px", "350px", "iframe");
    }
    else {
        jAlert("请选择需要添加分类的节点！", "友情提示");
    }
}
//修改
TFeesSubjectClass.prototype.ShowEditBox = function (sObj)
{
	if(sObj)
	{
		this.SelectObj = sObj;
		this.PageBox = dialog("修改科目", "iframe:feessubjectclass_do-Edit.aspx?FeesSubjectClassID=" + sObj, "450px", "350px", "iframe");
	}
}
//移转数据
TFeesSubjectClass.prototype.ShowMoveBox = function (sObj, sName) {
    if (sObj) {
        this.SelectObj = sObj;
        this.PageBox = dialog("数据转移", "iframe:feessubjectclass_do_move.aspx?FeesSubjectClassID=" + sObj + "&sName=" + sName, "1024px", "490px", "iframe");
    }
}
//删除节点
TFeesSubjectClass.prototype.DeleteNode = function (sObj, sParentID, sName) {
    if (sObj) {
        jConfirm('是否确认删除选中【' + sName + '】？删除后将无法恢复！', '友情提示', function (r) {
            if (r) {
                if (sObj == '') {
                    jAlert("选择错误，请核对后重新选择！", "友情提示");
                }
                else {
                    $.post("/feessubjectclass.aspx?Act=del&trNode=" + sObj, '', function (data) {
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

//取选中对象
TFeesSubjectClass.prototype.GetSelectObj = function()
{
	return this.SelectObj;
}

//刷新指定节点
function ReLoadTree(cID)
{
	$("#tTree").jstree('refresh');
}

$(function () {
 $.ajaxSetup({cache:false});
 $("#tTree").jstree({   

         "json_data":{"ajax":{
			"url":"/Services/CAjax.aspx",
			"data" : function (n) {
						return { 
							"do" : "DataClass",
							"doValue" : "select",
							"DataType" : "FeesSubjectClass",
							"NOCaches":0,
							"pid" : n.attr ? n.attr("id").replace("t_","") : -1 
						};}
		 }}, 
		 "core" : { 
				"initially_open" : [ "t_0" ]
			},	
		"ui":{},
		"lang":{     
                 loading : "加载中……"    
             },

         "plugins" : [ "themes", "json_data", "ui", "crrm", "types","dnd", "hotkeys","dnd", "contextmenu","cCode" ] 

     }).bind("create.jstree", function (e, data) {
		 $.post(
				"/Services/CAjax.aspx?do=DataClass&doValue=create&DataType=FeesSubjectClass", 
				{ 
					"pid" : data.rslt.parent.attr("id").replace("t_",""), 
					"position" : data.rslt.position,
					"ClassName" : data.rslt.name
				}, 
				function (r) {
					if(r.status) {
						$(data.rslt.obj).attr("id", "t_" + r.id);
					}
					else {
						$.jstree.rollback(data.rlbk);
					}
				}
			);
		 }).bind("rename.jstree", function (e, data) {
			$.post(
				"/Services/CAjax.aspx?do=DataClass&doValue=rename&DataType=FeesSubjectClass", 
				{ 
					"cid" : data.rslt.obj.attr("id").replace("t_",""),
					"pid" : data.rslt.obj.attr("pid"),
					"ClassName" : data.rslt.new_name
				}, 
				function (r) {
					if(!r.status) {
						$.jstree.rollback(data.rlbk);
					}
				}
			);
		}).bind("remove.jstree", function (e, data) {
			data.rslt.obj.each(function () {
				$.ajax({
					async : false,
					type: 'POST',
					url: "/Services/CAjax.aspx?do=DataClass&doValue=remove&DataType=FeesSubjectClass",
					data : { 
						"pid" : this.pid, 
						"cid" : this.id.replace("t_","")
					}, 
					success : function (r) {
						if(!r.status) {
							data.inst.refresh();
						}
					}
				});
			});
		}).bind("click.jstree",function(e){
		    var sObj = null;
		    if (e.target.nodeName == 'A') {
		        sObj = e.target.parentNode;
		    }
		    else {
		        sObj = e.target;
		    }

		    FeesSubjectClass.SelectObj = sObj;
		    var clickID = $(sObj).attr('id').replace("t_", "");
		    if (clickID != '') {
		        $('#tSel').val($(sObj).children('a').first().text());
		        $('#cID').val(clickID);
		        getDetails(clickID);
		    }
		    sObj = null;				
		});
       $("#tTree").jstree('open_all');

});


//显示编码插件
(function ($) {
	$.jstree.plugin("cCode", {
		__init : function () {
			this.get_container()
				.bind("create_node.jstree clean_node.jstree", $.proxy(function (e, data) { 
						this._prepare_checkboxes(data.rslt.obj);
					}, this));
		},
		__destroy : function () {
			this.get_container().find(".jstree-cCode").remove();
		},
		_fn : {
			_prepare_checkboxes : function (obj) {
				obj = !obj || obj == -1 ? this.get_container() : this._get_node(obj);
				var c, _this = this, t;
				obj.each(function () {
					t = $(this);
					if (t.attr("cCode")) {
						t.not(":has(.jstree-cCode)").append("<span class='jstree-cCode'>(" + t.attr("cCode") + ")</span>").parent().not(".jstree-cCode").addClass('jstree-cCode');
					}
					
				});
				
			}
		}
	});
})(jQuery);




$(document).ready(function () {
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
                    $.post("/feessubjectclass.aspx?Act=del&trNode=" + Content, '', function (data) {
                        if (data == "1") {
                            if ($("#tSel").val() == '') {
                                //刷新页面
                                sObj = -1;
                            }
                            else {
                                sObj = $("#cID").val();
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
            });
        }
    });

});


$("#Checkbox1").live("click", function () {
    $("#edTable tr:gt(0)").each(function () {
        $(this).find(".checkID").get(0).checked = $("#Checkbox1").get(0).checked;
    });
});

function getDetails(cID) {

    $.post("/feessubjectclass.aspx?Act=getNode&classID=" + cID, "", function (data) {
        if (data != '') {

            //返回json数据
            var dataObj = eval("(" + data + ")");
            var dobjClassID = [];
            var dobjClassName = [];
            var dobjOrder = [];
            var dobjPTime = [];
            var dobjPName = [];

            var dobDirection = [];
            var dobCode = [];
            var dobType = [];
            var dobState = [];
            var dobChePop = "";
            //将json对象分割为数组
            dobj = dataObj.cDetails.pid.split(',');
            dobjClassName = dataObj.cDetails.pname.split(',');
            dobjOrder = dataObj.cDetails.porder.split(',');
            dobjPTime = dataObj.cDetails.ptime.split(',');

            dobDirection = dataObj.cDetails.cDirection.split(',');
            dobCode = dataObj.cDetails.cCode.split(',');
            dobType = dataObj.cDetails.cType.split(',');
            dobState = dataObj.cDetails.state.split(',');
            dobChePop = dataObj.cDetails.chePop;

            if (cID == "tTree") {
                dobjPName = dataObj.cDetails.parentName.split(',');
            }
            //移除原有数据表
            $("#edTable").remove();
            //创建新表
            var tContent = "";
            var parName = "";
            var direction = ""; //方向
            var type = ""; //类型
            var sState = ""; //启用状态
            if (dobjPName != '') {
                var tTable = "<table id='edTable' width='100%' border='0' cellspacing='2' cellpadding='2'>" +
                    "<tr class='tBar' align='center'>" +
                    "<td align='center' style='width:5%'><input id='Checkbox1' class='B_Check' name='Checkbox1' type='checkbox'  style='width:25px'/></td>" +
                    "<td style='width:20%'>名称</td>" +
                    "<td style='width:10%'>类型</td>" +
                    "<td style='width:10%'>借贷关系</td>" +
                    "<td style='width:15%'>上级分类</td>" +
                    "<td style='width:5%'>排序</td>" +
                    "<td style='width:10%'>凭证启用状态</td>" +
                    "<td style='width:15%'>操作时间</td>" +
                    "<td style='width:10%'>操作</td></tr>";

                for (var i = 0; i < dobj.length; i++) {
                    if (dobjPName[i].toString() == '') {
                        parName = "顶级";
                    }
                    else {
                        parName = dobjPName[i].toString();
                    }
                    //借贷关系
                    if (dobDirection[i].toString() == "0") {
                        direction = "借方";
                    }
                    if (dobDirection[i].toString() == "1") {
                        direction = "贷方";
                    }
                    //类型
                    if (dobType[i].toString() == "0") {
                        type = "资产";
                    }
                    if (dobType[i].toString() == "1") {
                        type = "负债";
                    }
                    if (dobType[i].toString() == "2") {
                        type = "权益";
                    }
                    if (dobType[i].toString() == "3") {
                        type = "损益";
                    }
                    if (dobType[i].toString() == "4") {
                        type = "成本";
                    }
                    if (dobState[i].toString() == "1") {
                        if (dobChePop == "1") {
                            sState = "<a onclick='javascript:FeesSubjectClass.ShowMoveBox(" + dobj[i].toString() + ",\" " + dobjClassName[i].toString() + "\")' style='cursor:pointer'>已启用</a>";
                        }
                        else {
                            sState = "已启用";
                        }
                    }
                    else {
                        sState = "未启用";
                    }
                    if (dobj[i].toString() != '') {
                        tContent += "<tr class='tBar' align='center' style='font-weight:normal'>" +
                          "<td style='width:5%'>" +
                          "<input  class='checkID' name='checkID' type='checkbox' value=\"" + dobj[i].toString() + "\" style='width:25px'/></td>" +
                          "<td align='left' style='width:20%'>" + dobjClassName[i].toString() + "(" + dobCode[i].toString() + ")" + "</td>" +
                          "<td style='width:10%'>" + type + "</td>" +
                          "<td style='width:10%'>" + direction + "</td>" +
                          "<td align='left' style='width:15%'>" + parName + "</td>" +
                          "<td style='width:5%'>" + dobjOrder[i].toString() + "</td>" +
                          "<td style='width:10%'>" + sState + "</td>" +
                          "<td style='width:15%'>" + dobjPTime[i].toString() + "</td>" +
                          "<td style='width:10%'>" +
                          "<a onclick='javascript:FeesSubjectClass.ShowEditBox(" + dobj[i].toString() + ")' style='cursor:pointer'>修改</a>&nbsp;&nbsp;<a class='remove' onclick='javascript:FeesSubjectClass.DeleteNode(" + dobj[i].toString() + "," + dataObj.cDetails.parentID + ",\" " + dobjClassName[i].toString() + "\")' style='cursor:pointer'>删除</a></td>";
                    }
                    direction = "";
                    type = "";
                    sState = "";
                }

            }
            else {
                var tTable = "<table id='edTable' width='100%' border='0' cellspacing='2' cellpadding='2'>" +
                    "<tr class='tBar' align='center'>" +
                    "<td align='center' style='width:5%'><input id='Checkbox1' class='B_Check' name='Checkbox1' type='checkbox'  style='width:25px'/></td>" +
                    "<td style='width:25%'>名称</td>" +
                    "<td style='width:10%'>类型</td>" +
                    "<td style='width:10%'>借贷关系</td>" +
                    "<td style='width:10%'>排序</td>" +
                    "<td style='width:10%'>凭证启用状态</td>" +
                    "<td style='width:20%'>操作时间</td>" +
                    "<td style='width:15%'>操作</td></tr>";


                for (var i = 0; i < dobj.length; i++) {
                    //借贷关系
                    if (dobDirection[i].toString() == "0") {
                        direction = "借方";
                    }
                    if (dobDirection[i].toString() == "1") {
                        direction = "贷方";
                    }
                    //类型
                    if (dobType[i].toString() == "0") {
                        type = "资产";
                    }
                    if (dobType[i].toString() == "1") {
                        type = "负债";
                    }
                    if (dobType[i].toString() == "2") {
                        type = "权益";
                    }
                    if (dobType[i].toString() == "3") {
                        type = "损益";
                    }
                    if (dobType[i].toString() == "4") {
                        type = "成本";
                    }
                    if (dobState[i].toString() == "1") {
                        if (dobChePop == "1") {
                            sState = "<a onclick='javascript:FeesSubjectClass.ShowMoveBox(" + dobj[i].toString() + ",\" " + dobjClassName[i].toString() + "\")' style='cursor:pointer'>已启用</a>";
                        }
                        else {
                            sState="已启用"
                        }
                    }
                    else {
                        sState = "未启用";
                    }
                    if (dobj[i].toString() != '') {
                        tContent += "<tr class='tBar' align='center' style='font-weight:normal'>" +
                          "<td style='width:5%'>" +
                          "<input  class='checkID' name='checkID' type='checkbox' value=\"" + dobj[i].toString() + "\" style='width:25px'/></td>" +
                          "<td align='left' style='width:20%'>" + dobjClassName[i].toString() + "(" + dobCode[i].toString() + ")" + "</td>" +
                          "<td style='width:10%'>" + type + "</td>" +
                          "<td style='width:10%'>" + direction + "</td>" +
                          "<td style='width:10%'>" + dobjOrder[i].toString() + "</td>" +
                          "<td style='width:10%'>" + sState + "</td>" +
                          "<td style='width:20%'>" + dobjPTime[i].toString() + "</td>" +
                          "<td style='width:15%'>" +
                          "<a onclick='javascript:FeesSubjectClass.ShowEditBox(" + dobj[i].toString() + ")' style='cursor:pointer'>修改</a>&nbsp;&nbsp;<a class='remove' onclick='javascript:FeesSubjectClass.DeleteNode(" + dobj[i].toString() + "," + dataObj.cDetails.parentID + ",\" " + dobjClassName[i].toString() + "\")' style='cursor:pointer'>删除</a></td>";
                    }
                    direction = "";
                    type = "";
                    sState = "";
                }
            }
            var bTable = "</table>";
            $("div#divOne").append(tTable + tContent + bTable);
        }
    });
}

