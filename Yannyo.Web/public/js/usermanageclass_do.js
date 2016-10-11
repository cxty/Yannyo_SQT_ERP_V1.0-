/**
 * @author Cxty
 */
function TUserManageClass_do()
{
	this.Permissions = null;
}
TUserManageClass_do.prototype.ini = function()
{
	$('#bt_ok').click(function(){
		if ($('#cName').val() != '') {
			UserManageClass_do.sub();
		}else{
			jAlert('组名不能为空!','提示',function(){
				$('#cName').focus();
			});
		}
	});
	$('#bt_cl').click(function(){
		parent.HidBox();
	});
}
TUserManageClass_do.prototype.Checked = function()
{
	if(this.Permissions){
		var tArray = this.Permissions.split(',');
		for(var i=0;i<tArray.length;i++)
		{
			if (tArray[i]) {
				$("#UserPopedomList").jstree('check_node', $('#t_' + tArray[i]));
			}
		}
		tArray=null;
	}
}
TUserManageClass_do.prototype.sub = function()
{
	
	var menu = $("#UserPopedomList").jstree('get_checked');
       var ids="";
       for(i=0;i<menu.size();i++){
        ids += menu[i].id.replace('t_','')+",";
	   }
	$('#Popedoms').val(ids);

	$('#bForm').submit();
}