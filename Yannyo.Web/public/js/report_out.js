
function TReport_Out()
{

}
TReport_Out.prototype.ini = function()
{

	$('#bt_sub').click(function()
	{
		jConfirm('分析数据较大,该过程大约需(1-2)分钟,分析结果将自动缓存2个小时!','提示',function(r){
			if(r)
			{
				$("body").append("<div id=\"floatBoxBg\" style=\"height:"+$(document).height()+"px;filter:alpha(opacity=0);opacity:0;\"></div>");
				
				$("#floatBoxBg").animate({opacity:"0.5"},"normal",function(){
					$(this).show();
					$('#form1').attr('action','report_out-'+$('#ReType').children('option:selected').val()+'.aspx');
					$('#form1').submit();
				});
				
			}
		});
	});
}