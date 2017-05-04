function myfunction(on) {
    on.style.backgroundColor = "#D1D1D1";
}
function myfunction1(out) {
    out.style.backgroundColor = "#722b72";
}
function myfunction2() {
    //This note is categoryed to Love Notes
}

//回看笔记功能变量
var txt1 = new Object();
var title1 = new Object();
var time1 = new Object();
var txt2 = new Object();
var title2 = new Object();
var time2 = new Object();
var txt3 = new Object();
var title3 = new Object();
var time3 = new Object();
var txt4 = new Object();
var title4 = new Object();
var time4 = new Object();
var txt5 = new Object();
var title5 = new Object();
var time5 = new Object();

//回收站变量
var tp1 = new Object();
var tp2 = new Object();
var tp3 = new Object();


//添加笔记
function myfunction3() {

    myfunction4()
    var time = new Date();
    var value = document.getElementById("lab1");
    value.innerHTML = "创建时间:" + time.toLocaleString();
    var value1 = document.getElementById("lab2");
    value1.innerHTML = "修改时间:" + time.toLocaleString();
    var temp1 = "标题在此输入";
    document.getElementById("TextBox1").value = temp1;
    var temp2 = "在此输入正文......"
    document.getElementById("TextBox2").value = temp2;
}


//保存笔记
function myfunction4() {
    var time = new Date();
    var value = document.getElementById("lab2");
    //获取标题和内容,如果有内容就放入下一个DIV

    if (document.getElementById("b1").value == null) {
        document.getElementById("cont1").style.height = "20%";

        var b1 = document.getElementById("b1");
        b1.innerHTML = document.getElementById("TextBox1").value;
        var b2 = document.getElementById("b2");
        b2.innerHTML = document.getElementById("TextBox2").value;
        var temp = b2.innerHTML.substring(0, 30) + "......";
        b2.innerHTML = temp;
        value.innerHTML = "修改时间:" + time.toLocaleString();
        document.getElementById("Label1").innerHTML = time.toLocaleString();
        document.getElementById("b1").value = 1;
        document.getElementById("b3").value = null;
        document.getElementById("b5").value = null;
        document.getElementById("b7").value = null;
        document.getElementById("cont1").style.borderBottomStyle = "groove";
        document.getElementById("cont1").style.borderBottomWidth = "3px";
        document.getElementById("bt1").style.visibility = "visible";

        title1.innerHTML = b1.innerHTML;
        txt1.innerHTML = document.getElementById("TextBox2").value;
        time1.innerHTML = document.getElementById("Label1").innerHTML;

    }
    else if (document.getElementById("b3").value == null) {
        document.getElementById("cont2").style.height = "20%";

        var b3 = document.getElementById("b3");
        b3.innerHTML = document.getElementById("TextBox1").value;
        var b4 = document.getElementById("b4");
        b4.innerHTML = document.getElementById("TextBox2").value;
        var temp = b4.innerHTML.substring(0, 30) + "......";
        b4.innerHTML = temp;
        value.innerHTML = "修改时间:" + time.toLocaleString();
        document.getElementById("Label2").innerHTML = time.toLocaleString();
        document.getElementById("b3").value = 1;
        document.getElementById("cont2").style.borderBottomStyle = "groove";
        document.getElementById("cont2").style.borderBottomWidth = "3px";
        document.getElementById("cont2").style.borderTopStyle = "groove";
        document.getElementById("cont2").style.borderTopWidth = "3px";
        document.getElementById("bt2").style.visibility = "visible";

        title2.innerHTML = b3.innerHTML;
        txt2.innerHTML = document.getElementById("TextBox2").value;
        time2.innerHTML = document.getElementById("Label2").innerHTML;
    }
    else if (document.getElementById("b5").value == null) {
        document.getElementById("cont3").style.height = "20%";

        var b5 = document.getElementById("b5");
        b5.innerHTML = document.getElementById("TextBox1").value;
        var b6 = document.getElementById("b6");
        b6.innerHTML = document.getElementById("TextBox2").value;
        var temp = b6.innerHTML.substring(0, 30) + "......";
        b6.innerHTML = temp;
        value.innerHTML = "修改时间:" + time.toLocaleString();
        document.getElementById("Label3").innerHTML = time.toLocaleString();
        document.getElementById("b5").value = 1;
        document.getElementById("cont3").style.borderBottomStyle = "groove";
        document.getElementById("cont3").style.borderBottomWidth = "3px";
        document.getElementById("cont3").style.borderTopStyle = "groove";
        document.getElementById("cont3").style.borderTopWidth = "3px";
        document.getElementById("bt3").style.visibility = "visible";

        title3.innerHTML = b5.innerHTML;
        txt3.innerHTML = document.getElementById("TextBox2").value;
        time3.innerHTML = document.getElementById("Label3").innerHTML;
    }
    else if (document.getElementById("b7").value == null) {
        document.getElementById("cont4").style.height = "20%";

        var b7 = document.getElementById("b7");
        b7.innerHTML = document.getElementById("TextBox1").value;
        var b8 = document.getElementById("b8");
        b8.innerHTML = document.getElementById("TextBox2").value;
        var temp = b8.innerHTML.substring(0, 30) + "......";
        b8.innerHTML = temp;
        value.innerHTML = "修改时间:" + time.toLocaleString();
        document.getElementById("Label4").innerHTML = time.toLocaleString();
        document.getElementById("b7").value = 1;
        document.getElementById("cont4").style.borderBottomStyle = "groove";
        document.getElementById("cont4").style.borderBottomWidth = "3px";
        document.getElementById("cont4").style.borderTopStyle = "groove";
        document.getElementById("cont4").style.borderTopWidth = "3px";
        document.getElementById("bt4").style.visibility = "visible";

        title4.innerHTML = b7.innerHTML;
        txt4.innerHTML = document.getElementById("TextBox2").value;
        time4.innerHTML = document.getElementById("Label4").innerHTML;
    }

    else if (document.getElementById("b9").value == null) {
        document.getElementById("cont5").style.height = "20%";

        var b9 = document.getElementById("b9");
        b9.innerHTML = document.getElementById("TextBox1").value;
        var b10 = document.getElementById("b10");
        b10.innerHTML = document.getElementById("TextBox2").value;
        var temp = b10.innerHTML.substring(0, 30) + "......";
        b10.innerHTML = temp;
        value.innerHTML = "修改时间:" + time.toLocaleString();
        document.getElementById("Label5").innerHTML = time.toLocaleString();
        document.getElementById("b9").value = 1;
        document.getElementById("cont5").style.borderBottomStyle = "groove";
        document.getElementById("cont5").style.borderBottomWidth = "3px";
        document.getElementById("cont5").style.borderTopStyle = "groove";
        document.getElementById("cont5").style.borderTopWidth = "3px";
        document.getElementById("bt5").style.visibility = "visible";

        title5.innerHTML = b9.innerHTML;
        txt5.innerHTML = document.getElementById("TextBox2").value;
        time5.innerHTML = document.getElementById("Label5").innerHTML;
    }
}

