/**
 * @author Cxty
 */
function TMexpressTemplates_do()
{
	this.PageBox = null;
	this.PageForm = null;
	this.m_ConfigInfoID = 0;
	this.tExpJson = '';
}
TMexpressTemplates_do.prototype.ini = function(){
	if (this.tExpJson) {
		this.iniSelect();
	}
	$('#PublicExpressTemplates').change(function()
	{
		MexpressTemplates_do.SelectTo(this);
	});
	$('#bt_ok').click(function()
	{
		if($('#mName').val())
		{
			if($('#mExpName').val())
			{
				if($('#mPic').val())
				{
					if($('#mWidth').val())
					{
						if($('#mHeight').val())
						{
							if($('#mData').val())
							{
								$('#form1').submit();
							}
							else
							{
								$('#mData').focus();
								alert('模板内容不能为空!');
							}
						}
						else
						{
							$('#mHeight').focus();
							alert('高度不能为空!');
						}
					}
					else
					{
						$('#mWidth').focus();
						alert('宽度不能为空!');
					}
				}
				else
				{
					$('#mPic').focus();
					alert('运单图片不能为空!');
				}
			}
			else
			{
				$('#mExpName').focus();
				alert('快递公司不能为空!');
			}
		}else{
			$('#mName').focus();
			alert('名称不能为空!');
		}
	});
	$('#bt_cancel').click(function()
	{
		window.parent.HidBox();
	});
}
TMexpressTemplates_do.prototype.iniSelect = function()
{
	if(this.tExpJson)
	{
		var sObj = $('#PublicExpressTemplates');
		for(i=0;i<this.tExpJson.PublicExpressTemplates.length;i++)
		{
			sObj.append('<option indexV = "'+i+'" value="'+this.tExpJson.PublicExpressTemplates[i].ID+'">'+this.tExpJson.PublicExpressTemplates[i].Name+'</option>');
		}
		sObj = null;
	}
}
TMexpressTemplates_do.prototype.SelectTo = function(sObj)
{
	var sVal = $(sObj).children('option:selected').val();
	if(Number(sVal)!=-1)
	{
		var tObj = this.tExpJson.PublicExpressTemplates[$(sObj).children('option:selected').attr('indexV')];
		if(tObj)
		{
			$('#mName').val(tObj.Name);
			$('#mExpName').val(tObj.ExpName);
			$('#mWidth').val(tObj.Width);
			$('#mHeight').val(tObj.Height);
			$('#mPic').val(tObj.Pic);
			$('#mData').val(tObj.Data);
		}
		tObj = null;
	}
	sVal = null;
}
TMexpressTemplates_do.prototype.HidUserBox= function()
{
	CloseBox();
}