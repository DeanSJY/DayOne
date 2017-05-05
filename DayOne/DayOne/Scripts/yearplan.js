
function Addplan()
{
	var time=new Date();
    var L1=document.getElementById("lab1");
    var L2=document.getElementById("lab2");
    var L3=document.getElementById("lab3");

	if(L1.innerHTML=="")
	{
		L1.innerHTML=time.toLocaleString();
	}
	else if(L2.innerHTML=="")
	{
		L2.innerHTML=time.toLocaleString();
	}
	else if(L3.innerHTML=="")
	{
		L3.innerHTML=time.toLocaleString();
	}
	else
	{
	//div
	var temp=document.getElementById("rs");　　
　　var div = document.createElement("div");  
    div.setAttribute('id','sm-div');
    div.style=document.getElementById("input1").style;   
    div.style.display="block";
　    temp.appendChild(div);

    //图标
    var sp=document.createElement("span");
    sp.className="glyphicon glyphicon-heart-empty";
    div.appendChild(sp);
    
    //输入框
    var inp=document.createElement("input");
    inp.style.width="700px";
    inp.style.height="30px";
    inp.style.marginTop="45px";
    inp.style.marginLeft="15px";
    inp.style.border="0px";
    inp.style.borderBottom="1px solid #330033";
    inp.placeholder="记录1年的计划 美好生活的开始";
    inp.style.fontSize="20px";
    inp.setAttribute('id','inp1');
    div.appendChild(inp);
    
    //时间label
    var lab=document.createElement("label");
    lab.style.marginLeft="8px";
    lab.style.fontSize="20px";
    lab.innerHTML=time.toLocaleString();
    div.appendChild(lab);
   }
}

function Removeplan(){
	var L1=document.getElementById("lab1");
    var L2=document.getElementById("lab2");
    var L3=document.getElementById("lab3");
	
	var temp=document.getElementById("rs");
	temp.removeChild(document.getElementById("sm-div"));
	if(!document.getElementById("inp1"))
	{		
		L3.innerHTML="";
	}
}

function day(){
	location.href="dayplan.html";
}

function month(){
	location.href="dayplan3.html";
}

function week(){
	location.href="dayplan4.html";
}
function sjy(){
	location.href="SJY.html";
}