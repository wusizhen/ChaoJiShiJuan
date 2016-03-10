function closeDiv(id)
{                          
  document.getElementById(id).style.display="none"; 
}
function show(id)
{
  document.getElementById(id).style.display="block";         
}
//检查所有数据是否填好
function checkall()
{
    with(document)
    {
        //单选
        if(getElementById("txtSRCount").value==""||$('#ddlSRScore').combobox('getValue')=="")
        {
           $.messager.alert('消息','单选题没填好！','alert');
           return false;
        }
        else{
            var count,score,allcount;
            if(!isNaN(getElementById("txtSRCount").value)&&!isNaN($('#ddlSRScore').combobox('getValue')))
            {                
               count=parseInt(getElementById("txtSRCount").value);
               score=parseFloat($('#ddlSRScore').combobox('getValue'));
               allcount=parseInt(getElementById("lblSRAll").innerText);
                
            }else
            {
               $.messager.alert('消息','单选题数字格式填写有误！','alert');
               return false;
            }
            if(count>allcount)
            {
               $.messager.alert('消息','单选题库数量不足！','alert');
               return false;              
            }
        }
        
        //多选
        if(getElementById("txtCBCount").value==""||$('#ddlCBScore').combobox('getValue')=="")
        {
           $.messager.alert('消息','多选题没填好！','alert');           
           return false;
        }
        else{
            var count,score,allcount;
            if(!isNaN(getElementById("txtCBCount").value)&&!isNaN($('#ddlCBScore').combobox('getValue')))
            {                
               count=parseInt(getElementById("txtCBCount").value);
               score=parseFloat($('#ddlCBScore').combobox('getValue'));
               allcount=parseInt(getElementById("lblCBAll").innerText);
                
            }else
            {
               $.messager.alert('消息','多选题数字格式填写有误！','alert');    
               return false;
            }
            if(count>allcount)
            {
               $.messager.alert('消息','多选题库数量不足！','alert');    
               return false;              
            }
        }
        
        //判断
        if(getElementById("txtJDCount").value==""||$('#ddlJDScore').combobox('getValue')=="")
        {
           $.messager.alert('消息','判断题没填好！','alert');               
           return false;
        }
        else{
            var count,score,allcount;
            if(!isNaN(getElementById("txtJDCount").value)&&!isNaN($('#ddlJDScore').combobox('getValue')))
            {                
               count=parseInt(getElementById("txtJDCount").value);
               score=parseFloat($('#ddlJDScore').combobox('getValue'));
               allcount=parseInt(getElementById("lblJDAll").innerText);
                
            }else
            {
               $.messager.alert('消息','判断题数字格式填写有误！','alert');                              
               return false;
            }
            if(count>allcount)
            {
               $.messager.alert('消息','判断题库数量不足！','alert');                                             
               return false;              
            }
        }
        
        //填空
        if(getElementById("txtBFCount").value==""||$('#ddlBFScore').combobox('getValue')=="")
        {
           $.messager.alert('消息','填空题没填好！','alert');  
           return false;
        }
        else{
            var count,score,allcount;
            if(!isNaN(getElementById("txtBFCount").value)&&!isNaN($('#ddlBFScore').combobox('getValue')))
            {                
               count=parseInt(getElementById("txtBFCount").value);
               score=parseFloat($('#ddlBFScore').combobox('getValue'));
               allcount=parseInt(getElementById("lblBFAll").innerText);
                
            }else
            {
               $.messager.alert('消息','填空题数字格式填写有误！','alert');                 
               return false;
            }
            if(count>allcount)
            {
               $.messager.alert('消息','填空题库数量不足！','alert');                                
               return false;              
            }
        }
        
        //简答
        if(getElementById("txtSACount").value==""||$('#ddlSAScore').combobox('getValue')=="")
        {
           $.messager.alert('消息','简答题没填好！','alert');                                
           return false;
        }
        else{
            var count,score,allcount;
            if(!isNaN(getElementById("txtSACount").value)&&!isNaN($('#ddlSAScore').combobox('getValue')))
            {                
               count=parseInt(getElementById("txtSACount").value);
               score=parseFloat($('#ddlSAScore').combobox('getValue'));
               allcount=parseInt(getElementById("lblSAAll").innerText);
                
            }else
            {
               $.messager.alert('消息','简答题数字格式填写有误！','alert');     
               return false;
            }
            if(count>allcount)
            {
               $.messager.alert('消息','简答题库数量不足！','alert');                    
               return false;              
            }
        }
    }
    return true;    
}

