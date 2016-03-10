using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//tbMessage
		public class tbMessage
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
		/// messagetitle
        /// </summary>		
		private string _messagetitle;
        public string messagetitle
        {
            get{ return _messagetitle; }
            set{ _messagetitle = value; }
        }        
		/// <summary>
		/// messagecontent
        /// </summary>		
		private string _messagecontent;
        public string messagecontent
        {
            get{ return _messagecontent; }
            set{ _messagecontent = value; }
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
		/// userid
        /// </summary>		
		private int _userid;
        public int userid
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
		/// <summary>
		/// visitcount
        /// </summary>		
		private int _visitcount;
        public int visitcount
        {
            get{ return _visitcount; }
            set{ _visitcount = value; }
        }        
		   
	}
}