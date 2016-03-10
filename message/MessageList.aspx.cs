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
using BLL;
using Model;
using System.Text;
using Maticsoft.DBUtility;

public partial class subject_SubjectList : BasePage
{
    tbMessageBLL messageBLL = new tbMessageBLL();

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
            BindData(); // 第一次打开进行gridview数据绑定
        }
    }

    protected void BindData()
    {
        pageTotal = MyUtil.GetCount("tbMessage,tbUser", "tbMessage.userid=tbUser.id", GetWhereSql());
        gvwData.DataSource = MyUtil.GetListByIndex(pageSize, pageIndex, "tbMessage.*,tbUser.realname", "tbMessage,tbUser", "tbMessage.userid=tbUser.id", GetWhereSql(), "tbMessage.id desc");
        gvwData.DataKeyNames = new String[] { "id" };
        gvwData.DataBind();
    }

    private String GetWhereSql()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" 1=1 ");
        if (txtWord.Text.Trim() != "")
        {
            sb.Append(" and (messagetitle like '%" + txtWord.Text.Trim() + "%' or messagecontent like '%"+ txtWord.Text.Trim() + "%')");
        }
        tbUser user = (tbUser)Session[Constant.User];
        if (user.usertype == 2)
        {
            sb.Append(" and userid=" + user.id);
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
        string sqlText = "";
        for (int i = 0; i < gvwData.Rows.Count; i++)
        {
            CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
            if (cbx.Checked == true)
            {
                sqlText = sqlText + Convert.ToInt32(gvwData.DataKeys[i].Value) + ",";
            }
        }
        if (sqlText != "")
        {
            //去掉最后的逗号，并且加上右括号
            sqlText = sqlText.Substring(0, sqlText.Length - 1);
            messageBLL.DeleteList(sqlText);
            BindData();
        }
    }

    /// <summary>
    /// 截取字符串
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    protected String GetSmallTitle(String str)
    {
        if (str.Length > 25)
        {
            return str.Substring(0, 25) + "……";
        }
        return str;
    }
}
