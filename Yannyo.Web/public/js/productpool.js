/**
 * cxty@qq.com
 */
function TProductPoolManage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TProductPoolManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TProductPoolManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("新建联营商品",'iframe:productpool_do-Add.aspx',450,400,"iframe",'HidBox();'); // SysComm.ShowPageBox('productpool_do-Add.aspx',450,400);
}

TProductPoolManage.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TProductPoolManage.prototype.HidUserBox = function()
{
	CloseBox();
	location=location;
}
TProductPoolManage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			var tValue = '';
		    for(var i=0 ;i<ProductPoolManage.PageForm.elements.length;i++){ 
		        if(ProductPoolManage.PageForm.elements[i].name=="cCheck"){ 
		            e=ProductPoolManage.PageForm.elements[i];
		            if(e.checked == true)
		            {
		                tValue+=e.value+',';
		            }
		        }
		    }
		    if(Trim(tValue) != '')
		    {
				
				        ProductPoolManage.PageBox = dialog("删除联营商品",'iframe:productpool_do_Del-'+tValue+'.aspx',450,200,"iframe",'HidBox();');//SysComm.ShowPageBox('productpool_do_Del-'+tValue+'.aspx',450,200);
				    
		    }
		    tValue = null;
		}
	});
}
TProductPoolManage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			ProductPoolManage.PageBox = dialog("删除联营商品",'iframe:productpool_do_Del-'+idStr+'.aspx',450,200,"iframe",'HidBox();');//SysComm.ShowPageBox('productpool_do_Del-'+idStr+'.aspx',450,200);
		}
	});
}
TProductPoolManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改联营商品",'iframe:productpool_do_Edit-'+idStr+'.aspx',450,400,"iframe",'HidBox();');//SysComm.ShowPageBox('productpool_do_Edit-'+idStr+'.aspx',450,400);
}