function compute()
{
    with(document)
    {
        var allScore=0;
        //单选
        if(getElementById("txtSRCount").value!=""&&$('#ddlSRScore').combobox('getValue')!="")
        {      
            var count,score,allcount,result;
            if(!isNaN(getElementById("txtSRCount").value)&&!isNaN($('#ddlSRScore').combobox('getValue')))
            {                
               count=parseInt(getElementById("txtSRCount").value);
               score=parseFloat($('#ddlSRScore').combobox('getValue'));
               allcount=parseInt(getElementById("lblSRAll").innerText);
                
            }else
            {
               $.messager.alert('消息','单选题数字格式填写有误！','alert');                                   
               return false;
            }
            if(count>allcount)
            {
               $.messager.alert('消息','单选题库数量不足！','alert');                                   
               return false;              
            }            
            result=count*score;
            allScore+=result;
            getElementById("SRCount").innerText=result.toString();
            
        }
        
        //多选
        if(getElementById("txtCBCount").value!=""&&$('#ddlCBScore').combobox('getValue')!="")
        {           
            var count,score,allcount,result;
            if(!isNaN(getElementById("txtCBCount").value)&&!isNaN($('#ddlCBScore').combobox('getValue')))
            {                
               count=parseInt(getElementById("txtCBCount").value);
               score=parseFloat($('#ddlCBScore').combobox('getValue'));
               allcount=parseInt(getElementById("lblCBAll").innerText);
                
            }else
            {
               $.messager.alert('消息','多选题数字格式填写有误！','alert');                                                                 
               return false;
            }
            if(count>allcount)
            {
               $.messager.alert('消息','多选题库数量不足！','alert');                                                                 
               return false;              
            }
            result=count*score;
            allScore+=result;
            getElementById("CBCount").innerText=result.toString();
        }
        
        //判断
        if(getElementById("txtJDCount").value!=""&&$('#ddlJDScore').combobox('getValue')!="")
        {           
            var count,score,allcount,result;
            if(!isNaN(getElementById("txtJDCount").value)&&!isNaN($('#ddlJDScore').combobox('getValue')))
            {                
               count=parseInt(getElementById("txtJDCount").value);
               score=parseFloat($('#ddlJDScore').combobox('getValue'));
               allcount=parseInt(getElementById("lblJDAll").innerText);
                
            }else
            {
               $.messager.alert('消息','判断题数字格式填写有误！','alert');                                                                 
               return false;
            }
            if(count>allcount)
            {
               $.messager.alert('消息','判断题库数量不足！','alert');                                                                 
               return false;              
            }
            result=count*score;
            allScore+=result;
            getElementById("JDCount").innerText=result.toString();
        }
        
        //填空
        if(getElementById("txtBFCount").value!=""&&$('#ddlBFScore').combobox('getValue')!="")
        {           
            var count,score,allcount,result;
            if(!isNaN(getElementById("txtBFCount").value)&&!isNaN($('#ddlBFScore').combobox('getValue')))
            {                
               count=parseInt(getElementById("txtBFCount").value);
               score=parseFloat($('#ddlBFScore').combobox('getValue'));
               allcount=parseInt(getElementById("lblBFAll").innerText);
                
            }else
            {
               $.messager.alert('消息','填空题数字格式填写有误！','alert');                                                                 
               return false;
            }
            if(count>allcount)
            {
               $.messager.alert('消息','填空题库数量不足！','alert');                                                                 
               return false;              
            }
            result=count*score;
            allScore+=result;
            getElementById("BFCount").innerText=result.toString();
        }
        
        //简答
        if(getElementById("txtSACount").value!=""&&$('#ddlSAScore').combobox('getValue')!="")
        {           
            var count,score,allcount,result;
            if(!isNaN(getElementById("txtSACount").value)&&!isNaN($('#ddlSAScore').combobox('getValue')))
            {                
               count=parseInt(getElementById("txtSACount").value);
               score=parseFloat($('#ddlSAScore').combobox('getValue'));
               allcount=parseInt(getElementById("lblSAAll").innerText);
                
            }else
            {
               $.messager.alert('消息','简答题数字格式填写有误！','alert');                                                                 
               return false;
            }
            if(count>allcount)
            {
               $.messager.alert('消息','简答题库数量不足！','alert');                                                                 
               return false;              
            }
            result=count*score;
            allScore+=result;
            getElementById("SACount").innerText=result.toString();
        }
        
        getElementById("AllCount").innerText=allScore.toString();
    }
}

function becancel(id)
{   
    var table=document.getElementById(id);
    var textboxArray=table.getElementsByTagName("input");
    for(var i = 1; i < textboxArray.length; i=i+2)    {
        textboxArray[i].value="";
    }
    closeDiv("view"+id+"Top");
}

function besure(id)
{
    var table=document.getElementById(id);
    var textboxArray=table.getElementsByTagName("input");
    var usefulArray=table.getElementsByTagName("span");    
    var tempCount=0;
    var j=0;

    for(var i = 1; i < textboxArray.length; i=i+2)    {   
        var usefulCount=parseInt(usefulArray[j].innerText);
        var inputCount;
        if(!isNaN(textboxArray[i].value))
        {
           inputCount=parseInt(textboxArray[i].value);
           if(inputCount>usefulCount)
           {
               $.messager.alert('消息',"超过有效的可选数目！",'alert');                                                                 
               return false;
           }
           tempCount+=inputCount;
        }else
        {
           $.messager.alert('消息',"你填写的数字格式有误！",'alert');                                                                 
           return false;
        }
        j++;
    }
    
    if(document.getElementById("lbl"+id+"Count").innerText!="")
    {
        var usefulAll=parseInt(document.getElementById("lbl"+id+"Count").innerText);
        if(tempCount!=usefulAll)
        {
            $.messager.alert('消息',"你出的题目不等于"+usefulAll+"!",'alert');                                                                 
            return false;
        }
    }else
    { 
        if(tempCount.toString()!="NaN")
        {      
           document.getElementById("txt"+id+"Count").value=tempCount; 
        }      
    }
    closeDiv("view"+id+"Top");
    return true;
}