<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userInfo.aspx.cs" Inherits="userInfo" %>

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
#password {
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
#account {
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
#info {
	position: absolute;
	height: 150px;
	width: 215px;
	top: 42%;
	left: 1%;
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

#label_account {
	position: absolute;
	height: 150px;
	width: 1000px;
	top: 4%;
	left: 18%;
	font-family: 幼圆;
	font-size: 50px;
	color: #fff;
	border: none;
	background-color:transparent;
}
#label_info {
	position: absolute;
	height: 150px;
	width: 1000px;
	top: 42%;
	left: 18%;
	font-family: 幼圆;
	font-size: 50px;
	color: #fff;
	border: none;
	background-color:transparent;
}

#label_password {
	position: absolute;
	height: 150px;
	width: 1000px;
	top: 22%;
	left: 18%;
	font-family: 幼圆;
	font-size: 50px;
	color: #fff;
	border: none;
	background-color:transparent;
}
#back {
	position: absolute;
	height: 150px;
	width: 215px;
	bottom: -75%;
	font-family: 幼圆;
	font-size: 50px;
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
        <asp:Button ID="back" runat="server" Text="返回" OnClick="borrowBtn_Click" />
        <asp:Button ID="top_loginout" runat="server" Text="" OnClick="top_loginout_Click"  />

    </div>
 	<div id="main">

         <asp:Label ID="account" runat="server" Text="帐号"></asp:Label>
         <asp:Label ID="password" runat="server" Text="密码"></asp:Label>
         <asp:Label ID="info" runat="server" Text="个人信息"></asp:Label>

         <asp:Label ID="label_account" runat="server" Text="书本简介"></asp:Label>
         <asp:Label ID="label_password" runat="server" Text="书本简介"></asp:Label>
         <asp:Label ID="label_info" runat="server" Text="书本简介"></asp:Label>


    	<img id="fenge" src="/images/5.png" /> 
        <img id="fenge2" src="/images/5.png" /> 
        <img id="fenge3" src="/images/5.png" /> 

    </div>
</div>
    </form>
</body>
</html>
