/**
 * @author Cxty
 */
function TMsendgoods_Exp()
{
	
}
TMsendgoods_Exp.prototype.ini = function()
{
	$('#Sub_button').click(function(){
		if($('#ExpNO').val()=='')
		{
			jAlert('请填写运单号!','提示');
		}else if($('#ExpName').children('option:selected').val()==0){
				jAlert('请选择物流公司!','提示');
		}else{
			parent.SetExp({'ExpID':$('#ExpName').children('option:selected').val(),'ExpNO':$('#ExpNO').val()});
		}
	});
	$('#c_button').click(function(){
		parent.CloseBox();
	});
}
