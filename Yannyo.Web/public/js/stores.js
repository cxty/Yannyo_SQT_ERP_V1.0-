/**
 * cxty@qq.com
 */
function TStoresManage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TStoresManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TStoresManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("添加客户",'iframe:stores_do-Add.aspx',"550px","400px","iframe");
}
TStoresManage.prototype.dataAct = function () {
    this.PageBox = dialog("导入导出", 'iframe:data_import_export-Stores.aspx', "300px", "200px", "iframe");
}
TStoresManage.prototype.HidUserBox = function()
{
	CloseBox();
}
TStoresManage.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TStoresManage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
			if (r) {
				var tValue = '';
			    for(var i=0 ;i<StoresManage.PageForm.elements.length;i++){ 
			        if(StoresManage.PageForm.elements[i].name=="cCheck"){ 
			            e=StoresManage.PageForm.elements[i];
			            if(e.checked == true)
			            {
			                tValue+=e.value+',';
			            }
			        }
			    }
			    if(Trim(tValue) != '')
			    {
					
							StoresManage.PageBox = dialog("删除客户", 'iframe:stores_do_Del-' + tValue + '.aspx', "450px", "200px", "iframe");
						
			    }
			    tValue = null;
			}
	});
}
TStoresManage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if (r) {
			StoresManage.PageBox = dialog("删除客户",'iframe:stores_do_Del-'+idStr+'.aspx',"450px","200px","iframe");
		}
	});
}
TStoresManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改客户",'iframe:stores_do_Edit-'+idStr+'.aspx',"550px","400px","iframe");
}
TStoresManage.prototype.ShowImportBox = function()
{
	this.PageBox = dialog("导入客户",'iframe:stores_do-Import.aspx',"450px","200px","iframe");
}
