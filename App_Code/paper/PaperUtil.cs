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
using System.Data.SqlClient;

namespace Util
{
    /// <summary>
    ///Util 的摘要说明
    /// </summary>
    public class PaperUtil
    {
        public PaperUtil()
        {
        }

        public static int GetQuesCount(int subjectid, String tableName)
        {
            String strSql = "select count(*) from " + tableName + " where chapterid in (select id from tbChapter where subjectid=" + subjectid + ");";
            MyUtil.PrintSql(strSql);
            return (int)DbHelperSQL.GetSingle(strSql);
        }

        public static DataSet GetQuesCountDetail(int subjectid, String tableName)
        {
            String strSql = "SELECT [tbChapter].[id],[chapterno],[chaptername],COUNT([chaptername]) AS AllCount FROM [tbChapter] ," + tableName + " WHERE [tbChapter].[id]=" + tableName + ".[chapterid] AND subjectid=@subjectid GROUP BY [tbChapter].[id],[chaptername],[chapterno] ORDER BY [chapterno]";
            MyUtil.PrintSql(strSql);
            return DbHelperSQL.Query(strSql, new SqlParameter("@subjectid",subjectid));
        }
    }
}