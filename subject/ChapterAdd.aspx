<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="ChapterAdd.aspx.cs" Inherits="subject_SubjectAdd" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="addtable">
        <tr>
            <td>
                科目名：
            </td>
            <td>
                <asp:DropDownList ID="ddlSubject" runat="server" CssClass="easyui-combobox" Width="160px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                章节名：
            </td>
            <td>
                <asp:DropDownList ID="ddlChapterNO" runat="server" CssClass="easyui-combobox" Width="160px">
                    <asp:ListItem Text="第1章" Value="1"></asp:ListItem>
                    <asp:ListItem Text="第2章" Value="2"></asp:ListItem>
                    <asp:ListItem Text="第3章" Value="3"></asp:ListItem>
                    <asp:ListItem Text="第4章" Value="4"></asp:ListItem>
                    <asp:ListItem Text="第5章" Value="5"></asp:ListItem>
                    <asp:ListItem Text="第6章" Value="6"></asp:ListItem>
                    <asp:ListItem Text="第7章" Value="7"></asp:ListItem>
                    <asp:ListItem Text="第8章" Value="8"></asp:ListItem>
                    <asp:ListItem Text="第9章" Value="9"></asp:ListItem>
                    <asp:ListItem Text="第10章" Value="10"></asp:ListItem>
                    <asp:ListItem Text="第11章" Value="11"></asp:ListItem>
                    <asp:ListItem Text="第12章" Value="12"></asp:ListItem>
                    <asp:ListItem Text="第13章" Value="13"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                    ControlToValidate="ddlChapterNO"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                章节名：
            </td>
            <td>
                <asp:TextBox ID="txtChapterName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ControlToValidate="txtChapterName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lblInfo" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="lbtnAdd" runat="server" CssClass="easyui-linkbutton" data-options="iconCls:'icon-save'"
                    OnClick="lbtnAdd_Click">保存</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
