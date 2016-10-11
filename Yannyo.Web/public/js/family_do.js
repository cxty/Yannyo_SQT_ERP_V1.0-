/**
 * @author Cxty
 */
function TFamilydata_do()
{
	
}
TFamilydata_do.prototype.ini = function()
{
	$('#bt_s').click(function(){
		parent.SetFamilyData(jQuery.parseJSON('{\"fTitle\":\"'+$('#fTitle').val()+'\",\"fName\":\"'+$('#fName').val()+'\",\"fAge\":\"'+$('#fAge').val()+'\",\"fEnterprise\":\"'+$('#fEnterprise').val()+'\",\"fWork\":\"'+$('#fWork').val()+'\",\"fAddress\":\"'+$('#fAddress').val()+'\",\"fTel\":\"'+$('#fTel').val()+'\"}'));
		window.parent.HidBox();
	});
	$('#bt_c').click(function(){
		window.parent.HidBox();
	});
	var Data = parent.GetFamilyData();
	if(Data)
	{
		$('#fTitle').val(Data.fTitle);
		$('#fName').val(Data.fName);
		$('#fAge').val(Data.fAge);
		$('#fEnterprise').val(Data.fEnterprise);
		$('#fWork').val(Data.fWork);
		$('#fAddress').val(Data.fAddress);
		$('#fTel').val(Data.fTel);
	}
}
