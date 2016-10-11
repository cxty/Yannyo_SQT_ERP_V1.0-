/**
 * cxty@qq.com
 */
function TOrderList_Selecttype()
{
	this.OrdeType = 0;

}
TOrderList_Selecttype.prototype.ini = function(){
	
}
TOrderList_Selecttype.prototype.CheckF = function()
{
	parent.OrderList.ordertype = $('#Order_Type').children('option:selected').val();
	parent.OrderList.ShowAddUserBox();
}
