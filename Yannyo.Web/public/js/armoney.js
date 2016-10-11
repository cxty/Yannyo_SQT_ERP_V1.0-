/**
 * cxty@qq.com
 */
function TArmoneyManage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TArmoneyManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TArmoneyManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = SysComm.ShowPageBox('armoney_do-Add.aspx',450,500);
}
TArmoneyManage.prototype.ShowAddBatBox = function()
{
	this.PageBox = SysComm.ShowPageBox('armoney_bat.aspx',680,500);
}
TArmoneyManage.prototype.ShowImportUserBox = function()
{
	this.PageBox = SysComm.ShowPageBox('armoney_importdata.aspx',650,500);
}
TArmoneyManage.prototype.ShowImportUserBoxErp = function()
{
	this.PageBox = SysComm.ShowPageBox('armoney_do-Syn.aspx',450,400);
}
TArmoneyManage.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TArmoneyManage.prototype.HidUserBox = function()
{
	SysComm.HiddenPageBox(this.PageBox);
}
TArmoneyManage.prototype.Delt = function()
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
        this.PageBox = SysComm.ShowPageBox('armoney_do_Del-'+tValue+'.aspx',450,200);
    }
    tValue = null;
}
TArmoneyManage.prototype.ShowDelUserBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('armoney_do_Del-'+idStr+'.aspx',450,200);
}
TArmoneyManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('armoney_do_Edit-'+idStr+'.aspx',450,500);
}
