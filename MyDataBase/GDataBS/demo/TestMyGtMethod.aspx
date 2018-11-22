<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestMyGtMethod.aspx.cs" Inherits="GDataBS.demo.TestMyGtMethod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn" runat="server" Text="退了" OnClick="btn_Click" />
        <asp:TextBox ID="txttxt" runat="server"></asp:TextBox>
        <asp:Button ID="btnToMD5" runat="server" Text="加密" OnClick="btnToMD5_Click" />
        <asp:Button ID="Button1" runat="server" Text="TestPro" OnClick="Button1_Click1" />
        <div>
            <asp:Button ID="Button2" runat="server" Text="生成二维码" OnClick="Button2_Click"/>
            <asp:Image ID="Img" runat="server" />
        </div>
        <div>            
            <asp:Image ID="Image1" runat="server" ImageUrl="TemQRCode.aspx" />
        </div>
    </div>
    </form>
</body>
</html>
