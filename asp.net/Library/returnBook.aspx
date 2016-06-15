<%@ Page Language="C#" AutoEventWireup="true" CodeFile="returnBook.aspx.cs" Inherits="returnBook" %>

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



#borrowBtn {
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
	top: 40%;
	left: 42%;
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
        <asp:Button ID="borrowBtn" runat="server" Text="返回" OnClick="borrowBtn_Click" />
        <asp:Button ID="top_loginout" runat="server" Text="" OnClick="top_loginout_Click"  />

    </div>
 	<div id="main">
         <asp:GridView ID="books" runat="server" AutoGenerateColumns="False">
             <Columns>
                 <asp:BoundField DataField="bookName" HeaderText="书名" />
                 <asp:BoundField DataField="time" HeaderText="借书时间" />
                 <asp:HyperLinkField DataNavigateUrlFields="borrowId" Text="还书" DataNavigateUrlFormatString="returnBook.aspx?bookId={0}" />
             </Columns>
         </asp:GridView>
         <asp:Label ID="info" runat="server" Text="没有记录"></asp:Label>


    </div>
</div>
    </form>
</body>
</html>
