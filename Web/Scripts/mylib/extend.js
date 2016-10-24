/*
*
* @description:对js现有的数据类型的扩展
* @author:tangtai
* @time:2016-09-19
* 
*/

String.prototype.url = function (name) {
    return this + name;
}

//Object.prototype.GetValue = function () {
//    try {
//        var data = [];
//        $(this).each(function () {
//            var $this = this;
//            data.push($($this).val());
//        });
//        return data.join();
//    } catch (e) {
//        alert(e.message);
//    }
//}


//Object.prototype.GetAttr = function (attrName) {
//    try {
//        var data = [];
//        $(this).each(function () {
//            var $this = this;
//            data.push($($this).attr(attrName));
//        });
//        return data.join();
//    } catch (e) {
//        alert(e.message);
//    }
//}