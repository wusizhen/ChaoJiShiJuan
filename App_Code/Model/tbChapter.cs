using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//tbChapter
		public class tbChapter
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
		/// chapterno
        /// </summary>		
		private int _chapterno;
        public int chapterno
        {
            get{ return _chapterno; }
            set{ _chapterno = value; }
        }        
		/// <summary>
		/// chaptername
        /// </summary>		
		private string _chaptername;
        public string chaptername
        {
            get{ return _chaptername; }
            set{ _chaptername = value; }
        }        
		   
	}
}