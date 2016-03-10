var config = {  
    img: {
        css: "imgchange",
        loadStyle: "3px solid #EDF3FF",
        changeStyle: "3px solid #F37E03"
    },
    table: {
        //间隔变色
        separateClass: "separate",
        separateStyle: "#F9F9F9",
        backStyle: "",
        //鼠标移动变色
        hoverStyle: "#f5f5f5"
    }
};
$(document).ready(function() {
    //站点js初始化
    var _table = config.table;
    $("table.table tr:even").css("background-color", _table.separateStyle);
    $("table.table tbody tr,table.table tbody th").each(function() {
        var _bgcolor = $(this).css("background-color");
        $(this).mouseover(function() {
            $(this).css("background-color", _table.hoverStyle);
        }).mouseout(function() {
            $(this).css("background-color", _bgcolor);
        });
    });
});

$(document).ready(function() {
 $('input[name$="chkbAll"]').click(function(){
  if($(this).attr("checked") == "checked"||$(this).attr("checked")==true)
  {    //check all
       $('input[name$="chkbOne"]').each(function(){
        $(this).attr("checked",true);
       });
  }else{
       $('input[name$="chkbOne"]').each(function(){
        $(this).attr("checked",false);
       });
  }
 });
 
 $('#pp').pagination({  
    pageList:[12,20,30,50]
 }); 
});



