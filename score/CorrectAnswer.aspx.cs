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
using Util;
using Model;
using BLL;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using DAL;

public partial class subject_SubjectAdd : BasePage
{
    tbAnswerOfPaperDAL answerOfPaperDAL = new tbAnswerOfPaperDAL();
    tbScoreDAL scoreDAL = new tbScoreDAL();
    int arrangeid;

    protected void Page_Load(object sender, EventArgs e)
    {
        arrangeid = Convert.ToInt32(Request.QueryString["id"]);
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        DataSet set = this.GetOneRecord(arrangeid);
        if (set != null)
        {
            //保存tbAnswerOfPaper.id userid
            ViewState["answerofpaperid"] = set.Tables[0].Rows[0]["id"].ToString();
            ViewState["userid"] = set.Tables[0].Rows[0]["userid"].ToString();

            lblArrange.Text = set.Tables[0].Rows[0]["arrangetitle"].ToString();
            lblSubject.Text = set.Tables[0].Rows[0]["subjectname"].ToString();
            lblUser.Text = set.Tables[0].Rows[0]["realname"].ToString();
            lblQues.Text = set.Tables[0].Rows[0]["ques"].ToString();
            txtStandard.Text = set.Tables[0].Rows[0]["ans"].ToString();
            txtStudent.Text = set.Tables[0].Rows[0]["useranswer"].ToString();
            lblAllScore.Text = set.Tables[0].Rows[0]["allscore"].ToString();

            int allscore = Convert.ToInt32(lblAllScore.Text);
            ddlGetScore.Items.Clear();
            for (int i = 0; i <= allscore; i++)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                ddlGetScore.Items.Add(li);
            }
        }
        else
        {
            //暂无批改
            lblInfo.Text = "暂无批改或已经批改完！";
            lblInfo.Visible = true;
            lbtnAdd.Enabled = false;
        }
    }

    private DataSet GetOneRecord(int arrangeid)
    {
        String strSql = "select top 1 tbAnswerOfPaper.*,arrangetitle,subjectname,tbAnswer.ques,tbAnswer.ans,tbUser.realname from tbAnswerOfPaper,tbArrange,tbAnswer,tbSubject,tbUser where tbAnswerOfPaper.arrangeid=tbArrange.id and tbArrange.subjectid=tbSubject.id and tbAnswerOfPaper.answerid=tbAnswer.id and tbAnswerOfPaper.userid=tbUser.id and getscore=-1 and tbAnswerOfPaper.arrangeid=" + arrangeid;
        DataSet set = DbHelperSQL.Query(strSql);
        if (set.Tables[0].Rows.Count == 0)
        {
            return null;
        }
        else
        {
            return set;
        }
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        int answerofpaperid = Convert.ToInt32(ViewState["answerofpaperid"].ToString());
        int userid = Convert.ToInt32(ViewState["userid"].ToString());

        tbAnswerOfPaper model = answerOfPaperDAL.GetModel(answerofpaperid);
        model.getscore = Convert.ToDecimal(ddlGetScore.SelectedValue);
        answerOfPaperDAL.Update(model);
        //判断这个学生的简答题是否全部改完
        if (!DbHelperSQL.Exists("select * from tbAnswerOfPaper where arrangeid=" + arrangeid + " and userid=" + userid + " and getscore=-1"))
        {
            //批改完毕
            double sum = (double)DbHelperSQL.GetSingle("select sum(getscore) from tbAnswerOfPaper where arrangeid=" + arrangeid + " and userid=" + userid);
            int scoreid = (int)DbHelperSQL.GetSingle("select id from tbScore where arrangeid=" + arrangeid + " and userid=" + userid);
            tbScore score = scoreDAL.GetModel(scoreid);
            score.hascorrect = 1;
            score.scorestatus = 3;
            score.score +=Convert.ToDecimal(sum);
            scoreDAL.Update(score);
        }
        BindData();
    }

}
