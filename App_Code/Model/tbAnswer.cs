using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//tbAnswer
		public class tbAnswer
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
		/// chapterid
        /// </summary>		
		private int _chapterid;
        public int chapterid
        {
            get{ return _chapterid; }
            set{ _chapterid = value; }
        }        
		/// <summary>
		/// ques
        /// </summary>		
		private string _ques;
        public string ques
        {
            get{ return _ques; }
            set{ _ques = value; }
        }        
		/// <summary>
		/// ans
        /// </summary>		
		private string _ans;
        public string ans
        {
            get{ return _ans; }
            set{ _ans = value; }
        }        
		/// <summary>
		/// diff
        /// </summary>		
		private int _diff;
        public int diff
        {
            get{ return _diff; }
            set{ _diff = value; }
        }        
		/// <summary>
		/// selectcount
        /// </summary>		
		private int _selectcount;
        public int selectcount
        {
            get{ return _selectcount; }
            set{ _selectcount = value; }
        }        
		/// <summary>
		/// rightcount
        /// </summary>		
		private int _rightcount;
        public int rightcount
        {
            get{ return _rightcount; }
            set{ _rightcount = value; }
        }        
		/// <summary>
		/// questype
        /// </summary>		
		private int _questype;
        public int questype
        {
            get{ return _questype; }
            set{ _questype = value; }
        }        
		   
	}
}