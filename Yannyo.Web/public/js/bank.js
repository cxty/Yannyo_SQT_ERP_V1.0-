/**
 * cxty@qq.com
 */
function TBank()
{
	this.PageBox = null;
	this.PageForm = null;
}
TBank.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
}
TBank.prototype.HidUserBox = function()
{
	SysComm.HiddenPageBox(this.PageBox);
}
TBank.prototype.ShowAddBankBox = function()
{
	this.PageBox = SysComm.ShowPageBox('bank_do-Add.aspx',450,400);
}
TBank.prototype.Delt = function()
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
        this.PageBox = SysComm.ShowPageBox('bank_do_Del-'+tValue+'.aspx',450,200);
    }
    tValue = null;
}
TBank.prototype.ShowDelBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('bank_do_Del-'+idStr+'.aspx',450,200);
}
TBank.prototype.ShowEditBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('bank_do_Edit-'+idStr+'.aspx',450,400);
}