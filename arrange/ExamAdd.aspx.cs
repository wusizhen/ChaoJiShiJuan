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
    tbArrange arrange = new tbArrange();
    tbArrangeBLL arrangeBLL = new tbArrangeBLL();
    tbPaperBLL paperBLL = new tbPaperBLL();
    tbScoreDAL scoreDAL = new tbScoreDAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubject();
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                arrange = arrangeBLL.GetModel(id);
                txtArrangeName.Text = arrange.arrangetitle;
                txtStartTime.Text = arrange.starttime.ToString("yyyy-MM-dd HH:mm");
                txtEndTime.Text = arrange.endtime.ToString("yyyy-MM-dd HH:mm");

                ddlSubject.Items.FindByValue(arrange.subjectid.ToString()).Selected = true;
                ddlSubject.Enabled = false;
                BindPaper();
                ddlPaper.Items.FindByValue(arrange.paperid.ToString()).Selected = true;
                ddlPaper.Enabled = false;
            }
        }
    }

    private void BindSubject()
    {
        ddlSubject.DataSource = MyUtil.GetMySubject();
        ddlSubject.DataTextField = "subjectname";
        ddlSubject.DataValueField = "id";
        ddlSubject.DataBind();
        ddlSubject.Items.Insert(0, new ListItem("选择科目", "0"));
    }

    private void BindPaper()
    {
        if (ddlSubject.SelectedValue != "0")
        {
            ddlPaper.DataSource = paperBLL.GetList("subjectid=" + ddlSubject.SelectedValue + " and userid=" + ((tbUser)Session[Constant.User]).id);
            ddlPaper.DataTextField = "papertitle";
            ddlPaper.DataValueField = "id";
            ddlPaper.DataBind();
        }
        ddlPaper.Items.Insert(0, new ListItem("选择试卷", "0"));
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPaper();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {

        DateTime start = Convert.ToDateTime(txtStartTime.Text);
        DateTime end = Convert.ToDateTime(txtEndTime.Text);

        if (start.CompareTo(end) >= 0)
        {
            lblInfo.Text = "开始时间不能早于结束时间！";
            lblInfo.Visible = true;
            return;
        }
        if (end.CompareTo(DateTime.Now) <= 0)
        {
            lblInfo.Text = "截止时间不能早于现在时间！";
            lblInfo.Visible = true;
            return;
        }
        arrange.starttime = start;
        arrange.endtime = end;
        arrange.arrangetitle = txtArrangeName.Text.Trim();
        arrange.subjectid = Convert.ToInt32(ddlSubject.SelectedValue);
        arrange.paperid = Convert.ToInt32(ddlPaper.SelectedValue);
        arrange.arrangetype = 2;//考试
        arrange.userid = ((tbUser)Session[Constant.User]).id;

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            arrange.id = id;
            arrangeBLL.Update(arrange);
            lblInfo.Text = "编辑成功！";
        }
        else
        {
            int arrangeid = arrangeBLL.Add(arrange);
            int userid = ((tbUser)Session[Constant.User]).id;//老师id
            int subjectid = Convert.ToInt32(ddlSubject.SelectedValue);//科目id
            int hasShortAnswer = 0;
            if (paperBLL.GetModel(arrange.paperid).sa_count!= 0)
            {
                hasShortAnswer = 1;//有简答题
            }
            //为该考试安排添加学生记录
            AddStudentRecord(arrangeid, userid, subjectid, hasShortAnswer);
            lblInfo.Text = "添加成功！";
        }
        lblInfo.Visible = true;
        txtArrangeName.Text = "";
        txtEndTime.Text = "";
        txtStartTime.Text = "";
    }

    private void AddStudentRecord(int arrangeid, int userid, int subjectid, int hasShortAnswer)
    {
        //查询所有要进行该考试的学生
        String strSql = "select id from tbUser where classid in (select classid from tbGrant where userid=" + userid + " and subjectid=" + subjectid + ")";
        DataTable table = DbHelperSQL.Query(strSql).Tables[0];

        //取得数据库连接
        SqlConnection conn = SQLHelper.GetConnection();
        //打开数据库连接
        conn.Open();
        //创建事务
        SqlTransaction SqlTransaction = conn.BeginTransaction();

        try
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                tbScore score = new tbScore();
                score.arrangeid = arrangeid;
                score.userid = Convert.ToInt32(table.Rows[i][0]);
                score.createtime = DateTime.Now;
                score.starttime = DateTime.Now;
                score.endtime = DateTime.Now;
                score.hasshortanswer = hasShortAnswer;
                score.hascorrect = 0;//没有批改
                score.scorestatus = 1;//还没考试
                scoreDAL.AddTran(score, SqlTransaction);
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
            throw;
        }
        finally
        {
            //关闭各种资源
            SqlTransaction.Dispose();
            conn.Close();
        }
    }
}
