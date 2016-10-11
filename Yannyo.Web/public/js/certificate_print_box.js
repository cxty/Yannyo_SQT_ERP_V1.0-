function TCertificate_print_box()
{
	this.select_count = 0;
	this.UserCode = '';
	this.LODOP = null;
	if(document.all)
	{
		this.dw = $(document).width()-20;
		this.dh = $(window).height()-80;
	}
	else
	{
		this.dw = ($(document).width()-20)+'px';
		this.dh = ($(window).height()-80)+'px';
	}
}
TCertificate_print_box.prototype.ini = function()
{
	this.LODOP = getLodop(document.getElementById('LODOP'), document.getElementById('LODOP_EM'));
	//查找
	$('#button_Search').click(function(){
		location='/certificate_print_box.aspx?Act=do&cDateTimeB='+$('#cDateTimeB').val()+'&cDateTimeE='+$('#cDateTimeE').val()+'&cSteps='+$('#cSteps').children('option:selected').val()+'&cState='+$('#cState').children('option:selected').val()+'&cNumber='+$('#cNumber').val();
	});
	//全选
	$('#checkbox_b').click(function(){
		if ($(this).attr("checked") == true) { // 全选
		   $('#dloop tr').find(':checkbox').each(function() {
		   	$(this).attr("checked", true);
		   	Certificate_print_box.select_count++;
		  });
		} else { // 取消全选
		   $('#dloop tr').find(':checkbox').each(function() {
		   	$(this).attr("checked", false);
		  });
		  Certificate_print_box.select_count = 0;
		}
	});
	//取消
	$('#button_cl').click(function(){
		parent.HidBox();
	});
	//打印选中
	$('#button_Print').click(function(){
		jConfirm('是否确认 <b>打印选中凭证</b> ?<br>提示:每次打印系统都将留下打印记录,且批量打印较为耗时!','提示',function(r){
			if (r) {
				Certificate_print_box.print();
			}
		});
	});
}
TCertificate_print_box.prototype.print = function()
{
	try {
		this.LODOP.PRINT_INIT("凭证打印");
		this.LODOP.SET_PRINT_STYLE("FontSize", 12);
		$('#dloop tr').find(':checkbox').each(function(){
			if ($(this).attr("checked")) {
				Certificate_print_box.LODOP.ADD_PRINT_URL(0, 0, "100%", "100%", '/certificate_print-' + $(this).val() + '.aspx?UserCode=' + Certificate_print_box.UserCode);
				if(Certificate_print_box.LODOP.PREVIEW())
				{
					$(this).attr("checked", false);
					jConfirm('是否继续认 <b>打印选中凭证</b> ?<br>提示:每次打印系统都将留下打印记录,且批量打印较为耗时!','提示',function(r){
						if(r){
							Certificate_print_box.print();
						}
					});
				}
				return false;
			}
		});
	}catch (e) {
		jAlert('请安装打印控件![' + e + ']');
	}
}

