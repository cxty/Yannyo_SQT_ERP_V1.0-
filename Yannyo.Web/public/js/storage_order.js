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
	
	//$('#s_box').hide();

	$('#button_o').click(function(){
		OrderList.ShowAddUserBox();
	});
	$('#button_e').click(function(){
		OrderList.Export();
	});
	$('#button_s').click(function(){
		$('#s_box').show(500);
	});

	$('#tBoxs tbody tr').click(function(){
		$('#tBoxs tbody tr').removeClass('trColor_clicked');

		$(this).addClass('trColor_clicked');
	});

	
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
			location = '/storage_order-' + OrderList.ordertype + '.aspx?Act=Search&S_key=&StoresSupplier=' + $('#StoresSupplier').val() +
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
			location = '/storage_order-0.aspx?Act=Search&S_key=&ordertypeStr='+OrderList.ordertypeStr+'&StoresSupplier=' + $('#StoresSupplier').val() +
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
			location = '/storage_order-0.aspx?Act=Search&ordertypeStr=' + $(obj).attr('ordertypeStr') + '&S_key=&StoresSupplier=' + $('#StoresSupplier').val() +
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
TOrderList.prototype.Export = function()
{
	var s_ok = false;
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
		var _url = '/storage_order-' + this.ordertype + '.aspx?Act=Export&S_key=&StoresSupplier=' + $('#StoresSupplier').val() +
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
		
		//未指定单据类型
		if (this.ordertype == 0) {
			_url += '&ordertypeStr=' + this.ordertypeStr;
		}
		
		window.open('', "top");
		setTimeout(window.open(_url, "top"), 100);
		return false;
	}
}
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
	
}
TOrderList.prototype.ShowEditUserBox = function(idStr,otype)
{
	if ((navigator.userAgent.match(/iPhone/i)) || (navigator.userAgent.match(/iPad/i)) || (navigator.userAgent.match(/Android/i))) {
		window.open('', "top"); 
		setTimeout(window.open('/storage_order_do_v-'+otype+'-'+idStr+'.aspx', "top"), 100); 
		return false;
	}else{
		this.PageBox = dialog("等待收发货单据",'iframe:storage_order_do_v-'+otype+'-'+idStr+'.aspx',this.dw,this.dh,"iframe",'HidBox();');
	}
}
