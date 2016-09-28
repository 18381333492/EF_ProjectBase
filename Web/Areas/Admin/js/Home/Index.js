
$(function () {
    
    //菜单的初始化
    myMenu = new SDMenu("my_menu");
    myMenu.init();
    $('ul').attr("style", "height:33px");
    $('ul .tabs-inner').attr("style", "height: 33px; line-height: 33px");
});