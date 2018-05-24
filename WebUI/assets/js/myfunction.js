/*global $, jQuery,window*/
var ajaxUrlInputJsonReturnJson = function (argurl, arginputdata, callback) {
    'use strict';
    $.ajax({
        "url": argurl,
        "data": arginputdata,
        "contentType": "application/json; charset=utf-8",
        "type": "POST",
        "success": function (data) {
            callback(data.d);
        },
        "error": function () {
            window.alert('busy nice try');
        },
        "dataType": "json"
    });
};

// function parseFormInputToSingleRefJsonReturnString(formid) {}

var renderTbody = function (data, parameterArray, lastcolType, lastDataHTML, lastDataParaName) {
    'use strict';
    if (typeof data !== 'string' || Object.prototype.toString.call(parameterArray) !== '[object Array]' || typeof lastcolType !== 'string') {
        return;
    }
    //进行json对象转换之前将一些特殊符合进行编码或转义
    data = data.replace(/>/g, "&gt;");
    data = data.replace(/</g, "&lt;");
    //data = data.replace(" ", "&nbsp;");
    //data = data.replace("\"", "&quot;");
    data = data.replace(/'/g, "&#39;");
    data = data.replace(/\\/g, "\\\\"); //对斜线的转义
    // data = data.replace(/\n/, "\\n"); //注意php中替换的时候只能用双引号"\n"
    // data = data.replace("\r", "\\r");

    //转为 JS OBJECT
    data = JSON.parse(data);
    //渲染
    var intext = "",
        i, j;
    for (i = 0; i < data.total; i += 1) {
        intext += "<tr align='center'>";
        for (j = 0; j < parameterArray.length; j += 1) {
            intext += "<td>" + data.rows[i][parameterArray[j]] + "</td>";
        }
        switch (lastcolType) {
            case "empty":
                break;
            case "checkbox":
                intext += '<td><input type="checkbox" name="' + lastDataParaName + '" value="' + data.rows[i][lastDataParaName] + '" /></td>';
                break;
            case "a":
                // intext += "<td><a href='" + lastData + "'>进入</a></td>";
                intext += '<td><a href="' + lastDataHTML + '?' + (lastDataParaName === null ? '' : (lastDataParaName + '=' + data.rows[i][lastDataParaName])) + '"">进入</a></td>';
                break;
            case "img":
                // intext += "<td><a href='" + lastData + "'>进入</a></td>";
                intext += '<td><img src="' + data.rows[i][lastDataParaName] + '" width="100" height="66" alt="photo" /></td>';
                break;
            default:
                return;
        }
        intext += "</tr>";
    }
    // $("table.tablelist").children("tbody").append(intext);
    return intext;
};
$.fn.serializeObject = function () {
    'use strict';
    var o = {},
        a = this.serializeArray(),
        $radio = $("input[type='radio'],input[type='checkbox']", this);
    $.each(a, function () {
        if (o[this.name] != undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    $.each($radio, function () {
        if (!o.hasOwnProperty(this.name)) {
            o[this.name] = 'false';
        }
    });
    return o;
};

var parseFormInput = function (formid) {
    'use strict';
    if (typeof formid !== 'string') {
        return;
    }
    var afterdeal = '#' + formid,
        inputdatasmall = $(afterdeal).serializeObject();
    inputdatasmall = JSON.stringify(inputdatasmall);
    inputdatasmall = inputdatasmall.replace(/"([^"]*)"/g, "'$1'");
    return inputdatasmall;
};