

/**
* 
* @for 所有的商品统一下单js
*
**
******************************/

function order() {

    var order = {
        sGoodName: "",              //商品名字
        sGoodNo: "",                //商品编号(唯一)
        sGoodsPicture: "",          //商品图片
        sGoodsInfo:'',              //商品规格
        iGoodsCount: 0,             //购买数量
        dTotalPrices: 0,            //总价
        dPrices: 0,                 //实际支付价格
        sActivity: '',              //活动
        sOrderRemark: '',           //订单备注
        sReceiver: '',              //收件人
        sAddress: '',               //收货地址
        sPhone: '',                 //手机号
    }

    function checkParams() {

        //反馈给用户的提示
        if (client.string.isEmpty(order.sReceiver))
            return alert("亲,请输入收件人姓名!");
        if (client.string.isEmpty(order.sPhone))
            return alert("亲,请输入收件人手机号码!");
        if (!client.regex.isPhone(order.sPhone))
            return alert("亲,手机号码格式不对!");
        if (client.string.isEmpty(order.sAddress))
            return alert("亲,收货地址还没填写呢!");

        //系统验证
        if (order.iGoodsCount <= 0)
            return alert("参数错误!");
        if (order.dTotalPrices <= 0)
            return alert("参数错误!");
        if (order.dPrices <= 0)
            return alert("参数错误!");
        if (client.string.isEmpty(order.sGoodName))
            return alert("参数错误!");
        if (client.string.isEmpty(order.sGoodNo))
            return alert("参数错误!");
        if (client.string.isEmpty(order.sGoodsPicture))
            return alert("参数错误!");
        if (client.string.isEmpty(order.sGoodsInfo))
            return alert("参数错误!");

        return true;
    }
    
    //订单提交
    function orderCommit() {
        if (checkParams()) {
            client.ajax.ajaxRequest(
                "/Mobile/Orders/BookOrder",
                order,
                function (r) {
                    location.href = "跳转支付链接";
                });
        }
    }

    return {
        order: order,
        orderCommit: orderCommit
    }


}