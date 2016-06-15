<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css">
body {
	background-image: url(/images/20140918042916130.jpg);
}
#login {
	background-color: #FFF;
	height: 400px;
	width: 400px;
	left: 32%;
	right: 50%;
	position: absolute;
	top: 10%;
	background: rgba(52, 52, 52, 0.5);
	border-radius: 10px;
}
#img_pw {
	position: absolute;
	top: 255px;
	left: 46px;
	height: 30px;
	width: 30px;
}
#img_head {
	position: absolute;
	top: 7%;
	width: 150px;
	left: 33%;
	border-radius: 100px;
}
#login_username {
	border-style: none;
        border-color: inherit;
        border-width: medium;
        position: absolute;
	    height: 30px;
	    width: 200px;
	    left: 27%;
	    top: 49%;
	    margin: 0px;
	    padding: 0px;
	    border-radius: 5px;
	    right: 92px;
        background: rgba(255,255,255, 0.7);
    }
#login_btn {
	background-image: url(/images/2.png);
	height: 50px;
	width: 50px;
	position: absolute;
	top: 80%;
	left: 45%;
	border: none;
	background-repeat: no-repeat;
	background-size:50px 50px;
	background-color:transparent
}
#login_password {
	position: absolute;
	height: 30px;
	width: 200px;
	left: 27%;
	top: 64%;
	margin: 0px;
	padding: 0px;
	border: none;
	border-radius: 5px;
	background: rgba(255,255,255, 0.7);
}
#img_user {
	position: absolute;
	top: 196px;
	left: 46px;
	height: 30px;
	width: 30px;

}
#nameIsNull {
    position: absolute;
	left: 28%;
	top: 57%;
}
#pwIsNull {
    position: absolute;
	left: 28%;
	top: 72%;
}
</style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>华广图书馆</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
	<asp:TextBox ID="login_username"  runat="server"></asp:TextBox>
    <asp:TextBox ID="login_password"  runat="server"></asp:TextBox>
	<img id="img_user" src="/images/login.png" /> 
	<img id="img_pw" src="/images/pw.png" /> 
	<img id="img_head" src="/images/1.png" />
    <asp:Button ID="login_btn" runat="server" Text="" OnClick="login_btn_Click" />
    <asp:RequiredFieldValidator ID="nameIsNull" runat="server" ErrorMessage="用户名不能为空" ControlToValidate="login_username" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="pwIsNull" runat="server" ErrorMessage="密码不能为空" ControlToValidate="login_password" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>     
    </form>
</body>
</html>
