//爱心点赞+1
function AddHeart1(){
	document.getElementById("emheart1").style.visibility="hidden";
	document.getElementById("heart1").style.visibility="visible";
	var str=document.getElementById("lab1");
	var temp=Number(str.innerHTML);
	temp=temp+1;
	str.innerHTML=temp.toString();
}
function AddHeart2(){
	document.getElementById("emheart2").style.visibility="hidden";
	document.getElementById("heart2").style.visibility="visible";
	var str=document.getElementById("lab2");
	var temp=Number(str.innerHTML);
	temp=temp+1;
	str.innerHTML=temp.toString();
}
function AddHeart3(){
	document.getElementById("emheart3").style.visibility="hidden";
	document.getElementById("heart3").style.visibility="visible";
	var str=document.getElementById("lab3");
	var temp=Number(str.innerHTML);
	temp=temp+1;
	str.innerHTML=temp.toString();
}
function AddHeart4(){
	document.getElementById("emheart4").style.visibility="hidden";
	document.getElementById("heart4").style.visibility="visible";
	var str=document.getElementById("lab4");
	var temp=Number(str.innerHTML);
	temp=temp+1;
	str.innerHTML=temp.toString();
}


//爱心点赞-1
function SubHeart1(){
	document.getElementById("emheart1").style.visibility="visible";
	document.getElementById("heart1").style.visibility="hidden";
	var str=document.getElementById("lab1");
	var temp=Number(str.innerHTML);
	if(temp>=1){
		temp=temp-1;
	    str.innerHTML=temp.toString();
	}
}
function SubHeart2(){
	document.getElementById("emheart2").style.visibility="visible";
	document.getElementById("heart2").style.visibility="hidden";
	var str=document.getElementById("lab2");
	var temp=Number(str.innerHTML);
	if(temp>=1){
		temp=temp-1;
	    str.innerHTML=temp.toString();
	}	
}
function SubHeart3(){
	document.getElementById("emheart3").style.visibility="visible";
	document.getElementById("heart3").style.visibility="hidden";
	var str=document.getElementById("lab3");
	var temp=Number(str.innerHTML);
	if(temp>=1){
		temp=temp-1;
	    str.innerHTML=temp.toString();
	}
}
function SubHeart4(){
	document.getElementById("emheart4").style.visibility="visible";
	document.getElementById("heart4").style.visibility="hidden";
	var str=document.getElementById("lab4");
	var temp=Number(str.innerHTML);
	if(temp>=1){
		temp=temp-1;
	    str.innerHTML=temp.toString();
	}
}

function context(){
	document.getElementById("textarea1").readOnly="readonly";
	document.getElementById("textarea2").readOnly="readonly"
	document.getElementById("textarea3").readOnly="readonly"
	document.getElementById("textarea4").readOnly="readonly"
}
