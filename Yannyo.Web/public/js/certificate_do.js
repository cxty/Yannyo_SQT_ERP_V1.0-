/**
 * cxty@qq.com
 */
function TCertificate_do(){
    this.OrderType = 0;
    this.OrderID = 0;
    this.rowID = 0;
    this.PrintPageWidth = '';
    this.CertificateID = 0;
    this.CertificateDataJsonStr = '';
    this.CertificateDataJson = null;
    
    this.tObjJson = null;
    this.tObjJsonXML = null;
    this.FeesSubjectJson = null;
    this.FeesSubjectJsonXML = null;
    
    this.StaffJson = null;
    
    this.PaymentSystemJson = null;
    
    this.DepartmentsJsonStr = '';
    this.SupplierJsonStr = '';
    this.CustomersJsonStr = '';
    this.FeesSubjectJsonStr = '';
    this.PaymentSystemJsonStr = '';
    
    this.IsAddNew = false;//新建凭证
    this.IsSelectData = false;//已选择旧凭证
    this.IsEdit = false;//是否非修改状态
    this.IsEditAct = false;//是否有修改操作
    this.picStr = '';//凭证照片集合
    this.UserCode = '';
    
    this.cObj = null;//当前选中的单位对象
    this.sObj = null;//当前选中科目对象
    this.PageBox = null;
    
    this.ToObjectTreeIsOK = false;
    this.StaffTreeIsOK = false;
    this.FeesSubjectTreeIsOK = false;
    this.UpID = 0;
    this.DownID = 0;
    
    this.Certificate_lock = 0;//是否锁定凭证操作
    this.OldcDateTime = null;//修改时使用,原凭证时间
    this.MaxOrderDate = null;//凭证列表最大日期
}

