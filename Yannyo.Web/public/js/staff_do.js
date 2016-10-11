/**
 * @author Cxty
 */

 function TStaff_do()
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
	this.EduLoop = 0;
	this.WorkLoop = 0;
	this.FamilyLoop = 0;
	
	this.SelectEduData = null;
	this.SelectWorkData = null;
	this.SelectFamilyData = null;
	
	this.EduDataListJson = '';
	this.WorkDataListJson = '';
	this.FamilyDataListJson = '';
	
	this.EduDataListJsonStr = '';
	this.WorkDataListJsonStr = '';
	this.FamilyDataListJsonStr = '';
	this.StaffID = 0;
	this.ReCode = '';
 }
 TStaff_do.prototype.ini = function()
 {
 	if(this.EduDataListJsonStr)
	{
		this.EduDataListJson = jQuery.parseJSON(this.EduDataListJsonStr);
		if(this.EduDataListJson)
		{
			for(var i=0;i<this.EduDataListJson.EduDataList.length;i++)
			{
				this.SetEduData(this.EduDataListJson.EduDataList[i]);
			}
		}
	}
	if(this.WorkDataListJsonStr)
	{
		this.WorkDataListJson = jQuery.parseJSON(this.WorkDataListJsonStr);
		if(this.WorkDataListJson)
		{
			for(var i=0;i<this.WorkDataListJson.WorkDataList.length;i++)
			{
				this.SetWorkData(this.WorkDataListJson.WorkDataList[i]);
			}
		}
	}
	if(this.FamilyDataListJsonStr)
	{
		this.FamilyDataListJson = jQuery.parseJSON(this.FamilyDataListJsonStr);
		if(this.FamilyDataListJson)
		{
			for(var i=0;i<this.FamilyDataListJson.FamilyDataList.length;i++)
			{
				this.SetFamilyData(this.FamilyDataListJson.FamilyDataList[i]);
			}
		}
	}
	
 	//保存
 	$('#bt_s').click(function(){
		if(Staff_do.CheckF())
		{
			Staff_do.GetData();
			$('#bForm').submit();
		}
	});
	//取消
	$('#bt_c').click(function(){
		window.parent.HidBox();
	});
	//教育
	$('#EduData_bt').click(function(){
		Staff_do.SelectEduData = null;
		Staff_do.PageBox=dialog("教育信息","iframe:edudata_do.aspx",Staff_do.dw,Staff_do.dh,"iframe");
	});
	//工作
	$('#WorkData_bt').click(function(){
		Staff_do.SelectWorkData = null;
		Staff_do.PageBox=dialog("教育信息","iframe:workdata_do.aspx",Staff_do.dw,Staff_do.dh,"iframe");
	});
	//家庭
	$('#FamilyData_bt').click(function(){
		Staff_do.SelectFamilyData = null;
		Staff_do.PageBox=dialog("教育信息","iframe:familydata_do.aspx",Staff_do.dw,Staff_do.dh,"iframe");
	});
	//摄像头拍照
	$('#bt_pic_camera').click(function(){
		var RePid = window.showModalDialog('/camera-0.aspx?w=540&h=650',null,'dialogWidth=600px;dialogHeight=680px');
		Staff_do.AddPic(RePid);
	});
	$('#file_upload').uploadify({
	  'uploader'  : '/public/js/jquery.uploadify/uploadify.swf',
	  'script'    : '/Services/uppic.aspx?c='+Staff_do.ReCode,
	  'cancelImg' : '/public/js/jquery.uploadify/cancel.png',
	  'checkExisting':false,
	  'auto' : true,
	  'fileDesc' : 'jpg,gif,png',
	  'fileExt' : '*.jpg;*.gif;*.png',
	  'fileDataName':'PicData',
	  'removeCompleted' : true,
	  'height':25,
	  'width':80,
	  'buttonImg':'/public/js/jquery.uploadify/bt.png',
	  'uploaderType':'flash',
	  'onComplete':function(event,queueId,fileObj,response,data){
	  	var xml = null;
		if(document.all){ 
			var xmlDom=new ActiveXObject("Microsoft.XMLDOM") 
			xmlDom.loadXML(response) 
			xml = xmlDom ;
			} 
			else{
			xml = new DOMParser().parseFromString(response, "text/xml");
		}
			$(xml).find('root>re').each(function(){
				Staff_do.AddPic($(this).attr('picid'));
			});
		
	  }
	});
}
 //添加照片
 TStaff_do.prototype.AddPic = function(pid)
 {
 	if (pid) {
		$('#sPhotos').val('/cimg-' + pid + '.aspx');
		$('#sPic').html('<img pid="' + pid + '" src="/cimg-' + pid + '.aspx" style="width:98%" onClick="javascript:window.open(\'/cimg-' + pid + '.aspx\');"/>');
	}
 }
 TStaff_do.prototype.CheckF = function()
 {
 	if($('#sName').val()!="")
	{
		var dd = $("#category").mcDropdown();
		if(dd!='')
		{
			var ddarray = dd.getValue();
			if(ddarray.length>0)
			{
				if(Number(ddarray[0])>0){
					Sys.getObj('DepartmentsClassID').value = Number(ddarray[0]);
					return true;
				}
				else
				{
					jAlert('请选择部门!','提示');
				}
			}
			else
			{
				jAlert('请选择部门!','提示');	
			}
		}
		else
		{
			jAlert('请选择部门!','提示');	
		}
	}else{
		jAlert('名字不能为空!','提示');
	}
}
//添加教育
TStaff_do.prototype.SetEduData = function(sData)
{
	if(sData)
	{
		if (this.SelectEduData) {
			$('<li id="' + this.SelectEduData.attr('id') + '" StaffEduDataID="' + this.SelectEduData.attr('StaffEduDataID') + '" eDate="' + sData.eDate + '" eSchools="' + sData.eSchools + '" eContent="' + sData.eContent + '"><a href="javascript:void(0);" onclick="javascript:ShowEduData(' + this.SelectEduData.attr('id').replace('edu_','') + ');">' + sData.eDate + '-' + sData.eSchools + '-' + sData.eContent + '</a><a href="javascript:void(0);" onclick="javascript:DelEduData(' + this.SelectEduData.attr('id').replace('edu_','') + ');">[删]</a></li>').replaceAll(this.SelectEduData);
			//$('#EduDataList').append();
		}
		else {
			$('#EduDataList').append('<li id="edu_' + this.EduLoop + '" StaffEduDataID="'+(sData.StaffEduDataID?sData.StaffEduDataID:0)+'" eDate="' + sData.eDate + '" eSchools="' + sData.eSchools + '" eContent="' + sData.eContent + '"><a href="javascript:void(0);" onclick="javascript:ShowEduData(' + this.EduLoop + ');">' + sData.eDate + '-' + sData.eSchools + '-' + sData.eContent + '</a><a href="javascript:void(0);" onclick="javascript:DelEduData(' + this.EduLoop + ');">[删]</a></li>');
		}
	}
	this.EduLoop++;
}
function SetEduData(sData)
{
	Staff_do.SetEduData(sData);
}
//获取教育
TStaff_do.prototype.GetEduData = function(eId)
{
	if (eId) {
		this.SelectEduData = $('#edu_' + eId);
	}
	if (this.SelectEduData) {
		return {"StaffEduDataID":this.SelectEduData.attr('StaffEduDataID'),
				"eDate":this.SelectEduData.attr('eDate'),
				"eSchools":this.SelectEduData.attr('eSchools'),
				"eContent":this.SelectEduData.attr('eContent')};
	}
}
function GetEduData(eId)
{
	return Staff_do.GetEduData(eId);
}
function ShowEduData(eId)
{
	Staff_do.SelectEduData = $('#edu_' + eId);
	Staff_do.PageBox=dialog("教育信息","iframe:edudata_do.aspx",Staff_do.dw,Staff_do.dh,"iframe");
}
//删除教育
TStaff_do.prototype.DelEduData = function(eId)
{
	$('#edu_'+eId).remove();
}
function DelEduData(eId)
{
	jConfirm('是否确认删除?删除后无法恢复!','提示',function(r){
		if(r)
		{
			Staff_do.DelEduData(eId);
		}
	});
	
}

