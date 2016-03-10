using System;
using System.Web;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Web.SessionState;
using Model;
using BLL;

/// <summary>
///Authority 权限过滤
/// </summary>
public class AuthorityFilter : IHttpModule
{
    HttpContext context;
    HttpRequest request;
    HttpSessionState session;
    String defaultPath;//登陆页面
    String requestPath;//请求路径

    public AuthorityFilter()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    #region IHttpModule 成员

    public void Dispose()
    {

    }

    // Init方法仅用于给期望的事件注册方法
    public void Init(HttpApplication context)
    {
        context.PostAcquireRequestState += (new EventHandler(this.Application_AcquireRequestState));
    }
    #endregion

    //处理BeginRequest事件的实际代码
    void Application_AcquireRequestState(object sender, EventArgs e)
    {
        context = ((HttpApplication)sender).Context;
        request = context.Request;
        session = context.Session;

        requestPath = request.Path;
        defaultPath = request.ApplicationPath + "/Default.aspx";

        //仅处理向页面的请求，排除向资源文件的请求，排除非文件夹admin下的所有文件和后台首页
        //admin/index.aspx可以被任何已登陆用户访问，所以排除
        if (requestPath.IndexOf(".aspx") != -1 && !requestPath.StartsWith(defaultPath))
        {
            tbUser user = (tbUser)session[Constant.User];
            if (user == null)
            {
                //还没有登陆
                //context.Response.Redirect("~/Default.aspx");
                context.Response.Write("<script>parent.location.href='" + request.ApplicationPath + "/Default.aspx';</script>");
                context.Response.End();
            }
            else
            {
                bool isGranted = IsGranted(user.usertype, requestPath);
                if (isGranted == false)
                {
                    //没有权限访问
                    context.Response.Redirect("~/403.html");
                }

            }
        }
    }

    private bool IsGranted(int usertype, String path)
    {
        if (usertype == 1||usertype ==4)
        {
            List<String> admin = new List<string>();
            admin.Add("/Menu.aspx");
            admin.Add("/user/");
            admin.Add("/subject/");
            admin.Add("/message/");
            admin.Add("/person/");
            admin.Add("connector.aspx");
            foreach (String item in admin)
            {
                if (path.Contains(item))
                    return true;
            }
            return false;
        }
        if (usertype == 2)
        {
            List<String> teacher = new List<string>();
            teacher.Add("/Menu.aspx");
            teacher.Add("/library/");
            teacher.Add("/message/");
            teacher.Add("/paper/");
            teacher.Add("/arrange/");
            teacher.Add("/score/");
            teacher.Add("/person/");
            teacher.Add("connector.aspx");

            foreach (String item in teacher)
            {
                if (path.Contains(item))
                    return true;
            }
            return false;
        }

        if (usertype == 3)
        {
            List<String> student = new List<string>();
            student.Add("/Menu.aspx");
            student.Add("/student/");
            student.Add("/person/");
            student.Add("/message/MessageShow.aspx");

            foreach (String item in student)
            {
                if (path.Contains(item))
                    return true;
            }
            return false;
        }

        return false;
    }
}
