<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CookieLogin.aspx.cs" Inherits="Lesson4.CookieLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名：
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click"/>
        </div>
    </form>
</body>
</html>
