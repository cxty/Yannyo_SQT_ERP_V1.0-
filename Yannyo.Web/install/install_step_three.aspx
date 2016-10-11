<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="install_step_three.aspx.cs" Inherits="Yannyo.Web.install_step_three" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>燕游商企通安装向导(三)</title>
    <link rel="stylesheet" href="/install/css/install.css" />
    <script type='text/javascript' src='/install/javascript/jquery-1.4.4.min.js'></script>
    <script type='text/javascript' src='/install/javascript/crypto-md5.js'></script>
</head>
<body>
    <form id="form1" runat="server">
       <div class="container">
	    <div class="head"><img src="/install/images/logo.gif" width="354" height="53" alt="燕游商企通安装向导" /></div>
	    <div class="ins_box clearfix">
		    <div class="cont clearfix">
			    <ul class="step">
				    <li id="step_1"></li>
				    <li id="step_2"></li>
				    <li id="step_3" class="current"></li>
				    <li id="step_4"></li>
			    </ul>

			    <form action='install_step_three.aspx' method='post' target="install_iframe" onsubmit="return check_form();">
				    <div class="log_box">
					    <h2><img src="/install/images/guide_3.gif" width="82" height="15" /></h2>

					    <div class="red_box" style='display:none' id='error_div'>
						    <img src="/install/images/error.gif" width="16" height="15" />
						    安装发生错误：请联系管理员<label></label>
					    </div>

					    <div class="gray_box">
						    <div class="box">
							    <table class="form_table">
								    <col width="135px" />
								    <col />
								    <tr>
									    <th>数据库地址</th><td><input class="gray" type="text" id="db_address" name='db_address'/><br /><label class="error" id='db_baseAdress_label' style='display:none'><img src="/install/images/failed.gif" width="16" height="15" />请填写正确的数据库地址</label></td>
								    </tr>
								    <tr>
									    <th>数据库名称</th><td><input class="gray" type="text" id="db_name" name='db_name' /><br /><label class="error" id='db_name_label' style='display:none'><img src="/install/images/failed.gif" width="16" height="15" />请填写正确的数据库名称</label></td>
								    </tr>
								    <tr>
									    <th>账户</th><td><input class="gray" type="text" id="db_user" name='db_user' /><br /><label class="error" id='db_baseName_label' style='display:none'><img src="/install/images/failed.gif" width="16" height="15" />请填写正确的数据库账户</label></td>
								    </tr>
								    <tr>
									    <th>密码</th><td><input class="gray" type="password" id="db_pwd" name='db_pwd' /><br /><label class="error" id='db_basePwd_label' style='display:none'><img src="/install/images/failed.gif" width="16" height="15" />请填写正确的数据库密码</label></td>
								    </tr>
								    <tr>
									    <th>数据库表前缀</th>
									    <td><input class="gray" type="text"  name='db_pre' /><br /><label class="error" id='db_pre_label' style='display:none'><img src="/install/images/failed.gif" width="16" height="15" />请填写正确的表前缀字符（请留空）</label></td>
								    </tr>
								    <tr>
									    <th></th><td><input class="check" type="button" onclick="check_mysql();" style="cursor:pointer"/></td>
								    </tr>
							    </table>

							    <p id='right_p' style='display:none'><img src="/install/images/right.gif" width="19" height="18" />数据库连接正确</p>
							    <p id='error_p' style='display:none'><img src="/install/images/failed.gif" width="16" height="16" />数据库连接不正确</p>
                                <p id='connection' style='display:none'><img src="/install/images/jiaz.gif" width="100" height="16" />连接检测中...</p>
							    <hr />

							    <table class="form_table">
								    <col width="135px" />
								    <col />
								    <tr>
									    <th>管理员账户</th>
									    <td>
										    <input class="gray" type="text" id="admin_user" name='admin_user' value='admin' /><br />
										    <label class="error" id='admin_user_label' style='display:none'><img src="/install/images/failed.gif" width="16" height="15" />管理员账户不正确，字符在4-12个之间</label>
									    </td>
								    </tr>
								    <tr>
									    <th>密码</th>
									    <td>
										    <input class="gray" type="password" id="admin_pwd" name='admin_pwd' /><br />
										    <label class="error" id='admin_pwd_label' style='display:none'><img src="/install/images/failed.gif" width="16" height="15" />密码格式不正确，字符在6-16个之间</label>
									    </td>
								    </tr>
								    <tr>
									    <th>再次确认</th>
									    <td>
										    <input class="gray" type="password" id="admin_repwd" name='admin_repwd' /><br />
										    <label class="error" id='admin_repwd_label' style='display:none'><img src="/install/images/failed.gif" width="16" height="15" />二次密码输入的不一致</label>
									    </td>
								    </tr>
							    </table>
							    <hr />
                                <table class="form_table">
								    <col width="135px" />
								    <col />
								    <tr>
									    <th>企业名称</th>
									    <td>
										    <input class="gray" type="text" id="comName" name='comName'/><br />
									    </td>
								    </tr>
								    <tr>
									    <th>注册号</th>
									    <td>
										    <input class="gray" type="text" id="comID" name='comID' /><br />
									    </td>
								    </tr>
								    <tr>
									    <th>联系地址</th>
									    <td>
										    <input class="gray" type="text" id="comAddress" name='comAddress' /><br />
									    </td>
								    </tr>
                                     <tr>
									    <th>联系电话</th>
									    <td>
										    <input class="gray" type="text" id="comTel" name='comTel' /><br />
									    </td>
								    </tr>
                                  </table>
                                  <hr />
                                  <table class="form_table">
                                    <tr>
									    <th>初始订单号</th>
									    <td>
										    <input class="gray" type="text" id="orderNum" name='orderNum' /><br />
                                            <label class="error" id='orderNumT' style='display:none'><img src="/install/images/failed.gif" width="16" height="15" />长度小于12位</label>
									    </td>
								    </tr>
                                    <tr>
									    <th>初始供应商号</th>
									    <td>
										    <input class="gray" type="text" id="cumNum" name='cumNum' /><br />
                                            <label class="error" id='cumNumT' style='display:none'><img src="/install/images/failed.gif" width="16" height="15" />长度小于12位</label>
									    </td>
								    </tr>
                                    <tr>
									    <th>初始对账单号</th>
									    <td>
										    <input class="gray" type="text" id="ordNum" name='ordNum' /><br />
                                            <label class="error" id='ordNumT' style='display:none'><img src="/install/images/failed.gif" width="16" height="15" />长度小于12位</label>
									    </td>
								    </tr>
                                     <tr>
									    <th>凭证号长度</th>
									    <td>
										    <input class="gray" type="text" id="pzLen" name='pzLen' /><br />
                                            <label class="error" id='pzLenT' style='display:none'><img src="/install/images/failed.gif" width="16" height="15" />系统自动在凭证号前用"0"补齐</label>
									    </td>
								    </tr>
                                     <tr>
									    <th>金额小数保留位数</th>
									    <td>
										    <input class="gray" type="text" id="MonNum" name='MonNum' /><br />
									    </td>
								    </tr>
                                      <tr>
									    <th>数量小数保留位数</th>
									    <td>
										    <input class="gray" type="text" id="CounNum" name='CounNum' /><br />
									    </td>
								    </tr>
                                      <tr>
									    <th>单据打印宽度(cm)</th>
									    <td>
										    <input class="gray" type="text" id="oListWidth" name='oListWidth' /><br />
									    </td>
								    </tr>
                                     <tr>
									    <th>凭证打印宽度(cm)</th>
									    <td>
										    <input class="gray" type="text" id="pzWidth" name='pzWidth' /><br />
									    </td>
								    </tr>
                                     <tr>
									    <th>凭证打印行数</th>
									    <td>
										    <input class="gray" type="text" id="pzRow" name='pzRow' /><br />
									    </td>
								    </tr>
                                       <tr>
									    <th>随附单打印宽度(cm)</th>
									    <td>
										    <input class="gray" type="text" id="sOListWidth" name='sOListWidth' /><br />
									    </td>
								    </tr>
                                    <tr>
									    <th>随附单打印行数</th>
									    <td>
										    <input class="gray" type="text" id="sOrderRow" name='sOrderRow' /><br />
									    </td>
								    </tr>
							    </table>

							    <strong>安装选择</strong>
							    <label for=""><input class="radio" type="radio" name='install_type' value='all'/>安装完整：安装所有模块，并安装体验数据</label><br />
							    <label for=""><input class="radio" type="radio" name='install_type' checked="checked" value='simple' />简单安装：只安装系统程序</label>

							    <hr />

							    <div id='install_state' style='display:none'>
								    <strong>安装进度</strong>
								    <label>正在安装,请稍后...</label>
								    <div class="loading"><span style="width:0px;"></span><img src="/install/images/jiaz.gif" style='width:500px;height:20px' /></div>
							    </div>
                                <div id="install_fal" style="display:none"><img src="/install/images/failed.gif" width="16" height="15" /><b>安装失败，请联系管理员</b></label></div>
						    </div>
					    </div>
				    </div>
				    <p class="operate"><input class="return" type="button" onclick="window.location.href = 'install_step_two.aspx';" /><input class="next"  type="button" value='' onclick="javascript:next_step()" /></p>
			    </form>
		    </div>
		    <span class="l"></span><span class="r"></span><span class="b_l"></span><span class="b_r"></span>
	    </div>
	    <div class="foot"><a href="http://www.yannyo.com">关于我们</a>|<a href="http://www.yannyo.com">官方网站</a>|<a href="http://www.yannyo.com">联系我们</a>|<a href="">©2006-2011</a></div>
    </div>

    <iframe name='install_iframe' style='width:0px;height:0px;display:none' src='#'></iframe>
    </form>
