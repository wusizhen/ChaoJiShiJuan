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
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using Model;
using DAL;
using Util;

public partial class Login : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constant.User] != null)
        {
            Server.Transfer("~/Menu.aspx");
        }
    }


    protected void lbtnSubmit_Click(object sender, EventArgs e)
    {
        String loginName = txtLoginName.Text.Trim();
        String userPwd = txtUserPwd.Text.Trim();
        //MD5
        userPwd = Util.MyUtil.MD5(userPwd);
        String strSql = "select id from tbUser where loginname=@loginname and userpwd=@userpwd";
        bool b= DbHelperSQL.Exists(strSql,new SqlParameter("@loginname",loginName),new SqlParameter("@userpwd",userPwd));
        if (b)
        {
            //登陆成功
            int id = (int)DbHelperSQL.GetSingle(strSql, new SqlParameter("@loginname", loginName), new SqlParameter("@userpwd", userPwd));
            tbUser user = new tbUserDAL().GetModel(id);
            Session[Constant.User] = user;
            Server.Transfer("~/Menu.aspx");
        }
        else
        {
            lblTip.Text = "用户名或者密码错误";
            lblTip.Visible = true;
        }
    }
}
