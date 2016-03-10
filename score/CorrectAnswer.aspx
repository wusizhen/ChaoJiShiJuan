<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="CorrectAnswer.aspx.cs" Inherits="subject_SubjectAdd" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="addtable">
        <tr>
            <td>
                考试名：
            </td>
            <td>
                <asp:Label ID="lblArrange" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                科目：
            </td>
            <td>
                <asp:Label ID="lblSubject" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                学生：
            </td>
            <td>
                <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                题目：
            </td>
            <td>
                <asp:Label ID="lblQues" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                参考答案：
            </td>
            <td>
                <asp:TextBox ID="txtStandard" runat="server" Width="320px" TextMode="MultiLine" Rows="3" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                学生答案：
            </td>
            <td>
                <asp:TextBox ID="txtStudent" runat="server" Width="320px" TextMode="MultiLine" Rows="3" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                总分：
            </td>
            <td>
                <asp:Label ID="lblAllScore" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                得分：
            </td>
            <td>
                <asp:DropDownList ID="ddlGetScore" runat="server" CssClass="easyui-combobox" Width="80px">
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
                    OnClick="lbtnAdd_Click">保存并批改下一条</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
