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
using Maticsoft.DBUtility;
using System.Collections.Generic;

public partial class subject_SubjectAdd : BasePage
{
    tbGrant grant = new tbGrant();
    tbGrantBLL grantBLL = new tbGrantBLL();
    tbUserBLL userBLL = new tbUserBLL();
    tbClassBLL classBLL = new tbClassBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubject();
            BindUserName();
            BindClass();
            if (Request.QueryString["userid"] != null)
            {
                int userid = Convert.ToInt32(Request.QueryString["userid"]);
                int subjectid = Convert.ToInt32(Request.QueryString["subjectid"]);
                ddlUserName.Items.FindByValue(userid.ToString()).Selected = true;
                ddlSubject.Items.FindByValue(subjectid.ToString()).Selected = true;
                ddlUserName.Enabled = false;
                ddlSubject.Enabled = false;
                List<Int32> list = GetClassList(userid, subjectid);
                //处理编辑默认选择
                foreach (ListItem item in cblClass.Items)
                {
                    int id = Convert.ToInt32(item.Value);
                    if (list.Contains(id))
                    {
                        item.Selected = true;
                    }
                }
            }
        }
    }

    private List<int> GetClassList(int userid, int subjectid)
    {
        List<Int32> list=new List<int>();
        DataSet set = DbHelperSQL.Query("select classid from tbGrant where userid=" + userid + " and subjectid=" + subjectid);
        for (int i = 0; i < set.Tables[0].Rows.Count; i++)
        {
            list.Add(Convert.ToInt32(set.Tables[0].Rows[i][0]));
        }
        return list;
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

    private void BindClass()
    {
        cblClass.DataSource = classBLL.GetList(" 1=1 order by classname");
        cblClass.DataTextField = "classname";
        cblClass.DataValueField = "id";
        cblClass.DataBind();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        if (ddlSubject.SelectedValue == "0" || ddlUserName.SelectedValue == "0")
        {
            lblInfo.Text = "您还没有填好！";
            lblInfo.Visible = true;
            return;
        }
        grant.subjectid = Convert.ToInt32(ddlSubject.SelectedValue);
        grant.userid = Convert.ToInt32(ddlUserName.SelectedValue);

        //int userid = Convert.ToInt32(Request.QueryString["userid"]);
        //int subjectid = Convert.ToInt32(Request.QueryString["subjectid"]);

        //删除
        String strSql = "delete from tbGrant where userid=" + grant.userid + " and subjectid=" + grant.subjectid;
        DbHelperSQL.ExecuteSql(strSql);

        //添加
        for (int i = 0; i < cblClass.Items.Count; i++)
        {
            if (cblClass.Items[i].Selected)
            {
                grant.classid = Convert.ToInt32(cblClass.Items[i].Value);
                grantBLL.Add(grant);
            }
        }
        lblInfo.Text = "保存成功！";
        lblInfo.Visible = true;
    }
}
