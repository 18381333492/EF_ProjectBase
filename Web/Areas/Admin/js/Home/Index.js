﻿
$(function () {
    var f = new eui();

    /*!
    * method:获取菜单列表数据
    * author:[汤台]
    * version:[1.0.0]
    */
    f.post("/Admin/Menus/GetMenusList", null, function (res) {
        LoadMenu(res);
    },
    function (r) {
        $('#my_menu').append('<div style="text-align:center;height:40px;line-height:40px;">菜单加载失败!</div>');
        f.alert(r.info);
    })

    /*!
    * method:加载菜单数据列表
    * author:[汤台]
    * version:[1.0.0]
    */
    function LoadMenu(res) {
        var Menus = JSON.parse(res.data);
        var html = [];
        $(Menus).each(function () {
            html.push('<div>');
            html.push('<span>' + this.sMenuName + '</span>');
            $(this.Menus).each(function () {
                var item = this;
                html.push('<a url="' + item.sMenuLink + '" style="cursor:pointer">' + item.sMenuName + '</a>');
            });
            html.push('</div>');
        });
        $('#my_menu').append(html.join(''));
        myMenu = new SDMenu("my_menu");
        myMenu.init();

        //绑定菜单单击事件
        $("#my_menu a").bind("click", function () {
            if ($('#tabs').tabs("getTab", $(this).text())) {
                $('#tabs').tabs("select", $(this).text());
            }
            else {
                var height = $('#tabs').height() - 35 - 2 * 4;
                $('#tabs').tabs('add', {
                    title: $(this).text(),
                    content: '<iframe scrolling="auto" frameborder="0"  src="' + $(this).attr("url") + '" width="100%" height="' + height + 'px";></iframe>',
                    closable: true,
                });
            }
        });
    }

    /*!
    * method:安全退出/注销
    * author:[汤台]
    * version:[1.0.0]
    */
    $('.admin-out').click(function () {
        f.post("/Admin/Home/Quit", null, function (r) {
            window.location.href = "/Admin/Home/Login";
        });
    });
});