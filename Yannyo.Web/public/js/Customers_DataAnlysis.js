/**
 * cxty@qq.com
 */
function TCustomers_DataAnlysis()
{
	this.isIsPool = 0;
}
TCustomers_DataAnlysis.prototype.ini = function()
{
	$('#analysis_button').click(function(){
		if ($('#bDate').val() != '') {
			if ($('#eDate').val() != '') {
				$('#form1').attr('action','customers_dataanalysis-'+$('#dType').children('option:selected').val()+'-'+Customers_DataAnlysis.isIsPool+'.aspx');
				$('#form1').submit();
			}else{
				jAlert('请选择结束时间','提示');
				$('#eDate').focus();
			}
		}else{
			jAlert('请选择开始时间','提示');
			$('#bDate').focus();
		}
	});

	//点击导出
	$("#export_data").click(function () {
		var _url = '/customers_dataanalysis.aspx?Act=Export&isIsPool='+Customers_DataAnlysis.isIsPool+'&dType=' + $("#dType").children('option:selected').val() + '&bDate=' + $("#bDate").val() + '&eDate=' + $("#eDate").val();
		window.open('', "top");
		setTimeout(window.open(_url, "top"), 100);
	});
}
