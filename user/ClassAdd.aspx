<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="ClassAdd.aspx.cs" Inherits="class_ClassAdd" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="addtable">
        <tr>
            <td>
                班级名：
            </td>
            <td>
                <asp:TextBox ID="txtClassName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ControlToValidate="txtClassName"></asp:RequiredFieldValidator>
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
