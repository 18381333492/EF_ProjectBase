
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



Array.prototype.GetValue = function () {
    var data = [];
    $(this).each(function () {
        var $this = this;
        data.push($($this).val());
    });
    return data.join();
}


Array.prototype.GetAttr = function (attrName) {
    var data = [];
    $(this).each(function () {
        var $this = this;
        data.push($($this).attr(attrName));
    });
    return data.join();
}