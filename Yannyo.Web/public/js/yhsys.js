/**
 * cxty@qq.com
 */
function TYHsysManage()
{
	this.PageBox = null;
	this.PageForm = null;
}
TYHsysManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
}
TYHsysManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("添加客户系统",'iframe:yhsys_do-Add.aspx',"450px","400px","iframe");
}
TYHsysManage.prototype.HidUserBox = function()
{
	CloseBox();
}
TYHsysManage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			var tValue = '';
		    for(var i=0 ;i<YHsysManage.PageForm.elements.length;i++){ 
		        if(YHsysManage.PageForm.elements[i].name=="cCheck"){ 
		            e=YHsysManage.PageForm.elements[i];
		            if(e.checked == true)
		            {
		                tValue+=e.value+',';
		            }
		        }
		    }
		    if(Trim(tValue) != '')
		    {
				
						YHsysManage.PageBox = dialog("删除客户系统",'iframe:yhsys_do_Del-'+tValue+'.aspx',"450px","400px","iframe");
					
		    }
		    tValue = null;
		}
	});
}
TYHsysManage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			YHsysManage.PageBox = dialog("删除客户系统",'iframe:yhsys_do_Del-'+idStr+'.aspx',"450px","400px","iframe");
		}
	});
}
TYHsysManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改客户系统",'iframe:yhsys_do_Edit-'+idStr+'.aspx',"450px","400px","iframe");
}
