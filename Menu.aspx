<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html >
<html lang="'en">
<head runat="server">
    <meta charset="utf-8" />
    <title>高校在线考试系统</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- basic styles -->
    <link rel="shortcut icon" href="demo/LG.png">
    <link rel="stylesheet" href="demo/CLNDR/css/clndr.css">
    <link rel="stylesheet" href="demo/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="demo/bootStrap-addTabs/theme/css/bootstrap.min.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="demo/bootStrap-addTabs/theme/css/bootstrap-addtabs.css" type="text/css" media="screen" />
    <!--[if IE 7]>
		  <link rel="stylesheet" href="demo/assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- page specific plugin styles -->


    <!-- ace styles -->

    <link rel="stylesheet" href="demo/assets/css/ace.min.css" />
    <link rel="stylesheet" href="demo/assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="demo/assets/css/ace-skins.min.css" />
    <!-- mystyle.css-->
    <link rel="stylesheet" href="demo/assets/css/mystyle.css" />

    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="demo/assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- inline styles related to this page -->

    <!-- ace settings handler -->

    <script src="demo/assets/js/ace-extra.min.js"></script>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

    <!--[if lt IE 9]>
		<script src="demo/assets/js/html5shiv.js"></script>
		<script src="demo/assets/js/respond.min.js"></script>
    <![endif]-->
    <script src="demo/assets/js/jquery.min.js"></script>
    
    <script src="demo/bootstrap-addtabs/theme/js/bootstrap-addtabs.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#tabs').addtabs({ monitor: 'body' });
        })

        //是否可以close的重新绑定
        function CanClose() {
            $('#tabs').addtabs({
                close: true,
            })
        };
        function NoClose() {
            $('#tabs').addtabs({
                close: false,
            })
        };

        function myAddTab(title, url) {
            CanClose();
            Addtabs.add({
                id: title,
                title: title,
                content: Addtabs.options.content ? Addtabs.options.content : $(this).attr('content'),
                url: url,
                ajax: $(this).attr('ajax') ? true : false
            })

        };
        //myexam页面的进入考试按钮
        function addTabNoClose(title, url) {
            NoClose();
            Addtabs.add({
                id: title,
                title: title,
                content: Addtabs.options.content ? Addtabs.options.content : $(this).attr('content'),
                url: url,
                ajax: $(this).attr('ajax') ? true : false
            });
        };
        function myClose(id) {
            var tabid = "tab_" + id;
            Addtabs.close(tabid);
        };
        //关闭我的考试
        function closeMyExam() {
            myClose('tab_我的考试');
        }
        //关闭练习
        function closeExercise() {
            myClose('tab_正在练习');

        }
        //考试提交
        function closeExam() {
            myClose('正在考试');
            myAddTab('我的成绩', 'student/MyScore.aspx');
        }

    </script>

    <!--fusioncharts js-->
    <script src="demo/assets/js/fusioncharts.js"></script>
    <style>
        td {
            padding-right: 20px;
        }
    </style>

