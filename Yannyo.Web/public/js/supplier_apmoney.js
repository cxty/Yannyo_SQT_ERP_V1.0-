/**
 * cxty@qq.com
 */
function TSupplierAPmoney()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TSupplierAPmoney.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TSupplierAPmoney.prototype.HidUserBox = function()
{
	CloseBox();
}
TSupplierAPmoney.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TSupplierAPmoney.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("设置供货商期初应付",'iframe:supplier_apmoney_do_Edit-'+idStr+'.aspx',"450px","400px","iframe");
}
