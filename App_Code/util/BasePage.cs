using System;
using System.Web;


/// <summary>
///Page的基类
/// </summary>

namespace Util
{
    public class BasePage : System.Web.UI.Page
    {
        public int pageTotal;
        public int pageSize = 12;
        public int pageIndex = 1;

        public BasePage()
        {
            this.Load += new EventHandler(BasePage_Load); 
        }

        void BasePage_Load(object sender, EventArgs e)
        {
            
        }
    }    
}