﻿using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Model;
namespace BLL {
	 	//tbAnswerOfPaper
		public partial class tbAnswerOfPaperBLL
	{
   		     
		private readonly DAL.tbAnswerOfPaperDAL dal=new DAL.tbAnswerOfPaperDAL();
		public tbAnswerOfPaperBLL()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.tbAnswerOfPaper model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.tbAnswerOfPaper model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
				/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.tbAnswerOfPaper GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.tbAnswerOfPaper GetModelByCache(int id)
		{
			
			string CacheKey = "tbAnswerOfPaperModel-" + id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Model.tbAnswerOfPaper)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.tbAnswerOfPaper> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.tbAnswerOfPaper> DataTableToList(DataTable dt)
		{
			List<Model.tbAnswerOfPaper> modelList = new List<Model.tbAnswerOfPaper>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.tbAnswerOfPaper model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Model.tbAnswerOfPaper();					
													if(dt.Rows[n]["id"].ToString()!="")
				{
					model.id=int.Parse(dt.Rows[n]["id"].ToString());
				}
																																if(dt.Rows[n]["arrangeid"].ToString()!="")
				{
					model.arrangeid=int.Parse(dt.Rows[n]["arrangeid"].ToString());
				}
																																if(dt.Rows[n]["answerid"].ToString()!="")
				{
					model.answerid=int.Parse(dt.Rows[n]["answerid"].ToString());
				}
																																if(dt.Rows[n]["userid"].ToString()!="")
				{
					model.userid=int.Parse(dt.Rows[n]["userid"].ToString());
				}
																																				model.useranswer= dt.Rows[n]["useranswer"].ToString();
																												if(dt.Rows[n]["getscore"].ToString()!="")
				{
					model.getscore=decimal.Parse(dt.Rows[n]["getscore"].ToString());
				}
																																if(dt.Rows[n]["allscore"].ToString()!="")
				{
					model.allscore=decimal.Parse(dt.Rows[n]["allscore"].ToString());
				}
																										
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
		
		/// <summary>
        /// 获得单表的分页查询结果
        /// </summary>
        /// <param name="pageSize">每页显示的记录</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序字段，降序</param>
        /// <returns></returns>
		public DataSet GetListByIndex(int pageSize,int pageIndex,string strWhere,string filedOrder)
		{
			return dal.GetListByIndex(pageSize,pageIndex,strWhere,filedOrder);
		}
		
		/// <summary>
        /// 获取该表的总记录数
        /// </summary>
        /// <returns></returns>
		public int GetCount()
		{
			return dal.GetCount();
		}
		
		/// <summary>
        /// 获得某条件所返回的记录数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
		public int GetCount(String strWhere)
		{
			return dal.GetCount(strWhere);
		}
#endregion
   
	}
}