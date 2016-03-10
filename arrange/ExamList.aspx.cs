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
    public String editString = "";
    public String editString2 = "";

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
        pageTotal = MyUtil.GetCount("tbArrange,tbSubject,tbPaper", "tbArrange.subjectid=tbSubject.id and tbArrange.paperid=tbPaper.id", GetWhereSql());
        gvwData.DataSource = MyUtil.GetListByIndex(pageSize, pageIndex, "tbArrange.*,subjectname,papertitle", "tbArrange,tbSubject,tbPaper", "tbArrange.subjectid=tbSubject.id and tbArrange.paperid=tbPaper.id", GetWhereSql(), "tbArrange.id desc");
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
    /// 删除所选
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        int countSuccess = 0;
        for (int i = 0; i < gvwData.Rows.Count; i++)
        {
            CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
            if (cbx.Checked == true)
            {
                int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                //执行删除
                DbHelperSQL.ExecuteSql("delete from tbScore where arrangeid=" + id);
                DbHelperSQL.ExecuteSql("delete from tbAnswerOfPaper where arrangeid=" + id);
                arrangeBLL.Delete(id);
                countSuccess++;
            }
        }
        BindData();
        String message = "成功删除" + countSuccess + "条记录！";
        MyUtil.ShowMessage(this, message);
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

    /// <summary>
    /// 进入监控
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnControl_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        int id = Convert.ToInt32(lbtn.CommandArgument);
        editString2 = "?id=" + id;
        MyUtil.ExecuteJS(this, "$(function(){oe_control()})");
        BindData();
    }


}
