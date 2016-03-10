<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="UserAdd.aspx.cs" Inherits="subject_SubjectAdd" Title="无标题页" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="addtable">
        <tr>
            <td>
                登录名：
            </td>
            <td>
                <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ControlToValidate="txtLoginName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                真实名：
            </td>
            <td>
                <asp:TextBox ID="txtRealName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                    ControlToValidate="txtRealName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                用户类型：
            </td>
            <td>
                <asp:DropDownList ID="ddlUserType" runat="server" 
                    onselectedindexchanged="ddlUserType_SelectedIndexChanged" AutoPostBack="true" Width="160px">
                    <%--<asp:ListItem Value="1" Text="管理员"></asp:ListItem>
                    <asp:ListItem Value="2" Text="教师"></asp:ListItem>
                    <asp:ListItem Value="3" Text="学生"></asp:ListItem>--%>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                班级：
            </td>
            <td>
                <asp:DropDownList ID="ddlClass" runat="server" Width="160px" CssClass="easyui-combobox">                    
                </asp:DropDownList>
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
