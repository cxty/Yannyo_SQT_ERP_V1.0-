/**
 * cxty@qq.com
 */
function TValenceManage()
{
	this.PageBox = null;
	this.PageForm = null;
}
TValenceManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
}
TValenceManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = SysComm.ShowPageBox('valence_do-Add.aspx',450,400);
}
TValenceManage.prototype.HidUserBox = function()
{
	SysComm.HiddenPageBox(this.PageBox);
}
TValenceManage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			var tValue = '';
		    for(var i=0 ;i<ValenceManage.PageForm.elements.length;i++){ 
		        if(ValenceManage.PageForm.elements[i].name=="cCheck"){ 
		            e=ValenceManage.PageForm.elements[i];
		            if(e.checked == true)
		            {
		                tValue+=e.value+',';
		            }
		        }
		    }
		    if(Trim(tValue) != '')
		    {
				
			        	ValenceManage.PageBox = dialog("删除变价",'iframe:valence_do_Del-'+tValue+'.aspx',"450px","200px","iframe");// SysComm.ShowPageBox('valence_do_Del-'+tValue+'.aspx',450,200);
					
		    }
		    tValue = null;
		}
	});
}
TValenceManage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			ValenceManage.PageBox = dialog("删除变价",'iframe:valence_do_Del-'+idStr+'.aspx',"450px","200px","iframe");//SysComm.ShowPageBox('valence_do_Del-'+idStr+'.aspx',450,200);
		}
	});
}
TValenceManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('valence_do_Edit-'+idStr+'.aspx',450,400);
}
