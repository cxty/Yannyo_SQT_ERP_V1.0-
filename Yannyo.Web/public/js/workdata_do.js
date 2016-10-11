/**
 * @author Cxty
 */
function TWorkdata_do()
{
	
}
TWorkdata_do.prototype.ini = function()
{
	$('#bt_s').click(function(){
		parent.SetWorkData(jQuery.parseJSON('{\"wDate\":\"'+$('#wDate').val()+'\",\"wEnterprise\":\"'+$('#wEnterprise').val()+'\",\"wTel\":\"'+$('#wTel').val()+'\",\"wJobs\":\"'+$('#wJobs').val()+'\",\"wIncome\":\"'+$('#wIncome').val()+'\"}'));
		window.parent.HidBox();
	});
	$('#bt_c').click(function(){
		window.parent.HidBox();
	});
	var Data = parent.GetWorkData();
	if(Data)
	{
		$('#wDate').val(Data.wDate);
		$('#wEnterprise').val(Data.wEnterprise);
		$('#wTel').val(Data.wTel);
		$('#wJobs').val(Data.wJobs);
		$('#wIncome').val(Data.wIncome);
	}
}