TCertificate_do.prototype.ini = function(){
    if (this.IsEdit) {
        this.GetUpDownID();
    }
    //if(this.DepartmentsJsonStr && this.SupplierJsonStr && this.CustomersJsonStr)
    {
        this.tObjJson = jQuery.parseJSON('{"data":[' +
        '{"data":"客户","state":"closed","attr":{"rel":"root","stype":"0"},"children":[' +
        this.CustomersJsonStr +
        ']}' +
        ',{"data":"供应商","state":"closed","attr":{"rel":"root","stype":"1"},"children":[' +
        this.SupplierJsonStr +
        ']}' +
        ',{"data":"人员","state":"closed","attr":{"rel":"root","stype":"2"},"children":[' +
        this.DepartmentsJsonStr +
        ']}' +
        (this.PaymentSystemJsonStr ? ',{"data":"结算系统","state":"closed","attr":{"rel":"root","stype":"3"},"children":[' + this.PaymentSystemJsonStr + ']}' : '') +
        ']}');
        
        this.StaffJson = jQuery.parseJSON('{"data":[{"data":"人员","state":"closed","attr":{"rel":"root","stype":"2"},"children":[' + this.DepartmentsJsonStr + ']}]}');
        
        //this.tObjJsonXML = $($.json2xml(this.tObjJson, {formatOutput:false}));
        
        $("body").append('<div id="ToObjectTreeBox"><div id="ToObjectTree"></div></div>' +
        '<div id="StaffTreeBox"><div id="StaffTree"></div></div>');
        $("#ToObjectTreeBox").hide();
        $("#StaffTreeBox").hide();
        
        
        $('#StaffID_bt').click(function(){
            if ($("#StaffTreeBox").is(":hidden")) {
                Certificate_do.ShowStaffTree();
            }
            else {
                $("#StaffTreeBox").hide();
            }
        });
        $('#StaffName').keyup(function(){
            if ($(this).val() != '') {
                Certificate_do.ShowStaffTree();
            }
            else {
                $("#StaffTreeBox").hide();
            }
        }).bind("paste", function(){
            if ($(this).val() != '') {
                Certificate_do.ShowStaffTree();
            }
            else {
                $("#StaffTreeBox").hide();
            }
        });
    }
    if (this.FeesSubjectJsonStr) {
        this.FeesSubjectJson = jQuery.parseJSON('{"data":[{"data":"科目","state":"closed","attr":{"rel":"root"},"children":[' + this.FeesSubjectJsonStr + ']}]}');
        
        //this.FeesSubjectJsonXML = $($.json2xml(this.FeesSubjectJson, {formatOutput:false}));
        
        $("body").append('<div id="FeesSubjectTreeBox"><div id="FeesSubjectTree"></div></div>');
        $("#FeesSubjectTreeBox").hide();
        
    }
    
    if (this.CertificateDataJsonStr) {
        $("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
        
        $("#floatBoxBg").animate({
            opacity: "0.5"
        }, "normal", function(){
            $(this).show();
            Certificate_do.CertificateDataJson = jQuery.parseJSON(Certificate_do.CertificateDataJsonStr);
            Certificate_do.AddT(Certificate_do.CertificateDataJson);
            $(this).hide();
        });
    }
    
    
    /*
     //凭证类型
     $('#cType').change(function()
     {
     $('#cType_Str').html($(this).children('option:selected').val()==0?'收款':'付款');
     });
     $('#cType').change();
     */
    //新建时可选择原未随附的凭证
    if (this.IsAddNew) {
        $('#cCode').autocomplete('Services/CAjax.aspx', {
            width: 200,
            scroll: true,
            autoFill: true,
            scrollHeight: 200,
            matchContains: true,
            dataType: 'json',
            extraParams: {
                'do': 'GetCertificateList',
                'RCode': Math.random(),
                'IsToObject': 0,
                'cType': 1,
                'CertificateCode': function(){
                    return $('#cCode').val();
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
            if (formatted != null) {
                $.getJSON('/Services/CAjax.aspx?do=GetCertificate&cid=' + formatted, function(data){
                    if (data.results.Certificates) {
                        Certificate_do.IsSelectData = true;//屏蔽修改
                        Certificate_do.CertificateID = data.results.Certificates.CertificateID;
                        $('#toObjectName').val(data.results.Certificates.toObjectName);
                        $('#toObjectID').val(data.results.Certificates.toObjectID);
                        $('#StaffName').val(data.results.Certificates.StaffName);
                        $('#StaffID').val(data.results.Certificates.StaffID);
                        $('#cDateTime').val(data.results.Certificates.cDateTime);
                        $('#BankName').val(data.results.Certificates.BankName);
                        //$('#BankID').val(data.results.Certificates.BankID);
                        
                        Certificate_do.AddT(data.results.DataList);
                        
                        $('#tBoxs :input').attr('readonly', 'readonly');
                    }
                });
            }
        });
    }
    //供应商
    //$('#toObject').change(function(){
    //	Certificate_do.SettoObj($(this).children('option:selected').val());
    //});
    //$('#toObject').change();//初始化
    //this.IsEdit = false;//初始化后
    //"CertificateDataInfoJson":[{"CertificateDataID":0,"CertificateID":0,"FeesSubjectName":"","FeesSubjectID":0,"cdName":null,"cdMoney":0,"cdRemake":null,"cdAppendTime":"\/Date(1292334925660+0800)\/"}] 
    //添加项目
    $('#subbutton_add').click(function(){
        if (!Certificate_do.IsSelectData) {
            Certificate_do.AddT(jQuery.parseJSON('{"CertificateDataInfoJson":[{"CertificateDataID":0,"CertificateID":'+Certificate_do.CertificateID+',"FeesSubjectName":"","FeesSubjectID":0,"cdName":"","cdMoney":0,"cdMoneyB":0,"cdRemake":"","cdAppendTime":"","toObject":"0","toObjectID":"0","ObjectName":""}]}'));
            Certificate_do.IsEditAct = true;
        }
        else {
            jAlert('不能修改原数据!', '提示');
        }
    });
    //录入凭证原件
    $('#subbutton_camera').click(function(){
        var RePid = window.showModalDialog('/camera-' + Certificate_do.CertificateID + '.aspx', null, 'dialogWidth=640px;dialogHeight=480px');
        //alert(RePid);
        Certificate_do.IsEditAct = true;
        Certificate_do.AddPic(RePid);
    });
    //审核凭证
    $('#subbutton_verify').click(function(){
        if (!Certificate_do.IsEditAct) {
            jConfirm('是否确认 <b>审核</b> 操作?<br>提示:审核后的凭证6小时内可以 <b>撤回重审</b>,48小时内可以 <b>作废</b>.', '提示', function(r){
                if (r) {
                    $("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
                    $("#floatBoxBg").animate({
                        opacity: "0.5"
                    }, "normal", function(){
                        $.getJSON('/certificate_do_s-' + Certificate_do.CertificateID + '.aspx?format=json', function(data){
                            if (data.results.state == 'True') {
                                jConfirmYesNo(data.results.msg + ',是否跳转至下一条?', '提示', function(r){
                                    if (r == 'yes') {
                                        var cid = Certificate_do.DownID;//parent.CertificateList.next(Certificate_do.CertificateID);
                                        //cid = (cid) ? cid : (cid != 'undefined') ? cid : Certificate_do.CertificateID;
                                        if (cid > 0) {
                                            location.href = '/certificate_do-Edit-' + cid + '.aspx';
                                        }
                                        else {
                                            jAlert('已经是最后一条!', '提示', function(){
                                                location.href = '/certificate_do-Edit-' + Certificate_do.CertificateID + '.aspx';
                                            });
                                        }
                                    }
                                    else {
                                        location.href = '/certificate_do-Edit-' + Certificate_do.CertificateID + '.aspx';
                                    }
                                });
                            }
                            else {
                                jAlert(data.results.msg, '提示');
                            }
                        });
                    });
                }
            });
        }
        else {
            jAlert('该凭证已被修改,请先保存再审核!', '提示');
        }
    });
    //撤回重审
    $('#subbutton_re_verify').click(function(){
        jConfirm('是否确认 <b>撤回重审</b> 操作?<br>提示:该操作将印象数据统计,并在系统中留下操作记录!', '提示', function(r){
            $("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
            $("#floatBoxBg").animate({
                opacity: "0.5"
            }, "normal", function(){
                $.getJSON('/certificate_do_rs-' + Certificate_do.CertificateID + '.aspx?format=json', function(data){
                    if (data.results.state == 'True') {
                        jAlert(data.results.msg, '提示', function(){
                            location.href = '/certificate_do-Edit-' + Certificate_do.CertificateID + '.aspx';
                        });
                    }
                    else {
                        jAlert(data.results.msg, '提示');
                    }
                });
            });
        });
    });
    //作废
    $('#subbutton_invalid').click(function(){
        jConfirm('是否确认 <b>作废</b> 操作?<br>提示:作废后将不能恢复!', '提示', function(r){
            if (r) {
                $("body").append("<div id=\"floatBoxBg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;\"></div>");
                $("#floatBoxBg").animate({
                    opacity: "0.5"
                }, "normal", function(){
                    $.getJSON('/certificate_do_i-' + Certificate_do.CertificateID + '.aspx?format=json', function(data){
                        if (data.results.state == 'True') {
                            jConfirmYesNo(data.results.msg + ',是否跳转至下一条?', '提示', function(r){
                                if (r == 'yes') {
                                    var cid = Certificate_do.DownID;//parent.CertificateList.next(Certificate_do.CertificateID);
                                    //cid = (cid) ? cid : (cid != 'undefined') ? cid : Certificate_do.CertificateID;
                                    if (cid > 0) {
                                        location.href = '/certificate_do-Edit-' + cid + '.aspx';
                                    }
                                    else {
                                        jAlert('已经是最后一条!', '提示', function(){
                                            location.href = '/certificate_do-Edit-' + Certificate_do.CertificateID + '.aspx';
                                        });
                                    }
                                }
                                else {
                                    location.href = '/certificate_do-Edit-' + Certificate_do.CertificateID + '.aspx';
                                }
                            });
                        }
                        else {
                            jAlert(data.results.msg, '提示');
                        }
                    });
                });
            }
        });
    });
    //操作记录
    $('#subbutton_log').click(function(){
        dialog("查看凭证操作记录", 'iframe:/certificateworkinglog-' + Certificate_do.CertificateID + '.aspx', "500px", "400px", "iframe");
    });
    //打印凭证
    $('#subbutton_print_t').click(function(){
        jConfirm('是否确认 <b>打印</b> 操作?<br>提示:每次打印系统都将留下打印记录!', '提示', function(r){
            if (r) {
                var LODOP;
                try {
                    LODOP = getLodop(document.getElementById('LODOP'), document.getElementById('LODOP_EM'));
                    try {
                        LODOP.PRINT_INIT("凭证打印");
                        //LODOP.SET_PRINT_PAGESIZE(3, Certificate_do.PrintPageWidth, "0", "");
                        LODOP.SET_PRINT_STYLE("FontSize", 12);
                        LODOP.ADD_PRINT_URL(0, 0, "100%", "100%", '/certificate_print-' + Certificate_do.CertificateID + '.aspx?UserCode=' + Certificate_do.UserCode);
                        LODOP.PREVIEW();
                    } 
                    catch (e) {
                        jAlert('请安装打印控件![' + e + ']');
                    }
                    
                    return false;
                } 
                catch (e) {
                    window.open('', "top");
                    setTimeout(window.open('/certificate_print-' + Certificate_do.CertificateID + '.aspx?UserCode=' + Certificate_do.UserCode, "top"), 100);
                    return false;
                }
            }
        });
    });
    //验证,提交
    $('#subbutton_save').click(function(){
        var tV = Certificate_do.GetTDataJson();
        if (tV) {
            //if (Certificate_do.GetStaff()) {
            if (Number($('#StaffID').val()) > 0) {
                if ($.trim($('#cDateTime').val()) != '') {
					if (((Date.parse($('#cDateTime').val()) - (Date.parse(Certificate_do.MaxOrderDate))) / (30 * 24 * 60 * 60 * 1000)) < 0) {
						jAlert('时间不能小于 ' + Certificate_do.MaxOrderDate, '提示');
					}
					else {
					
						$('#CertificateDataStr').val(tV);
						if (Certificate_do.IsSelectData) {
							$('#bForm').attr('action', '/certificate_do-Edit-' + Certificate_do.OrderType + '-' + Certificate_do.OrderID + '-' + Certificate_do.CertificateID + '.aspx');
						}
						$('#NewPIC').val(Certificate_do.picStr);
						$('#bForm').submit();
					}
                }
                else {
                    jAlert('请填写发生时间!', '提示', function(){
                        $('#cDateTime').focus();
                    });
                }
            }
            else {
                jAlert('请选择人员!', '提示');
            }
            //}
        }
    });
    //获取凭证序号
    //if($.browser.msie)
    //{
    //	$('#cDateTime').bind('propertychange',function(e) {
    //		Certificate_do.GetNumber();
    //	});
    //}else{
    
    $('#cDateTime').click(function(){
        if (!$(this).attr('OldDate')) {
            $(this).attr('OldDate', $(this).val());
            $(this).attr('OldNum', $('#cNumber').val());
        }
    });
    
    $('#cDateTime').bind('blur', function(e){
        if (Certificate_do.IsEdit) {//修改状态
            var _odate = toDate($(this).attr('OldDate'));
            var _ndate = toDate($(this).val());
            //if (_ndate < _odate) {
            //    jAlert('时间不能小于原凭证时间!', '提示');
            //    $(this).val($(this).attr('OldDate'));
            //}
            //else {
                var __odate = new Date(_odate);
                var __ndate = new Date(_ndate);
                if (__odate.getYear() == __ndate.getYear()) {
                    if (__odate.getMonth() < __ndate.getMonth()) {
                        Certificate_do.GetNumber(Certificate_do.CertificateID);
                    }
                    else {
                        $('#cNumber').val($(this).attr('OldNum'));
                    }
                }
                else {
                    Certificate_do.GetNumber(Certificate_do.CertificateID);
                }
            //}
        }
        else {
            Certificate_do.GetNumber(0);
        }
        
    });
    //$("#cDateTime").get(0).addEventListener("oninput",function(){Certificate_do.GetNumber();},false);  
    
    //}
    $('body').mousedown(function(oEvent){
        Certificate_do.TreeOut(oEvent);
    });
}
//凭证序号
TCertificate_do.prototype.GetNumber = function(CertificateID){
    var oD = Date.parse(this.OldcDateTime.replace('-', '/'));
    var sD = Date.parse($('#cDateTime').val().replace('-', '/'));
    if (sD) {
    
    }
    else {
        sD = Date.parse($('#cDateTime').val());
    }
    if (oD) {
    
    }
    else {
        oD = Date.parse(Certificate_do.OldcDateTime);
    }
    
    if (Math.abs((sD - oD) / (30 * 24 * 60 * 60 * 1000)) != 0) {
        jQuery.getJSON('/certificate_do.aspx?format=json&Act=GetNum', {
            cDateTime: $('#cDateTime').val(),
			cid:CertificateID,
        }, function(data){
            if (data) {
				if(data.results.MaxOrderDate){
					Certificate_do.MaxOrderDate = data.results.MaxOrderDate;
					//if(((sD-(Date.parse(data.results.MaxOrderDate))) / (30 * 24 * 60 * 60 * 1000)) < 0){
					//	jAlert('时间不能小于 '+data.results.MaxOrderDate,'提示');
					//}else{
						if (data.results.Num) {
		                    $('#cNumber').val(data.results.Num);
		                }
					//}
				}
                
            }
        });
    }
}

//获取经办人
TCertificate_do.prototype.GetStaff = function(){
    var dd = $("#category").mcDropdown();
    if (dd) {
        var ddarray = dd.getValue();
        if (ddarray.length > 0) {
            if (ddarray[0].indexOf('s_') > -1) {
                $('#StaffID').val(Number(ddarray[0].replace('s_', '')));
                return true;
            }
            else {
                jAlert('请选择人员,不能选择部门!', '提示');
            }
        }
        else {
            jAlert('请选择人员!', '提示');
        }
    }
    else {
        jAlert('对象加载失败,请刷新页面!', '提示');
    }
}
//添加项
TCertificate_do.prototype.AddT = function(tData){
    if (tData) {
        var tID = 0;
        var _dthtml = '';
        var tr = $('#dloop');
        
        for (var i = 0; i < tData.CertificateDataInfoJson.length; i++) {
            tID = this.rowID;
            _dthtml = '';
            
            _dthtml = '<tr id="tr_' + tID + '" CertificateDataID="' + tData.CertificateDataInfoJson[i].CertificateDataID + '" CertificateID="' + tData.CertificateDataInfoJson[i].CertificateID + '" class="' + ((tID % 2 != 0) ? 'trA' : 'trB') + '">' +
            
            '<td><input type="text" id="cdName_' +
            tID +
            '" name="cdName_' +
            tID +
            '" value="' +
            tData.CertificateDataInfoJson[i].cdName +
            '" style="width:90%;" /></td>' +
            '<td class="aBt"><input type="text" id="FeesSubjectName_' +
            tID +
            '" name="FeesSubjectName_' +
            tID +
            '" value="' +
            tData.CertificateDataInfoJson[i].FeesSubjectName +
            '" style="width:90%;"  /><input type="hidden" id="FeesSubjectID_' +
            tID +
            '" name="FeesSubjectID_' +
            tID +
            '" value="' +
            tData.CertificateDataInfoJson[i].FeesSubjectID +
            '" /><a href="#"  id="feesbt_' +
            tID +
            '"></a></td>' +
            '<td class="aBt"><input name="toObjectType_' +
            tID +
            '" id="toObjectType_' +
            tID +
            '" type="hidden" value="' +
            tData.CertificateDataInfoJson[i].toObject +
            '" />' +
            '<input name="toObjectID_' +
            tID +
            '" id="toObjectID_' +
            tID +
            '" type="hidden" value="' +
            tData.CertificateDataInfoJson[i].toObjectID +
            '" />' +
            '<input type="text" id="toObjectName_' +
            tID +
            '" name="toObjectName_' +
            tID +
            '" value="' +
            tData.CertificateDataInfoJson[i].ObjectName +
            '" style="width:90%;"  /><a href="#"  id="toobjbt_' +
            tID +
            '"></a></td>' +
            '<td align="right"><input type="text" id="cdMoney_' +
            tID +
            '" name="cdMoney_' +
            tID +
            '" style="text-align:right;width:80%;" value="' +
            Number(tData.CertificateDataInfoJson[i].cdMoney).toFixed(2) +
            '" /></td>' +
            '<td align="right"><input type="text" id="cdMoneyB_' +
            tID +
            '" name="cdMoneyB_' +
            tID +
            '" style="text-align:right;width:80%;" value="' +
            Number(tData.CertificateDataInfoJson[i].cdMoneyB).toFixed(2) +
            '" /></td>' +
            //+'<td><input type="text" id="cdRemake_' +tID +'" name="cdRemake_' +tID +'" value="' +tData.CertificateDataInfoJson[i].cdRemake +'" /></td>' +
            '<td align="center"><a href="javascript:void(0);" onclick="javascript:Certificate_do.DelT(' +
            tID +
            ')" >删除</a></td>' +
            '</tr>';
            jQuery(_dthtml).appendTo(tr);
            
            
            
            //点击单位输入框
            $('#toobjbt_' + tID).click(function(){
                Certificate_do.IsEditAct = true;
                if (Certificate_do.cObj != $('#toObjectName_' + $(this).attr('id').replace('toobjbt_', ''))) {
                    if ($("#ToObjectTreeBox").is(":hidden")) {
                        Certificate_do.ShowToObjectTree($('#toObjectName_' + $(this).attr('id').replace('toobjbt_', '')));
                    }
                    else {
                        $("#ToObjectTreeBox").hide();
                    }
                }
                else 
                    if ($("#ToObjectTreeBox").is(":hidden")) {
                        Certificate_do.ShowToObjectTree($('#toObjectName_' + $(this).attr('id').replace('toobjbt_', '')));
                    }
                    else {
                        $("#ToObjectTreeBox").hide();
                    }
            });
            
            $('#FeesSubjectName_' + tID).val(this.GetParentsStr(this.FeesSubjectJson.data[0], this.FeesSubjectJson.data[0], tData.CertificateDataInfoJson[i].FeesSubjectID, 0));
            //点击科目输入框
            $('#feesbt_' + tID).click(function(){
                Certificate_do.IsEditAct = true;
                if (Certificate_do.sObj != $('#FeesSubjectName_' + $(this).attr('id').replace('feesbt_', ''))) {
                    if ($("#FeesSubjectTreeBox").is(":hidden")) {
                        Certificate_do.ShowFeesSubjectTree($('#FeesSubjectName_' + $(this).attr('id').replace('feesbt_', '')));
                    }
                    else {
                        $("#FeesSubjectTreeBox").hide();
                    }
                }
                else 
                    if ($("#FeesSubjectTreeBox").is(":hidden")) {
                        Certificate_do.ShowFeesSubjectTree($('#FeesSubjectName_' + $(this).attr('id').replace('feesbt_', '')));
                    }
                    else {
                        $("#FeesSubjectTreeBox").hide();
                    }
            });
            
            $('#FeesSubjectName_' + tID).keyup(function(){
                Certificate_do.IsEditAct = true;
                if ($(this).val() != '') {
                    Certificate_do.ShowFeesSubjectTree(this);
                    //$("#FeesSubjectTree").jstree("search",$(this).val());
                }
                else {
                    $("#FeesSubjectTreeBox").hide();
                }
            }).bind("paste", function(){
                Certificate_do.IsEditAct = true;
                if ($(this).val() != '') {
                    Certificate_do.ShowFeesSubjectTree(this);
                    //$("#FeesSubjectTree").jstree("search",$(this).val());
                }
                else {
                    $("#FeesSubjectTreeBox").hide();
                }
            });
            
            $('#toObjectName_' + tID).keyup(function(){
                Certificate_do.IsEditAct = true;
                var tID = $(this).attr('id').replace('toObjectName_', '');
                if ($(this).val() == '') {
                    $('#toObjectType_' + tID).val(0);
                    $('#toObjectID_' + tID).val(0);
                    $("#ToObjectTreeBox").hide();
                }
                else {
                    Certificate_do.ShowToObjectTree(this);
                    //$("#ToObjectTree").jstree("search",$(this).val());
                }
                tID = null;
            }).bind("paste", function(){
                Certificate_do.IsEditAct = true;
                var tID = $(this).attr('id').replace('toObjectName_', '');
                if ($(this).val() == '') {
                    $('#toObjectType_' + tID).val(0);
                    $('#toObjectID_' + tID).val(0);
                    $("#ToObjectTreeBox").hide();
                }
                else {
                    Certificate_do.ShowToObjectTree(this);
                    //$("#ToObjectTree").jstree("search",$(this).val());
                }
                tID = null;
            });
            
            $("#cdMoney_" + tID).keyup(function(){
                Certificate_do.IsEditAct = true;
                CheckNumber($(this));
                Certificate_do.SumT();
            }).bind("paste", function(){
                Certificate_do.IsEditAct = true;
                CheckNumber($(this));
                Certificate_do.SumT();
            });
            $("#cdMoneyB_" + tID).keyup(function(){
                Certificate_do.IsEditAct = true;
                CheckNumber($(this));
                Certificate_do.SumT();
            }).bind("paste", function(){
                Certificate_do.IsEditAct = true;
                CheckNumber($(this));
                Certificate_do.SumT();
            });
            Certificate_do.SumT();
            
            this.rowID++;
        }
    }
}
//显示人员树
TCertificate_do.prototype.ShowStaffTree = function(){
    if (!this.StaffTreeIsOK) {
        $("#StaffTree").jstree({
            "json_data": Certificate_do.StaffJson,
            "types": {
                "valid_children": ["dt"],
                "types": {
                    "dt": {
                        "icon": {
                            "image": "/images/dot.png"
                        },
                        "valid_children": ["default"],
                        "max_depth": 2,
                        "hover_node": true,
                        "open_node": false,
                        "select_node": true
                    },
                    "root": {
                        "valid_children": ["default"],
                        "hover_node": false,
                        "select_node": function(){
                            return false;
                        }
                    }
                }
            },
            "themes": {
                "theme": "default"
            },
            "plugins": ["themes", "json_data", "ui", "crrm", "types", "hotkeys", "search"]
        }).bind("select_node.jstree", function(e, data){
            var sID = data.rslt.obj.attr("id").replace('d_', '');
            var sType = data.rslt.obj.attr("otype");
            var sName = data.rslt.obj.context.text;
            var isRoot = data.rslt.obj.attr("rel") == 'root' ? 1 : 0;
            //Certificate_do.ShowcObjectBox_ReCall(sID,sType,sName);
            $('#StaffID').val(sID);
            $('#StaffName').val(sName);
            $('#StaffTreeBox').hide();
        });
        this.StaffTreeIsOK = true;
    }
    var sObjoffset = $('#StaffName').offset();
    $("#StaffTreeBox").show();
    $("#StaffTreeBox").offset({
        top: sObjoffset.top + 25,
        left: sObjoffset.left
    });
    $("#StaffTree").jstree("search", $('#StaffName').val());
    sObjoffset = null;
}
//显示科目树
TCertificate_do.prototype.ShowFeesSubjectTree = function(sObj){
    if (!this.FeesSubjectTreeIsOK) {
        $("#FeesSubjectTree").jstree({
            "json_data": Certificate_do.FeesSubjectJson,
            "types": {
                "valid_children": ["dt"],
                "types": {
                    "dt": {
                        "icon": {
                            "image": "/images/dot.png"
                        },
                        "valid_children": ["default"],
                        "max_depth": 2,
                        "hover_node": true,
                        "open_node": false,
                        "select_node": true
                    },
                    "root": {
                        "valid_children": ["default"],
                        "hover_node": false,
                        "select_node": function(){
                            return false;
                        }
                    }
                }
            },
            "themes": {
                "theme": "default"
            },
            "plugins": ["themes", "json_data", "ui", "crrm", "types", "hotkeys", "search"]
        }).bind("select_node.jstree", function(e, data){
            var sID = data.rslt.obj.attr("id").replace('t_', '');
            var sName = data.rslt.obj.context.text;
            Certificate_do.ShowFeesSubjectBox_ReCall(sID, sName);
            
        });
        this.FeesSubjectTreeIsOK = true;
    }
    this.sObj = $(sObj);
    var sObjoffset = this.sObj.offset();
    $("#FeesSubjectTreeBox").show();
    $("#FeesSubjectTreeBox").offset({
        top: sObjoffset.top + 25,
        left: sObjoffset.left
    });
    $("#FeesSubjectTree").jstree("search", $(this.sObj).val());
    sObjoffset = null;
}
//显示单位树
TCertificate_do.prototype.ShowToObjectTree = function(sObj){
    if (!this.ToObjectTreeIsOK) {
        $("#ToObjectTree").jstree({
            "json_data": Certificate_do.tObjJson,
            "types": {
                "valid_children": ["dt"],
                "types": {
                    "dt": {
                        "icon": {
                            "image": "/images/dot.png"
                        },
                        "valid_children": ["default"],
                        "max_depth": 2,
                        "hover_node": true,
                        "open_node": false,
                        "select_node": true
                    },
                    "root": {
                        "valid_children": ["default"],
                        "hover_node": false,
                        "select_node": function(){
                            return false;
                        }
                    }
                }
            },
            "themes": {
                "theme": "default"
            },
            "plugins": ["themes", "json_data", "ui", "crrm", "types", "hotkeys", "search"]
        }).bind("select_node.jstree", function(e, data){
            var sID = data.rslt.obj.attr("id").replace('d_', '');
            var sType = data.rslt.obj.attr("otype");
            var sName = data.rslt.obj.context.text;
            var isRoot = data.rslt.obj.attr("rel") == 'root' ? 1 : 0;
            Certificate_do.ShowcObjectBox_ReCall(sID, sType, sName);
            
        });
        this.ToObjectTreeIsOK = true;
    }
    this.cObj = $(sObj);
    var cObjoffset = this.cObj.offset();
    $("#ToObjectTreeBox").show();
    $("#ToObjectTreeBox").offset({
        top: cObjoffset.top + 25,
        left: cObjoffset.left
    });
    $("#ToObjectTree").jstree("search", $(this.cObj).val());
    cObjoffset = null;
    
}
//递归树文字,obj=json对象,val=子节点编号,sType=类型
TCertificate_do.prototype.GetParentsStr = function(obj, lobj, val, sType){
    var tStr = '';
    if (obj && lobj && val) {
        if (lobj.attr.rel == 'root') {
            if (lobj.children) {
                for (var j = 0; j < lobj.children.length; j++) {
                    if (lobj.attr.value == val) {
                        tStr = Certificate_do.GetParentsStrLoop(obj, obj, lobj.attr.pid, sType) + lobj.data;
                    }
                    else {
                        tStr += Certificate_do.GetParentsStr(obj, lobj.children[j], val, sType);
                    }
                    
                }
            }
        }
        else 
            if (lobj.attr.rel == 'dt' && lobj.attr.value == val) {
                tStr += Certificate_do.GetParentsStrLoop(obj, obj, lobj.attr.pid, sType) + lobj.data;
            }
    }
    return tStr;
}
TCertificate_do.prototype.GetParentsStrLoop = function(obj, lobj, val, sType){
    var tStr = '';
    if (obj && lobj && val) {
        if (lobj.attr.rel == 'root') {
            if (lobj.children) {
                for (var j = 0; j < lobj.children.length; j++) {
                    if (lobj.children[j].attr.value == val) {
                        tStr = Certificate_do.GetParentsStrLoop(obj, obj, lobj.children[j].attr.pid, sType) + lobj.children[j].data + '\\' + tStr;
                    }
                    else {
                        tStr = Certificate_do.GetParentsStrLoop(obj, lobj.children[j], val, sType) + tStr;
                    }
                }
            }
        }
    }
    return tStr;
}
TCertificate_do.prototype.GetParentsStrChildren = function(obj, val){
    var tStr = '';
    if (obj && val) {
        for (var i = 0; i < obj.length; i++) {
            if (obj[i].attr.value == val) {
                tStr += this.GetParentsStrChildren(obj[i].children, obj[i].attr.pid) + '>' + obj[i].data;
            }
            else {
                tStr += this.GetParentsStrChildren(obj[i].children, val);
            }
        }
    }
    return tStr;
}
//鼠标树外事件
TCertificate_do.prototype.TreeOut = function(oEvent){

}
//删除项
TCertificate_do.prototype.DelT = function(did){
    if (!this.IsSelectData) {
        $('#tr_' + did).remove();
        Certificate_do.SumT();
    }
    else {
        jAlert('不能删除原数据!', '提示');
    }
}
//合计金额
TCertificate_do.prototype.SumT = function(){
    var tM = 0;
    var tMB = 0;
    var tr = $('#dloop').children('tr');
    var tId = '';
    if (tr) {
        if (tr.length > 0) {
            for (var i = 0; i < tr.length; i++) {
                tId = $(tr[i]).attr('id').replace('tr_', '');
                tM += Number($('#cdMoney_' + tId).val());
                tMB += Number($('#cdMoneyB_' + tId).val());
            }
        }
    }
    $('#SumMoneyA').html(Number(tM).toFixed(2));
    $('#SumMoneyB').html(Number(tMB).toFixed(2));
    tM = null;
    tMB = null;
    tr = null;
    tId = null;
}
//整理数据并返回
TCertificate_do.prototype.GetTDataJson = function(){
    var tr = $('#dloop').children('tr');
    var tId = '';
    var tJson = '';
    var cMoney = 0;
    var tSumMoney = 0;
    var tSumMoneyB = 0;
    var IsError = false;
    if (tr) {
        if (tr.length > 0) {
            for (var i = 0; i < tr.length; i++) {
                tId = $(tr[i]).attr('id').replace('tr_', '');
                if (Number($('#FeesSubjectID_' + tId).val()) > 0) {
                    tSumMoney += Number($('#cdMoney_' + tId).val());
                    tSumMoneyB += Number($('#cdMoneyB_' + tId).val());
                    tJson += '{"CertificateDataID":"' + $(tr[i]).attr('CertificateDataID') + '",' +
                    '"CertificateID":"' +
                    $(tr[i]).attr('CertificateID') +
                    '",' +
                    '"FeesSubjectName":"","FeesSubjectID":"' +
                    $('#FeesSubjectID_' + tId).val() +
                    '",' +
                    '"cdName":"' +
                    $('#cdName_' + tId).val() +
                    '",' +
                    '"cdMoney":"' +
                    $('#cdMoney_' + tId).val() +
                    '",' +
                    '"cdMoneyB":"' +
                    $('#cdMoneyB_' + tId).val() +
                    '",' +
                    '"cdRemake":"","cdAppendTime":"\/Date(1292334925660+0800)\/",' +
                    '"toObject":"' +
                    $('#toObjectType_' + tId).val() +
                    '","toObjectID":"' +
                    $('#toObjectID_' + tId).val() +
                    '"' +
                    '},'
                    cMoney += Number($('#cdMoney_' + tId).val());
                }
            }
            if (tSumMoney.toFixed(2) == tSumMoneyB.toFixed(2)) {
                if (tJson != '') {
                    tJson = '{"CertificateDataInfoJson":[' + tJson.substring(0, tJson.length - 1) + ']}';
                }
            }
            else {
                //tJson = '';
                IsError = true;
                jAlert('借方:' + tSumMoney + ',贷方:' + tSumMoneyB + ',借贷方金额应该相等,请正确录入!', '提示');
            }
        }
    }
    $('#cMoney').val(cMoney);
    if (!IsError) {
        if (tJson != '') {
            return tJson;
        }
        else {
            jAlert('请添加摘要!', '提示');
            return false;
        }
    }
    else {
        return false;
    }
    
    cMoney = null;
    tr = null;
    tId = null;
    tJson = null;
}
//单位
TCertificate_do.prototype.ShowcObjectBox = function(sObj){
    if (sObj) {
        this.cObj = $(sObj);
        this.PageBox = dialog("选择单位", "iframe:dataclass_box.aspx?Act=cObj", "450px", "350px", "iframe");
    }
}
TCertificate_do.prototype.ShowcObjectBox_ReCall = function(sID, sType, sName){
    if (this.cObj) {
        var tID = this.cObj.attr('id').replace('toObjectName_', '');
        this.cObj.val(sName);
        $('#toObjectID_' + tID).val(sID);
        $('#toObjectType_' + tID).val(sType);
        
        //this.cObj.val(this.GetParentsStr(this.tObjJson,sID,sType));
    }
    $("#ToObjectTreeBox").hide();
}
//科目
TCertificate_do.prototype.ShowFeesSubjectBox = function(sObj){
    if (sObj) {
        this.sObj = $(sObj);
        this.PageBox = dialog("选择科目", "iframe:dataclass_box.aspx?Act=sObj", "450px", "350px", "iframe");
    }
}
TCertificate_do.prototype.ShowFeesSubjectBox_ReCall = function(sID, sName){
    if (this.sObj) {
        var tID = this.sObj.attr('id').replace('FeesSubjectName_', '');
        this.sObj.val(sName);
        $('#FeesSubjectID_' + tID).val(sID);
        
        this.sObj.val(this.GetParentsStr(this.FeesSubjectJson.data[0], this.FeesSubjectJson.data[0], sID, 0));
    }
    $("#FeesSubjectTreeBox").hide();
}
TCertificate_do.prototype.AddPic = function(pid){
    this.picStr += pid + ',';
    var _dthtml = '<li><img pid="' + pid + '" src="/cimg-' + pid + '.aspx" style="width:98%" onClick="javascript:window.open(\'/cimg-' + pid + '.aspx\');"/></li>';
    
    jQuery(_dthtml).appendTo($('#PicList'));
    
}
TCertificate_do.prototype.HidUserBox = function(){
    CloseBox();
}
//取当前凭证前后凭证编号
TCertificate_do.prototype.GetUpDownID = function(){
    $.getJSON('/certificate_do_p-' + this.CertificateID + '.aspx?format=json', function(data){
        if (data.results.state == 'True') {
            if (data.results.UpDownID) {
                Certificate_do.UpID = Number(data.results.UpDownID.UpID);
                Certificate_do.DownID = Number(data.results.UpDownID.DownID);
                if (Certificate_do.UpID > 0) {
                    $('#subbutton_up').click(function(){
                        location.href = '/certificate_do-Edit-' + Certificate_do.UpID + '.aspx';
                    });
                }
                else {
                    $('#subbutton_up').hide();
                }
                if (Certificate_do.DownID > 0) {
                    $('#subbutton_down').click(function(){
                        location.href = '/certificate_do-Edit-' + Certificate_do.DownID + '.aspx';
                    });
                }
                else {
                    $('#subbutton_down').hide();
                }
            }
        }
        else {
            jAlert(data.results.msg, '提示');
        }
    });
}
function CheckNumber(obj){
    var t = obj.val();
    if (/^[-\+]?\d+(\.\d+)?$/.test(t)) {
    
    }
    else 
        if (t.substr(t.length - 1) == '.') {
        
        }
        else {
        
            obj.val(0);
        }
}

function toDate(str){
    var m = str.substring(5, str.lastIndexOf("-"));
    var d = str.substring(str.length, str.lastIndexOf("-") + 1);
    var y = str.substring(0, str.indexOf("-"));
    return Date.parse(m + "/" + d + "/" + y);
}

