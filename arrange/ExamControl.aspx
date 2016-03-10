<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="ExamControl.aspx.cs" Inherits="subject_SubjectList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .table th, .table td
        {
            padding: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div id="box_top">
            学生：<asp:TextBox ID="txtWord" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlScoreStatus" runat="server">
                <asp:ListItem Text="所有状态" Value="0"></asp:ListItem>
                <asp:ListItem Text="还没考试" Value="1"></asp:ListItem>
                <asp:ListItem Text="正在考试" Value="2"></asp:ListItem>
                <asp:ListItem Text="考试成功" Value="3"></asp:ListItem>
                <asp:ListItem Text="考试失败" Value="4"></asp:ListItem>
                <asp:ListItem Text="等待批改" Value="5"></asp:ListItem>
                <asp:ListItem Text="重新考试" Value="6"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlClass" runat="server" Width="160px">
            </asp:DropDownList>
            <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search'"
                OnClick="lbtnSearch_Click">搜索</asp:LinkButton>
        </div>
        <div id="box_middle">
            <asp:GridView ID="gvwData" runat="server" AutoGenerateColumns="false" CssClass="table"
                HorizontalAlign="Center" OnRowDataBound="gvwData_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1+pageSize*(pageIndex-1) %></ItemTemplate>
                        <ItemStyle CssClass="table_head" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="班级名">
                        <ItemTemplate>
                            <%# Eval("classname")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="学生名">
                        <ItemTemplate>
                            <%# Eval("realname")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="开始答卷">
                        <ItemTemplate>
                            <%# Eval("starttime")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="结束答卷">
                        <ItemTemplate>
                            <%# Eval("endtime")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="考试状态">
                        <ItemTemplate>
                            <%# Eval("scorestatus")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    没有返回任何数据！
                </EmptyDataTemplate>
                <HeaderStyle CssClass="table_head" />
                <RowStyle HorizontalAlign="Center" />
                <EmptyDataRowStyle Font-Size="16px" ForeColor="Red" Font-Bold="true" />
            </asp:GridView>
        </div>
    </div>
    <div id="pp" class="easyui-pagination" style="background: #efefef; border: 1px solid #ccc;"
        data-options="  
        total:<%=pageTotal%>,
        onSelectPage:function(pageIndex, pageSize){  
             $('#<%=hfPageIndex.ClientID %>').val(pageIndex);
             $('#<%=hfPageSize.ClientID %>').val(pageSize);
             $('#<%=btnHide.ClientID %>').click();
        },
        showRefresh:false,
        pageNumber:<%=pageIndex %>,
        pageSize:<%=pageSize %>  
    ">
    </div>
    <div style="display: none;">
        <asp:HiddenField ID="hfPageIndex" runat="server" />
        <asp:HiddenField ID="hfPageSize" runat="server" />
        <asp:Button ID="btnHide" runat="server" Text="" OnClick="btnHide_Click" />
    </div>
</asp:Content>
