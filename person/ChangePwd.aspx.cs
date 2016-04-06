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
using DAL;
using Maticsoft.DBUtility;

public partial class subject_SubjectAdd : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        tbUser user = (tbUser)Session[Constant.User];

        if (user.userpwd!=MyUtil.MD5(txtOldPwd.Text.Trim()))
        {
            //Response.Write(MyUtil.MD5(txtOldPwd.Text.Trim())); //没必要写
            lblInfo.Text = "原密码错误！";
            lblInfo.Visible = true;
            return;
        }
        if (txtNewPwd.Text.Trim() != txtNewPwd2.Text.Trim())
        {
            lblInfo.Text = "两次密码不一致！";
            lblInfo.Visible = true;
            return;
        }
        user.userpwd = MyUtil.MD5(txtNewPwd.Text.Trim());
        new tbUserBLL().Update(user);
        lblInfo.Text = "修改成功！";
        lblInfo.Visible = true;
    }
}
