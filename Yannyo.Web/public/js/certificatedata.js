/**
 * @author Cxty
 */
function TCertificateData()
{
	this.PageBox = null;
	if(document.all)
	{
		this.dw = $(document).width()-20;
		this.dh = $(window).height()-80;
	}
	else
	{
		this.dw = document.body.clientWidth-20+'px';
		this.dh = $(window).height()-80+'px';
	}
}
TCertificateData.prototype.ini = function()
{
	$('#cObjectName').click(function()
	{
		CertificateData.PageBox = dialog("选择单位","iframe:dataclass_box.aspx?Act=cObj&ShowType=All","450px","350px","iframe");
	});
	$('#FeesSubject').click(function()
	{
		CertificateData.PageBox = dialog("选择科目","iframe:dataclass_box.aspx?Act=sObj&ShowType=All","450px","350px","iframe");
	});
	$('#bt_sub').click(function()
	{
		location='/certificatedata.aspx?ShowType=' + $('#ShowType').children('option:selected').val() + 
		'&cObjectName=' + $('#cObjectName').val() + 
		'&cObjectType=' + $('#cObjectType').val() + 
		'&cObjectID=' + $('#cObjectID').val() + 
		'&cObjectIsRoot=' + $('#cObjectIsRoot').val() + 
		'&FeesSubject=' + $('#FeesSubject').val() + 
		'&FeesSubjectID=' + $('#FeesSubjectID').val() + 
		'&StaffName=' + $('#StaffName').val() + 
		'&StaffID=' + $('#StaffID').val() + 
		'&TimeB=' + $('#TimeB').val() + '&TimeE=' + $('#TimeE').val()+'&cSteps='+$('#cSteps').children('option:selected').val();
	});
	$('#bt_exp').click(function()
	{
		var _url='/certificatedata.aspx?Act=Export&ShowType=' + $('#ShowType').children('option:selected').val() + 
		'&cObjectName=' + $('#cObjectName').val() + 
		'&cObjectType=' + $('#cObjectType').val() + 
		'&cObjectID=' + $('#cObjectID').val() + 
		'&cObjectIsRoot=' + $('#cObjectIsRoot').val() + 
		'&FeesSubject=' + $('#FeesSubject').val() + 
		'&FeesSubjectID=' + $('#FeesSubjectID').val() + 
		'&StaffName=' + $('#StaffName').val() + 
		'&StaffID=' + $('#StaffID').val() + 
		'&TimeB=' + $('#TimeB').val() + '&TimeE=' + $('#TimeE').val()+'&cSteps='+$('#cSteps').children('option:selected').val();
		window.open('', "top"); 
		setTimeout(window.open(_url, "top"), 100); 
		return false;
	});
}
TCertificateData.prototype.HidUserBox = function()
{
	CloseBox();
}
TCertificateData.prototype.ShowcObjectBox_ReCall = function(sID,sType,sName,isRoot)
{
	$('#cObjectName').val(sName);
	$('#cObjectID').val(sID);
	$('#cObjectType').val(sType);
	$('#cObjectIsRoot').val(isRoot);
}
TCertificateData.prototype.ShowFeesSubjectBox_ReCall = function(sID,sName)
{
	$('#FeesSubject').val(sName);
	$('#FeesSubjectID').val(sID);
}
TCertificateData.prototype.ShowBox = function(cId,cCode)
{
	if(cId)
	{
		dialog("凭证:"+cCode,'iframe:/certificate_do-Edit-'+cId+'.aspx',this.dw,this.dh,"iframe",'HidBox();');
	}
}

$().ready(function(){
	$('#StaffName').autocomplete('Services/CAjax.aspx',{ 
		
		width: 200,
		scroll: true,
		autoFill: true,
		scrollHeight: 200,
		matchContains: true,
		dataType: 'json',
		extraParams:{
			'do':'GetStaffList',
			'sType':'1',
			'RCode':Math.random(),
			'StaffName':function(){return $('#StaffName').val();}
		},
		parse: function(data) {
				var rows = [];  
				var tArray = data.results;
				 for(var i=0; i<tArray.length; i++){  
				  rows[rows.length] = {    
					data:tArray[i].value +"("+ tArray[i].info+")",    
					value:tArray[i].id,    
					result:tArray[i].value    
					};    
				  }
			   return rows; 
			 },
		formatItem: function(row, i, max) {  
			   return row;
		},
		formatMatch: function(row, i, max) {
					return row.value; 
		},
		formatResult: function(row) { 
					return row.value;
		}
	  }).result(function(event, data, formatted) {
			$("#StaffID").val((formatted!=null)?formatted:"0");
		}
	  );
});