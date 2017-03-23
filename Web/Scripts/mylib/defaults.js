
/*
*
*JQUERY Easy UI 插件的重写
*
*/

void function () {
    $.extend($.fn.textbox.defaults, {
        height: 30,
        width: 200,
        required: true,
        missingMessage:'亲,该项为必填项哦'
    });
   
    $.extend($.fn.numberbox.defaults, {
        height: 30,
        width: 200,
        required: true,
        missingMessage: '亲,该项为必填项哦'
    });

    $.extend($.fn.combobox.defaults, {
        height: 30,
        width: 200,
        panelHeight: 'auto',
        editable: false
    });

    //重写datebox的formatter **处理两次的formatter***
    $.extend($.fn.datebox.defaults, {
        formatter: function (date) {
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            var d = date.getDate();
            return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
        },
        parser: function (s) {
            if (!s) return new Date();
            var ss = (s.split('-'));
            var y = parseInt(ss[0], 10);
            var m = parseInt(ss[1], 10);
            var d = parseInt(ss[2], 10);
            if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
                return new Date(y, m - 1, d);
            } else {
                return new Date();
            }
        }
    });

    /**
    *重写分页控件的显示
    */
    $.extend($.fn.pagination.defaults, {
        beforePageText: '第',//页数文本框前显示的汉字 
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录  共{total}条记录',
    });

    /**
    *重写datagrid的onLoadSuccess事件
    */
    $.extend($.fn.datagrid.defaults, {
        pageSize: 20,
      
    });

    $.extend($.fn.treegrid.defaults, {
       
    });

    $.extend($.fn.tree.defaults, {
       
    });
}()