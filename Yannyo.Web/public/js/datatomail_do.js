/**
 * @author Cxty
 */
function TDataToMail_Do()
{
	
}
TDataToMail_Do.prototype.ini = function()
{
	$('#bt_ok').click(function(){
		if($('#dEmail').val()=='')
		{
			jAlert('请填写收件人邮箱!','提示',function(){
				$('#dEmail').focus();
			});
		}else{
			$('#bForm').submit();
		}
	});
	$('#bt_cl').click(function(){
		parent.HidBox();
	});
}
TDataToMail_Do.prototype.HidUserBox = function()
{
	CloseBox();
}
