/**
 * cxty@qq.com
 */
function TStaffStoresManage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TStaffStoresManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TStaffStoresManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("绑定人员客户信息",'iframe:staffstores_do.aspx',450,300,"iframe",'HidBox();');//SysComm.ShowPageBox('staffstores_do-Add.aspx',450,300);
}
TStaffStoresManage.prototype.ShowimportdataBox = function()
{
	this.PageBox = dialog("导入数据",'iframe:staffstores_importdata.aspx',450,300,"iframe",'HidBox();');//SysComm.ShowPageBox('staffstores_importdata.aspx',450,300);
}
TStaffStoresManage.prototype.HidUserBox = function()
{
	//SysComm.HiddenPageBox(this.PageBox);
	CloseBox();
	location=location;
}
TStaffStoresManage.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TStaffStoresManage.prototype.SearchB = function()
{
	this.Act.value="SearchB";
	this.PageForm.submit();
}
TStaffStoresManage.prototype.SearchC = function()
{
	this.Act.value="SearchC";
	this.PageForm.submit();
}
TStaffStoresManage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			var tValue = '';
		    for(var i=0 ;i<StaffStoresManage.PageForm.elements.length;i++){ 
		        if(StaffStoresManage.PageForm.elements[i].name=="cCheck"){ 
		            e=StaffStoresManage.PageForm.elements[i];
		            if(e.checked == true)
		            {
		                tValue+=e.value+',';
		            }
		        }
		    }
		    if(Trim(tValue) != '')
		    {
				
			        	StaffStoresManage.PageBox = dialog("删除记录",'iframe:staffstores_do_Del-'+tValue+'.aspx',450,200,"iframe",'HidBox();');// SysComm.ShowPageBox('staffstores_do_Del-'+tValue+'.aspx',450,200);
			        
		    }
		    tValue = null;
		}
	});
}
TStaffStoresManage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			StaffStoresManage.PageBox = dialog("删除记录",'iframe:staffstores_do_Del-'+idStr+'.aspx',450,200,"iframe",'HidBox();');//SysComm.ShowPageBox('staffstores_do_Del-'+idStr+'.aspx',450,200);
		}
	});
}
TStaffStoresManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改记录",'iframe:staffstores_do_Edit-'+idStr+'.aspx',450,200,"iframe",'HidBox();');//SysComm.ShowPageBox('staffstores_do_Edit-'+idStr+'.aspx',450,300);
}
TStaffStoresManage.prototype.ShowUpBox = function(idStr)
{
	this.PageBox = dialog("上岗",'iframe:staff_do_Up-'+idStr+'.aspx',450,450,"iframe",'HidBox();');//SysComm.ShowPageBox('staff_do_Up-'+idStr+'.aspx',550,450);
}
TStaffStoresManage.prototype.ShowDownBox = function(idStr)
{
	this.PageBox = dialog("离岗",'iframe:staff_do_Down-'+idStr+'.aspx',450,450,"iframe",'HidBox();');//SysComm.ShowPageBox('staff_do_Down-'+idStr+'.aspx',550,450);
}
