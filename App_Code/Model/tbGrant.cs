using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//tbGrant
		public class tbGrant
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
		/// userid
        /// </summary>		
		private int _userid;
        public int userid
        {
            get{ return _userid; }
            set{ _userid = value; }
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
		/// classid
        /// </summary>		
		private int _classid;
        public int classid
        {
            get{ return _classid; }
            set{ _classid = value; }
        }        
		   
	}
}