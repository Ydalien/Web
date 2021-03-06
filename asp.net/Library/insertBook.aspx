﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="insertBook.aspx.cs" Inherits="insertBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<style type="text/css">
body {
	background-color: #3866c6;
	margin: 0px;
	padding: 0px;
}
#top {
	height: 60px;
	width: 100%;
	margin: 0px;
	padding: 0px;
	position: absolute;
	background-color: #2b2f32;
}
#top_loginout {
	position: absolute;
	height: 50px;
	width: 50px;
	bottom: 10%;
	right: 10%;
    background-image: url(/images/log-out.png);
    border: none;
	background-repeat: no-repeat;
	background-size:50px 50px;
	background-color:transparent
}

#main {
	margin: 0px;
	padding: 0px;
	width: 100%;
	height: 100%;
	position: absolute;
	bottom: auto;
	top: 60px;
}
#username {
	position: absolute;
	top: 15px;
	right: 15%;
	font-family : 微软雅黑;
	font-size : 20px;
	color : #fff;
}
#author {
	position: absolute;
	height: 150px;
	width: 215px;
	top: 23%;
	left: 4%;
	font-family: 幼圆;
	font-size: 50px;
	color: #fff;
	border: none;
	background-color:transparent;
}
#bookname {
	position: absolute;
	height: 150px;
	width: 215px;
	top: 4%;
	left: 4%;
	font-family: 幼圆;
	font-size: 50px;
	color: #fff;
	border: none;
	background-color:transparent;
}
#press {
	position: absolute;
	height: 150px;
	width: 215px;
	top: 42%;
	left: 3%;
	font-family: 幼圆;
	font-size: 50px;
	color: #fff;
	border: none;
	background-color:transparent;
}
#date {
	position: absolute;
	height: 150px;
	width: 215px;
	top: 63%;
	left: 0%;
	font-family: 幼圆;
	font-size: 50px;
	color: #fff;
	border: none;
	background-color:transparent;
}
#bookInfo {
	position: absolute;
	height: 150px;
	width: 215px;
	top: 83%;
	left: 0%;
	font-family: 幼圆;
	font-size: 50px;
	color: #fff;
	border: none;
	background-color:transparent;
}

#fenge {
	position: absolute;
	top: 3%;
	height: 73px;
	width: 72px;
	left: 14%;
}
#fenge2 {
	position: absolute;
	top: 22%;
	height: 73px;
	width: 72px;
	left: 14%;
}
#fenge3 {
	position: absolute;
	top: 41%;
	height: 73px;
	width: 72px;
	left: 14%;
}
#fenge4 {
	position: absolute;
	top: 62%;
	height: 73px;
	width: 72px;
	left: 14%;
}
#fenge5 {
	position: absolute;
	top: 82%;
	height: 73px;
	width: 72px;
	left: 14%;
}

#insertBooks {
	border-style: none;
        border-color: inherit;
        border-width: medium;
        position: absolute;
	    height: 150px;
	    width: 215px;
	    bottom: -75%;
	    font-family: 幼圆;
	    font-size: 50px;
	    color: #fff;
	    background-color:transparent;
        left: 0px;
    }
#bookNameTextBox {
	position: absolute;
	height: 54px;
	width: 500px;
	top: 5%;
	left: 18%;
	font-family: 幼圆;
	font-size: 25px;
	border: none;

}
#authorTextBox {
	position: absolute;
	height: 54px;
	width: 500px;
	top: 24%;
	left: 18%;
	font-family: 幼圆;
	font-size: 25px;
	border: none;

}
#pressTextBox {
	position: absolute;
	height: 54px;
	width: 500px;
	top: 43%;
	left: 18%;
	font-family: 幼圆;
	font-size: 25px;
	border: none;

}
#dateTextBox {
	position: absolute;
	height: 54px;
	width: 500px;
	top: 64%;
	left: 18%;
	font-family: 幼圆;
	font-size: 25px;
	border: none;

}
#bookInfoTextBox {
	position: absolute;
	height: 54px;
	width: 500px;
	top: 83%;
	left: 18%;
	font-family: 幼圆;
	font-size: 25px;
	border: none;

}
#label_bookName {
	position: absolute;
	height: 150px;
	width: 1000px;
	top: 15%;
	left: 18%;
	font-family: 幼圆;
	font-size: 25px;
	color: #fff;
	border: none;
	background-color:transparent;
}
#label_author {
	position: absolute;
	height: 150px;
	width: 1000px;
	top: 53%;
	left: 18%;
	font-family: 幼圆;
	font-size: 25px;
	color: #fff;
	border: none;
	background-color:transparent;
}

