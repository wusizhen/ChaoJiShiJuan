using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//tbSubject
		public class tbSubject
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
		/// subjectname
        /// </summary>		
		private string _subjectname;
        public string subjectname
        {
            get{ return _subjectname; }
            set{ _subjectname = value; }
        }        
		   
	}
}