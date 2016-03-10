<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html >
<html lang="'en">
<head   runat="server">
    <meta charset="utf-8" />
    <title>高校在线考试系统</title>
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- basic styles -->
		<link rel="shortcut icon" href="demo/LG.png">
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
        <script src="demo/assets/js/bootstrap.min.js"></script>
        <script src="demo/bootstrap-addtabs/theme/js/bootstrap-addtabs.js"></script>
		 <script type="text/javascript">
            $(function(){
                $('#tabs').addtabs({monitor:'.nav'});                
            })
        </script>
    

</head>
<body runat="server">
    <form id="form1" runat="server">
    <div class="navbar navbar-inverse" id="navbar">
        <script type="text/javascript">
            try { ace.settings.check('navbar', 'fixed') } catch (e) { }
        </script>

        <div class="navbar-container" id="navbar-container">
            <div class="row">
                <div class="col-xs-8">
            <div class="navbar-header pull-left">
                <a href="#" class="navbar-brand"style="display:inline-block;padding-top:0;padding-left:10px;" >
                    <img src="demo/logo.png"/>
                </a><!-- /.brand -->
            </div><!-- /.navbar-header -->
                    </div>
            <div class="col-xs-4">
            <div class="navbar-header pull-right" role="navigation">
                <ul class="nav ace-nav">
                    <li class="light-blue">
                        <a id="bbb" data-toggle="dropdown" href="#" class="dropdown-toggle">
                            <span class="glyphicon glyphicon-user"></span>                            
                                                                            
                            <i class="icon-caret-down"></i>
                        </a>

                        <ul class="user-menu pull-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">
                            <li >
                              <span style="color:#000000"> 用户：</span> <asp:Label ID="lblRealName" runat="server" Text="" Font-Bold="true" ForeColor="Green"></asp:Label>
                            </li>

                            <li>
                              <span style="color:#000000"> 角色：</span> <asp:Label ID="lblRole" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                            </li>

                            <li class="divider"></li>

                            <li>
                                                                   
                                   <asp:LinkButton ID="lbtnEdit" runat="server" data-options="plain:true,iconCls:'icon-undo'"
                            OnClick="lbtnEdit_Click"><span class="glyphicon glyphicon-off"></span>注销</asp:LinkButton>
                                </a>
                            </li>
                        </ul>
                    </li>
                </ul><!-- /.ace-nav -->
            </div><!-- /.navbar-header -->
                </div>
                </div>
        </div><!-- /.container -->
    </div>


        <div class="main-container-inner"><!--  新版版主窗口   -->
            <a class="menu-toggler" id="menu-toggler" href="#">
                <span class="menu-text"></span>
            </a>

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

                <ul class="nav nav-list"><!--新版导航-->
                    
                  <!--  <li>
                        <a href="#" data-addtab="mss"  url="http://www.bilibili.com">
                            <i class="icon-text-width"></i>
                            文字排版
                        </a>
                    </li> -->
                    <li  runat="server" id="menu1">
                        <a href="#" class="dropdown-toggle">
                            <span class="glyphicon glyphicon-wrench"></span>
                            <span class="menu-text"> 系统管理 </span>

                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="用户管理" url="user/UserList.aspx">
                                   
                                    用户管理　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="班级管理" url="user/ClassList.aspx">
                                    
                                    班级管理　
                                </a>
                            </li>                          
                        </ul>
                    </li>

                    <li runat="server"  id="menu2">
                        <a href="#" class="dropdown-toggle">
                            <span class="glyphicon glyphicon-calendar"></span>
                            <span class="menu-text"> 课程管理 </span>

                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="科目管理" url="subject/SubjectList.aspx">
                                    
                                   科目管理　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="章节管理" url="subject/ChapterList.aspx">
                                    
                                    章节管理　
                                </a>
                            </li>
                            
                            <li>
                                <a href="#" data-addtab="授课管理" url="subject/GrantList.aspx">
                                    
                                     授课管理　
                                </a>
                            </li>
                        </ul>
                    </li>

                    <li  runat="server" id="menu9">
                        <a href="#" class="dropdown-toggle">
                            <span class="glyphicon glyphicon-volume-up"></span>
                            <span class="menu-text"> 通知公告 </span>

                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="发布公告" url="message/MessageAdd.aspx">
                                    
                                    发布公告　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="公告列表" url="message/MessageList.aspx">
                                    
                                    公告列表　
                                </a>
                            </li>                           
                        </ul>
                    </li>


                    
                    <li  runat="server" id="menu3">
                        <a href="#" class="dropdown-toggle">
                            <span class="glyphicon glyphicon-briefcase"></span>
                            <span class="menu-text"> 题库管理 </span>

                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="单选题" url="library/SingleList.aspx">
                                    
                                    单选题　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="多选题" url="library/CheckList.aspx">
                                    
                                    多选题　
                                </a>
                            </li>
                             <li>
                                <a href="#" data-addtab="判断题" url="library/JudgeList.aspx">
                                    
                                   判断题　
                                </a>
                            </li>  
                             <li>
                                <a href="#" data-addtab="填空题" url="library/BlankList.aspx">
                                    
                                    填空题　
                                </a>
                            </li>  
                             <li>
                                <a href="#" data-addtab="简答题" url="library/AnswerList.aspx">
                                    
                                    简答题　
                                </a>
                            </li>                             
                        </ul>
                    </li>

                      <li  runat="server" id="menu4">
                        <a href="#" class="dropdown-toggle">
                            <span class="glyphicon glyphicon-file"></span>
                            <span class="menu-text"> 试卷管理 </span>

                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="添加试卷" url="paper/PaperAdd.aspx">
                                    
                                    添加试卷　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="试卷列表" url="paper/PaperList.aspx">
                                    
                                    试卷列表　
                                </a>
                            </li>                                                 
                        </ul>
                    </li>

                     <li  runat="server" id="menu5">
                        <a href="#" class="dropdown-toggle">
                            <span class="glyphicon glyphicon-tasks"></span>
                            <span class="menu-text"> 考试安排 </span>

                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="练习管理" url="arrange/ExerciseList.aspx">
                                    
                                    练习管理　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="考试管理" url="arrange/ExamList.aspx">
                                    
                                    考试管理　
                                </a>
                            </li>                                                 
                        </ul>
                    </li>
                    
                     <li  runat="server" id="menu6">
                        <a href="#" class="dropdown-toggle">
                            <span class="glyphicon glyphicon-folder-open"></span>
                            <span class="menu-text"> 成绩管理 </span>

                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="简答批改" url="score/CorrectList.aspx">
                                    
                                    简答批改　
                                </a>
                            </li>

                            <li>
                                <a href="#" data-addtab="学生成绩" url="score/ScoreList.aspx">
                                    
                                    学生成绩　
                                </a>
                            </li>
                             <li>
                                <a href="#" data-addtab="系统分析" url="score/ExamList.aspx">
                                    
                                    统计分析（building...）　
                                </a>
                            </li>                                                      
                        </ul>
                    </li>
                                             
                    <li  runat="server" id="menu7">
                        <a href="#" class="dropdown-toggle" >
                            <span class="glyphicon glyphicon-pencil"></span>
                            <span class="menu-text"> 学生考试 </span>

                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="我的练习" url="student/MyExercise.aspx">
                                    
                                    我的练习　
                                </a>
                            </li>

                            <li>
                                <a href="#"  data-addtab="我的考试" url="student/MyExam.aspx">
                                    
                                    我的考试　
                                </a>
                            </li>
                             <li>
                                <a href="#" data-addtab="我的成绩" url="student/MyScore.aspx">
                                    
                                    我的成绩　
                                </a>
                            </li>                                                        
                        </ul>
                    </li>
                    
                     <li  runat="server" id="menu8">
                        <a href="#" class="dropdown-toggle">
                            <span class="glyphicon glyphicon-heart"></span>
                            <span class="menu-text"> 个人管理 </span>

                            <b class="arrow icon-angle-down"></b>
                        </a>

                        <ul class="submenu">
                            <li>
                                <a href="#" data-addtab="修改密码" url="person/ChangePwd.aspx">
                                    
                                    修改密码　
                                </a>
                            </li>                                                         
                        </ul>
                    </li>                                                                      
                </ul><!-- /.nav-list -->

                <div class="sidebar-collapse" id="sidebar-collapse">
                    <i class="icon-double-angle-left" data-icon1="icon-double-angle-left" data-icon2="icon-double-angle-right"></i>
                </div>

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
                                        <a href="#home"  aria-controls="home" role="tab" data-toggle="tab">
                                            主页
                                        </a>
                                    </li>
                                </ul>
                                <!-- Tab panes -->
                                <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane active" id="home">
                                   <!--主页内容-->
                                       
                <div style=" padding-left:20px;padding-top:5px;">
                    <h3>
                        基本信息</h3>
                    <div style="padding-left:10px;">
                        <div style="float: left; width: 200px; height: 150px; text-align: center; vertical-align: middle;">
                            <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" />
                        </div>
                        <div style="float: left; width: 300px; height: 150px; vertical-align: middle;
                            font-size: 14px;padding-left:20px;">
                            <table cellspacing="12">
                                <tr>
                                    <td>
                                        登录名：
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        真实名：
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        本次登陆时间：
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        本次登陆IP：
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div style="clear: both;padding-top:10px;">
                        <h3>
                            通知公告</h3>
                        <asp:GridView ID="gvwData" runat="server" AutoGenerateColumns="false" CssClass="table"
                            HorizontalAlign="Center">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1+pageSize*(pageIndex-1) %></ItemTemplate>
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
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="时间">
                                    <ItemTemplate>
                                        <%# Eval("createtime")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <a  data-options="plain:true" onclick="return addTab('查看公告','message/MessageShow.aspx?id=<%#Eval("id") %>')">
                                            查看</a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                没有返回任何数据！
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="table_head" />
                            <RowStyle HorizontalAlign="Center" />
                            <EmptyDataRowStyle Font-Size="16px" ForeColor="Red" Font-Bold="true" />
                        </asp:GridView>
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
                </div>
   
    
                                    </div>   
                                </div>

                            </div>



                            <!-- PAGE CONTENT ENDS -->
                        </div><!-- /.col -->
                    </div><!-- /.row -->
                </div><!-- /.page-content -->
            </div><!-- /.main-content -->

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

        </div><!-- /.main-container-inner -->

        <a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
            <i class="icon-double-angle-up icon-only bigger-110"></i>
        </a>
    </div><!-- /.main-container -->
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
   
    <script src="demo/assets/js/typeahead-bs2.min.js"></script>
   
    <!-- page specific plugin scripts -->
    <!--[if lte IE 8]>
      <script src="demo/assets/js/excanvas.min.js"></script>
    <![endif]-->
        
    <!-- ace scripts -->

    <script src="demo/assets/js/ace-elements.min.js"></script>
    <script src="demo/assets/js/ace.min.js"></script>

    <!-- inline scripts related to this page -->
   
      </form>
</body>
</html>
