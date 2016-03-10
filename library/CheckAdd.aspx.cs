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
    tbCheck check = new tbCheck();
    tbCheckBLL checkBLL = new tbCheckBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubject();
            BindChapter();
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                check = checkBLL.GetModel(id);
                txtQues.Text = check.ques;
                txtA.Text = check.option_a;
                txtB.Text = check.option_b;
                txtC.Text = check.option_c;
                txtD.Text = check.option_d;
                txtE.Text = check.option_e;
                txtF.Text = check.option_f;
                txtG.Text = check.option_g;
                ddlDiff.ClearSelection();
                ddlDiff.Items.FindByValue(check.diff.ToString()).Selected = true;
                txtAns.Text = check.ans;
                ddlSubject.Items.FindByValue(MyUtil.GetSubjectIDbyChapterID(check.chapterid).ToString()).Selected = true;
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
        int chapterid = Convert.ToInt32(ddlChapter.SelectedValue);

        check.ques = txtQues.Text.Trim();
        check.ans = txtAns.Text.Trim();
        check.chapterid = chapterid;
        check.option_a = txtA.Text.Trim();
        check.option_b = txtB.Text.Trim();
        check.option_c = txtC.Text.Trim();
        check.option_d = txtD.Text.Trim();
        check.option_e = txtE.Text.Trim();
        check.option_f = txtF.Text.Trim();
        check.option_g = txtG.Text.Trim();
        check.diff = Convert.ToInt32(ddlDiff.SelectedValue);
        check.questype = 1;//随机类型

        if (DbHelperSQL.Exists("select * from tbCheck where ques='" + check.ques + "'") && Request.QueryString["id"] == null)
        {
            lblInfo.Text = "已存在该题目！";
            lblInfo.Visible = true;
            return;
        }

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            check.id = id;
            checkBLL.Update(check);
            lblInfo.Text = "编辑成功！";
        }
        else
        {
            checkBLL.Add(check);
            lblInfo.Text = "添加成功！";
        }
        lblInfo.Visible = true;
        txtQues.Text = "";
        txtA.Text = "";
        txtB.Text = "";
        txtC.Text = "";
        txtD.Text = "";
        txtE.Text = "";
        txtF.Text = "";
        txtG.Text = "";
    }


    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindChapter();
    }
}
