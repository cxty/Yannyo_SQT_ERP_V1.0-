/**
 * @author cxty@qq.com
 */
function TArmoneyManage_Bat()
{
	this.PageBox = null;
	this.PageForm = null;

	this.Act = null;
	this.tObj_Box = null;
	this.loop_count = 0;
	this.loop_count_obj = null;
	this.tLoop_box = null;
	this.ARObjType_A = null;
	this.ARObjType_B = null;
	this.ARObjType_C = null;
	this.ARObjType = 0;//默认是客户,1=个人
	this.eDate = null;
}
TArmoneyManage_Bat.prototype.ini = function()
{
	this.PageForm = document.getElementById('bForm');
	this.tObj_Box = document.getElementById('tObj_Box');
	this.tLoop_box = document.getElementById('tLoop_box');
	this.Act = document.getElementById('Act');
	this.ARObjType_A = document.getElementById('ARObjType_A');
	this.ARObjType_B = document.getElementById('ARObjType_B');
	this.ARObjType_C = document.getElementById('ARObjType_C');
	this.loop_count_obj = document.getElementById('loop_count_obj');
	this.eDate = document.getElementById('eDate');
	
	this.CheckR();
	this.DelAll();
}
TArmoneyManage_Bat.prototype.Add = function()
{
	if(this.tLoop_box)
	{
		var tHTML = '<table width="680px" border="0" cellspacing="0" cellpadding="0" id="tLoop_Table_'+this.loop_count+'">'+
					  '<tr>'+
					    '<td width="100px"><input name="sName_'+this.loop_count+'" id="sName_'+this.loop_count+'" type="text" style="width:100px"  />'+
						'<INPUT TYPE="hidden" NAME="ARObjID_'+this.loop_count+'" id="ARObjID_'+this.loop_count+'"  />'+
						'<INPUT TYPE="hidden" NAME="tValue_'+this.loop_count+'" id="tValue_'+this.loop_count+'"  /></td>'+
					    '<td width="60px"><input name="aAMoney_'+this.loop_count+'" id="aAMoney_'+this.loop_count+'" type="text" style="width:60px"/></td>'+
					    '<td width="60px"><input name="aBMoney_'+this.loop_count+'" id="aBMoney_'+this.loop_count+'" type="text" style="width:60px"/></td>'+
					    '<td width="60px"><input name="aOpenDate_'+this.loop_count+'" id="aOpenDate_'+this.loop_count+'" onclick="new Calendar().show(this);" type="text" style="width:60px"/></td>'+
					    '<td width="60px"><input name="aOpenMoney_'+this.loop_count+'" id="aOpenMoney_'+this.loop_count+'" type="text" style="width:60px"/></td>'+
					    '<td width="60px"><input name="aDate_'+this.loop_count+'" id="aDate_'+this.loop_count+'" onclick="new Calendar().show(this);" type="text" style="width:60px"/></td>'+
						'<td width="60px"><input name="aActualDate_'+this.loop_count+'" id="aActualDate_'+this.loop_count+'" onclick="new Calendar().show(this);" type="text" style="width:60px"/></td>'+
						'<td width="60px"><input name="aActualMoney_'+this.loop_count+'" id="aActualMoney_'+this.loop_count+'" type="text" style="width:60px" onkeydown="javascript:ArmoneyManage_Bat.AutoValue('+this.loop_count+');" onkeyup="javascript:ArmoneyManage_Bat.AutoValue('+this.loop_count+');" onchange="javascript:ArmoneyManage_Bat.AutoValue('+this.loop_count+');"/></td>'+
					    '<td width="30px"><a href="javascript:void(0);" onclick="javascript:ArmoneyManage_Bat.Del('+this.loop_count+');">删除</a></td>'+
					  '</tr></table>';
					  
		this.tLoop_box.innerHTML += tHTML;

		this.BAutoinput(document.getElementById('sName_'+this.loop_count),document.getElementById('ARObjID_'+this.loop_count),this.loop_count);
		
		this.loop_count++;
		
		tHTML = null;
	}
}
TArmoneyManage_Bat.prototype.AutoValue = function(tI)
{
	/*
	var sObj = document.getElementById('aActualMoney_'+tI);
	var tObj = document.getElementById('aBMoney_'+tI);
	var ttObj = document.getElementById('aOpenMoney_'+tI);
	var vObj = document.getElementById('tValue_'+tI);
	if(sObj && tObj && ttObj && vObj)
	{
		tObj.value = Number(vObj.value)-Number(sObj.value);
		ttObj.value = tObj.value;
	}
	*/
}
TArmoneyManage_Bat.prototype.BAutoinput = function(sObj,jObj,tI)
{
	
	if (this.ARObjType == 0) {
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
				'eDate':function(){return $('#eDate').val()},
				'StoresName': function(){return $('#' + sObj.id).val();}
			},
			parse: function(data){
				var rows = [];
				var tArray = data.results;
				for (var i = 0; i < tArray.length; i++) {
					rows[rows.length] = {
						data: tArray[i].value + "(" + tArray[i].info + ")",
						value: tArray[i].id,
						result: tArray[i].value,
						ArMoney: tArray[i].ArMoney,
						NrMoney: tArray[i].NrMoney
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
			formatResult: function(row, i, max){
				return row.value;
			}
		}).result(function(event, data, formatted, row){
			$('#aAMoney_'+tI).val(row.NrMoney);
			$('#aBMoney_'+tI).val(row.ArMoney);
			$('#aOpenMoney_'+tI).val(row.ArMoney);
			$('#tValue_'+tI).val(row.ArMoney);

			$('#' + jObj.id).val((formatted != null) ? formatted : "0");
			
		});
	}else if (this.ARObjType == 1){
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
	}else if (this.ARObjType == 2){
		$('#' + sObj.id).autocomplete('Services/CAjax.aspx', {
		
			width: 200,
			scroll: true,
			autoFill: true,
			scrollHeight: 200,
			matchContains: true,
			dataType: 'json',
			extraParams: {
				'do': 'GetPaymentSystemList',
				'RCode': Math.random(),
				'eDate':function(){return $('#eDate').val()},
				'PaymentSystemName': function(){
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
						NrMoney: tArray[i].NrMoney,
						ArMoney: tArray[i].tArray
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
			$('#aAMoney_'+tI).val(row.NrMoney);
			$('#aBMoney_'+tI).val(row.ArMoney);
			$('#aOpenMoney_'+tI).val(row.ArMoney);
			$('#tValue_'+tI).val(row.ArMoney);
			
			$('#' + jObj.id).val((formatted != null) ? formatted : "0");
		});
	}
}
TArmoneyManage_Bat.prototype.Del = function(tID)
{
	var tObj = document.getElementById('tLoop_Table_'+tID);
	if(tObj)
	{
		tObj.parentNode.removeChild(tObj);
	}
}
TArmoneyManage_Bat.prototype.DelAll = function()
{
	for(var i=0;i<this.loop_count;i++)
	{
		this.Del(i);
	}
	this.Add();
}
TArmoneyManage_Bat.prototype.CheckR = function()
{
	if(this.ARObjType_A.checked)
	{
		this.ARObjType = 0;
		this.tObj_Box.innerHTML = '门店/客户';
		this.DelAll();
		
	}
	else if(this.ARObjType_B.checked)
	{
		this.ARObjType = 1;
		this.tObj_Box.innerHTML = '个人';
		this.DelAll();
		
	}
	else if(this.ARObjType_C.checked)
	{
		this.ARObjType = 2;
		this.tObj_Box.innerHTML = '结算系统';
		this.DelAll();
	}
}
TArmoneyManage_Bat.prototype.CheckS = function()
{
	this.loop_count_obj.value = this.loop_count;
	this.Act.value = 'OK';
	this.PageForm.submit();
}