//添加工作
TStaff_do.prototype.SetWorkData = function(sData)
{
	if(sData)
	{
		if (this.SelectWorkData) {
			$('#WorkDataList').append('<li id="' + this.SelectWorkData.attr('id') + '" StaffWorkDataID="' + this.SelectWorkData.attr('StaffWorkDataID') + '" wDate="' + sData.wDate + '" wEnterprise="' + sData.wEnterprise + '" wTel="' + sData.wTel + '" wJobs="'+sData.wJobs+'" wIncome="'+sData.wIncome+'"><a href="javascript:void(0);" onclick="javascript:ShowWorkData(' + this.SelectWorkData.attr('id').replace('work_','') + ');">' + sData.wDate + '-' + sData.wEnterprise + '-' + sData.wJobs + '</a> <a href="javascript:void(0);" onclick="javascript:DelWorkData(' + this.SelectWorkData.attr('id').replace('work_','') + ');">[删]</a></li>');
		}
		else {
			$('#WorkDataList').append('<li id="work_' + this.WorkLoop + '" StaffWorkDataID="'+(sData.StaffWorkDataID?sData.StaffWorkDataID:0)+'" wDate="' + sData.wDate + '" wEnterprise="' + sData.wEnterprise + '" wTel="' + sData.wTel + '" wJobs="'+sData.wJobs+'" wIncome="'+sData.wIncome+'"><a href="javascript:void(0);" onclick="javascript:ShowWorkData(' + this.WorkLoop + ');">' + sData.wDate + '-' + sData.wEnterprise + '-' + sData.wJobs + '</a> <a href="javascript:void(0);" onclick="javascript:DelWorkData(' + this.WorkLoop + ');">[删]</a></li>');
		}
	}
	this.WorkLoop++;
}
function SetWorkData(sData)
{
	Staff_do.SetWorkData(sData);
}
//获取教育
TStaff_do.prototype.GetWorkData = function(eId)
{
	if (eId) {
		this.SelectWorkData = $('#work_' + eId);
	}
	if (this.SelectWorkData) {
		return {"StaffWorkDataID":this.SelectWorkData.attr('StaffWorkDataID'),
				"wDate":this.SelectWorkData.attr('wDate'),
				"wEnterprise":this.SelectWorkData.attr('wEnterprise'),
				"wTel":this.SelectWorkData.attr('wTel'),
				"wJobs":this.SelectWorkData.attr('wJobs'),
				"wIncome":this.SelectWorkData.attr('wIncome')};
	}
}
function GetWorkData(eId)
{
	return Staff_do.GetWorkData(eId);
}
function ShowWorkData(eId)
{
	Staff_do.SelectWorkData = $('#work_' + eId);
	Staff_do.PageBox=dialog("工作信息","iframe:workdata_do.aspx",Staff_do.dw,Staff_do.dh,"iframe");
}
//删除工作
TStaff_do.prototype.DelWorkData = function(eId)
{
	$('#work_'+eId).remove();
}
function DelWorkData(eId)
{
	jConfirm('是否确认删除?删除后无法恢复!','提示',function(r){
		if(r)
		{
			Staff_do.DelWorkData(eId);
		}
	});
	
}


