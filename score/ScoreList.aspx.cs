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
            BindArrange();
            BindClass();
            BindData();
        }
    }

    private void BindArrange()
    {
        String strSql = "select tbArrange.id,(arrangetitle+'('+subjectname+')') as newtitle from tbArrange,tbSubject where tbArrange.subjectid=tbSubject.id and arrangetype=2 and userid=" + user.id + " order by tbArrange.id desc";
        ddlArrange.DataSource = DbHelperSQL.Query(strSql);
        ddlArrange.DataValueField = "id";
        ddlArrange.DataTextField = "newtitle";
        ddlArrange.DataBind();
        ddlArrange.Items.Insert(0, new ListItem("所有考试", "0"));
    }

    private void BindClass()
    {
        int arrangeid = Convert.ToInt32(ddlArrange.SelectedValue);
        if (arrangeid != 0)
        {
            int subjectid = arrangeBLL.GetModel(arrangeid).subjectid;
            ddlClass.DataSource = DbHelperSQL.Query("select * from tbClass where id in (select distinct classid from tbGrant where subjectid=" + subjectid + " and userid=" + user.id + ")");
            ddlClass.DataTextField = "classname";
            ddlClass.DataValueField = "id";
            ddlClass.DataBind();
        }
        ddlClass.Items.Insert(0, new ListItem("所有班级", "0"));
        BindData();
    }

    protected void ddlArrange_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindClass();
    }

    protected void BindData()
    {
        pageTotal = MyUtil.GetCount("tbScore,tbArrange,tbSubject,tbClass,tbUser", "tbScore.arrangeid=tbArrange.id and tbArrange.subjectid=tbSubject.id and tbClass.id=tbUser.classid and tbScore.userid=tbUser.id", GetWhereSql());
        gvwData.DataSource = MyUtil.GetListByIndex(pageSize, pageIndex, "tbScore.*,tbSubject.subjectname,tbArrange.arrangetitle,tbUser.realname,tbClass.classname", "tbScore,tbArrange,tbSubject,tbClass,tbUser", "tbScore.arrangeid=tbArrange.id and tbArrange.subjectid=tbSubject.id and tbClass.id=tbUser.classid and tbScore.userid=tbUser.id", GetWhereSql(), "tbClass.classname,tbUser.realname");
        gvwData.DataKeyNames = new String[] { "id" };
        gvwData.DataBind();
    }

    private String GetWhereSql()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" score>=" + ddlRange1.SelectedValue);
        sb.Append(" and score<=" + ddlRange2.SelectedValue);
        sb.Append(" and tbArrange.userid=" + user.id);
        if (txtWord.Text.Trim() != "")
        {
            sb.Append(" and realname like '%" + txtWord.Text.Trim() + "%' ");
        }
        if (ddlArrange.SelectedValue != "0")
        {
            sb.Append(" and tbScore.arrangeid=" + ddlArrange.SelectedValue);
        }
        else
        {
            sb.Append(" and tbScore.arrangeid in(select id from tbArrange where userid=" + user.id + ")");
        }
        if (ddlClass.SelectedValue != "0")
        {
            sb.Append(" and tbClass.id=" + ddlClass.SelectedValue);
        }
        if (ddlScoreStatus.SelectedValue != "0")
        {
            sb.Append(" and scorestatus=" + ddlScoreStatus.SelectedValue);
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
                    e.Row.Cells[7].Text = "<span style='color:blown'>还没考试</span>";
                    break;
                case "2":
                    e.Row.Cells[7].Text = "<span style='color:black'>正在考试</span>";
                    break;
                case "3":
                    e.Row.Cells[7].Text = "<span style='color:green'>考试成功</span>";
                    break;
                case "4":
                    e.Row.Cells[7].Text = "<span style='color:red'>考试失败</span>";
                    break;
                case "5":
                    e.Row.Cells[7].Text = "<span style='color:green'>等待批改</span>";
                    break;
                case "6":
                    e.Row.Cells[7].Text = "<span style='color:red'>重新考试</span>";
                    break;
            }
        }
    }

    /// <summary>
    /// 导出Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        MyUtil.DownloadExcel(MyUtil.GetAll("tbUser.realname as 学生,tbClass.classname 班级,tbSubject.subjectname as 科目,tbArrange.arrangetitle as 考试标题,score as 分数,tbScore.starttime as 开始时间,tbScore.endtime as 结束时间", "tbScore,tbArrange,tbSubject,tbClass,tbUser", "tbScore.arrangeid=tbArrange.id and tbArrange.subjectid=tbSubject.id and tbClass.id=tbUser.classid and tbScore.userid=tbUser.id", GetWhereSql()), this);
    }

    /// <summary>
    /// 重考所选
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        string sqlText = "";
        for (int i = 0; i < gvwData.Rows.Count; i++)
        {
            CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
            if (cbx.Checked == true)
            {
                sqlText = sqlText + Convert.ToInt32(gvwData.DataKeys[i].Value) + ",";
            }
        }
        if (sqlText != "")
        {
            //去掉最后的逗号，并且加上右括号
            sqlText = sqlText.Substring(0, sqlText.Length - 1);
            DbHelperSQL.ExecuteSql("update tbScore set scorestatus=6 where id in(" + sqlText + ")");
            BindData();
        }
    }

    /// <summary>
    /// 重考
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        int id = Convert.ToInt32(lbtn.CommandArgument);
        DbHelperSQL.ExecuteSql("update tbScore set scorestatus=6 where id="+id);        
        BindData();
    }
}
