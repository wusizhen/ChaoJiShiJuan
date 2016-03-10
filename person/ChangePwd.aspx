<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="ChangePwd.aspx.cs" Inherits="subject_SubjectAdd" Title="无标题页"  ValidateRequest="false"%>

<%@ Register TagName="CKEditor" TagPrefix="XG" Src="~/js/CKEditor.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="padding:20px;">
        <tr>
            <td>
                原密码：
            </td>
            <td>
                <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtOldPwd"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                新密码：
            </td>
            <td>
                <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtNewPwd"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
            <td>
                重复新密码：
            </td>
            <td>
                <asp:TextBox ID="txtNewPwd2" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtNewPwd2"></asp:RequiredFieldValidator>                
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
