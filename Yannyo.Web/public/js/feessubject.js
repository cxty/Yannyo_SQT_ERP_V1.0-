/**
 * cxty@qq.com
 */
function TFeesSubjectManage()
{
	this.PageBox = null;
	this.PageForm = null;
}
TFeesSubjectManage.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
}
TFeesSubjectManage.prototype.ShowAddUserBox = function()
{
	this.PageBox = dialog("新建科目",'iframe:feessubject_do-Add.aspx',450,400,"iframe",'HidBox();'); //SysComm.ShowPageBox('feessubject_do-Add.aspx',450,200);
}
TFeesSubjectManage.prototype.HidUserBox = function()
{
	CloseBox();
	location=location;
}
TFeesSubjectManage.prototype.Delt = function()
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			var tValue = '';
		    for(var i=0 ;i<FeesSubjectManage.PageForm.elements.length;i++){ 
		        if(FeesSubjectManage.PageForm.elements[i].name=="cCheck"){ 
		            e=FeesSubjectManage.PageForm.elements[i];
		            if(e.checked == true)
		            {
		                tValue+=e.value+',';
		            }
		        }
		    }
		    if(Trim(tValue) != '')
		    {
				
						FeesSubjectManage.dialog("删除科目",'iframe:feessubject_do_Del-'+tValue+'.aspx',450,200,"iframe",'HidBox();');
			        	//this.ShowPageBox('feessubject_do_Del-'+tValue+'.aspx',450,200);
					
		    }
		    tValue = null;
		}
	});
}
TFeesSubjectManage.prototype.ShowDelUserBox = function(idStr)
{
	jConfirm('本操作不可逆,删除后将无法恢复,是否确认执行本操作?','提示',function(r){
		if(r)
		{
			FeesSubjectManage.PageBox = dialog("删除科目",'iframe:feessubject_do_Del-'+idStr+'.aspx',450,200,"iframe",'HidBox();');//SysComm.ShowPageBox('feessubject_do_Del-'+idStr+'.aspx',450,200);
		}
	});
}
TFeesSubjectManage.prototype.ShowEditUserBox = function(idStr)
{
	this.PageBox = dialog("修改科目",'iframe:feessubject_do_Edit-'+idStr+'.aspx',450,200,"iframe",'HidBox();');//SysComm.ShowPageBox('feessubject_do_Edit-'+idStr+'.aspx',450,200);
}
