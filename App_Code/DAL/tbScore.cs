using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace DAL  
{
	 	//tbScoreDAL
		public partial class tbScoreDAL
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbScore");
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
		public int Add(Model.tbScore model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbScore(");			
            strSql.Append("arrangeid,userid,hasshortanswer,hascorrect,score,scorestatus,createtime,starttime,endtime");
			strSql.Append(") values (");
            strSql.Append("@arrangeid,@userid,@hasshortanswer,@hascorrect,@score,@scorestatus,@createtime,@starttime,@endtime");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@arrangeid", SqlDbType.Int,4) ,            
                        new SqlParameter("@userid", SqlDbType.Int,4) ,            
                        new SqlParameter("@hasshortanswer", SqlDbType.Int,4) ,            
                        new SqlParameter("@hascorrect", SqlDbType.Int,4) ,            
                        new SqlParameter("@score", SqlDbType.Float,8) ,            
                        new SqlParameter("@scorestatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@starttime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@endtime", SqlDbType.SmallDateTime)             
              
            };
			            
            parameters[0].Value = model.arrangeid;                        
            parameters[1].Value = model.userid;                        
            parameters[2].Value = model.hasshortanswer;                        
            parameters[3].Value = model.hascorrect;                        
            parameters[4].Value = model.score;                        
            parameters[5].Value = model.scorestatus;                        
            parameters[6].Value = model.createtime;                        
            parameters[7].Value = model.starttime;                        
            parameters[8].Value = model.endtime;                        
			   
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
		public bool Update(Model.tbScore model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbScore set ");
			                                                
            strSql.Append(" arrangeid = @arrangeid , ");                                    
            strSql.Append(" userid = @userid , ");                                    
            strSql.Append(" hasshortanswer = @hasshortanswer , ");                                    
            strSql.Append(" hascorrect = @hascorrect , ");                                    
            strSql.Append(" score = @score , ");                                    
            strSql.Append(" scorestatus = @scorestatus , ");                                    
            strSql.Append(" createtime = @createtime , ");                                    
            strSql.Append(" starttime = @starttime , ");                                    
            strSql.Append(" endtime = @endtime  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@arrangeid", SqlDbType.Int,4) ,            
                        new SqlParameter("@userid", SqlDbType.Int,4) ,            
                        new SqlParameter("@hasshortanswer", SqlDbType.Int,4) ,            
                        new SqlParameter("@hascorrect", SqlDbType.Int,4) ,            
                        new SqlParameter("@score", SqlDbType.Float,8) ,            
                        new SqlParameter("@scorestatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@starttime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@endtime", SqlDbType.SmallDateTime)             
              
            };
            			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.arrangeid;                        
            parameters[2].Value = model.userid;                        
            parameters[3].Value = model.hasshortanswer;                        
            parameters[4].Value = model.hascorrect;                        
            parameters[5].Value = model.score;                        
            parameters[6].Value = model.scorestatus;                        
            parameters[7].Value = model.createtime;                        
            parameters[8].Value = model.starttime;                        
            parameters[9].Value = model.endtime;                       Util.MyUtil.PrintSql(strSql.ToString());
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
			strSql.Append("delete from tbScore ");
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
			strSql.Append("delete from tbScore ");
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
		public Model.tbScore GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, arrangeid, userid, hasshortanswer, hascorrect, score, scorestatus, createtime, starttime, endtime  ");			
			strSql.Append("  from tbScore ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			 Util.MyUtil.PrintSql(strSql.ToString());
			Model.tbScore model=new Model.tbScore();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["arrangeid"].ToString()!="")
				{
					model.arrangeid=int.Parse(ds.Tables[0].Rows[0]["arrangeid"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["userid"].ToString()!="")
				{
					model.userid=int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["hasshortanswer"].ToString()!="")
				{
					model.hasshortanswer=int.Parse(ds.Tables[0].Rows[0]["hasshortanswer"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["hascorrect"].ToString()!="")
				{
					model.hascorrect=int.Parse(ds.Tables[0].Rows[0]["hascorrect"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["score"].ToString()!="")
				{
					model.score=decimal.Parse(ds.Tables[0].Rows[0]["score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["scorestatus"].ToString()!="")
				{
					model.scorestatus=int.Parse(ds.Tables[0].Rows[0]["scorestatus"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(ds.Tables[0].Rows[0]["createtime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["starttime"].ToString()!="")
				{
					model.starttime=DateTime.Parse(ds.Tables[0].Rows[0]["starttime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["endtime"].ToString()!="")
				{
					model.endtime=DateTime.Parse(ds.Tables[0].Rows[0]["endtime"].ToString());
				}
																														
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
			strSql.Append(" FROM tbScore ");
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
			strSql.Append(" FROM tbScore ");
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
            coreSql.Append("select top " + (pageIndex - 1) * pageSize + " id from tbScore where 1=1 ");
            if (strWhere.Trim() != "")
            {
                coreSql.Append(" and " + strWhere);
            }
            if (filedOrder != "")
            {
                coreSql.Append("ORDER BY " + filedOrder + " ");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " * from tbScore where 1=1 ");
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
			String strSql="select count(*) from tbScore";
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
			String strSql="select count(*) from tbScore where "+strWhere;
			Util.MyUtil.PrintSql(strSql.ToString());
			return Convert.ToInt32(DbHelperSQL.GetSingle(strSql));
		}
        
        #region 支持事务
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddTran(Model.tbScore model,SqlTransaction transaction)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbScore(");			
            strSql.Append("arrangeid,userid,hasshortanswer,hascorrect,score,scorestatus,createtime,starttime,endtime");
			strSql.Append(") values (");
            strSql.Append("@arrangeid,@userid,@hasshortanswer,@hascorrect,@score,@scorestatus,@createtime,@starttime,@endtime");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@arrangeid", SqlDbType.Int,4) ,            
                        new SqlParameter("@userid", SqlDbType.Int,4) ,            
                        new SqlParameter("@hasshortanswer", SqlDbType.Int,4) ,            
                        new SqlParameter("@hascorrect", SqlDbType.Int,4) ,            
                        new SqlParameter("@score", SqlDbType.Float,8) ,            
                        new SqlParameter("@scorestatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@starttime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@endtime", SqlDbType.SmallDateTime)             
              
            };
            			            
            parameters[0].Value = model.arrangeid;                        
            parameters[1].Value = model.userid;                        
            parameters[2].Value = model.hasshortanswer;                        
            parameters[3].Value = model.hascorrect;                        
            parameters[4].Value = model.score;                        
            parameters[5].Value = model.scorestatus;                        
            parameters[6].Value = model.createtime;                        
            parameters[7].Value = model.starttime;                        
            parameters[8].Value = model.endtime;                        
			   
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
		public bool UpdateTran(Model.tbScore model,SqlTransaction transaction)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbScore set ");
			                                                
            strSql.Append(" arrangeid = @arrangeid , ");                                    
            strSql.Append(" userid = @userid , ");                                    
            strSql.Append(" hasshortanswer = @hasshortanswer , ");                                    
            strSql.Append(" hascorrect = @hascorrect , ");                                    
            strSql.Append(" score = @score , ");                                    
            strSql.Append(" scorestatus = @scorestatus , ");                                    
            strSql.Append(" createtime = @createtime , ");                                    
            strSql.Append(" starttime = @starttime , ");                                    
            strSql.Append(" endtime = @endtime  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@arrangeid", SqlDbType.Int,4) ,            
                        new SqlParameter("@userid", SqlDbType.Int,4) ,            
                        new SqlParameter("@hasshortanswer", SqlDbType.Int,4) ,            
                        new SqlParameter("@hascorrect", SqlDbType.Int,4) ,            
                        new SqlParameter("@score", SqlDbType.Float,8) ,            
                        new SqlParameter("@scorestatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@createtime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@starttime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@endtime", SqlDbType.SmallDateTime)             
              
            };
            			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.arrangeid;                        
            parameters[2].Value = model.userid;                        
            parameters[3].Value = model.hasshortanswer;                        
            parameters[4].Value = model.hascorrect;                        
            parameters[5].Value = model.score;                        
            parameters[6].Value = model.scorestatus;                        
            parameters[7].Value = model.createtime;                        
            parameters[8].Value = model.starttime;                        
            parameters[9].Value = model.endtime;                       Util.MyUtil.PrintSql(strSql.ToString());
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
			strSql.Append("delete from tbScore ");
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
			strSql.Append("delete from tbScore ");
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
		public Model.tbScore GetModelTran(int id ,SqlTransaction transaction)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, arrangeid, userid, hasshortanswer, hascorrect, score, scorestatus, createtime, starttime, endtime  ");			
			strSql.Append("  from tbScore ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			 Util.MyUtil.PrintSql(strSql.ToString());
			Model.tbScore model=new Model.tbScore();
			DataSet ds=SQLHelper.ExecuteDataset(transaction,CommandType.Text, strSql.ToString(), parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["arrangeid"].ToString()!="")
				{
					model.arrangeid=int.Parse(ds.Tables[0].Rows[0]["arrangeid"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["userid"].ToString()!="")
				{
					model.userid=int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["hasshortanswer"].ToString()!="")
				{
					model.hasshortanswer=int.Parse(ds.Tables[0].Rows[0]["hasshortanswer"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["hascorrect"].ToString()!="")
				{
					model.hascorrect=int.Parse(ds.Tables[0].Rows[0]["hascorrect"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["score"].ToString()!="")
				{
					model.score=decimal.Parse(ds.Tables[0].Rows[0]["score"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["scorestatus"].ToString()!="")
				{
					model.scorestatus=int.Parse(ds.Tables[0].Rows[0]["scorestatus"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(ds.Tables[0].Rows[0]["createtime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["starttime"].ToString()!="")
				{
					model.starttime=DateTime.Parse(ds.Tables[0].Rows[0]["starttime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["endtime"].ToString()!="")
				{
					model.endtime=DateTime.Parse(ds.Tables[0].Rows[0]["endtime"].ToString());
				}
																														
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

