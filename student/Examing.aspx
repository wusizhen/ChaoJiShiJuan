<%@ Page Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeFile="Examing.aspx.cs" Inherits="student_Examing" Title="无标题页" %>

<%@ Import Namespace="Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #span1
        {
            float: left;
            padding-top: 10px;
        }
        #oe_box
        {
            margin: 0px auto;
            font-size: 16px;
            line-height: 20px;
            margin-top: 6px;
            float: left;
            padding-left: 30px;
            width: 90%;
            color: Black;
        }
        .paperTitle
        {
            font-weight: bold;
            text-align: center;
            width: 100%;
        }
        #timer
        {
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
        .questionZone
        {
        }
        .oe_title
        {
            color: #333333;
            font-weight: bold;
            margin-left: 0px;
            line-height: 35px;
        }
        .oe_item
        {
            margin-top: 10px;
            margin-left: 18px;
        }
        .tda, .tdb
        {
            padding-left: 25px;
            line-height: 28px;
        }
        .tda:hover, .tdb:hover
        {
            font-weight: 100;
            cursor: pointer;
        }
        .oe_bfText
        {
            border-left-width: 0px;
            border-right-width: 0px;
            border-top-width: 0px;
            border-bottom: solid 1px #333333;
        }
        .oe_filter
        {
            background: #A1A1A1;
            filter: Alpha(Opacity=50);
        }
        #submiting
        {
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
        var maxtime=5;
        function setTimer(i)
        {
           maxtime=i*60;
        }
        function Pause(obj,iMinSecond){
　　     if (window.eventList==null) window.eventList=new Array();
　　     var ind=-1;
　　     for (var i=0;i<window.eventList.length;i++){
　　      if (window.eventList[i]==null) {
　　       window.eventList[i]=obj;
　　       ind=i;
　　       break;
　　      }
　　     }    　　 
　　     if (ind==-1){
　　      ind=window.eventList.length;
　　      window.eventList[ind]=obj;
　　     }
　　     setTimeout("GoOn(" + ind + ")",3000);
　　    }
       function GoOn(ind){
　　     var obj=window.eventList[ind];
　　     window.eventList[ind]=null;
　　     if (obj.NextStep) obj.NextStep();
　　     else obj();
　　    }
        function CountDown(){   
            if(maxtime>=0){   
                minutes = Math.floor(maxtime/60);   
                seconds = Math.floor(maxtime%60); 
                if(seconds<10)
                   seconds="0"+seconds; 
                if(minutes<10)
                   minutes="0"+minutes; 
                msg ="剩余时间<BR/>"+ minutes+":"+seconds;   
                document.getElementById("timer").innerHTML=msg;   
                if(maxtime == 5*60)
                {
                   document.getElementById("timer").style.color="Red"
                }   
                --maxtime;   
            }else{   
               clearInterval(timer);   
               document.getElementById("main").className="oe_filter";
               document.getElementById("submiting").style.display="block";
               Pause(this,3000);
　　             this.NextStep=function(){
                   document.getElementById('<%=btnAuto.ClientID %>').click();　　              
　　           }               
            }   
        } 
        function manual()
        {
           if(confirm('你确定要交卷吗？'))
           {
               clearInterval(timer);   
               document.getElementById("main").className="oe_filter";
               document.getElementById("submiting").style.display="block";
                Pause(this,3000);
　　             this.NextStep=function(){
                   return true;             
　　             }    
           }else
           {
               return false;
           }
        }  
        timer = setInterval("CountDown()",1000);
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="oe_box">
        <div id="timer">
        </div>
        <div class="paperTitle">
            <div style="font-size: 30px; padding-top: 5px; padding-bottom: 5px; text-align: center;">
                <%=arrange.arrangetitle%>
            </div>
            <div style="height: 10px;">
            </div>
            <div style="padding-bottom: 5px; text-align: center; font-size: 20px;">
                科目：<%=subject.subjectname %>&nbsp;&nbsp;&nbsp;&nbsp;时长：<%=paper.durationtime %>分钟
            </div>

            <script type="text/jscript">
                          setTimer(<%=paper.durationtime %>);
            </script>

        </div>
        <div style="height: 10px;">
        </div>
        <div class="questionZone">
            <asp:Repeater ID="rptSR" runat="server">
                <HeaderTemplate>
                    <div class="oe_title">
                        <%=GetIndex() %>、单项选择(共<%=paper.sr_count%>小题：每小题<%=paper.sa_scoreofeach%>分，满分<%=paper.sr_count * paper.sa_scoreofeach%>分)</div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="oe_item">
                        <%#Container.ItemIndex+1 %>.&nbsp;<%# ((tbSingle)Container.DataItem).ques %><br />
                        <table>
                            <tr>
                                <td class="tda">
                                    A:<asp:RadioButton ID="rbtnA" runat="server" Text='<%# ((tbSingle)Container.DataItem).option_a %>'
                                        GroupName="<%# ((tbSingle)Container.DataItem).id %>" /><br />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdb">
                                    B:<asp:RadioButton ID="rbtnB" runat="server" Text='<%# ((tbSingle)Container.DataItem).option_b %>'
                                        GroupName="<%# ((tbSingle)Container.DataItem).id %>" /><br />
                                </td>
                            </tr>
                            <tr>
                                <td class="tda">
                                    C:<asp:RadioButton ID="rbtnC" runat="server" Text='<%# ((tbSingle)Container.DataItem).option_c %>'
                                        GroupName="<%# ((tbSingle)Container.DataItem).id %>" /><br />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdb">
                                    D:<asp:RadioButton ID="rbtnD" runat="server" Text='<%# ((tbSingle)Container.DataItem).option_d %>'
                                        GroupName="<%# ((tbSingle)Container.DataItem).id %>" /><br />
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hfSR" runat="server" Value="<%# ((tbSingle)Container.DataItem).id %>" />
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <br />
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="questionZone">
            <asp:Repeater ID="rptCB" runat="server" onitemdatabound="rptCB_ItemDataBound">
                <HeaderTemplate>
                    <div class="oe_title">
                        <%=GetIndex() %>、多项选择(共<%=paper.cb_count%>小题：每小题<%=paper.cb_scoreofeach %>分，满分<%=paper.cb_count * paper.cb_scoreofeach%>分)</div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="oe_item">
                        <%#Container.ItemIndex+1 %>.&nbsp;<%# ((tbCheck)Container.DataItem).ques %><br />
                        <table>
                            <tr>
                                <td class="tda">
                                    A:<asp:CheckBox ID="chkA" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_a %>' /><br />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdb">
                                    B:<asp:CheckBox ID="chkB" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_b %>' /><br />
                                </td>
                            </tr>
                            <tr>
                                <td class="tda">
                                    C:<asp:CheckBox ID="chkC" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_c %>' /><br />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdb">
                                    D:<asp:CheckBox ID="chkD" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_d %>' /><br />
                                </td>
                            </tr>
                            <tr>
                                <td class="tda">
                                    <asp:Label ID="lblE" runat="server" Text="E:" Visible="false" ></asp:Label><asp:CheckBox ID="chkE" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_e %>' Visible="false"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdb">
                                    <asp:Label ID="lblF" runat="server" Text="F:" Visible="false"></asp:Label><asp:CheckBox ID="chkF" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_f %>' Visible="false"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="tda">
                                    <asp:Label ID="lblG" runat="server" Text="G:" Visible="false"></asp:Label><asp:CheckBox ID="chkG" runat="server" Text='<%# ((tbCheck)Container.DataItem).option_g %>' Visible="false"/>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hfCB" runat="server" Value="<%# ((tbCheck)Container.DataItem).id %>" />
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <br />
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="questionZone">
            <asp:Repeater ID="rptJD" runat="server">
                <HeaderTemplate>
                    <div class="oe_title">
                        <%=GetIndex() %>、判断题(共<%=paper.jd_count%>小题：每小题<%=paper.jd_scoreofeach%>分，满分<%=paper.jd_count * paper.jd_scoreofeach%>分)</div>
                    <table>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="tda">
                            <%#Container.ItemIndex+1 %>.&nbsp;<%# ((tbJudge)Container.DataItem).ques%><br />
                        </td>
                        <td class="tdb">
                            <asp:RadioButton ID="rbtnRight" runat="server" GroupName="<%# ((tbJudge)Container.DataItem).id %>"
                                Text="对" />
                            <asp:RadioButton ID="rbtnWrong" runat="server" GroupName="<%# ((tbJudge)Container.DataItem).id %>"
                                Text="错" />
                            <asp:HiddenField ID="hfJD" runat="server" Value="<%# ((tbJudge)Container.DataItem).id %>" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                    <br />
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="questionZone">
            <asp:Repeater ID="rptBF" runat="server">
                <HeaderTemplate>
                    <div class="oe_title">
                        <%=GetIndex() %>、填空题(共<%=paper.bf_count%>小题：每小题<%=paper.bf_scoreofeach%>分，满分<%=paper.bf_count * paper.bf_scoreofeach%>分)</div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="tda">
                        <%#Container.ItemIndex+1 %>.&nbsp;
                        <%# GetBFFront(((tbBlank)Container.DataItem).ques)%>
                        <asp:TextBox ID="txtBF" runat="server" CssClass="oe_bfText" Width='<%#((tbBlank)Container.DataItem).blanklength*40%>'></asp:TextBox>
                        <%# GetBFAfter(((tbBlank)Container.DataItem).ques)%>
                        <asp:Label ID="lblBFAnswer" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                        <asp:HiddenField ID="hfBF" runat="server" Value="<%# ((tbBlank)Container.DataItem).id %>" />
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <br />
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="questionZone">
            <asp:Repeater ID="rptSA" runat="server">
                <HeaderTemplate>
                    <div class="oe_title">
                        <%=GetIndex() %>、简答题(共<%=paper.sa_count%>小题：每小题<%=paper.sa_scoreofeach%>分，满分<%=paper.sa_count * paper.sa_scoreofeach%>分)</div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="tda">
                        <%#Container.ItemIndex+1 %>.&nbsp;
                        <%# ((tbAnswer)Container.DataItem).ques %><br />
                        <asp:TextBox ID="txtAnswer" Style="border: solid 1px #cccccc;" runat="server" TextMode="MultiLine"
                            Rows="6" Columns="60" EnableTheming="false"></asp:TextBox>
                        <asp:HiddenField ID="hfSA" runat="server" Value="<%# ((tbAnswer)Container.DataItem).id %>" />
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <br />
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div style="text-align: center;">
            <asp:LinkButton ID="lbtnSubmit" runat="server" CssClass="easyui-linkbutton" data-options="iconCls:'icon-ok'"
                OnClick="btnSubmit_Click" OnClientClick="return manual();">交卷</asp:LinkButton>
        </div>
        <div style="display: none;">
            <asp:Button ID="btnAuto" runat="server" Text="" OnClick="btnSubmit_Click" />
        </div>
        <div style="text-align: center;">
            <asp:LinkButton ID="lbtnBack" runat="server" CssClass="easyui-linkbutton" data-options="iconCls:'icon-back'"
                OnClick="btnBack_Click" Visible="false">关闭并返回</asp:LinkButton>
        </div>
        <div style="height: 20px;">
        </div>
        <div style="display: none;" id="submiting">
            <img src="img/loading.gif" alt="" /><br />
            正在提交……
        </div>
    </div>

    <script type="text/javascript">
        //$(function(){ $("body").attr("onselectstart","return false");$("body").attr("oncontextmenu","self.event.returnValue=false");});            
    </script>

</asp:Content>
