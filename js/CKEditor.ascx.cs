using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class js_CKEditor : System.Web.UI.UserControl
{
    private String height="200";
    private String width="800";
    private String theme = "default";

    
    //属性
    public String Text
    {
        get { return txtCKContent.Text; }
        set { txtCKContent.Text = value; }
    }
    public String Height
    {
        get { return height; }
        set { height = value; }
    }
    public String Width
    {
        get { return width; }
        set { width = value; }
    }
    public String Theme
    {
        get { return theme; }
        set { theme = value; }
    }
    //事件
    //public event EventHandler CKEditor_Submit;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (theme == "simple")
        {
            width = "600";
        }
    }

    //protected void btnCKSubmit_Click(object sender, EventArgs e)
    //{
    //    if (CKEditor_Submit != null)
    //        CKEditor_Submit(this, e);
    //}

    public String GetContextPath()
    {
        return Request.ApplicationPath;
    }

    public String GetToolBar()
    {
        if (theme == "simple")
        {
            return "[['Font', 'FontSize'],['Bold', 'Italic', 'Underline'], ['TextColor', 'BGColor'],['JustifyLeft', 'JustifyCenter', 'JustifyRight'],['NumberedList', 'BulletedList'],['Link', 'Unlink', 'Anchor']]";
        }
        return " [['Source', '-', 'Preview'], ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord'], ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'], ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote', 'ShowBlocks'],['Image', 'Flash', 'Table', 'HorizontalRule', 'SpecialChar'],'/',['Bold', 'Italic', 'Underline'], ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],  ['Styles', 'Format', 'Font', 'FontSize'], ['TextColor', 'BGColor'],['Link', 'Unlink', 'Anchor']]";
    }
}
