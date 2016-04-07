<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Examing.aspx.cs"
    Inherits="student_Examing" Title="无标题页" %>

<%@ Import Namespace="Model" %>
<!doctype html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <!--禁止缩放，启动响应式-->
    <link rel="stylesheet" href="../demo/bootstrap/css/bootstrap.min.css">
    <!-- mystyle.css-->
    <link rel="stylesheet" href="../demo/assets/css/mystyle.css" />
    <!--[if IE 7]>
		  <link rel="stylesheet" href="../demo/assets/css/font-awesome-ie7.min.css" />
		<![endif]-->


    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="../demo/assets/css/ace-ie.min.css" />
		<![endif]-->

    <!--[if lt IE 9]>
		<script src="../demo/assets/js/html5shiv.js"></script>
		<script src="../demo/assets/js/respond.min.js"></script>
		<![endif]-->

    <!--conutdown-->

    <title>在线考试</title>
    <style>
        body {
            position: relative;
            padding-top: 10px;
            background-color: #f5f5f5;
        }


        .timer {
            text-align: center;
            margin: 30px auto 0;
            padding: 0 0 10px;
            border-bottom: 2px solid #99CC33;
        }

            .timer .table-cell {
                display: inline-block;
                margin: 0 5px;
                width: 50px;
                background: url(../demo/countdown/images/timer.png) no-repeat 0 0;
            }

                .timer .table-cell .tab-val {
                    font-size: 35px;
                    color: #99CC33;
                    height: 81px;
                    line-height: 81px;
                    margin: 0 0 5px;
                }

                .timer .table-cell .tab-metr {
                    font-family: Arial;
                    font-size: 12px;
                    text-transform: uppercase;
                }

        #simple_timer.timer .table-cell.day,
        #periodic_timer_days.timer .table-cell.hour {
            width: 120px;
            background-image: url(../demo/countdown/images/timer_long.png);
        }

        #span1 {
            float: left;
            padding-top: 10px;
        }

        #oe_box {
            margin: 0px auto;
            font-size: 16px;
            line-height: 20px;
            margin-top: 6px;
            float: left;
            padding-left: 30px;
            width: 90%;
            color: Black;
        }

        .paperTitle {
            font-weight: bold;
            text-align: center;
            width: 100%;
        }

        #timer {
            position: fixed;
            top: 250px;
            right: 5px;
            font-size: 25px;
            color: Green;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            z-index: 100;
            font-weight: bold;
            line-height: 30px;
            text-align: center;
            width: auto;
        }

        .questionZone {
        }

        .oe_title {
            color: #333333;
            font-weight: bold;
            margin-left: 0px;
            line-height: 35px;
        }

        .oe_item {
            margin-top: 10px;
            margin-left: 18px;
        }

        .tda, .tdb {
            padding-left: 25px;
            line-height: 28px;
        }

            .tda:hover, .tdb:hover {
                font-weight: 100;
                cursor: pointer;
            }

        .oe_bfText {
            border-left-width: 0px;
            border-right-width: 0px;
            border-top-width: 0px;
            border-bottom: solid 1px #333333;
        }

        .oe_filter {
            background: #A1A1A1;
            filter: Alpha(Opacity=50);
        }

        #submiting {
            width: 200px;
            background-color: White;
            position: fixed;
            top: 30%;
            left: 45%;
            border: solid 2px #757415;
            text-align: center;
        }
    </style>
    <script type="text/jscript">
        var maxtime = 5;
        function setTimer(i) {
            maxtime = i * 60;
        }
        function Pause(obj, iMinSecond) {
            if (window.eventList == null) window.eventList = new Array();
            var ind = -1;
            for (var i = 0; i < window.eventList.length; i++) {
                if (window.eventList[i] == null) {
                    window.eventList[i] = obj;
                    ind = i;
                    break;
                }
            }
            if (ind == -1) {
                ind = window.eventList.length;
                window.eventList[ind] = obj;
            }
            setTimeout("GoOn(" + ind + ")", 3000);
        }
        function GoOn(ind) {
            var obj = window.eventList[ind];
            window.eventList[ind] = null;
            if (obj.NextStep) obj.NextStep();
            else obj();
        }
        function CountDown() {
            if (maxtime >= 0) {
                minutes = Math.floor(maxtime / 60);
                seconds = Math.floor(maxtime % 60);
                if (seconds < 10)
                    seconds = "0" + seconds;
                if (minutes < 10)
                    minutes = "0" + minutes;
                msg = minutes + ":" + seconds;
                document.getElementById("time_show").innerHTML = msg;
                if (maxtime == 5 * 60) {
                    document.getElementById("time_show").style.color = "Red"
                }
                --maxtime;
            } else {
                clearInterval(timer);
                document.getElementById("main").className = "oe_filter";
                document.getElementById("submiting").style.display = "block";
                Pause(this, 3000);
                this.NextStep = function () {
                    document.getElementById('<%=btnAuto.ClientID %>').click();
                }
            }
        }
        function manual() {
            if (confirm('你确定要交卷吗？')) {
                clearInterval(timer);
                document.getElementById("main").className = "oe_filter";
                document.getElementById("submiting").style.display = "block";
                Pause(this, 3000);
                this.NextStep = function () {
                    return true;
                }
            } else {
                return false;
            }
        }
        timer = setInterval("CountDown()", 1000);
    </script>
