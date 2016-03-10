using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Model;
using System.Data.OleDb;
using DAL;
using Maticsoft.DBUtility;

namespace Util
{
    public class CheckToDB
    {

        /// <summary>
        /// 从指定的Excel文件读取数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static DataTable GetDataFromExcel(String filepath)
        {
            String STRCONN = "PROVIDER=MICROSOFT.JET.OLEDB.4.0;" + "DATA SOURCE=" + filepath + ";" + "EXTENDED PROPERTIES=EXCEL 5.0;";
            String excelSql = "SELECT * FROM [sheet1$]";

            OleDbConnection conn = new OleDbConnection(STRCONN);
            OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(excelSql, conn);
            DataSet OleDsExcle = new DataSet();
            OleDaExcel.Fill(OleDsExcle, "Sheet1");
            conn.Close();

            for (int i = 0; i < OleDsExcle.Tables["Sheet1"].Rows.Count; i++)
            {
                for (int j = 0; j < OleDsExcle.Tables["Sheet1"].Columns.Count; j++)
                {
                    Console.Write(OleDsExcle.Tables["Sheet1"].Rows[i][j].ToString());
                }
                Console.WriteLine("============================");
            }
            return OleDsExcle.Tables["Sheet1"];
        }

        /// <summary>
        /// 导入到数据库
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>返回插入不成功的学号</returns>
        public static List<String> ExportToDB(DataTable dt)
        {
            List<String> list = new List<string>();
            tbCheckDAL checkDAL = new tbCheckDAL();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbCheck check = new tbCheck();
                int chapterid = GetChapterID(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                if (chapterid != 0)
                {
                    check.chapterid = chapterid;
                }
                else
                {
                    list.Add("行" + (i + 2) + "的科目或章节不存在！");
                    continue;
                }
                check.ques = dt.Rows[i][2].ToString().Trim();
                check.option_a = dt.Rows[i][3].ToString().Trim();
                check.option_b = dt.Rows[i][4].ToString().Trim();
                check.option_c = dt.Rows[i][5].ToString().Trim();
                check.option_d = dt.Rows[i][6].ToString().Trim();
                check.option_e = dt.Rows[i][7].ToString().Trim();
                check.option_f = dt.Rows[i][8].ToString().Trim();
                check.option_g = dt.Rows[i][9].ToString().Trim();

                String diff = dt.Rows[i][10].ToString();
                if (diff != "容易" && diff != "较易" && diff != "一般" && diff != "较难" && diff != "困难")
                {
                    list.Add("行" + (i + 2) + "的难度设置不正确！");
                    continue;
                }
                if (diff == "容易")
                {
                    check.diff = 1;
                }
                if (diff == "较易")
                {
                    check.diff = 2;
                }
                if (diff == "一般")
                {
                    check.diff = 3;
                }
                if (diff == "较难")
                {
                    check.diff = 4;
                }
                if (diff == "困难")
                {
                    check.diff = 5;
                }

                String ans = dt.Rows[i][11].ToString();
                if (ans==""||ans==null)
                {
                    list.Add("行" + (i + 2) + "的选项不正确！");
                    continue;
                }
                check.ans = ans;
                check.questype = 1;//随机类型
                //判断题目是否存在
                if (DbHelperSQL.Exists("select * from tbCheck where ques=@ques", new SqlParameter("@ques", check.ques)))
                {
                    list.Add("行" + (i + 2) + "的题目已经存在！");
                    continue;
                }
                checkDAL.Add(check);
            }
            return list;
        }


        /// <summary>
        /// 根据subjectname和chaptername获取chapterid
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="chapter"></param>
        /// <returns></returns>
        public static int GetChapterID(String subject, String chapterno)
        {
            int ret;
            String strSql = "select tbChapter.id from tbChapter,tbSubject where tbChapter.subjectid=tbSubject.id and subjectname=@subjectname and chapterno=@chapterno";
            if (!MyUtil.IsGrantSubject(subject))
            {
                return 0;
            }
            try
            {
                ret = (int)DbHelperSQL.GetSingle(strSql, new SqlParameter("@subjectname", subject), new SqlParameter("@chapterno", Convert.ToInt32(chapterno)));
            }
            catch (Exception)
            {
                ret = 0;
            }
            return ret;
        }
    }
}
