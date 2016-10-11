

function TReport_Sales()
{
	this.dType = 0;
}
TReport_Sales.prototype.ini = function()
{
	
	
	$('#bt_sub').click(function()
	{
		Report_Sales.ShowMB();
	});
	$("#export_data").click(function () {
		var _url = '';
		
		if (Report_Sales.dType == 0 || Report_Sales.dType == 3 || Report_Sales.dType == 6) {
			Report_Sales.dType = (Report_Sales.dType==6)?($('#_dtype_a').attr('checked')?6:7):($('#_dtype_b').attr('checked')?3:0);
			_url = '/report_sales.aspx?Act=Export&bDate=' + $("#bDate").val()+'&eDate='+$("#eDate").val()+'&ReType='+$("#ReType").children('option:selected').val()+'&dType='+Report_Sales.dType+'&NOJoinSales='+$("#NOJoinSales").children('option:selected').val()+'&PaymentSystemID='+$("#PaymentSystemID").children('option:selected').val()+'&CostPrice='+$("#CostPrice").children('option:selected').val()+'&SingleMemberID='+$('#SingleMemberID').val()+'&OrderNumber='+$('#OrderNumber').val();
		}
		else if (Report_Sales.dType == 1 || Report_Sales.dType == 4 || Report_Sales.dType == 7) {
			Report_Sales.dType = (Report_Sales.dType == 7)?($('#_dtype_b').attr('checked')?7:6): $('#_dtype_b').attr('checked')?4:1;
			_url = '/report_sales.aspx?Act=Export&bDate=' + $("#bDate").val()+'&eDate='+$("#eDate").val()+'&ReType='+$("#ReType").children('option:selected').val()+'&dType='+Report_Sales.dType+'&NOJoinSales='+$("#NOJoinSales").children('option:selected').val()+'&PaymentSystemID='+$("#PaymentSystemID").children('option:selected').val()+'&CostPrice='+$("#CostPrice").children('option:selected').val()+'&SingleMemberID='+$('#SingleMemberID').val()+'&OrderNumber='+$('#OrderNumber').val();
		}

		window.open('', "top");
		setTimeout(window.open(_url, "top"), 100);
		return false;
	});
	$('#_dtype_a').click(function(){
		$('#_dtype_box').show();
	});
	$('#_dtype_b').click(function(){
		$('#_dtype_box').hide();
	});
	if(this.dType==3 || this.dType==4)
	{
		$('#_dtype_box').hide();
	}
	
}
TReport_Sales.prototype.ShowMB = function()
{
	jConfirm('分析数据较大,该过程大约需(1-2)分钟,分析结果将自动缓存2个小时!','提示',function(r){
		if(r)
		{
			$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
			
			$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
				$(this).show();
				if (Report_Sales.dType == 0 || Report_Sales.dType == 3 || Report_Sales.dType == 6) {
					Report_Sales.dType = (Report_Sales.dType==6)?($('#_dtype_a').attr('checked')?6:7):($('#_dtype_b').attr('checked')?3:0);
					//Report_Sales.dType = $('#_dtype_b').attr('checked')?3:0;
					$('#form1').attr('action', 'report_sales-' + $('#ReType').children('option:selected').val() + '.aspx?dType='+Report_Sales.dType).submit();
				}
				else if (Report_Sales.dType == 1 || Report_Sales.dType == 4 || Report_Sales.dType == 7) {
					Report_Sales.dType = (Report_Sales.dType == 7)?($('#_dtype_b').attr('checked')?7:6): $('#_dtype_b').attr('checked')?4:1;
					$('#form1').attr('action', 'report_sales-' + $('#ReType').children('option:selected').val() + '.aspx?dType='+Report_Sales.dType).submit();
				}else {
					$('#form1').submit();
				}
								
			});
			
		}
	});
}
