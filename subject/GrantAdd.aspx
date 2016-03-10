<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="GrantAdd.aspx.cs" Inherits="subject_SubjectAdd" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                教师名：
            </td>
            <td>
                <asp:DropDownList ID="ddlUserName" runat="server" CssClass="easyui-combobox" Width="160px">
                </asp:DropDownList>
            </td>
        </tr>
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
            <td valign="top" style="padding-top:10px;">
                班级名：
            </td>
            <td>
                <div style="height:100px;overflow-x:hidden;overflow-y:scroll;width:650px;padding-top:5px;">
                    <asp:CheckBoxList ID="cblClass" runat="server" RepeatDirection="Horizontal" RepeatColumns="6" Width="600px">
                    </asp:CheckBoxList>
                </div>
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