//删除笔记
function myfunction5() {
    if (document.getElementById("Label5").innerHTML == document.getElementById("lab2").innerHTML) {
        document.getElementById("b9").innerHTML = "";
        document.getElementById("b10").innerHTML = "";
        document.getElementById("Label5").innerHTML = "";
        var value = document.getElementById("lab1");
        value.innerHTML = "创建时间:";
        var value1 = document.getElementById("lab2");
        value1.innerHTML = "修改时间:";
        document.getElementById("b8").value = null;
        document.getElementById("cont5").style.borderBottom = "none";
        document.getElementById("cont5").style.borderTop = "none";
        document.getElementById("bt5").style.visibility = "hidden";

        document.getElementById("cont4").style.height = "0px";
    }
    else if (document.getElementById("Label4").innerHTML == document.getElementById("lab2").innerHTML) {
        document.getElementById("b7").innerHTML = "";
        document.getElementById("b8").innerHTML = "";
        document.getElementById("Label4").innerHTML = "";
        var value = document.getElementById("lab1");
        value.innerHTML = "创建时间:";
        var value1 = document.getElementById("lab2");
        value1.innerHTML = "修改时间:";
        document.getElementById("b7").value = null;
        document.getElementById("cont4").style.borderBottom = "none";
        document.getElementById("cont4").style.borderTop = "none";
        document.getElementById("bt4").style.visibility = "hidden";

        document.getElementById("cont4").style.height = "0px";
    }
    else if (document.getElementById("Label3").innerHTML == document.getElementById("lab2").innerHTML) {

        document.getElementById("b5").innerHTML = "";
        document.getElementById("b6").innerHTML = "";
        document.getElementById("Label3").innerHTML = "";
        document.getElementById("b5").value = null;
        var value = document.getElementById("lab1");
        value.innerHTML = "创建时间:";
        var value1 = document.getElementById("lab2");
        value1.innerHTML = "修改时间:";
        document.getElementById("cont3").style.borderBottom = "none";
        document.getElementById("cont3").style.borderTop = "none";
        document.getElementById("bt3").style.visibility = "hidden";

        document.getElementById("cont3").style.height = "0px";

    }
    else if (document.getElementById("Label2").innerHTML == document.getElementById("lab2").innerHTML) {
        document.getElementById("b3").innerHTML = "";
        document.getElementById("b4").innerHTML = "";
        document.getElementById("Label2").innerHTML = "";
        document.getElementById("b3").value = null;
        var value = document.getElementById("lab1");
        value.innerHTML = "创建时间:";
        var value1 = document.getElementById("lab2");
        value1.innerHTML = "修改时间:";
        document.getElementById("cont2").style.borderBottom = "none";
        document.getElementById("cont2").style.borderTop = "none";
        document.getElementById("bt2").style.visibility = "hidden";

        document.getElementById("cont2").style.height = "0px";

    }
    else if (document.getElementById("Label1").innerHTML == document.getElementById("lab2").innerHTML) {
        var tp1 = document.getElementById("TextBox1").value;
        var tp2 = document.getElementById("TextBox2").value;
        var tp3 = document.getElementById("Label4").innerText;
        document.getElementById("b1").innerHTML = "";
        document.getElementById("b2").innerHTML = "";
        document.getElementById("Label1").innerHTML = "";
        document.getElementById("b1").value = null;
        var value = document.getElementById("lab1");
        value.innerHTML = "创建时间:";
        var value1 = document.getElementById("lab2");
        value1.innerHTML = "修改时间:";
        document.getElementById("cont1").style.borderBottom = "none";
        document.getElementById("cont1").style.borderTop = "none";
        document.getElementById("bt1").style.visibility = "hidden";

        document.getElementById("cont1").style.height = "0px";

    }
    else if (document.getElementById("b1").value == null) {
        var value = document.getElementById("lab1");
        value.innerHTML = "创建时间:";
        var value1 = document.getElementById("lab2");
        value1.innerHTML = "修改时间:";
        var temp1 = "";
        document.getElementById("TextBox1").value = temp1;
        var temp2 = ""
        document.getElementById("TextBox2").value = temp2;

        document.getElementById("cont1").style.height = "0px";
    }
}

