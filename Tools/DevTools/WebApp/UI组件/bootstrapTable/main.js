

//时间格式化  yyyy-MM-dd hh:mm:ss
function Data_String(str) {
    var d = eval('new ' + str.substr(1, str.length - 2));
    var ar_date = [d.getFullYear(), d.getMonth() + 1, d.getDate(), d.getHours(), d.getMinutes(), d.getSeconds()];
    for (var i = 0; i < ar_date.length; i++) ar_date[i] = dFormat(ar_date[i]);
    return ar_date.slice(0, 3).join('-') + ' ' + ar_date.slice(3).join(':');

    function dFormat(i) { return i < 10 ? "0" + i.toString() : i; }
}

//指定的时间格式化成指定的格式
var format = function (time, format) {
    var t = new Date(time);
    var tf = function (i) { return (i < 10 ? '0' : '') + i };
    return format.replace(/yyyy|MM|dd|HH|mm|ss/g, function (a) {
        switch (a) {
            case 'yyyy':
                return tf(t.getFullYear());
                break;
            case 'MM':
                return tf(t.getMonth() + 1);
                break;
            case 'mm':
                return tf(t.getMinutes());
                break;
            case 'dd':
                return tf(t.getDate());
                break;
            case 'HH':
                return tf(t.getHours());
                break;
            case 'ss':
                return tf(t.getSeconds());
                break;
        }
    })
}


function getNames(obj, name, tij) {
    var p = document.getElementById(obj);
    var plist = p.getElementsByTagName(tij);
    var rlist = new Array();
    for (i = 0; i < plist.length; i++) {
        if (plist[i].getAttribute("name") == name) {
            rlist[rlist.length] = plist[i];
        }
    }
    return rlist;
}

function fod(obj, name) {
    var p = obj.parentNode.getElementsByTagName("span");
    var p1 = getNames(name, "f", "div"); // document.getElementById(name).getElementsByTagName("div");
    for (i = 0; i < p1.length; i++) {
        if (obj == p[i]) {
            p[i].className = "active";
            p1[i].className = "dis";
        }
        else {
            p[i].className = "normal";
            p1[i].className = "hidden";
        }
    }
}
//移除HTML
String.prototype.stripHTML = function () {
    var reTag = /<(?:.|\s)*?>/g;
    return this.replace(reTag, "");
}

///跳转到iframe
function gotoHref(str) {
    if (str != "") {
        $("#mainIframe", window.parent.document).attr("src", str);
    }
}