//添加家庭
TStaff_do.prototype.SetFamilyData = function(sData)
{
	if(sData)
	{
		if (this.SelectFamilyData) {
			$('#FamilyDataList').append('<li id="' + this.SelectFamilyData.attr('id') + '" StaffFamilyDataID="' + this.SelectFamilyData.attr('StaffFamilyDataID') + '" fTitle="' + sData.fTitle + '" fName="' + sData.fName + '" fAge="' + sData.fAge + '" fEnterprise="'+sData.fEnterprise+'" fWork="'+sData.fWork+'" fAddress="'+sData.fAddress+'" fTel="'+sData.fTel+'"><a href="javascript:void(0);" onclick="javascript:ShowFamilyData(' + this.SelectFamilyData.attr('id').replace('family_','') + ');">' + sData.fTitle + '-' + sData.fName + '-' + sData.fAge + '</a> <a href="javascript:void(0);" onclick="javascript:DelFamilyData(' + this.SelectFamilyData.attr('id').replace('family_','') + ');">[删]</a></li>');
		}
		else {
			$('#FamilyDataList').append('<li id="family_' + this.FamilyLoop + '" StaffFamilyDataID="'+(sData.StaffFamilyDataID?sData.StaffFamilyDataID:0)+'" fTitle="' + sData.fTitle + '" fName="' + sData.fName + '" fAge="' + sData.fAge + '" fEnterprise="'+sData.fEnterprise+'" fWork="'+sData.fWork+'" fAddress="'+sData.fAddress+'" fTel="'+sData.fTel+'"><a href="javascript:void(0);" onclick="javascript:ShowFamilyData(' + this.FamilyLoop + ');">' + sData.fTitle + '-' + sData.fName + '-' + sData.fAge + '</a> <a href="javascript:void(0);" onclick="javascript:DelFamilyData(' + this.FamilyLoop + ');">[删]</a></li>');
		}
	}
	this.WorkLoop++;
}
function SetFamilyData(sData)
{
	Staff_do.SetFamilyData(sData);
}
//获取教育
TStaff_do.prototype.GetFamilyData = function(eId)
{
	if (eId) {
		this.SelectFamilyData = $('#family_' + eId);
	}
	if (this.SelectFamilyData) {
		return {"StaffFamilyDataID":this.SelectFamilyData.attr('StaffFamilyDataID'),
				"fTitle":this.SelectFamilyData.attr('fTitle'),
				"fName":this.SelectFamilyData.attr('fName'),
				"fAge":this.SelectFamilyData.attr('fAge'),
				"fEnterprise":this.SelectFamilyData.attr('fEnterprise'),
				"fWork":this.SelectFamilyData.attr('fWork'),
				"fAddress":this.SelectFamilyData.attr('fAddress'),
				"fTel":this.SelectFamilyData.attr('fTel')};
	}
}
function GetFamilyData(eId)
{
	return Staff_do.GetFamilyData(eId);
}
function ShowFamilyData(eId)
{
	Staff_do.SelectFamilyData = $('#family_' + eId);
	Staff_do.PageBox=dialog("家庭信息","iframe:familydata_do.aspx",Staff_do.dw,Staff_do.dh,"iframe");
}
//删除工作
TStaff_do.prototype.DelFamilyData = function(eId)
{
	$('#family_'+eId).remove();
}
function DelFamilyData(eId)
{
	jConfirm('是否确认删除?删除后无法恢复!','提示',function(r){
		if(r)
		{
			Staff_do.DelFamilyData(eId);
		}
	});	
}


