using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace DAL  
{
	 	//tbPaperDAL
		public partial class tbPaperDAL
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbPaper");
			strSql.Append(" where ");
			                                       strSql.Append(" id = @id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			Util.MyUtil.PrintSql(strSql.ToString());
			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.tbPaper model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbPaper(");			
            strSql.Append("subjectid,userid,papertitle,diff,allscore,durationtime,createtime,papertype,sr_count,sr_scoreofeach,sr_diff,sr_chapterrange,sr_countofeachchatper,cb_count,cb_scoreofeach,cb_diff,cb_chapterrange,cb_countofeachchapter,jd_count,jd_scoreofeach,jd_diff,jd_chapterrange,jd_countofeachchapter,bf_count,bf_scoreofeach,bf_diff,bf_chapterrange,bf_countofeachchapter,sa_count,sa_scoreofeach,sa_diff,sa_chapterrange,sa_countofeachchapter,sr_list,cb_list,jd_list,bf_list,sa_list");
			strSql.Append(") values (");
            strSql.Append("@subjectid,@userid,@papertitle,@diff,@allscore,@durationtime,@createtime,@papertype,@sr_count,@sr_scoreofeach,@sr_diff,@sr_chapterrange,@sr_countofeachchatper,@cb_count,@cb_scoreofeach,@cb_diff,@cb_chapterrange,@cb_countofeachchapter,@jd_count,@jd_scoreofeach,@jd_diff,@jd_chapterrange,@jd_countofeachchapter,@bf_count,@bf_scoreofeach,@bf_diff,@bf_chapterrange,@bf_countofeachchapter,@sa_count,@sa_scoreofeach,@sa_diff,@sa_chapterrange,@sa_countofeachchapter,@sr_list,@cb_list,@jd_list,@bf_list,@sa_list");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@subjectid", SqlDbType.Int,4) ,            
                        new SqlParameter("@userid", SqlDbType.Int,4) ,            
                        new SqlParameter("@papertitle", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@diff", SqlDbType.Float,8) ,            
                        new SqlParameter("@allscore", SqlDbType.Int,4) ,            
                        new SqlParameter("@durationtime", SqlDbType.Int,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@papertype", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sr_countofeachchatper", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@cb_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@cb_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@cb_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@cb_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@cb_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@jd_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@jd_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@jd_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@jd_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@jd_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@bf_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@bf_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@bf_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@bf_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@bf_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sa_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@sa_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@sa_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@sa_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sa_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sr_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@cb_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@jd_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@bf_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@sa_list", SqlDbType.NVarChar,2000)             
              
            };
			            
            parameters[0].Value = model.subjectid;                        
            parameters[1].Value = model.userid;                        
            parameters[2].Value = model.papertitle;                        
            parameters[3].Value = model.diff;                        
            parameters[4].Value = model.allscore;                        
            parameters[5].Value = model.durationtime;                        
            parameters[6].Value = model.createtime;                        
            parameters[7].Value = model.papertype;                        
            parameters[8].Value = model.sr_count;                        
            parameters[9].Value = model.sr_scoreofeach;                        
            parameters[10].Value = model.sr_diff;                        
            parameters[11].Value = model.sr_chapterrange;                        
            parameters[12].Value = model.sr_countofeachchatper;                        
            parameters[13].Value = model.cb_count;                        
            parameters[14].Value = model.cb_scoreofeach;                        
            parameters[15].Value = model.cb_diff;                        
            parameters[16].Value = model.cb_chapterrange;                        
            parameters[17].Value = model.cb_countofeachchapter;                        
            parameters[18].Value = model.jd_count;                        
            parameters[19].Value = model.jd_scoreofeach;                        
            parameters[20].Value = model.jd_diff;                        
            parameters[21].Value = model.jd_chapterrange;                        
            parameters[22].Value = model.jd_countofeachchapter;                        
            parameters[23].Value = model.bf_count;                        
            parameters[24].Value = model.bf_scoreofeach;                        
            parameters[25].Value = model.bf_diff;                        
            parameters[26].Value = model.bf_chapterrange;                        
            parameters[27].Value = model.bf_countofeachchapter;                        
            parameters[28].Value = model.sa_count;                        
            parameters[29].Value = model.sa_scoreofeach;                        
            parameters[30].Value = model.sa_diff;                        
            parameters[31].Value = model.sa_chapterrange;                        
            parameters[32].Value = model.sa_countofeachchapter;                        
            parameters[33].Value = model.sr_list;                        
            parameters[34].Value = model.cb_list;                        
            parameters[35].Value = model.jd_list;                        
            parameters[36].Value = model.bf_list;                        
            parameters[37].Value = model.sa_list;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
			if (obj == null)
			{
				return 0;
			}
			else
			{
				                    
            	return Convert.ToInt32(obj);
                                                                  
			}
			 Util.MyUtil.PrintSql(strSql.ToString());
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.tbPaper model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbPaper set ");
			                                                
            strSql.Append(" subjectid = @subjectid , ");                                    
            strSql.Append(" userid = @userid , ");                                    
            strSql.Append(" papertitle = @papertitle , ");                                    
            strSql.Append(" diff = @diff , ");                                    
            strSql.Append(" allscore = @allscore , ");                                    
            strSql.Append(" durationtime = @durationtime , ");                                    
            strSql.Append(" createtime = @createtime , ");                                    
            strSql.Append(" papertype = @papertype , ");                                    
            strSql.Append(" sr_count = @sr_count , ");                                    
            strSql.Append(" sr_scoreofeach = @sr_scoreofeach , ");                                    
            strSql.Append(" sr_diff = @sr_diff , ");                                    
            strSql.Append(" sr_chapterrange = @sr_chapterrange , ");                                    
            strSql.Append(" sr_countofeachchatper = @sr_countofeachchatper , ");                                    
            strSql.Append(" cb_count = @cb_count , ");                                    
            strSql.Append(" cb_scoreofeach = @cb_scoreofeach , ");                                    
            strSql.Append(" cb_diff = @cb_diff , ");                                    
            strSql.Append(" cb_chapterrange = @cb_chapterrange , ");                                    
            strSql.Append(" cb_countofeachchapter = @cb_countofeachchapter , ");                                    
            strSql.Append(" jd_count = @jd_count , ");                                    
            strSql.Append(" jd_scoreofeach = @jd_scoreofeach , ");                                    
            strSql.Append(" jd_diff = @jd_diff , ");                                    
            strSql.Append(" jd_chapterrange = @jd_chapterrange , ");                                    
            strSql.Append(" jd_countofeachchapter = @jd_countofeachchapter , ");                                    
            strSql.Append(" bf_count = @bf_count , ");                                    
            strSql.Append(" bf_scoreofeach = @bf_scoreofeach , ");                                    
            strSql.Append(" bf_diff = @bf_diff , ");                                    
            strSql.Append(" bf_chapterrange = @bf_chapterrange , ");                                    
            strSql.Append(" bf_countofeachchapter = @bf_countofeachchapter , ");                                    
            strSql.Append(" sa_count = @sa_count , ");                                    
            strSql.Append(" sa_scoreofeach = @sa_scoreofeach , ");                                    
            strSql.Append(" sa_diff = @sa_diff , ");                                    
            strSql.Append(" sa_chapterrange = @sa_chapterrange , ");                                    
            strSql.Append(" sa_countofeachchapter = @sa_countofeachchapter , ");                                    
            strSql.Append(" sr_list = @sr_list , ");                                    
            strSql.Append(" cb_list = @cb_list , ");                                    
            strSql.Append(" jd_list = @jd_list , ");                                    
            strSql.Append(" bf_list = @bf_list , ");                                    
            strSql.Append(" sa_list = @sa_list  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@subjectid", SqlDbType.Int,4) ,            
                        new SqlParameter("@userid", SqlDbType.Int,4) ,            
                        new SqlParameter("@papertitle", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@diff", SqlDbType.Float,8) ,            
                        new SqlParameter("@allscore", SqlDbType.Int,4) ,            
                        new SqlParameter("@durationtime", SqlDbType.Int,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@papertype", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sr_countofeachchatper", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@cb_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@cb_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@cb_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@cb_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@cb_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@jd_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@jd_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@jd_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@jd_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@jd_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@bf_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@bf_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@bf_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@bf_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@bf_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sa_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@sa_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@sa_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@sa_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sa_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sr_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@cb_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@jd_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@bf_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@sa_list", SqlDbType.NVarChar,2000)             
              
            };
            			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.subjectid;                        
            parameters[2].Value = model.userid;                        
            parameters[3].Value = model.papertitle;                        
            parameters[4].Value = model.diff;                        
            parameters[5].Value = model.allscore;                        
            parameters[6].Value = model.durationtime;                        
            parameters[7].Value = model.createtime;                        
            parameters[8].Value = model.papertype;                        
            parameters[9].Value = model.sr_count;                        
            parameters[10].Value = model.sr_scoreofeach;                        
            parameters[11].Value = model.sr_diff;                        
            parameters[12].Value = model.sr_chapterrange;                        
            parameters[13].Value = model.sr_countofeachchatper;                        
            parameters[14].Value = model.cb_count;                        
            parameters[15].Value = model.cb_scoreofeach;                        
            parameters[16].Value = model.cb_diff;                        
            parameters[17].Value = model.cb_chapterrange;                        
            parameters[18].Value = model.cb_countofeachchapter;                        
            parameters[19].Value = model.jd_count;                        
            parameters[20].Value = model.jd_scoreofeach;                        
            parameters[21].Value = model.jd_diff;                        
            parameters[22].Value = model.jd_chapterrange;                        
            parameters[23].Value = model.jd_countofeachchapter;                        
            parameters[24].Value = model.bf_count;                        
            parameters[25].Value = model.bf_scoreofeach;                        
            parameters[26].Value = model.bf_diff;                        
            parameters[27].Value = model.bf_chapterrange;                        
            parameters[28].Value = model.bf_countofeachchapter;                        
            parameters[29].Value = model.sa_count;                        
            parameters[30].Value = model.sa_scoreofeach;                        
            parameters[31].Value = model.sa_diff;                        
            parameters[32].Value = model.sa_chapterrange;                        
            parameters[33].Value = model.sa_countofeachchapter;                        
            parameters[34].Value = model.sr_list;                        
            parameters[35].Value = model.cb_list;                        
            parameters[36].Value = model.jd_list;                        
            parameters[37].Value = model.bf_list;                        
            parameters[38].Value = model.sa_list;                       Util.MyUtil.PrintSql(strSql.ToString());
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbPaper ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			 Util.MyUtil.PrintSql(strSql.ToString());
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
				/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbPaper ");
			strSql.Append(" where ID in ("+idlist + ")  ");
			 Util.MyUtil.PrintSql(strSql.ToString());
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.tbPaper GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, subjectid, userid, papertitle, diff, allscore, durationtime, createtime, papertype, sr_count, sr_scoreofeach, sr_diff, sr_chapterrange, sr_countofeachchatper, cb_count, cb_scoreofeach, cb_diff, cb_chapterrange, cb_countofeachchapter, jd_count, jd_scoreofeach, jd_diff, jd_chapterrange, jd_countofeachchapter, bf_count, bf_scoreofeach, bf_diff, bf_chapterrange, bf_countofeachchapter, sa_count, sa_scoreofeach, sa_diff, sa_chapterrange, sa_countofeachchapter, sr_list, cb_list, jd_list, bf_list, sa_list  ");			
			strSql.Append("  from tbPaper ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			 Util.MyUtil.PrintSql(strSql.ToString());
			Model.tbPaper model=new Model.tbPaper();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["subjectid"].ToString()!="")
				{
					model.subjectid=int.Parse(ds.Tables[0].Rows[0]["subjectid"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["userid"].ToString()!="")
				{
					model.userid=int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
				}
																																				model.papertitle= ds.Tables[0].Rows[0]["papertitle"].ToString();
																												if(ds.Tables[0].Rows[0]["diff"].ToString()!="")
				{
					model.diff=decimal.Parse(ds.Tables[0].Rows[0]["diff"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["allscore"].ToString()!="")
				{
					model.allscore=int.Parse(ds.Tables[0].Rows[0]["allscore"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["durationtime"].ToString()!="")
				{
					model.durationtime=int.Parse(ds.Tables[0].Rows[0]["durationtime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(ds.Tables[0].Rows[0]["createtime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["papertype"].ToString()!="")
				{
					model.papertype=int.Parse(ds.Tables[0].Rows[0]["papertype"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["sr_count"].ToString()!="")
				{
					model.sr_count=int.Parse(ds.Tables[0].Rows[0]["sr_count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["sr_scoreofeach"].ToString()!="")
				{
					model.sr_scoreofeach=int.Parse(ds.Tables[0].Rows[0]["sr_scoreofeach"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["sr_diff"].ToString()!="")
				{
					model.sr_diff=int.Parse(ds.Tables[0].Rows[0]["sr_diff"].ToString());
				}
																																				model.sr_chapterrange= ds.Tables[0].Rows[0]["sr_chapterrange"].ToString();
																																model.sr_countofeachchatper= ds.Tables[0].Rows[0]["sr_countofeachchatper"].ToString();
																												if(ds.Tables[0].Rows[0]["cb_count"].ToString()!="")
				{
					model.cb_count=int.Parse(ds.Tables[0].Rows[0]["cb_count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["cb_scoreofeach"].ToString()!="")
				{
					model.cb_scoreofeach=int.Parse(ds.Tables[0].Rows[0]["cb_scoreofeach"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["cb_diff"].ToString()!="")
				{
					model.cb_diff=int.Parse(ds.Tables[0].Rows[0]["cb_diff"].ToString());
				}
																																				model.cb_chapterrange= ds.Tables[0].Rows[0]["cb_chapterrange"].ToString();
																																model.cb_countofeachchapter= ds.Tables[0].Rows[0]["cb_countofeachchapter"].ToString();
																												if(ds.Tables[0].Rows[0]["jd_count"].ToString()!="")
				{
					model.jd_count=int.Parse(ds.Tables[0].Rows[0]["jd_count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["jd_scoreofeach"].ToString()!="")
				{
					model.jd_scoreofeach=int.Parse(ds.Tables[0].Rows[0]["jd_scoreofeach"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["jd_diff"].ToString()!="")
				{
					model.jd_diff=int.Parse(ds.Tables[0].Rows[0]["jd_diff"].ToString());
				}
																																				model.jd_chapterrange= ds.Tables[0].Rows[0]["jd_chapterrange"].ToString();
																																model.jd_countofeachchapter= ds.Tables[0].Rows[0]["jd_countofeachchapter"].ToString();
																												if(ds.Tables[0].Rows[0]["bf_count"].ToString()!="")
				{
					model.bf_count=int.Parse(ds.Tables[0].Rows[0]["bf_count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["bf_scoreofeach"].ToString()!="")
				{
					model.bf_scoreofeach=int.Parse(ds.Tables[0].Rows[0]["bf_scoreofeach"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["bf_diff"].ToString()!="")
				{
					model.bf_diff=int.Parse(ds.Tables[0].Rows[0]["bf_diff"].ToString());
				}
																																				model.bf_chapterrange= ds.Tables[0].Rows[0]["bf_chapterrange"].ToString();
																																model.bf_countofeachchapter= ds.Tables[0].Rows[0]["bf_countofeachchapter"].ToString();
																												if(ds.Tables[0].Rows[0]["sa_count"].ToString()!="")
				{
					model.sa_count=int.Parse(ds.Tables[0].Rows[0]["sa_count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["sa_scoreofeach"].ToString()!="")
				{
					model.sa_scoreofeach=int.Parse(ds.Tables[0].Rows[0]["sa_scoreofeach"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["sa_diff"].ToString()!="")
				{
					model.sa_diff=int.Parse(ds.Tables[0].Rows[0]["sa_diff"].ToString());
				}
																																				model.sa_chapterrange= ds.Tables[0].Rows[0]["sa_chapterrange"].ToString();
																																model.sa_countofeachchapter= ds.Tables[0].Rows[0]["sa_countofeachchapter"].ToString();
																																model.sr_list= ds.Tables[0].Rows[0]["sr_list"].ToString();
																																model.cb_list= ds.Tables[0].Rows[0]["cb_list"].ToString();
																																model.jd_list= ds.Tables[0].Rows[0]["jd_list"].ToString();
																																model.bf_list= ds.Tables[0].Rows[0]["bf_list"].ToString();
																																model.sa_list= ds.Tables[0].Rows[0]["sa_list"].ToString();
																										
				return model;
			}
			else
			{
				return null;
			}
		}
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM tbPaper ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			 Util.MyUtil.PrintSql(strSql.ToString());
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM tbPaper ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			Util.MyUtil.PrintSql(strSql.ToString());
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
        /// 获得单表的分页查询结果
        /// </summary>
        /// <param name="pageSize">每页显示的记录</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序字段</param>
        /// <returns></returns>
		public DataSet GetListByIndex(int pageSize,int pageIndex,string strWhere,string filedOrder)
		{
		    StringBuilder coreSql = new StringBuilder();
            coreSql.Append("select top " + (pageIndex - 1) * pageSize + " id from tbPaper where 1=1 ");
            if (strWhere.Trim() != "")
            {
                coreSql.Append(" and " + strWhere);
            }
            if (filedOrder != "")
            {
                coreSql.Append("ORDER BY " + filedOrder + " ");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " * from tbPaper where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" and id not in(" + coreSql.ToString() + ")");
            if (filedOrder != "")
            {
                strSql.Append(" ORDER BY " + filedOrder + " ");
            }
            Util.MyUtil.PrintSql(strSql.ToString());
            return DbHelperSQL.Query(strSql.ToString());		
		}
		
		/// <summary>
        /// 获取该表的总记录数
        /// </summary>
        /// <returns></returns>
		public int GetCount()
		{
			String strSql="select count(*) from tbPaper";
			Util.MyUtil.PrintSql(strSql.ToString());
			return Convert.ToInt32(DbHelperSQL.GetSingle(strSql));
		}
		
		/// <summary>
        /// 获得某条件所返回的记录数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
		public int GetCount(String strWhere)
		{
			String strSql="select count(*) from tbPaper where "+strWhere;
			Util.MyUtil.PrintSql(strSql.ToString());
			return Convert.ToInt32(DbHelperSQL.GetSingle(strSql));
		}
        
        #region 支持事务
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddTran(Model.tbPaper model,SqlTransaction transaction)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbPaper(");			
            strSql.Append("subjectid,userid,papertitle,diff,allscore,durationtime,createtime,papertype,sr_count,sr_scoreofeach,sr_diff,sr_chapterrange,sr_countofeachchatper,cb_count,cb_scoreofeach,cb_diff,cb_chapterrange,cb_countofeachchapter,jd_count,jd_scoreofeach,jd_diff,jd_chapterrange,jd_countofeachchapter,bf_count,bf_scoreofeach,bf_diff,bf_chapterrange,bf_countofeachchapter,sa_count,sa_scoreofeach,sa_diff,sa_chapterrange,sa_countofeachchapter,sr_list,cb_list,jd_list,bf_list,sa_list");
			strSql.Append(") values (");
            strSql.Append("@subjectid,@userid,@papertitle,@diff,@allscore,@durationtime,@createtime,@papertype,@sr_count,@sr_scoreofeach,@sr_diff,@sr_chapterrange,@sr_countofeachchatper,@cb_count,@cb_scoreofeach,@cb_diff,@cb_chapterrange,@cb_countofeachchapter,@jd_count,@jd_scoreofeach,@jd_diff,@jd_chapterrange,@jd_countofeachchapter,@bf_count,@bf_scoreofeach,@bf_diff,@bf_chapterrange,@bf_countofeachchapter,@sa_count,@sa_scoreofeach,@sa_diff,@sa_chapterrange,@sa_countofeachchapter,@sr_list,@cb_list,@jd_list,@bf_list,@sa_list");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@subjectid", SqlDbType.Int,4) ,            
                        new SqlParameter("@userid", SqlDbType.Int,4) ,            
                        new SqlParameter("@papertitle", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@diff", SqlDbType.Float,8) ,            
                        new SqlParameter("@allscore", SqlDbType.Int,4) ,            
                        new SqlParameter("@durationtime", SqlDbType.Int,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@papertype", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sr_countofeachchatper", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@cb_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@cb_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@cb_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@cb_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@cb_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@jd_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@jd_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@jd_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@jd_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@jd_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@bf_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@bf_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@bf_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@bf_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@bf_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sa_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@sa_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@sa_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@sa_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sa_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sr_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@cb_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@jd_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@bf_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@sa_list", SqlDbType.NVarChar,2000)             
              
            };
            			            
            parameters[0].Value = model.subjectid;                        
            parameters[1].Value = model.userid;                        
            parameters[2].Value = model.papertitle;                        
            parameters[3].Value = model.diff;                        
            parameters[4].Value = model.allscore;                        
            parameters[5].Value = model.durationtime;                        
            parameters[6].Value = model.createtime;                        
            parameters[7].Value = model.papertype;                        
            parameters[8].Value = model.sr_count;                        
            parameters[9].Value = model.sr_scoreofeach;                        
            parameters[10].Value = model.sr_diff;                        
            parameters[11].Value = model.sr_chapterrange;                        
            parameters[12].Value = model.sr_countofeachchatper;                        
            parameters[13].Value = model.cb_count;                        
            parameters[14].Value = model.cb_scoreofeach;                        
            parameters[15].Value = model.cb_diff;                        
            parameters[16].Value = model.cb_chapterrange;                        
            parameters[17].Value = model.cb_countofeachchapter;                        
            parameters[18].Value = model.jd_count;                        
            parameters[19].Value = model.jd_scoreofeach;                        
            parameters[20].Value = model.jd_diff;                        
            parameters[21].Value = model.jd_chapterrange;                        
            parameters[22].Value = model.jd_countofeachchapter;                        
            parameters[23].Value = model.bf_count;                        
            parameters[24].Value = model.bf_scoreofeach;                        
            parameters[25].Value = model.bf_diff;                        
            parameters[26].Value = model.bf_chapterrange;                        
            parameters[27].Value = model.bf_countofeachchapter;                        
            parameters[28].Value = model.sa_count;                        
            parameters[29].Value = model.sa_scoreofeach;                        
            parameters[30].Value = model.sa_diff;                        
            parameters[31].Value = model.sa_chapterrange;                        
            parameters[32].Value = model.sa_countofeachchapter;                        
            parameters[33].Value = model.sr_list;                        
            parameters[34].Value = model.cb_list;                        
            parameters[35].Value = model.jd_list;                        
            parameters[36].Value = model.bf_list;                        
            parameters[37].Value = model.sa_list;                        
			   
			object obj = SQLHelper.ExecuteScalar(transaction,CommandType.Text, strSql.ToString(), parameters);	
			
			if (obj == null)
			{
				return 0;
			}
			else
			{
				                    
            	return Convert.ToInt32(obj);
                                                                  
			}
			 Util.MyUtil.PrintSql(strSql.ToString());
            			
		}
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool UpdateTran(Model.tbPaper model,SqlTransaction transaction)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbPaper set ");
			                                                
            strSql.Append(" subjectid = @subjectid , ");                                    
            strSql.Append(" userid = @userid , ");                                    
            strSql.Append(" papertitle = @papertitle , ");                                    
            strSql.Append(" diff = @diff , ");                                    
            strSql.Append(" allscore = @allscore , ");                                    
            strSql.Append(" durationtime = @durationtime , ");                                    
            strSql.Append(" createtime = @createtime , ");                                    
            strSql.Append(" papertype = @papertype , ");                                    
            strSql.Append(" sr_count = @sr_count , ");                                    
            strSql.Append(" sr_scoreofeach = @sr_scoreofeach , ");                                    
            strSql.Append(" sr_diff = @sr_diff , ");                                    
            strSql.Append(" sr_chapterrange = @sr_chapterrange , ");                                    
            strSql.Append(" sr_countofeachchatper = @sr_countofeachchatper , ");                                    
            strSql.Append(" cb_count = @cb_count , ");                                    
            strSql.Append(" cb_scoreofeach = @cb_scoreofeach , ");                                    
            strSql.Append(" cb_diff = @cb_diff , ");                                    
            strSql.Append(" cb_chapterrange = @cb_chapterrange , ");                                    
            strSql.Append(" cb_countofeachchapter = @cb_countofeachchapter , ");                                    
            strSql.Append(" jd_count = @jd_count , ");                                    
            strSql.Append(" jd_scoreofeach = @jd_scoreofeach , ");                                    
            strSql.Append(" jd_diff = @jd_diff , ");                                    
            strSql.Append(" jd_chapterrange = @jd_chapterrange , ");                                    
            strSql.Append(" jd_countofeachchapter = @jd_countofeachchapter , ");                                    
            strSql.Append(" bf_count = @bf_count , ");                                    
            strSql.Append(" bf_scoreofeach = @bf_scoreofeach , ");                                    
            strSql.Append(" bf_diff = @bf_diff , ");                                    
            strSql.Append(" bf_chapterrange = @bf_chapterrange , ");                                    
            strSql.Append(" bf_countofeachchapter = @bf_countofeachchapter , ");                                    
            strSql.Append(" sa_count = @sa_count , ");                                    
            strSql.Append(" sa_scoreofeach = @sa_scoreofeach , ");                                    
            strSql.Append(" sa_diff = @sa_diff , ");                                    
            strSql.Append(" sa_chapterrange = @sa_chapterrange , ");                                    
            strSql.Append(" sa_countofeachchapter = @sa_countofeachchapter , ");                                    
            strSql.Append(" sr_list = @sr_list , ");                                    
            strSql.Append(" cb_list = @cb_list , ");                                    
            strSql.Append(" jd_list = @jd_list , ");                                    
            strSql.Append(" bf_list = @bf_list , ");                                    
            strSql.Append(" sa_list = @sa_list  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@subjectid", SqlDbType.Int,4) ,            
                        new SqlParameter("@userid", SqlDbType.Int,4) ,            
                        new SqlParameter("@papertitle", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@diff", SqlDbType.Float,8) ,            
                        new SqlParameter("@allscore", SqlDbType.Int,4) ,            
                        new SqlParameter("@durationtime", SqlDbType.Int,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@papertype", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sr_countofeachchatper", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@cb_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@cb_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@cb_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@cb_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@cb_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@jd_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@jd_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@jd_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@jd_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@jd_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@bf_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@bf_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@bf_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@bf_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@bf_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sa_count", SqlDbType.Int,4) ,            
                        new SqlParameter("@sa_scoreofeach", SqlDbType.Int,4) ,            
                        new SqlParameter("@sa_diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@sa_chapterrange", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sa_countofeachchapter", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sr_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@cb_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@jd_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@bf_list", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@sa_list", SqlDbType.NVarChar,2000)             
              
            };
            			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.subjectid;                        
            parameters[2].Value = model.userid;                        
            parameters[3].Value = model.papertitle;                        
            parameters[4].Value = model.diff;                        
            parameters[5].Value = model.allscore;                        
            parameters[6].Value = model.durationtime;                        
            parameters[7].Value = model.createtime;                        
            parameters[8].Value = model.papertype;                        
            parameters[9].Value = model.sr_count;                        
            parameters[10].Value = model.sr_scoreofeach;                        
            parameters[11].Value = model.sr_diff;                        
            parameters[12].Value = model.sr_chapterrange;                        
            parameters[13].Value = model.sr_countofeachchatper;                        
            parameters[14].Value = model.cb_count;                        
            parameters[15].Value = model.cb_scoreofeach;                        
            parameters[16].Value = model.cb_diff;                        
            parameters[17].Value = model.cb_chapterrange;                        
            parameters[18].Value = model.cb_countofeachchapter;                        
            parameters[19].Value = model.jd_count;                        
            parameters[20].Value = model.jd_scoreofeach;                        
            parameters[21].Value = model.jd_diff;                        
            parameters[22].Value = model.jd_chapterrange;                        
            parameters[23].Value = model.jd_countofeachchapter;                        
            parameters[24].Value = model.bf_count;                        
            parameters[25].Value = model.bf_scoreofeach;                        
            parameters[26].Value = model.bf_diff;                        
            parameters[27].Value = model.bf_chapterrange;                        
            parameters[28].Value = model.bf_countofeachchapter;                        
            parameters[29].Value = model.sa_count;                        
            parameters[30].Value = model.sa_scoreofeach;                        
            parameters[31].Value = model.sa_diff;                        
            parameters[32].Value = model.sa_chapterrange;                        
            parameters[33].Value = model.sa_countofeachchapter;                        
            parameters[34].Value = model.sr_list;                        
            parameters[35].Value = model.cb_list;                        
            parameters[36].Value = model.jd_list;                        
            parameters[37].Value = model.bf_list;                        
            parameters[38].Value = model.sa_list;                       Util.MyUtil.PrintSql(strSql.ToString());
            int rows=SQLHelper.ExecuteNonQuery(transaction,CommandType.Text, strSql.ToString(), parameters);	
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteTran(int id,SqlTransaction transaction)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbPaper ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			 Util.MyUtil.PrintSql(strSql.ToString());
			int rows=SQLHelper.ExecuteNonQuery(transaction,CommandType.Text, strSql.ToString(), parameters);	
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
				/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteListTran(string idlist ,SqlTransaction transaction)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbPaper ");
			strSql.Append(" where ID in ("+idlist + ")  ");
			 Util.MyUtil.PrintSql(strSql.ToString());
			int rows=SQLHelper.ExecuteNonQuery(transaction,CommandType.Text, strSql.ToString());	
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
				
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.tbPaper GetModelTran(int id ,SqlTransaction transaction)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, subjectid, userid, papertitle, diff, allscore, durationtime, createtime, papertype, sr_count, sr_scoreofeach, sr_diff, sr_chapterrange, sr_countofeachchatper, cb_count, cb_scoreofeach, cb_diff, cb_chapterrange, cb_countofeachchapter, jd_count, jd_scoreofeach, jd_diff, jd_chapterrange, jd_countofeachchapter, bf_count, bf_scoreofeach, bf_diff, bf_chapterrange, bf_countofeachchapter, sa_count, sa_scoreofeach, sa_diff, sa_chapterrange, sa_countofeachchapter, sr_list, cb_list, jd_list, bf_list, sa_list  ");			
			strSql.Append("  from tbPaper ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			 Util.MyUtil.PrintSql(strSql.ToString());
			Model.tbPaper model=new Model.tbPaper();
			DataSet ds=SQLHelper.ExecuteDataset(transaction,CommandType.Text, strSql.ToString(), parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["subjectid"].ToString()!="")
				{
					model.subjectid=int.Parse(ds.Tables[0].Rows[0]["subjectid"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["userid"].ToString()!="")
				{
					model.userid=int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
				}
																																				model.papertitle= ds.Tables[0].Rows[0]["papertitle"].ToString();
																												if(ds.Tables[0].Rows[0]["diff"].ToString()!="")
				{
					model.diff=decimal.Parse(ds.Tables[0].Rows[0]["diff"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["allscore"].ToString()!="")
				{
					model.allscore=int.Parse(ds.Tables[0].Rows[0]["allscore"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["durationtime"].ToString()!="")
				{
					model.durationtime=int.Parse(ds.Tables[0].Rows[0]["durationtime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(ds.Tables[0].Rows[0]["createtime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["papertype"].ToString()!="")
				{
					model.papertype=int.Parse(ds.Tables[0].Rows[0]["papertype"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["sr_count"].ToString()!="")
				{
					model.sr_count=int.Parse(ds.Tables[0].Rows[0]["sr_count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["sr_scoreofeach"].ToString()!="")
				{
					model.sr_scoreofeach=int.Parse(ds.Tables[0].Rows[0]["sr_scoreofeach"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["sr_diff"].ToString()!="")
				{
					model.sr_diff=int.Parse(ds.Tables[0].Rows[0]["sr_diff"].ToString());
				}
																																				model.sr_chapterrange= ds.Tables[0].Rows[0]["sr_chapterrange"].ToString();
																																model.sr_countofeachchatper= ds.Tables[0].Rows[0]["sr_countofeachchatper"].ToString();
																												if(ds.Tables[0].Rows[0]["cb_count"].ToString()!="")
				{
					model.cb_count=int.Parse(ds.Tables[0].Rows[0]["cb_count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["cb_scoreofeach"].ToString()!="")
				{
					model.cb_scoreofeach=int.Parse(ds.Tables[0].Rows[0]["cb_scoreofeach"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["cb_diff"].ToString()!="")
				{
					model.cb_diff=int.Parse(ds.Tables[0].Rows[0]["cb_diff"].ToString());
				}
																																				model.cb_chapterrange= ds.Tables[0].Rows[0]["cb_chapterrange"].ToString();
																																model.cb_countofeachchapter= ds.Tables[0].Rows[0]["cb_countofeachchapter"].ToString();
																												if(ds.Tables[0].Rows[0]["jd_count"].ToString()!="")
				{
					model.jd_count=int.Parse(ds.Tables[0].Rows[0]["jd_count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["jd_scoreofeach"].ToString()!="")
				{
					model.jd_scoreofeach=int.Parse(ds.Tables[0].Rows[0]["jd_scoreofeach"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["jd_diff"].ToString()!="")
				{
					model.jd_diff=int.Parse(ds.Tables[0].Rows[0]["jd_diff"].ToString());
				}
																																				model.jd_chapterrange= ds.Tables[0].Rows[0]["jd_chapterrange"].ToString();
																																model.jd_countofeachchapter= ds.Tables[0].Rows[0]["jd_countofeachchapter"].ToString();
																												if(ds.Tables[0].Rows[0]["bf_count"].ToString()!="")
				{
					model.bf_count=int.Parse(ds.Tables[0].Rows[0]["bf_count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["bf_scoreofeach"].ToString()!="")
				{
					model.bf_scoreofeach=int.Parse(ds.Tables[0].Rows[0]["bf_scoreofeach"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["bf_diff"].ToString()!="")
				{
					model.bf_diff=int.Parse(ds.Tables[0].Rows[0]["bf_diff"].ToString());
				}
																																				model.bf_chapterrange= ds.Tables[0].Rows[0]["bf_chapterrange"].ToString();
																																model.bf_countofeachchapter= ds.Tables[0].Rows[0]["bf_countofeachchapter"].ToString();
																												if(ds.Tables[0].Rows[0]["sa_count"].ToString()!="")
				{
					model.sa_count=int.Parse(ds.Tables[0].Rows[0]["sa_count"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["sa_scoreofeach"].ToString()!="")
				{
					model.sa_scoreofeach=int.Parse(ds.Tables[0].Rows[0]["sa_scoreofeach"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["sa_diff"].ToString()!="")
				{
					model.sa_diff=int.Parse(ds.Tables[0].Rows[0]["sa_diff"].ToString());
				}
																																				model.sa_chapterrange= ds.Tables[0].Rows[0]["sa_chapterrange"].ToString();
																																model.sa_countofeachchapter= ds.Tables[0].Rows[0]["sa_countofeachchapter"].ToString();
																																model.sr_list= ds.Tables[0].Rows[0]["sr_list"].ToString();
																																model.cb_list= ds.Tables[0].Rows[0]["cb_list"].ToString();
																																model.jd_list= ds.Tables[0].Rows[0]["jd_list"].ToString();
																																model.bf_list= ds.Tables[0].Rows[0]["bf_list"].ToString();
																																model.sa_list= ds.Tables[0].Rows[0]["sa_list"].ToString();
																										
				return model;
			}
			else
			{
				return null;
			}
		}
		#endregion 支持事务
	}
}

