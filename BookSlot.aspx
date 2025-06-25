<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookSlot.aspx.cs" Inherits="Task1.BookSlot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Date&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
        <br />
        <br />
        Day&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Monday</asp:ListItem>
            <asp:ListItem>Tuesday</asp:ListItem>
            <asp:ListItem>Wednesday</asp:ListItem>
            <asp:ListItem>Thursday</asp:ListItem>
            <asp:ListItem>Friday</asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Time Slot&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem>9-10 am</asp:ListItem>
            <asp:ListItem>10-11 am</asp:ListItem>
            <asp:ListItem>11-12 am</asp:ListItem>
            <asp:ListItem>12-1 pm</asp:ListItem>
            <asp:ListItem>1-2 pm</asp:ListItem>
            <asp:ListItem>2-3 pm</asp:ListItem>
            <asp:ListItem>3-4 pm</asp:ListItem>
            <asp:ListItem>4-5 pm</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Book" OnClick="Button1_Click" />
    </form>
</body>
</html>
