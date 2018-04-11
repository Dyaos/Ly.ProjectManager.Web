$(function () {
    $("#identity").selectpicker({});
    $(".reload-vify").click(function () {

        $(".reload-vify").find("img").attr("src", "/Home/VerificationCode?time=" + Math.random());
    });
});