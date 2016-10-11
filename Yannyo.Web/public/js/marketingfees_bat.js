/**
 * @author cxty@qq.com
 */
function TMarketingfees_bat()
{
	this.PageBox = null;
	this.PageForm = null;

	this.Act = null;
	this.tObj_Box = null;
	this.loop_count = 0;
	this.loop_count_obj = null;
	this.tLoop_box = null;
	this.ObjType_A = null;
	this.ObjType = 0;//默认是收入,1=支出
	
	this.ObjType_B_Box = null;
	this.ObjTypeB_A = null;
	this.ObjTypeB = 0;//默认是销售费用,1=公司费用
}
TMarketingfees_bat.prototype.ini = function()
{
	this.PageForm = document.getElementById('bForm');
	this.tObj_Box = document.getElementById('tObj_Box');
	this.tLoop_box = document.getElementById('tLoop_box');
	this.Act = document.getElementById('Act');
	this.ObjType_A = document.getElementById('ObjType_A');
	this.ObjTypeB_A = document.getElementById('ObjTypeB_A');
	this.ObjType_B_Box = document.getElementById('ObjType_B_Box');
	this.loop_count_obj = document.getElementById('loop_count_obj');
	
	this.CheckR();
	this.DelAll();
}
TMarketingfees_bat.prototype.Add = function()
{
	if(this.tLoop_box)
	{
		var tHTML_s = '';
		if(this.ObjType == 1 && this.ObjTypeB==0)
		{
			tHTML_s = '<td width="100px"><input name="StoresName_'+this.loop_count+'" id="StoresName_'+this.loop_count+'" type="text" style="width:100px"  />'+
						'<INPUT TYPE="hidden" NAME="StoresID_'+this.loop_count+'" id="StoresID_'+this.loop_count+'"  /></td>';
		}else
		{
			tHTML_s = '';
		}
		var tHTML = '<table width="630px" border="0" cellspacing="0" cellpadding="0" id="tLoop_Table_'+this.loop_count+'">'+
					  '<tr>'+tHTML_s+
					    '<td width="70px"><input name="FeesSubjectName_'+this.loop_count+'" id="FeesSubjectName_'+this.loop_count+'" type="text" style="width:70px"/>'+
						'<INPUT TYPE="hidden" NAME="FeesSubjectID_'+this.loop_count+'" id="FeesSubjectID_'+this.loop_count+'"  /></td>'+
					    '<td width="70px"><input name="StaffName_'+this.loop_count+'" id="StaffName_'+this.loop_count+'" type="text" style="width:70px"/>'+
						'<INPUT TYPE="hidden" NAME="StaffID_'+this.loop_count+'" id="StaffID_'+this.loop_count+'"  /></td>'+
					    '<td width="70px"><input name="mDateTime_'+this.loop_count+'" id="mDateTime_'+this.loop_count+'" onclick="new Calendar().show(this);" type="text" style="width:70px"/></td>'+
					    '<td width="70px"><input name="mFees_'+this.loop_count+'" id="mFees_'+this.loop_count+'" type="text" style="width:70px"/></td>'+
					    '<td width="100px"><input name="mRemark_'+this.loop_count+'" id="mRemark_'+this.loop_count+'" type="text" style="width:100px"/></td>'+
					    '<td width="30px"><a href="javascript:void(0);" onclick="javascript:Marketingfees_bat.Del('+this.loop_count+');">删除</a></td>'+
					  '</tr></table>';
					  
		this.tLoop_box.innerHTML += tHTML;
		
		if(this.ObjType == 1 && this.ObjTypeB==0)
		{
			this.BStoresAutoInput(document.getElementById('StoresName_'+this.loop_count),document.getElementById('StoresID_'+this.loop_count));
		}
		
		this.BFeesSubjectAutoInput(document.getElementById('FeesSubjectName_'+this.loop_count),document.getElementById('FeesSubjectID_'+this.loop_count));
		this.BStaffAutoInput(document.getElementById('StaffName_'+this.loop_count),document.getElementById('StaffID_'+this.loop_count));
		
		this.loop_count++;
		
		tHTML = null;
	}
}
TMarketingfees_bat.prototype.Del = function(tID)
{
	var tObj = document.getElementById('tLoop_Table_'+tID);
	if(tObj)
	{
		tObj.parentNode.removeChild(tObj);
	}
}
TMarketingfees_bat.prototype.DelAll = function()
{
	for(var i=0;i<this.loop_count;i++)
	{
		this.Del(i);
	}
	this.Add();
}
TMarketingfees_bat.prototype.CheckR = function()
{
	if(this.ObjType_A.checked)
	{
		this.ObjType = 0;
		this.ObjType_B_Box.style.display = 'none';
		this.tObj_Box.style.display = 'none';
		this.DelAll();
	}
	else
	{
		this.ObjType = 1;
		this.ObjType_B_Box.style.display = '';
		this.CheckRB();
		this.DelAll();
	}
}
TMarketingfees_bat.prototype.CheckRB = function()
{
	if(this.ObjTypeB_A.checked)
	{
		this.ObjTypeB = 0;
		this.tObj_Box.style.display = '';
		this.DelAll();
	}
	else
	{
		this.ObjTypeB = 1;
		this.tObj_Box.style.display = 'none';
		this.DelAll();	
	}
}
TMarketingfees_bat.prototype.CheckS = function()
{
	this.loop_count_obj.value = this.loop_count;
	this.Act.value = 'OK';
	this.PageForm.submit();
}
//门店
TMarketingfees_bat.prototype.BStoresAutoInput = function(sObj,jObj)
{
	$('#' + sObj.id).autocomplete('Services/CAjax.aspx', {
		
			width: 200,
			scroll: true,
			autoFill: true,
			scrollHeight: 200,
			matchContains: true,
			dataType: 'json',
			extraParams: {
				'do': 'GetStoresList',
				'RCode': Math.random(),
				'StoresName': function(){
					return $('#' + sObj.id).val();
				}
			},
			parse: function(data){
				var rows = [];
				var tArray = data.results;
				for (var i = 0; i < tArray.length; i++) {
					rows[rows.length] = {
						data: tArray[i].value + "(" + tArray[i].info + ")",
						value: tArray[i].id,
						result: tArray[i].value
					};
				}
				return rows;
			},
			formatItem: function(row, i, max){
				return row;
			},
			formatMatch: function(row, i, max){
				return row.value;
			},
			formatResult: function(row){
				return row.value;
			}
		}).result(function(event, data, formatted){
			$('#' + jObj.id).val((formatted != null) ? formatted : "0");
		});
}
TMarketingfees_bat.prototype.BFeesSubjectAutoInput = function(sObj,jObj)
{
	$('#' + sObj.id).autocomplete('Services/CAjax.aspx', {
		
			width: 200,
			scroll: true,
			autoFill: true,
			scrollHeight: 200,
			matchContains: true,
			dataType: 'json',
			extraParams: {
				'do': 'GetFeesSubjectList',
				'RCode': Math.random(),
				'FeesSubjectName': function(){
					return $('#' + sObj.id).val();
				}
			},
			parse: function(data){
				var rows = [];
				var tArray = data.results;
				for (var i = 0; i < tArray.length; i++) {
					rows[rows.length] = {
						data: tArray[i].value,
						value: tArray[i].id,
						result: tArray[i].value
					};
				}
				return rows;
			},
			formatItem: function(row, i, max){
				return row;
			},
			formatMatch: function(row, i, max){
				return row.value;
			},
			formatResult: function(row){
				return row.value;
			}
		}).result(function(event, data, formatted){
			$('#' + jObj.id).val((formatted != null) ? formatted : "0");
		});
}
TMarketingfees_bat.prototype.BStaffAutoInput = function(sObj,jObj)
{
	$('#' + sObj.id).autocomplete('Services/CAjax.aspx', {
		
			width: 200,
			scroll: true,
			autoFill: true,
			scrollHeight: 200,
			matchContains: true,
			dataType: 'json',
			extraParams: {
				'do': 'GetStaffList',
				'RCode': Math.random(),
				'StaffName': function(){
					return $('#' + sObj.id).val();
				}
			},
			parse: function(data){
				var rows = [];
				var tArray = data.results;
				for (var i = 0; i < tArray.length; i++) {
					rows[rows.length] = {
						data: tArray[i].value + "(" + tArray[i].info + ")",
						value: tArray[i].id,
						result: tArray[i].value
					};
				}
				return rows;
			},
			formatItem: function(row, i, max){
				return row;
			},
			formatMatch: function(row, i, max){
				return row.value;
			},
			formatResult: function(row){
				return row.value;
			}
		}).result(function(event, data, formatted){
			$('#' + jObj.id).val((formatted != null) ? formatted : "0");
		});
}
