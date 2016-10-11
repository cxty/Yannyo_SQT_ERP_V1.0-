/**
 * cxty@qq.com
 */
function TCertificateList()
{
	this.OrderType = 0;
	this.OrderID = 0;
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
TCertificateList.prototype.ini = function()
{
	//添加随附,凭证
	$('#subbutton_add').click(function(){
		if ((navigator.userAgent.match(/iPhone/i)) || (navigator.userAgent.match(/iPad/i)) || (navigator.userAgent.match(/Android/i))) {
			window.open('', "top"); 
			setTimeout(window.open('/certificate_do-Add-'+CertificateList.OrderType+'-'+CertificateList.OrderID+'.aspx', "top"), 100); 
			return false;
		}else{
			dialog("凭证录入",'iframe:/certificate_do-Add-'+CertificateList.OrderType+'-'+CertificateList.OrderID+'.aspx',CertificateList.dw,CertificateList.dh,"iframe",'HidBox();');
		}
	});
	//查找
	$('#button_Search').click(function(){
		location='/certificatelist.aspx?cDateTimeB='+$('#cDateTimeB').val()+'&cDateTimeE='+$('#cDateTimeE').val()+'&cSteps='+$('#cSteps').children('option:selected').val()+'&cState='+$('#cState').children('option:selected').val()+'&cNumber='+$('#cNumber').val();
	});
	//批量打印
	$('#button_print').click(function(){
		dialog("批量打印凭证",'iframe:/certificate_print_box.aspx',CertificateList.dw,CertificateList.dh,"iframe",'HidBox();');
	});
}
TCertificateList.prototype.HidUserBox = function()
{
	CloseBox();
	location=location;
}
//指定凭证的下一条凭证
TCertificateList.prototype.next =function(CertificateID)
{
	var tr = $('#dloop').children('tr[certificateid='+CertificateID+']');
	if(tr)
	{
		var ntr = $(tr).next();
		if(ntr)
		{
			return $(ntr).attr('certificateid')?$(ntr).attr('certificateid'):false;
		}else{
			return false;
		}
	}else{
			return false;
	}
}
//查看凭证
TCertificateList.prototype.ShowData = function(CertificateID,cCode)
{
	if ((navigator.userAgent.match(/iPhone/i)) || (navigator.userAgent.match(/iPad/i)) || (navigator.userAgent.match(/Android/i))) {
		window.open('', "top"); 
		setTimeout(window.open('/certificate_do-Edit-'+this.OrderType+'-'+this.OrderID+'-'+CertificateID+'.aspx', "top"), 100); 
		return false;
	}else{
		dialog("查看凭证",'iframe:/certificate_do-Edit-'+this.OrderType+'-'+this.OrderID+'-'+CertificateID+'.aspx',this.dw,this.dh,"iframe",'HidBox();');
	}
}