</body>
<script type='text/javascript'>
    $(document).ready(function () {
        $("#orderNum").focus(function () {
            $("#orderNumT").show();
        });
        $("#orderNum").focusout(function () {
            $("#orderNumT").hide();
        });
        $("#cumNum").focus(function () {
            $("#cumNumT").show();
        });
        $("#cumNum").focusout(function () {
            $("#cumNumT").hide();
        });
        $("#ordNum").focus(function () {
            $("#ordNumT").show();
        });
        $("#ordNum").focusout(function () {
            $("#ordNumT").hide();
        });
        $("#pzLen").focus(function () {
            $("#pzLenT").show();
        });
        $("#pzLen").focusout(function () {
            $("#pzLenT").hide();
        });
    });
    var re_value = "";//获取检查数据库连接返回值
    //更新进度条
    function update_progress(obj) {
        var whole = $('#install_state img').css('width');
        var nowProgress = obj.percent ? parseInt(whole) * parseFloat(obj.percent) : 0;

        if (obj.isError == true) {
            $('#error_div').show();
            $('#error_div label').html(obj.message);
            $('#install_state label').addClass('red_box');
            $('.next').attr('disabled', '');
        }
        else {
            $('#install_state label').removeClass('red_box');
        }

        $('#install_state label').html(obj.message);
        $('#install_state .loading span').css('width', nowProgress);
    }

    //检查表单信息
    function check_form() {
        if ($("#db_address").val() == '') {
            $("#db_baseAdress_label").show();
        }
        else {
            $("#db_baseAdress_label").hide();
            if ($("#db_name").val() == '') {
                $("#db_name_label").show();
            }
            else {
                $("#db_name_label").hide();
                if ($("#db_user").val() == '') {
                    $("#db_baseName_label").show();
                }
                else {
                    $("#db_baseName_label").hide();
                    if ($("#db_pwd").val() == '') {
                        $("#db_basePwd_label").show();
                    }
                    else {
                        $("#db_basePwd_label").hide();
                    }
                }
            }
        }
    }
    //检查mysql链接
    function check_mysql() {
        $('#error_p').hide();
        $('#right_p').hide();
        //获取ajax检查mysql链接的所需数据
        var sendData = { 'db_address': '', 'db_name':'','db_user': '', 'db_pwd': ''};
        for (val in sendData) {
            sendData[val] = $('[name="' + val + '"]').val();
        }
        if (sendData.db_address == '' || sendData.db_name == '' || sendData.db_user == '' || sendData.db_pwd == '') {
            check_form();
        }
        else {
            check_form();
            $('#connection').show();
            $.post('install_step_three.aspx?act=check_sql&databaseAdress=' + sendData.db_address + '&databaseName=' + sendData.db_name + '&accountName=' + sendData.db_user + '&accountPwd=' + sendData.db_pwd, function (content) {
                re_value = content;
                if (content == 1) {
                    $('#connection').hide();
                    $('#right_p').show();
                    $('#error_p').hide();
                }
                else {
                    $('#connection').hide();
                    $('#right_p').hide();
                    $('#error_p').show();
                }
            });
        }
    }
    function next_step() {
        if (re_value == 1) {
            //获取ajax检查mysql链接的所需数据
            var sendData = { 'db_address': '', 'db_name': '', 'db_user': '', 'db_pwd': '', 'db_pre': '' };
            for (val in sendData) {
                sendData[val] = $('[name="' + val + '"]').val();
            }
            if ($("#admin_user").val() == '') {
                $("#admin_user_label").show();
            }
            else {
                $("#admin_user_label").hide();
                if ($("#admin_pwd").val() == '') {
                    $("#admin_pwd_label").show();
                }
                else {
                    $("#admin_pwd_label").hide();
                    if ($("#admin_pwd").val() != $("#admin_repwd").val()) {
                        $("#admin_repwd_label").show();
                    }
                    else {
                        $("#admin_repwd_label").hide();
                        $("#install_fal").hide();
                        $('#install_state').show();
                        $.post('install_step_three.aspx?act=write_sql&databaseAdress=' + sendData.db_address + '&databaseName=' + sendData.db_name + '&accountName=' + sendData.db_user + '&accountPwd=' + sendData.db_pwd + '&prefix=' + sendData.db_pre, function (data) {
                            if (Number(data) > 0) {
                                window.location.href = 'install_step_four.aspx?Act=install_four&adminName=' + $("#admin_user").val() + '&adminPwd=' + hex_md5($("#admin_repwd").val()) + '&comName=' + $("#comName").val() + '&comID=' + $("#comID").val() + '&comAddress=' + $("#comAddress").val() + '&comTel=' + $("#comTel").val() + '&orderNum=' + $("#orderNum").val() + '&cumNum=' + $("#cumNum").val() + '&ordNum=' + $("#ordNum").val() + '&pzLen=' + $("#pzLen").val() + '&MonNum=' + $("#MonNum").val() + '&CounNum=' + $("#CounNum").val() + '&oListWidth=' + $("#oListWidth").val() + '&pzWidth=' + $("#pzWidth").val() + '&pzRow=' + $("#pzRow").val() + '&sOListWidth=' + $("#sOListWidth").val() + '&sOrderRow=' + $("#sOrderRow").val();
                            }
                            else {
                                $("#error_div").show();
                                $('#install_state').hide();
                            }
                        });
                    }
                }
            }
        }
        else {
            $('#error_p').show();
            return false;
        }
    }

</script>

</html>
