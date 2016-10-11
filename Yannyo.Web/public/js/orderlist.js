/**
 * cxty@qq.com
 */
function TOrderList()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
	this.ordertype = 0;
	this.ordertypeStr = '';
	this.UserCode = '';

	this.PrinterName = '';//默认打印机名称
	this.PrintPageWidth = '';//打印单据宽度
	this.PrintPageHeight = 0;//打印单据高度

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
TOrderList.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
	
	$('#print_all_bt').hide();
	$('input[name="CheckAll"]').hide();
	$('#s_box').hide();

	$('#print_show_bt').click(function () {
	    $('#print_all_bt').show();
	    $('input[name="CheckAll"]').show();
	});

	$('.CheckAll').click(function () {

	    var _isChecked =  $(this).attr('checked');
	    $('input[name="CheckAll"]').attr('checked', _isChecked);
	    
	});

	$('#print_all_bt').click(function () {
	    var _checkObj = $('input[name="CheckAll"]:checked');
	    var _orderid_array = [];
	    var _ordertype_array = [];
	    for (var i = 0; i < _checkObj.length;i++){
	        _orderid_array.push($(_checkObj[i]).attr('orderid'));
	        _ordertype_array.push($(_checkObj[i]).attr('otype'));
	    }

	    if (_orderid_array.length > 0) {


	        jConfirmYesNo('是否打印金额?<br>提示:每次打印系统都将留下打印记录!', '提示', function (r) {
	            if (r) {
	                var ShowMoney = '';
	                if (r == 'no') {
	                    ShowMoney = '&ShowMoney=false';
	                }
	                //var _Print_URL = '/orderprintall-' + _orderid_array.join('x') + '-' + _ordertype_array.join('x') + '.aspx?UserCode=' + OrderList.UserCode + ShowMoney;
	                var _Print_URL = '/orderprint.aspx?act=pl&orderid=' + _orderid_array.join('x') + '&ordertype=' + _ordertype_array.join('x') + '&UserCode=' + OrderList.UserCode + ShowMoney;
	                var LODOP;
	                try {
	                    LODOP = getLodop(document.getElementById('LODOP'), document.getElementById('LODOP_EM'));
	                    try {
	                        LODOP.PRINT_INIT("单据打印");
	                        LODOP.SET_PRINT_STYLE("FontSize", 12);
	                        LODOP.ADD_PRINT_URL(0, 0, "100%", "100%", _Print_URL);

	                        var _printerName = LODOP.GET_PRINTER_NAME(-1);
	                        if (_printerName) {
	                            if (_printerName.indexOf(OrderList.PrinterName) > -1) {
	                                if (OrderList.ListCount < 14) {
	                                    LODOP.SET_PRINT_PAGESIZE(3, OrderList.PrintPageWidth, 0, "");
	                                } else {
	                                    LODOP.SET_PRINT_PAGESIZE(3, OrderList.PrintPageWidth, OrderList.PrintPageHeight + OrderList.ListCount * 20, "");
	                                }
	                            }
	                        }

	                        LODOP.PREVIEW();
	                    }
	                    catch (e) {
	                        jAlert('请安装打印控件![' + e + ']');
	                    }

	                    return false;
	                }
	                catch (e) {
	                    window.open('', "top");
	                    setTimeout(window.open(_Print_URL, "top"), 100);
	                    return false;
	                }
	            }
	        });

	    } else {
	        jConfirm('批量打印前需先选择打印的单据!请在单据列表左侧勾选!', '提示', function () { });
	    }
	});

	$('#button_o').click(function(){
		OrderList.ShowAddUserBox();
	});
	$('#button_e').click(function(){
		OrderList.Export();
	});
	$('#button_a').click(function(){
		OrderList.Export(true);
	});
	$('#button_s').click(function(){
		$('#s_box').show(500);
	});

	$('#tBoxs tbody tr').click(function(){
		$('#tBoxs tbody tr').removeClass('trColor_clicked');

		$(this).addClass('trColor_clicked');
	});

	//控制单据时间
	/*
	$('#oSteps').change(function(){
		if(Number($(this).children('option:selected').val())==-1)
		{
			$('#sType_a').attr('readonly','readonly');
			$('#oOrderDateTimeB').attr('readonly','readonly');
			$('#oOrderDateTimeE').attr('readonly','readonly');
			
			$('#sType_b').attr('readonly','readonly');
			$('#dDateTimeB').attr('readonly','readonly');
			$('#dDateTimeE').attr('readonly','readonly');
		}else{
			$('#sType_a').removeAttr('readonly');
			$('#oOrderDateTimeB').removeAttr('readonly');
			$('#oOrderDateTimeE').removeAttr('readonly');
			
			$('#sType_b').removeAttr('readonly');
			$('#dDateTimeB').removeAttr('readonly');
			$('#dDateTimeE').removeAttr('readonly');
		}
	});
	$('#oSteps').change();
	*/
	$('#oOrderDateTimeB').focus(function(){
		$('#sType_a').attr('checked','checked');
	});
	$('#oOrderDateTimeE').focus(function(){
		$('#sType_a').attr('checked','checked');
	});
	
	$('#dDateTimeB').focus(function(){
		$('#sType_b').attr('checked','checked');
	});
	$('#dDateTimeE').focus(function(){
		$('#sType_b').attr('checked','checked');
	});
}
TOrderList.prototype.ShowAddUserBox = function()
{
	if(this.ordertype > 0)
	{
		if ((navigator.userAgent.match(/iPhone/i)) || (navigator.userAgent.match(/iPad/i)) || (navigator.userAgent.match(/Android/i))) {
			window.open('', "top"); 
			setTimeout(window.open('/orderlist_do-1-'+this.ordertype+'.aspx', "top"), 100); 
			return false;
		}else{
			this.PageBox = dialog("新建单据",'iframe:orderlist_do-1-'+this.ordertype+'.aspx',this.dw,this.dh,"iframe",'HidBox();'); 
		}
	}else{
		this.PageBox = dialog("选择单据类型",'iframe:orderlist_typebox.aspx',400,200,"iframe",'HidBox();'); 
	}
}
TOrderList.prototype.Search = function()
{
	var s_ok = false;
	this.Act.value="Search";
	var sType = 1;
	
	if(Number($('#oSteps').children('option:selected').val())>-1)
	{
		if($('#sType_a').attr('checked'))
		{
			sType = 1;
			if($('#oOrderDateTimeB').val()=='')
			{
				s_ok = false;
				jAlert('请选择单据时间','提示',function(){$('#oOrderDateTimeB').focus();});
				
			}else{
				s_ok = true;
			}
		}
		if($('#sType_b').attr('checked'))
		{
			sType = 2;
			if($('#dDateTimeB').val()=='')
			{
				s_ok = false;
				jAlert('请选择单据操作开始时间','提示',function(){$('#dDateTimeB').focus();});
				
			}else{
				s_ok = true;
			}
		}
	}else{
		if($('#sType_b').attr('checked'))
		{
			s_ok = false;
			jAlert('请选择操作步骤.','提示',function(){
				$("#oSteps").jFlash({
		            css: {color: "#fff",backgroundColor:"#e00"}, //and more css property
		            time: 100, // 每次闪烁间隔时间，单位是毫秒
		            count: 5, // 闪烁的总次数
		            onStop: function(_this){} //闪烁完了，回调，会传入当然闪烁元素的引用
		        });
			});
		}else{
			s_ok = true;
		}
	}
	if (s_ok) {
		$("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
		$("#floatBoxBg").animate({
			opacity: "0.5"
		}, "normal", function(){
			location = '/orderlist-' + OrderList.ordertype + '.aspx?Act=Search&S_key=&StoresSupplier=' + $('#StoresSupplier').val() +
			'&StoresSupplierID=' +
			$('#StoresSupplierID').val() +
			'&oOrderNum=' +
			$('#oOrderNum').val() +
			'&StaffName=' +
			$('#StaffName').val() +
			'&StaffID=' +
			$('#StaffID').val() +
			'&UserName=' +
			$('#UserName').val() +
			'&UserID=' +
			$('#UserID').val() +
			'&oCustomersOrderID=' +
			$('#oCustomersOrderID').val() +
			'&oOrderDateTimeB=' +
			$('#oOrderDateTimeB').val() +
			'&oOrderDateTimeE=' +
			$('#oOrderDateTimeE').val() +
			'&ProductsName=' +
			$('#ProductsName').val() +
			'&ProductsID=' +
			$('#ProductsID').val() +
			'&oState=' +
			$('#oState').children('option:selected').val() +
			'&oSteps=' +
			$('#oSteps').children('option:selected').val() +
			//'&dType_b=' +
			//$('#dType_b').children('option:selected').val() +
			//'&dType=' +
			//$('#dType').children('option:selected').val() +
			'&dDateTimeB=' +
			$('#dDateTimeB').val() +
			'&dDateTimeE=' +
			$('#dDateTimeE').val()+
			'&sType=' + sType + '&StorageID=' + $('#StorageID').val() + '&StorageName=' + $('#StorageName').val();
			
		});
	}
}
TOrderList.prototype.SearchB = function()
{
	var s_ok = false;
	this.Act.value="Search";
	var sType = 1;
	
	if(Number($('#oSteps').children('option:selected').val())>-1)
	{
		if($('#sType_a').attr('checked'))
		{
			sType = 1;
			if($('#oOrderDateTimeB').val()=='')
			{
				s_ok = false;
				jAlert('请选择单据时间','提示',function(){$('#oOrderDateTimeB').focus();});
				
			}else{
				s_ok = true;
			}
		}
		if($('#sType_b').attr('checked'))
		{
			sType = 2;
			if($('#dDateTimeB').val()=='')
			{
				s_ok = false;
				jAlert('请选择单据操作开始时间','提示',function(){$('#dDateTimeB').focus();});
				
			}else{
				s_ok = true;
			}
		}
	}else{
		if($('#sType_b').attr('checked'))
		{
			s_ok = false;
			jAlert('请选择操作步骤.','提示',function(){
				$("#oSteps").jFlash({
		            css: {color: "#fff",backgroundColor:"#e00"}, //and more css property
		            time: 100, // 每次闪烁间隔时间，单位是毫秒
		            count: 5, // 闪烁的总次数
		            onStop: function(_this){} //闪烁完了，回调，会传入当然闪烁元素的引用
		        });
			});
		}else{
			s_ok = true;
		}
	}
	if (s_ok) {
		$("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
		$("#floatBoxBg").animate({
			opacity: "0.5"
		}, "normal", function(){
			location = '/orderlist-0.aspx?Act=Search&S_key=&ordertypeStr='+OrderList.ordertypeStr+'&StoresSupplier=' + $('#StoresSupplier').val() +
			'&StoresSupplierID=' +
			$('#StoresSupplierID').val() +
			'&oOrderNum=' +
			$('#oOrderNum').val() +
			'&StaffName=' +
			$('#StaffName').val() +
			'&StaffID=' +
			$('#StaffID').val() +
			'&UserName=' +
			$('#UserName').val() +
			'&UserID=' +
			$('#UserID').val() +
			'&oCustomersOrderID=' +
			$('#oCustomersOrderID').val() +
			'&oOrderDateTimeB=' +
			$('#oOrderDateTimeB').val() +
			'&oOrderDateTimeE=' +
			$('#oOrderDateTimeE').val() +
			'&ProductsName=' +
			$('#ProductsName').val() +
			'&ProductsID=' +
			$('#ProductsID').val() +
			'&oState=' +
			$('#oState').children('option:selected').val() +
			'&oSteps=' +
			$('#oSteps').children('option:selected').val() +
			//'&dType_b=' +
			//$('#dType_b').children('option:selected').val() +
			//'&dType=' +
			//$('#dType').children('option:selected').val() +
			'&dDateTimeB=' +
			$('#dDateTimeB').val() +
			'&dDateTimeE=' +
			$('#dDateTimeE').val()+
			'&sType=' + sType + '&StorageID=' + $('#StorageID').val() + '&StorageName=' + $('#StorageName').val();
			
		});
	}
}
TOrderList.prototype.SearchC = function(obj)
{
	var s_ok = false;
	this.Act.value="Search";
	var sType = 1;
	
	if(Number($('#oSteps').children('option:selected').val())>-1)
	{
		if($('#sType_a').attr('checked'))
		{
			sType = 1;
			if($('#oOrderDateTimeB').val()=='')
			{
				s_ok = false;
				jAlert('请选择单据时间','提示',function(){$('#oOrderDateTimeB').focus();});
				
			}else{
				s_ok = true;
			}
		}
		if($('#sType_b').attr('checked'))
		{
			sType = 2;
			if($('#dDateTimeB').val()=='')
			{
				s_ok = false;
				jAlert('请选择单据操作开始时间','提示',function(){$('#dDateTimeB').focus();});
				
			}else{
				s_ok = true;
			}
		}
	}else{
		if($('#sType_b').attr('checked'))
		{
			s_ok = false;
			jAlert('请选择操作步骤.','提示',function(){
				$("#oSteps").jFlash({
		            css: {color: "#fff",backgroundColor:"#e00"}, //and more css property
		            time: 100, // 每次闪烁间隔时间，单位是毫秒
		            count: 5, // 闪烁的总次数
		            onStop: function(_this){} //闪烁完了，回调，会传入当然闪烁元素的引用
		        });
			});
		}else{
			s_ok = true;
		}
	}
	if (s_ok) {
		$("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
		$("#floatBoxBg").animate({
			opacity: "0.5"
		}, "normal", function(){
			location = '/orderlist-0.aspx?Act=Search&ordertypeStr=' + $(obj).attr('ordertypeStr') + '&S_key=&StoresSupplier=' + $('#StoresSupplier').val() +
			'&StoresSupplierID=' +
			$('#StoresSupplierID').val() +
			'&oOrderNum=' +
			$('#oOrderNum').val() +
			'&StaffName=' +
			$('#StaffName').val() +
			'&StaffID=' +
			$('#StaffID').val() +
			'&UserName=' +
			$('#UserName').val() +
			'&UserID=' +
			$('#UserID').val() +
			'&oCustomersOrderID=' +
			$('#oCustomersOrderID').val() +
			'&oOrderDateTimeB=' +
			$('#oOrderDateTimeB').val() +
			'&oOrderDateTimeE=' +
			$('#oOrderDateTimeE').val() +
			'&ProductsName=' +
			$('#ProductsName').val() +
			'&ProductsID=' +
			$('#ProductsID').val() +
			'&oState=' +
			$('#oState').children('option:selected').val() +
			'&oSteps=' +
			$('#oSteps').children('option:selected').val() +
			//'&dType_b=' +
			//$('#dType_b').children('option:selected').val() +
			//'&dType=' +
			//$('#dType').children('option:selected').val() +
			'&dDateTimeB=' +
			$('#dDateTimeB').val() +
			'&dDateTimeE=' +
			$('#dDateTimeE').val()+
			'&sType=' + sType + '&StorageID=' + $('#StorageID').val() + '&StorageName=' + $('#StorageName').val();
			
		});
	}
}
TOrderList.prototype.Export = function(_isAll)
{
	var s_ok = false;
	var sType = 1;
	_isAll = _isAll?true:false;
	
	if(Number($('#oSteps').children('option:selected').val())>-1)
	{
		if($('#sType_a').attr('checked'))
		{
			sType = 1;
			if($('#oOrderDateTimeB').val()=='')
			{
				s_ok = false;
				jAlert('请选择单据时间','提示',function(){$('#oOrderDateTimeB').focus();});
				
			}else{
				s_ok = true;
			}
		}
		if($('#sType_b').attr('checked'))
		{
			sType = 2;
			if($('#dDateTimeB').val()=='')
			{
				s_ok = false;
				jAlert('请选择单据操作开始时间','提示',function(){$('#dDateTimeB').focus();});
				
			}else{
				s_ok = true;
			}
		}
	}else{
		if($('#sType_b').attr('checked'))
		{
			s_ok = false;
			jAlert('请选择操作步骤.','提示',function(){
				$("#oSteps").jFlash({
		            css: {color: "#fff",backgroundColor:"#e00"}, //and more css property
		            time: 100, // 每次闪烁间隔时间，单位是毫秒
		            count: 5, // 闪烁的总次数
		            onStop: function(_this){} //闪烁完了，回调，会传入当然闪烁元素的引用
		        });
			});
		}else{
			s_ok = true;
		}
	}
	if (s_ok) {
		var _url = '/orderlist-' + this.ordertype + '.aspx?Act=Export&S_key=&StoresSupplier=' + $('#StoresSupplier').val() +
		'&StoresSupplierID=' +
		$('#StoresSupplierID').val() +
		'&oOrderNum=' +
		$('#oOrderNum').val() +
		'&StaffName=' +
		$('#StaffName').val() +
		'&StaffID=' +
		$('#StaffID').val() +
		'&UserName=' +
		$('#UserName').val() +
		'&UserID=' +
		$('#UserID').val() +
		'&oCustomersOrderID=' +
		$('#oCustomersOrderID').val() +
		'&oOrderDateTimeB=' +
		$('#oOrderDateTimeB').val() +
		'&oOrderDateTimeE=' +
		$('#oOrderDateTimeE').val() +
		'&ProductsName=' +
		$('#ProductsName').val() +
		'&ProductsID=' +
		$('#ProductsID').val() +
		'&oState=' +
		$('#oState').children('option:selected').val() +
		'&oSteps=' +
		$('#oSteps').children('option:selected').val() +
		//'&dType_b=' +
		//$('#dType_b').children('option:selected').val() +
		//'&dType=' +
		//$('#dType').children('option:selected').val() +
		'&dDateTimeB=' +
		$('#dDateTimeB').val() +
		'&dDateTimeE=' +
		$('#dDateTimeE').val()+
		'&sType=' + sType + '&StorageID=' + $('#StorageID').val() + '&StorageName=' + $('#StorageName').val()+'&AllOrderList='+(_isAll?'true':'');
		
		//未指定单据类型
		if (this.ordertype == 0) {
			_url += '&ordertypeStr=' + this.ordertypeStr;
		}
		
		window.open('', "top");
		setTimeout(window.open(_url, "top"), 100);
		return false;
	}
}

TOrderList.prototype.Print = function () {

};

TOrderList.prototype.HidUserBox = function()
{	

	jConfirm('是否 更新单据列表?','提示',function(r){
		if(r)
		{
			location=location;
		}else{
			CloseBox();
		}
	});

	
	//$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){$(this).show();location=location;});
	
}
TOrderList.prototype.ShowEditUserBox = function(idStr,otype)
{
	if ((navigator.userAgent.match(/iPhone/i)) || (navigator.userAgent.match(/iPad/i)) || (navigator.userAgent.match(/Android/i))) {
		window.open('', "top"); 
		setTimeout(window.open('/orderlist_do_v-'+otype+'-'+idStr+'.aspx', "top"), 100); 
		return false;
	}else{
		this.PageBox = dialog("查看单据",'iframe:orderlist_do_v-'+otype+'-'+idStr+'.aspx',this.dw,this.dh,"iframe",'HidBox();');
	}
}
