/**
 * cxty@qq.com
 */
function TSalesManage()
{
	this.PageBox = null;
	this.PageForm = null;
}
TSalesManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	$('#bt_s').click(function(){
		location='sales.aspx?sDate='+$('#sDate').val();	
	});
}
TSalesManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("新建永辉销售数据",'iframe:sales_do-Add.aspx',450,400,"iframe",'HidBox();'); // SysComm.ShowPageBox('sales_do-Add.aspx',450,400);
}
TSalesManage.prototype.ShowimportdataBox = function()
{
	this.PageBox = dialog("导入永辉销售数据",'iframe:importdata.aspx',700,550,"iframe",'HidBox();');//SysComm.ShowPageBox('importdata.aspx',450,430);
}
TSalesManage.prototype.ShowSyndataBox = function()
{
	this.PageBox = dialog("匹配永辉销售数据",'iframe:sales_syndata.aspx',500,200,"iframe",'HidBox();');//SysComm.ShowPageBox('sales_syndata.aspx',450,400);
}
TSalesManage.prototype.HidUserBox = function()
{
	CloseBox();
	//SysComm.HiddenPageBox(this.PageBox);
}
TSalesManage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			var tValue = '';
		    for(var i=0 ;i<SalesManage.PageForm.elements.length;i++){ 
		        if(SalesManage.PageForm.elements[i].name=="cCheck"){ 
		            e=SalesManage.PageForm.elements[i];
		            if(e.checked == true)
		            {
		                tValue+=e.value+',';
		            }
		        }
		    }
		    if(Trim(tValue) != '')
		    {
				
			        	SalesManage.PageBox = dialog("删除永辉销售数据",'iframe:sales_do_Del-'+tValue+'.aspx',500,200,"iframe",'HidBox();');//SysComm.ShowPageBox('sales_do_Del-'+tValue+'.aspx',450,200);
			        
		    }
		    tValue = null;
		}
	});
}
TSalesManage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			SalesManage.PageBox = dialog("删除永辉销售数据",'iframe:sales_do_Del-'+idStr+'.aspx',500,200,"iframe",'HidBox();');//SysComm.ShowPageBox('sales_do_Del-'+idStr+'.aspx',450,200);
		}
	});
}
TSalesManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改永辉销售数据",'iframe:sales_do_Edit-'+idStr+'.aspx',500,450,"iframe",'HidBox();');//SysComm.ShowPageBox('sales_do_Edit-'+idStr+'.aspx',450,400);
}
