using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace DAL  
{
	 	//tbChapterDAL
		public partial class tbChapterDAL
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbChapter");
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
		public int Add(Model.tbChapter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbChapter(");			
            strSql.Append("subjectid,chapterno,chaptername");
			strSql.Append(") values (");
            strSql.Append("@subjectid,@chapterno,@chaptername");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@subjectid", SqlDbType.Int,4) ,            
                        new SqlParameter("@chapterno", SqlDbType.Int,4) ,            
                        new SqlParameter("@chaptername", SqlDbType.NVarChar,50)             
              
            };
			            
            parameters[0].Value = model.subjectid;                        
            parameters[1].Value = model.chapterno;                        
            parameters[2].Value = model.chaptername;                        
			   
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
		public bool Update(Model.tbChapter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbChapter set ");
			                                                
            strSql.Append(" subjectid = @subjectid , ");                                    
            strSql.Append(" chapterno = @chapterno , ");                                    
            strSql.Append(" chaptername = @chaptername  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@subjectid", SqlDbType.Int,4) ,            
                        new SqlParameter("@chapterno", SqlDbType.Int,4) ,            
                        new SqlParameter("@chaptername", SqlDbType.NVarChar,50)             
              
            };
            			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.subjectid;                        
            parameters[2].Value = model.chapterno;                        
            parameters[3].Value = model.chaptername;                       Util.MyUtil.PrintSql(strSql.ToString());
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
			strSql.Append("delete from tbChapter ");
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
			strSql.Append("delete from tbChapter ");
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
		public Model.tbChapter GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, subjectid, chapterno, chaptername  ");			
			strSql.Append("  from tbChapter ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			 Util.MyUtil.PrintSql(strSql.ToString());
			Model.tbChapter model=new Model.tbChapter();
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
																																if(ds.Tables[0].Rows[0]["chapterno"].ToString()!="")
				{
					model.chapterno=int.Parse(ds.Tables[0].Rows[0]["chapterno"].ToString());
				}
																																				model.chaptername= ds.Tables[0].Rows[0]["chaptername"].ToString();
																										
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
			strSql.Append(" FROM tbChapter ");
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
			strSql.Append(" FROM tbChapter ");
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
            coreSql.Append("select top " + (pageIndex - 1) * pageSize + " id from tbChapter where 1=1 ");
            if (strWhere.Trim() != "")
            {
                coreSql.Append(" and " + strWhere);
            }
            if (filedOrder != "")
            {
                coreSql.Append("ORDER BY " + filedOrder + " ");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " * from tbChapter where 1=1 ");
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
			String strSql="select count(*) from tbChapter";
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
			String strSql="select count(*) from tbChapter where "+strWhere;
			Util.MyUtil.PrintSql(strSql.ToString());
			return Convert.ToInt32(DbHelperSQL.GetSingle(strSql));
		}
        
        #region 支持事务
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddTran(Model.tbChapter model,SqlTransaction transaction)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbChapter(");			
            strSql.Append("subjectid,chapterno,chaptername");
			strSql.Append(") values (");
            strSql.Append("@subjectid,@chapterno,@chaptername");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@subjectid", SqlDbType.Int,4) ,            
                        new SqlParameter("@chapterno", SqlDbType.Int,4) ,            
                        new SqlParameter("@chaptername", SqlDbType.NVarChar,50)             
              
            };
            			            
            parameters[0].Value = model.subjectid;                        
            parameters[1].Value = model.chapterno;                        
            parameters[2].Value = model.chaptername;                        
			   
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
		public bool UpdateTran(Model.tbChapter model,SqlTransaction transaction)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbChapter set ");
			                                                
            strSql.Append(" subjectid = @subjectid , ");                                    
            strSql.Append(" chapterno = @chapterno , ");                                    
            strSql.Append(" chaptername = @chaptername  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@subjectid", SqlDbType.Int,4) ,            
                        new SqlParameter("@chapterno", SqlDbType.Int,4) ,            
                        new SqlParameter("@chaptername", SqlDbType.NVarChar,50)             
              
            };
            			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.subjectid;                        
            parameters[2].Value = model.chapterno;                        
            parameters[3].Value = model.chaptername;                       Util.MyUtil.PrintSql(strSql.ToString());
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
			strSql.Append("delete from tbChapter ");
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
			strSql.Append("delete from tbChapter ");
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
		public Model.tbChapter GetModelTran(int id ,SqlTransaction transaction)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, subjectid, chapterno, chaptername  ");			
			strSql.Append("  from tbChapter ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			 Util.MyUtil.PrintSql(strSql.ToString());
			Model.tbChapter model=new Model.tbChapter();
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
																																if(ds.Tables[0].Rows[0]["chapterno"].ToString()!="")
				{
					model.chapterno=int.Parse(ds.Tables[0].Rows[0]["chapterno"].ToString());
				}
																																				model.chaptername= ds.Tables[0].Rows[0]["chaptername"].ToString();
																										
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

