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

public partial class subject_SubjectAdd : BasePage
{
    tbUser user = new tbUser();
    tbUserBLL userBLL = new tbUserBLL();
    tbClassBLL classBLL = new tbClassBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUserType();
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                user = userBLL.GetModel(id);
                txtLoginName.Text = user.loginname;
                txtLoginName.Enabled = false;
                txtRealName.Text = user.realname;
                ddlUserType.Items.FindByValue(user.usertype.ToString()).Selected = true;
                ddlUserType.Enabled=false;
                if (user.usertype == 3)
                {
                    BindClass();
                    ddlClass.Items.FindByValue(user.classid.ToString()).Selected = true;
                    ddlClass.Enabled = true;
                }
                else
                {
                    ddlClass.Enabled = false;
                }
            }
        }
    }

    private void BindUserType()
    {
        ListItem li1 = new ListItem("管理员", "1");
        ListItem li2 = new ListItem("教师", "2");
        ListItem li3 = new ListItem("学生", "3");
        tbUser user = (tbUser)Session[Constant.User];
        if (user.usertype == 4)
        {
            ddlUserType.Items.Add(li1);
            ddlUserType.Items.Add(li2);
            ddlUserType.Items.Add(li3);
        }
        else
        {
            ddlUserType.Items.Add(li2);
            ddlUserType.Items.Add(li3);
        }
    }

    private void BindClass()
    {
        ddlClass.Items.Clear();
        if (ddlUserType.SelectedValue == "3")
        {
            ddlClass.DataSource = classBLL.GetList(" 1=1 order by classname");
            ddlClass.DataTextField = "classname";
            ddlClass.DataValueField = "id";
            ddlClass.DataBind();
        }
    }

    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindClass();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        DataSet set = userBLL.GetList(" loginname='" + txtLoginName.Text.Trim() + "'");
        if (set.Tables[0].Rows.Count > 0 && Request.QueryString["id"]==null)
        {
            lblInfo.Text = "已存在该用户名！";
            lblInfo.Visible = true;
            return;
        }
        user.loginname = txtLoginName.Text.Trim();
        user.realname = txtRealName.Text.Trim();
        user.usertype = Convert.ToInt32(ddlUserType.SelectedValue);
        
        if (user.usertype == 3)
        {
            user.classid = Convert.ToInt32(ddlClass.SelectedValue);
        }
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            user.id = id;
            user.userpwd = userBLL.GetModel(id).userpwd;
            userBLL.Update(user);
            lblInfo.Text = "编辑成功！";
        }
        else
        {
            user.userpwd = MyUtil.MD5("888888");
            userBLL.Add(user);
            lblInfo.Text = "添加成功，初始密码为：888888！";
        }
        lblInfo.Visible = true;
        txtLoginName.Text = "";
        txtRealName.Text = "";
    }

}
