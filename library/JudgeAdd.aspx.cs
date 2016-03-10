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
using DAL;
using Maticsoft.DBUtility;

public partial class subject_SubjectAdd : BasePage
{
    tbJudge judge = new tbJudge();
    tbJudgeBLL judgeBLL = new tbJudgeBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubject();
            BindChapter();
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                judge = judgeBLL.GetModel(id);
                txtQues.Text = judge.ques;
                ddlDiff.ClearSelection();
                ddlDiff.Items.FindByValue(judge.diff.ToString()).Selected = true;
                ddlAns.Items.FindByValue(judge.ans.ToString()).Selected = true;
                ddlSubject.Items.FindByValue(MyUtil.GetSubjectIDbyChapterID(judge.chapterid).ToString()).Selected = true;
            }
        }
    }

    private void BindChapter()
    {
        ddlChapter.DataSource = DbHelperSQL.Query("select * from tbChapter where subjectid=" + ddlSubject.SelectedValue);
        ddlChapter.DataTextField = "chaptername";
        ddlChapter.DataValueField = "id";
        ddlChapter.DataBind();
    }

    private void BindSubject()
    {
        ddlSubject.DataSource = MyUtil.GetMySubject();
        ddlSubject.DataTextField = "subjectname";
        ddlSubject.DataValueField = "id";
        ddlSubject.DataBind();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        int chapterid=Convert.ToInt32(ddlChapter.SelectedValue);

        judge.ques = txtQues.Text.Trim();
        judge.ans = ddlAns.SelectedValue;
        judge.chapterid = chapterid;
        judge.diff = Convert.ToInt32(ddlDiff.SelectedValue);
        judge.questype = 1;//随机类型

        if (DbHelperSQL.Exists("select * from tbJudge where ques='" + judge.ques + "'") && Request.QueryString["id"]==null)
        {
            lblInfo.Text = "已存在该题目！";
            lblInfo.Visible = true;
            return;
        }        

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            judge.id = id;
            judgeBLL.Update(judge);
            lblInfo.Text = "编辑成功！";
        }
        else
        {
            judgeBLL.Add(judge);
            lblInfo.Text = "添加成功！";
        }
        lblInfo.Visible = true;
        txtQues.Text = "";
    }
    

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindChapter();
    }
}
