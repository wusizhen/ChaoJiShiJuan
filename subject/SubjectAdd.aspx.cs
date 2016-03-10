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

public partial class subject_SubjectAdd : BasePage
{
    tbSubject subject = new tbSubject();
    tbSubjectBLL subjectBLL = new tbSubjectBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                subject = subjectBLL.GetModel(id);
                txtSubjectName.Text = subject.subjectname;
            }
        }
    }


    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        DataSet set = subjectBLL.GetList(" subjectname='" + txtSubjectName.Text.Trim() + "'");
        if (set.Tables[0].Rows.Count == 1)
        {
            lblInfo.Text = "已存在该科目！";
            lblInfo.Visible = true;
            return;
        }
        subject.subjectname = txtSubjectName.Text.Trim();

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            subject.id = id;
            subjectBLL.Update(subject);
            lblInfo.Text = "编辑成功！";
        }
        else
        {
            subjectBLL.Add(subject);
            lblInfo.Text = "添加成功！";
        }
        lblInfo.Visible = true;
        txtSubjectName.Text = "";
    }
}