//增加附件
function myfunction6() {
    var v1 = document.getElementById("TextBox4");
    var v2 = document.getElementById("FileUpload1");
    v1.value = v2.value;
    var temp = v1.value.substring(12, 32);
    v1.value = "上传的附件为： " + temp;
    document.getElementById("sp1").style.color = "#72272b";
}

function myfunction7() {
    document.getElementById("sp1").style.color = "white";
    var file = document.getElementById("FileUpload1");
    file.outerHTML = file.outerHTML;
    setTimeout(function () { (document.getElementById("sp1").style.color = "#aaa") }, 3000);
    var temp2 = "";
    document.getElementById("TextBox4").value = "已撤销上传附件" + temp2
    setTimeout(function () { (document.getElementById("TextBox4").value = "") }, 3000);
}

function myfunction8() {
    var t1 = document.getElementById("TextBox1");
    if (t1.value == "") {
        var obj = document.getElementById("btn2");
        obj.disabled = true;
        var obj2 = document.getElementById("Button2");
        obj2.disabled = true;
    }
    else if (t1.value !== "") {
        var obj = document.getElementById("btn2");
        obj.disabled = false;
        var obj2 = document.getElementById("Button2");
        obj2.disabled = false;
    }
}

//回看笔记
function replay1() {
    document.getElementById("TextBox2").value = txt1.innerHTML;
    document.getElementById("TextBox1").value = title1.innerHTML;
    document.getElementById("lab2").innerHTML = time1.innerHTML;
    document.getElementById("lab1").innerHTML = "保存时间：";
}

