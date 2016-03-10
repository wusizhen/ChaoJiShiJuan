<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Login" Title="欢迎登陆 高校在线考试系统" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">        
        $(function(){
//           $('#oe_login').window({   
//                 title:'登陆',
//                 iconCls:'icon-help', 
//                 collapsible:false, 
//                 minimizable:false,
//                 maximizable:false,
//                 closable:false,
//                 draggable:false              
//            });  
//            $('#oe_login').window('open');
//            $('#oe_login').window('resize',{  
//                width: 350,  
//                height: 200  
//            }); 
//            $('#oe_login').window('move',{     
//                top:200   
//            });
            
            $("body").addClass("login_bg");
            
        })      
    </script>

    <style type="text/css">
        .login_bg
        {
            background: white url(images/login_bg.jpg) repeat-x left top !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 1000px; height: 600px; margin: 0px auto;">
        <div style="padding-top: 50px; padding-left: 20px;">
            <img src="images/login_top.png" width="80" height="80" />
            <img src="images/gxzzks.png" height="80"  style="margin-left:20px;"/></div>
        <div>
            <div style="height: 20px">
            </div>
            <div style="width: 400px; height: 300px; float: left;padding-left:80px">
                <img src="images/login_left.jpg" />
            </div>
            <div style="width: 320px; height: 300px; float: left; padding-left: 120px;padding-top:40px;">
                <div class="easyui-panel" title="&nbsp;&nbsp;&nbsp;登陆" style="width: 300px; height: 200px; padding: 10px;
                    background: #fafafa;" iconcls="icon-tip" closable="false" collapsible="false"
                    minimizable="false" maximizable="false">
                    <table style="margin: 0px auto; margin-top: 10px;" cellspacing="5">
                        <tr>
                            <td>
                                用户名：
                            </td>
                            <td>
                                <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtLoginName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserPwd" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtUserPwd"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="padding-left:20px;padding-top:10px;">
                                <asp:LinkButton ID="lbtnSubmit" runat="server" CssClass="easyui-linkbutton" 
                                    data-options="iconCls:'icon-ok'" onclick="lbtnSubmit_Click">登陆</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="padding-top:5px;">
                                <asp:Label ID="lblTip" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div style="clear: both;text-align:center;">
            ©2013 武汉理工大学管理学院 林立志 版权所有 联系QQ：878983297
        </div>
    </div>
</asp:Content>
