<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="MessageShow.aspx.cs" Inherits="subject_SubjectAdd" Title="无标题页" ValidateRequest="false" %>

<%@ Register TagName="CKEditor" TagPrefix="XG" Src="~/js/CKEditor.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../demo/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../demo/bootStrap-addTabs/theme/css/bootstrap.min.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 600px;margin:20px auto;">
        <div style="text-align: center;border-bottom:1px solid #3098be;margin-bottom:20px;">
            <asp:Label ID="lblTitle" runat="server" Text="Label" Font-Size="X-Large" Font-Bold="true" ForeColor="#3098BE"></asp:Label><br />
            <div style="font-size:14px;padding-top:10px;margin-top:10px;margin-bottom:10px;">
                <span class="glyphicon glyphicon-calendar" style="margin-right:5px;margin-top:2px;"></span>时间：<asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="glyphicon glyphicon-globe"style="margin-right:5px;"></span>访问量：<asp:Label
                ID="lblVisitCount" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div style="font-size: 16px; line-height: 28px;">
            <asp:Localize ID="locContent" runat="server"></asp:Localize>
        </div>
    </div>
</asp:Content>
