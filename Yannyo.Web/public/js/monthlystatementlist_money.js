/**
 * @author Cxty
 */
function TMonthlystatementList_Money()
{
	
}
TMonthlystatementList_Money.prototype.ini = function()
{
	$('#sub_add').click(function(){
		parent.AddPayMoneyData(jQuery.parseJSON('{"MonthlyStatementAppendMoneyData":[{"MonthlyStatementAppendMoneyDataID":0,"MonthlyStatementID":0,"mstate":0,"mMoney":"'+$('#mMoney').val()+'","mDateTime":"'+$('#mDateTime').val()+'","mRemake":"'+$('#mRemake').val()+'"}]}'));
	});
	$('#sub_cancel').click(function(){
		parent.HidBox();
	});
}
