$(function () {
    //初始化表单验证
    bindBootstrapValidator();
    //验证码
    $(".reload-vify").click(function () {
        $(".reload-vify").find("img").attr("src", "/Login/VerificationCode?time=" + Math.random());
    });

    //登陆
    $("#btn-login").click(function () {
        if ($(".login-form").formValid()) {
            alert(111);
        }
    });
});

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
        $(this).attr("data-bv-notempty-message", msg+"是必填项,不能为空");
    });
}