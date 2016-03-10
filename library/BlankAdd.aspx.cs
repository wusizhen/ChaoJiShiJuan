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
    tbBlank blank = new tbBlank();
    tbBlankBLL blankBLL = new tbBlankBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubject();
            BindChapter();
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                blank = blankBLL.GetModel(id);
                txtQues.Text = blank.ques;
                ddlDiff.ClearSelection();
                ddlDiff.Items.FindByValue(blank.diff.ToString()).Selected = true;
                txtAns.Text = blank.ans;
                ddlSubject.Items.FindByValue(MyUtil.GetSubjectIDbyChapterID(blank.chapterid).ToString()).Selected = true;
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

        blank.ques = txtQues.Text.Trim();
        blank.ans = txtAns.Text.Trim();
        blank.chapterid = chapterid;
        blank.diff = Convert.ToInt32(ddlDiff.SelectedValue);
        blank.questype = 1;//随机类型
        blank.blanklength = blank.ans.Length;

        if (blank.ques.IndexOf("{0}") < 0)
        {
            lblInfo.Text = "问题没有分隔符！";
            lblInfo.Visible = true;
            return;
        }
        if (DbHelperSQL.Exists("select * from tbBlank where ques='" + blank.ques + "'") && Request.QueryString["id"]==null)
        {
            lblInfo.Text = "已存在该题目！";
            lblInfo.Visible = true;
            return;
        }        

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            blank.id = id;
            blankBLL.Update(blank);
            lblInfo.Text = "编辑成功！";
        }
        else
        {
            blankBLL.Add(blank);
            lblInfo.Text = "添加成功！";
        }
        lblInfo.Visible = true;
        txtQues.Text = "";
        txtAns.Text = "";
    }
    

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindChapter();
    }
}
