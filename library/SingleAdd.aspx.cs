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
    tbSingle single = new tbSingle();
    tbSingleBLL singleBLL = new tbSingleBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubject();
            BindChapter();
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                single = singleBLL.GetModel(id);
                txtQues.Text = single.ques;
                txtA.Text = single.option_a;
                txtB.Text = single.option_b;
                txtC.Text = single.option_c;
                txtD.Text = single.option_d;
                ddlDiff.ClearSelection();
                ddlDiff.Items.FindByValue(single.diff.ToString()).Selected = true;
                ddlAns.Items.FindByValue(single.ans.ToString()).Selected = true;
                ddlSubject.Items.FindByValue(MyUtil.GetSubjectIDbyChapterID(single.chapterid).ToString()).Selected = true;
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

        single.ques = txtQues.Text.Trim();
        single.ans = ddlAns.SelectedValue;
        single.chapterid = chapterid;
        single.option_a = txtA.Text.Trim();
        single.option_b = txtB.Text.Trim();
        single.option_c = txtC.Text.Trim();
        single.option_d = txtD.Text.Trim();
        single.diff = Convert.ToInt32(ddlDiff.SelectedValue);
        single.questype = 1;//随机类型

        if (DbHelperSQL.Exists("select * from tbSingle where ques='" + single.ques + "'") && Request.QueryString["id"]==null)
        {
            lblInfo.Text = "已存在该题目！";
            lblInfo.Visible = true;
            return;
        }        

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            single.id = id;
            singleBLL.Update(single);
            lblInfo.Text = "编辑成功！";
        }
        else
        {
            singleBLL.Add(single);
            lblInfo.Text = "添加成功！";
        }
        lblInfo.Visible = true;
        txtQues.Text = "";
        txtA.Text="";
        txtB.Text="";
        txtC.Text="";
        txtD.Text="";
    }
    

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindChapter();
    }
}
