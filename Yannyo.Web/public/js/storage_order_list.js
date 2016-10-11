/**
 * cxty@qq.com
 */

function TStorageOrderList(){
	this.bData = null;
	this.dData = null;
	this.PData = null;
	this.sData = null;
	
	this.grid = null;
	this.summaryData = null;
	this.summary = '';
	if(document.all)
	{
		this.dw = $(document).width()-20;
		this.dh = $(window).height()-80;
	}
	else
	{
		this.dw = ($(document).width()-20)+'px';
		this.dh = ($(window).height()-80)+'px';
	}
}

TStorageOrderList.prototype.ini = function()
{
	
	this.GetData();
	
	//条件检索
	$('#button_Search').click(function(){
		$('#form1').submit();
	});
	
	//弹出数据调整窗
	$('#edit_data').click(function(){
		StorageOrderList.ShowEditDataBox();
	});
	
	//导出数据
	$('#export_data').click(function(){
		StorageOrderList.ExpData();
	});
};

TStorageOrderList.prototype.ShowEditDataBox = function()
{
	if ((navigator.userAgent.match(/iPhone/i)) || (navigator.userAgent.match(/iPad/i)) || (navigator.userAgent.match(/Android/i))) {
		window.open('', "top"); 
		setTimeout(window.open('/storage_order_do-12.aspx', "top"), 100); 
		return false;
	}else{
		this.PageBox = dialog("数据调整",'iframe:storage_order_do-12.aspx',this.dw,this.dh,"iframe",'HidBox();'); 
	}
};

TStorageOrderList.prototype.ExpData = function()
{
	var _url = '/storage_order_list.aspx?Act=exp&S_key='+$('#S_key').val()+
	'&ProductID='+$('#ProductID').val()+
	'&StorageID='+$('#StorageID').val()+
	'&StorageClassNum='+$('#StorageClassNum').val()+
	'&bDate='+$('#bDate').val()+
	'&eDate='+$('#eDate').val()+
	'';
	window.open('', "top");
	setTimeout(window.open(_url, "top"), 100);
	return false;
};

TStorageOrderList.prototype.GetData = function()
{
	$.ajax({
          type: "POST",
           url: "/storage_order_list.aspx?Act=data",
           dataType :"json",
           data:   {
				ProductID:$('#ProductID').val(),
				StorageID:$('#StorageID').val(),
				StorageClassNum:$('#StorageClassNum').val(),
				bDate:$('#bDate').val(),
				eDate:$('#eDate').val()
			},
          success: function(data){
				if(data)
				{
					if(data.results.bList){
						StorageOrderList.bData = data.results.bList;
					}
					if(data.results.dList){
						StorageOrderList.dData = data.results.dList;
					}
					if(data.results.pList){
						StorageOrderList.pData = data.results.pList;
					}
					if(data.results.sList){
						StorageOrderList.sData = data.results.sList;
					}
					StorageOrderList.ShowDataTable();
				}
		
			},
          error: function(xhr, ajaxOptions, thrownError){
             alert('Error: '+ thrownError);
        }
	}); 
};

