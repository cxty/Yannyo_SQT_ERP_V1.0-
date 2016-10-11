/**
 * @author Cxty
 */
function TM_Members()
{
	this.MConfigID = 0;
}
TM_Members.prototype.ini = function()
{
	$('#bt_DownLoad').click(function(){
		M_Members.DownLoad();
	});
	$('#bt_Delt').click(function(){
		
	});
}
TM_Members.prototype.HidUserBox = function()
{
	CloseBox();
}
TM_Members.prototype.Edit = function(MemberInfoID)
{
	if(MemberInfoID)
	{
		
	}
}
TM_Members.prototype.DownLoad = function()
{
	this.PageBox = dialog("下载商城会员信息","iframe:mmembers_do-"+M_Members.MConfigID+"-DownLoad.aspx","550px","450px","iframe");
}
