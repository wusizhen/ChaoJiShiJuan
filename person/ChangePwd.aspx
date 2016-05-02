<%@ Page Language="C#"  CodeFile="ChangePwd.aspx.cs" Inherits="subject_SubjectAdd" Title="无标题页"  %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">

    <meta name="viewport" content="width=device-width,initial-scale=1">
    <!--禁止缩放，启动响应式-->
    <link rel="stylesheet" href="../demo/bootstrap/css/bootstrap.min.css">
    <!-- mystyle.css-->
    <link rel="stylesheet" href="../demo/assets/css/mystyle.css" />
    <style>
        body {
            margin-top: 70px;
            background-color: #F5F5F5;
        }

        .row > .col-sm-offset-4 {
            margin-top: 70px;
        }

        .pwdbtn {
            width:100%;
        }
    </style>
</head>
<body runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-4 col-sm-offset-4 col-xs-12">
                <div class="panel">
                    <div class="panel-heading">
                        <h4 style="color: #808080; display: inline-block">修改密码 </h4>
                        <span class="glyphicon glyphicon-lock pull-right" style="margin-top: 10px; color: #808080"></span>
                    </div>
                    <div class="panel-body">
                        <form runat="server" method="post" action="" role="form" class="form-horizontal">
                            <div class="form-group">

                                <div class="col-sm-12 col-xs-12">
                                    <asp:Label ID="lblInfo" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="sr-only">原密码:</label>
                                <div class="col-sm-12 col-xs-12">

                                    <asp:TextBox ID="txtOldPwd" runat="server" CssClass="form-control myInput" TextMode="Password" placeholder="原密码"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtOldPwd"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="form-group">
                                <label class="sr-only">新密码:</label>
                                <div class="col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" CssClass="form-control myInput" placeholder="新密码"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtNewPwd"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="sr-only">重复新密码:</label>
                                <div class="col-sm-12 col-xs-12">

                                    <asp:TextBox ID="txtNewPwd2" runat="server" TextMode="Password" CssClass="form-control myInput" placeholder="重复新密码"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtNewPwd2"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-4 col-xs-offset-4">

                                    <asp:LinkButton ID="lbtnAdd" runat="server" CssClass="btn btn-info pwdbtn" 
                                        OnClick="lbtnAdd_Click">保存</asp:LinkButton>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <script src="../demo/bootstrap/js/jquery-1.11.1.min.js"></script>
    <script src="../demo/bootstrap/js/bootstrap.min.js"></script>
    <script src="../demo/assets/js/placeholderForCP.js"></script>

</body>
</html>