TStorageOrderList.prototype.ShowDataTable = function()
{
	var obj = { width: $('#dataTable').width()-20, height: 600, title: "商品出入库明细",resizable:true,draggable:false,editable:false,selectionModel: { type: 'row' },numberCell: false };
	
	obj.colModel = [
        { title: "操作时间", width: 110, dataType: "string",colModel:[{
						title:"",
						width:110,
						dataIndx:"splappendtime"
						}]
					},
		{ title: "单据类型", width: 80, dataType: "string",colModel:[{
						title:"",
						width:80,
						dataIndx:"otype",
						}] },
        { title: "客户/供应商", width: 200, dataType: "string",colModel:[{
						title:"",
						width:200,
						dataIndx:"StoresSupplierName",
						}] },
        { title: "单据号", width: 100, dataType: "string",colModel:[{
						title:"上期结转",
						width:100,
						dataIndx:"oordernum",
						}] },
        ];
        
        //构建表头,上期结转
        if(this.pData){
        	for(var i=0;i<this.pData.length;i++){
        		var _bObj = {
						title:this.pData[i].pname+'<br>'+this.pData[i].pbarcode,
						width:100,
						dataType:"integer",
						align:"right",
						
						colModel:[{
							title:0,
							width:100,
							dataType:"integer",
							align:"right",
							dataIndx:"quantity_"+this.pData[i].ProductsID
							}]
						};
				
				if(this.bData){
					//取上期结转，合并条件下所有仓库指定商品数量
					for(var j=0;j<this.bData.length;j++){
						var _colModel = _bObj.colModel[0];
						if(_colModel)
						{
							if(this.pData[i].ProductsID == this.bData[j].productsid){
								_colModel.title = Number(_colModel.title)+Number(this.bData[j].quantity);
							}
							_bObj.colModel[0] = _colModel;
						}
					}
				}
				obj.colModel.push(_bObj);
				_bObj = null;
			}
        }
        
		//明细数据
		var data = [];
		if(this.dData){
			for(var i=0;i<this.dData.length;i++){
				var _oTypeStr = '';
				switch(Number(this.dData[i].otype)){
					case 0:
						_oTypeStr = '数据调整';
					break;
					case 1:
						_oTypeStr = '采购进货';
					break;
					case 2:
						_oTypeStr = '采购退货';
					break;
					case 3:
						_oTypeStr = '销售发货';
					break;
					case 4:
						_oTypeStr = '销售退货';
					break;
					case 5:
						_oTypeStr = '赠品';
					break;
					case 6:
						_oTypeStr = '样品';
					break;
					case 7:
						_oTypeStr = '代购';
					break;
					case 8:
						_oTypeStr = '库存调整';
					break;
					case 9:
						_oTypeStr = '库存调拨';
					break;
					case 10:
						_oTypeStr = '坏货';
					break;
					case 11:
						_oTypeStr = '换货';
					break;
				}
				
				var _dObj = null;
				//同一时间,同一单据,仅为一条数据
				for(var j=0;j<data.length;j++){
					if(data[j].splappendtime == this.dData[i].splappendtime && data[j].oordernum==this.dData[i].oordernum){
						_dObj = data[j];
						break;
					}
				}
				
				if(_dObj){
					_dObj['quantity_'+this.dData[i].productsid] = Number(this.dData[i].quantity);
				}else{
					_dObj =  {
					'splappendtime':this.dData[i].splappendtime,
					'otype':_oTypeStr,
					'StoresSupplierName':this.dData[i].StoresSupplierName,
					'oordernum':this.dData[i].oordernum,
					'productsid':this.dData[i].productsid
					};
					_dObj['quantity_'+this.dData[i].productsid] = Number(this.dData[i].quantity);
					data.push(_dObj);
				}
				
			}
		}
        
        var $summaryData;
	    obj.render = function (evt, ui) {
	        StorageOrderList.summary = $("<div class='pq-grid-summary'  ></div>").prependTo($(".pq-grid-bottom", this));
	        $summaryData = StorageOrderList.calculateSummary();
	        
	    }
	    
        obj.dataModel = { data: data};
        obj.freezeCols = 4;
       
	    obj.refresh = function (evt, ui) {
	       	var _data = [$summaryData];
	        var _obj = { data: _data, $cont: StorageOrderList.summary};
	        StorageOrderList.grid.pqGrid("createTable", _obj);
	    }
	    
       this.grid = $("#dataTable").pqGrid(obj);
       
       //this.grid.pqGrid( "createTable", {$cont: $(".pq-grid-summary"), data: [ [ "Total", "5", "10" ] ] } );
};

TStorageOrderList.prototype.calculateSummary = function()
{
	//合计
    var _sumData  = {'splappendtime':'',
    				'otype':'',
					'StoresSupplierName':'',
					'oordernum':'<b>本期结转</b>',
					'productsid':''};
    //本期
    for(var i=0;i<this.pData.length;i++){
    	var _sum = 0;
    	for(var j=0;j<this.dData.length;j++){
    		
    		if(Number(this.pData[i].ProductsID) == Number(this.dData[j].productsid)){
    			
    			_sum += Number(this.dData[j].quantity);
    			
    		}
   		}
   		_sumData['quantity_'+this.pData[i].ProductsID] = _sum;
    }
    //上期
    for(var i=0;i<this.pData.length;i++){
    	for(var j=0;j<this.bData.length;j++){
    		if(Number(this.pData[i].ProductsID) == Number(this.bData[j].productsid)){
    			_sumData['quantity_'+this.pData[i].ProductsID] += Number(this.bData[j].quantity);
    		}
    	}
    }
    
    //_sumData.unshift("","<b>本期结转</b>","");
    
    return _sumData;
};

TStorageOrderList.prototype.HidUserBox = function()
{	

	jConfirm('是否 更新列表?','提示',function(r){
		if(r)
		{
			location=location;
		}else{
			CloseBox();
		}
	});
	
};

var StorageOrderList = new TStorageOrderList();

$().ready(function () {
	
	
	StorageOrderList.ini();
	
	
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
    //导出数据
    $("#export_data").click(function () {
        var StorageClassName=$("#StorageClassName").val();
        if(StorageClassName =='')
        {
            jAlert("请选择仓库类别！","友情提示");
        }
        else
        {
            var _url = '/stockproduct.aspx?Act=Export&StorageID=' + $("#StorageID").children('option:selected') + '&ProductID=' + $("#ProductID").val() + '&sDate=' + $("#sDate").val() + '&StorageClassNum=' + $("#StorageClassNum").val();
            window.open('', "top");
            setTimeout(window.open(_url, "top"), 100);
            return false;
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
    $("#res_btn").click(function () {
        $("#winType").fadeOut("slow");
    });
 });
 
function HidBox()
{
	StorageOrderList.HidUserBox();
}