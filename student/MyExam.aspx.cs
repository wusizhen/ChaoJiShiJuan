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
using DAL;
using BLL;
using Model;
using System.Text;

public partial class subject_SubjectList : BasePage
{
    tbArrangeBLL arrangeBLL = new tbArrangeBLL();
    tbUser user;
    public String editString = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(hfPageIndex.Value))
        {
            pageIndex = Convert.ToInt32(hfPageIndex.Value);
        }
        if (!String.IsNullOrEmpty(hfPageSize.Value))
        {
            pageSize = Convert.ToInt32(hfPageSize.Value);
        }
        user = (tbUser)Session[Constant.User];
        if (!IsPostBack)
        {
            BindSubject();
            BindData();
        }
    }

    private void BindSubject()
    {
        ddlSubject.DataSource = MyUtil.GetMySubject();
        ddlSubject.DataTextField = "subjectname";
        ddlSubject.DataValueField = "id";
        ddlSubject.DataBind();
        ddlSubject.Items.Insert(0, new ListItem("所有科目", "0"));
    }

    protected void BindData()
    {
        pageTotal = MyUtil.GetCount("tbScore,tbArrange,tbSubject,tbPaper", "tbScore.arrangeid=tbArrange.id and tbArrange.paperid=tbPaper.id and tbArrange.subjectid=tbSubject.id", GetWhereSql());
        gvwData.DataSource = MyUtil.GetListByIndex(pageSize, pageIndex, "tbScore.scorestatus,tbArrange.*,tbSubject.subjectname,tbPaper.durationtime", "tbScore,tbArrange,tbSubject,tbPaper", "tbScore.arrangeid=tbArrange.id and tbArrange.paperid=tbPaper.id and tbArrange.subjectid=tbSubject.id", GetWhereSql(), "tbScore.id desc");
        gvwData.DataKeyNames = new String[] { "id" };
        gvwData.DataBind();
    }

    private String GetWhereSql()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" tbScore.userid=" + user.id + " and tbArrange.arrangetype=2");
        if (ddlSubject.SelectedValue != "0")
        {
            sb.Append(" and tbArrange.subjectid=" + ddlSubject.SelectedValue);
        }
        return sb.ToString();
    }

    /// <summary>
    /// 分页事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnHide_Click(object sender, EventArgs e)
    {
        BindData();
    }


    /// <summary>
    /// 按照条件搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }

    /// <summary>
    /// 编辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        int id = Convert.ToInt32(lbtn.CommandArgument);
        MyUtil.ExecuteJS(this, "$(function(){top.addTabNoClose('正在考试','student/Examing.aspx?id=" + id + "');top.closeMyExam();})");
        BindData();
    }

    protected void gvwData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbtn = (LinkButton)e.Row.FindControl("lbtnEdit");
            switch (DataBinder.Eval(e.Row.DataItem, "scorestatus").ToString())
            {
                case "1":
                    e.Row.Cells[6].Text = "还没考试";
                    break;
                case "2":
                    e.Row.Cells[6].Text = "正在考试";
                    lbtn.Enabled=false;
                    lbtn.Text = "已考";
                    break;
                case "3":
                    e.Row.Cells[6].Text = "考试成功";
                    lbtn.Enabled=false;
                    lbtn.Text = "已考";
                    break;
                case "4":
                    e.Row.Cells[6].Text = "考试失败";
                    lbtn.Enabled=false;
                    lbtn.Text = "已考";
                    break;
                case "5":
                    e.Row.Cells[6].Text = "等待批改";
                    lbtn.Enabled = false;
                    lbtn.Text = "已考";
                    break;
                case "6":
                    e.Row.Cells[6].Text = "重新考试";
                    break;
            }
            DateTime endTime=Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "endtime"));
            if (DateTime.Compare(endTime, DateTime.Now)<0)
            {
                //已过期
                lbtn.Enabled = false;
                lbtn.Text = "已过期";
            }
        }
    }
}
