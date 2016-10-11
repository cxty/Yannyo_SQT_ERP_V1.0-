/**
 * cxty@qq.com
 */
 function TStockProduct_Log()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
	this.bDate = '';
	this.eDate = '';
	this.TreeJson = null;

	if (document.all) {
	    this.dw = $(document).width() - 20;
	    this.dh = $(window).height() - 80;
	}
	else {
	    this.dw = ($(document).width() - 20) + 'px';
	    this.dh = ($(window).height() - 80) + 'px';
	}
}
TStockProduct_Log.prototype.ini = function()
{

	this.PageForm = $('#form1');
	this.S_key = $('#S_key');
	this.Act = $('#Act');

	//数据搜索
    $('#S_key').autocomplete('Services/CAjax.aspx', {
            width: 200,
            scroll: true,
            autoFill: true,
            scrollHeight: 200,
            matchContains: true,
            dataType: 'json',
            extraParams: {
                'do': 'GetProductsList',
                'RCode': Math.random(),
                'ProductsName': function () { return $('#S_key').val(); }
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

	//仓库分类树
    $("#treeNode").jstree({   
	"json_data":StockProduct_Log.TreeJson, 
	"types" : {  
			 "valid_children" : [ "dt" ],  
			 "types" : {
				 "dt" : {
					 "icon" : { 
						"image" : "/images/dot.png" 
					},
					 "valid_children" : [ "default" ],
					 "max_depth" : 2,
					 "hover_node" : true,
					 "open_node":false,
					 "select_node" : true
				 } 
			 }  
		}, 
	 "plugins" : [ "themes", "json_data", "ui", "crrm", "types", "hotkeys","cCode"] 
	}).bind("select_node.jstree", function (e,data) {
		var sID = data.rslt.obj.attr("id").replace('t_','');
		//var sName = data.rslt.obj.context.text;
        var sName = $("#treeNode").jstree('get_text');
        //document.getElementById("StorageClassName").value=sName;
        $("#StorageClassName").val(sName);
        $("#StorageClassNum").val(sID);
        $("#winType").fadeOut("slow");
        if(sID !='')
        {
            $.post('/stockproduct.aspx?Aclass=aclass&sClassID='+sID,'',function(data){
                 var sName=eval("("+data+")").sName.split(",");
                 var sID=eval("("+data+")").sID.split(",");
                 var count=sName.length;
                 var StorageID=document.getElementById("StorageID");;
                 if(count>1)
                 {
                     StorageID.length=0;
                     StorageID.options.add(new Option("选择全部", "0"));
                     for (var i = 0; i < count - 1; i++) {
                       StorageID.options.add(new Option(sName[i], sID[i]));
                     }
                 }
                 else
                 {
                    StorageID.length=0;
                    StorageID.options.add(new Option("选择全部", "0"));
                 }
            });
        }
	 });
    //打开仓库树
    $("#StorageClassName").click(function () {
        $("#winType").fadeIn("slow");
    });
    //关闭仓库树
    $("#winClose").click(function () {
        $("#winType").fadeOut("slow");
    });
	//查找
	$('#bt_se').click(function(){
		if(StockProduct_Log.CheckF()== true){
			jConfirm('分析数据较大,该过程大约需(1-2)分钟,分析结果将自动缓存2个小时!','提示',function(r){
				if(r)
				{
					$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
					
					$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
						$(this).show();
						StockProduct_Log.Act.val("Search");
						location = 'stockproduct_log.aspx?Act=Search&StorageID=' + $('#StorageID').children('option:selected').val() + '&bDate=' + $('#bDate').val() + '&eDate=' + $('#eDate').val() + '&ProductID=' + $('#ProductID').val() + '&S_key=' + $('#S_key').val() + '&StorageClassName=' + $("#StorageClassName").val() + '&StorageClassNum=' + $("#StorageClassNum").val();

					});
					
				}
			});
		}
	});
	//打印
	$('#bt_print').click(function(){
		if(StockProduct_Log.CheckF()== true){
		}
	});
}
TStockProduct_Log.prototype.HidUserBox = function()
{
	//CloseBox();
	//location = location;
	jConfirm('是否 更新列表?', '提示', function (r) {
	    if (r) {
	        location = location;
	    } else {
	        CloseBox();
	    }
	});

}
TStockProduct_Log.prototype.CheckF = function()
{
	if ($("#StorageClassName").val() == '') {
		jAlert("请选择仓库分类！","友情提示");
	}else if($('#StorageID').val() == 0){
		jAlert("请选择仓库！","友情提示");
	}else if($('#bDate').val() == ''){
		jAlert("请填写开始时间！","友情提示");
	}else if($('#eDate').val() == ''){
		jAlert("请填写结束时间！","友情提示");
	}else if($('#ProductID').val() == '' || $('#ProductID').val() == 0){
		jAlert("请选择商品！","友情提示");
	}else{
		return true;
	}
}

TStockProduct_Log.prototype.ShowEditUserBox = function (idStr, otype) {
    if ((navigator.userAgent.match(/iPhone/i)) || (navigator.userAgent.match(/iPad/i)) || (navigator.userAgent.match(/Android/i))) {
        window.open('', "top");
        setTimeout(window.open('/orderlist_do_v-' + otype + '-' + idStr + '.aspx', "top"), 100);
        return false;
    } else {
        this.PageBox = dialog("查看单据", 'iframe:orderlist_do_v-' + otype + '-' + idStr + '.aspx', this.dw, this.dh, "iframe", 'HidBox();');
    }
}