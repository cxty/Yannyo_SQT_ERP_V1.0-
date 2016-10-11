/**
 * cxty@qq.com
 */
function TOrderField()
{
	this.PageBox = null;
	this.PageForm = null;
}
TOrderField.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
}
TOrderField.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("添加新字段","iframe:OrderField_do-Add.aspx","500px","400px","iframe");
}
TOrderField.prototype.HidUserBox = function()
{
	CloseBox();
}
TOrderField.prototype.Delt = function()
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
        this.PageBox = dialog("删除字段",'iframe:OrderField_do_Del-'+tValue+'.aspx',"500px","200px","iframe");
    }
    tValue = null;
}
TOrderField.prototype.ShowDelUserBox = function(idStr)
{
	this.PageBox = dialog("删除字段",'iframe:OrderField_do_Del-'+idStr+'.aspx',"500px","200px","iframe"); 
}
TOrderField.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改字段",'iframe:OrderField_do_Edit-'+idStr+'.aspx',"500px","400px","iframe"); 
}
