/**
 * cxty@qq.com
 */
function TStorage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TStorage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TStorage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("添加新仓库","iframe:storage_do-Add.aspx","500px","400px","iframe");
}
TStorage.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TStorage.prototype.dataAct = function () {
    this.PageBox = dialog("导入导出", 'iframe:data_import_export-Storage.aspx', "300px", "200px", "iframe");
}
TStorage.prototype.HidUserBox = function()
{
	CloseBox();
}
TStorage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			var tValue = '';
		    for(var i=0 ;i<Storage.PageForm.elements.length;i++){ 
		        if(Storage.PageForm.elements[i].name=="cCheck"){ 
		            e=Storage.PageForm.elements[i];
		            if(e.checked == true)
		            {
		                tValue+=e.value+',';
		            }
		        }
		    }
		    if(Trim(tValue) != '')
		    {
				
			    Storage.PageBox = dialog("删除仓库",'iframe:storage_do_Del-'+tValue+'.aspx',"450px","200px","iframe");
					
		    }
		    tValue = null;
		}
	});
}
TStorage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			Storage.PageBox = dialog("删除仓库",'iframe:storage_do_Del-'+idStr+'.aspx',"450px","200px","iframe"); 
		}
	});
}
TStorage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改仓库",'iframe:storage_do_Edit-'+idStr+'.aspx',"500px","400px","iframe");
}
//修改状态
TStorage.prototype.State = function(idStr)
{
	if(idStr)
	{
		jConfirm('是否确认 修改该仓库状态?', '提示',function(r){
			jQuery.getJSON('/storage_do.aspx?Act=State&format=json&sid='+idStr,null,function(data){
				if(data)
				{
					if (data.results.state == 'True')
					{
						$('#s_'+data.results.StorageID).html(data.results.StorageState==0?"正常":"<span style=\"color:#F00\" >屏蔽</span>");
					}
					jAlert(data.results.msg, '提示');
				}
			});
		});
	}else{
		jAlert('对象错误!','提示');
	}
}