<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="MessageList.aspx.cs" Inherits="subject_SubjectList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="box">
        <div id="box_top">
            标题或内容：<asp:TextBox ID="txtWord" runat="server"></asp:TextBox>
            <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search'"
                OnClick="lbtnSearch_Click">搜索</asp:LinkButton>
            <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="easyui-linkbutton" data-options="plain:true,iconCls:'icon-cancel'"
                OnClick="lbtnDelete_Click" OnClientClick="return confirm('您确定删除所选的吗？')">删除所选</asp:LinkButton>
        </div>
        <div id="box_middle">
            <asp:GridView ID="gvwData" runat="server" AutoGenerateColumns="false" CssClass="table"
                HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1+pageSize*(pageIndex-1) %></ItemTemplate>
                        <ItemStyle CssClass="table_head" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkbAll" runat="server" CssClass="check_all" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkbOne" runat="server" CssClass="check_one" />
                        </ItemTemplate>
                        <ItemStyle CssClass="table_head" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="标题">
                        <ItemTemplate>
                            &nbsp;&nbsp;<%# GetSmallTitle(Eval("messagetitle").ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发布者">
                        <ItemTemplate>
                            <%# Eval("realname")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="创建时间">
                        <ItemTemplate>
                            <%# Eval("createtime")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-cut'" onclick="return top.addTab('编辑公告','message/MessageAdd.aspx?id=<%#Eval("id") %>')">
                                编辑</a>
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
