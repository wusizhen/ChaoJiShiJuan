using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
using FusionCharts.Charts;
    

public partial class test_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //教师
        Chart Comparison = new Chart("column2d", "class3Comparison", "500", "400", "jsonurl", "../fusionChartsData/Class3HLAData.json");
        class3Comparison.Text = Comparison.Render();

        Chart ExamStat = new Chart("radar", "teacherExamStat", "500", "450", "jsonurl", "../fusionChartsData/teacherExam.json");
        techerExamStat.Text = ExamStat.Render();

        //学生
        Chart StudentError = new Chart("bar2d", "studentError", "400", "300", "jsonurl", "../fusionChartsData/studentError.json");
        studentError.Text = StudentError.Render();

        //管理员
        Chart AdminWeekSign = new Chart("area2d", "adminsighin", "500", "400", "jsonurl", "../fusionChartsData/adminSignIn.json");
        adminweeksignin.Text = AdminWeekSign.Render();

        Chart AdminIpStatic = new Chart("pie2d", "adminipstatic", "450", "300", "jsonurl", "../fusionChartsData/ipStat.json");
        adminipstatic.Text = AdminIpStatic.Render();


        

    }
}