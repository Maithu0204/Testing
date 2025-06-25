<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobApplicationForm.aspx.cs" Inherits="Task1.JobApplicationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Stream&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>BSCIT</asp:ListItem>
                <asp:ListItem>BSCCS</asp:ListItem>
                <asp:ListItem>BCA</asp:ListItem>
                <asp:ListItem>MCA</asp:ListItem>
                <asp:ListItem>BTECH</asp:ListItem>
                <asp:ListItem>MTECH</asp:ListItem>
                <asp:ListItem>Others</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Are You a&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                <asp:ListItem>Fresher</asp:ListItem>
                <asp:ListItem>Experience</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Name&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Email&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Contact Number&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            CTC&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Number"  Enabled="false">0</asp:TextBox>
            <br />
            <br />
            Expected CTC&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox5" runat="server" TextMode="Number" Enabled="false" >0</asp:TextBox>
            <br />
            <br />
            Notice Period&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox6" runat="server" Enabled="false">0</asp:TextBox>
            <br />
            <br />
            Resume Attachment&nbsp;&nbsp;&nbsp;
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Button1_Click1" />
        </div>
    </form>
</body>
</html>
