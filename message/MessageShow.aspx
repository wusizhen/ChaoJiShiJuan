<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="MessageShow.aspx.cs" Inherits="subject_SubjectAdd" Title="无标题页" ValidateRequest="false" %>

<%@ Register TagName="CKEditor" TagPrefix="XG" Src="~/js/CKEditor.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 600px;padding-top: 15px;padding-left:15px;">
        <div style="text-align: center;">
            <asp:Label ID="lblTitle" runat="server" Text="Label" Font-Size="Large" Font-Bold="true"></asp:Label><br />
            <div style="font-size:14px;padding-top:10px;">时间：<asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;访问量：<asp:Label
                ID="lblVisitCount" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div style="font-size: 16px; line-height: 28px;">
            <asp:Localize ID="locContent" runat="server"></asp:Localize>
        </div>
    </div>
</asp:Content>
