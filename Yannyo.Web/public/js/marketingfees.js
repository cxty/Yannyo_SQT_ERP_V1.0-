/**
 * cxty@qq.com
 */
function TMarketingFees()
{
	this.PageBox = null;
	this.PageForm = null;
}
TMarketingFees.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
}
TMarketingFees.prototype.ShowAddUserBox = function()
{
	this.PageBox = SysComm.ShowPageBox('marketingfees_do-Add.aspx',450,400);
}
TMarketingFees.prototype.ShowAddRevenueBox = function()
{
	this.PageBox = SysComm.ShowPageBox('marketingfeesrevenue_do-Add.aspx',450,400);
}
TMarketingFees.prototype.ShowAddBatBox = function()
{
	this.PageBox = SysComm.ShowPageBox('marketingfees_bat.aspx',650,500);
}
TMarketingFees.prototype.ShowImportBox = function()
{
	this.PageBox = SysComm.ShowPageBox('marketingfees_importdata.aspx',450,400);
}

TMarketingFees.prototype.HidUserBox = function()
{
	SysComm.HiddenPageBox(this.PageBox);
}
TMarketingFees.prototype.Delt = function()
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
        this.PageBox = SysComm.ShowPageBox('marketingfees_do_Del-'+tValue+'.aspx',450,200);
    }
    tValue = null;
}
TMarketingFees.prototype.ShowDelUserBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('marketingfees_do_Del-'+idStr+'.aspx',450,200);
}
TMarketingFees.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('marketingfees_do_Edit-'+idStr+'.aspx',450,400);
}
TMarketingFees.prototype.ShowEditRevenueBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('marketingfeesrevenue_do_Edit-'+idStr+'.aspx',450,400);
}