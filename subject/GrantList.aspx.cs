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
using System.Collections.Generic;

public partial class subject_SubjectList : BasePage
{
    tbGrantBLL grantBLL = new tbGrantBLL();
    tbUserBLL userBLL = new tbUserBLL();
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
            BindUserName();
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

    private void BindUserName()
    {
        ddlUserName.DataSource = userBLL.GetList("usertype=2");
        ddlUserName.DataTextField = "realname";
        ddlUserName.DataValueField = "id";
        ddlUserName.DataBind();
        ddlUserName.Items.Insert(0, new ListItem("所有教师", "0"));
    }

    protected void BindData()
    {
        pageTotal = (int)DbHelperSQL.GetSingle("select count(A) from (select count(classid) as A from tbGrant where " + GetWhereSql() + " group by userid,subjectid) B");
        gvwData.DataSource = MyUtil.GetListByIndex2(pageSize, pageIndex, "userid,subjectid,tbUser.realname,tbSubject.subjectname,count(tbGrant.classid) as classcount", "tbGrant,tbUser,tbSubject", "tbGrant.userid=tbUser.id and tbGrant.subjectid=tbSubject.id", GetWhereSql(),"tbUser.realname,tbSubject.subjectname,userid,subjectid","(userid+subjectid)", "tbUser.realname");
        gvwData.DataKeyNames = new String[] { "userid", "subjectid" };
        gvwData.DataBind();
    }

    private String GetWhereSql()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" 1=1 ");
        if (ddlUserName.SelectedValue != "0")
        {
            sb.Append(" and userid=" + ddlUserName.SelectedValue);
        }
        if (ddlSubject.SelectedValue != "0")
        {
            sb.Append(" and subjectid=" + ddlSubject.SelectedValue);
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
                int userid = Convert.ToInt32(gvwData.DataKeys[i].Values[0]);
                int subjectid = Convert.ToInt32(gvwData.DataKeys[i].Values[1]);
                bool b = this.DeleteGrant(userid, subjectid);
                if (b == true)
                {
                    countSuccess++;
                }
                else
                {
                    countFail++;
                }
            }
        }

        String message = "成功删除" + countSuccess + "条记录！";
        if (countFail != 0)
        {
            message += "<br/>还存在" + countFail + "条记录删除失败！";
        }
        MyUtil.ShowMessage(this, message);
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
        int userid = Convert.ToInt32(lbtn.CommandArgument);
        int subjectid = Convert.ToInt32(lbtn.CommandName);
        editString = "?userid=" + userid + "&subjectid=" + subjectid;
        MyUtil.ExecuteJS(this, "$(function(){oe_edit()})");
        BindData();
    }

    /// <summary>
    /// 删除一条授课
    /// </summary>
    /// <param name="userid"></param>
    /// <param name="subjectid"></param>
    /// <returns></returns>
    private bool DeleteGrant(int userid, int subjectid)
    {
        List<String> list = new List<string>();
        list.Add("delete from tbGrant where userid=" + userid + " and subjectid=" + subjectid);
        list.Add("delete from tbScore where arrangeid in(select id from tbArrange where userid=" + userid + " and subjectid=" + subjectid + ")");
        list.Add("delete from tbAnswerOfPaper where arrangeid in(select id from tbArrange where userid=" + userid + " and subjectid=" + subjectid + ")");
        list.Add("delete from tbPaper where userid=" + userid + " and subjectid=" + subjectid);
        list.Add("delete from tbArrange where userid=" + userid + " and subjectid=" + subjectid);
        int count = DbHelperSQL.ExecuteSqlTran(list);//事务
        if (count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
