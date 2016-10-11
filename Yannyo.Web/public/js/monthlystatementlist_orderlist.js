/**
 * cxty@qq.com
 */
function TMonthlyStatementList_OrderList()
{
	this.OrderType = 0;
	this.StoresSupplierID = 0;
	this.P_OrderIDStr = '';
}
TMonthlyStatementList_OrderList.prototype.ini = function()
{
	this.P_OrderIDStr = parent.MonthlyStatementList_do.GetOrderIDStr();
	this.iniOrderList();
	$('#button_Search').click(function(){
		location='/monthlystatementlist_orderlist-'+MonthlyStatementList_OrderList.OrderType+'.aspx?oOrderNum='+$('#oOrderNum').val()+'&oCustomersOrderID='+$('#oCustomersOrderID').val()+'&oOrderDateTimeB='+$('#oOrderDateTimeB').val()+'&oOrderDateTimeE='+$('#oOrderDateTimeE').val()+'';
	});
	$('#subbutton_add').click(function(){
		MonthlyStatementList_OrderList.ToAdd();
	});
	$('#subbutton_close').click(function(){
		parent.HidBox();
	});
	//全选
	$('#checkbox_b').click(function(){
		if ($(this).attr("checked") == true) { // 全选
		   $('#dLoop tr').find(':checkbox').each(function() {
		   $(this).attr("checked", true);
		  });
		} else { // 取消全选
		   $('#dLoop tr').find(':checkbox').each(function() {
		   $(this).attr("checked", false);
		  });
		}
	});
}

//过滤单据列表中已存在的单据
TMonthlyStatementList_OrderList.prototype.iniOrderList = function()
{
	var tr = $('#dLoop input');
	if(tr)
	{
		for (var i = 0; i < tr.length; i++) {
			if (tr[i]) {
				if((','+this.P_OrderIDStr+',').indexOf($(tr[i]).val())>-1)
				{
					$(tr[i]).remove();
				}
			}
		}
	}
}

//添加回单据列表
TMonthlyStatementList_OrderList.prototype.ToAdd = function()
{
	var redata = null;
	var reloopdata = '';
	var tr = $('#dLoop input:checked');
	var oMoney = 0;
	//var tID = ',2,4,';
	if(tr)
	{
		for (var i = 0; i < tr.length; i++) 
		{
			if(tr[i])
			{
				oMoney = Number($(tr[i]).attr('SumMoney'));
				//if(tID.indexOf(','+$(tr[i]).attr('oType')+',')>-1)
				{
					//oMoney=oMoney*-1;
				}
				reloopdata+='{"MonthlyStatementDataID":0,"MonthlyStatementID":0,"OrderID":\"'+$(tr[i]).val()+'\","oMoney":\"'+oMoney+'\","sRemake":"","sAppendTime":"\/Date(1292828094096+0800)\/","oOrderNum":"'+$(tr[i]).attr('oOrderNum')+'","oOrderDateTime":"'+$(tr[i]).attr('oOrderDateTime')+'","StaffName":"'+$(tr[i]).attr('StaffName')+'","oTypeStr":"'+$(tr[i]).attr('oTypeStr')+'","oType":"'+$(tr[i]).attr('oType')+'","StoresSupplierName":"'+$(tr[i]).attr('StoresSupplierName')+'"},';
			}
		}
		if (reloopdata != '') {
			reloopdata = reloopdata.substring(0, reloopdata.length - 1);
		}
		
		redata = '{"MonthlyStatementData":['+reloopdata+']}';
		parent.MonthlyStatementList_do.AddOrderData(jQuery.parseJSON(redata),true);
		$(tr).remove();
	}
}
