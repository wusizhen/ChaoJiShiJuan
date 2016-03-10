using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BLL;
using Model;
using System.Data.SqlClient;
using DAL;
using Util;
using Maticsoft.DBUtility;

public partial class student_Examing : System.Web.UI.Page
{
    int arrangeid;
    int index = 0;
    float sum = 0;//总分
    public tbArrange arrange;
    public tbPaper paper;
    public tbSubject subject;
    public PaperContent pc;
    public tbScore score;
    tbArrangeBLL arrangeBLL = new tbArrangeBLL();
    tbPaperBLL paperBLL = new tbPaperBLL();
    tbSubjectBLL subjectBLL = new tbSubjectBLL();
    tbScoreBLL scoreBLL = new tbScoreBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        arrangeid = Convert.ToInt32(Request.QueryString["id"]);
        arrange = arrangeBLL.GetModel(arrangeid);
        paper = paperBLL.GetModel(arrange.paperid);
        subject = subjectBLL.GetModel(arrange.subjectid);

        if (!IsPostBack)
        {
            //取得数据库连接
            SqlConnection conn = SQLHelper.GetConnection();
            //打开数据库连接
            conn.Open();
            //创建事务
            SqlTransaction SqlTransaction = conn.BeginTransaction();

            try
            {
                PaperGenerateDAL pgd = new PaperGenerateDAL(paper, SqlTransaction);
                pc = pgd.GetPaperContent();
                SqlTransaction.Commit();
            }
            catch (Exception)
            {
                try
                {
                    SqlTransaction.Rollback();
                }
                catch (Exception)
                {
                    //事务回滚出错
                }
            }
            finally
            {
                //关闭各种资源
                SqlTransaction.Dispose();
                conn.Close();
            }
            if (arrange.arrangetype == 2)
            {
                //考试，记录考试时间，成绩状态
                tbUser user = (tbUser)Session[Constant.User];
                tbScore score = this.GetScore(arrangeid, user.id);
                score.starttime = DateTime.Now;
                score.scorestatus = 2;//正在考试
                scoreBLL.Update(score);

                //把scoreid存放在ViewState
                ViewState[Constant.ScoreID] = score.id;
            }
            if (pc.SRContent.Count != 0)
            {
                rptSR.DataSource = pc.SRContent;
                rptSR.DataBind();
            }

            if (pc.CBContent.Count != 0)
            {
                rptCB.DataSource = pc.CBContent;
                rptCB.DataBind();
            }

            if (pc.JDContent.Count != 0)
            {
                rptJD.DataSource = pc.JDContent;
                rptJD.DataBind();
            }

            if (pc.BFContent.Count != 0)
            {
                rptBF.DataSource = pc.BFContent;
                rptBF.DataBind();
            }

            if (pc.SAContent.Count != 0)
            {
                rptSA.DataSource = pc.SAContent;
                rptSA.DataBind();
            }
        }
    }

    /// <summary>
    /// 题目标题序号
    /// </summary>
    /// <returns></returns>
    protected String GetIndex()
    {
        index++;
        switch (index)
        {
            case 1: return "一";
            case 2: return "二";
            case 3: return "三";
            case 4: return "四";
            case 5: return "五";
        }
        return "";
    }

    /// <summary>
    /// 取得填空题的前半部分
    /// </summary>
    /// <param name="question"></param>
    /// <returns></returns>
    protected String GetBFFront(String question)
    {
        return question.Substring(0, question.IndexOf("{0}"));
    }

    /// <summary>
    /// 取得填空题的后半部分
    /// </summary>
    /// <param name="question"></param>
    /// <returns></returns>
    protected String GetBFAfter(String question)
    {
        return question.Substring(question.IndexOf("{0}") + 3);
    }

    /// <summary>
    /// 交卷
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //比较时间大小
        int scoreid = Convert.ToInt32(ViewState[Constant.ScoreID]);
        score = scoreBLL.GetModel(scoreid);

        PaperContent studentAnswer = CollectData();
        PaperContent standardAnswer = GetStandardAnswer(studentAnswer);

        if (arrange.arrangetype == 1)
        {
            //===============练习
            ShowCorrectAnswer(studentAnswer, standardAnswer);
            MyUtil.ExecuteJS(this, "clearInterval(timer);document.getElementById('timer').style.display='none';");
        }
        if (arrange.arrangetype == 2)
        {
            //===============考试
            score.endtime = DateTime.Now;
            if (DateTime.Compare(DateTime.Now, score.starttime.AddMinutes(paper.durationtime + 5)) > 0)
            {
                //超时
                MyUtil.ExecuteJS(this, "alert('交卷失败，超过指定时间！');top.closeExam();");
                score.scorestatus = 4;
                scoreBLL.Update(score);
                return;
            }
            score.score = Convert.ToDecimal(sum);
            if (paper.sa_count > 0)
            {
                //有简答题，等待批改
                score.scorestatus = 5;
            }
            else
            {
                //记录成绩
                score.scorestatus = 3;
            }
            scoreBLL.Update(score);
            //MyUtil.ExecuteJS(this, "alert('交卷成功！');top.closeExam();");
            Response.Write("<script type='text/javascript'>alert('交卷成功！');top.closeExam();</script>");
        }
        lbtnSubmit.Visible = false;
        lbtnBack.Visible = true;
    }

    /// <summary>
    /// 返回成绩菜单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        MyUtil.ExecuteJS(this, "top.closeExercise();");
    }

    /// <summary>
    /// 收集数据
    /// </summary>
    /// <returns></returns>
    private PaperContent CollectData()
    {
        PaperContent studentAnswer = new PaperContent();

        //单选题
        foreach (RepeaterItem item in rptSR.Items)
        {
            tbSingle sr = new tbSingle();

            sr.id = Convert.ToInt32(((HiddenField)item.FindControl("hfSR")).Value);

            if (((RadioButton)item.FindControl("rbtnA")).Checked)
            {
                sr.ans = "A";
                studentAnswer.SRContent.Add(sr);
                continue;
            }
            if (((RadioButton)item.FindControl("rbtnB")).Checked)
            {
                sr.ans = "B";
                studentAnswer.SRContent.Add(sr);
                continue;
            }
            if (((RadioButton)item.FindControl("rbtnC")).Checked)
            {
                sr.ans = "C";
                studentAnswer.SRContent.Add(sr);
                continue;
            }
            if (((RadioButton)item.FindControl("rbtnD")).Checked)
            {
                sr.ans = "D";
                studentAnswer.SRContent.Add(sr);
                continue;
            }
            //没选
            studentAnswer.SRContent.Add(sr);
        }

        //多选题
        foreach (RepeaterItem item in rptCB.Items)
        {
            tbCheck cb = new tbCheck();

            cb.id = Convert.ToInt32(((HiddenField)item.FindControl("hfCB")).Value);

            cb.ans = "";
            if (((CheckBox)item.FindControl("chkA")).Checked)
            {
                cb.ans += "A";
            }
            if (((CheckBox)item.FindControl("chkB")).Checked)
            {
                cb.ans += "B";
            }
            if (((CheckBox)item.FindControl("chkC")).Checked)
            {
                cb.ans += "C";
            }
            if (((CheckBox)item.FindControl("chkD")).Checked)
            {
                cb.ans += "D";
            }
            if (((CheckBox)item.FindControl("chkE")).Checked)
            {
                cb.ans += "E";
            }
            if (((CheckBox)item.FindControl("chkF")).Checked)
            {
                cb.ans += "F";
            }
            if (((CheckBox)item.FindControl("chkG")).Checked)
            {
                cb.ans += "G";
            }
            studentAnswer.CBContent.Add(cb);
        }

        //判断题
        foreach (RepeaterItem item in rptJD.Items)
        {
            tbJudge jd = new tbJudge();

            jd.id = Convert.ToInt32(((HiddenField)item.FindControl("hfJD")).Value);

            if (((RadioButton)item.FindControl("rbtnRight")).Checked)
            {
                jd.ans = "对";
                studentAnswer.JDContent.Add(jd);
                continue;
            }
            if (((RadioButton)item.FindControl("rbtnWrong")).Checked)
            {
                jd.ans = "错";
                studentAnswer.JDContent.Add(jd);
            }
            //没选
            studentAnswer.JDContent.Add(jd);
        }

        //填空题
        foreach (RepeaterItem item in rptBF.Items)
        {
            tbBlank bf = new tbBlank();

            bf.id = Convert.ToInt32(((HiddenField)item.FindControl("hfBF")).Value);

            bf.ans = ((TextBox)item.FindControl("txtBF")).Text.Trim();
            studentAnswer.BFContent.Add(bf);

        }

        //简答题
        foreach (RepeaterItem item in rptSA.Items)
        {
            tbAnswer sa = new tbAnswer();

            sa.id = Convert.ToInt32(((HiddenField)item.FindControl("hfSA")).Value);

            sa.ans = ((TextBox)item.FindControl("txtAnswer")).Text.Trim();
            studentAnswer.SAContent.Add(sa);
        }
        return studentAnswer;
    }

    /// <summary>
    /// 显示答案
    /// </summary>
    /// <param name="studentAnswer"></param>
    /// <param name="standardAnswer"></param>
    private void ShowCorrectAnswer(PaperContent studentAnswer, PaperContent standardAnswer)
    {
        //单选题
        for (int i = 0; i < rptSR.Items.Count; i++)
        {
            if (!(studentAnswer.SRContent[i].ans == standardAnswer.SRContent[i].ans))
            {
                //做错了
                switch (standardAnswer.SRContent[i].ans)
                {
                    case "A": ((RadioButton)rptSR.Items[i].FindControl("rbtnA")).ForeColor = System.Drawing.Color.Red; ((RadioButton)rptSR.Items[i].FindControl("rbtnA")).Font.Bold = true; break;
                    case "B": ((RadioButton)rptSR.Items[i].FindControl("rbtnB")).ForeColor = System.Drawing.Color.Red; ((RadioButton)rptSR.Items[i].FindControl("rbtnB")).Font.Bold = true; break;
                    case "C": ((RadioButton)rptSR.Items[i].FindControl("rbtnC")).ForeColor = System.Drawing.Color.Red; ((RadioButton)rptSR.Items[i].FindControl("rbtnC")).Font.Bold = true; break;
                    case "D": ((RadioButton)rptSR.Items[i].FindControl("rbtnD")).ForeColor = System.Drawing.Color.Red; ((RadioButton)rptSR.Items[i].FindControl("rbtnD")).Font.Bold = true; break;
                }
            }
        }

        //多选题
        for (int i = 0; i < rptCB.Items.Count; i++)
        {
            String answer = standardAnswer.CBContent[i].ans;
            if (!(studentAnswer.CBContent[i].ans == answer))
            {
                //做错了
                if (answer.Contains("A"))
                {
                    ((System.Web.UI.WebControls.CheckBox)rptCB.Items[i].FindControl("chkA")).ForeColor = System.Drawing.Color.Red;
                    ((System.Web.UI.WebControls.CheckBox)rptCB.Items[i].FindControl("chkA")).Font.Bold = true;
                }
                if (answer.Contains("B"))
                {
                    ((System.Web.UI.WebControls.CheckBox)rptCB.Items[i].FindControl("chkB")).ForeColor = System.Drawing.Color.Red;
                    ((System.Web.UI.WebControls.CheckBox)rptCB.Items[i].FindControl("chkB")).Font.Bold = true;
                }
                if (answer.Contains("C"))
                {
                    ((System.Web.UI.WebControls.CheckBox)rptCB.Items[i].FindControl("chkC")).ForeColor = System.Drawing.Color.Red;
                    ((System.Web.UI.WebControls.CheckBox)rptCB.Items[i].FindControl("chkC")).Font.Bold = true;
                }
                if (answer.Contains("D"))
                {
                    ((System.Web.UI.WebControls.CheckBox)rptCB.Items[i].FindControl("chkD")).ForeColor = System.Drawing.Color.Red;
                    ((System.Web.UI.WebControls.CheckBox)rptCB.Items[i].FindControl("chkD")).Font.Bold = true;
                }
            }
        }

        //判断题
        for (int i = 0; i < rptJD.Items.Count; i++)
        {
            String answer = standardAnswer.JDContent[i].ans;
            if (!(studentAnswer.JDContent[i].ans == answer))
            {
                //做错了
                if (answer == "对")
                {
                    ((RadioButton)rptJD.Items[i].FindControl("rbtnRight")).ForeColor = System.Drawing.Color.Red;
                    ((RadioButton)rptJD.Items[i].FindControl("rbtnRight")).Font.Bold = true;
                }
                else
                {
                    ((RadioButton)rptJD.Items[i].FindControl("rbtnWrong")).ForeColor = System.Drawing.Color.Red;
                    ((RadioButton)rptJD.Items[i].FindControl("rbtnWrong")).Font.Bold = true;
                }
            }
        }

        //填空题
        for (int i = 0; i < rptBF.Items.Count; i++)
        {
            String answer = standardAnswer.BFContent[i].ans;
            if (!(studentAnswer.BFContent[i].ans == answer))
            {
                Label txtBFAnswer = (Label)rptBF.Items[i].FindControl("lblBFAnswer");
                txtBFAnswer.Text = "(" + answer + ")";
                txtBFAnswer.Visible = true;
                txtBFAnswer.Font.Bold = true;
            }
        }

        //简答题
        for (int i = 0; i < rptSA.Items.Count; i++)
        {
            String answer = standardAnswer.SAContent[i].ans;
            if (!(studentAnswer.SAContent[i].ans == answer))
            {
                TextBox txtAnswer = (TextBox)rptSA.Items[i].FindControl("txtAnswer");
                txtAnswer.Text = studentAnswer.SAContent[i].ans + "(参考答案：" + answer + ")";
            }
        }
    }

    /// <summary>
    /// 获取正确答案，计算分数，更新题库selectcount和rightcount
    /// </summary>
    /// <param name="studentAnswer"></param>
    /// <returns></returns>
    private PaperContent GetStandardAnswer(PaperContent studentAnswer)
    {
        PaperContent standardAnswer = new PaperContent();

        tbSingleDAL singleDAL = new tbSingleDAL();
        tbCheckDAL checkDAL = new tbCheckDAL();
        tbJudgeDAL judgeDAL = new tbJudgeDAL();
        tbBlankDAL blankDAL = new tbBlankDAL();
        tbAnswerDAL answerDAl = new tbAnswerDAL();
        tbAnswerOfPaperDAL answerOfPaperDAL = new tbAnswerOfPaperDAL();

        //取得数据库连接
        SqlConnection conn = SQLHelper.GetConnection();
        //打开数据库连接
        conn.Open();
        //创建事务
        SqlTransaction SqlTransaction = conn.BeginTransaction();

        try
        {
            //单选
            foreach (tbSingle item in studentAnswer.SRContent)
            {
                tbSingle single = singleDAL.GetModelTran(item.id, SqlTransaction);
                single.selectcount = single.selectcount + 1;
                if (single.ans == item.ans)
                {
                    //正确
                    sum += paper.sa_scoreofeach;
                    single.rightcount = single.rightcount + 1;
                }
                standardAnswer.SRContent.Add(single);
                singleDAL.UpdateTran(single, SqlTransaction);
            }
            //多选
            foreach (tbCheck item in studentAnswer.CBContent)
            {
                tbCheck check = new tbCheckDAL().GetModelTran(item.id, SqlTransaction);
                check.selectcount = check.selectcount + 1;
                if (check.ans == item.ans)
                {
                    //正确
                    sum += paper.cb_scoreofeach;
                    check.rightcount = check.rightcount + 1;
                }
                standardAnswer.CBContent.Add(check);
                checkDAL.UpdateTran(check, SqlTransaction);
            }
            //判断
            foreach (tbJudge item in studentAnswer.JDContent)
            {
                tbJudge judge = new tbJudgeDAL().GetModelTran(item.id, SqlTransaction);
                judge.selectcount = judge.selectcount + 1;
                if (judge.ans == item.ans)
                {
                    //正确
                    sum += paper.jd_scoreofeach;
                    judge.rightcount = judge.rightcount + 1;
                }
                standardAnswer.JDContent.Add(judge);
                judgeDAL.UpdateTran(judge, SqlTransaction);
            }
            //填空
            foreach (tbBlank item in studentAnswer.BFContent)
            {
                tbBlank blank = new tbBlankDAL().GetModelTran(item.id, SqlTransaction);
                blank.selectcount = blank.selectcount + 1;
                if (blank.ans == item.ans)
                {
                    //正确
                    sum += paper.bf_scoreofeach;
                    blank.rightcount = blank.rightcount + 1;
                }
                standardAnswer.BFContent.Add(blank);
                blankDAL.UpdateTran(blank, SqlTransaction);
            }
            //简答题 不比较答案，但返回正确答案 并记录学生答案
            foreach (tbAnswer item in studentAnswer.SAContent)
            {
                tbAnswer answer = new tbAnswerDAL().GetModelTran(item.id, SqlTransaction);
                standardAnswer.SAContent.Add(answer);
                if (arrange.arrangetype == 2)
                {
                    //插入学生答案
                    tbAnswerOfPaper answerOfPaper = new tbAnswerOfPaper();
                    answerOfPaper.answerid = answer.id;
                    answerOfPaper.arrangeid = arrange.id;
                    answerOfPaper.useranswer = item.ans;
                    answerOfPaper.userid = score.userid;
                    answerOfPaper.allscore = paper.sa_scoreofeach;
                    answerOfPaper.getscore = -1;//还没批改
                    
                    //删除已存在的
                    String deleteSql = "delete from tbAnswerOfPaper where answerid=" + answerOfPaper.answerid + " and arrangeid=" + answerOfPaper.arrangeid + " and userid=" + answerOfPaper.userid;
                    SqlHelper.ExecuteNonQuery(SqlTransaction, CommandType.Text, deleteSql);

                    answerOfPaperDAL.AddTran(answerOfPaper, SqlTransaction);
                }
            }
            SqlTransaction.Commit();
        }
        catch (Exception)
        {
            try
            {
                SqlTransaction.Rollback();
            }
            catch (Exception)
            {
                //事务回滚出错
            }
        }
        finally
        {
            //关闭各种资源
            SqlTransaction.Dispose();
            conn.Close();
        }
        return standardAnswer;
    }

    /// <summary>
    /// 根据arrangeid和userid获取Score对象
    /// </summary>
    /// <param name="arrangeid"></param>
    /// <param name="userid"></param>
    /// <returns></returns>
    private tbScore GetScore(int arrangeid, int userid)
    {
        String strSql = "select id from tbScore where arrangeid=" + arrangeid + " and userid=" + userid;
        return scoreBLL.GetModel((int)DbHelperSQL.GetSingle(strSql));
    }

    /// <summary>
    /// 多选题控制选项
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptCB_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            CheckBox chkE = (CheckBox)e.Item.FindControl("chkE");
            Label lblE = (Label)e.Item.FindControl("lblE");
            if (chkE.Text != "")
            {
                chkE.Visible = true;
                lblE.Visible = true;
            }

            CheckBox chkF = (CheckBox)e.Item.FindControl("chkF");
            Label lblF = (Label)e.Item.FindControl("lblF");
            if (chkF.Text != "")
            {
                chkF.Visible = true;
                lblF.Visible = true;
            }

            CheckBox chkG = (CheckBox)e.Item.FindControl("chkG");
            Label lblG = (Label)e.Item.FindControl("lblG");
            if (chkG.Text != "")
            {
                chkG.Visible = true;
                lblG.Visible = true;
            }
        }
    }
}
