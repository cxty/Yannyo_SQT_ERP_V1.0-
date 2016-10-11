/**
 * cxty@qq.com
 */
function TApmoneyManage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TApmoneyManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TApmoneyManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = SysComm.ShowPageBox('apmoney_do-Add.aspx',450,400);
}
TApmoneyManage.prototype.ShowAddBatBox = function()
{
	this.PageBox = SysComm.ShowPageBox('apmoney_bat.aspx',650,530);
}
TApmoneyManage.prototype.ShowImportUserBox = function()
{
	this.PageBox = SysComm.ShowPageBox('apmoney_importdata.aspx',650,500);
}
TApmoneyManage.prototype.ShowImportUserBoxErp = function()
{
	this.PageBox = SysComm.ShowPageBox('apmoney_do-Syn.aspx',450,400);
}
TApmoneyManage.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TApmoneyManage.prototype.HidUserBox = function()
{
	SysComm.HiddenPageBox(this.PageBox);
}
TApmoneyManage.prototype.Delt = function()
{
	var tValue = '';
    for(var i=0 ;i<this.PageForm.elements.length;i++){ 
        if(this.PageForm.elements[i].name=="cCheck"){ 
            e=this.PageForm.elements[i];
            if(e.checked == true)
            {
                tValue+=e.value+',';
            }
        }
    }
    if(Trim(tValue) != '')
    {
        this.PageBox = SysComm.ShowPageBox('apmoney_do_Del-'+tValue+'.aspx',450,200);
    }
    tValue = null;
}
TApmoneyManage.prototype.ShowDelUserBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('apmoney_do_Del-'+idStr+'.aspx',450,200);
}
TApmoneyManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('apmoney_do_Edit-'+idStr+'.aspx',450,400);
}
