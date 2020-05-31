<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IsPostBackExample.aspx.cs" Inherits="Lesson1.IsPostBackExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table>
            <tr>
                <td>
                    <label for="username">用户名：</label>
                </td>
                <td colspan="2">
                    <input type="text" name="name" value="@name" id="username" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="pwd">密码：</label>
                </td>
                <td colspan="2">
                    <input type="password" name="pwd" id="pwd" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <input type="submit" value="登录" />
                </td>
                <td>
                    <input type="button" value="取消" />
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
