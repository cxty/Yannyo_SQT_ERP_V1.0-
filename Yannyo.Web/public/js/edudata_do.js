/**
 * @author Cxty
 */
function TEdudata_do()
{
	
}
TEdudata_do.prototype.ini = function()
{
	$('#bt_s').click(function(){
		parent.SetEduData(jQuery.parseJSON('{\"eDate\":\"'+$('#eDate').val()+'\",\"eSchools\":\"'+$('#eSchools').val()+'\",\"eContent\":\"'+$('#eContent').val()+'\"}'));
		window.parent.HidBox();
	});
	$('#bt_c').click(function(){
		window.parent.HidBox();
	});
	var EduData = parent.GetEduData();
	if(EduData)
	{
		$('#eDate').val(EduData.eDate);
		$('#eSchools').val(EduData.eSchools);
		$('#eContent').val(EduData.eContent);
	}
}
