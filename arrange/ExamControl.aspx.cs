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
using Maticsoft.DBUtility;

public partial class subject_SubjectList : BasePage
{
    tbArrangeBLL arrangeBLL = new tbArrangeBLL();
    int arrangeid;

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
        arrangeid = Convert.ToInt32(Request.QueryString["id"]);
        if (!IsPostBack)
        {
            BindClass();
            BindData();
        }
    }

    private void BindClass()
    {
        ddlClass.DataSource = DbHelperSQL.Query("select distinct tbClass.* from tbClass,tbScore,tbUser where tbClass.id=tbUser.classid and tbScore.userid=tbUser.id and tbScore.arrangeid=" + arrangeid+" order by classname");
        ddlClass.DataTextField = "classname";
        ddlClass.DataValueField = "id";
        ddlClass.DataBind();
        ddlClass.Items.Insert(0, new ListItem("所有班级", "0"));
    }

    protected void BindData()
    {
        pageTotal = MyUtil.GetCount("tbScore,tbUser,tbClass", "tbScore.userid=tbUser.id and tbUser.classid=tbClass.id", GetWhereSql());
        gvwData.DataSource = MyUtil.GetListByIndex(pageSize, pageIndex, "tbScore.*,tbClass.classname,tbUser.realname", "tbScore,tbUser,tbClass", "tbScore.userid=tbUser.id and tbUser.classid=tbClass.id", GetWhereSql(), "tbClass.classname,tbUser.realname");
        gvwData.DataKeyNames = new String[] { "id" };
        gvwData.DataBind();
    }

    private String GetWhereSql()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" 1=1 and tbScore.arrangeid="+arrangeid);
        if (txtWord.Text.Trim() != "")
        {
            sb.Append(" and tbUser.realname like '%" + txtWord.Text.Trim() + "%' ");
        }
        if (ddlClass.SelectedValue != "0")
        {
            sb.Append(" and tbClass.id=" + ddlClass.SelectedValue);
        }
        if (ddlScoreStatus.SelectedValue != "0")
        {
            sb.Append(" and tbScore.scorestatus=" + ddlScoreStatus.SelectedValue);
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
                case "1":
                    e.Row.Cells[3].Text = "";
                    e.Row.Cells[4].Text = "";
                    e.Row.Cells[5].Text = "<span style='color:blown'>还没考试</span>";
                    break;
                case "2":
                    e.Row.Cells[4].Text = "";
                    e.Row.Cells[5].Text = "<span style='color:black'>正在考试</span>";
                    break;
                case "3":
                    e.Row.Cells[5].Text = "<span style='color:green'>考试成功</span>";
                    break;
                case "4":
                    e.Row.Cells[5].Text = "<span style='color:red'>考试失败</span>";
                    break;
                case "5":
                    e.Row.Cells[5].Text = "<span style='color:green'>等待批改</span>";
                    break;
                case "6":
                    e.Row.Cells[5].Text = "<span style='color:red'>重新考试</span>";
                    break;
            }
        }
    }
}
