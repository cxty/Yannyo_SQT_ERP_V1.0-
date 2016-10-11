/**
 * cxty@qq.com
 */
function TStaff_do_updown()
{
	this.PageBox = null;
	this.PageForm = null;
	this.Act = null;
	this.tSidStr = null;
	this.IsNoList = false;
}
TStaff_do_updown.prototype.ini = function()
{
	this.PageForm = document.getElementById('form1');
	this.tSidStr = document.getElementById('tSidStr');
}
TStaff_do_updown.prototype.HidUserBox = function()
{
	SysComm.HiddenPageBox(this.PageBox);
}

TStaff_do_updown.prototype.OKGo = function()
{
	if(this.IsNoList){
		var tValue = '';
		for(var i=0 ;i<this.PageForm.elements.length;i++){ 
			if(this.PageForm.elements[i].name=="cCheck"){ 
				e=this.PageForm.elements[i];
				if(e.checked == true)
				{
					tValue+=e.value+',';
				}
			}
		}
		if(Trim(tValue) != '')
		{
			this.tSidStr.value=tValue;
			this.PageForm.submit();
			//this.PageBox = SysComm.ShowPageBox('staff_do_'+this.Act+'-'+tValue+'.aspx',450,200);
		}
		tValue = null;
	}else{
		this.PageForm.submit();
	}
}
