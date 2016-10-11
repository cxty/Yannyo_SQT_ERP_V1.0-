/**
 * @author Cxty
 */
$().ready(function(){
	$('#StoresName').autocomplete('Services/CAjax.aspx',{
		
		width: 200,
		scroll: true,
		autoFill: true,
		scrollHeight: 200,
		matchContains: true,
		dataType: 'json',
		extraParams:{
			'do':'GetStoresList',
			'RCode':Math.random(),
			'StoresName':function(){return $('#StoresName').val();}
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
			$("#StoresID").val((formatted!=null)?formatted:"0");      
		}
	  );
});

function TMConfig_do()
{
	
}
TMConfig_do.prototype.ini = function()
{
	$('#but_sub').click(function()
	{
		if($('#m_Name').val()=='')
		{
			alert('名称不能为空!');
			$('#m_Name').focus();
		}else if($('#StoresID').val()=='')
		{
			alert('客户不能为空,请从下来列表中选择!');
			$('#StoresName').focus();
		}else{
			$('#bForm').submit();
		}
	});
}
