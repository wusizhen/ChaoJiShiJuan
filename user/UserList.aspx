<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="UserList.aspx.cs" Inherits="user_UserList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">        
        $(function(){
           $('#oe_iframe').window('close'); 
           $('#oe_iframe2').window('close');
           $('#oe_iframe3').window('close');
        })
        function oe_import()
        {
            $('#oe_iframe').window({   
                 title:'用户导入',
                 iconCls:'icon-help',                 
                 onClose:function(){   
                    $('#<%=btnHide.ClientID %>').click();
                 }   
            });  
            $('#oe_iframe').window('open');
            $('#oe_iframe').window('resize',{  
                width: 500,  
                height: 200  
            }); 
            $('#oe_iframe').window('move',{   
                left:150,   
                top:0   
            });
            return false;    
        }
        function oe_add()
        {
            $('#oe_iframe2').window({   
                 title:'用户添加',
                 iconCls:'icon-add',                 
                 onClose:function(){   
                    $('#<%=btnHide.ClientID %>').click();
                 }   
            });  
            $('#oe_iframe2').window('open');
            $('#oe_iframe2').window('resize',{  
                width: 400,  
                height: 400  
            }); 
            $('#oe_iframe2').window('move',{   
                left:150,   
                top:0   
            });
            return false;    
        }
        function oe_edit()
        {
            $('#oe_iframe3').window('open');
            $('#oe_iframe3').window({   
                 title:'用户编辑', 
                 iconCls:'icon-cut',                
                 onClose:function(){   
                    $('#<%=btnHide.ClientID %>').click();
                 }   
            }); 
            $('#oe_iframe3').window('resize',{  
                width: 400,  
                height: 400  
            }); 
            $('#oe_iframe3').window('move',{   
                left:150,   
                top:0   
            });
            return false;    
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="box">
        <div id="box_top">        
            登录名：<asp:TextBox ID="txtWord" runat="server"></asp:TextBox> 
            <asp:DropDownList ID="ddlUsertType" runat="server" CssClass="easyui-combobox" Width="160px">
               <asp:ListItem Value="0" Text="所有"></asp:ListItem>
               <asp:ListItem Value="1" Text="管理员"></asp:ListItem>
               <asp:ListItem Value="2" Text="教师"></asp:ListItem>
               <asp:ListItem Value="3" Text="学生"></asp:ListItem>
            </asp:DropDownList>
            <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="easyui-linkbutton" 
                data-options="plain:true,iconCls:'icon-search'" onclick="lbtnSearch_Click">搜索</asp:LinkButton>  
            <asp:LinkButton ID="lbtnAdd" runat="server" CssClass="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'" OnClientClick="return oe_add();">添加</asp:LinkButton>   
            <asp:LinkButton ID="lbtnImport" runat="server" CssClass="easyui-linkbutton" data-options="plain:true,iconCls:'icon-help'" OnClientClick="return oe_import();">导入</asp:LinkButton>                     
            <asp:LinkButton ID="lbtnExport" runat="server" CssClass="easyui-linkbutton" 
                data-options="plain:true,iconCls:'icon-sum'" onclick="lbtnExport_Click">导出</asp:LinkButton>                                       
            <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="easyui-linkbutton" 
                data-options="plain:true,iconCls:'icon-cancel'" onclick="lbtnDelete_Click" OnClientClick="return confirm('您确定删除所选的吗？')">删除所选</asp:LinkButton>
        </div>
        <div id="box_middle">
            <asp:GridView ID="gvwData" runat="server" AutoGenerateColumns="false" CssClass="table"
                HorizontalAlign="Center" onrowdatabound="gvwData_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1+pageSize*(pageIndex-1) %></ItemTemplate>
                        <ItemStyle CssClass="table_head" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkbAll" runat="server"  CssClass="check_all"/>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkbOne" runat="server" CssClass="check_one"/>
                         </ItemTemplate>
                        <ItemStyle CssClass="table_head" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="登录名">
                        <ItemTemplate>
                            <%# Eval("loginname")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="真实名">
                        <ItemTemplate>
                            <%# Eval("realname")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户类型">
                        <ItemTemplate>
                            <%# Eval("usertype")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="班级">
                        <ItemTemplate>
                            <%# Eval("classname")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="easyui-linkbutton" data-options="plain:true,iconCls:'icon-cut'" CommandArgument='<%#Eval("id") %>' OnClick="lbtnEdit_Click">编辑用户</asp:LinkButton>                                                          
                            <asp:LinkButton ID="lbtnReset" runat="server" CssClass="easyui-linkbutton" data-options="plain:true,iconCls:'icon-redo'" CommandArgument='<%#Eval("id") %>' OnClick="lbtnReset_Click" OnClientClick="return confirm('您确定要重置吗？')">重置密码</asp:LinkButton>
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
     <div id="oe_iframe" class="easyui-window" style="padding: 5px;">
        <iframe src="UserImport.aspx" frameborder="0" scrolling="auto" width="100%" height="100%">
        </iframe>
    </div>
    <div id="oe_iframe2" class="easyui-window" style="padding: 5px;">
        <iframe src="UserAdd.aspx" frameborder="0" scrolling="auto" width="100%" height="100%">
        </iframe>
    </div>
    <div id="oe_iframe3" class="easyui-window" style="padding: 5px;">
        <iframe src="UserAdd.aspx<%=editString %>" frameborder="0" scrolling="auto" width="100%" height="100%">
        </iframe>
    </div>
</asp:Content>
