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

public partial class class_ClassAdd : BasePage
{
    tbClass classModel = new tbClass();
    tbClassBLL classBLL = new tbClassBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                classModel = classBLL.GetModel(id);
                txtClassName.Text = classModel.classname;
            }
        }
    }


    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        DataSet set = classBLL.GetList(" classname='" + txtClassName.Text.Trim() + "'");
        if (set.Tables[0].Rows.Count == 1)
        {
            lblInfo.Text = "已存在该班级！";
            lblInfo.Visible = true;
            return;
        }
        classModel.classname = txtClassName.Text.Trim();

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            classModel.id = id;
            classBLL.Update(classModel);
            lblInfo.Text = "编辑成功！";
        }
        else
        {
            classBLL.Add(classModel);
            lblInfo.Text = "添加成功！";
        }
        lblInfo.Visible = true;
        txtClassName.Text = "";
    }
}
