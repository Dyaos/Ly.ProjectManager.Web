//获取url参数的值
//name 对应参数名称
$.request = function (name) {
    var search = location.search.slice(1);
    var arr = search.split("&");
    for (var i = 0; i < arr.length; i++) {
        var ar = arr[i].split("=");
        if (ar[0] == name) {
            if (unescape(ar[1]) == 'undefined') {
                return "";
            } else {
                return unescape(ar[1]);
            }
        }
    }
    return "";
}
//type 提示类型
//msg 提示内容
//callback 回调函数
$.toastMsg = function (msg, type, title, callback, options) {
    var defaults = {
        "closeButton": true,
        "debug": false,
        "progressBar": true,
        "positionClass": "toast-bottom-full-width",
        "onclick": null,
        "showDuration": "400",
        "hideDuration": "1000",
        "timeOut": "2000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    top.toastr.options = $.extend(defaults, options);
    top.toastr[type](msg, title);
}
//重新加载
$.reload = function () {
    location.reload();
    return false;
}
//加载层
//type false关闭 true打开
$.loading = function (type) {
    if (type) {
        top.layer.load(2);
    } else {
        top.layer.closeAll("loading");
    }
}
//当前frame
//index
$.currentWindow = function () {
    var iframeId = top.$(".J_menuTab.active").attr("data-id");
    var iframe = top.$("iframe[data-id='" + iframeId + "']");
    return top.frames[$(iframe[0]).attr("name")];
}

//关闭弹窗
//type 关闭的弹窗类型
$.closeAll = function (type) {
    top.layer.closeAll(type);
};
//使用layui打开一个iframe
//options 配置参数
$.modalOpen = function (options) {
    var defaults = {
        id: null,
        title: '系统窗口',
        width: "100px",
        height: "100px",
        url: '',
        fix: false,
        shade: 0.3,
        btn: ['确认', '关闭'],
        maxmin: true,
        btnclass: ['btn btn-primary', 'btn btn-danger'],
        callBack: null
    };
    options = $.extend(defaults, options);
    var _width = top.$(window).width() > parseInt(options.width.replace('px', '')) ? options.width : top.$(window).width() + 'px';
    var _height = top.$(window).height() > parseInt(options.height.replace('px', '')) ? options.height : top.$(window).height() + 'px';
    var current = top.layer.open({
        id: options.id,
        type: 2,
        shade: options.shade,
        title: options.title,
        fix: false,
        area: [_width, _height],
        content: options.url,
        btn: options.btn,
        shadeClose: true,
        maxmin: options.maxmin, //开启最大化最小化按钮
        btnclass: options.btnclass,
        yes: function () {
            var iframe = top.frames[options.id];
            var id = $(iframe).find("iframe").attr("id");
            options.callBack(id)
        }, cancel: function () {
            return true;
        }
    });
};
//关闭使用layui打开的iframe
$.modalClose = function () {
    var index = top.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
    var $IsdialogClose = top.$("#layui-layer" + index).find('.layui-layer-btn').find("#IsdialogClose");
    var IsClose = $IsdialogClose.is(":checked");
    if ($IsdialogClose.length == 0) {
        IsClose = true;
    }
    if (IsClose) {
        top.layer.close(index);
    } else {
        location.reload();
    }
};
//Confirm 提示框
//content 选择内容
//callBack 回调函数
$.modalConfirm = function (content, callBack) {
    top.layer.confirm(content, {
        icon: "fa-exclamation-circle",
        title: "系统提示",
        btn: ['确认', '取消'],
        btnclass: ['btn btn-primary', 'btn btn-danger'],
    }, function () {
        callBack(true);
    }, function () {
        callBack(false)
    });
};
//提交表单
$.submitForm = function (options) {
    var defaults = {
        url: "",
        param: [],
        loading: "正在提交数据...",
        success: null,
        close: true
    };
    var options = $.extend(defaults, options);
    $.loading(true, options.loading);
    window.setTimeout(function () {
        if ($('[name=__RequestVerificationToken]').length > 0) {
            options.param["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
        }
        $.ajax({
            url: options.url,
            data: options.param,
            type: "post",
            dataType: "json",
            success: function (data) {
                if (data.state == "success") {
                    options.success(data);
                    if (options.close == true) {
                        $.modalClose();
                    }
                    $.toastMsg(data.message, data.state);
                } else {
                    $.toastMsg(data.message, data.state);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.loading(false);
                $.toastMsg(data.message, "error");
            },
            beforeSend: function () {
                $.loading(true, options.loading);
            },
            complete: function () {
                $.loading(false);
            }
        });
    }, 500);
};
//删除表单
$.deleteForm = function (options) {
    var defaults = {
        prompt: "注：您确定要删除该项数据吗？",
        url: "",
        param: [],
        success: null,
        close: true
    };
    var options = $.extend(defaults, options);
    if ($('[name=__RequestVerificationToken]').length > 0) {
        options.param["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
    }
    $.modalConfirm(options.prompt, function (r) {
        if (r) {
            $.loading();
            window.setTimeout(function () {
                $.ajax({
                    url: options.url,
                    data: options.param,
                    type: "post",
                    dataType: "json",
                    success: function (data) {
                        if (data.state == "success") {
                            options.success(data);
                            $.toastMsg(data.message, data.state);
                        } else {
                            $.toastMsg(data.message, "error");
                        }
                        $.closeAll("dialog");
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        $.loading(false);
                        $.toastMsg(errorThrown, "error");
                        $.closeAll("dialog");
                    },
                    beforeSend: function () {
                        $.loading(true);
                    },
                    complete: function () {
                        $.loading(false);
                    }
                });
            }, 500);
        }
    });
};
//序列化表单
$.fn.formSerialize = function (formdate) {
    var element = $(this);
    if (!!formdate) {
        for (var key in formdate) {
            var $id = element.find('#' + key);
            var value = $.trim(formdate[key]).replace(/&nbsp;/g, '');
            var type = $id.attr('type');
            if ($id.hasClass("select2-hidden-accessible")) {
                type = "select";
            }
            switch (type) {
                case "checkbox":
                    if (value == "true") {
                        $id.attr("checked", 'checked');
                    } else {
                        $id.removeAttr("checked");
                    }
                    break;
                case "select":
                    $id.val(value).trigger("change");
                    break;
                default:
                    $id.val(value);
                    break;
            }
        };
        return false;
    }
    var postdata = {};

    element.find('input,select,textarea').each(function (r) {
        var $this = $(this);
        var id = $this.attr('id');
        var type = $this.attr('type');
        switch (type) {
            case "checkbox":
                postdata[id] = $this.is(":checked");
                break;
            default:
                var value = $this.val() == "" ? "&nbsp;" : $this.val();
                if (!$.request("keyValue")) {
                    value = value.replace(/&nbsp;/g, '');
                }
                postdata[id] = value;
                break;
        }
    });
    if ($('[name=__RequestVerificationToken]').length > 0) {
        postdata["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
    }
    return postdata;
};
//验证表单
//callback 回调函数
$.fn.formValid = function (callback) {
    var data = $(this).data("bootstrapValidator");
    if (!!data) {
        data.validate();
        if (!data.isValid()) {
            return false;
        }
    }
    return true;
}

$.fn.dataGrid = function (options) {
    var defaults = {
        datatype: "json",
        autowidth: true,
        rownumbers: true,
        shrinkToFit: false,
        gridview: true
    };
    var options = $.extend(defaults, options);
    var $element = $(this);
    options["onSelectRow"] = function (rowid) {
        var length = $(this).jqGrid("getGridParam", "selrow").length;
        var $operate = $(".operate");
        if (length > 0) {
            $operate.animate({ "left": 0 }, 200);
        } else {
            $operate.animate({ "left": '-100.1%' }, 200);
        }
        $operate.find('.close').click(function () {
            $operate.animate({ "left": '-100.1%' }, 200);
        })
    };
    $element.jqGrid(options);
};

$.fn.jqGridRowValue = function () {
    var $grid = $(this);
    var selectedRowIds = $grid.jqGrid("getGridParam", "selarrrow");
    if (selectedRowIds != "") {
        var json = [];
        var len = selectedRowIds.length;
        for (var i = 0; i < len; i++) {
            var rowData = $grid.jqGrid('getRowData', selectedRowIds[i]);
            json.push(rowData);
        }
        return json;
    } else {
        return $grid.jqGrid('getRowData', $grid.jqGrid('getGridParam', 'selrow'));
    }
}

$.fn.bindSelect = function (options) {
    var defaults = {
        id: "id",
        text: "text",
        search: false,
        url: "",
        param: [],
        change: null
    };
    var options = $.extend(defaults, options);
    var $element = $(this);
    if (options.url != "") {
        $.ajax({
            url: options.url,
            data: options.param,
            dataType: "json",
            async: false,
            success: function (data) {
                $.each(data, function (i) {
                    $element.append($("<option></option>").val(data[i][options.id]).html(data[i][options.text]));
                });
            }
        });
    }
}

$.clientsInit = function () {
    var dataJson = {
        authorizeMenu: [],
        authorizeButton: []
    };
    var init = function () {
        $.ajax({
            url: "/ClientData/GetClientsDataJson",
            type: "get",
            dataType: "json",
            async: false,
            success: function (data) {
                dataJson.authorizeMenu = eval(data.authorizeMenu);
                dataJson.authorizeButton = data.authorizeButton;
            }
        });
    }
    init();
    return dataJson;
}

$.fn.authorizeButton = function () {
    var moduleId = top.$(".J_menuTab.active").attr("data-id");

    var dataJson = top.clients.authorizeButton[moduleId];
    var $element = $(this);
    $element.find('a[authorize=yes]').attr('authorize', 'no');

    console.info($element.find('a[authorize=yes]'));
    if (dataJson != undefined) {
        $.each(dataJson, function (i) {
            $element.find("." + dataJson[i].btnEncode).attr('authorize', 'yes');
        });
    }
    console.info(dataJson);
    $element.find("[authorize=no]").parents('li').prev('.split').remove();
    $element.find("[authorize=no]").parents('li').remove();
    $element.find('[authorize=no]').remove();
}