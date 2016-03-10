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
        user=(tbUser)Session[Constant.User];
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
        pageTotal = MyUtil.GetCount("tbScore,tbArrange,tbSubject", "tbScore.arrangeid=tbArrange.id and tbArrange.subjectid=tbSubject.id", GetWhereSql());
        gvwData.DataSource = MyUtil.GetListByIndex(pageSize, pageIndex, "tbScore.*,tbSubject.subjectname,tbArrange.arrangetitle", "tbScore,tbArrange,tbSubject", "tbScore.arrangeid=tbArrange.id and tbArrange.subjectid=tbSubject.id", GetWhereSql(), "tbScore.id desc");
        gvwData.DataKeyNames = new String[] { "id" };
        gvwData.DataBind();
    }

    private String GetWhereSql()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" tbScore.userid=" + user.id + " and scorestatus<>1 and scorestatus<>2 and scorestatus<>6");
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

    protected void gvwData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            switch (DataBinder.Eval(e.Row.DataItem, "scorestatus").ToString())
            {
                case "3":
                    e.Row.Cells[6].Text = "<span style='color:green'>考试成功</span>";
                    break;
                case "4":
                    e.Row.Cells[6].Text = "<span style='color:red'>考试失败</span>";
                    break;
                case "5":
                    e.Row.Cells[6].Text = "<span style='color:green'>等待批改</span>";
                    //不显示分数
                    e.Row.Cells[3].Text = "";
                    break;
            }
        }
    }

}
