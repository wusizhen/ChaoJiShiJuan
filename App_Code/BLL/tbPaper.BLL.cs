using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Model;
namespace BLL {
	 	//tbPaper
		public partial class tbPaperBLL
	{
   		     
		private readonly DAL.tbPaperDAL dal=new DAL.tbPaperDAL();
		public tbPaperBLL()
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
		public int  Add(Model.tbPaper model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.tbPaper model)
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
		public Model.tbPaper GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.tbPaper GetModelByCache(int id)
		{
			
			string CacheKey = "tbPaperModel-" + id;
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
			return (Model.tbPaper)objModel;
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
		public List<Model.tbPaper> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.tbPaper> DataTableToList(DataTable dt)
		{
			List<Model.tbPaper> modelList = new List<Model.tbPaper>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.tbPaper model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Model.tbPaper();					
													if(dt.Rows[n]["id"].ToString()!="")
				{
					model.id=int.Parse(dt.Rows[n]["id"].ToString());
				}
																																if(dt.Rows[n]["subjectid"].ToString()!="")
				{
					model.subjectid=int.Parse(dt.Rows[n]["subjectid"].ToString());
				}
																																if(dt.Rows[n]["userid"].ToString()!="")
				{
					model.userid=int.Parse(dt.Rows[n]["userid"].ToString());
				}
																																				model.papertitle= dt.Rows[n]["papertitle"].ToString();
																												if(dt.Rows[n]["diff"].ToString()!="")
				{
					model.diff=decimal.Parse(dt.Rows[n]["diff"].ToString());
				}
																																if(dt.Rows[n]["allscore"].ToString()!="")
				{
					model.allscore=int.Parse(dt.Rows[n]["allscore"].ToString());
				}
																																if(dt.Rows[n]["durationtime"].ToString()!="")
				{
					model.durationtime=int.Parse(dt.Rows[n]["durationtime"].ToString());
				}
																																if(dt.Rows[n]["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(dt.Rows[n]["createtime"].ToString());
				}
																																if(dt.Rows[n]["papertype"].ToString()!="")
				{
					model.papertype=int.Parse(dt.Rows[n]["papertype"].ToString());
				}
																																if(dt.Rows[n]["sr_count"].ToString()!="")
				{
					model.sr_count=int.Parse(dt.Rows[n]["sr_count"].ToString());
				}
																																if(dt.Rows[n]["sr_scoreofeach"].ToString()!="")
				{
					model.sr_scoreofeach=int.Parse(dt.Rows[n]["sr_scoreofeach"].ToString());
				}
																																if(dt.Rows[n]["sr_diff"].ToString()!="")
				{
					model.sr_diff=int.Parse(dt.Rows[n]["sr_diff"].ToString());
				}
																																				model.sr_chapterrange= dt.Rows[n]["sr_chapterrange"].ToString();
																																model.sr_countofeachchatper= dt.Rows[n]["sr_countofeachchatper"].ToString();
																												if(dt.Rows[n]["cb_count"].ToString()!="")
				{
					model.cb_count=int.Parse(dt.Rows[n]["cb_count"].ToString());
				}
																																if(dt.Rows[n]["cb_scoreofeach"].ToString()!="")
				{
					model.cb_scoreofeach=int.Parse(dt.Rows[n]["cb_scoreofeach"].ToString());
				}
																																if(dt.Rows[n]["cb_diff"].ToString()!="")
				{
					model.cb_diff=int.Parse(dt.Rows[n]["cb_diff"].ToString());
				}
																																				model.cb_chapterrange= dt.Rows[n]["cb_chapterrange"].ToString();
																																model.cb_countofeachchapter= dt.Rows[n]["cb_countofeachchapter"].ToString();
																												if(dt.Rows[n]["jd_count"].ToString()!="")
				{
					model.jd_count=int.Parse(dt.Rows[n]["jd_count"].ToString());
				}
																																if(dt.Rows[n]["jd_scoreofeach"].ToString()!="")
				{
					model.jd_scoreofeach=int.Parse(dt.Rows[n]["jd_scoreofeach"].ToString());
				}
																																if(dt.Rows[n]["jd_diff"].ToString()!="")
				{
					model.jd_diff=int.Parse(dt.Rows[n]["jd_diff"].ToString());
				}
																																				model.jd_chapterrange= dt.Rows[n]["jd_chapterrange"].ToString();
																																model.jd_countofeachchapter= dt.Rows[n]["jd_countofeachchapter"].ToString();
																												if(dt.Rows[n]["bf_count"].ToString()!="")
				{
					model.bf_count=int.Parse(dt.Rows[n]["bf_count"].ToString());
				}
																																if(dt.Rows[n]["bf_scoreofeach"].ToString()!="")
				{
					model.bf_scoreofeach=int.Parse(dt.Rows[n]["bf_scoreofeach"].ToString());
				}
																																if(dt.Rows[n]["bf_diff"].ToString()!="")
				{
					model.bf_diff=int.Parse(dt.Rows[n]["bf_diff"].ToString());
				}
																																				model.bf_chapterrange= dt.Rows[n]["bf_chapterrange"].ToString();
																																model.bf_countofeachchapter= dt.Rows[n]["bf_countofeachchapter"].ToString();
																												if(dt.Rows[n]["sa_count"].ToString()!="")
				{
					model.sa_count=int.Parse(dt.Rows[n]["sa_count"].ToString());
				}
																																if(dt.Rows[n]["sa_scoreofeach"].ToString()!="")
				{
					model.sa_scoreofeach=int.Parse(dt.Rows[n]["sa_scoreofeach"].ToString());
				}
																																if(dt.Rows[n]["sa_diff"].ToString()!="")
				{
					model.sa_diff=int.Parse(dt.Rows[n]["sa_diff"].ToString());
				}
																																				model.sa_chapterrange= dt.Rows[n]["sa_chapterrange"].ToString();
																																model.sa_countofeachchapter= dt.Rows[n]["sa_countofeachchapter"].ToString();
																																model.sr_list= dt.Rows[n]["sr_list"].ToString();
																																model.cb_list= dt.Rows[n]["cb_list"].ToString();
																																model.jd_list= dt.Rows[n]["jd_list"].ToString();
																																model.bf_list= dt.Rows[n]["bf_list"].ToString();
																																model.sa_list= dt.Rows[n]["sa_list"].ToString();
																						
				
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