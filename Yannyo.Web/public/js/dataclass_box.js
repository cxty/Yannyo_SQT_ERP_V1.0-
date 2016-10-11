/**
 * @author Cxty
 */
function TDataClass_box()
{
	this.DepartmentsJsonStr = '';
	this.DepartmentsJson = null;//部门人员
	this.SupplierJsonStr = '';
	this.SupplierJson = null;//供应商
	this.CustomersJsonStr = '';
	this.CustomersJson = null;//客户
}
TDataClass_box.prototype.ini = function()
{
	if(this.DepartmentsJsonStr)
	{
		this.DepartmentsJson = jQuery.parseJSON(this.DepartmentsJsonStr);
	}
	if(this.SupplierJsonStr)
	{
		this.SupplierJson = jQuery.parseJSON(this.SupplierJsonStr);
	}
	if(this.CustomersJsonStr)
	{
		this.CustomersJson = jQuery.parseJSON(this.CustomersJsonStr);
	}

}
TDataClass_box.prototype.cObjReCall = function(sID,sType,sName)
{
	window.parent.cObjReCall(sID,sType,sName);
}
TDataClass_box.prototype.cObjReCallb = function(sID,sType,sName,isRoot)
{
	window.parent.cObjReCall(sID,sType,sName,isRoot);
}
TDataClass_box.prototype.sObjReCall = function(sID,sName)
{
	window.parent.sObjReCall(sID,sName);
}