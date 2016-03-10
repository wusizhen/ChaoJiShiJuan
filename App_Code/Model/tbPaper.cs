using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//tbPaper
		public class tbPaper
	{
   		     
      	/// <summary>
		/// id
        /// </summary>		
		private int _id;
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// subjectid
        /// </summary>		
		private int _subjectid;
        public int subjectid
        {
            get{ return _subjectid; }
            set{ _subjectid = value; }
        }        
		/// <summary>
		/// userid
        /// </summary>		
		private int _userid;
        public int userid
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
		/// <summary>
		/// papertitle
        /// </summary>		
		private string _papertitle;
        public string papertitle
        {
            get{ return _papertitle; }
            set{ _papertitle = value; }
        }        
		/// <summary>
		/// diff
        /// </summary>		
		private decimal _diff;
        public decimal diff
        {
            get{ return _diff; }
            set{ _diff = value; }
        }        
		/// <summary>
		/// allscore
        /// </summary>		
		private int _allscore;
        public int allscore
        {
            get{ return _allscore; }
            set{ _allscore = value; }
        }        
		/// <summary>
		/// durationtime
        /// </summary>		
		private int _durationtime;
        public int durationtime
        {
            get{ return _durationtime; }
            set{ _durationtime = value; }
        }        
		/// <summary>
		/// createtime
        /// </summary>		
		private DateTime _createtime;
        public DateTime createtime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }        
		/// <summary>
		/// papertype
        /// </summary>		
		private int _papertype;
        public int papertype
        {
            get{ return _papertype; }
            set{ _papertype = value; }
        }        
		/// <summary>
		/// sr_count
        /// </summary>		
		private int _sr_count;
        public int sr_count
        {
            get{ return _sr_count; }
            set{ _sr_count = value; }
        }        
		/// <summary>
		/// sr_scoreofeach
        /// </summary>		
		private int _sr_scoreofeach;
        public int sr_scoreofeach
        {
            get{ return _sr_scoreofeach; }
            set{ _sr_scoreofeach = value; }
        }        
		/// <summary>
		/// sr_diff
        /// </summary>		
		private int _sr_diff;
        public int sr_diff
        {
            get{ return _sr_diff; }
            set{ _sr_diff = value; }
        }        
		/// <summary>
		/// sr_chapterrange
        /// </summary>		
		private string _sr_chapterrange;
        public string sr_chapterrange
        {
            get{ return _sr_chapterrange; }
            set{ _sr_chapterrange = value; }
        }        
		/// <summary>
		/// sr_countofeachchatper
        /// </summary>		
		private string _sr_countofeachchatper;
        public string sr_countofeachchatper
        {
            get{ return _sr_countofeachchatper; }
            set{ _sr_countofeachchatper = value; }
        }        
		/// <summary>
		/// cb_count
        /// </summary>		
		private int _cb_count;
        public int cb_count
        {
            get{ return _cb_count; }
            set{ _cb_count = value; }
        }        
		/// <summary>
		/// cb_scoreofeach
        /// </summary>		
		private int _cb_scoreofeach;
        public int cb_scoreofeach
        {
            get{ return _cb_scoreofeach; }
            set{ _cb_scoreofeach = value; }
        }        
		/// <summary>
		/// cb_diff
        /// </summary>		
		private int _cb_diff;
        public int cb_diff
        {
            get{ return _cb_diff; }
            set{ _cb_diff = value; }
        }        
		/// <summary>
		/// cb_chapterrange
        /// </summary>		
		private string _cb_chapterrange;
        public string cb_chapterrange
        {
            get{ return _cb_chapterrange; }
            set{ _cb_chapterrange = value; }
        }        
		/// <summary>
		/// cb_countofeachchapter
        /// </summary>		
		private string _cb_countofeachchapter;
        public string cb_countofeachchapter
        {
            get{ return _cb_countofeachchapter; }
            set{ _cb_countofeachchapter = value; }
        }        
		/// <summary>
		/// jd_count
        /// </summary>		
		private int _jd_count;
        public int jd_count
        {
            get{ return _jd_count; }
            set{ _jd_count = value; }
        }        
		/// <summary>
		/// jd_scoreofeach
        /// </summary>		
		private int _jd_scoreofeach;
        public int jd_scoreofeach
        {
            get{ return _jd_scoreofeach; }
            set{ _jd_scoreofeach = value; }
        }        
		/// <summary>
		/// jd_diff
        /// </summary>		
		private int _jd_diff;
        public int jd_diff
        {
            get{ return _jd_diff; }
            set{ _jd_diff = value; }
        }        
		/// <summary>
		/// jd_chapterrange
        /// </summary>		
		private string _jd_chapterrange;
        public string jd_chapterrange
        {
            get{ return _jd_chapterrange; }
            set{ _jd_chapterrange = value; }
        }        
		/// <summary>
		/// jd_countofeachchapter
        /// </summary>		
		private string _jd_countofeachchapter;
        public string jd_countofeachchapter
        {
            get{ return _jd_countofeachchapter; }
            set{ _jd_countofeachchapter = value; }
        }        
		/// <summary>
		/// bf_count
        /// </summary>		
		private int _bf_count;
        public int bf_count
        {
            get{ return _bf_count; }
            set{ _bf_count = value; }
        }        
		/// <summary>
		/// bf_scoreofeach
        /// </summary>		
		private int _bf_scoreofeach;
        public int bf_scoreofeach
        {
            get{ return _bf_scoreofeach; }
            set{ _bf_scoreofeach = value; }
        }        
		/// <summary>
		/// bf_diff
        /// </summary>		
		private int _bf_diff;
        public int bf_diff
        {
            get{ return _bf_diff; }
            set{ _bf_diff = value; }
        }        
		/// <summary>
		/// bf_chapterrange
        /// </summary>		
		private string _bf_chapterrange;
        public string bf_chapterrange
        {
            get{ return _bf_chapterrange; }
            set{ _bf_chapterrange = value; }
        }        
		/// <summary>
		/// bf_countofeachchapter
        /// </summary>		
		private string _bf_countofeachchapter;
        public string bf_countofeachchapter
        {
            get{ return _bf_countofeachchapter; }
            set{ _bf_countofeachchapter = value; }
        }        
		/// <summary>
		/// sa_count
        /// </summary>		
		private int _sa_count;
        public int sa_count
        {
            get{ return _sa_count; }
            set{ _sa_count = value; }
        }        
		/// <summary>
		/// sa_scoreofeach
        /// </summary>		
		private int _sa_scoreofeach;
        public int sa_scoreofeach
        {
            get{ return _sa_scoreofeach; }
            set{ _sa_scoreofeach = value; }
        }        
		/// <summary>
		/// sa_diff
        /// </summary>		
		private int _sa_diff;
        public int sa_diff
        {
            get{ return _sa_diff; }
            set{ _sa_diff = value; }
        }        
		/// <summary>
		/// sa_chapterrange
        /// </summary>		
		private string _sa_chapterrange;
        public string sa_chapterrange
        {
            get{ return _sa_chapterrange; }
            set{ _sa_chapterrange = value; }
        }        
		/// <summary>
		/// sa_countofeachchapter
        /// </summary>		
		private string _sa_countofeachchapter;
        public string sa_countofeachchapter
        {
            get{ return _sa_countofeachchapter; }
            set{ _sa_countofeachchapter = value; }
        }        
		/// <summary>
		/// sr_list
        /// </summary>		
		private string _sr_list;
        public string sr_list
        {
            get{ return _sr_list; }
            set{ _sr_list = value; }
        }        
		/// <summary>
		/// cb_list
        /// </summary>		
		private string _cb_list;
        public string cb_list
        {
            get{ return _cb_list; }
            set{ _cb_list = value; }
        }        
		/// <summary>
		/// jd_list
        /// </summary>		
		private string _jd_list;
        public string jd_list
        {
            get{ return _jd_list; }
            set{ _jd_list = value; }
        }        
		/// <summary>
		/// bf_list
        /// </summary>		
		private string _bf_list;
        public string bf_list
        {
            get{ return _bf_list; }
            set{ _bf_list = value; }
        }        
		/// <summary>
		/// sa_list
        /// </summary>		
		private string _sa_list;
        public string sa_list
        {
            get{ return _sa_list; }
            set{ _sa_list = value; }
        }        
		   
	}
}