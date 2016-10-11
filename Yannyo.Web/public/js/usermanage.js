/**
 * cxty@qq.com
 */
function TUserManage()
{
	this.PageBox = null;
	this.PageForm = null;
}
TUserManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
}
TUserManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("添加新操作员","iframe:usermanage_do-Add.aspx","600px","400px","iframe");
}
TUserManage.prototype.HidUserBox = function()
{
	CloseBox();//SysComm.HiddenPageBox(this.PageBox);
}
TUserManage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			var tValue = '';
		    for(var i=0 ;i<UserManage.PageForm.elements.length;i++){ 
		        if(UserManage.PageForm.elements[i].name=="cCheck"){ 
		            e=UserManage.PageForm.elements[i];
		            if(e.checked == true)
		            {
		                tValue+=e.value+',';
		            }
		        }
		    }
		    if(Trim(tValue) != '')
		    {
		        UserManage.PageBox = dialog("删除操作员",'iframe:usermanage_do_Del-'+tValue+'.aspx',"500px","200px","iframe");
		    }
		    tValue = null;
		}
	});
}
TUserManage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			UserManage.PageBox = dialog("删除操作员",'iframe:usermanage_do_Del-'+idStr+'.aspx',"500px","200px","iframe"); 
		}
	});
	
}
TUserManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改操作员",'iframe:usermanage_do_Edit-'+idStr+'.aspx',"600px","400px","iframe"); 
}
