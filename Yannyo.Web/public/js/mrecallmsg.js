/**
 * @author Cxty
 */
function TM_ReCallMsg()
{
	this.MConfigID = 0;
	this.Act = '';
}
TM_ReCallMsg.prototype.ini = function()
{
	$('#bt_ok').click(function()
	{
		if (M_ReCallMsg.Act == 'TradeMemo') {
			$('#form1').submit();
		}
		else {
			window.parent.Close_ReCallMsg(M_ReCallMsg.GetMsg());
		}
	});
	$('#bt_cancel').click(function()
	{
		window.parent.HidBox();
	});
}
TM_ReCallMsg.prototype.HidUserBox = function()
{
	CloseBox();
}
TM_ReCallMsg.prototype.SetMsg = function(msg)
{
	if(msg)
	{
		$('#tMsg').val(tMsg);
	}
}
TM_ReCallMsg.prototype.GetMsg = function()
{

	return $('#tMsg').val();

}
