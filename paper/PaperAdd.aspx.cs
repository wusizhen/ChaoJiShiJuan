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

public partial class paper_PaperAdd : System.Web.UI.Page
{
    tbPaperBLL paperBLL = new tbPaperBLL();
    int subjectid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                //int id = Convert.ToInt32(Request.QueryString["id"]);
                //paper = paperBLL.GetModel(id);
                //txtSubjectName.Text = paper.subjectname;
            }
            BindSubject();
            SetCount();
            BindRpt();
        }

        subjectid = Convert.ToInt32(ddlSubject.SelectedValue);
    }

    private void BindSubject()
    {
        ddlSubject.DataSource = MyUtil.GetMySubject();
        ddlSubject.DataTextField = "subjectname";
        ddlSubject.DataValueField = "id";
        ddlSubject.DataBind();
        subjectid = Convert.ToInt32(ddlSubject.SelectedValue);
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetCount();
    }

    protected void BindRpt()
    {
        rptSR.DataSource = PaperUtil.GetQuesCountDetail(subjectid, "tbSingle");
        rptSR.DataBind();
        rptCB.DataSource = PaperUtil.GetQuesCountDetail(subjectid, "tbCheck");
        rptCB.DataBind();
        rptBF.DataSource = PaperUtil.GetQuesCountDetail(subjectid, "tbBlank");
        rptBF.DataBind();
        rptJD.DataSource = PaperUtil.GetQuesCountDetail(subjectid, "tbJudge");
        rptJD.DataBind();
        rptSA.DataSource = PaperUtil.GetQuesCountDetail(subjectid, "tbAnswer");
        rptSA.DataBind();
    }
    /// <summary>
    /// 设置每种类型题目可选道数
    /// </summary>
    protected void SetCount()
    {
        lblSRAll.Text = PaperUtil.GetQuesCount(subjectid, "tbSingle").ToString();
        lblCBAll.Text = PaperUtil.GetQuesCount(subjectid, "tbCheck").ToString();
        lblJDAll.Text = PaperUtil.GetQuesCount(subjectid, "tbJudge").ToString();
        lblBFAll.Text = PaperUtil.GetQuesCount(subjectid, "tbBlank").ToString();
        lblSAAll.Text = PaperUtil.GetQuesCount(subjectid, "tbAnswer").ToString();
    }

    /// <summary>
    /// 收集各个Repeater中的数据，生成PaperSetting
    /// </summary>
    /// <returns>返回试卷详细设置对象</returns>
    protected tbPaper CollectPaperData()
    {
        tbPaper paper = new tbPaper();

        TextBox tempBox = null;
        HiddenField tempHf = null;
        try
        {
            paper.papertitle = txtPaperTitle.Text.Trim();
            paper.subjectid = Convert.ToInt32(ddlSubject.SelectedValue);
            paper.durationtime = Convert.ToInt32(ddlDurationTime.SelectedValue);
        }
        catch (Exception)
        {
            MyUtil.ShowMessage(this, "你填写的时间不正确！");
            return (tbPaper)null;
        }
        //遍历单选
        foreach (RepeaterItem item in rptSR.Items)
        {
            tempBox = (TextBox)(item.FindControl("txtSRChapterCount"));
            tempHf = (HiddenField)(item.FindControl("hfSRRange"));
            paper.sr_chapterrange += tempHf.Value + "|";
            paper.sr_countofeachchatper += tempBox.Text.Trim() + "|";
        }
        //去除最后一个“|”
        if (paper.sr_countofeachchatper != "" && paper.sr_countofeachchatper != null)
            paper.sr_countofeachchatper = paper.sr_countofeachchatper.TrimEnd('|');
        if (paper.sr_chapterrange != "" && paper.sr_chapterrange != null)
            paper.sr_chapterrange = paper.sr_chapterrange.TrimEnd('|');
        try
        {
            //填写数量
            paper.sr_count = Convert.ToInt32(txtSRCount.Text);
            //难度系数
            paper.sr_diff = Convert.ToInt32(ddlSRDiff.SelectedValue);
            //每题分数
            paper.sr_scoreofeach = Convert.ToInt32(ddlSRScore.SelectedValue);
        }
        catch (Exception)
        {
            MyUtil.ShowMessage(this, "你填写的单选题数据不正确！");
            return (tbPaper)null;
        }

        //遍历多选
        foreach (RepeaterItem item in rptCB.Items)
        {
            tempBox = (TextBox)(item.FindControl("txtCBChapterCount"));
            tempHf = (HiddenField)(item.FindControl("hfCBRange"));
            paper.cb_chapterrange += tempHf.Value + "|";
            paper.cb_countofeachchapter += tempBox.Text.Trim() + "|";
        }
        //去除最后一个“|”
        if (paper.cb_countofeachchapter != "" && paper.cb_countofeachchapter != null)
            paper.cb_countofeachchapter = paper.cb_countofeachchapter.TrimEnd('|');
        if (paper.cb_chapterrange != "" && paper.cb_chapterrange != null)
            paper.cb_chapterrange = paper.cb_chapterrange.TrimEnd('|');
        try
        {
            //填写数量
            paper.cb_count = Convert.ToInt32(txtCBCount.Text);
            //难度系数
            paper.cb_diff = Convert.ToInt32(ddlCBDiff.SelectedValue);
            //每题分数
            paper.cb_scoreofeach = Convert.ToInt32(ddlCBScore.SelectedValue);
        }
        catch (Exception)
        {
            MyUtil.ShowMessage(this, "你填写的多选题数据不正确！");
            return (tbPaper)null;
        }

        //遍历判断
        foreach (RepeaterItem item in rptJD.Items)
        {
            tempBox = (TextBox)(item.FindControl("txtJDChapterCount"));
            tempHf = (HiddenField)(item.FindControl("hfJDRange"));
            paper.jd_chapterrange += tempHf.Value + "|";
            paper.jd_countofeachchapter += tempBox.Text.Trim() + "|";
        }
        //去除最后一个“|”
        if (paper.jd_countofeachchapter != "" && paper.jd_countofeachchapter != null)
            paper.jd_countofeachchapter = paper.jd_countofeachchapter.TrimEnd('|');
        if (paper.jd_chapterrange != "" && paper.jd_chapterrange != null)
            paper.jd_chapterrange = paper.jd_chapterrange.TrimEnd('|');
        try
        {
            //填写数量
            paper.jd_count = Convert.ToInt32(txtJDCount.Text);
            //难度系数
            paper.jd_diff = Convert.ToInt32(ddlJDDiff.SelectedValue);
            //每题分数
            paper.jd_scoreofeach = Convert.ToInt32(ddlJDScore.SelectedValue);
        }
        catch (Exception)
        {
            MyUtil.ShowMessage(this, "你填写的判断题数据不正确！");
            return (tbPaper)null;
        }


        //遍历填空
        foreach (RepeaterItem item in rptBF.Items)
        {
            tempBox = (TextBox)(item.FindControl("txtBFChapterCount"));
            tempHf = (HiddenField)(item.FindControl("hfBFRange"));
            paper.bf_chapterrange += tempHf.Value + "|";
            paper.bf_countofeachchapter += tempBox.Text.Trim() + "|";
        }
        //去除最后一个“|”
        if (paper.bf_countofeachchapter != "" && paper.bf_countofeachchapter != null)
            paper.bf_countofeachchapter = paper.bf_countofeachchapter.TrimEnd('|');
        if (paper.bf_chapterrange != "" && paper.bf_chapterrange != null)
            paper.bf_chapterrange = paper.bf_chapterrange.TrimEnd('|');
        try
        {
            //填写数量
            paper.bf_count = Convert.ToInt32(txtBFCount.Text);
            //难度系数
            paper.bf_diff = Convert.ToInt32(ddlBFDiff.SelectedValue);
            //每题分数
            paper.bf_scoreofeach = Convert.ToInt32(ddlBFScore.SelectedValue);
        }
        catch (Exception)
        {
            MyUtil.ShowMessage(this, "你填写的填空题数据不正确！");
            return (tbPaper)null;
        }


        //遍历简答
        foreach (RepeaterItem item in rptSA.Items)
        {
            tempBox = (TextBox)(item.FindControl("txtSAChapterCount"));
            tempHf = (HiddenField)(item.FindControl("hfSARange"));
            paper.sa_chapterrange += tempHf.Value + "|";
            paper.sa_countofeachchapter += tempBox.Text.Trim() + "|";
        }
        //去除最后一个“|”
        if (paper.sa_countofeachchapter != "" && paper.sa_countofeachchapter != null)
            paper.sa_countofeachchapter = paper.sa_countofeachchapter.TrimEnd('|');
        if (paper.sa_chapterrange != "" && paper.sa_chapterrange != null)
            paper.sa_chapterrange = paper.sa_chapterrange.TrimEnd('|');
        try
        {
            //填写数量
            paper.sa_count = Convert.ToInt32(txtSACount.Text);
            //难度系数
            paper.sa_diff = Convert.ToInt32(ddlSADiff.SelectedValue);
            //每题分数
            paper.sa_scoreofeach = Convert.ToInt32(ddlSAScore.SelectedValue);
        }
        catch (Exception)
        {
            MyUtil.ShowMessage(this, "你填写的简答题数据不正确！");
            return (tbPaper)null;
        }
        return paper;
    }

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        tbPaper paper = CollectPaperData();

        //判断数据验证是否错误 
        if (paper != null)
        {
            paper.createtime = DateTime.Now;
            paper.papertype = 1;//随机试卷为1
            paper.userid = ((tbUser)Session[Constant.User]).id;
            paper.allscore = paper.sr_count * paper.sr_scoreofeach + paper.cb_count * paper.cb_scoreofeach + paper.jd_count * paper.jd_scoreofeach + paper.bf_count * paper.bf_scoreofeach + paper.sa_count * paper.sa_scoreofeach;
            paper.diff = (paper.sr_count * paper.sr_scoreofeach * paper.sr_diff + paper.cb_count * paper.cb_scoreofeach * paper.cb_diff + paper.jd_count * paper.jd_scoreofeach * paper.jd_diff + paper.bf_count * paper.bf_scoreofeach * paper.bf_diff + paper.sa_count * paper.sa_scoreofeach * paper.sa_diff) / paper.allscore;
            int sign = paperBLL.Add(paper);
            //调用BLL层
            if (sign != 0)
            {
                MyUtil.ShowMessageRedirect(this, "添加成功！", "PaperAdd.aspx");
            }
            else
            {
                MyUtil.ShowError(this, "发生错误！");
            }
        }
    }

    /// <summary>
    /// 单选题详细设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtSRSet_Click(object sender, EventArgs e)
    {
        lblSRSubject.Text = ddlSubject.SelectedItem.Text;
        lblSRCount.Text = txtSRCount.Text;

        MyUtil.ExecuteJS(this, "$(function(){show('viewSRTop');})");
    }
    /// <summary>
    /// 多选题详细设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtCBSet_Click(object sender, EventArgs e)
    {
        lblCBSubject.Text = ddlSubject.SelectedItem.Text;
        lblCBCount.Text = txtCBCount.Text;

        MyUtil.ExecuteJS(this, "$(function(){show('viewCBTop');})");
    }
    /// <summary>
    /// 填空题详细设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtBFSet_Click(object sender, EventArgs e)
    {
        lblBFSubject.Text = ddlSubject.SelectedItem.Text;
        lblBFCount.Text = txtBFCount.Text;

        MyUtil.ExecuteJS(this, "$(function(){show('viewBFTop');})");
    }
    /// <summary>
    ///判断题详细设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtJDSet_Click(object sender, EventArgs e)
    {
        lblJDSubject.Text = ddlSubject.SelectedItem.Text;
        lblJDCount.Text = txtJDCount.Text;

        MyUtil.ExecuteJS(this, "$(function(){show('viewJDTop');})");
    }
    /// <summary>
    /// 简答题详细设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtSASet_Click(object sender, EventArgs e)
    {
        lblSASubject.Text = ddlSubject.SelectedItem.Text;
        lblSACount.Text = txtSACount.Text;

        MyUtil.ExecuteJS(this, "$(function(){show('viewSATop');})");
    }


}
