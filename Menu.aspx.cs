using System;
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
using FusionCharts.Charts;

public partial class _Default : BasePage
{
    tbUser user;

    protected void Page_Load(object sender, EventArgs e)
    {
        user = (tbUser)Session[Constant.User];

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

            Label1.Text = user.loginname;
            //Label2.Text = user.realname;
            Label3.Text = DateTime.Now.ToString("yyyy年MM月d日");
            Label4.Text = Request.UserHostAddress;
            Label5.Text = user.realname;

            lblRealName.Text = user.realname;
            switch (user.usertype)
            {                
                case 1: lblRole.Text = "管理员"; menu1.Visible = true; menu2.Visible = true; menu3.Visible = false;
                    menu4.Visible = false; menu5.Visible = false; menu6.Visible = false;
                    menu7.Visible = false;  menu9.Visible = true;
                    studentInt.Visible = false; teacherInt.Visible = false; adminInt.Visible = true; oeadminInt.Visible = false;
                    Image1.ImageUrl = "~/images/admin.jpg"; break;
                case 2: lblRole.Text = "教师"; menu1.Visible = false; menu2.Visible = false; menu3.Visible = true;
                    menu4.Visible = true; menu5.Visible = true; menu6.Visible = true;
                    menu7.Visible = false;  menu9.Visible = true;
                    studentInt.Visible = false; teacherInt.Visible = true; adminInt.Visible = false; oeadminInt.Visible = false;
                    Image1.ImageUrl = "~/images/tea.jpg"; break;
                case 3: lblRole.Text = "学生"; menu1.Visible = false; menu2.Visible = false; menu3.Visible = false;
                    menu4.Visible = false; menu5.Visible = false; menu6.Visible = false;
                    menu7.Visible = true;  menu9.Visible = false;
                    studentInt.Visible = true; teacherInt.Visible = false; adminInt.Visible = false; oeadminInt.Visible = false;
                    Image1.ImageUrl = "~/images/stu.jpg"; break;
                case 4: lblRole.Text = "超级管理员"; menu1.Visible = true; menu2.Visible = true; menu3.Visible = false;
                    menu4.Visible = false; menu5.Visible = false; menu6.Visible = false;
                    menu7.Visible = false;  menu9.Visible = true;
                    studentInt.Visible = false; teacherInt.Visible = false; adminInt.Visible = false; oeadminInt.Visible = true;
                    Image1.ImageUrl = "~/images/admin.jpg"; break;
            }
        }
        //教师
        Chart Comparison = new Chart("column2d", "class3Comparison", "500", "400", "jsonurl", "fusionChartsData/Class3HLAData.json");
        class3Comparison.Text = Comparison.Render();

        Chart ExamStat = new Chart("radar", "teacherExamStat", "500", "450", "jsonurl", "fusionChartsData/teacherExam.json");
        techerExamStat.Text = ExamStat.Render();

        //学生
        Chart StudentError = new Chart("bar2d", "studentError", "400", "300", "jsonurl", "fusionChartsData/studentError.json");
        studentError.Text = StudentError.Render();

        //管理员
        Chart AdminWeekSign = new Chart("area2d", "adminsighin", "500", "400", "jsonurl", "fusionChartsData/adminSignIn.json");
        adminweeksignin.Text = AdminWeekSign.Render();

        Chart AdminIpStatic = new Chart("pie2d", "adminipstatic", "450", "300", "jsonurl", "fusionChartsData/ipStat.json");
        adminipstatic.Text = AdminIpStatic.Render();
    }

    protected void BindData()
    {
        pageTotal = MyUtil.GetCount("tbMessage,tbUser", "tbMessage.userid=tbUser.id", GetWhereSql());
        gvwData.DataSource = MyUtil.GetListByIndex(5, pageIndex, "tbMessage.*,tbUser.realname", "tbMessage,tbUser", "tbMessage.userid=tbUser.id", GetWhereSql(), "tbMessage.id desc");
        gvwData.DataKeyNames = new String[] { "id" };
        gvwData.DataBind();
    }

    private String GetWhereSql()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" 1=1 ");
        tbUser user = (tbUser)Session[Constant.User];
        if (user.usertype == 2)  
        {
            //教师（管理员的公告）
            sb.Append(" and usertype=1 ");
        }
        if (user.usertype == 3)
        {
            //学生(管理员和教师的公告)
            sb.Append(" and (usertype=1 or userid in (select distinct userid from tbUser,tbGrant where tbUser.classid=tbGrant.classid and tbUser.id="+user.id+"))");
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

    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        Session[Constant.User] = null;
        Response.Redirect("~/login.aspx");
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
