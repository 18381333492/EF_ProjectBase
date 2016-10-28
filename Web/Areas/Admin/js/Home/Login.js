
$(function () {
    //根据窗口宽度生成图片宽度
    var width = $(window).width();
    $(".screenbg ul img").css("width", width + "px");

    var i = 0;
    var f = new eui();

    /*!
    * method:单击切换验证码
    * author:[汤台]
    * version:[1.0.0]
    */
    $('.codeImg img').click(function () {
        if (i > 4) {
            alert('图片验证码切换太频繁');
            return;
        }
        i++;
        $(this).attr("src", "/Admin/Home/GetImgCode/" + i + "");
    });

    /*!
    * method:后台用户登录
    * author:[汤台]
    * version:[1.0.0]
    */
    $('.login input').click(function () {
        var sUserName = $('.name input').val().trim();
        var sPassWord = $('.password input').val().trim();
        var sImgCode = $('.code input').val().trim();
        f.post('/Admin/Home/CheckLogin',
            {
                sUserName: sUserName,
                sPassWord, sPassWord,
                    sImgCode: sImgCode
                },
                function (res) {
                    location.href = "/Admin/Home/Index";
                },
                function (r) {
                    alert(r.info);
                    $('.codeImg img').click();
                });
    });
});