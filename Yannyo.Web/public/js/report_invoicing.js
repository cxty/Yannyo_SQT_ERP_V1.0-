
function TReport_Invoicing()
{

}
TReport_Invoicing.prototype.ini = function()
{
	
	$('#ReType').change(function(){
		switch($(this).children('option:selected').val())
		{
			//日
			case 0:case '0':
				$('#day_sDate').show();
				$('#month_sDate').hide();
				$('#year_sDate').hide();
				$('#sDate_Box').hide();
			break;
			//月
			case 1:case '1':
				$('#day_sDate').hide();
				$('#month_sDate').show();
				$('#month_sDate').val('');
				$('#year_sDate').hide();
				$('#sDate_Box').hide();
			break;
			//年
			case 2:case '2':
				$('#day_sDate').hide();
				$('#month_sDate').hide();
				$('#year_sDate').show();
				$('#year_sDate').val('');
				$('#sDate_Box').hide();
			break;
			//区间
			case 3:case '3':
				$('#day_sDate').hide();
				$('#month_sDate').hide();
				$('#year_sDate').hide();
				$('#sDate_Box').show();
			break;
		}
	});
	$('#ReType').change();
	
	$('#bt_sub').click(function()
	{
		//if ($('#sDate').val() != '') {
			var IsOK = false;
			var d=new Date();
			
			var errMsg = '';
			switch($('#ReType').children('option:selected').val())
			{
				case 0:case '0'://日
					var sD = Date.parse($('#day_sDate').val().replace('-','/'));
					if(sD)
					{
						
					}else{
						sD = Date.parse($('#day_sDate').val());
					}
					$('#sDate').val($('#day_sDate').val());
					IsOK = (d-sD)/(24*60*60*1000)>1;
					errMsg = '请选择今天前的日期.';
				break;
				case 1:case '1'://月
					var sD = Date.parse($('#month_sDate').val($('#month_sDate').val()+'-01').val().replace('-','/'));
					if(sD)
					{
						
					}else{
						sD = Date.parse($('#month_sDate').val());
					}
					$('#sDate').val($('#month_sDate').val());
					IsOK = (d-sD)/(30*24*60*60*1000)>1;
					errMsg = '请选择当前月份前的日期.';
				break;
				case 2:case '2'://年
					$('#sDate').val($('#year_sDate').val($('#year_sDate').val()+'-01-01').val());
					IsOK = true;
				break;
				case 3:case '3'://区间
					var bD = Date.parse($('#b_sDate').val().replace('-','/'));
					if(bD)
					{
						
					}else{
						bD = Date.parse($('#b_sDate').val());
					}
					var eD = Date.parse($('#e_sDate').val().replace('-','/'));
					if(eD)
					{
						
					}else{
						eD = Date.parse($('#e_sDate').val());
					}
					if (bD <= eD) {
						$('#sDate').val($('#b_sDate').val());
						$('#eDate').val($('#e_sDate').val());
						IsOK = (d - eD) / (24 * 60 * 60 * 1000) > 1;
						errMsg = '请选择今天前的日期.';
					}else{
						IsOK = false;
						errMsg = '其实日期必须小等于截止日期';
					}
				break;
				default:
					IsOK = true;
				break;
			}
			if (IsOK) {
				jConfirm('分析数据较大,该过程大约需(1-2)分钟,分析结果将自动缓存2个小时!', '提示', function(r){
					if (r) {
						$("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
						
						$("#floatBoxBg").animate({
							opacity: "0.5"
						}, "normal", function(){
							$(this).show();
							$('#form1').submit();
						});
					}
				});
			}else{
				jAlert(errMsg,'提示');
			}
		//}else{
		//	jAlert('请选择一个时间点!','提示');
		//}
	});
}