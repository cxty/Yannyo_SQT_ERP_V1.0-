/**
 * cxty@qq.com
 */
function TErpDataManage()
{
	this.PageBox = null;
	this.PageForm = null;
}
TErpDataManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
}
TErpDataManage.prototype.ShowimportErpdataBox = function()
{
	this.PageBox = SysComm.ShowPageBox('geterpdata.aspx',450,400);
}
TErpDataManage.prototype.ShowSyncErpdataBox = function()
{
	this.PageBox = SysComm.ShowPageBox('erpdata_sync.aspx',450,200);
}
TErpDataManage.prototype.HidUserBox = function()
{
	SysComm.HiddenPageBox(this.PageBox);
}
TErpDataManage.prototype.Delt = function()
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
        this.PageBox = SysComm.ShowPageBox('erpdata_do_Del-'+tValue+'.aspx',450,200);
    }
    tValue = null;
}
TErpDataManage.prototype.ShowDelUserBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('erpdata_do_Del-'+idStr+'.aspx',450,200);
}

