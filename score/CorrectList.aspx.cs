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
        pageTotal = MyUtil.GetCount("tbArrange,tbSubject", "tbArrange.subjectid=tbSubject.id", GetWhereSql());
        gvwData.DataSource = MyUtil.GetListByIndex2(pageSize, pageIndex, "tbArrange.id,subjectname,arrangetitle,starttime,endtime,count(tbAnswerOfPaper.id) as answercount", "tbArrange,tbSubject,tbAnswerOfPaper", "tbArrange.subjectid=tbSubject.id and tbArrange.id=tbAnswerOfPaper.arrangeid and tbAnswerOfPaper.getscore=-1", GetWhereSql(),"tbArrange.id,subjectname,arrangetitle,starttime,endtime","tbArrange.id" ,"tbArrange.id desc");
        gvwData.DataKeyNames = new String[] { "id" };
        gvwData.DataBind();
    }

    private String GetWhereSql()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" tbArrange.arrangetype=2 and tbArrange.userid=" + ((tbUser)Session[Constant.User]).id);
        if (txtWord.Text.Trim() != "")
        {
            sb.Append(" and arrangetitle like '%" + txtWord.Text.Trim() + "%' ");
        }
        if (ddlSubject.SelectedValue != "0")
        {
            sb.Append(" and tbArrange.subjectid=" + ddlSubject.SelectedValue);
        }
        else
        {
            sb.Append(" and tbArrange.subjectid in" + MyUtil.GetMySubjectString());
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
    /// 批改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        int id = Convert.ToInt32(lbtn.CommandArgument);
        editString = "?id=" + id;
        MyUtil.ExecuteJS(this, "$(function(){oe_add()})");
        BindData();
    }

    protected void gvwData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "answercount").ToString()=="0")
            {
                //没有批改
                LinkButton lbtn = (LinkButton)e.Row.FindControl("lbtnEdit");
                lbtn.Text = "暂无批改";
                lbtn.Enabled = false;
            }
        }
    }
}
