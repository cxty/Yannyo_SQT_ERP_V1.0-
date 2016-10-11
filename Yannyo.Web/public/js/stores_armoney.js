/**
 * cxty@qq.com
 */
function TStoresARMoney()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TStoresARMoney.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TStoresARMoney.prototype.HidUserBox = function()
{
	CloseBox();
}
TStoresARMoney.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TStoresARMoney.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("设置客户期初应收",'iframe:stores_armoney_do_Edit-'+idStr+'.aspx',"450px","400px","iframe");
}