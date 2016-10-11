function TUserManageDo()
{
	this.PageForm = null;
	this.Permissions = '';
}
TUserManageDo.prototype.ini = function()
{
	this.PageForm = $('#bForm');
	$('#uType').change(function(){
		var _p = $(this).children('option:selected').attr('Popedoms');
		if(_p){
			var tArray = _p.split(',');
			for(var i=0;i<tArray.length;i++)
			{
				if (tArray[i]) {
					$("#UserPopedomList").jstree('check_node', $('#t_' + tArray[i]));
				}
			}
			tArray=null;
		}else{
			$("#UserPopedomList").jstree('uncheck_all');
		}
	});
	
	//全选，全不选
	$('#All_Storage').click(function(){
		
		$("input[name='StorageIDStr']").attr('checked',$(this).attr('checked'));
		
	});
	//单条选择，判断是否已全选
	$("input[name='StorageIDStr'][id!='All_Storage']").click(function(){
		
		$.each($("input[name='StorageIDStr'][id!='All_Storage']"),function(i,n){
			
			if(!$(n).attr('checked')){
				$('#All_Storage').attr('checked',false);
				return false;
			}else if(i==$("input[name='StorageIDStr'][id!='All_Storage']").length-1){
					$('#All_Storage').attr('checked','checked');
			}	
			
		});
		
	});
}
TUserManageDo.prototype.Checked = function()
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
TUserManageDo.prototype.sub = function()
{
	
	var menu = $("#UserPopedomList").jstree('get_checked');
       var ids="";
       for(i=0;i<menu.size();i++){
        ids += menu[i].id.replace('t_','')+",";
	   }
	$('#uPermissions').val(ids);

	this.PageForm.submit();
}