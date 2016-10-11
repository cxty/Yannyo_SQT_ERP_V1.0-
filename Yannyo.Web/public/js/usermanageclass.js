/**
 * @author Cxty
 */
function TUserManageClass()
{
	this.PageBox = null;
	this.PageForm = null;
}
TUserManageClass.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	$('#bt_add').click(function(){
		this.PageBox = dialog("添加操作员组","iframe:usermanageclass_do-Add.aspx","600px","400px","iframe");
	});
}
TUserManageClass.prototype.HidUserBox = function()
{
	CloseBox();
}
TUserManageClass.prototype.ShowEditBox = function(cid)
{
	if(cid)
	{
		this.PageBox = dialog("操作员组","iframe:usermanageclass_do_Edit-"+cid+".aspx","600px","400px","iframe");
	}
}
TUserManageClass.prototype.ShowDelBox = function(cid)
{
	if(cid)
	{
		this.PageBox = dialog("删除操作员组","iframe:usermanageclass_do_Del-"+cid+".aspx","300px","200px","iframe");
	}
}
