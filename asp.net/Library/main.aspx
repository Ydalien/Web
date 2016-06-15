<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>华广图书馆</title>
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
#bookname {
	position: absolute;
	width: 500px;
	top: 45%;
	left: 29%;
	height: 33px;
	border: none;
	
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
#btn3 {
	position: absolute;
	height: 150px;
	width: 215px;
	top: 65%;
	left: 50%;
	font-family: 幼圆;
	font-size: 50px;
	color: #fff;
	border: none;
	background-color:transparent;
}
#btn2 {
	position: absolute;
	height: 150px;
	width: 215px;
	top: 65%;
	left: 30%;
	font-family: 幼圆;
	font-size: 50px;
	color: #fff;
	border: none;
	background-color:transparent;
}

#btn {
	position: absolute;
	top: 45%;
	right: 23%;
	width: 100px;
	height: 35px;
	border: none;
	font-family : 微软雅黑;
	background-color: #FFF;
}
#img_book {
	position: absolute;
	top: 6%;
	left: 41%;
}
#fenge {
	position: absolute;
	top: 71%;
	height: 73px;
	width: 72px;
	left: 45%;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="all">
        <div id="top">
            <asp:Label ID="username" runat="server" Text="欢迎，第一个用户"></asp:Label>
            <asp:Button ID="top_loginout" runat="server" Text="" OnClick="top_loginout_Click" />
        </div>
 	    <div id="main">
    	    <img id="img_book"src="/images/4.png"  />
            <asp:TextBox ID="bookname" runat="server"></asp:TextBox>
            <asp:Button ID="btn" runat="server" Text="查询" OnClick="btn_Click" />
            <asp:Button ID="btn2" runat="server" Text="管理书籍" OnClick="btn2_Click" />
            <asp:Button ID="btn3" runat="server" Text="个人信息" OnClick="btn3_Click" />
    	    <img id="fenge" src="/images/5.png" /> 
        </div>
    </div>
    </form>
</body>
</html>
