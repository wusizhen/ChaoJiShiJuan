using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//tbScore
		public class tbScore
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
		/// arrangeid
        /// </summary>		
		private int _arrangeid;
        public int arrangeid
        {
            get{ return _arrangeid; }
            set{ _arrangeid = value; }
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
		/// hasshortanswer
        /// </summary>		
		private int _hasshortanswer;
        public int hasshortanswer
        {
            get{ return _hasshortanswer; }
            set{ _hasshortanswer = value; }
        }        
		/// <summary>
		/// hascorrect
        /// </summary>		
		private int _hascorrect;
        public int hascorrect
        {
            get{ return _hascorrect; }
            set{ _hascorrect = value; }
        }        
		/// <summary>
		/// score
        /// </summary>		
		private decimal _score;
        public decimal score
        {
            get{ return _score; }
            set{ _score = value; }
        }        
		/// <summary>
		/// scorestatus
        /// </summary>		
		private int _scorestatus;
        public int scorestatus
        {
            get{ return _scorestatus; }
            set{ _scorestatus = value; }
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
		/// starttime
        /// </summary>		
		private DateTime _starttime;
        public DateTime starttime
        {
            get{ return _starttime; }
            set{ _starttime = value; }
        }        
		/// <summary>
		/// endtime
        /// </summary>		
		private DateTime _endtime;
        public DateTime endtime
        {
            get{ return _endtime; }
            set{ _endtime = value; }
        }        
		   
	}
}