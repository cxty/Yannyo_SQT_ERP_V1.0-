/**
 * @author cxty@qq.com
 */
function TApmoneyManage_Bat()
{
	this.PageBox = null;
	this.PageForm = null;

	this.Act = null;
	this.tObj_Box = null;
	this.loop_count = 0;
	this.loop_count_obj = null;
	this.tLoop_box = null;
	this.APObjType_A = null;
	this.APObjType = 2;//默认是供货商,1=个人
}
TApmoneyManage_Bat.prototype.ini = function()
{
	this.PageForm = document.getElementById('bForm');
	this.tObj_Box = document.getElementById('tObj_Box');
	this.tLoop_box = document.getElementById('tLoop_box');
	this.Act = document.getElementById('Act');
	this.APObjType_A = document.getElementById('APObjType_A');
	this.loop_count_obj = document.getElementById('loop_count_obj');
	
	this.CheckR();
	this.DelAll();
}
TApmoneyManage_Bat.prototype.Add = function()
{
	if(this.tLoop_box)
	{
		var tHTML = '<table width="630px" border="0" cellspacing="0" cellpadding="0" id="tLoop_Table_'+this.loop_count+'">'+
					  '<tr>'+
					    '<td width="100px"><input name="sName_'+this.loop_count+'" id="sName_'+this.loop_count+'" type="text" style="width:100px"  />'+
						'<INPUT TYPE="hidden" NAME="APObjID_'+this.loop_count+'" id="APObjID_'+this.loop_count+'"  /></td>'+
					    '<td width="80px"><input name="nMoney_'+this.loop_count+'" id="nMoney_'+this.loop_count+'" type="text" style="width:80px"/></td>'+
					    '<td width="80px"><input name="tMoney_'+this.loop_count+'" id="tMoney_'+this.loop_count+'" type="text" style="width:80px"/></td>'+
						'<td width="80px"><input name="aPayMoney_'+this.loop_count+'" id="aPayMoney_'+this.loop_count+'" type="text" style="width:80px"/></td>'+
					   '<td width="100px"><input name="FeesSubjectName_'+this.loop_count+'" id="FeesSubjectName_'+this.loop_count+'" type="text" style="width:100px"/>'+
						'<INPUT TYPE="hidden" NAME="FeesSubjectID_'+this.loop_count+'" id="FeesSubjectID_'+this.loop_count+'" /></td>'+
					    '<td width="80px"><input name="aDoDateTime_'+this.loop_count+'" id="aDoDateTime_'+this.loop_count+'" onclick="new Calendar().show(this);" type="text" style="width:80px"/></td>'+
						'<td width="30px"><a href="javascript:void(0);" onclick="javascript:ApmoneyManage_Bat.Del('+this.loop_count+');">删除</a></td>'+
					  '</tr></table>';
					  
		this.tLoop_box.innerHTML += tHTML;

		this.BAutoinput(document.getElementById('sName_'+this.loop_count),document.getElementById('APObjID_'+this.loop_count),this.loop_count);
		
		this.BAutoinput_b(document.getElementById('FeesSubjectName_'+this.loop_count),document.getElementById('FeesSubjectID_'+this.loop_count));

		this.loop_count++;
		
		tHTML = null;
	}
}
TApmoneyManage_Bat.prototype.BAutoinput = function(sObj,jObj,tI)
{
	var tDo = (this.APObjType==2)?'GetSupplierList':'GetStaffList';

	if (this.APObjType == 2) {
		$('#' + sObj.id).autocomplete('Services/CAjax.aspx', {
		
			width: 200,
			scroll: true,
			autoFill: true,
			scrollHeight: 200,
			matchContains: true,
			dataType: 'json',
			extraParams: {
				'do': tDo,
				'RCode': Math.random(),
				'eDate':function(){return $('#eDate').val()},
				'SupplierName': function(){
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
						result: tArray[i].value,
						ApMoney: tArray[i].ApMoney,
						NpMoney: tArray[i].NpMoney
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
		}).result(function(event, data, formatted, row){
			$('#nMoney_'+tI).val(row.NpMoney);
			$('#tMoney_'+tI).val(row.ApMoney);
			$('#' + jObj.id).val((formatted != null) ? formatted : "0");
		});
	}else{
		$('#' + sObj.id).autocomplete('Services/CAjax.aspx', {
			width: 200,
			scroll: true,
			autoFill: true,
			scrollHeight: 200,
			matchContains: true,
			dataType: 'json',
			extraParams: {
				'do': tDo,
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
}
TApmoneyManage_Bat.prototype.BAutoinput_b = function(sObj,jObj)
{
	$('#'+sObj.id).autocomplete('Services/CAjax.aspx',{ 
		
		width: 200,
		scroll: true,
		autoFill: true,
		scrollHeight: 200,
		matchContains: true,
		dataType: 'json',
		extraParams:{
			'do':'GetFeesSubjectList',
			'RCode':Math.random(),
			'FeesSubjectName':function(){return $('#'+sObj.id).val();}
		},
		parse: function(data) {
				var rows = [];  
				var tArray = data.results;
				 for(var i=0; i<tArray.length; i++){  
				  rows[rows.length] = {    
					data:tArray[i].value,    
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
			$("#"+jObj.id).val((formatted!=null)?formatted:"0");
		}
	  );
}
TApmoneyManage_Bat.prototype.Del = function(tID)
{
	var tObj = document.getElementById('tLoop_Table_'+tID);
	if(tObj)
	{
		tObj.parentNode.removeChild(tObj);
	}
}
TApmoneyManage_Bat.prototype.DelAll = function()
{
	for(var i=0;i<this.loop_count;i++)
	{
		this.Del(i);
	}
	this.Add();
}
TApmoneyManage_Bat.prototype.CheckR = function()
{
	if(this.APObjType_A.checked)
	{
		this.APObjType = 2;
		this.tObj_Box.innerHTML = '供货商';
		this.DelAll();
		
	}
	else
	{
		this.APObjType = 1;
		this.tObj_Box.innerHTML = '个人';
		this.DelAll();
		
	}
}
TApmoneyManage_Bat.prototype.CheckS = function()
{
	this.loop_count_obj.value = this.loop_count;
	this.Act.value = 'OK';
	this.PageForm.submit();
}

