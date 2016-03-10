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
using System.IO;
using System.Collections.Generic;
using DAL;
using System.Text;
using Util;

public partial class admin_task_StudentImport : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 导入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnImport_Click(object sender, EventArgs e)
    {
        String filename = "";
        if (fulImport.HasFile)
        {
            if (!fulImport.FileName.EndsWith(".xls"))
            {
                lblTip.Text = "上传文件格式只能为xls";
                return;
            }
            if (!Directory.Exists(Server.MapPath("~/temp")))
                Directory.CreateDirectory(Server.MapPath("~/temp"));
            filename = Server.MapPath("~/temp/") + DateTime.Now.ToFileTime() + ".xls";
            fulImport.SaveAs(filename);
        }
        List<String> list = BlankToDB.ExportToDB(BlankToDB.GetDataFromExcel(filename));
        if (list.Count == 0)
        {
            lblTip.Text = "全部导入成功";
        }
        else
        {
            StringBuilder error = new StringBuilder();
            int i = 3;
            foreach (String str in list)
            {
                error.Append(str + "&nbsp;");
                i--;
                if (i == 0)
                {
                    i = 3;
                    error.Append("<br/>");
                }
            }            
            lblTip.Text = error.ToString();
        }
    }

    protected void btnDownload1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/upload/model/blank.xls");
    }
}
