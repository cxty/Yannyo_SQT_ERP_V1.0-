
function TMexpressTemplates()
{
	this.PageBox = null;
	this.PageForm = null;
	this.m_ConfigInfoID = 0;
}
TMexpressTemplates.prototype.ini = function()
{

	$('#bt_Add').click(function()
	{
		MexpressTemplates.PageBox = dialog("创建模板","iframe:mexpresstemplates_do-"+MexpressTemplates.MConfigID+"-Add.aspx","550px","450px","iframe");
	});
	$('#bt_Delt').click(function()
	{
		MexpressTemplates.Del();
	});
	
}

TMexpressTemplates.prototype.HidUserBox= function()
{
	CloseBox();
}
TMexpressTemplates.prototype.Edit= function(eId)
{
	this.PageBox = dialog("修改运单模板",'iframe:mexpresstemplates_do-'+this.MConfigID+'-Edit.aspx?m_ExpressTemplatesID='+eId,"550px","450px","iframe");
}
TMexpressTemplates.prototype.Del= function(dId)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
			if(r)
			{
				var tValue = '';
				
				if(dId)
				{
					tValue = dId;
				}
				else
				{
					
				    for(var i=0 ;i<MexpressTemplates.PageForm.elements.length;i++){ 
				        if(MexpressTemplates.PageForm.elements[i].name=="cCheck"){ 
				            e=MexpressTemplates.PageForm.elements[i];
				            if(e.checked == true)
				            {
				                tValue+=e.value+',';
				            }
				        }
				    }
				}
				if(Trim(tValue) != '')
			    {
					
							MexpressTemplates.PageBox = dialog("删除运单模板",'iframe:mexpresstemplates_do-'+MexpressTemplates.MConfigID+'-Del.aspx?etId='+tValue,"550px","450px","iframe");
						
			    }
			    tValue = null;
			}
	});
}