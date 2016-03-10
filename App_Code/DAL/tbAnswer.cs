using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace DAL  
{
	 	//tbAnswerDAL
		public partial class tbAnswerDAL
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbAnswer");
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
		public int Add(Model.tbAnswer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbAnswer(");			
            strSql.Append("chapterid,ques,ans,diff,selectcount,rightcount,questype");
			strSql.Append(") values (");
            strSql.Append("@chapterid,@ques,@ans,@diff,@selectcount,@rightcount,@questype");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@chapterid", SqlDbType.Int,4) ,            
                        new SqlParameter("@ques", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@ans", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@selectcount", SqlDbType.Int,4) ,            
                        new SqlParameter("@rightcount", SqlDbType.Int,4) ,            
                        new SqlParameter("@questype", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.chapterid;                        
            parameters[1].Value = model.ques;                        
            parameters[2].Value = model.ans;                        
            parameters[3].Value = model.diff;                        
            parameters[4].Value = model.selectcount;                        
            parameters[5].Value = model.rightcount;                        
            parameters[6].Value = model.questype;                        
			   
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
		public bool Update(Model.tbAnswer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbAnswer set ");
			                                                
            strSql.Append(" chapterid = @chapterid , ");                                    
            strSql.Append(" ques = @ques , ");                                    
            strSql.Append(" ans = @ans , ");                                    
            strSql.Append(" diff = @diff , ");                                    
            strSql.Append(" selectcount = @selectcount , ");                                    
            strSql.Append(" rightcount = @rightcount , ");                                    
            strSql.Append(" questype = @questype  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@chapterid", SqlDbType.Int,4) ,            
                        new SqlParameter("@ques", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@ans", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@selectcount", SqlDbType.Int,4) ,            
                        new SqlParameter("@rightcount", SqlDbType.Int,4) ,            
                        new SqlParameter("@questype", SqlDbType.Int,4)             
              
            };
            			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.chapterid;                        
            parameters[2].Value = model.ques;                        
            parameters[3].Value = model.ans;                        
            parameters[4].Value = model.diff;                        
            parameters[5].Value = model.selectcount;                        
            parameters[6].Value = model.rightcount;                        
            parameters[7].Value = model.questype;                       Util.MyUtil.PrintSql(strSql.ToString());
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
			strSql.Append("delete from tbAnswer ");
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
			strSql.Append("delete from tbAnswer ");
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
		public Model.tbAnswer GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, chapterid, ques, ans, diff, selectcount, rightcount, questype  ");			
			strSql.Append("  from tbAnswer ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			 Util.MyUtil.PrintSql(strSql.ToString());
			Model.tbAnswer model=new Model.tbAnswer();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["chapterid"].ToString()!="")
				{
					model.chapterid=int.Parse(ds.Tables[0].Rows[0]["chapterid"].ToString());
				}
																																				model.ques= ds.Tables[0].Rows[0]["ques"].ToString();
																																model.ans= ds.Tables[0].Rows[0]["ans"].ToString();
																												if(ds.Tables[0].Rows[0]["diff"].ToString()!="")
				{
					model.diff=int.Parse(ds.Tables[0].Rows[0]["diff"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["selectcount"].ToString()!="")
				{
					model.selectcount=int.Parse(ds.Tables[0].Rows[0]["selectcount"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["rightcount"].ToString()!="")
				{
					model.rightcount=int.Parse(ds.Tables[0].Rows[0]["rightcount"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["questype"].ToString()!="")
				{
					model.questype=int.Parse(ds.Tables[0].Rows[0]["questype"].ToString());
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
			strSql.Append(" FROM tbAnswer ");
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
			strSql.Append(" FROM tbAnswer ");
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
            coreSql.Append("select top " + (pageIndex - 1) * pageSize + " id from tbAnswer where 1=1 ");
            if (strWhere.Trim() != "")
            {
                coreSql.Append(" and " + strWhere);
            }
            if (filedOrder != "")
            {
                coreSql.Append("ORDER BY " + filedOrder + " ");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " * from tbAnswer where 1=1 ");
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
			String strSql="select count(*) from tbAnswer";
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
			String strSql="select count(*) from tbAnswer where "+strWhere;
			Util.MyUtil.PrintSql(strSql.ToString());
			return Convert.ToInt32(DbHelperSQL.GetSingle(strSql));
		}
        
        #region 支持事务
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddTran(Model.tbAnswer model,SqlTransaction transaction)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbAnswer(");			
            strSql.Append("chapterid,ques,ans,diff,selectcount,rightcount,questype");
			strSql.Append(") values (");
            strSql.Append("@chapterid,@ques,@ans,@diff,@selectcount,@rightcount,@questype");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@chapterid", SqlDbType.Int,4) ,            
                        new SqlParameter("@ques", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@ans", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@selectcount", SqlDbType.Int,4) ,            
                        new SqlParameter("@rightcount", SqlDbType.Int,4) ,            
                        new SqlParameter("@questype", SqlDbType.Int,4)             
              
            };
            			            
            parameters[0].Value = model.chapterid;                        
            parameters[1].Value = model.ques;                        
            parameters[2].Value = model.ans;                        
            parameters[3].Value = model.diff;                        
            parameters[4].Value = model.selectcount;                        
            parameters[5].Value = model.rightcount;                        
            parameters[6].Value = model.questype;                        
			   
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
		public bool UpdateTran(Model.tbAnswer model,SqlTransaction transaction)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbAnswer set ");
			                                                
            strSql.Append(" chapterid = @chapterid , ");                                    
            strSql.Append(" ques = @ques , ");                                    
            strSql.Append(" ans = @ans , ");                                    
            strSql.Append(" diff = @diff , ");                                    
            strSql.Append(" selectcount = @selectcount , ");                                    
            strSql.Append(" rightcount = @rightcount , ");                                    
            strSql.Append(" questype = @questype  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@chapterid", SqlDbType.Int,4) ,            
                        new SqlParameter("@ques", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@ans", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@diff", SqlDbType.Int,4) ,            
                        new SqlParameter("@selectcount", SqlDbType.Int,4) ,            
                        new SqlParameter("@rightcount", SqlDbType.Int,4) ,            
                        new SqlParameter("@questype", SqlDbType.Int,4)             
              
            };
            			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.chapterid;                        
            parameters[2].Value = model.ques;                        
            parameters[3].Value = model.ans;                        
            parameters[4].Value = model.diff;                        
            parameters[5].Value = model.selectcount;                        
            parameters[6].Value = model.rightcount;                        
            parameters[7].Value = model.questype;                       Util.MyUtil.PrintSql(strSql.ToString());
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
			strSql.Append("delete from tbAnswer ");
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
			strSql.Append("delete from tbAnswer ");
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
		public Model.tbAnswer GetModelTran(int id ,SqlTransaction transaction)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, chapterid, ques, ans, diff, selectcount, rightcount, questype  ");			
			strSql.Append("  from tbAnswer ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			 Util.MyUtil.PrintSql(strSql.ToString());
			Model.tbAnswer model=new Model.tbAnswer();
			DataSet ds=SQLHelper.ExecuteDataset(transaction,CommandType.Text, strSql.ToString(), parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["chapterid"].ToString()!="")
				{
					model.chapterid=int.Parse(ds.Tables[0].Rows[0]["chapterid"].ToString());
				}
																																				model.ques= ds.Tables[0].Rows[0]["ques"].ToString();
																																model.ans= ds.Tables[0].Rows[0]["ans"].ToString();
																												if(ds.Tables[0].Rows[0]["diff"].ToString()!="")
				{
					model.diff=int.Parse(ds.Tables[0].Rows[0]["diff"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["selectcount"].ToString()!="")
				{
					model.selectcount=int.Parse(ds.Tables[0].Rows[0]["selectcount"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["rightcount"].ToString()!="")
				{
					model.rightcount=int.Parse(ds.Tables[0].Rows[0]["rightcount"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["questype"].ToString()!="")
				{
					model.questype=int.Parse(ds.Tables[0].Rows[0]["questype"].ToString());
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

