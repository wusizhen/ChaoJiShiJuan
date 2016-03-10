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
    tbChapter chapter = new tbChapter();
    tbChapterBLL chapterBLL = new tbChapterBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubject();
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                chapter = chapterBLL.GetModel(id);
                txtChapterName.Text = chapter.chaptername;
                ddlSubject.Items.FindByValue(chapter.subjectid.ToString()).Selected = true;
                ddlChapterNO.Items.FindByValue(chapter.chapterno.ToString()).Selected = true;
            }
        }
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
        int subjectid=Convert.ToInt32(ddlSubject.SelectedValue);
        int chapterno=Convert.ToInt32(ddlChapterNO.SelectedValue);
        String chapterName=txtChapterName.Text.Trim();

        if (DbHelperSQL.Exists("select * from tbChapter where subjectid=" + subjectid + " and chapterno=" + chapterno) && Request.QueryString["id"]==null)
        {
            lblInfo.Text = "已存在该章节！";
            lblInfo.Visible = true;
            return;
        }
        chapter.chapterno = chapterno;
        chapter.subjectid = subjectid;
        chapter.chaptername = txtChapterName.Text.Trim();

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            chapter.id = id;
            chapterBLL.Update(chapter);
            lblInfo.Text = "编辑成功！";
        }
        else
        {
            chapterBLL.Add(chapter);
            lblInfo.Text = "添加成功！";
        }
        lblInfo.Visible = true;
        txtChapterName.Text = "";
    }
}
