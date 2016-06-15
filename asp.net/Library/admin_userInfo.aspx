<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_userInfo.aspx.cs" Inherits="admin_userInfo" %>

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



#insertUser {
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
#info {
	position: absolute;
	height: 150px;
	width: 1000px;
	top: 22%;
	left: 42%;
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
#selectName {
	position: absolute;
	width: 500px;
	top: 45%;
	left: 29%;
	height: 33px;
	border: none;
	
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
        <asp:Button ID="insertUser" runat="server" Text="增加用户" OnClick="insertUser_Click" />
        <asp:Button ID="top_loginout" runat="server" Text="" OnClick="top_loginout_Click"  />
    </div>
 	<div id="main">
         <asp:GridView ID="users" runat="server" AutoGenerateColumns="False" Height="184px" Width="430px" OnRowCancelingEdit="users_RowCancelingEdit" OnRowDeleting="users_RowDeleting" OnRowEditing="users_RowEditing" OnRowUpdating="users_RowUpdating">
             <Columns>
                 <asp:BoundField DataField="userId" HeaderText="用户标识" ReadOnly="True" />
                 <asp:BoundField DataField="userName" HeaderText="用户名" />
                 <asp:BoundField DataField="userPassWord" HeaderText="用户密码" />
                 <asp:BoundField DataField="userInfo" HeaderText="用户信息" />
                 <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
             </Columns>
         </asp:GridView>

         <asp:TextBox ID="selectName" runat="server"></asp:TextBox>
         <asp:Button ID="btn" runat="server" Text="查询" OnClick="btn_Click" />
         <asp:Label ID="info" runat="server" Text="没有记录"></asp:Label>


    </div>
</div>
    </form>
</body>
</html>
