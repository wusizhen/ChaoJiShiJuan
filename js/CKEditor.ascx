<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CKEditor.ascx.cs" Inherits="js_CKEditor"  %>

<script src='<%=ResolveClientUrl("~/js/ckeditor/ckeditor.js") %>'> type="text/javascript" runat="server"></script>

<script type="text/javascript" >

CKEDITOR.editorConfig = function( config )
{
	var basePath='<%=GetContextPath() %>/';
	
	config.filebrowserBrowseUrl= basePath+'js/ckfinder/ckfinder.html'; //上传文件时浏览服务文件夹 

    config.filebrowserImageBrowseUrl= basePath+'js/ckfinder/ckfinder.html?Type=Images'; //上传图片时浏览服务文件夹 

    config.filebrowserFlashBrowseUrl= basePath+'js/ckfinder/ckfinder.html?Type=Flash';  //上传Flash时浏览服务文件夹 

    config.filebrowserUploadUrl = basePath+'js/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files'; //上传文件按钮(标签) 

    config.filebrowserImageUploadUrl= basePath+'js/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images'; //上传图片按钮(标签) 

    config.filebrowserFlashUploadUrl= basePath+'js/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'; //上传Flash按钮(标签) 
    
    // 自定义工具栏
    config.toolbar =<%=GetToolBar() %>;
    
    config.width=<%=this.Width %>;
    config.height=<%=this.Height %>;

};

</script>
<div style='width:<%=this.Width %>px'>
    <div>
        <asp:TextBox ID="txtCKContent" runat="server" CssClass="ckeditor" TextMode="MultiLine">
        </asp:TextBox>
    </div>
    <div style="height:10px;"></div>
</div>
