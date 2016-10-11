

function TDataAnalysis()
{
	this.StoresName = null;
	this.StoresID = null;
	this.StoresName_Box = null;

	this.StaffName = null;
	this.StaffID = null;
	this.StaffName_Box = null;

	this.StaffNameB = null;
	this.StaffIDB = null;
	this.StaffNameB_Box = null;

	this.pBrand = null;
	this.pBrand_Box = null;

	this.RegionID = null;
	this.RegionBox_Box = null;

	this.bDateTime = null;
	this.eDateTime = null;

	this.YHsysName = null;
	this.YHsysID = null;
	this.YHsysName_Box = null;

	this.ProductName = null;
	this.ProductID = null;
	this.ProductName_Box = null;

	this.PageBox = null;
	this.A_Value = null;
	this.A_Value_ID = null;
	this.formB = null;
}
TDataAnalysis.prototype.ini = function()
{
	this.StoresName = document.getElementById('StoresName');
	this.StoresID = document.getElementById('StoresID');
	this.StoresName_Box = document.getElementById('StoresName_Box');

	this.StaffName = document.getElementById('StaffName');
	this.StaffID = document.getElementById('StaffID');
	this.StaffName_Box = document.getElementById('StaffName_Box');

	this.StaffNameB = document.getElementById('StaffNameB');
	this.StaffIDB = document.getElementById('StaffIDB');
	this.StaffNameB_Box = document.getElementById('StaffNameB_Box');

	this.pBrand = document.getElementById('pBrand');
	this.pBrand_Box = document.getElementById('pBrand_Box');

	this.RegionID = document.getElementById('RegionID');
	this.RegionBox_Box = document.getElementById('RegionBox_Box');
	
	this.bDateTime = document.getElementById('bDateTime');
	this.eDateTime = document.getElementById('eDateTime');

	this.YHsysName = document.getElementById('YHsysName');
	this.YHsysID = document.getElementById('YHsysID');
	this.YHsysName_Box = document.getElementById('YHsysName_Box');
	
	this.ProductName = document.getElementById('ProductName');
	this.ProductID = document.getElementById('ProductID');
	this.ProductName_Box = document.getElementById('ProductName_Box');

	this.formB = document.getElementById('form1');
	this.A_Value = document.getElementById('A_Value');
	this.A_Value_ID = document.getElementById('A_Value_ID');
	

}
TDataAnalysis.prototype.ReSet = function()
{
	if(this.StoresName)
	{
		this.StoresName.value = '';
	}
	if(this.StoresID)
	{this.StoresID.value = '';}

	if(this.StaffName)
	{this.StaffName.value = '';}

	if(this.StaffID)
	{this.StaffID.value = '';}
	
	if(this.StaffNameB)
	{this.StaffNameB.value = '';}
	if(this.StaffIDB)
	{this.StaffIDB.value = '';}

	if(this.pBrand)
	{this.pBrand.value = '';}

	if(this.bDateTime)
	{this.bDateTime.value = '';}
	if(this.eDateTime)
	{this.eDateTime.value = '';}

	if(this.RegionID)
	{this.RegionID.value = '';}

}
TDataAnalysis.prototype.CheckF = function()
{
	var isOK = false;

	var dd = $("#category").mcDropdown();
	if(dd!=''){
		var ddarray = dd.getValue();
		if(ddarray.length>0)
		{
			if(Number(ddarray[0])>0){

				this.RegionID.value = Number(ddarray[0]);
			}
		}
	}	

	if(this.bDateTime)
	{
		if(this.bDateTime.value == '')
		{
			isOK = false;
			alert('请选择时间!');
		}else
		{
			isOK = true;
		}
	}
	if(this.eDateTime)
	{
		if(this.eDateTime.value == '')
		{
			isOK = false;
			alert('请选择时间!');
		}else
		{
			isOK = true;
		}
	}
	if(isOK)
	{




		this.PageBox = SysComm.ShowPageBox('load.html',200,25);
		this.formB.submit();
	}
}
TDataAnalysis.prototype.ShowTitleBox = function(sType)
{
	this.PageBox = SysComm.ShowPageBox('dataanalysis-tvalue-'+sType+'.aspx',450,400);
}
TDataAnalysis.prototype.HidUserBox = function()
{
	SysComm.HiddenPageBox(this.PageBox);
}
TDataAnalysis.prototype.ReValue = function(valueArray)
{
	var tStr = '';
	var tId = '';
	if(valueArray)
	{
		for(t in valueArray)
		{
			tStr+=valueArray[t][1]+',';
			tId+=valueArray[t][0]+',';
		}
	}
	this.A_Value.value = tStr;
	this.A_Value_ID.value = tId;
	tStr = null;
	tId = null;
	this.HidUserBox();
}


$(document).ready(function()
{
	//slides the element with class "menu_body" when paragraph with class "menu_head" is clicked 
	$("#firstpane_1 p.menu_head").click(function()
    {
		$(this).css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
       	$(this).siblings().css({backgroundImage:"url(images/left.png)"});
	});
	$("#firstpane_2 p.menu_head").click(function()
    {
		$(this).css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
       	$(this).siblings().css({backgroundImage:"url(images/left.png)"});
	});
	$("#firstpane_3 p.menu_head").click(function()
    {
		$(this).css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
       	$(this).siblings().css({backgroundImage:"url(images/left.png)"});
	});
	$("#firstpane_5 p.menu_head").click(function()
    {
		$(this).css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
       	$(this).siblings().css({backgroundImage:"url(images/left.png)"});
	});
	
});
function f_1()
{
	$('#firstpane_1 p.menu_head').css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
}
function f_2()
{
	$('#firstpane_2 p.menu_head').css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
}
function f_3()
{
	$('#firstpane_3 p.menu_head').css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
}
function f_5()
{
	$('#firstpane_5 p.menu_head').css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
}
function f_6()
{
	$('#firstpane_6 p.menu_head').css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
}

$(document).ready(function (){
	$("#category").mcDropdown("#categorymenu");
});