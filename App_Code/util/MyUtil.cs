using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.IO;
using Maticsoft.DBUtility;
using Model;
using BLL;
using System.Collections.Generic;

namespace Util
{
    /// <summary>
    ///Util 的摘要说明
    /// </summary>
    public class MyUtil
    {
        public MyUtil()
        {
        }

        /// <summary>
        /// 分页初始化参数
        /// </summary>
        /// <param name="page"></param>
        public static void initParam(BasePage page)
        {
            try
            {
                HiddenField hfPageIndex = (HiddenField)page.FindControl("hfPageIndex");
                HiddenField hfPageSize = (HiddenField)page.FindControl("hfPageSize");
                if (!String.IsNullOrEmpty(hfPageIndex.Value))
                {
                    page.pageIndex = Convert.ToInt32(hfPageIndex.Value);
                }
                if (!String.IsNullOrEmpty(hfPageSize.Value))
                {
                    page.pageSize = Convert.ToInt32(hfPageSize.Value);
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 执行JS
        /// </summary>
        /// <param name="page"></param>
        /// <param name="str"></param>
        public static void ExecuteJS(System.Web.UI.Page page, String str)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", str, true);
        }

        /// <summary>
        /// 前台显示通知
        /// </summary>
        /// <param name="page"></param>
        /// <param name="str"></param>
        public static void ShowMessage(System.Web.UI.Page page, String str)
        {
            String strNew = "$.messager.alert('消息','" + str + "','alert');";
            page.ClientScript.RegisterStartupScript(page.GetType(), "", strNew, true);
        }

        /// <summary>
        /// 前台显示后重定向
        /// </summary>
        /// <param name="page"></param>
        /// <param name="str"></param>
        /// <param name="url"></param>
        public static void ShowMessageRedirect(System.Web.UI.Page page, String str, String url)
        {
            String strNew = "alert('" + str + "');";
            String strRedirect = "window.location.href='" + url + "';";
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "", strNew + strRedirect, true);
        }

        /// <summary>
        /// 前台显示错误
        /// </summary>
        /// <param name="page"></param>
        /// <param name="str"></param>
        public static void ShowError(System.Web.UI.Page page, String str)
        {
            String strNew = "$.messager.alert('错误','" + str + "','error');";
            page.ClientScript.RegisterStartupScript(page.GetType(), "", strNew, true);
        }

        /// <summary>
        /// 处理搜索结果，渲染红色
        /// </summary>
        /// <param name="content"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static String SplitArround(String content, String word)
        {
            StringBuilder sb = new StringBuilder();
            String ret;
            String[] array = content.Split(new String[] { word }, System.StringSplitOptions.RemoveEmptyEntries);
            String newWord = "<span style='color:Red'>" + word + "</span>";
            if (array.Length == 0)
            {
                if (content == word)
                {
                    return newWord;
                }
                else
                {
                    return content;
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(array[i]);
                sb.Append(newWord);
            }
            if (content.StartsWith(word))
            {
                sb.Insert(0, newWord);
            }
            ret = sb.ToString();
            if (!content.EndsWith(word))
            {
                ret = ret.TrimEnd(newWord.ToCharArray());
            }
            return ret.ToString();
        }

        /// <summary>
        /// MD5算法加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String MD5(String str)
        {
            byte[] array = Maticsoft.Common.DEncrypt.DEncrypt.MakeMD5(Encoding.UTF8.GetBytes(str));
            return BitConverter.ToString(array).Replace("-", "");
        }

        /// <summary>
        /// 把DataTable转换成Excel文件并下载
        /// </summary>
        /// <param name="dt"></param>
        public static void DownloadExcel(DataTable dt, String fileName, BasePage page)
        {
            ExcelHelper ex = new ExcelHelper();
            HttpResponse response = page.Response;

            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt, 1, 1);

            if (!Directory.Exists(page.Server.MapPath("~/temp/")))
            {
                Directory.CreateDirectory(page.Server.MapPath("~/temp/"));
            }
            //导出Excel保存的路径！
            String path = page.Server.MapPath("~/temp/" + fileName + ".xls");
            ex.OutputFilePath = path;
            ex.OutputExcelFile();

            System.IO.FileInfo file = new System.IO.FileInfo(path);
            response.Clear();
            response.Charset = "utf-8";//设置输出的编码
            response.ContentEncoding = System.Text.Encoding.UTF8;
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名    
            response.AddHeader("Content-Disposition", "attachment; filename=" + page.Server.UrlEncode(file.Name));
            // 添加头信息，指定文件大小，让浏览器能够显示下载进度    
            response.AddHeader("Content-Length", file.Length.ToString());
            // 指定返回的是一个不能被客户端读取的流，必须被下载    
            response.ContentType = "application/excel";
            // 把文件流发送到客户端    
            response.WriteFile(file.FullName);
            response.End();
        }

        /// <summary>
        /// 把DataTable转换成Excel文件并下载
        /// </summary>
        /// <param name="dt"></param>
        public static void DownloadExcel(DataTable dt, BasePage page)
        {
            DownloadExcel(dt, DateTime.Now.ToFileTime().ToString(), page);
        }

        /// <summary>
        /// 多表分页查询
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="selectField">选择的字段</param>
        /// <param name="tableNames">如"tbSubject,tbChapter"</param>
        /// <param name="strWhere1">如"tbSubject.id=tbChapter.subjectid"</param>
        /// <param name="strWhere2">自定义条件</param>
        /// <param name="filedOrder">排序字段</param>
        /// <returns></returns>
        public static DataSet GetListByIndex(int pageSize, int pageIndex, string selectField, string tableNames, string strWhere1, string strWhere2, string filedOrder)
        {
            //StringBuilder coreSql = new StringBuilder();
            //coreSql.Append("select ROW_NUMBER() OVER ");
            //if (filedOrder != "")
            //{
            //    coreSql.Append(" (ORDER BY " + filedOrder + ")");
            //}
            //coreSql.Append(" AS RowNumber," + selectField + " from " + tableNames + " ");
            //coreSql.Append(" where " + strWhere1 + " ");
            //if (strWhere2.Trim() != "")
            //{
            //    coreSql.Append(" and " + strWhere2);
            //}
            //String strSql = "SELECT TOP " + pageSize + " * FROM (" + coreSql.ToString() + ") A WHERE RowNumber > " + (pageIndex - 1) * pageSize;
            //PrintSql(strSql.ToString());
            //return DbHelperSQL.Query(strSql.ToString());

            String id;
            int index=tableNames.IndexOf(',');
            if (index > 0)
            {
                id = tableNames.Substring(0, index) + ".id";
            }
            else
            {
                id = tableNames + ".id";
            }
            StringBuilder coreSql = new StringBuilder();
            coreSql.Append("select top " + (pageIndex-1)*pageSize + " "+id+" from " + tableNames + " ");
            coreSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                coreSql.Append(" and " + strWhere2);
            }
            if (filedOrder != "")
            {
                coreSql.Append(" order by " + filedOrder + " ");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " " + selectField + " from " + tableNames + " ");
            strSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                strSql.Append(" and " + strWhere2);
            }
            strSql.Append(" and "+id+" not in(" + coreSql.ToString() + ")");
            if (filedOrder != "")
            {
                strSql.Append(" order by " + filedOrder + " ");
            }
            PrintSql(strSql.ToString());
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 存在group的SQL语句分页
        /// </summary>
        public static DataSet GetListByIndex2(int pageSize, int pageIndex, string selectField, string tableNames, string strWhere1, string strWhere2, String strGroup,String ids,string filedOrder)
        {
            String id=ids;
            
            StringBuilder coreSql = new StringBuilder();
            coreSql.Append("select top " + (pageIndex - 1) * pageSize + " " + id + " from " + tableNames + " ");
            coreSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                coreSql.Append(" and " + strWhere2);
            }
            if (strGroup.Trim() != "")
            {
                coreSql.Append(" group by " + strGroup);
            }
            if (filedOrder != "")
            {
                coreSql.Append(" order by " + filedOrder + " ");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " " + selectField + " from " + tableNames + " ");
            strSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                strSql.Append(" and " + strWhere2);
            }
            strSql.Append(" and " + id + " not in(" + coreSql.ToString() + ")");
            if (strGroup.Trim() != "")
            {
                strSql.Append(" group by " + strGroup);
            }
            if (filedOrder != "")
            {
                strSql.Append(" order by " + filedOrder + " ");
            }
            PrintSql(strSql.ToString());
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 存在join的SQL语句分页
        /// </summary>
        public static DataSet GetListByIndex3(int pageSize, int pageIndex, string selectField, string tableNames, string strWhere1, string strWhere2, string filedOrder)
        {
            String id=filedOrder;
            
            StringBuilder coreSql = new StringBuilder();
            coreSql.Append("select top " + (pageIndex - 1) * pageSize + " " + id + " from " + tableNames + " ");
            coreSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                coreSql.Append(" and " + strWhere2);
            }
            if (filedOrder != "")
            {
                coreSql.Append(" order by " + filedOrder + " ");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " " + selectField + " from " + tableNames + " ");
            strSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                strSql.Append(" and " + strWhere2);
            }
            strSql.Append(" and " + id + " not in(" + coreSql.ToString() + ")");
            if (filedOrder != "")
            {
                strSql.Append(" order by " + filedOrder + " ");
            }
            PrintSql(strSql.ToString());
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取多表查询的记录数
        /// </summary>
        /// <param name="tableNames">如"tbSubject,tbChapter"</param>
        /// <param name="strWhere1">如"tbSubject.id=tbChapter.subjectid"</param>
        /// <param name="strWhere2">自定义条件</param>
        /// <returns></returns>
        public static int GetCount(string tableNames, string strWhere1, string strWhere2)
        {
            StringBuilder coreSql = new StringBuilder();
            coreSql.Append("select count(*) from ");
            coreSql.Append(tableNames);
            coreSql.Append(" where ");
            coreSql.Append(strWhere1);
            if (strWhere2.Trim() != "")
            {
                coreSql.Append(" and " + strWhere2);
            }
            PrintSql(coreSql.ToString());
            return (int)DbHelperSQL.GetSingle(coreSql.ToString());
        }

        /// <summary>
        /// 获取所有数据源
        /// </summary>
        /// <param name="tableNames">如"tbSubject,tbChapter"</param>
        /// <param name="strWhere1">如"tbSubject.id=tbChapter.subjectid"</param>
        /// <param name="strWhere2">自定义条件</param>
        /// <returns></returns>
        public static DataTable GetAll(string field, string tableNames, string strWhere1, string strWhere2)
        {
            StringBuilder coreSql = new StringBuilder();
            coreSql.Append("select " + field + " from ");
            coreSql.Append(tableNames);
            coreSql.Append(" where ");
            coreSql.Append(strWhere1);
            if (strWhere2.Trim() != "")
            {
                coreSql.Append(" and " + strWhere2);
            }
            PrintSql(coreSql.ToString());
            return DbHelperSQL.Query(coreSql.ToString()).Tables[0];
        }


        /// <summary>
        /// 输出sql语句
        /// </summary>
        /// <param name="sql"></param>
        public static void PrintSql(String sql)
        {
            //try
            //{
            //    String filePath = System.Web.HttpContext.Current.Server.MapPath("~/sql.txt");
            //    if (!System.IO.File.Exists(filePath))
            //        System.IO.File.Create(filePath);
            //    System.IO.StreamWriter srw = new System.IO.StreamWriter(filePath, true);
            //    srw.WriteLine("TIME:" + DateTime.Now.ToString() + " SQL:" + sql);
            //    srw.Close();
            //    srw.Dispose();
            //}
            //catch (Exception)
            //{


            //}
        }

        /// <summary>
        /// 获取某个用户的科目
        /// </summary>
        /// <returns></returns>
        public static DataSet GetMySubject()
        {
            tbUser user = (tbUser)HttpContext.Current.Session[Constant.User];

            if (user.usertype == 1 || user.usertype == 4)
            {
                //管理员
                return DbHelperSQL.Query("select * from tbSubject");
            }
            if (user.usertype == 2)
            {
                //教师
                return DbHelperSQL.Query("select * from tbSubject where id in(select distinct subjectid from tbGrant where userid=" + user.id + ") order by subjectname");
            }
            if (user.usertype == 3)
            {
                //学生
                return DbHelperSQL.Query("select * from tbSubject where id in(select distinct subjectid from tbGrant,tbUser where tbGrant.classid=tbUser.classid and tbUser.id=" + user.id + ") order by subjectname");
            }
            return null;
        }

        /// <summary>
        /// 获取某个用户的科目ID字符串
        /// </summary>
        /// <returns></returns>
        public static String GetMySubjectString()
        {
            DataTable dt = MyUtil.GetMySubject().Tables[0];
            StringBuilder sb = new StringBuilder();
            sb.Append(" (");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append(dt.Rows[i]["id"].ToString());
                sb.Append(",");
            }
            String str = sb.ToString();
            if (str.EndsWith(","))
            {
                str = str.TrimEnd(',');
            }
            str = str + ")";
            return str;
        }

        /// <summary>
        /// 判断某个科目是否属于当前账户
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsGrantSubject(String str)
        {
            DataTable dt = MyUtil.GetMySubject().Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (str.Trim() == dt.Rows[i]["subjectname"].ToString().Trim())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 根据ChapterID获取SubjectID
        /// </summary>
        /// <param name="chapterid"></param>
        /// <returns></returns>
        public static int GetSubjectIDbyChapterID(int chapterid)
        {
            return (int)DbHelperSQL.GetSingle("select top 1 subjectid from tbChapter where id=" + chapterid);
        }

        /// <summary>
        /// 处理学生不交卷，故障的情况
        /// </summary>
        public static void UpdateScoreStatus()
        {
            tbScoreBLL scoreBLL = new tbScoreBLL();
            while (true)
            {
                System.Threading.Thread.Sleep(1000 * 60 * 5);//每5分钟
                List<tbScore> list = scoreBLL.GetModelList("scorestatus=2");
                DateTime dt = DateTime.Now;
                foreach (tbScore item in list)
                {
                    int duration = (int)DbHelperSQL.GetSingle("select durationtime from tbPaper,tbArrange where tbArrange.id=" + item.arrangeid + " and tbPaper.id=tbArrange.paperid");
                    TimeSpan ts = dt - item.starttime;
                    if ((ts.Duration().TotalMinutes - (duration + 5)) > 0)//给5分钟的时间误差
                    {
                        item.scorestatus = 4;
                        scoreBLL.Update(item);
                    }
                }
            }
        }
    }
}