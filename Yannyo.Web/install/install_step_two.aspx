<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="install_step_two.aspx.cs" Inherits="Yannyo.Web.Install_StepTwo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>燕游商企通安装向导(二)</title>
    <link rel="stylesheet" href="/install/css/install.css" />
    <script language="javascript" type="text/javascript" src="/public/js/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="container">
	<div class="head"><img src="/install/images/logo.gif" width="354" height="53" alt="燕游商企通安装向导" /></div>
	<div class="ins_box clearfix">
		<div class="cont clearfix">
			<ul class="step">
				<li id="step_1"></li>
				<li id="step_2" class="current"></li>
				<li id="step_3"></li>
				<li id="step_4"></li>
			</ul>
			<div class="log_box">
				<h2><img src="/install/images/guide_2.gif" width="112" height="15" /></h2>

				<div class="green_box" style='display:none' id='right_div'>
					<img src="/install/images/right.gif" width="19" height="18" />
					您的系统配置是有效的，单击下一步继续！
				</div>

				<div class="red_box" style='display:none' id='error_div'>
					<img src="/install/images/error.gif" width="16" height="15" />
					您的系统配置不具备安装燕游商企通软件，有疑问可以访问：<a href='http://tech.yannyo.com/bbs/' target='_blank'>http://tech.yannyo.com/bbs/</a>
				</div>

				<div class="gray_box">
					<div class="box">
						<strong>版本及环境设置</strong>
						<p><img alt="" id="aq" src="/install/images/success.gif" width="16" height="16" />服务器IP：<label id="getIp"></label></p>
                        <p><img alt="" id="bq" src="/install/images/success.gif" width="16" height="16" />服务器域名：<label id="getDomain"></label></p>
                        <p><img alt="" id="cq" src="/install/images/success.gif" width="16" height="16" />服务器端口：<label id="getPort"></label></p>
                        <p><img alt="" id="dq" src="/install/images/success.gif" width="16" height="16" />服务器操作系统：<label id="getOperat"></label></p>
                        <p><img alt="" id="eq" src="/install/images/success.gif" width="16" height="16" />服务器虚拟内存：<label id="getMemory"></label></p>
                        <p><img alt="" id="fq" src="/install/images/success.gif" width="16" height="16" />服务器当前占有内存：<label id="getCpuMemory"></label></p>
						
                        <strong>文件可写权限</strong>
                        <p><img alt="" id="ffqi" src="/install/images/success.gif" width="16" height="16" />/Install：<label id="getInstall"></label></p>
						<p><img alt="" id="aaq" src="/install/images/success.gif" width="16" height="16" />/Cache：<label id="getCache"></label></p>
                        <p><img alt="" id="bbq" src="/install/images/success.gif" width="16" height="16" />/Config：<label id="getConfig"></label></p>
                        <p><img alt="" id="ccq" src="/install/images/success.gif" width="16" height="16" />/Data：<label id="getData"></label></p>
                        <p><img alt="" id="ddq" src="/install/images/success.gif" width="16" height="16" />/Data/ExportData：<label id="getExportData"></label></p>
                        <p><img alt="" id="eeq" src="/install/images/success.gif" width="16" height="16" />/Aspx/1：<label id="getDefault"></label></p>
                        <p><img alt="" id="ffq" src="/install/images/success.gif" width="16" height="16" />/Ufile：<label id="getUfile"></label></p>
                        <p><img alt="" id="ggq" src="/install/images/success.gif" width="16" height="16" />/Yannyo.config：<label id="getYannyo_Config"></label></p>
					</div>
				</div>

			</div>
			<p class="operate">
				<input class="return" type="button" onclick="window.location.href = 'install_step_one.aspx';" />
				<input class="next" type="button" onclick="javascript:check_config()"/>
			</p>
		</div>
		<span class="l"></span><span class="r"></span><span class="b_l"></span><span class="b_r"></span>
	</div>
	<div class="foot"><a href="http://www.yannyo.com">关于我们</a>|<a href="http://www.yannyo.com">官方网站</a>|<a href="http://www.yannyo.com">联系我们</a>|<a href="">©2006-2011</a></div>
