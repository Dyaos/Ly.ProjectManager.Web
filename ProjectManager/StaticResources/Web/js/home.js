var clients = [];
$(function () {
    clients = $.clientsInit();
    GetLoadNav();
});


function GetLoadNav() {
    var data = top.clients.authorizeMenu;
    var _html = "";

    $.each(data, function (i) {
        var row = data[i];
        if (row.parentGuid == "0") {
            _html += '<li>';
            var childNodes = row.ChildNodes;
            if (childNodes.length == 0) {
                _html += '<a class="J_menuItem" href="' + row.moduleUri + '" data-id="' + row.moduleGuid + '"><i class="' + row.moduleIcon + '"></i><span>' + row.moduleName + '</span></a>';
            } else {
                _html += '<a data-id="' + row.moduleGuid + '" href="#" class="dropdown-toggle"><i class="' + row.moduleIcon + '"></i><span>' + row.moduleName + '</span> <span class="fa arrow"></span></a>';

                _html += '<ul class="nav nav-second-level">';
                $.each(childNodes, function (i) {
                    var subrow = childNodes[i];
                    _html += '<li>';
                    _html += '<a class="J_menuItem" data-id="' + subrow.moduleGuid + '" href="' + subrow.moduleUri + '"><i class="' + subrow.moduleIcon + '"></i><span>' + subrow.moduleName + '</span></a>';
                    _html += '</li>';
                });
                _html += '</ul>';
            }
            _html += '</li>';
        }
    });
    $("ul#side-menu").append(_html);
}