
/*
*
*Easy UI 插件的重写js
*
*/

void function () {
    $.extend($.fn.textbox.defaults, {
        height: 30,
        width: 200,
        required:true 
    });

    $.extend($.fn.combobox.defaults, {
        height: 30,
        width: 200,
        panelHeight:'auto'
    });
}()