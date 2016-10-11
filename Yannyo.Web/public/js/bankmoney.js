/**
 * cxty@qq.com
 */
function TBankMoney()
{
	this.PageBox = null;
	this.PageForm = null;
}
TBankMoney.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
}
TBankMoney.prototype.HidUserBox = function()
{
	SysComm.HiddenPageBox(this.PageBox);
}
TBankMoney.prototype.ShowAddBankBox = function()
{
	this.PageBox = SysComm.ShowPageBox('bank.aspx',450,400);
}
TBankMoney.prototype.ShowAddMoneyBox = function()
{
	this.PageBox = SysComm.ShowPageBox('bankmoney_do-Add.aspx',450,400);
}
TBankMoney.prototype.ShowImportBox = function()
{
	this.PageBox = SysComm.ShowPageBox('bankmoney_importdata.aspx',450,400);
}
TBankMoney.prototype.Delt = function()
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
        this.PageBox = SysComm.ShowPageBox('bankmoney_do_Del-'+tValue+'.aspx',450,200);
    }
    tValue = null;
}
TBankMoney.prototype.ShowDelBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('bankmoney_do_Del-'+idStr+'.aspx',450,200);
}
TBankMoney.prototype.ShowEditBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('bankmoney_do_Edit-'+idStr+'.aspx',450,400);
}