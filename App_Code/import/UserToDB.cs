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
    public class UserToDB
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
            tbUserDAL userDAL = new tbUserDAL();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbUser user = new tbUser();
                String loginname = dt.Rows[i][0].ToString();
                String realname = dt.Rows[i][1].ToString();
                String userpwd = dt.Rows[i][2].ToString();
                String classname = dt.Rows[i][3].ToString();
                String usertype = dt.Rows[i][4].ToString();

                user.loginname = loginname;//登陆名
                user.realname = realname;//真实名

                if (usertype.Trim() == "学生")
                {
                    if (IsNum(loginname))
                    {
                        //班级
                        try
                        {
                            int classid = (int)DbHelperSQL.GetSingle("select top 1 id from tbClass where classname=@classname", new SqlParameter("@classname", classname));
                            user.classid = classid;
                        }
                        catch (Exception)
                        {
                            list.Add("行" + (i + 2) + "的班级不存在！");
                            continue;
                        }
                    }
                    else
                    {
                        list.Add("行" + (i + 2) + "的学号格式不正确！");
                        continue;
                    }
                    user.usertype = 3;
                }
                else
                    if (usertype.Trim() == "教师")
                    {
                        user.usertype = 2;
                    }
                    else
                    {
                        list.Add("行" + (i + 2) + "的身份格式不正确！");
                        continue;
                    }
                //密码
                try
                {
                    user.userpwd = MyUtil.MD5(GetPwdByCard(userpwd));
                }
                catch (Exception)
                {
                    list.Add("行" + (i + 2) + "的密码格式不正确！");
                    continue;
                }

                //判断登陆名是否存在
                if (DbHelperSQL.Exists("select * from tbUser where loginname=@loginname", new SqlParameter("@loginname", loginname)))
                {
                    list.Add("行" + (i + 2) + "的登陆名已经存在！");
                    continue;
                }

                userDAL.Add(user);
            }
            return list;
        }

        /// <summary>
        /// 判断字符串是否属于学号类型（数字字符串）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNum(String str)
        {
            Regex rex = new Regex(@"^\d+$");
            return rex.IsMatch(str);
        }

        /// <summary>
        /// 通过身份证号码获得密码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String GetPwdByCard(String str)
        {
            if (str.EndsWith("x") || str.EndsWith("X"))
            {
                return str.Substring(str.Length - 7, 6);
            }
            else
            {
                return str.Substring(str.Length - 6, 6);
            }
        }
    }
}
