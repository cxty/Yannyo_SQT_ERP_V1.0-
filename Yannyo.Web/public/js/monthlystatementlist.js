/**
 * cxty@qq.com
 */
function TMonthlyStatementList()
{
	this.sType = 0;
	
	if(document.all)
	{
		this.dw = $(document).width()-20;
		this.dh = $(window).height()-80;
	}
	else
	{
		this.dw = document.body.clientWidth-20+'px';
		this.dh = $(window).height()-80+'px';
	}
}
TMonthlyStatementList.prototype.ini = function()
{
	
	//查询
	$('#button_Search').click(function(){
		location='/monthlystatementlist.aspx?sCode='+$('#sCode').val()+
		'&sDateTimeB='+$('#sDateTimeB').val()+
		'&sDateTimeE='+$('#sDateTimeE').val()+
		'&sObjectName='+$('#sObjectName').val()+
		'&sObjectID='+$('#sObjectID').val()+
		'&cCode='+$('#cCode').val()+
		'&sType='+$('#sType').children('option:selected').val()+
		'&sObjectType='+$('#sObjectType').children('option:selected').val()+
		'&sSteps='+$('#sSteps').children('option:selected').val()+
		'&sReceiptState='+$('#sReceiptState').children('option:selected').val()+
		'&sState='+$('#sState').children('option:selected').val()+'';
	});
	//新建对账单
	$('#button_add').click(function(){
		if ((navigator.userAgent.match(/iPhone/i)) || (navigator.userAgent.match(/iPad/i)) || (navigator.userAgent.match(/Android/i))) {
			window.open('', "top"); 
			setTimeout(window.open('/monthlystatementlist_do-Add-'+MonthlyStatementList.sType+'.aspx', "top"), 100); 
			return false;
		}else{
			dialog("新建对账单",'iframe:/monthlystatementlist_do-Add-'+MonthlyStatementList.sType+'.aspx',MonthlyStatementList.dw,MonthlyStatementList.dh,"iframe",'HidBox();');
		}
	});
}
TMonthlyStatementList.prototype.HidUserBox = function()
{
	CloseBox();
	location=location;
}
TMonthlyStatementList.prototype.ShowData = function(mid,ccode,sType)
{
	dialog("对账单",'iframe:/monthlystatementlist_do-Edit-'+mid+'-'+sType+'.aspx',MonthlyStatementList.dw,MonthlyStatementList.dh,"iframe",'HidBox();');
}
