
$('#button_Sub').click(function(){
	//$('#bForm').submit();
});
function CheckF(QUANTITY)
{
	var tForm = Sys.getObj('bForm');
	var isOK = Sys.getObj('isOK');
	var isBad = Sys.getObj('isBad');
	
	if(isOK.value == ''){isOK.value=0;}
	if(isBad.value == ''){isBad.value=0;}

	if((Number(isOK.value)+Number(isBad.value))!=QUANTITY)
	{
		alert("可用与不可用库存总和因等于总库存,请调整.");
	}
	else
	{
		tForm.submit();
	}
}
//SumValue=总数,sObj=当前对象,tObj=操作对象
function AutoValue(SumValue,sObj,tObj)
{
	if(sObj && tObj)
	{
		var sValue = Number(sObj.value);
		tObj.value = SumValue-sValue;
	}
}