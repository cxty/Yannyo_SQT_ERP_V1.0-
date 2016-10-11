/**
 * @author Cxty
 */
function TFeesSubjectClass_do()
{
	this.pObj = null;
	this.Act = '';
	this.FeesSubjectClassID = 0;
}
TFeesSubjectClass_do.prototype.ini = function()
{
	this.pObj = window.parent.FeesSubjectClass.GetSelectObj();
	$('#bt_ok').click(function()
	{
		if($('#cCode').val()!='')
		{
			if($('#cClassName').val()!='')
			{
				if(FeesSubjectClass_do.pObj)
				{
					if(FeesSubjectClass_do.Act=='Add')
					{
						$('#cParentID').val($(FeesSubjectClass_do.pObj).attr('id').replace("t_", ""));
					}
					else
					{
						$('#cParentID').val($(FeesSubjectClass_do.pObj).attr('pid'));
					}
					
					jQuery.post('/feessubjectclass_do-'+FeesSubjectClass_do.Act+'.aspx?reformat=json&cParentID='+$('#cParentID').val(),
					{cCode:""+$('#cCode').val()+"",
					cClassName:""+$('#cClassName').val()+"",
					cType:""+$('#cType').children('option:selected').val()+"",
					cDirection:""+$("input:radio:checked[@name=cDirection]").val()+"",
					cParentID:""+$('#cParentID').val()+"",
					FeesSubjectClassID:""+FeesSubjectClass_do.FeesSubjectClassID+""},
					function(data){
						if(data.results)
						{
							jAlert(data.results.msg,'提示');
							parent.ReLoadTree(data.results.ReValue.ParentID);
							if(data.results.state)
							{
								//parent.CloseBox();
							}
						}
					},'json');
					
					//$('#bForm').submit();
				}
				
			}else
			{
				jAlert('科目名称不能为空!','提示');
				$('#cClassName').focus();
			}
		}else
		{
			jAlert('科目编号不能为空!','提示');
			$('#cCode').focus();
		}
	});
	$('#bt_cancel').click(function()
	{
		window.parent.HidBox();
	});
}