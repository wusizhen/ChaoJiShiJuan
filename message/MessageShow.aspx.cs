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
                message.visitcount = message.visitcount + 1;
                messageBLL.Update(message);

                lblTitle.Text = message.messagetitle;
                lblTime.Text = message.createtime.ToString("yyyy-MM-dd HH:mm:ss");
                lblVisitCount.Text = message.visitcount.ToString();
                locContent.Text = message.messagecontent;
            }
        }
    }
    
}
