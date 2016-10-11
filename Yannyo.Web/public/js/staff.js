/**
 * cxty@qq.com
 */
function TStaffManage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.Act = null;
}
TStaffManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
		this.Act = document.getElementById('Act');
}
TStaffManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("添加人员",'iframe:staff_do-Add.aspx',650,450,"iframe",'HidBox();');//  SysComm.ShowPageBox('staff_do-Add.aspx',450,250);
}
TStaffManage.prototype.HidUserBox = function()
{
	//SysComm.HiddenPageBox(this.PageBox);
	CloseBox();
	location=location;
}
TStaffManage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			var tValue = '';
		    for(var i=0 ;i<StaffManage.PageForm.elements.length;i++){ 
		        if(StaffManage.PageForm.elements[i].name=="cCheck"){ 
		            e=StaffManage.PageForm.elements[i];
		            if(e.checked == true)
		            {
		                tValue+=e.value+',';
		            }
		        }
		    }
		    if(Trim(tValue) != '')
		    {
				
			        	StaffManage.PageBox = dialog("删除人员",'iframe:staff_do_Del-'+tValue+'.aspx',450,200,"iframe",'HidBox();');
					
		    }
		    tValue = null;
		}
	});
}
TStaffManage.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TStaffManage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			StaffManage.PageBox = dialog("删除人员",'iframe:staff_do_Del-'+idStr+'.aspx',450,200,"iframe",'HidBox();');//SysComm.ShowPageBox('staff_do_Del-'+idStr+'.aspx',450,200);
		}
	});
}
TStaffManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改人员",'iframe:staff_do_Edit-'+idStr+'.aspx',650,450,"iframe",'HidBox();');// SysComm.ShowPageBox('staff_do_Edit-'+idStr+'.aspx',450,250);
}
TStaffManage.prototype.ShowUpBox = function(idStr)
{
	this.PageBox = dialog("上岗",'iframe:staff_do_Up-'+idStr+'.aspx',450,450,"iframe",'HidBox();');//SysComm.ShowPageBox('staff_do_Up-'+idStr+'.aspx',550,450);
}
TStaffManage.prototype.ShowDownBox = function(idStr)
{
	this.PageBox = dialog("离岗",'iframe:staff_do_Down-'+idStr+'.aspx',450,450,"iframe",'HidBox();');//SysComm.ShowPageBox('staff_do_Down-'+idStr+'.aspx',550,450);
}
//修改状态
TStaffManage.prototype.State = function(idStr)
{
	if(idStr)
	{
		jConfirm('是否确认 修改该人员状态?', '提示',function(r){
			jQuery.getJSON('/staff_do.aspx?Act=State&format=json&sid='+idStr,null,function(data){
				if(data)
				{
					if (data.results.state == 'True')
					{
						$('#s_'+data.results.StaffID).html(data.results.StaffState==0?"正常":"<span style=\"color:#F00\" >屏蔽</span>");
					}
					jAlert(data.results.msg, '提示');
				}
			});
		});
	}else{
		jAlert('对象错误!','提示');
	}
}