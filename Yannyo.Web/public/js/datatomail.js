/**
 * @author Cxty
 */
function TDataToMail()
{
	this.PageBox = null;
}
TDataToMail.prototype.ini = function()
{
	$('#bt_add').click(function(){
		this.PageBox = dialog("添加转发",'iframe:datatomail_do-Add.aspx',"550px","250px","iframe");
	});
}
TDataToMail.prototype.HidUserBox = function()
{
	CloseBox();
}
TDataToMail.prototype.ShowEditBox = function(did)
{
	this.PageBox = dialog("修改转发",'iframe:datatomail_do_Edit-'+did+'.aspx',"550px","250px","iframe");
}
TDataToMail.prototype.ShowDelBox = function(did)
{
	jConfirm('是否 <b>确定删除该转发</b> 删除后将无法恢复?','提示',function(r){
		if(r)
		{
			DataToMail.PageBox = dialog("删除转发",'iframe:datatomail_do_Del-'+did+'.aspx',"300px","150px","iframe");
		}
	});
}