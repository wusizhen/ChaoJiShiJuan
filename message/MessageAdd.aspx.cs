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
    tbMessage message = new tbMessage();
    tbMessageBLL messageBLL = new tbMessageBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                message = messageBLL.GetModel(id);
                txtMessageTitle.Text = message.messagetitle;
                txtMessageContent.Text = message.messagecontent;
            }
        }
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        if (txtMessageContent.Text.Trim() == "")
        {
            lblInfo.Text = "内容不能为空！";
            lblInfo.Visible = true;
            return;
        }
        message.messagetitle = txtMessageTitle.Text.Trim();
        message.messagecontent = txtMessageContent.Text.Trim();

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            message.id = id;
            tbMessage oldMessage = messageBLL.GetModel(id);
            message.createtime = oldMessage.createtime;
            message.visitcount = oldMessage.visitcount;
            message.userid = oldMessage.userid;
            messageBLL.Update(message);
            lblInfo.Text = "编辑成功！";
        }
        else
        {
            message.createtime = DateTime.Now;
            message.visitcount = 0;
            message.userid = ((tbUser)Session[Constant.User]).id;
            messageBLL.Add(message);
            lblInfo.Text = "添加成功！";
        }
        lblInfo.Visible = true;
    }
}
