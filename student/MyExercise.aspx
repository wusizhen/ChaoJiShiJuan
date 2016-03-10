<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="MyExercise.aspx.cs" Inherits="subject_SubjectList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="box">
        <div id="box_top">
            <asp:DropDownList ID="ddlSubject" runat="server">
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
                    <asp:TemplateField HeaderText="科目名">
                        <ItemTemplate>
                            <%# Eval("subjectname")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="练习标题">
                        <ItemTemplate>
                            <%# Eval("arrangetitle")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="时长">
                        <ItemTemplate>
                            <%# Eval("durationtime")%>分钟
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="开始时间">
                        <ItemTemplate>
                            <%# Eval("starttime")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="截止时间">
                        <ItemTemplate>
                            <%# Eval("endtime")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="easyui-linkbutton" data-options="plain:true,iconCls:'icon-no'"
                                CommandArgument='<%#Eval("id") %>' OnClick="lbtnEdit_Click" OnClientClick="return confirm('你确定现在进行练习吗？')">进入练习</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    没有返回任何数据！
                </EmptyDataTemplate>
                <HeaderStyle  CssClass="table_head"/>
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
