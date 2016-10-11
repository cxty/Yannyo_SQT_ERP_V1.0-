/**
 * @author Cxty
 */
function TReport_Certificate_Summary()
{
	this.PrintPageWidth = '';
	this.UserCode = '';
}
TReport_Certificate_Summary.prototype.ini = function()
{
	$('#button_Summary').click(function(){
		if($('#bDate').val()!='')
		{
			if($('#eDate').val()!='')
			{
				$('#form1').submit();
			}else{
				
				jAlert('截止时间不能为空!','提示',function(){
					$('#bDate').focus();
				});
			}
		}else{
			
			jAlert('开始时间不能为空!','提示',function(){
				$('#bDate').focus();
			});
		}		
	});
	$('#button_print').click(function(){
		if($('#bDate').val()!='')
		{
			if($('#eDate').val()!='')
			{
				
				var LODOP;
				try{
					LODOP=getLodop(document.getElementById('LODOP'),document.getElementById('LODOP_EM'));
					try {
						LODOP.PRINT_INIT("凭证汇总打印");
						LODOP.SET_PRINT_PAGESIZE(3, Report_Certificate_Summary.PrintPageWidth, "0", "");
						LODOP.SET_PRINT_STYLE("FontSize",12);
	
						LODOP.ADD_PRINT_URL(0, 0, "100%", "100%",'/report_certificate_summary_print.aspx?bDate='+$('#bDate').val()+'&eDate='+$('#eDate').val()+'&UserCode='+Report_Certificate_Summary.UserCode);
						LODOP.PREVIEW();
	
					}catch(e){
						jAlert('请安装打印控件![' + e + ']');		
					}
					
					return false;
				 }catch(e){
						window.open('', "top"); 
						setTimeout(window.open('/report_certificate_summary_print.aspx?bDate='+$('#bDate').val()+'&eDate='+$('#eDate').val()+'&UserCode='+Report_Certificate_Summary.UserCode, "top"), 100); 
						return false;
				 }


			}else{
				
				jAlert('截止时间不能为空!','提示',function(){
					$('#bDate').focus();
				});
			}
		}else{
			
			jAlert('开始时间不能为空!','提示',function(){
				$('#bDate').focus();
			});
		}
	});
}
TReport_Certificate_Summary.prototype.HidUserBox = function()
{
	CloseBox();
}