TStaff_do.prototype.GetData = function()
{
	var EduDataList = $('#EduDataList').children('li');
	var WorkDataList = $('#WorkDataList').children('li');
	var FamilyDataList = $('#FamilyDataList').children('li');
	if(EduDataList)
	{
		this.EduDataListJsonStr = '';
		for(var i=0;i<EduDataList.length;i++)
		{
			if(EduDataList[i]){
				this.EduDataListJsonStr+='{"StaffEduDataID":"'+$(EduDataList[i]).attr('StaffEduDataID')+'","StaffID":"'+Staff_do.StaffID+'","eDate":"'+$(EduDataList[i]).attr('eDate')+'","eSchools":"'+$(EduDataList[i]).attr('eSchools')+'","eContent":"'+$(EduDataList[i]).attr('eContent')+'"},';
			}
		}
		if (this.EduDataListJsonStr != '') {
			this.EduDataListJsonStr = '{"EduDataListJson":[' + this.EduDataListJsonStr.substring(0, this.EduDataListJsonStr.length - 1) + ']}';
			$('#EduDataListJson').val(this.EduDataListJsonStr);
		}
	}
	if(WorkDataList)
	{
		this.WorkDataListJsonStr = '';
		for(var i=0;i<WorkDataList.length;i++)
		{
			if(WorkDataList[i])
			{
				this.WorkDataListJsonStr+='{"StaffWorkDataID":"'+$(WorkDataList[i]).attr('StaffWorkDataID')+'","StaffID":"'+Staff_do.StaffID+'","wDate":"'+$(WorkDataList[i]).attr('wDate')+'","wEnterprise":"'+$(WorkDataList[i]).attr('wEnterprise')+'","wTel":"'+$(WorkDataList[i]).attr('wTel')+'","wJobs":"'+$(WorkDataList[i]).attr('wJobs')+'","wIncome":"'+$(WorkDataList[i]).attr('wIncome')+'"},';
			}
		}
		if (this.WorkDataListJsonStr != '') {
			this.WorkDataListJsonStr = '{"WorkDataListJson":[' + this.WorkDataListJsonStr.substring(0, this.WorkDataListJsonStr.length - 1) + ']}';
			$('#WorkDataListJson').val(this.WorkDataListJsonStr);
		}
	}
	if(FamilyDataList)
	{
		this.FamilyDataListJsonStr = '';
		for(var i=0;i<FamilyDataList.length;i++)
		{
			if(FamilyDataList[i])
			{
				this.FamilyDataListJsonStr+='{"StaffFamilyDataID":"'+$(FamilyDataList[i]).attr('StaffFamilyDataID')+'","StaffID":"'+Staff_do.StaffID+'","fTitle":"'+$(FamilyDataList[i]).attr('fTitle')+'","fName":"'+$(FamilyDataList[i]).attr('fName')+'","fAge":"'+$(FamilyDataList[i]).attr('fAge')+'","fEnterprise":"'+$(FamilyDataList[i]).attr('fEnterprise')+'","fWork":"'+$(FamilyDataList[i]).attr('fWork')+'","fAddress":"'+$(FamilyDataList[i]).attr('fAddress')+'","fTel":"'+$(FamilyDataList[i]).attr('fTel')+'"},';
			}
		}
		if (this.FamilyDataListJsonStr != '') {
			this.FamilyDataListJsonStr = '{"FamilyDataListJson":[' + this.FamilyDataListJsonStr.substring(0, this.FamilyDataListJsonStr.length - 1) + ']}';
			$('#FamilyDataListJson').val(this.FamilyDataListJsonStr);
		}
	}
}
function HidBox()
{
	CloseBox();
}

