/**
 * cxty@qq.com
 */
function TPriceClassDefaultPrice()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TPriceClassDefaultPrice.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}

TPriceClassDefaultPrice.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TPriceClassDefaultPrice.prototype.HidUserBox = function()
{
	CloseBox();
}

TPriceClassDefaultPrice.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("价格类型默认价格信息",'iframe:PriceClassDefaultPrice_do_List-'+idStr+'.aspx',"500px","400px","iframe");
}
