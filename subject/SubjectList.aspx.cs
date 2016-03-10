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
    tbSubjectBLL subjectBLL = new tbSubjectBLL();
    public String editString="";

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
            BindData();
        }
    }

    protected void BindData()
    {
        pageTotal = subjectBLL.GetCount(GetWhereSql());
        gvwData.DataSource = subjectBLL.GetListByIndex(pageSize, pageIndex, GetWhereSql(), "subjectname");
        gvwData.DataKeyNames = new String[] { "id" };
        gvwData.DataBind();
    }

    private String GetWhereSql()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" 1=1 ");
        if (txtWord.Text.Trim() != "")
        {
            sb.Append(" and subjectname like '%" + txtWord.Text.Trim() + "%' ");
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
        int countFail = 0;
        for (int i = 0; i < gvwData.Rows.Count; i++)
        {
            CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
            if (cbx.Checked == true)
            {
                int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                bool b = DbHelperSQL.Exists("select id from tbChapter where subjectid=" + id);
                if (b == false)
                {
                    //执行删除
                    subjectBLL.Delete(id);
                    countSuccess++;
                }
                else
                {
                    countFail++;
                }
            }
        }
        BindData();
        String message = "成功删除" + countSuccess + "条记录！";
        if (countFail != 0)
        {
            message += "<br/>还存在" + countFail + "条记录拒绝删除！";
            message += "<br/>可能原因：该科目还存在章节！";
        }
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

}
