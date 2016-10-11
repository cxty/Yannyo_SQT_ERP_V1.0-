
function TDataAnalysis_tvalue()
{
	this.pageform = null;
}
TDataAnalysis_tvalue.prototype.ini = function()
{
	this.pageform = document.getElementById('bForm');
	
}
TDataAnalysis_tvalue.prototype.ReValue = function()
{
	var tValue = new Array();
    for(var i=0 ;i<this.pageform.elements.length;i++){ 
        if(this.pageform.elements[i].name=="tValue"){ 
            e=this.pageform.elements[i];
            if(e.checked == true)
            {
				tValue.push(new Array(e.value,e.alt));
            }
        }
    }
	window.parent.ReValue(tValue);
}