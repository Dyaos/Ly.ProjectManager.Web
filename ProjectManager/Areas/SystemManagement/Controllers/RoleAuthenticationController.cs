using Ly.ProjectManager.Code;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Areas.SystemManagement.Controllers
{
    /// <summary>
    /// 角色验证
    /// </summary>
    public class RoleAuthenticationController : ControllerBase
    {
        private IRoleAuthenticationApp roleAuthApp;

        public RoleAuthenticationController(IRoleAuthenticationApp roleAuthApp)
        {
            this.roleAuthApp = roleAuthApp;
        }

        [HttpGet]
        public ActionResult GetPermissionTree(string roleId)
        {
            try
            {
                var data = roleAuthApp.GetTreeList(roleId).ToList();
                WirteOperationRecord("RoleAuthentication", "SELECT", "查询", "Info:获取角色(集合)");
                return Content(data.TreeViewJson());
            }
            catch (Exception ex)
            {
                log.logLevel = "ERROR";
                log.logType = "ERROR";
                WirteOperationRecord("RoleAuthentication", "", "", "Info:" + ex.Message.ToString());
                return Error(ex.Message);
            }
        }
    }
}