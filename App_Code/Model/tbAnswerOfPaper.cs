using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//tbAnswerOfPaper
		public class tbAnswerOfPaper
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
		/// answerid
        /// </summary>		
		private int _answerid;
        public int answerid
        {
            get{ return _answerid; }
            set{ _answerid = value; }
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
		/// useranswer
        /// </summary>		
		private string _useranswer;
        public string useranswer
        {
            get{ return _useranswer; }
            set{ _useranswer = value; }
        }        
		/// <summary>
		/// getscore
        /// </summary>		
		private decimal _getscore;
        public decimal getscore
        {
            get{ return _getscore; }
            set{ _getscore = value; }
        }        
		/// <summary>
		/// allscore
        /// </summary>		
		private decimal _allscore;
        public decimal allscore
        {
            get{ return _allscore; }
            set{ _allscore = value; }
        }        
		   
	}
}