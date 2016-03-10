<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="MessageAdd.aspx.cs" Inherits="subject_SubjectAdd" Title="无标题页"  ValidateRequest="false"%>

<%@ Register TagName="CKEditor" TagPrefix="XG" Src="~/js/CKEditor.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="addtable">
        <tr>
            <td>
                标题：
            </td>
            <td>
                <asp:TextBox ID="txtMessageTitle" runat="server" Width="600px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtMessageTitle"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top">
                内容：
            </td>
            <td>
                <XG:CKEditor runat="server" ID="txtMessageContent" Height="200" Width="800" Theme="default" />
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