</div>

    </form>
    <script type='text/javascript'>
        var ErrorNum = 0;
        var getCache = 0;
        var getConfig = 0;
        var getData = 0;
        var getExportData = 0;
        var getDefault = 0;
        var getUfile = 0;
        var getYannyoConfig = 0;

        $(window).load(function () {
            $.get('install_step_two.aspx?act=install', function (data) {
                var getJson = eval("(" + data + ")");
                ErrorNum = getJson.details.ErrorNum;
                //获得ip
                if (getJson.details.getIP != '') {
                    $("#getIp").html(getJson.details.getIP);
                }
                else {
                    $("#aq").removeAttr("src");
                    $("#aq").attr("src", "/install/images/failed.gif");
                    $("#getIp").html("未能正确获得IP地址");
                }
                //服务器域名
                if (getJson.details.getDomain != '') {
                    $("#getDomain").html(getJson.details.getDomain);
                }
                else {
                    $("#bq").removeAttr("src");
                    $("#bq").attr("src", "/install/images/failed.gif");
                    $("#getDomain").html("未能正确获得服务器域名");
                }
                //端口
                if (getJson.details.getPort != '') {
                    $("#getPort").html(getJson.details.getPort);
                }
                else {
                    $("#cq").removeAttr("src");
                    $("#cq").attr("src", "/install/images/failed.gif");
                    $("#getPort").html("未能正确获得服务器端口号");
                }
                //操作系统
                if (getJson.details.getOperat != '') {
                    $("#getOperat").html(getJson.details.getOperat);
                }
                else {
                    $("#dq").removeAttr("src");
                    $("#dq").attr("src", "/install/images/failed.gif");
                    $("#getOperat").html("未能正确获得服务器操作系统版本");
                }
                //虚拟内存
                if (getJson.details.getMemory != '') {
                    $("#getMemory").html(getJson.details.getMemory);
                }
                else {
                    $("#eq").removeAttr("src");
                    $("#eq").attr("src", "/install/images/failed.gif");
                    $("#getMemory").html("未能正确获得服务器虚拟内存");
                }
                //当前占有内存
                if (getJson.details.getCpuMemory != '') {
                    $("#getCpuMemory").html(getJson.details.getCpuMemory);
                }
                else {
                    $("#fq").removeAttr("src");
                    $("#fq").attr("src", "/install/images/failed.gif");
                    $("#getCpuMemory").html("未能正确获得服务器当前使用内存");
                }
                //cache
                if (getJson.details.cache == 1) {
                    $("#getCache").html("可写");
                }
                else {
                    $("#aaq").removeAttr("src");
                    $("#aaq").attr("src", "/install/images/failed.gif");
                    $("#getCache").html("权限不足");
                }
                //config
                if (getJson.details.config == 1) {
                    $("#getConfig").html("可写");
                }
                else {
                    $("#bbq").removeAttr("src");
                    $("#bbq").attr("src", "/install/images/failed.gif");
                    $("#getConfig").html("权限不足");
                }
                //data
                if (getJson.details.data == 1) {
                    $("#getData").html("可写");
                }
                else {
                    $("#ccq").removeAttr("src");
                    $("#ccq").attr("src", "/install/images/failed.gif");
                    $("#getData").html("权限不足");
                }
                //exportdata
                if (getJson.details.exportdata == 1) {
                    $("#getExportData").html("可写");
                }
                else {
                    $("#ddq").removeAttr("src");
                    $("#ddq").attr("src", "/install/images/failed.gif");
                    $("#getExportData").html("权限不足");
                }
                //default
                if (getJson.details.de == 1) {
                    $("#getDefault").html("可写");
                }
                else {
                    $("#eeq").removeAttr("src");
                    $("#eeq").attr("src", "/install/images/failed.gif");
                    $("#getDefault").html("权限不足");
                }
                //ufile
                if (getJson.details.ufile == 1) {
                    $("#getUfile").html("可写");
                }
                else {
                    $("#ffq").removeAttr("src");
                    $("#ffq").attr("src", "/install/images/failed.gif");
                    $("#getUfile").html("权限不足");
                }
                //install
                if (getJson.details.install == 1) {
                    $("#getInstall").html("可写");
                }
                else {
                    $("#ffqi").removeAttr("src");
                    $("#ffqi").attr("src", "/install/images/failed.gif");
                    $("#getInstall").html("权限不足");
                }
                //yannyoconfig
                if (getJson.details.yannyoconfig == 1) {
                    $("#getYannyo_Config").html("可写");
                }
                else {
                    $("#ggq").removeAttr("src");
                    $("#ggq").attr("src", "/install/images/failed.gif");
                    $("#getYannyo_Config").html("权限不足");
                }
                if (ErrorNum > 0) {
                    document.getElementById('error_div').style.display = '';
                }
                else {
                    document.getElementById('right_div').style.display = '';
                }
            });
        });
        //检查配置信息
        function check_config() {
            var error_num = ErrorNum;
            if (error_num > 0) {
                alert('您的系统环境配置没有通过检查');
            }
            else {
                window.location.href = 'install_step_three.aspx';
            }
        }
    </script>
</body>
</html>
