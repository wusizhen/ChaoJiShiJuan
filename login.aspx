<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Login"
    Title="欢迎登陆 高校在线考试系统" %>

<!doctype html>
<html lang="en" class="no-js">
<head>
    <meta charset="UTF-8" />
    <link rel="stylesheet" href="demo/bootstrap/css/bootstrap.min.css">
    <!-- mystyle.css-->
    <link rel="stylesheet" href="demo/assets/css/mystyle.css" />
    <title>欢迎登陆超级试卷</title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="demo/assets/css/partclegrondstyle.css" />
    <link href='http://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>
    <!-- remember, jQuery is completely optional -->
    <!-- <script type='text/javascript' src='demo/bootstrap/js/jquery-1.11.1.min.js'></script> -->
    <script src="demo/assets/js/jquery.particleground.js"></script>
    <script type='text/javascript' src='demo/assets/js/demo.js'></script>
    <script src="demo/bootstrap/js/bootstrap.min.js"></script>
    <script src="demo/assets/js/placeholderForCP.js"></script>
    <script language="JavaScript">
        function keyLogin() {
            if (event.keyCode == 13)
                //按Enter键的键值为13  
                document.getElementById("lbtnSubmit").click();
            //调用登录按钮的登录事件  
        }
    </script>
</head>

<body>

    <div id="particles">
        <div id="intro">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-4 col-sm-offset-4 col-xs-12">
                        <div class="panel" style="background-color: rgba(0,0,0,0.35);">
                            <div class="panel-heading" style="text-align: center">
                                <div class="row">
                                    <div class="col-xs-12">
                                        <h1 style="color: #FFFFFF;">超级试卷</h1>
                                        <h4 style="color: #FFFFFF;">在线考试系统</h4>
                                    </div>
                                </div>
                                <div style="min-height: 20px;">
                                    <asp:Label ID="lblTip" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="panel-body">
                                <form runat="server" id="form1" method="post" role="form">
                                    <div class="row myRows">
                                        <div class="col-xs-1 col-xs-offset-1 myCols">
                                            <i class="glyphicon glyphicon-user"></i>
                                        </div>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtLoginName" runat="server" CssClass="form-control myInput" placeholder="用户名"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-1">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtLoginName"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row myRows">
                                        <div class="col-xs-1 col-xs-offset-1 myCols">
                                            <i class="glyphicon glyphicon-lock"></i>
                                        </div>
                                        <div class="col-xs-8">
                                            <asp:TextBox ID="txtUserPwd" runat="server" CssClass="form-control myInput" placeholder="密码" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-1">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtUserPwd"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row myRows">
                                        <div class="col-xs-4 col-xs-offset-2">
                                            <a class="myA" href="#">忘记密码?</a>
                                        </div>
                                        <div class="col-xs-5 col-xs-offset-1" style="color: #FFFFFF">
                                            <asp:CheckBox runat="server" ID="cookieCheck" CssClass="myCheckBox"></asp:CheckBox>30天内记住
                                       
                                        </div>
                                    </div>
                                    <div class="row myRows">
                                        <div class="col-xs-4 col-xs-offset-6">
                                            <asp:LinkButton ID="lbtnSubmit" runat="server" CssClass="btn btn-info btn-block" OnClick="lbtnSubmit_Click">登陆</asp:LinkButton>
                                        </div>

                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>
        <div class="row myrow footer">
            <div class="col-xs-12 footer">
                <span>© 2016 超级试卷</span>
                <span class="dot">·</span>
                <a target="_blank" href="http://www.whut.edu.cn">武汉理工大学</a>
                <span class="dot">·</span>
                <span>创作：大呲花|MuJi|Vi.Ci</span>
                <span class="dot">·</span>
                <a target="_blank" href="https://github.com/woailuoli993/ChaoJiShiJuan" >源码</a>
            </div>
        </div>
    </div>



</body>
</html>

