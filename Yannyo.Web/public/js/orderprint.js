try
{
	var printer = false;
	
	var LODOP;
	try{
			LODOP=getLodop(document.getElementById('LODOP'),document.getElementById('LODOP_EM'));
			if ((LODOP!=null)&&(typeof(LODOP.VERSION)!="undefined")) printer=true;
	 }catch(e){
			printer = false;
	 }
	
	if(printer)
	{
		/*
		try {
			LODOP.PRINT_INIT("单据打印");
			LODOP.SET_PRINT_PAGESIZE(3, "21.5cm", "0", "");
			LODOP.SET_PRINT_STYLE("FontSize",12);
			//LODOP.SET_PRINT_STYLE("Bold",1);
			//LODOP.ADD_PRINT_TEXT(50,231,260,39,"打印页面部分内容");
			//LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", $('body').html());
			LODOP.ADD_PRINT_URL(0, 0, "100%", "100%",location);
			LODOP.PREVIEW();
			//LODOP.PRINT_DESIGN ()
		}catch(e){
			alert(e);			
		}
		*/
	}
	else
	{
		if(wb)
		{
			wb.execwb(7,1); 
			window.close();
		}
		else
		{
			try{
				window.print();
				/*
				$("div.print_box").printArea({
					mode: "popup",
					popClose: true
				});*/
			}catch(e){
				alert(e+"打印控件启动失败,请查看帮助!");
				window.open("help_print.html","_blank");
			}
		}
	}
}catch(e){
	try{
		window.print();
				/*
				$("div.print_box").printArea({
					mode: "popup",
					popClose: true
				});*/
	}catch(e){
		alert(e+"打印控件启动失败,请查看帮助!");
		window.open("help_print.html","_blank");
	}
}

