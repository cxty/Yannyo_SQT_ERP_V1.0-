/**
 * cxty@qq.com
 */
function TProductsManage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TProductsManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TProductsManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("添加商品",'iframe:products_do-Add.aspx',"550px","450px","iframe"); 
}
TProductsManage.prototype.ShowImportUserBox = function()
{
	this.PageBox = dialog("导入商品",'iframe:products_importdata.aspx',"550px","450px","iframe");
}
TProductsManage.prototype.ShowImportUserBoxErp = function()
{
	this.PageBox = dialog("同步商品",'iframe:products_do-Syn.aspx',"550px","450px","iframe"); 
}

TProductsManage.prototype.dataAct = function ()
{
    this.PageBox = dialog("导入导出", 'iframe:data_import_export-Products.aspx', "300px", "200px", "iframe");
}

TProductsManage.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TProductsManage.prototype.HidUserBox = function()
{
	CloseBox();
}
TProductsManage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			var tValue = '';
		    for(var i=0 ;i<ProductsManage.PageForm.elements.length;i++){ 
		        if(ProductsManage.PageForm.elements[i].name=="cCheck"){ 
		            e=ProductsManage.PageForm.elements[i];
		            if(e.checked == true)
		            {
		                tValue+=e.value+',';
		            }
		        }
		    }
		    if(Trim(tValue) != '')
		    {
				
			        	ProductsManage.PageBox = dialog("删除商品",'iframe:products_do_Del-'+tValue+'.aspx',"500px","200px","iframe"); 
					
		    }
		    tValue = null;
		}
	});
}
TProductsManage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			ProductsManage.PageBox = dialog("删除商品",'iframe:products_do_Del-'+idStr+'.aspx',"500px","200px","iframe");  
		}
	});
}
TProductsManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改商品",'iframe:products_do_Edit-'+idStr+'.aspx',"550px","450px","iframe");
}
TProductsManage.prototype.ShowProductBox = function(idStr)
{
	window.open('', "top");
	setTimeout(window.open("/product_show.aspx?pid="+idStr, "top"), 100);
}
TProductsManage.prototype.SetState = function(pid)
{
	$.getJSON('/Services/CAjax.aspx?do=SetProductsState&ProductID='+pid,function(data){
		if(data.results)
		{
			$('#p_'+data.pid).html((data.state==0)?'正常':'屏蔽');
		}else{
			
			
		}
	});
}