</head>


<body>
    <form id="form1" runat="server">
        <!--<div id="timer">
            存放时间（old）
        </div>-->
        <div>

            <div id="oe_box">
                <!--新版考试头-->
                <div class="container-head">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2 class="exam-h2"><%=arrange.arrangetitle%>
                                <small>科目：<%=subject.subjectname %>&nbsp;&nbsp;&nbsp;&nbsp;时长：<%=paper.durationtime %>分钟</small></h2>
                            <script type="text/jscript">
                                setTimer(<%=paper.durationtime %>);
                            </script>
                        </div>
                        <div class="panel-body">
                            <div class="mychoice">
                                <p>总分 <%=paper.allscore %> 分 ，请在 ：<%=paper.durationtime %> 分钟内作答 。</p>
                            </div>
                            <div id="testpaper-navbar" class="testpaper-navbar affix-top" data-spy="affix" data-offset-top="200">
                                <ul class="nav nav-pills clearfix">
                                    <li class="active">
                                        <a href="#single">单选题</a></li>
                                    <li><a href="#double">多选题</a></li>
                                    <li><a href="#judge">判断题</a></li>
                                    <li><a href="#answer">问答题</a></li>
                                    <li><a href="#cailiao">简答题</a></li>
                                </ul>
                            </div>

                        </div>
                    </div>
                </div>
                <!--new头以外的全部-->
                <div class="row">
                    <!--5试题存放处-->
                    <div class="col-sm-9 col-xs-7" id="panel-right">
                        <!--单选-->
                        <div id="single">
                            <div class="panel panel-default">
                                <!-- 添加选择题-->
                                <asp:Repeater ID="rptSR" runat="server">
                                    <HeaderTemplate>
                                        <div class="panel-heading">
                                            <h4><%=GetIndex() %>、单项选择
                <small>(共<%=paper.sr_count%>小题：每小题<%=paper.sa_scoreofeach%>分，满分<%=paper.sr_count * paper.sa_scoreofeach%>分)</small></h4>
                                        </div>
                                        <div class="panel-body">
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <div class="testpaper-question-stem-wrap clearfix">
                                            <div class="testpaper-question-seq-wrap">
                                                <div class="testpaper-question-seq"><%#Container.ItemIndex+1 %></div>
                                                <div class="testpaper-question-score"><%=paper.sa_scoreofeach%>分</div>
                                            </div>
                                            <div class="testpaper-question-stem">
                                                <p class="MsoNormal">
                                                    <br>
                                                        <%# ((tbSingle)Container.DataItem).ques %></br>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="testpaper-question-choices">
                                            <ul>
                                                <li>
                                                    <strong>A.</strong><asp:RadioButton ID="rbtnA" runat="server" Text='<%# ((tbSingle)Container.DataItem).option_a %>'
                                                        GroupName="<%# ((tbSingle)Container.DataItem).id %>" />
                                                </li>
                                                <li>
                                                    <strong>B.</strong><asp:RadioButton ID="rbtnB" runat="server" Text='<%# ((tbSingle)Container.DataItem).option_b %>'
                                                        GroupName="<%# ((tbSingle)Container.DataItem).id %>" />
                                                </li>
                                                <li>
                                                    <strong>C.</strong><asp:RadioButton ID="rbtnC" runat="server" Text='<%# ((tbSingle)Container.DataItem).option_c %>'
                                                        GroupName="<%# ((tbSingle)Container.DataItem).id %>" />
                                                </li>
                                                <li>
                                                    <strong>D.</strong><asp:RadioButton ID="rbtnD" runat="server" Text='<%# ((tbSingle)Container.DataItem).option_d %>'
                                                        GroupName="<%# ((tbSingle)Container.DataItem).id %>" />
                                                </li>
                                            </ul>
                                            <asp:HiddenField ID="hfSR" runat="server" Value="<%# ((tbSingle)Container.DataItem).id %>" />
                                        </div>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <br />
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <!--多选-->
                        <div id="double">
                            <div class="panel panel-default">
                                <!-- 添加选择题-->
                                <asp:Repeater ID="rptCB" runat="server" OnItemDataBound="rptCB_ItemDataBound">
                                    <HeaderTemplate>
                                        <div class="panel-heading">
                                            <h4><%=GetIndex() %>、多项选择
                <small>(共<%=paper.cb_count%>小题：每小题<%=paper.cb_scoreofeach %>分，满分<%=paper.cb_count * paper.cb_scoreofeach%>分)</small></h4>
                                        </div>
                                        <div class="panel-body">
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <div class="testpaper-question-stem-wrap clearfix">
                                            <div class="testpaper-question-seq-wrap">
                                                <div class="testpaper-question-seq"><%#Container.ItemIndex+1 %></div>
                                                <div class="testpaper-question-score"><%=paper.cb_scoreofeach %>分</div>
                                            </div>
                                            <div class="testpaper-question-stem">
                                                <p class="MsoNormal">
                                                    <br>
                                                        <%# ((tbCheck)Container.DataItem).ques %></br>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="testpaper-question-choices">
                                            <ul>
                                                <li>
                                                    <strong>A.</strong><asp:CheckBox ID="chkA" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_a %>' />
                                                </li>
                                                <li>
                                                    <strong>B.</strong><asp:CheckBox ID="chkB" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_b %>' />
                                                </li>
                                                <li>
                                                    <strong>C.</strong><asp:CheckBox ID="chkC" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_c %>' />
                                                </li>
                                                <li>
                                                    <strong>D.</strong><asp:CheckBox ID="chkD" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_d %>' /></li>
                                                <li runat="server" id="liE" visible="false">
                                                    <strong>
                                                        <asp:Label ID="lblE" runat="server" Text="E." Visible="false"></asp:Label><asp:CheckBox ID="chkE" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_e %>' Visible="false" /></strong></li>
                                                <li runat="server" id="liF" visible="false">
                                                    <strong>
                                                        <asp:Label ID="lblF" runat="server" Text="F." Visible="false"></asp:Label><asp:CheckBox ID="chkF" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_f %>' Visible="false" /></strong></li>
                                                <li runat="server" id="liG" visible="false">
                                                    <stron>
                                                        <asp:Label ID="lblG" runat="server" Text="G." Visible="false"></asp:Label><asp:CheckBox ID="chkG" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_g %>' Visible="false" />
                                                    </strong></li>
                                            </ul>
                                            <asp:HiddenField ID="hfCB" runat="server" Value="<%# ((tbCheck)Container.DataItem).id %>" />
                                        </div>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <br />
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <!--判断-->
                        <div id="judge">
                            <div class="panel panel-default">
                                <!-- 添加选择题-->
                                <asp:Repeater ID="rptJD" runat="server">
                                    <HeaderTemplate>
                                        <div class="panel-heading">
                                            <h4><%=GetIndex() %>、判断题
                <small>(共<%=paper.jd_count%>小题：每小题<%=paper.jd_scoreofeach%>分，满分<%=paper.jd_count * paper.jd_scoreofeach%>分)</small></h4>
                                        </div>
                                        <div class="panel-body">
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <div class="testpaper-question-stem-wrap clearfix">
                                            <div class="testpaper-question-seq-wrap">
                                                <div class="testpaper-question-seq"><%#Container.ItemIndex+1 %></div>
                                                <div class="testpaper-question-score"><%=paper.jd_scoreofeach%>分</div>
                                            </div>
                                            <div class="testpaper-question-stem">
                                                <p class="MsoNormal">
                                                    <br>
                                                        <%# ((tbJudge)Container.DataItem).ques%></br>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="testpaper-question-choices">
                                            <ul>
                                                <li>
                                                    <asp:RadioButton ID="rbtnRight" runat="server" GroupName="<%# ((tbJudge)Container.DataItem).id %>" Text="对　　　　　　　　　　　　　　　　　　　　" /></li>
                                                <li>
                                                    <asp:RadioButton ID="rbtnWrong" runat="server" GroupName="<%# ((tbJudge)Container.DataItem).id %>" Text="错　　　　　　　　　　　　　　　　　　　　" /></li>

                                            </ul>
                                            <asp:HiddenField ID="hfJD" runat="server" Value="<%# ((tbJudge)Container.DataItem).id %>" />
                                        </div>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <br />
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <!--填空-->
                        <div id="answer">
                            <div class="panel panel-default">
                                <!-- 添加选择题-->
                                <asp:Repeater ID="rptBF" runat="server">
                                    <HeaderTemplate>
                                        <div class="panel-heading">
                                            <h4><%=GetIndex() %>、填空题
                <small>(共<%=paper.bf_count%>小题：每小题<%=paper.bf_scoreofeach%>分，满分<%=paper.bf_count * paper.bf_scoreofeach%>分)</small></h4>
                                        </div>
                                        <div class="panel-body">
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <div class="testpaper-question-stem-wrap clearfix">
                                            <div class="testpaper-question-seq-wrap">
                                                <div class="testpaper-question-seq"><%#Container.ItemIndex+1 %></div>
                                                <div class="testpaper-question-score"><%=paper.bf_scoreofeach%>分</div>
                                            </div>
                                            <div class="testpaper-question-stem">
                                                <p class="MsoNormal">
                                                    <br>
                                                        <%# GetBFFront(((tbBlank)Container.DataItem).ques)%>
                                                        <asp:TextBox ID="txtBF" runat="server" CssClass="oe_bfText" Width='<%#((tbBlank)Container.DataItem).blanklength*40%>'></asp:TextBox>
                                                        <%# GetBFAfter(((tbBlank)Container.DataItem).ques)%></br>
                                                    <asp:Label ID="lblBFAnswer" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                                </p>
                                                <asp:HiddenField ID="hfBF" runat="server" Value="<%# ((tbBlank)Container.DataItem).id %>" />
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <br />
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <!--简答-->
                        <div id="cailiao">
                            <div class="panel panel-default">
                                <!-- 添加选择题-->
                                <asp:Repeater ID="rptSA" runat="server">
                                    <HeaderTemplate>
                                        <div class="panel-heading">
                                            <h4><%=GetIndex() %>、简答题
                <small>(共<%=paper.sa_count%>小题：每小题<%=paper.sa_scoreofeach%>分，满分<%=paper.sa_count * paper.sa_scoreofeach%>分)</small></h4>
                                        </div>
                                        <div class="panel-body">
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <div class="testpaper-question-stem-wrap clearfix">
                                            <div class="testpaper-question-seq-wrap">
                                                <div class="testpaper-question-seq"><%#Container.ItemIndex+1 %></div>
                                                <div class="testpaper-question-score"><%=paper.sa_scoreofeach%>分</div>
                                            </div>
                                            <div class="testpaper-question-stem">
                                                <p class="MsoNormal">
                                                    <br>
                                                        <%# ((tbAnswer)Container.DataItem).ques %></br>
                                                </p>

                                            </div>
                                        </div>
                                        <div class="testpaper-question-choices">
                                            <asp:TextBox ID="txtAnswer" Style="border: solid 1px #cccccc;" runat="server" TextMode="MultiLine"
                                                Rows="15" Columns="90" EnableTheming="false"></asp:TextBox>
                                            <asp:HiddenField ID="hfSA" runat="server" Value="<%# ((tbAnswer)Container.DataItem).id %>" />
                                        </div>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <br />
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>


                        <!--计时器 时间-->

                    </div>

                   
                </div>
                 
            </div>
        </div>
        </div></div>

        <div class="col-sm-3 col-xs-5">
                        <div class="testpaper-card affix-top" data-spy="affix" data-offset-top="200" data-offset-bottom="200">
                            <div class="panel-heading">
                                <span class=" testpaper-card-timer" id="time_show">　</span>
                                <button class="btn btn-sm btn-default pull-right" id="suspend">下次再做</button>
                                <button id="pause" class="btn btn-sm btn-default pull-right" data-toggle="modal" data-backdrop="static" data-target="#modal">暂停</button>
                            </div>

                            <div class="panel-footer">

                                <asp:LinkButton ID="lbtnSubmit" runat="server" CssClass="btn btn-success btn-block do-test"
                                    OnClick="btnSubmit_Click" OnClientClick="return manual();">交卷</asp:LinkButton>
                                <div style="display: none;">
                                    <asp:Button ID="btnAuto" runat="server" Text="" OnClick="btnSubmit_Click" />
                                </div>
                                <asp:LinkButton ID="lbtnBack" runat="server" CssClass="btn btn-success btn-block do-test"
                                    OnClick="btnBack_Click" Visible="false">关闭并返回</asp:LinkButton>
                            </div>
                        </div>

                    </div>
        <!--旧版从此处开始添加-->



        <div style="height: 20px;">
        </div>
        <div style="display: none;" id="submiting">
            <img src="img/loading.gif" alt="" /><br />
            正在提交……
        </div>



        <script type="text/javascript">
            //$(function(){ $("body").attr("onselectstart","return false");$("body").attr("oncontextmenu","self.event.returnValue=false");});            
        </script>


    </form>
    <script src="../demo/bootstrap/js/jquery-1.11.1.min.js"></script>
    <script src="../demo/bootstrap/js/bootstrap.min.js"></script>

    <!--conutdown-->
    <script src="../demo/countdown/js/jquery.syotimer.js"></script>


    <script type="text/javascript">
        //侧边栏固定
        var Getid = function (id) {
            return document.getElementById(id);
        }
        var addEvent = function (obj, event, fun) {
            if (obj, addEventListener) {
                obj.addEventListener(event, fun, false);
            } else if (obj.attachEvent()) {
                obj.attachEvent("on" + event, fun)
            }

        }

        var lnSider = Getid("rightside");
        addEvent(window, "scroll", function () {
            //scrollTop兼容性问题
            var scrollHeight = document.documentElement.scrollTop == 0 ? document.body.scrollTop : document.documentElement.scrollTop;
            // console.log(scrollHeight);
            var contentHeight = Getid("panel-right").offsetHeight - lnSider.offsetHeight;
            // console.log(contentHeight);
            if (scrollHeight > 14 && scrollHeight < contentHeight + 14) {
                lnSider.style.position = "absolute";

                lnSider.style.width = "90%";
                lnSider.style.left = "15px";
                lnSider.style.top = scrollHeight - 14 + "px";
            } else if (scrollHeight <= 14) {
                lnSider.style.position = "absolute";
                lnSider.style.width = "90%";
                lnSider.style.left = "15px";
                lnSider.style.top = "0px";
            }
        });

        //countdown
        var myDate = new Date();
        var myyear = myDate.getFullYear();
        var mymonth = myDate.getMonth();
        var myday = myDate.getDate();
        var myhour = myDate.getHours();
        var mymin = myDate.getMinutes();
        var mysec = myDate.getSeconds();
        //console.log(myyear);
        //console.log(mymonth);
        $('#simple_timer').syotimer({
            year: myyear,
            month: mymonth + 1,
            day: myday,
            hour: myhour,
            minute: mymin + 1,
            second: mysec,
            dayVisible: false,
            headTitle: '<h3>考试剩余时间</h3>',


            dubleNumbers: false,
            effectType: 'opacity',

            periodUnit: 'm',
            periodic: false,
            periodInterval: 3,
        });


        //倒计时结束后触发的事件
        function done() {
            var str = $('#simple_timer').text();
            var out = str.match(/\d+/g);//正则表达式 /d匹配数字 +匹配至少一个 /g全局匹配 匹配一个字数字符，/\d/ = /[0-9]/
            //console.log(out); 
            var h = parseInt(out[0]), m = parseInt(out[1]), s = parseInt(out[2]);
            //console.log(h+'#'+m+'#'+s);
            var calc = h * 3600 + m * 60 + s;
            //console.log(calc); 
            if (calc == 0) {
                //事件

                alert("结束");
            }
            /*else{
            console.log('等待..');
            } 
            */
            var t = setTimeout('done()', 1000);
        }
        done();

    </script>
</body>
</html>
