
$(function () {
    //根据窗口宽度生成图片宽度
    var width = $(window).width();
    $(".screenbg ul img").css("width", width + "px");

    var i = 0;
    //单击切换验证码
    $('.codeImg img').click(function () {
        if (i > 4) {
            alert('图片验证码切换太频繁');
            return;
        }
        i++;
        $(this).attr("src", "/Admin/Home/GetImgCode/" + i + "");
    });

    //后台用户登录
    $('.login input').click(function () {
        var sUserName = $('.name input').val().trim();
        var sPassWord = $('.password input').val().trim();
        var sImgCode = $('.code input').val().trim();
        $.ajax({
            url: '/Admin/Home/CheckLogin',
            type: 'POST',
            dataType: 'json',
            data: {
                sUserName: sUserName,
                sPassWord, sPassWord,
                    sImgCode: sImgCode
            }
                ,
            success: function (res) {
                if (res.success) {
                    location.href = "/Admin/Home/Index";
                }
                else {
                    alert(res.info);
                }
            },
            error: function (res) {
                alert(res.info);
            },
        })
    });
});