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

public partial class user_UserList : BasePage
{
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
            BindData();
        }
    }

    protected void BindData()
    {
        pageTotal = MyUtil.GetCount("tbUser left join tbClass on tbUser.classid=tbClass.id", "1=1", GetWhereSql());
        gvwData.DataSource = MyUtil.GetListByIndex3(pageSize, pageIndex, "tbUser.*,tbClass.classname", "tbUser left join tbClass on tbUser.classid=tbClass.id", "1=1", GetWhereSql(), "tbUser.id");
        gvwData.DataKeyNames = new String[] { "id" };
        gvwData.DataBind();
    }

    private String GetWhereSql()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" loginname<>'oeadmin' ");
        if (txtWord.Text.Trim() != "")
        {
            sb.Append(" and loginname like '%" + txtWord.Text.Trim() + "%' ");
        }
        if (ddlUsertType.SelectedValue != "0")
        {
            sb.Append(" and usertype=" + ddlUsertType.SelectedValue);
        }
        tbUser user = (tbUser)Session[Constant.User];
        if (user.usertype != 4)
        {
            //非超级管理员,不显示普通管理员
            sb.Append(" and usertype<>1");
        }
        return sb.ToString();
    }

    /// <summary>
    /// 处理用户类型显示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvwData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //处理用户显示类型
            switch (DataBinder.Eval(e.Row.DataItem, "usertype").ToString())
            {
                case "0":
                    e.Row.Cells[4].Text = "已冻结";
                    break;
                case "1":
                    e.Row.Cells[4].Text = "管理员";
                    break;
                case "2":
                    e.Row.Cells[4].Text = "教师";
                    break;
                case "3":
                    e.Row.Cells[4].Text = "学生";
                    break;
            }
            //处理搜索结果
            //String word = txtWord.Text.Trim();
            //if (word != "")
            //{
            //    String loginName = DataBinder.Eval(e.Row.DataItem, "loginname").ToString();
            //    e.Row.Cells[2].Text = MyUtil.SplitArround(loginName,word);
            //}
        }
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
                tbUser user = userBLL.GetModel(id);
                switch (user.usertype)
                {
                    case 1:
                        //删除管理员
                        userBLL.Delete(id);
                        DbHelperSQL.ExecuteSql("delete from tbMessage where userid=" + id);
                        countSuccess++;
                        break;
                    case 2:
                        //删除教师
                        bool b = DbHelperSQL.Exists("select id from tbGrant where userid=" + id);
                        if (b == false)
                        {
                            //执行删除
                            userBLL.Delete(id);
                            DbHelperSQL.ExecuteSql("delete from tbMessage where userid=" + id);
                            countSuccess++;
                        }
                        else
                        {
                            countFail++;
                        }
                        break;
                    case 3:
                        //删除学生
                        userBLL.Delete(id);
                        DbHelperSQL.ExecuteSql("delete from tbAnswerOfPaper where userid=" + id);
                        DbHelperSQL.ExecuteSql("delete from tbScore where userid=" + id);
                        countSuccess++;
                        break;
                }

            }
        }
        BindData();
        String message = "成功删除" + countSuccess + "条记录！";
        if (countFail != 0)
        {
            message += "<br/>还存在" + countFail + "条记录拒绝删除！";
            message += "<br/>可能原因：该教师存在授课！";
        }
        MyUtil.ShowMessage(this, message);
    }

    /// <summary>
    /// 重置密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnReset_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        int id = Convert.ToInt32(lbtn.CommandArgument);

        tbUser user = userBLL.GetModel(id);
        user.userpwd = MyUtil.MD5("888888");
        userBLL.Update(user);
        BindData();
        MyUtil.ShowMessage(this, "新的密码为888888！");
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

    /// <summary>
    /// 导出Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        MyUtil.DownloadExcel(MyUtil.GetAll("tbUser.*,tbClass.classname", "tbUser left join tbClass on tbUser.classid=tbClass.id", "1=1", GetWhereSql()), this);
    }
}
