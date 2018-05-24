/*global $, jQuery,AMap,window,console*/

var jsonc = "";

function dataIn(dd) {
    "use strict";
    jsonc = dd;
    var map, geolocation;
    //加载地图，调用浏览器定位服务
    map = new AMap.Map("n_ull", {
        resizeEnable: true
    });
    map.plugin('AMap.Geolocation', function () {
        geolocation = new AMap.Geolocation({
            enableHighAccuracy: true, //是否使用高精度定位，默认:true
            timeout: 10000,
            buttonOffset: new AMap.Pixel(10, 20),
            // zoomToAccuracy: true,
            buttonPosition: 'RB'
        });
        // map.addControl(geolocation);
        geolocation.getCurrentPosition();
        AMap.event.addListener(geolocation, 'complete', onComplete); //返回定位信息
        AMap.event.addListener(geolocation, 'error', onError);
    });
}
//解析定位结果
function onComplete(data) {
    "use strict";
    var str = {
        lat: data.position.getLat(),
        lng: data.position.getLng()
    };
    str = JSON.stringify(str);
    // location.replace("about:blank");
    // if(data.accuracy){
    //      str.push('精度：' + data.accuracy + ' 米');
    // }//如为IP精确定位结果则没有精度信息
    // str.push('是否经过偏移：' + (data.isConverted ? '是' : '否'));
    // document.getElementById('tip').innerHTML = str.join('<br>');
    // location.href="about:blank";
    window.document.getElementById(jsonc).innerHTML = str.toString();
}
//解析定位错误信息
function onError() {
    "use strict";
    console.log("position failed");
    window.document.getElementById(jsonc).innerHTML = "position failed";
    // location.href="about:blank";
}