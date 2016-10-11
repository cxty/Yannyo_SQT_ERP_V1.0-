<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="install_step_one.aspx.cs" Inherits="Yannyo.Web.install.Install_StepOne" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>燕游商企通安装向导(一)</title>
    <link rel="stylesheet" href="/install/css/install.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
	<div class="head"><img src="/install/images/logo.gif" width="354" height="53" alt="燕游商企通安装向导" /></div>
	<div class="ins_box clearfix">
		<div class="cont clearfix">
			<ul class="step">
				<li id="step_1" class="current"></li>
				<li id="step_2"></li>
				<li id="step_3"></li>
				<li id="step_4"></li>
			</ul>
			<div class="log_box">
				<h2><img src="/install/images/guide_1.gif" width="203" height="15" /></h2>

				<div class="red_box" style='display:none' id='error_div'>
					<img src="/install/images/error.gif" width="16" height="15" />
					请认真阅读并同意以上条款
				</div>

				<div class="gray_box">
					<div class="box" style="height:314px; overflow-y:auto">
                        <p>燕游商企通免费版授权协议 适用所有语种用户 版权所有 (c) 2011，燕游网络（www.yannyo.com）保留所有权利。</p>
						<p>
                        感谢您选择燕游网络系列软件产品。希望燕游商企通能为您的企业管理提供一个强大高效的平台解决方案。 
                        燕游商企通是燕游网络独立开发完成，全称为燕游中小商贸企业资源管理系统。燕游网络是燕游商企通软件产品的开发商，依法拥护燕游商企通的产品著作权。使用者：无论个人或组织机构、用途如何（包括以学习和研究为目的）、是否盈利，均须仔细阅读本授权协议，只有在理解、同意、并遵守本协议的相关条款的条件，方可开始安装并使用本软件。 
                        本授权协议适用且仅适用于燕游商企通v1.x.x版本，燕游网络拥有对本授权协议的最终解释权。
                        </p>
                        <p>I 协议许可的权利</p> 
                        <p>1.您可以在遵守本授权协议的基础上，将燕游商企通软件应用于企业内部,非其它专卖等商业用途。</p>
                        <p>2.您可以在协议规定的约束和限制范围内修改本软件的界面风格以适应您企业的要求。</p>
                        <p>3.您拥有使用本软件构建企业内部管理所产生的企业信息的所有权，并独立承担与文章内容的相关法律义务。</p>
                        <p>4. 获得燕游网络特许授权之后，您可以将本软件应用于商业用途。</p> 
                        <p>5. 特许授权用户享有反映和提出意见的权力，相关意见将被作为首要考虑，但没有一定被采纳的承诺或保证。</p> 
                        <p>II 协议规定的约束和限制</p>
                        <p>1. 不允许使用本软件的源码以及在本软件源码的基础进行修改后与衍生的代码一起做为闭源的商业软件或程序发布销售。</p>
                        <p>2. 未获特许授权之前，不得将本软件用于商业用途（包括但不限于企业网站、经营性网站、以营利为目或实现盈利的网站）。获得特许授权请登陆http://www.yannyo.com参考相关说明。</p>  
                        <p>3. 不得对本软件或与之关联的特许授权进行出租、出售、抵押或发放子许可证。</p>
                        <p>4. 禁止在燕游商企通的整体或任何部分基础上以发展任何派生版本、修改版本或第三方版本用于重新分发。</p>
                        <p>5. 无论如何，即无论用途如何、是否经过修改或美化、修改程度如何，只要使用燕游商企通的整体或部分，未经书面许可，系统页面页脚处的Powered by 燕游商企通 v x.x和燕游名称及其网站（http://www.yannyo.com）链接都必须保留，不能清除或修改。</p>
                        <p>6. 如果您未能遵守本协议的条款，您的授权将被终止，所被许可的权利将被收回，并承担相应法律责任。</p>
                        <p>III 有限担保和免责声明</p>
                        <p>1. 本软件及所附带的文件是作为不提供任何明确的或隐含的赔偿或担保的形式提供的。</p>
                        <p>2. 用户出于自愿而使用本软件，使用之前必须了解使用本软存在的风险，我们不承诺任何形式的使用担保，也不承担任何因使用本软件而产生问题的相关责任。</p>
                        <p>3. 我们不对使用本软件构建的站点中的文章或信息承担责任。</p>
                        
                        </div>
				</div>
				<p class="agree"><label><input type="checkbox" id='agree' /> 我同意上述条款和条件</label></p>
			</div>
			<p class="operate"><input class="next" type="button" onclick="check_license();" /></p>
		</div>
		<span class="l"></span><span class="r"></span><span class="b_l"></span><span class="b_r"></span>
	</div>
	<div class="foot"><a href="http://www.yannyo.com">关于我们</a>|<a href="http://www.yannyo.com">官方网站</a>|<a href="http://www.yannyo.com">联系我们</a>|<a href="">©2006-2011</a></div>
</div>
    </form>
    <script type='text/javascript'>
        //检查协议阅读状态
        function check_license() {
            var is_agree = document.getElementById('agree').checked;
            if (is_agree == true) {
                window.location.href = 'install_step_two.aspx';
            }
            else {
                document.getElementById('error_div').style.display = '';
            }
        }
    </script>
</body>
</html>
