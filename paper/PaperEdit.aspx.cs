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
    tbPaper paper = new tbPaper();
    tbPaperBLL paperBLL = new tbPaperBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            paper = paperBLL.GetModel(id);
            txtPaperTitle.Text = paper.papertitle;
            txtDuration.Text = paper.durationtime.ToString();
        }
    }


    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        paper = paperBLL.GetModel(id);
        paper.papertitle = txtPaperTitle.Text.Trim();
        paper.durationtime = Convert.ToInt32(txtDuration.Text);
        paperBLL.Update(paper);

        lblInfo.Text = "编辑成功！";
        lblInfo.Visible = true;
        
    }
}
