/**
 * cxty@qq.com
 */
function TCostValenceManage()
{
	this.PageBox = null;
	this.PageForm = null;
}
TCostValenceManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
}
TCostValenceManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("添加成本变动",'iframe:costvalence_do-Add.aspx',450,400,"iframe",'HidBox();'); //SysComm.ShowPageBox('costvalence_do-Add.aspx',450,400);
}
TCostValenceManage.prototype.HidUserBox = function()
{
	CloseBox();
	location=location;
	//SysComm.HiddenPageBox(this.PageBox);
}
TCostValenceManage.prototype.Delt = function()
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
        this.PageBox = dialog("删除成本变动",'iframe:costvalence_do_Del-'+tValue+'.aspx',450,200,"iframe",'HidBox();');//SysComm.ShowPageBox('costvalence_do_Del-'+tValue+'.aspx',450,200);
    }
    tValue = null;
}
TCostValenceManage.prototype.ShowDelUserBox = function(idStr)
{
	this.PageBox = dialog("删除成本变动",'iframe:costvalence_do_Del-'+idStr+'.aspx',450,200,"iframe",'HidBox();');// SysComm.ShowPageBox('costvalence_do_Del-'+idStr+'.aspx',450,200);
}
TCostValenceManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改成本变动",'iframe:costvalence_do_Edit-'+idStr+'.aspx',450,400,"iframe",'HidBox();');//SysComm.ShowPageBox('costvalence_do_Edit-'+idStr+'.aspx',450,400);
}
