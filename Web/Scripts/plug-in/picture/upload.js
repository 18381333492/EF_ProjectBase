





function upload() {
    
    var element;

    //创建图片上传插件
    function create(id, params) {
        element = document.getElementById(id);
        init();
    }


    //初始化
    function init(id) {
        var dd =$(element).load("/Scripts/plug-in/picture/style.html",
            function (data) {
                data = data.trim();                
                $(element).html(data);
                bingEvent();
        });
    }

    //绑定事件
    function bingEvent() {
        $(element).find("img").on("click", function () {
            $(element).find("input").click();
        });
        $(element).find("input").on("change", function () {
            if ($(this).val() != "") {   
                Up();
            }
        });
    }

    //上传图片
    function Up() {
             //利用easyui的表单提交上传图片
        $(element).find("from").form('submit', {
            url: option.url,
            queryParams: { path: option.path },
            success: function (data) {
                data = JSON.parse(data);
                if (data.success) {
                    //debugger
                    //option.callback && option.callback(data.message);
                    ////   $this.children().eq(0).attr("src", data.message);
                    //$this.children().eq(1).show();
                } else {
                    alert(data.message);
                }
            }
        });
    }

    return {
        create: create
    }
}
