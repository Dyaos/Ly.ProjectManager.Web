(function ($) {

    function bindBootstrapValidator() {
        bindBootstrapValidatorAttribute($("form.validate-form"));
        $.each($("form.validate-form"), function () {
            $(this).bootstrapValidator({
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                }
            });
            $(this).on("success.form.bv", function (e) {
                // 禁止提交默认事件
                e.preventDefault();
            });
        });
    }
    //绑定验证属性 message
    function bindBootstrapValidatorAttribute($form) {
        $form.find("input[required]").each(function () {
            var msg = $(this).parents(".form-group").find("label[for]").html();
            $(this).attr("data-bv-notempty-message", msg + "是必填项,不能为空");
        });
    }

    $.login = {
        init: function () {
            bindBootstrapValidator();
            //验证码
            $(".reload-vify").click(function () {
                $(".reload-vify").find("img").attr("src", "/Login/VerificationCode?time=" + Math.random());
            });

            //登陆
            $("#btn-login").click(function () {
                if ($(".login-form").formValid()) {
                    if (!$("#validCode").val()) {
                        $.login.formMessage("请输入验证码");
                        return;
                    }
                    $("#btn-login").attr('disabled', 'disabled').html("登录中.....");
                    $.login.checkLogin();
                }
            });

            var login_error = top.$.cookie('ly_login_error');
            if (login_error != null) {
                switch (login_error) {
                    case "overdue":
                        $.login.formMessage("系统登录已超时,请重新登录");
                        break;
                    case "OnLine":
                        $.login.formMessage("您的帐号已在其它地方登录,请重新登录");
                        break;
                    case "-1":
                        $.login.formMessage("系统未知错误,请重新登录");
                        break;
                }
            }
            top.$.cookie('ly_login_error', '', { path: "/", expires: -1 });

            document.onkeydown = function (e) {
                if (!e) e = window.event;
                if ((e.keyCode || e.which) == 13) {
                    document.getElementById("btn-login").focus();
                    document.getElementById("btn-login").click();
                }
            }
        },
        checkLogin: function () {
            var param = $(".login-form").formSerialize();
            param.cardPwd = $.md5(param.cardPwd);
            $.ajax({
                url: '/Login/CheckLogin',
                dataType: "json",
                contentType: "application/json",
                type: "post",
                async: true,
                data: JSON.stringify(param),
                success: function (data) {
                    if (data.state == "error") {
                        $("#btn-login").removeAttr('disabled').html("登录");
                        $(".reload-vify").trigger("click");
                        $("#validCode").val("");
                        $.login.formMessage(JSON.parse(JSON.parse(data.message).message).message);
                    } else {
                        $.login.formMessage();
                        $("#btn-login").html("登录成功，正在跳转...");
                        window.setTimeout(function () {
                            window.location.href = "/Home/Index";
                        }, 500);
                    }
                }
            });
        },
        formMessage: function (msg) {
            if (!!msg) {
                $(".login-tips").show().html(msg);
            } else {
                $(".login-tips").hide();
            }
        }
    };

    $(function () {
        $.login.init();
    });
})(jQuery)