#label_press {
	position: absolute;
	height: 150px;
	width: 1000px;
	top: 33%;
	left: 18%;
	font-family: 幼圆;
	font-size: 25px;
	color: #fff;
	border: none;
	background-color:transparent;
}
#label_date {
	position: absolute;
	height: 150px;
	width: 1000px;
	top: 94%;
	left: 18%;
	font-family: 幼圆;
	font-size: 25px;
	color: #fff;
	border: none;
	background-color:transparent;
}
#label_bookInfo {
	position: absolute;
	height: 150px;
	width: 1000px;
	top: 75%;
	left: 18%;
	font-family: 幼圆;
	font-size: 25px;
	color: #fff;
	border: none;
	background-color:transparent;
}

</style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>华广图书馆</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="all">
    <div id="top">
        <asp:Label ID="username" runat="server" Text="欢迎，第一个用户"></asp:Label>
        <asp:Button ID="insertBooks" runat="server" Text="添加" OnClick="insertBooks_Click" />
        <asp:Button ID="top_loginout" runat="server" Text="" OnClick="top_loginout_Click"  />

    </div>
 	<div id="main">

         <asp:Label ID="bookname" runat="server" Text="书名"></asp:Label>
         <asp:Label ID="author" runat="server" Text="作者"></asp:Label>
         <asp:Label ID="press" runat="server" Text="出版社"></asp:Label>
         <asp:Label ID="date" runat="server" Text="出版时间"></asp:Label>
         <asp:Label ID="bookInfo" runat="server" Text="书本简介"></asp:Label>

         <asp:TextBox ID="bookNameTextBox" runat="server"></asp:TextBox>
         <asp:TextBox ID="authorTextBox" runat="server"></asp:TextBox>
         <asp:TextBox ID="pressTextBox" runat="server"></asp:TextBox>
         <asp:TextBox ID="dateTextBox" runat="server"></asp:TextBox>
         <asp:TextBox ID="bookInfoTextBox" runat="server"></asp:TextBox>

          <asp:RequiredFieldValidator ID="label_bookName" runat="server" ErrorMessage="不能为空" ControlToValidate="booknameTextBox"></asp:RequiredFieldValidator>
         <asp:RequiredFieldValidator ID="label_author" runat="server" ErrorMessage="不能为空" ControlToValidate="authorTextBox"></asp:RequiredFieldValidator>
         <asp:RequiredFieldValidator ID="label_press" runat="server" ErrorMessage="不能为空" ControlToValidate="pressTextBox" ></asp:RequiredFieldValidator>
         <asp:RequiredFieldValidator ID="label_date" runat="server" ErrorMessage="不能为空" ControlToValidate="dateTextBox" ></asp:RequiredFieldValidator>
         <asp:RequiredFieldValidator ID="label_bookInfo" runat="server" ErrorMessage="不能为空" ControlToValidate="bookInfoTextBox" ></asp:RequiredFieldValidator>

    	<img id="fenge" src="/images/5.png" /> 
        <img id="fenge2" src="/images/5.png" /> 
        <img id="fenge3" src="/images/5.png" /> 
        <img id="fenge4" src="/images/5.png" /> 
        <img id="fenge5" src="/images/5.png" /> 
    </div>
</div>
    </form>
</body>
</html>