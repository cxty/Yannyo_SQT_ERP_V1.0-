/**
 * @author Cxty
 */
function TPublic_ProductTree()
{
	this.reobj = '';
}
TPublic_ProductTree.prototype.ini = function()
{
	
}
//回调父页面
TPublic_ProductTree.prototype.ReDate = function(reObj)
{
	parent.SetProductID(reObj,this.reobj);
}

 $(function () {
 $.ajaxSetup({cache:true});
 $("#ptTree").jstree({   

		 "json_data":{"ajax":{
			"url":"/Services/CAjax.aspx",
			"data" : function (n) {
							return { 
								"do" : "DataClass",
								"doValue" : "SelectTreeAndData",
								"DataType" : "ProductClass",
								"pid" : n.attr ? n.attr("id").replace("t_","") : -1 ,
								"orderType":parent.$('#hide_p').attr("checked") ? 1:0
							};
					}
		 }}, 
		 "core" : { 
				"initially_open" : [ "t_0" ]
			},

		"types" : {  
			 "valid_children" : [ "dt" ],  
			 "types" : {
				 "dt" : {
					 "icon" : { 
						"image" : "/images/dot.png" 
					},
					 "valid_children" : [ "default" ],
					 "max_depth" : 2,
					 "hover_node" : true,
					 "open_node":false,
					 "select_node" : true
				 },
				"root":{
					"valid_children" : [ "default" ],
					"hover_node" : false,
					"select_node" : function () {return false;}
				 }  
			 }  
		},  
		 "plugins" : [ "themes", "json_data", "ui", "crrm", "types","dnd", "hotkeys" ] 

	 }).bind("select_node.jstree", function (e,data) {
		Public_ProductTree.ReDate(jQuery.parseJSON('{"id":"'+data.rslt.obj.attr("id").replace('d_','')+'","name":"'+data.rslt.obj.children("a").text()+'"}'));
	 });

});