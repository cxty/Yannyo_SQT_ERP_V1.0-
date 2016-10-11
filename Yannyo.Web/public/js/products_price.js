/**
 * cxty@qq.com
 */
function TStockProductsManage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
	this.sDate = '';
}
TStockProductsManage.prototype.ini = function()
{
	$('#sCodeButton').show();
	$('#rCodeButton').hide();
	$("input[name='save_price']").hide();
	
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
	

	$('input[pType="Price"]').blur(function(){
		var _ProductsID = $(this).attr('ProductsID');
		var _Price = $(this).val();
		if(_ProductsID>0){
			if($(this).val() != $(this).attr('oldValue')){
				$('#'+$(this).attr('BoxIndex')+'_priceBT').show();
			}
		}
	});
	
	$("input[name='save_price']").click(function(){
		var _BoxIndex = $(this).attr('BoxIndex');
		var _Price = $('#'+_BoxIndex+'_priceBox .ProductPriceBox').val();
		var _PriceRMB = $('#'+_BoxIndex+'_priceBox .ProductPriceRRMBBox').val();
		var _ProductsID = $(this).attr('ProductsID');
		var _Bt = $(this);
		$.get('/product_price.aspx?format=json&act=UpdatePrice&ProductID='+_ProductsID+'&Price='+_Price+'&PriceRMB='+_PriceRMB,function(data,state){
				if(data){
					data = eval("("+data+")");
					if(!data.state){
						alert('已超时!');
						location=location;
					}else{
						$(_Bt).hide();
						$('input[pType="Price"][productsid='+_ProductsID+']').hide(300).delay(500).show(300);
						
					}
				}
			});
	});
	
	//请在10分钟内输入商品成本维护校验码:
	$('#sCodeButton').click(function(){
		
		$('#sCodeButton').attr('disabled',"true");
		$('#sCodeButton').html('请在10分钟内输入商品成本维护校验码!');
		setTimeout(function(){
			$('#sCodeButton').attr('disabled',"false");
			$('#sCodeButton').html('重新发送校验码');
		},10000);	
			
			
		$('#rCodeButton').show();
			
		$.get('/product_price.aspx?format=json&act=SendCode',function(data,state){
			
		});
	});
	
	$('#sertch').click(function () {
	    if (document.all) {
	        dw = $(document).width() - 20;
	        dh = $(window).height() - 80;
	    }
	    else {
	        dw = $(document).width() - 20 + 'px';
	        dh = $(window).height() - 80 + 'px';
	    }
	    this.PageBox = dialog("查询盘点数据", 'iframe:warehouseinventorylist.aspx', dw, dh, "iframe", 'HidBox;'); 
	});
	
	$('#cls_z').click(function(){
		var _Show = $(this).val()!='过滤零数据';
		var __Show = false;
		var tr = $('#tBox').children('tbody').children('tr');
		if(tr)
		{
			for(var i=0;i<tr.length;i++)
			{
				if($(tr[i]).children('.l_a'))
				{
					__Show = false;
					for(var j=0;j<$(tr[i]).children('.l_a').length;j++)
					{
						if($(tr[i]).children('.l_a')[j])
						{
							if(Number($($(tr[i]).children('.l_a')[j]).text())!=0)
							{
								__Show = true;
							}
						}
					}
					if (!__Show) {
						if (_Show) {
							$(tr[i]).show();
						}
						else {
							$(tr[i]).hide();
						}
					}
				}
			}
		}
		
		$(this).val($(this).val()=='过滤零数据'?'显示零数据':'过滤零数据');
	});
	
}
TStockProductsManage.prototype.ShowEditBox = function(pid)
{
	this.PageBox = dialog("修改不可用库存",'iframe:stockproduct_do_Edit-'+pid+'.aspx',450,350,"iframe",'HidBox();');
}
TStockProductsManage.prototype.ShowUpdateBox = function (pid) {
    this.PageBox = dialog("修改盘点数据", 'iframe:warehouseinventory_do_Edit-'+pid+'.aspx', 450, 350, "iframe", 'HidBox();');
}
TStockProductsManage.prototype.HidUserBox = function()
{
	//SysComm.HiddenPageBox(this.PageBox);
	CloseBox();
	location=location;
}
TStockProductsManage.prototype.Search = function () {
    var StorageClassName = $("#StorageClassName").val();
    if (StorageClassName == '') {
        jAlert("请选择仓库分类！","友情提示");
    }
    else {
        this.Act.value = "Search";
        location = 'product_price.aspx?Act=Search&StorageID=' + $('#StorageID').children('option:selected').val() + '&sDate=' + $('#sDate').val() + '&ProductID=' + $('#ProductID').val() + '&S_key=' + $('#S_key').val() + '&StorageClassName=' + $("#StorageClassName").val() + '&StorageClassNum=' + $("#StorageClassNum").val();
    }
    //this.PageForm.submit();
}

var StockProductsManage = new TStockProductsManage();

$().ready(function () {


StockProductsManage.ini();
});