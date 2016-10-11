/**
 * cxty@qq.com
 */
function TSupplierManage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TSupplierManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TSupplierManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("添加供应商",'iframe:supplier_do-Add.aspx',"490px","400px","iframe");
}
TSupplierManage.prototype.dataAct = function () {
    this.PageBox = dialog("导入导出", 'iframe:data_import_export-Supplier.aspx', "300px", "200px", "iframe");
}
TSupplierManage.prototype.HidUserBox = function()
{
	CloseBox();
}
TSupplierManage.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TSupplierManage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			var tValue = '';
		    for(var i=0 ;i<SupplierManage.PageForm.elements.length;i++){ 
		        if(SupplierManage.PageForm.elements[i].name=="cCheck"){ 
		            e=SupplierManage.PageForm.elements[i];
		            if(e.checked == true)
		            {
		                tValue+=e.value+',';
		            }
		        }
		    }
		    if(Trim(tValue) != '')
		    {
				
			        	SupplierManage.PageBox = dialog("删除供应商",'iframe:supplier_do_Del-'+tValue+'.aspx',"490px","200px","iframe");
					
		    }
		    tValue = null;
		}
	});
}
TSupplierManage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			SupplierManage.PageBox = dialog("删除供应商",'iframe:supplier_do_Del-'+idStr+'.aspx',"490px","200px","iframe");
		}
	});
}
TSupplierManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改供应商",'iframe:supplier_do_Edit-'+idStr+'.aspx',"490px","400px","iframe");
}
