/**
 * cxty@qq.com
 */
function TProductsBeginning()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TProductsBeginning.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TProductsBeginning.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TProductsBeginning.prototype.HidUserBox = function()
{
	CloseBox();
}
TProductsBeginning.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("设置商品期初库存",'iframe:products_beginning_do_Edit-'+idStr+'.aspx',"450px","400px","iframe");
}
