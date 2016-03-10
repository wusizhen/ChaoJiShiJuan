using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//tbClass
		public class tbClass
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
		/// classname
        /// </summary>		
		private string _classname;
        public string classname
        {
            get{ return _classname; }
            set{ _classname = value; }
        }        
		   
	}
}