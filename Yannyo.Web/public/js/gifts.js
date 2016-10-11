/**
 * cxty@qq.com
 */
function TGiftsManage()
{
	this.PageBox = null;
	this.PageForm = null;
}
TGiftsManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
}
TGiftsManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = SysComm.ShowPageBox('gifts_do-Add.aspx',450,400);
}
TGiftsManage.prototype.HidUserBox = function()
{
	SysComm.HiddenPageBox(this.PageBox);
}
TGiftsManage.prototype.Delt = function()
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
        this.PageBox = SysComm.ShowPageBox('gifts_do_Del-'+tValue+'.aspx',450,200);
    }
    tValue = null;
}
TGiftsManage.prototype.ShowDelUserBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('gifts_do_Del-'+idStr+'.aspx',450,200);
}
TGiftsManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('gifts_do_Edit-'+idStr+'.aspx',450,400);
}
