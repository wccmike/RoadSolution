
$(function () {

    var initZoom = 15;
    var rm = 40;
    var circleR = 4000;

    var username = document.cookie.split(";")[0].split("=")[1];
    if (username == "ankang") {
        rm = 1;
        initZoom = 9;
        circleR = 30000;
    }

    function LBMap(mid) {
        this.map = null;
        this.marks = [];
        this.circles = [];
        this.init(mid);

        this.clear = function (ol) {
            for (var i = 0; i < ol.length; i++) {
                this.map.removeOverlay(ol[i]);
            }
        }
    }

    // 初始化地图
    LBMap.prototype.init = function (mid) {
        // 百度地图API功能
        var map = new BMap.Map(mid, {
            mapType: BMAP_NORMAL_MAP
        }); // 创建地图实例
        var point = new BMap.Point(108.953098279, 34.2777998978); // 创建点坐标
        map.centerAndZoom(point, initZoom); // 初始化地图，设置中心点坐标和地图级别
        map.enableScrollWheelZoom();
        map.addControl(new BMap.MapTypeControl({
            mapTypes: [BMAP_NORMAL_MAP, BMAP_HYBRID_MAP]
        }));

        map.addEventListener("zoomend", function () {
            // 缩放结束后事件回调
            var zm = map.getZoom();
        });
        this.map = map;
    };


    // 添加标记
    LBMap.prototype.addMark = function (pt, setting) {
        var point = new BMap.Point(pt[0], pt[1]);
        var marker = new BMap.Marker(point);

        if (setting.icon != null && setting.icon != "") {
            var myIcon = new BMap.Icon(setting.icon, new BMap.Size(35, 35), {
                // 指定定位位置。
                // 当标注显示在地图上时，其所指向的地理位置距离图标左上
                // 角各偏移10像素和25像素。您可以看到在本例中该位置即是
                // 图标中央下端的尖角位置。
                offset: new BMap.Size(10, 25)
            });

            marker.setIcon(myIcon);
        }

        if (setting.title != null && setting.title != "") {
            // 创建标注对象并添加到地图
            var label = new BMap.Label(setting.title, {
                offset: new BMap.Size(-5, 35)
            });
            label.setStyle({
                "border": "0px",
                "border-radius": "4px"
            });
            marker.setLabel(label);
        }

        this.map.addOverlay(marker);
        this.marks.push(marker);
        return marker;
    };

    // 绘制圆
    LBMap.prototype.addCircle = function (pt, r) {

        var point = new BMap.Point(pt.lng, pt.lat);
        var circle = new BMap.Circle(point, r, {
            strokeColor: "",
            strokeWeight: 2,
            strokeOpacity: 0.5,
            fillOpacity: 0.2,
            fillColor: ""
        });
        this.map.addOverlay(circle);
        this.circles.push(circle);
    }

    // 绘制线
    LBMap.prototype.addPolyline = function (pts, icon) {
        var points = [];
        for (var i = 0; i < pts.length; i++) {
            var pt = pts[i];
            var point = new BMap.Point(pt[0], pt[1]);
            points.push(point);
        }
        var polyline = new BMap.Polyline(points, {
            strokeColor: "green",
            strokeWeight: 2
        });
        this.map.addOverlay(polyline);
        //this.circles.push(polyline);
    }

    // 绘制巡查点
    LBMap.prototype.addCheckPoint = function (title, pt, icon) {

        var point = new BMap.Point(pt[0], pt[1]);
        var marker = new BMap.Marker(point);
        var myIcon = new BMap.Icon(icon, new BMap.Size(20, 20));

        // 创建标注对象并添加到地图
        var label = new BMap.Label(title, {
            offset: new BMap.Size(-5, 20)
        });
        label.setStyle({
            "border": "0px",
            "border-radius": "4px"
        });
        marker.setLabel(label);

        marker.setIcon(myIcon);
        this.map.addOverlay(marker);
        this.marks.push(marker);
    }

    var mrMap = new LBMap("m-map");
    var ptMap = new LBMap("p-map");

    // 初始化部门树
    Dept.Tree.init($("#tree"), function (node) {
        if (node.level >= 1) {
            loadData();
        }
    });

    function loadData() {
        mrMap.clear(mrMap.marks);
        mrMap.clear(mrMap.circles);
        addMarks(mrMap);
        addCircle(mrMap, circleR);
        selectMonitorMap();
    }

    setTimeout(function () {
        Dept.Tree.selectNode(1);
        loadData();
    }, 2000);

    // 添加人员
    function addMarks(map) {
        for (var i = 0; i < 2; i++) {
            var lng = 108.953098279;
            var lat = 34.2777998978;
            var x = 0;
            var y = 0;
            if (i % 4 == 0) {
                x = parseFloat(lng.toFixed(2)) + 0.02;
                y = parseFloat(lat.toFixed(2)) + 0.01;
            } else if (i % 4 == 1) {
                x = parseFloat(lng.toFixed(2)) + 0.008;
                y = parseFloat(lat.toFixed(2));
            } else if (i % 4 == 2) {
                x = parseFloat(lng.toFixed(2)) + 0.01;
                y = parseFloat(lat.toFixed(2));
            } else {
                x = parseFloat(lng.toFixed(2)) - 0.1;
                y = parseFloat(lat.toFixed(2));
            }

            var marker = map.addMark([x, y], {
                title: "路长" + (i + 1),
                icon: "assets/images/person.png"
            });

            marker.addEventListener("click", function (e) {
                // 获取人员信息
                var mark = e.target;
                selectPersonTrack(mark)

            });
        }

    }


    function selectPersonTrack(mark) {
        switchTab("p-map");
        setTimeout(function () {
            ptMap.clear(ptMap.marks);
            ptMap.clear(ptMap.circles);
            ptMap.map.setZoom(13);
            var cpt = ptMap.map.getCenter();
            cpt.lng = 108.953098279;
            cpt.lat = 34.2777998978;
            var marker = ptMap.addMark([cpt.lng, cpt.lat], {
                title: "路长",
                icon: "assets/images/person.png"
            });
            marker.setAnimation(BMAP_ANIMATION_BOUNCE);
            //addCircle(ptMap, 3000);

            var llng = parseFloat(cpt.lng.toFixed(4));
            var llat = parseFloat(cpt.lat.toFixed(4));
            var pts = [];
            pts.push([llng, llat]);
            pts.push([llng + 0.00474, llat + 0.05478]);
            pts.push([llng + 0.01121, llat + 0.05067]);
            pts.push([llng + 0.01579, llat + 0.05045]);
            pts.push([llng + 0.02145, llat + 0.04718]);
            pts.push([llng + 0.01193, llat + 0.0427]);
            pts.push([llng + 0.00061, llat + 0.04604]);
            pts.push([llng + 0.00294, llat + 0.04946]);
            pts.push([llng + 0.00133, llat + 0.05569]);
            pts.push([llng + 0.0254, llat + 0.05174]);
            pts.push([llng + 0.05235, llat + 0.04847]);
            pts.push([llng + 0.07319, llat + 0.03806]);
            pts.push([llng + 0.03717, llat + 0.0332]);
            pts.push([llng + 0.08101, llat + 0.06009]);
            pts.push([llng + 0.004, llat + 0.04239]);
            pts.push([cpt.lng, cpt.lat]);
            ptMap.addPolyline(pts);





            // 添加巡查点
            for (var i = 0; i < 5; i++) {
                var x = 0;
                var y = 0;
                if (i % 4 == 0) {
                    x = parseFloat(cpt.lng.toFixed(2)) + (Math.random() / 20);
                    y = parseFloat(cpt.lat.toFixed(2)) + (Math.random() / 20);
                } else if (i % 4 == 1) {
                    x = parseFloat(cpt.lng.toFixed(2)) - (Math.random() / 20);
                    y = parseFloat(cpt.lat.toFixed(2)) - (Math.random() / 20);
                } else if (i % 4 == 2) {
                    x = parseFloat(cpt.lng.toFixed(2)) + (Math.random() / 20);
                    y = parseFloat(cpt.lat.toFixed(2)) - (Math.random() / 20);
                } else {
                    x = parseFloat(cpt.lng.toFixed(2)) - (Math.random() / 20);
                    y = parseFloat(cpt.lat.toFixed(2)) + (Math.random() / 20);
                }
                var icon = "images/s_point.png";
                //ptMap.addCheckPoint("巡查点" + (i+1), [x, y], icon);
            }

        }, 500)
    }

    function selectMonitorMap() {
        setTimeout(function () {
            switchTab("m-map");
        }, 500);
    }
    // 地图监控和人员跟踪切换
    function switchTab(mid) {
        $(".itab").find("li").find("a").each(function () {
            var hf = $(this).attr("href");
            if (hf == "#" + mid) {
                if (!$(this).is(".selected")) {
                    $(this).addClass("selected");
                    $(hf).parent().parent().parent().parent().parent().show();
                }
            } else {
                $(this).removeClass("selected");
                $(hf).parent().parent().parent().parent().parent().hide();
            }
        });
        if (mid == "m-map") {
            $(".search_container").show();
        } else {
            $(".search_container").hide();
        }
    }

    $(".itab").find("li").find("a").bind("click", function () {
        var hf = $(this).attr("href");
        if (hf == "#m-map") {
            switchTab("m-map");
        }
    });

    $(window).resize(function () {
        // 计算界面高度
        lrResize();
    });

    function lrResize() {
        //获取浏览器可见区域高度
        var ht = $(window).height() - 50;
        $(".o-map").css({
            "height": ht + "px"
        });
    };

    lrResize();

    $(".task_list").find(".item").find("ul li").bind("click", function () {

        $("#dialog-modal").dialog({
            title: "任务详情",
            modal: true,
            width: 450
        });

    });
});