/**
 * cxty@qq.com
 */
function TArmoney_ImportdataManage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TArmoney_ImportdataManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TArmoney_ImportdataManage.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TArmoney_ImportdataManage.prototype.OK = function()
{
	this.Act.value="OK";
	this.PageForm.submit();
}
TArmoney_ImportdataManage.prototype.HidUserBox = function()
{
	SysComm.HiddenPageBox(this.PageBox);
}
TArmoney_ImportdataManage.prototype.Delt = function()
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
TArmoney_ImportdataManage.prototype.ShowDelUserBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('armoney_do_Del-'+idStr+'.aspx',450,200);
}
TArmoney_ImportdataManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = SysComm.ShowPageBox('armoney_do_Edit-'+idStr+'.aspx',450,400);
}
