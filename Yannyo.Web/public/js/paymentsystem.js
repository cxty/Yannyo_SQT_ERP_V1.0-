/**
 * cxty@qq.com
 */
function TPaymentSystemManage()
{
	this.PageBox = null;
	this.PageForm = null;
	this.S_key = null;
	this.Act = null;
}
TPaymentSystemManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.S_key = document.getElementById('S_key');
	this.Act = document.getElementById('Act');
}
TPaymentSystemManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("添加结算系统",'iframe:paymentsystem_do-Add.aspx',"450px","400px","iframe"); 
}

TPaymentSystemManage.prototype.Search = function()
{
	this.Act.value="Search";
	this.PageForm.submit();
}
TPaymentSystemManage.prototype.HidUserBox = function()
{
	CloseBox();
}
TPaymentSystemManage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			var tValue = '';
		    for(var i=0 ;i<PaymentSystemManage.PageForm.elements.length;i++){ 
		        if(PaymentSystemManage.PageForm.elements[i].name=="cCheck"){ 
		            e=PaymentSystemManage.PageForm.elements[i];
		            if(e.checked == true)
		            {
		                tValue+=e.value+',';
		            }
		        }
		    }
		    if(Trim(tValue) != '')
		    {
				
			        	PaymentSystemManage.PageBox = dialog("删除结算系统",'iframe:paymentsystem_do_Del-'+tValue+'.aspx',"450px","400px","iframe");
					
		    }
		    tValue = null;
		}
	});
}
TPaymentSystemManage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			PaymentSystemManage.PageBox = dialog("删除结算系统",'iframe:paymentsystem_do_Del-'+idStr+'.aspx',"450px","400px","iframe");
		}
	});
}
TPaymentSystemManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改结算系统",'iframe:paymentsystem_do_Edit-'+idStr+'.aspx',"450px","400px","iframe");
}
