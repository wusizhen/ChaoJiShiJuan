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
using BLL;
using Model;
using System.Text;
using Maticsoft.DBUtility;

public partial class subject_SubjectList : BasePage
{
    tbJudgeBLL judgeBLL = new tbJudgeBLL();
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
            BindChapter();
            BindData();
        }
    }

    private void BindSubject()
    {
        ddlSubject.Items.Clear();
        ddlSubject.DataSource = MyUtil.GetMySubject();
        ddlSubject.DataTextField = "subjectname";
        ddlSubject.DataValueField = "id";
        ddlSubject.DataBind();
        ddlSubject.Items.Insert(0, new ListItem("所有科目", "0"));
    }

    private void BindChapter()
    {
        ddlChapter.DataSource = DbHelperSQL.Query("select * from tbChapter where subjectid=" + ddlSubject.SelectedValue);
        ddlChapter.DataTextField = "chaptername";
        ddlChapter.DataValueField = "id";
        ddlChapter.DataBind();
        ddlChapter.Items.Insert(0, new ListItem("所有章节", "0"));
    }

    protected void BindData()
    {
        pageTotal = MyUtil.GetCount("tbJudge,tbChapter,tbSubject", "tbJudge.chapterid=tbChapter.id and tbChapter.subjectid=tbSubject.id", GetWhereSql());
        gvwData.DataSource = MyUtil.GetListByIndex(pageSize, pageIndex, "tbJudge.*,tbSubject.subjectname,tbChapter.chaptername", "tbJudge,tbChapter,tbSubject", "tbJudge.chapterid=tbChapter.id and tbChapter.subjectid=tbSubject.id", GetWhereSql(), "subjectname,tbChapter.chapterno");
        gvwData.DataKeyNames = new String[] { "id" };
        gvwData.DataBind();
    }

    private String GetWhereSql()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" questype=1 ");
        if (txtWord.Text.Trim() != "")
        {
            sb.Append(" and ques like '%" + txtWord.Text.Trim() + "%' ");
        }
        if (ddlSubject.SelectedValue != "0")
        {
            sb.Append(" and subjectid=" + ddlSubject.SelectedValue);
        }
        else
        {
            sb.Append(" and subjectid in" + MyUtil.GetMySubjectString());
        }
        if (ddlChapter.SelectedValue != "0")
        {
            sb.Append(" and chapterid=" + ddlChapter.SelectedValue);
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
    /// 删除所选
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
            judgeBLL.DeleteList(sqlText);
            BindData();
        }
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
        editString = "?id=" + id;
        MyUtil.ExecuteJS(this, "$(function(){oe_edit()})");
        BindData();
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindChapter();
    }

    protected void gvwData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //处理用户显示类型
            switch (DataBinder.Eval(e.Row.DataItem, "diff").ToString())
            {
                case "1":
                    e.Row.Cells[6].Text = "容易";
                    break;
                case "2":
                    e.Row.Cells[6].Text = "较易";
                    break;
                case "3":
                    e.Row.Cells[6].Text = "一般";
                    break;
                case "4":
                    e.Row.Cells[6].Text = "较难";
                    break;
                case "5":
                    e.Row.Cells[6].Text = "困难";
                    break;
            }
            //处理搜索结果
            //String word = txtWord.Text.Trim();
            //if (word != "")
            //{
            //    String loginName = DataBinder.Eval(e.Row.DataItem, "loginname").ToString();
            //    e.Row.Cells[2].Text = MyUtil.SplitArround(loginName,word);
            //}
        }
    }

    /// <summary>
    /// 截取字符串
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected String GetSmallQues(String str)
    {
        if (str.Length > 20)
        {
            return str.Substring(0, 20) + "……";
        }
        return str;
    }
}
