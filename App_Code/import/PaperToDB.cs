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
using System.Web;

namespace Util
{
    public class PaperToDB
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

            tbPaper paper = new tbPaper();
            tbSingle single = new tbSingle();
            tbCheck check = new tbCheck();
            tbJudge judge = new tbJudge();
            tbBlank blank = new tbBlank();
            tbAnswer answer = new tbAnswer();

            tbPaperDAL paperDAL = new tbPaperDAL();
            tbSingleDAL singleDAL = new tbSingleDAL();
            tbCheckDAL checkDAL = new tbCheckDAL();
            tbJudgeDAL judgeDAL = new tbJudgeDAL();
            tbBlankDAL blankDAL = new tbBlankDAL();
            tbAnswerDAL answerDAL = new tbAnswerDAL();
            //取得数据库连接
            SqlConnection conn = SQLHelper.GetConnection();
            //打开数据库连接
            conn.Open();
            //创建事务
            SqlTransaction SqlTransaction = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String flag = dt.Rows[i][0].ToString();
                    String temp = dt.Rows[i][1].ToString();
                    switch (flag)
                    {
                        case "#科目#":
                            //获取科目id
                            try
                            {
                                int subjectid = (int)DbHelperSQL.GetSingle("select id from tbSubject where subjectname=@subjectname and id in" + MyUtil.GetMySubjectString(), new SqlParameter("@subjectname", dt.Rows[i][1].ToString()));
                                paper.subjectid = subjectid;
                            }
                            catch (Exception)
                            {
                                list.Add("科目不存在或者没有权限！");
                                continue;
                            }
                            break;
                        case "#标题#":
                            paper.papertitle = dt.Rows[i][1].ToString();
                            if (String.IsNullOrEmpty(paper.papertitle))
                            {
                                list.Add("标题设置不正确！");
                                continue;
                            }
                            break;
                        case "#时间#":
                            try
                            {
                                paper.durationtime = Convert.ToInt32(dt.Rows[i][1].ToString().TrimEnd('分'));
                            }
                            catch (Exception)
                            {
                                list.Add("时间格式不正确！");
                                continue;
                            }
                            break;
                        case "#单选分值#":
                            try
                            {
                                paper.sr_scoreofeach = Convert.ToInt32(dt.Rows[i][1].ToString().TrimEnd('分'));
                            }
                            catch (Exception)
                            {
                                list.Add("单选分值格式不正确！");
                                continue;
                            }
                            break;
                        case "#多选分值#":
                            try
                            {
                                paper.cb_scoreofeach = Convert.ToInt32(dt.Rows[i][1].ToString().TrimEnd('分'));
                            }
                            catch (Exception)
                            {
                                list.Add("多选分值格式不正确！");
                                continue;
                            }
                            break;
                        case "#判断分值#":
                            try
                            {
                                paper.jd_scoreofeach = Convert.ToInt32(dt.Rows[i][1].ToString().TrimEnd('分'));
                            }
                            catch (Exception)
                            {
                                list.Add("判断分值格式不正确！");
                                continue;
                            }
                            break;
                        case "#填空分值#":
                            try
                            {
                                paper.bf_scoreofeach = Convert.ToInt32(dt.Rows[i][1].ToString().TrimEnd('分'));
                            }
                            catch (Exception)
                            {
                                list.Add("填空分值格式不正确！");
                                continue;
                            }
                            break;
                        case "#简答分值#":
                            try
                            {
                                paper.sa_scoreofeach = Convert.ToInt32(dt.Rows[i][1].ToString().TrimEnd('分'));
                            }
                            catch (Exception)
                            {
                                list.Add("简答分值格式不正确！");
                                continue;
                            }
                            break;
                        case "#单选#":
                            single.chapterid = 0;//不属于任何章节
                            single.diff = 3;//默认难度一般
                            single.questype = 2;//固定类型
                            single.ques = dt.Rows[i][1].ToString();
                            single.option_a = dt.Rows[i][2].ToString();
                            single.option_b = dt.Rows[i][3].ToString();
                            single.option_c = dt.Rows[i][4].ToString();
                            single.option_d = dt.Rows[i][5].ToString();
                            single.ans = dt.Rows[i][6].ToString();
                            if (single.ans != "A" && single.ans != "B" && single.ans != "C" && single.ans != "D")
                            {
                                list.Add("行" + (i + 2) + "的单选答案不正确！");
                                continue;
                            }
                            int singleid = singleDAL.AddTran(single, SqlTransaction);
                            paper.sr_list += singleid + ",";
                            paper.sr_count += 1;
                            break;
                        case "#多选#":
                            check.chapterid = 0;//不属于任何章节
                            check.diff = 3;//默认难度一般
                            check.questype = 2;//固定类型
                            check.ques = dt.Rows[i][1].ToString();
                            check.option_a = dt.Rows[i][2].ToString();
                            check.option_b = dt.Rows[i][3].ToString();
                            check.option_c = dt.Rows[i][4].ToString();
                            check.option_d = dt.Rows[i][5].ToString();
                            check.option_e = dt.Rows[i][6].ToString();
                            check.option_f = dt.Rows[i][7].ToString();
                            check.option_g = dt.Rows[i][8].ToString();
                            check.ans = dt.Rows[i][9].ToString();
                            if (check.ans == "" || check.ans == null)
                            {
                                list.Add("行" + (i + 2) + "的多选答案不正确！");
                                continue;
                            }
                            int checkid = checkDAL.AddTran(check, SqlTransaction);
                            paper.cb_list += checkid + ",";
                            paper.cb_count += 1;
                            break;
                        case "#判断#":
                            judge.chapterid = 0;//不属于任何章节
                            judge.diff = 3;//默认难度一般
                            judge.questype = 2;//固定类型
                            judge.ques = dt.Rows[i][1].ToString();
                            judge.ans = dt.Rows[i][2].ToString();
                            if (judge.ans != "对" && judge.ans != "错")
                            {
                                list.Add("行" + (i + 2) + "的判断答案不正确！");
                                continue;
                            }
                            int judgeid = judgeDAL.AddTran(judge, SqlTransaction);
                            paper.jd_list += judgeid + ",";
                            paper.jd_count += 1;
                            break;
                        case "#填空#":
                            blank.chapterid = 0;//不属于任何章节
                            blank.diff = 3;//默认难度一般
                            blank.questype = 2;//固定类型
                            blank.ques = dt.Rows[i][1].ToString();
                            blank.ans = dt.Rows[i][2].ToString();
                            blank.blanklength = blank.ans.Length;
                            int blankid = blankDAL.AddTran(blank, SqlTransaction);
                            paper.bf_list += blankid + ",";
                            paper.bf_count += 1;
                            break;
                        case "#简答#":
                            answer.chapterid = 0;//不属于任何章节
                            answer.diff = 3;//默认难度一般
                            answer.questype = 2;//固定类型
                            answer.ques = dt.Rows[i][1].ToString();
                            answer.ans = dt.Rows[i][2].ToString();
                            int answerid = answerDAL.AddTran(answer, SqlTransaction);
                            paper.sa_list += answerid + ",";
                            paper.sa_count += 1;
                            break;
                    }
                }
                if (list.Count == 0)
                {
                    if (paper.sr_list.EndsWith(","))
                    {
                        paper.sr_list = paper.sr_list.TrimEnd(',');
                    }
                    if (paper.cb_list.EndsWith(","))
                    {
                        paper.cb_list = paper.cb_list.TrimEnd(',');
                    }
                    if (paper.jd_list.EndsWith(","))
                    {
                        paper.jd_list = paper.jd_list.TrimEnd(',');
                    }
                    if (paper.bf_list.EndsWith(","))
                    {
                        paper.bf_list = paper.bf_list.TrimEnd(',');
                    }
                    if (paper.sa_list.EndsWith(","))
                    {
                        paper.sa_list = paper.sa_list.TrimEnd(',');
                    }
                    paper.allscore = paper.sr_count * paper.sr_scoreofeach + paper.cb_count * paper.cb_scoreofeach + paper.jd_count * paper.jd_scoreofeach + paper.bf_count * paper.bf_scoreofeach + paper.sa_count * paper.sa_scoreofeach;
                    paper.papertype = 2;//固定试卷
                    paper.createtime = DateTime.Now;
                    paper.userid = ((tbUser)HttpContext.Current.Session[Constant.User]).id;
                    paperDAL.AddTran(paper, SqlTransaction);
                    SqlTransaction.Commit();
                }
            }
            catch (Exception)
            {
                try
                {
                    SqlTransaction.Rollback();
                }
                catch (Exception)
                {
                    //事务回滚出错
                }
            }
            finally
            {
                //关闭各种资源
                SqlTransaction.Dispose();
                conn.Close();
            }

            return list;
        }

    }
}
