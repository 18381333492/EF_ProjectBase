var webFont = (function(){
    //判断设备显示字体
	if(judge.platform() == "ios"){
		var str = "<style> body{ font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif!important;}</style>";
		$('head').append(str);
	}
	if(judge.platform()=="android"){
		var str = "<style>body{ font-family: 'RobotoRegular', 'Droid Sans', sans-serif!important;}</style>";
		$('head').append(str);
	}
})()

//$(function(){


//    var customFunc =function(){
//             alert(1);
//         }
//    $('.add-collection').click(function(){
//        $(this).find('i').toggleClass('on');
//        //showToast("已加入收藏夹！","2","","");       
//        showConfirm("主题样式切换代码：jQuery Theme Switcher",customFunc);
//    })
//    $('.js_notes').click(function(){
//        $('.notes').velocity("fadeIn",{duration:250});
//    })
//    $('.js_notes_off').click(function(){
//        $('.notes').velocity("fadeOut",{duration:250});
//    })


//    $(".t-order-btn,.t-start-btn,.t-car").click(function(){
//        showConfirm("主题样式切换代码：jQuery Theme Switcher",customFunc);
//    })
//})

//var showToast = function(hint,time,url,pagename){
//    var str = "<div class='dialog toast-wrap'>";
//        str += "<div class='toast'><h4>"+hint+"</h4>";
//        if(url !== ""){
//            str += "<p>"+time+"秒后跳转至<a class='text-orange' href='url'>"+pagename+"</a></p>";
//        }
//        str += "</div></div>";
    
//    $('body').append(str);
//    $('.toast-wrap')
//        .velocity("fadeIn",{duration:250})
//        .velocity("fadeOut",{delay:time*1000,duration:150,complete:function(){
//            window.location.href = url || "#";
//            $('.toast-wrap').remove();
//        }});             
//}
//var showConfirm = function(hint,confirm){
//    var str = "<div class='dialog dialog-confirm'>";
//        str += "<div class='confirm'><div class='body'><p>"+hint+"</p></div>";
//        str += "<div class='foot flex-wrap'>";
//        if(confirm !== ""){
//            str += "<a class='flex-item-1 js_close'>取消</a>";
//            str += "<a class='flex-item-1 js_confirm'>确定</a>";
//        }else{
//            str += "<a class='flex-item-1 js_close'>确定</a>";
//        }
//        $('body').append(str);
//        $('.dialog-confirm') .velocity("fadeIn",{duration:250});
//    $('body').find('.js_close').on('click',function(){
//        $('.dialog-confirm') .velocity("fadeOut",{duration:200});
//        setTimeout(function(){
//            $('.dialog-confirm').remove();
//        },500)
//    })
//    $('body').find('.js_confirm').on('click',function(){
//        confirm();
//        $('.dialog-confirm') .velocity("fadeOut",{duration:200});
//        setTimeout(function(){
//            $('.dialog-confirm').remove();
//        },500)
//    })
  
//}

//var tips=function(msg,time){
//    if($('body').find('.tips').length == 0){
//        var str = '<div class="tips">';
//        str+=' <p>';
//        str+=msg;
//        str+='</p>';
//        str +='</div>';
//        $('body').append(str);
//        window.setTimeout(function(){
//            $('.tips').remove();
//        },time);
//    }
//    else {
//        $('body').find('.tips p').text(msg);
//        window.setTimeout(function(){
//            $('.tips').remove();
//        },time);
//    }


//};