</head>
<body runat="server">
    <form id="form1" runat="server">
        <div class="navbar navbar-inverse" id="navbar">
            <script type="text/javascript">
                try { ace.settings.check('navbar', 'fixed') } catch (e) { }
            </script>

            <div class="navbar-container" id="navbar-container">
                <div class="row">
                    <div class="col-sm-1 col-xs-6">
                        <div class="navbar-header pull-left mynavbar-header">
                            <a class="menu-toggler" id="menu-toggler" href="#"></a>
                            <a href="#" class="navbar-brand miss">
                                <img src="demo/logo2/Icons11.png" />
                            </a>
                            <!-- /.brand -->
                        </div>
                        <!-- /.navbar-header -->
                    </div>
                    <div class="col-sm-7 ">
                        <div class="brand">
                            <a href="#">高校在线考试系统</a>
                        </div>
                    </div>
                    <div class="col-sm-4 col-xs-6">
                        <div class="navbar-header pull-right" role="navigation">
                            <ul class="nav ace-nav mynav">
                                <li class="light-blue">
                                    <a id="bbb" data-toggle="dropdown" href="#" class="dropdown-toggle">
                                        <span class="glyphicon glyphicon-user"></span>
                                        <span>您好,<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></span>

                                        <i class="icon-caret-down"></i>
                                    </a>

                                    <ul class="user-menu pull-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">
                                        <li class="panel-body">
                                            <div class="row">
                                                <div class="col-xs-4 ListColAndRow">
                                                    <asp:Image ID="Image1" CssClass="img-circle" runat="server" Width="100px" Height="100px" />
                                                </div>
                                                <div class="col-xs-8 ListColAndRow" style="font-size: xx-small">
                                                    <h4 class="myH4">
                                                        <asp:Label ID="lblRealName" runat="server" Text=""></asp:Label>·<asp:Label ID="lblRole" runat="server" Text=""></asp:Label></h4>
                                                    <div class="row ListColAndRow">
                                                        <div class="col-xs-12 ListColAndRow">
                                                            <span style="color: #808080">
                                                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></span>
                                                        </div>
                                                    </div>
                                                    <div class="row ListColAndRow ListColAndRow2">
                                                        <table>
                                                            <tr>
                                                                <td>本次登录时间:
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>本次登录IP:
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="panel-footer" style="height: 100%;">
                                            <div class="col-xs-4">
                                                <a href="#" data-addtab="修改密码" url="person/ChangePwd.aspx" class="btn btn-default myStyleBtn">修改密码</a>
                                            </div>
                                            <div class="col-xs-4 col-xs-offset-4">
                                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-default myStyleBtn" OnClick="lbtnEdit_Click">注销</asp:LinkButton>
                                            </div>
                                        </li>




                                    </ul>

                                </li>
                            </ul>
                            <!-- /.ace-nav -->
                        </div>
                        <!-- /.navbar-header -->
                    </div>
                </div>
            </div>
            <!-- /.container -->
        </div>


        <div class="main-container-inner">
            <!--  新版版主窗口   -->
            <!-- <a class="menu-toggler" id="menu-toggler" href="#"> 
                <span class="menu-text"></span>
            </a>
            -->
            <div class="sidebar" id="sidebar">
                <script type="text/javascript">
                    try { ace.settings.check('sidebar', 'fixed') } catch (e) { }
                </script>

                <!-- <div class="sidebar-shortcuts" id="sidebar-shortcuts">

                    <div class="sidebar-shortcuts-mini" id="sidebar-shortcuts-mini">
                        <span class="btn btn-success"></span>

                        <span class="btn btn-info"></span>

                        <span class="btn btn-warning"></span>

                        <span class="btn btn-danger"></span>
                    </div>
                </div><!-- #sidebar-shortcuts -->

                <ul class="nav nav-list">
                    <!--新版导航-->

                    <!--  <li>
                        <a href="#" data-addtab="mss"  url="http://www.bilibili.com">
                            <i class="icon-text-width"></i>
                            文字排版
                        </a>
                    </li> -->
                    <li runat="server" id="menu1">
                        <a href="#" class="dropdown-toggle">
                            <img src="demo/logo2/Icons10.png" />
                            <span class="menu-text">系统管理 </span>


                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="用户管理" url="user/UserList.aspx">用户管理　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="班级管理" url="user/ClassList.aspx">班级管理　
                                </a>
                            </li>
                        </ul>
                    </li>

                    <li runat="server" id="menu2">
                        <a href="#" class="dropdown-toggle">
                            <img src="demo/logo2/Icons12.png" />
                            <span class="menu-text">课程管理 </span>


                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="科目管理" url="subject/SubjectList.aspx">科目管理　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="章节管理" url="subject/ChapterList.aspx">章节管理　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="授课管理" url="subject/GrantList.aspx">授课管理　
                                </a>
                            </li>
                        </ul>
                    </li>

                    <li runat="server" id="menu9">
                        <a href="#" class="dropdown-toggle">
                            <img src="demo/logo2/Icons6.png" />
                            <span class="menu-text">通知公告 </span>


                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="发布公告" url="message/MessageAdd.aspx">发布公告　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="公告列表" url="message/MessageList.aspx">公告列表　
                                </a>
                            </li>
                        </ul>
                    </li>



                    <li runat="server" id="menu3">
                        <a href="#" class="dropdown-toggle">
                            <img src="demo/logo2/Icons1.png" />
                            <span class="menu-text">题库管理 </span>

                        </a>
                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="单选题" url="library/SingleList.aspx">单选题　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="多选题" url="library/CheckList.aspx">多选题　
                                </a>
                            </li>
                            <li>
                                <a href="#" data-addtab="判断题" url="library/JudgeList.aspx">判断题　
                                </a>
                            </li>
                            <li>
                                <a href="#" data-addtab="填空题" url="library/BlankList.aspx">填空题　
                                </a>
                            </li>
                            <li>
                                <a href="#" data-addtab="简答题" url="library/AnswerList.aspx">简答题　
                                </a>
                            </li>
                        </ul>
                    </li>

                    <li runat="server" id="menu4">
                        <a href="#" class="dropdown-toggle">
                            <img src="demo/logo2/Icons5.png" />
                            <span class="menu-text">试卷管理 </span>


                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="添加试卷" url="paper/PaperAdd.aspx">添加试卷　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="试卷列表" url="paper/PaperList.aspx">试卷列表　
                                </a>
                            </li>
                        </ul>
                    </li>

                    <li runat="server" id="menu5">
                        <a href="#" class="dropdown-toggle">
                            <img src="demo/logo2/Icons7.png" />
                            <span class="menu-text">考试安排 </span>


                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="练习管理" url="arrange/ExerciseList.aspx">练习管理　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="考试管理" url="arrange/ExamList.aspx">考试管理　
                                </a>
                            </li>
                        </ul>
                    </li>

                    <li runat="server" id="menu6">
                        <a href="#" class="dropdown-toggle">
                            <img src="demo/logo2/Icons4.png" />
                            <span class="menu-text">成绩管理 </span>


                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="简答批改" url="score/CorrectList.aspx">简答批改　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="学生成绩" url="score/ScoreList.aspx">学生成绩　
                                </a>
                            </li>
                            <li>
                                <a href="#" data-addtab="系统分析" url="score/ExamList.aspx">统计分析（building...）　
                                </a>
                            </li>
                        </ul>
                    </li>

                    <li runat="server" id="menu7">
                        <a href="#" class="dropdown-toggle">
                            <img src="demo/logo2/Icons3.png" />
                            <span class="menu-text">学生考试 </span>


                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="我的练习" url="student/MyExercise.aspx">我的练习　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="我的考试" url="student/MyExam.aspx">我的考试　
                                </a>
                            </li>
                            <li>
                                <a href="#" data-addtab="我的成绩" url="student/MyScore.aspx">我的成绩　
                                </a>
                            </li>
                        </ul>
                    </li>


                </ul>
                <!-- /.nav-list -->



                <script type="text/javascript">
                    try { ace.settings.check('sidebar', 'collapsed') } catch (e) { }
                </script>
            </div>

            <div class="main-content">


                <div class="page-content">
                    <!--	<div class="page-header">
                            <h1>
                                主页
                            </h1>
                        </div>
                        <!-- /.page-header -->

                    <div class="row">
                        <div class="col-xs-12">
                            <!-- PAGE CONTENT BEGINS -->

                            <!--              <div class="alert alert-block alert-success">
                                <button type="button" class="close" data-dismiss="alert">
                                    <i class="icon-remove"></i>
                                </button>

                                <i class="icon-ok green"></i>

                                欢迎使用
                                <strong class="green">
                                    高校在线考试系统
                                    <small>(v1.0)</small>
                                </strong>
                               
                            </div> -->
                            <div id="tabs">
                                <!-- Nav tabs -->
                                <ul class="nav nav-tabs" role="tablist">
                                    <li role="presentation" class="active">
                                        <a href="#home" aria-controls="home" role="tab" data-toggle="tab">主页
                                        </a>

                                </ul>
                                <!-- Tab panes -->
                                <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane active" id="home">
                                        <!--主页内容-->

                                        <div style="padding-left: 20px; padding-top: 5px;">

                                            <div class="alert alert-info alert-dismissible" role="alert">
                                                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                欢迎进入 <strong>超级试卷</strong> - <span style="font-size: 12px;">智能多题型高校在线考试系统</span>
                                            </div>

                                            <div class="row Int" runat="server" id="studentInt">
                                                <div class="col-sm-2 col-sm-offset-2 col-xs-4">
                                                    <a href="#" data-addtab="我的练习" url="student/MyExercise.aspx" class="btn btn-default btnGroup1 btn-block"><span class="glyphicon glyphicon-file"></span><span>我的练习　</span></a>
                                                </div>
                                                <div class="col-sm-2 col-sm-offset-1 col-xs-4">
                                                    <a href="#" data-addtab="我的考试" url="student/MyExam.aspx" class="btn btn-default btnGroup2 btn-block"><span class="glyphicon glyphicon-pencil"></span><span>我的考试　</span></a>
                                                </div>
                                                <div class="col-sm-2 col-sm-offset-1 col-xs-4">
                                                    <a href="#" data-addtab="我的成绩" url="student/MyScore.aspx" class="btn btn-default btnGroup1 btn-block"><span class="glyphicon glyphicon-list"></span><span>我的成绩　</span></a>
                                                </div>
                                            </div>
                                            <div class="row Int" runat="server" id="teacherInt">
                                                <div class="col-sm-2 col-sm-offset-2 col-xs-4">
                                                    <a href="#" data-addtab="发布公告" url="message/MessageAdd.aspx" class="btn btn-default btnGroup1 btn-block"><span class="glyphicon glyphicon-file"></span><span>发布公告　</span></a>
                                                </div>
                                                <div class="col-sm-2 col-sm-offset-1 col-xs-4">
                                                    <a href="#" data-addtab="考试管理" url="arrange/ExamList.aspx" class="btn btn-default btnGroup2 btn-block"><span class="glyphicon glyphicon-pencil"></span><span>考试管理　</span></a>
                                                </div>
                                                <div class="col-sm-2 col-sm-offset-1 col-xs-4">
                                                    <a href="#" data-addtab="学生成绩" url="score/ScoreList.aspx" class="btn btn-default btnGroup1 btn-block"><span class="glyphicon glyphicon-list"></span><span>学生成绩　</span></a>
                                                </div>
                                            </div>
                                            <div class="row Int" runat="server" id="adminInt">
                                                <div class="col-sm-2 col-sm-offset-2 col-xs-4">
                                                    <a href="#" data-addtab="发布公告" url="message/MessageAdd.aspx" class="btn btn-default btnGroup1 btn-block"><span class="glyphicon glyphicon-file"></span><span>发布公告　</span></a>
                                                </div>
                                                <div class="col-sm-2 col-sm-offset-1 col-xs-4">
                                                    <a href="#" data-addtab="授课管理" url="subject/GrantList.aspx" class="btn btn-default btnGroup2 btn-block"><span class="glyphicon glyphicon-pencil"></span><span>授课管理　</span></a>
                                                </div>
                                                <div class="col-sm-2 col-sm-offset-1 col-xs-4">
                                                    <a href="#" data-addtab="班级管理" url="user/ClassList.aspx" class="btn btn-default btnGroup1 btn-block"><span class="glyphicon glyphicon-list"></span><span>班级管理　</span></a>
                                                </div>
                                            </div>
                                            <div class="row Int" runat="server" id="oeadminInt">
                                                <div class="col-sm-2 col-sm-offset-2 col-xs-4">
                                                    <a href="#" data-addtab="用户管理" url="user/UserList.aspx" class="btn btn-default btnGroup1 btn-block"><span class="glyphicon glyphicon-file"></span><span>用户管理　</span></a>
                                                </div>
                                                <div class="col-sm-2 col-sm-offset-1 col-xs-4">
                                                    <a href="#" data-addtab="发布公告" url="message/MessageAdd.aspx" class="btn btn-default btnGroup2 btn-block"><span class="glyphicon glyphicon-pencil"></span><span>发布公告　</span></a>
                                                </div>
                                                <div class="col-sm-2 col-sm-offset-1 col-xs-4">
                                                    <a href="#" data-addtab="公告列表" url="message/MessageList.aspx" class="btn btn-default btnGroup1 btn-block"><span class="glyphicon glyphicon-list"></span><span>公告列表　</span></a>
                                                </div>
                                            </div>
                                            <div class="row ">
                                                <div class="pan">
                                                    <div class="col-sm-12 col-xs-12">
                                                        <div class="inform">
                                                            <div class="row">
                                                                <div class="col-sm-6 col-xs-12">
                                                                    <div class="page-header myPage-header">
                                                                        <h3 style="font-family: SimHei">通知公告</h3>
                                                                    </div>

                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="gvwData" runat="server" AutoGenerateColumns="false" CssClass="table"
                                                                            GridLines="None">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="序号">
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex+1+pageSize*(pageIndex-1) %>
                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="发布人">
                                                                                    <ItemTemplate>
                                                                                        <span><%# Eval("realname")%></span>
                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="主题">
                                                                                    <ItemTemplate>
                                                                                        <a href="#" onclick="return myAddTab('查看公告　','message/MessageShow.aspx?id= <%#Eval("id") %>')"><%# GetSmallTitle(Eval("messagetitle").ToString())%></a>
                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="时间">
                                                                                    <ItemTemplate>
                                                                                        <span><%# Eval("createtime")%></span>
                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>


                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                没有返回任何数据！
                                                                            </EmptyDataTemplate>

                                                                            <EmptyDataRowStyle Font-Size="16px" ForeColor="Red" Font-Bold="true" />
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div style="background: #efefef; border: 1px solid #ccc;"
                                                                        data-options="  
                                total:<%=pageTotal%>,
                                onSelectPage:function(pageIndex, pageSize){  
                                     $('#<%=hfPageIndex.ClientID %>').val(pageIndex);
                                     $('#<%=hfPageSize.ClientID %>').val(pageSize);
                                     $('#<%=btnHide.ClientID %>').click();
                                },
                                showPageList:false,
                                showRefresh:false,
                                pageNumber:<%=pageIndex %>,
                                pageSize:5  
                            ">
                                                                    </div>
                                                                    <div style="display: none;">
                                                                        <asp:HiddenField ID="hfPageIndex" runat="server" />
                                                                        <asp:HiddenField ID="hfPageSize" runat="server" />
                                                                        <asp:Button ID="btnHide" runat="server" Text="" OnClick="btnHide_Click" />
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-6 col-xs-12">
                                                                    
                                                                        <div class="page-header myPage-header">
                                                                            <h3 style="font-family: SimHei">天气</h3>
                                                                        </div>
                                                                        <iframe name="sinaWeatherTool" src="http://weather.news.sina.com.cn/chajian/iframe/weatherStyle41.html?city=%E6%AD%A6%E6%B1%89" width="260" height="114" marginwidth="0" marginheight="0" hspace="0" vspace="0" frameborder="0" scrolling="no"></iframe>
                                                                    
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-sm-12 col-xs-12">
                                                        <div class="inform">

                                                            <div class="page-header myPage-header">
                                                                <h3 style="font-family: SimHei">日历</h3>
                                                            </div>
                                                            <div class="cal1"></div>
                                                            <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
                                                            <script src="https://cdnjs.cloudflare.com/ajax/libs/underscore.js/1.8.3/underscore-min.js"></script>
                                                            <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.6/moment.min.js"></script>
                                                            <script src="demo/CLNDR/src/clndr.js"></script>
                                                            <script src="demo/CLNDR/demo.js"></script>

                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12 col-xs-12">
                                                        <div class="inform">
                                                            <div class="page-header myPage-header">
                                                                <h3 style="font-family: SimHei">教师统计分析</h3>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-sm-6 col-xs-12">
                                                                    <asp:Literal ID="class3Comparison" runat="server"></asp:Literal>
                                                                </div>
                                                                <div class="col-sm-6 col-xs-12">
                                                                    <asp:Literal ID="techerExamStat" runat="server"></asp:Literal>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12 col-xs-12">
                                                        <div class="inform">
                                                            <div class="page-header myPage-header">
                                                                <h3 style="font-family: SimHei">管理员统计</h3>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-sm-6 col-xs-12">
                                                                    <asp:Literal ID="adminweeksignin" runat="server"></asp:Literal>
                                                                </div>
                                                                <div class="col-sm-6 col-xs-12">
                                                                    <asp:Literal ID="adminipstatic" runat="server"></asp:Literal>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12 col-xs-12">
                                                        <div class="inform">
                                                            <div class="page-header myPage-header">
                                                                <h3 style="font-family: SimHei">学生统计</h3>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-sm-6 col-xs-12">
                                                                    <asp:Literal ID="studentError" runat="server"></asp:Literal>
                                                                </div>
                                                                <div class="col-sm-6 col-xs-12 infobox-container">
                                                                    <p>学生统计</p>
                                                                    <div class="infobox infobox-red  ">
                                                                        <div class="infobox-icon">
                                                                            <i class="icon-beaker"></i>
                                                                        </div>

                                                                        <div class="infobox-data">
                                                                            <span class="infobox-data-number">3</span>
                                                                            <div class="infobox-content">最近考试</div>
                                                                        </div>
                                                                    </div>



                                                                    <div class="space-6"></div>
                                                                    <div class="infobox infobox-blue infobox-small infobox-dark">
                                                                        <div class="infobox-chart">
                                                                            <span class="sparkline" data-values="3,4,2,3,4,4,2,2"></span>
                                                                        </div>

                                                                        <div class="infobox-data">
                                                                            <div class="infobox-content">答题成就</div>
                                                                            <div class="infobox-content">40</div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="infobox infobox-green infobox-small infobox-dark">
                                                                        <div class="infobox-progress">
                                                                            <div class="easy-pie-chart percentage" data-percent="61" data-size="39">
                                                                                <span class="percent">61</span>%
                                                                            </div>
                                                                        </div>

                                                                        <div class="infobox-data">
                                                                            <div class="infobox-content">正答率</div>
                                                                            <div class="infobox-content">61%</div>
                                                                        </div>
                                                                    </div>




                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="clear"></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>



                                <!-- PAGE CONTENT ENDS -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.page-content -->
                </div>
                <!-- /.main-content -->

                <!--        <div class="ace-settings-container" id="ace-settings-container">
                <div class="btn btn-app btn-xs btn-warning ace-settings-btn" id="ace-settings-btn">
                    <i class="icon-cog bigger-150"></i>
                </div>

                <div class="ace-settings-box" id="ace-settings-box">
                    <div>
                        <div class="pull-left">
                            <select id="skin-colorpicker" class="hide">
                                <option data-skin="default" value="#00935f">#00935f</option>
                                <option data-skin="skin-1" value="#222A2D">#222A2D</option>
                                <option data-skin="skin-2" value="#C6487E">#C6487E</option>
                                <option data-skin="skin-3" value="#D0D0D0">#D0D0D0</option>
                            </select>
                        </div>
                        <span>&nbsp; 选择皮肤</span>
                    </div>

                    <div>
                        <input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-navbar" />
                        <label class="lbl" for="ace-settings-navbar"> 固定导航条</label>
                    </div>

                    <div>
                        <input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-sidebar" />
                        <label class="lbl" for="ace-settings-sidebar"> 固定滑动条</label>
                    </div>
                    <div>
                        <input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-add-container" />
                        <label class="lbl" for="ace-settings-add-container">
                            切换窄屏
                            <b></b>
                        </label>
                    </div>
                </div>
            </div><!-- /#ace-settings-container -->

            </div>
            <!-- /.main-container-inner -->

            <a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
                <i class="icon-double-angle-up icon-only bigger-110"></i>
            </a>
        </div>
        <!-- /.main-container -->
        <!-- basic scripts -->
        <!--[if !IE]> -->

        <script type="text/javascript">
            window.jQuery || document.write("<script src='demo/assets/js/jquery-2.0.3.min.js'>" + "<" + "script>");
        </script>

        <!-- <![endif]-->
        <!--[if IE]>
    <script type="text/javascript">
     window.jQuery || document.write("<script src='demo/assets/js/jquery-1.10.2.min.js'>"+"<"+"script>");
    </script>
    <![endif]-->

        <script type="text/javascript">
            if ("ontouchend" in document) document.write("<script src='demo/assets/js/jquery.mobile.custom.min.js'>" + "<" + "script>");
        </script>
        <script src="demo/assets/js/bootstrap.min.js"></script>
        <script src="demo/assets/js/typeahead-bs2.min.js"></script>

        <!-- page specific plugin scripts -->
        <!--[if lte IE 8]>
            <script src="demo/assets/js/excanvas.min.js"></script>
        <![endif]-->

        <script src="demo/assets/js/jquery-ui-1.10.3.custom.min.js"></script>
        <script src="demo/assets/js/jquery.ui.touch-punch.min.js"></script>
        <script src="demo/assets/js/jquery.slimscroll.min.js"></script>
        <script src="demo/assets/js/jquery.easy-pie-chart.min.js"></script>
        <script src="demo/assets/js/jquery.sparkline.min.js"></script>
        <script src="demo/assets/js/flot/jquery.flot.min.js"></script>
        <script src="demo/assets/js/flot/jquery.flot.pie.min.js"></script>
        <script src="demo/assets/js/flot/jquery.flot.resize.min.js"></script>

        <!-- ace scripts -->

        <script src="demo/assets/js/ace-elements.min.js"></script>
        <script src="demo/assets/js/ace.min.js"></script>
       
        <!-- inline scripts related to this page -->

          <script type="text/javascript">
        jQuery(function ($) {
            $('.easy-pie-chart.percentage').each(function () {
                var $box = $(this).closest('.infobox');
                var barColor = $(this).data('color') || (!$box.hasClass('infobox-dark') ? $box.css('color') : 'rgba(255,255,255,0.95)');
                var trackColor = barColor == 'rgba(255,255,255,0.95)' ? 'rgba(255,255,255,0.25)' : '#E2E2E2';
                var size = parseInt($(this).data('size')) || 50;
                $(this).easyPieChart({
                    barColor: barColor,
                    trackColor: trackColor,
                    scaleColor: false,
                    lineCap: 'butt',
                    lineWidth: parseInt(size / 10),
                    animate: /msie\s*(8|7|6)/.test(navigator.userAgent.toLowerCase()) ? false : 1000,
                    size: size
                });
            })

            $('.sparkline').each(function () {
                var $box = $(this).closest('.infobox');
                var barColor = !$box.hasClass('infobox-dark') ? $box.css('color') : '#FFF';
                $(this).sparkline('html', { tagValuesAttribute: 'data-values', type: 'bar', barColor: barColor, chartRangeMin: $(this).data('min') || 0 });
            });




            var placeholder = $('#piechart-placeholder').css({ 'width': '90%', 'min-height': '150px' });
            var data = [
              { label: "social networks", data: 38.7, color: "#68BC31" },
              { label: "search engines", data: 24.5, color: "#2091CF" },
              { label: "ad campaigns", data: 8.2, color: "#AF4E96" },
              { label: "direct traffic", data: 18.6, color: "#DA5430" },
              { label: "other", data: 10, color: "#FEE074" }
            ]
            function drawPieChart(placeholder, data, position) {
                $.plot(placeholder, data, {
                    series: {
                        pie: {
                            show: true,
                            tilt: 0.8,
                            highlight: {
                                opacity: 0.25
                            },
                            stroke: {
                                color: '#fff',
                                width: 2
                            },
                            startAngle: 2
                        }
                    },
                    legend: {
                        show: true,
                        position: position || "ne",
                        labelBoxBorderColor: null,
                        margin: [-30, 15]
                    }
                  ,
                    grid: {
                        hoverable: true,
                        clickable: true
                    }
                })
            }
            drawPieChart(placeholder, data);

            /**
            we saved the drawing function and the data to redraw with different position later when switching to RTL mode dynamically
            so that's not needed actually.
            */
            placeholder.data('chart', data);
            placeholder.data('draw', drawPieChart);



            var $tooltip = $("<div class='tooltip top in'><div class='tooltip-inner'></div></div>").hide().appendTo('body');
            var previousPoint = null;

            placeholder.on('plothover', function (event, pos, item) {
                if (item) {
                    if (previousPoint != item.seriesIndex) {
                        previousPoint = item.seriesIndex;
                        var tip = item.series['label'] + " : " + item.series['percent'] + '%';
                        $tooltip.show().children(0).text(tip);
                    }
                    $tooltip.css({ top: pos.pageY + 10, left: pos.pageX + 10 });
                } else {
                    $tooltip.hide();
                    previousPoint = null;
                }

            });






            var d1 = [];
            for (var i = 0; i < Math.PI * 2; i += 0.5) {
                d1.push([i, Math.sin(i)]);
            }

            var d2 = [];
            for (var i = 0; i < Math.PI * 2; i += 0.5) {
                d2.push([i, Math.cos(i)]);
            }

            var d3 = [];
            for (var i = 0; i < Math.PI * 2; i += 0.2) {
                d3.push([i, Math.tan(i)]);
            }


            var sales_charts = $('#sales-charts').css({ 'width': '100%', 'height': '220px' });
            $.plot("#sales-charts", [
                { label: "Domains", data: d1 },
                { label: "Hosting", data: d2 },
                { label: "Services", data: d3 }
            ], {
                hoverable: true,
                shadowSize: 0,
                series: {
                    lines: { show: true },
                    points: { show: true }
                },
                xaxis: {
                    tickLength: 0
                },
                yaxis: {
                    ticks: 10,
                    min: -2,
                    max: 2,
                    tickDecimals: 3
                },
                grid: {
                    backgroundColor: { colors: ["#fff", "#fff"] },
                    borderWidth: 1,
                    borderColor: '#555'
                }
            });


            $('#recent-box [data-rel="tooltip"]').tooltip({ placement: tooltip_placement });
            function tooltip_placement(context, source) {
                var $source = $(source);
                var $parent = $source.closest('.tab-content')
                var off1 = $parent.offset();
                var w1 = $parent.width();

                var off2 = $source.offset();
                var w2 = $source.width();

                if (parseInt(off2.left) < parseInt(off1.left) + parseInt(w1 / 2)) return 'right';
                return 'left';
            }


            $('.dialogs,.comments').slimScroll({
                height: '300px'
            });


            //Android's default browser somehow is confused when tapping on label which will lead to dragging the task
            //so disable dragging when clicking on label
            var agent = navigator.userAgent.toLowerCase();
            if ("ontouchstart" in document && /applewebkit/.test(agent) && /android/.test(agent))
                $('#tasks').on('touchstart', function (e) {
                    var li = $(e.target).closest('#tasks li');
                    if (li.length == 0) return;
                    var label = li.find('label.inline').get(0);
                    if (label == e.target || $.contains(label, e.target)) e.stopImmediatePropagation();
                });

            $('#tasks').sortable({
                opacity: 0.8,
                revert: true,
                forceHelperSize: true,
                placeholder: 'draggable-placeholder',
                forcePlaceholderSize: true,
                tolerance: 'pointer',
                stop: function (event, ui) {//just for Chrome!!!! so that dropdowns on items don't appear below other items after being moved
                    $(ui.item).css('z-index', 'auto');
                }
            }
            );
            $('#tasks').disableSelection();
            $('#tasks input:checkbox').removeAttr('checked').on('click', function () {
                if (this.checked) $(this).closest('li').addClass('selected');
                else $(this).closest('li').removeClass('selected');
            });


        })
    </script>
          <script type="text/javascript">
        var _bdhmProtocol = (("https:" == document.location.protocol) ? " https://" : " http://");
        document.write(unescape("%3Cscript src='" + _bdhmProtocol + "hm.baidu.com/h.js%3Fe9e1d61340ff3d9495a8cca04ebdb49d' type='text/javascript'%3E%3C/script%3E"));
    </script>
        <!--END-->
    </form>
</body>
</html>
