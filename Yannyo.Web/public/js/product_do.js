/**
 * cxty@qq.com
 */
function TProductDo()
{
	this.PageForm = null;
	this.Act = null;
	this.ProductFieldValue = null;
	this.ProductClassID = 0;
	this.obj_id = 0;
}
TProductDo.prototype.ini = function()
{
	this.PageForm = document.getElementById('bForm');
	this.Act = document.getElementById('Act');
	
	//this.iniField(this.ProductClassID);
}
TProductDo.prototype._id = function(){
	return this.obj_id++;
}
TProductDo.prototype.iniField = function(ProductClassID){
	$.getJSON('/products_do.aspx?format=json&Act=GetProductFieldList&ProductClassID='+ProductClassID,function(data){
		if(data.results)
		{
			if(data.results.state == 'True'){
				if(data.data.FieldList){
					$('#ProductField').children().remove();
					var _html = '';
					var _id = 0;
					var obj_value = "";//修改时赋值
					for(var i=0;i<data.data.FieldList.length;i++){
						_id = ProductDo._id();
						obj_value = "";
						switch(data.data.FieldList[i].Field.pfType){
							case 0:
								_html = '<input class="fieldobj" ProductFieldValueID="" ProductFieldID="'+data.data.FieldList[i].Field.ProductFieldID+'" stype="0" id="field_input_'+_id+'" name="field_input_'+_id+'" value="'+(obj_value?obj_value:"")+'" />';
							break;
							case 1:
								_html = '<textarea class="fieldobj" ProductFieldValueID="" ProductFieldID="'+data.data.FieldList[i].Field.ProductFieldID+'" stype="1" id="field_input_'+_id+'" name="field_input_'+_id+'" cols="45" rows="5">'+(obj_value?obj_value:"")+'</textarea>';
							break;
							case 2:
								_html = '<input class="fieldobj" ProductFieldValueID="" ProductFieldID="'+data.data.FieldList[i].Field.ProductFieldID+'" stype="2" id="field_input_'+_id+'" name="field_input_'+_id+'" value="'+(obj_value?obj_value:"")+'" />';
							break;
							case 3:
								_html = '<div class="fieldobj" ProductFieldValueID=""  ProductFieldID="'+data.data.FieldList[i].Field.ProductFieldID+'" id="field_input_'+_id+'" stype="3"><input type="hidden" class="img_value" /><div class="img_list"></div><div style="BACKGROUND:url(/images/upimg.png) no-repeat;" class="img_b" style="margin:5px"   value="选择图片" ></div></div>';
							break;
							case 4:
								_html = '<div class="fieldobj" ProductFieldValueID="" ProductFieldID="'+data.data.FieldList[i].Field.ProductFieldID+'" id="field_input_'+_id+'" stype="4"><input type="hidden" class="file_value" /><div class="file_list"></div><div style="BACKGROUND:url(/images/upfile.png) no-repeat;" class="file_b" style="margin:5px"   value="选择文件" ></div></div>';
							break;
						}
						$('#ProductField').append('<tr id="field_'+i+'"><td  align="right" class="ltd">'+data.data.FieldList[i].Field.pfName+'</td><td align="left" class="rtd">'+_html+'</td></tr>');
						ProductDo.ini_upimg('field_input_'+_id);
						ProductDo.ini_upfile('field_input_'+_id);
					}
					
					ProductDo.ini_productfieldvalue();
				}
			}
		}
	});
}
//初始化图片上传控件
TProductDo.prototype.ini_upimg = function(s_box){
	if(s_box){
		
		if($('#'+s_box).attr('stype') == 3){
			$.jUploader({
                button: $('#' + s_box+' .img_b'), // 这里设置按钮id
                action: '/services/CAjax.aspx?do=UpFile&FileType=jpg,gif,png&fObj='+s_box, // 这里设置上传处理接口
                // 上传开始
                onUpload: function(fileName){	
                	
                },
                // 上传完成事件
                onComplete: function(fileName, response){
                    if(response){
						if(response.code == 0){
							
							ProductDo.Add_img(response.fObj,response.file);
						}else{
							alert(response.msg);
						}
					}
                }
            });
			
		}
	}
}
TProductDo.prototype.Add_img = function(s_box,img_src){
	var _img = $('<img src="'+img_src+'" atr="点击删除" style="width:150px;height:128px;float:left;" />').bind('click',function(){
				$(this).remove();
			});
			
			
	$('#'+s_box+' .img_list').append(_img);
}
//图片上传插件整理值
TProductDo.prototype.toValue_upimg = function(s_box){
	if(s_box){
		if($('#'+s_box).attr('stype') == 3){
			var _imgList = $('#'+s_box+' .img_list img');
			$('#'+s_box+' .img_value').val('');
			var _val = '';
			for(var i=0;i<_imgList.length;i++){
				_val+=$(_imgList).attr('src')+',';
			}
			$('#'+s_box+' .img_value').val(_val);
		}
	}
}
//初始化图片上传控件
TProductDo.prototype.ini_upfile = function(s_box){
	if(s_box){
		
		if($('#'+s_box).attr('stype') == 4){
			$.jUploader({
                button: $('#' + s_box+' .file_b'), // 这里设置按钮id
                action: '/services/CAjax.aspx?do=UpFile&FileType=doc,txt,zip,rar,docx,xsl,xslx&fObj='+s_box, // 这里设置上传处理接口
                // 上传开始
                onUpload: function(fileName){	
                	
                },
                // 上传完成事件
                onComplete: function(fileName, response){
                    if(response){
						if(response.code == 0){
							
							ProductDo.Add_file(response.fObj,response.file);
						}else{
							alert(response.msg);
						}
					}
                }
            });
			
		}
	}
}
TProductDo.prototype.Add_file = function(s_box,file){
	var _file = $('<div src="'+file+'" atr="点击删除" style="width:100%;height:25px;float:left;clear: left;" >'+file+'</div>').bind('click',function(){
				$(this).remove();
			});
			
	$('#'+s_box+' .file_list').append(_file);
}
//文件上传插件整理值
TProductDo.prototype.toValue_upfile = function(s_box){
	if(s_box){
		if($('#'+s_box).attr('stype') == 4){
			var _fileList = $('#'+s_box+' .file_list div');
			$('#'+s_box+' .file_value').val('');
			var _val = '';
			for(var i=0;i<_fileList.length;i++){
				_val+=$(_fileList).attr('src')+',';
			}
			$('#'+s_box+' .file_value').val(_val);
		}
	}
}
TProductDo.prototype.ini_productfieldvalue = function(){
	if(this.ProductFieldValue){
		var _ProductFieldValue = jQuery.parseJSON(this.ProductFieldValue).ProductFieldValue;
		
		var _field_obj = null;
		var _field_obj_id = null;
		for(var i =0 ;i<_ProductFieldValue.length;i++){
			_field_obj = $('#ProductField .fieldobj[ProductFieldID='+_ProductFieldValue[i].ProductFieldID+']');
			_field_obj_id = $(_field_obj).attr('id');
			$(_field_obj).attr('ProductFieldValueID',_ProductFieldValue[i].ProductsFieldValueID);
			switch($(_field_obj).attr('stype')){
				case 0:case '0':
				case 1:case '1':
				case 2:case '2':
					$(_field_obj).val(_ProductFieldValue[i].pfvData.replace('$r$','\r\n'));
				break;
				case 3:case '3':
					if(_ProductFieldValue[i].pfvData){
						var _img = _ProductFieldValue[i].pfvData.split(',');
						for(var _j=0;_j<_img.length;_j++){
							if(_img[_j]){
								this.Add_img(_field_obj_id,_img[_j]);
							}
						}
						_img = null;
					}
				break;
				case 4:case '4':
					var _file = _ProductFieldValue[i].pfvData.split(',');
						for(var _j=0;_j<_file.length;_j++){
							if(_file[_j]){
								this.Add_file(_field_obj_id,_file[_j]);
							}
						}
						_file = null;
				break;
			}
		}
	}
}
TProductDo.prototype.sub_form = function(){
	var _all_field = $('#ProductField .fieldobj');
	var _json = "";
	for(var i=0;i<_all_field.length;i++){
		var _ProductFieldValueID = $(_all_field[i]).attr('ProductFieldValueID')?$(_all_field[i]).attr('ProductFieldValueID'):0;
		var _ProductFieldID = $(_all_field[i]).attr('ProductFieldID')?$(_all_field[i]).attr('ProductFieldID'):0;
		var _Type = $(_all_field[i]).attr('stype')?$(_all_field[i]).attr('stype'):0;
		switch($(_all_field[i]).attr('stype')){
			case 0:case '0':
			case 1:case '1':
			case 2:case '2':
				_json += '{"ProductFieldValueID":"'+_ProductFieldValueID+'","ProductFieldID":"'+_ProductFieldID+'","value":"'+$(_all_field[i]).val().replace(/[\r]/g,'[br]').replace(/[\n]/g,'[br]')+'","Type":"'+_Type+'"},';
			break;
			case 3:case '3':
				this.toValue_upimg($(_all_field[i]).attr('id'));
				_json += '{"ProductFieldValueID":"'+_ProductFieldValueID+'","ProductFieldID":"'+_ProductFieldID+'","value":"'+$(_all_field[i]).children('.img_value').val()+'","Type":"'+_Type+'"},';
			break;
			case 4:case '4':
				this.toValue_upfile($(_all_field[i]).attr('id'));
				_json += '{"ProductFieldValueID":"'+_ProductFieldValueID+'","ProductFieldID":"'+_ProductFieldID+'","value":"'+$(_all_field[i]).children('.file_value').val()+'","Type":"'+_Type+'"},';
			break;
		}
	}
	if(_json){
		_json = _json.substring(0,_json.length-1);	
	}
	$('#ProductFieldValue').val('{"FieldValue":['+_json+']}');
}
TProductDo.prototype.SetState = function(pid)
{
	$.getJSON('/Services/CAjax.aspx?do=SetProductsState&ProductID='+pid,function(data){
		if(data.results)
		{
			$('#p_'+data.pid).html((data.state==0)?'正常':'屏蔽');
		}else{
			
			
		}
	});
}
