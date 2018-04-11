$(function () {
    $("#btnToast").click(function () {
        $.modalOpen({
            id: "Form",
            title: "新增岗位",
            url: "//fly.layui.com/",
            width: "893px",
            height: "600px",
            fix:true,
            maxmin: true,
            callBack: function (iframeId) {
                
            }
        });
       // $.deleteForm();
        //$.modalAlert("确认要删除吗？","success");
    });
});