using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace DAL  
{
	 	//tbUserDAL
		public partial class tbUserDAL
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbUser");
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
		public int Add(Model.tbUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbUser(");			
            strSql.Append("loginname,realname,userpwd,classid,usertype");
			strSql.Append(") values (");
            strSql.Append("@loginname,@realname,@userpwd,@classid,@usertype");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@loginname", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@realname", SqlDbType.NVarChar,10) ,            
                        new SqlParameter("@userpwd", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@classid", SqlDbType.Int,4) ,            
                        new SqlParameter("@usertype", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.loginname;                        
            parameters[1].Value = model.realname;                        
            parameters[2].Value = model.userpwd;                        
            parameters[3].Value = model.classid;                        
            parameters[4].Value = model.usertype;                        
			   
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
		public bool Update(Model.tbUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbUser set ");
			                                                
            strSql.Append(" loginname = @loginname , ");                                    
            strSql.Append(" realname = @realname , ");                                    
            strSql.Append(" userpwd = @userpwd , ");                                    
            strSql.Append(" classid = @classid , ");                                    
            strSql.Append(" usertype = @usertype  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@loginname", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@realname", SqlDbType.NVarChar,10) ,            
                        new SqlParameter("@userpwd", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@classid", SqlDbType.Int,4) ,            
                        new SqlParameter("@usertype", SqlDbType.Int,4)             
              
            };
            			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.loginname;                        
            parameters[2].Value = model.realname;                        
            parameters[3].Value = model.userpwd;                        
            parameters[4].Value = model.classid;                        
            parameters[5].Value = model.usertype;                       Util.MyUtil.PrintSql(strSql.ToString());
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
			strSql.Append("delete from tbUser ");
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
			strSql.Append("delete from tbUser ");
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
		public Model.tbUser GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, loginname, realname, userpwd, classid, usertype  ");			
			strSql.Append("  from tbUser ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			 Util.MyUtil.PrintSql(strSql.ToString());
			Model.tbUser model=new Model.tbUser();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.loginname= ds.Tables[0].Rows[0]["loginname"].ToString();
																																model.realname= ds.Tables[0].Rows[0]["realname"].ToString();
																																model.userpwd= ds.Tables[0].Rows[0]["userpwd"].ToString();
																												if(ds.Tables[0].Rows[0]["classid"].ToString()!="")
				{
					model.classid=int.Parse(ds.Tables[0].Rows[0]["classid"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["usertype"].ToString()!="")
				{
					model.usertype=int.Parse(ds.Tables[0].Rows[0]["usertype"].ToString());
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
			strSql.Append(" FROM tbUser ");
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
			strSql.Append(" FROM tbUser ");
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
            coreSql.Append("select top " + (pageIndex - 1) * pageSize + " id from tbUser where 1=1 ");
            if (strWhere.Trim() != "")
            {
                coreSql.Append(" and " + strWhere);
            }
            if (filedOrder != "")
            {
                coreSql.Append("ORDER BY " + filedOrder + " ");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " * from tbUser where 1=1 ");
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
			String strSql="select count(*) from tbUser";
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
			String strSql="select count(*) from tbUser where "+strWhere;
			Util.MyUtil.PrintSql(strSql.ToString());
			return Convert.ToInt32(DbHelperSQL.GetSingle(strSql));
		}
        
        #region 支持事务
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddTran(Model.tbUser model,SqlTransaction transaction)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbUser(");			
            strSql.Append("loginname,realname,userpwd,classid,usertype");
			strSql.Append(") values (");
            strSql.Append("@loginname,@realname,@userpwd,@classid,@usertype");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@loginname", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@realname", SqlDbType.NVarChar,10) ,            
                        new SqlParameter("@userpwd", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@classid", SqlDbType.Int,4) ,            
                        new SqlParameter("@usertype", SqlDbType.Int,4)             
              
            };
            			            
            parameters[0].Value = model.loginname;                        
            parameters[1].Value = model.realname;                        
            parameters[2].Value = model.userpwd;                        
            parameters[3].Value = model.classid;                        
            parameters[4].Value = model.usertype;                        
			   
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
		public bool UpdateTran(Model.tbUser model,SqlTransaction transaction)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbUser set ");
			                                                
            strSql.Append(" loginname = @loginname , ");                                    
            strSql.Append(" realname = @realname , ");                                    
            strSql.Append(" userpwd = @userpwd , ");                                    
            strSql.Append(" classid = @classid , ");                                    
            strSql.Append(" usertype = @usertype  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@loginname", SqlDbType.NVarChar,20) ,            
                        new SqlParameter("@realname", SqlDbType.NVarChar,10) ,            
                        new SqlParameter("@userpwd", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@classid", SqlDbType.Int,4) ,            
                        new SqlParameter("@usertype", SqlDbType.Int,4)             
              
            };
            			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.loginname;                        
            parameters[2].Value = model.realname;                        
            parameters[3].Value = model.userpwd;                        
            parameters[4].Value = model.classid;                        
            parameters[5].Value = model.usertype;                       Util.MyUtil.PrintSql(strSql.ToString());
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
			strSql.Append("delete from tbUser ");
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
			strSql.Append("delete from tbUser ");
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
		public Model.tbUser GetModelTran(int id ,SqlTransaction transaction)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, loginname, realname, userpwd, classid, usertype  ");			
			strSql.Append("  from tbUser ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			 Util.MyUtil.PrintSql(strSql.ToString());
			Model.tbUser model=new Model.tbUser();
			DataSet ds=SQLHelper.ExecuteDataset(transaction,CommandType.Text, strSql.ToString(), parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.loginname= ds.Tables[0].Rows[0]["loginname"].ToString();
																																model.realname= ds.Tables[0].Rows[0]["realname"].ToString();
																																model.userpwd= ds.Tables[0].Rows[0]["userpwd"].ToString();
																												if(ds.Tables[0].Rows[0]["classid"].ToString()!="")
				{
					model.classid=int.Parse(ds.Tables[0].Rows[0]["classid"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["usertype"].ToString()!="")
				{
					model.usertype=int.Parse(ds.Tables[0].Rows[0]["usertype"].ToString());
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

