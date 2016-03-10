using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//tbUser
		public class tbUser
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
		/// loginname
        /// </summary>		
		private string _loginname;
        public string loginname
        {
            get{ return _loginname; }
            set{ _loginname = value; }
        }        
		/// <summary>
		/// realname
        /// </summary>		
		private string _realname;
        public string realname
        {
            get{ return _realname; }
            set{ _realname = value; }
        }        
		/// <summary>
		/// userpwd
        /// </summary>		
		private string _userpwd;
        public string userpwd
        {
            get{ return _userpwd; }
            set{ _userpwd = value; }
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
		/// <summary>
		/// usertype
        /// </summary>		
		private int _usertype;
        public int usertype
        {
            get{ return _usertype; }
            set{ _usertype = value; }
        }        
		   
	}
}