/**
 * @author Cxty
 */
function TMConfig()
{
	this.PageBox = null;
	this.PageForm = null;
}
TMConfig.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	$('#b_add').click(function(){
		MConfig.PageBox = dialog("添加新网店","iframe:mconfig_do-Add.aspx","500px","350px","iframe");
	});
}
TMConfig.prototype.HidUserBox = function()
{
	CloseBox();
}
TMConfig.prototype.edit = function(idStr)
{
	this.PageBox = dialog("修改配置信息",'iframe:mconfig_do_Edit-'+idStr+'.aspx',"500px","350px","iframe");
}
TMConfig.prototype.state = function(idStr)
{
	$.getJSON('/mconfig_do_State-'+idStr+'.aspx?format=json',function(data){
			if(data.results.state)
			{
				alert(data.results.msg);
				$('#m_state_'+data.results.idStr).html((data.results.state==0)?'正常':'屏蔽');
				$('#m_tool_'+data.results.idStr).html((data.results.state==0)?'关闭':'开启');
			}
			else
			{
				alert(data.results.msg);
			}
		});
}
