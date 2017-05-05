function edit(){
	//隐藏三个输入框
	document.getElementById("col3").style.visibility="hidden";
	document.getElementById("col4").style.visibility="hidden";
	document.getElementById("col5").style.visibility="hidden";
	//显示输入新密码输入框
	document.getElementById("col-add1").style.visibility="visible";
	document.getElementById("col-add2").style.visibility="visible";	
}

function confirm(){
	//重新显示
	document.getElementById("col3").style.visibility="visible";
	document.getElementById("col4").style.visibility="visible";
	document.getElementById("col5").style.visibility="visible";
	//隐藏新密码输入框
	document.getElementById("col-add1").style.visibility="hidden";
	document.getElementById("col-add2").style.visibility="hidden";	
}

//document.getElementById("input2").type="password";
