using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//tbArrange
		public class tbArrange
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
		/// paperid
        /// </summary>		
		private int _paperid;
        public int paperid
        {
            get{ return _paperid; }
            set{ _paperid = value; }
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
		/// arrangetitle
        /// </summary>		
		private string _arrangetitle;
        public string arrangetitle
        {
            get{ return _arrangetitle; }
            set{ _arrangetitle = value; }
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
		/// <summary>
		/// arrangetype
        /// </summary>		
		private int _arrangetype;
        public int arrangetype
        {
            get{ return _arrangetype; }
            set{ _arrangetype = value; }
        }        
		   
	}
}