function replay2() {
    document.getElementById("TextBox2").value = txt2.innerHTML;
    document.getElementById("TextBox1").value = title2.innerHTML;
    document.getElementById("lab2").innerHTML = time2.innerHTML;
    document.getElementById("lab1").innerHTML = "保存时间：";
}

function replay3() {
    document.getElementById("TextBox2").value = txt3.innerHTML;
    document.getElementById("TextBox1").value = title3.innerHTML;
    document.getElementById("lab2").innerHTML = time3.innerHTML;
    document.getElementById("lab1").innerHTML = "保存时间：";
}

function replay4() {
    document.getElementById("TextBox2").value = txt4.innerHTML;
    document.getElementById("TextBox1").value = title4.innerHTML;
    document.getElementById("lab2").innerHTML = time4.innerHTML;
    document.getElementById("lab1").innerHTML = "保存时间：";
}

function replay5() {
    document.getElementById("TextBox2").value = txt5.innerHTML;
    document.getElementById("TextBox1").value = title5.innerHTML;
    document.getElementById("lab2").innerHTML = time5.innerHTML;
    document.getElementById("lab1").innerHTML = "保存时间：";
}
//查看回收站
function gotobin() {
    var tp1 = document.getElementById("TextBox1").value;
    var tp2 = document.getElementById("TextBox2").value;
    if (document.getElementById("lab2").innerHTML = time1.innerHTML) {
        var tp3 = document.getElementById("lab2").innerText;
        location.href = 'http://localhost:1889/NoteBook/RecycleNote.html?title=' + tp1 + '&content=' + tp2 + '&time=' + tp3;

    }
    else if (document.getElementById("lab2").innerHTML = time2.innerHTML) {
        var tp3 = document.getElementById("lab2").innerText;
        location.href = 'http://localhost:1889/NoteBook/RecycleNote.html?title=' + tp1 + '&content=' + tp2 + '&time=' + tp3;
    }
    else if (document.getElementById("lab2").innerHTML = time3.innerHTML) {
        var tp3 = document.getElementById("lab2").innerText;
        location.href = 'http://localhost:1889/NoteBook/RecycleNote.html?title=' + tp1 + '&content=' + tp2 + '&time=' + tp3;
    }
    else if (document.getElementById("lab2").innerHTML = time4.innerHTML) {
        var tp3 = document.getElementById("lab2").innerText;
        location.href = '/NoteBook/RecycleNote.html?title=' + tp1 + '&content=' + tp2 + '&time=' + tp3;
    }
    else if (document.getElementById("lab2").innerHTML = time5.innerHTML) {
        var tp3 = document.getElementById("lab2").innerText;
        location.href = '/NoteBook/RecycleNote.html?title=' + tp1 + '&content=' + tp2 + '&time=' + tp3;
    }

}

//加入爱心笔记
function heart() {
    var tp1 = document.getElementById("TextBox1").value;
    var tp2 = document.getElementById("TextBox2").value;
    if (document.getElementById("lab2").innerHTML = time1.innerHTML) {
        var tp3 = document.getElementById("lab2").innerText;
        location.href = 'http://localhost:1889/NoteBook/RecycleNote.html?title=' + tp1 + '&content=' + tp2 + '&time=' + tp3;

    }
    else if (document.getElementById("lab2").innerHTML = time2.innerHTML) {
        var tp3 = document.getElementById("lab2").innerText;
        location.href = 'http://localhost:1889/NoteBook/RecycleNote.html?title=' + tp1 + '&content=' + tp2 + '&time=' + tp3;
    }
    else if (document.getElementById("lab2").innerHTML = time3.innerHTML) {
        var tp3 = document.getElementById("lab2").innerText;
        location.href = 'http://localhost:1889/NoteBook/RecycleNote.html?title=' + tp1 + '&content=' + tp2 + '&time=' + tp3;
    }
    else if (document.getElementById("lab2").innerHTML = time4.innerHTML) {
        var tp3 = document.getElementById("lab2").innerText;
        location.href = 'http://localhost:1889/NoteBook/RecycleNote.html?title=' + tp1 + '&content=' + tp2 + '&time=' + tp3;
    }
    else if (document.getElementById("lab2").innerHTML = time5.innerHTML) {
        var tp3 = document.getElementById("lab2").innerText;
        location.href = 'http://localhost:1889/NoteBook/RecycleNote.html?title=' + tp1 + '&content=' + tp2 + '&time=' + tp3;
    }
}


