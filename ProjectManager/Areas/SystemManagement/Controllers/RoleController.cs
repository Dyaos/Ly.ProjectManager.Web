using Ly.ProjectManager.Code;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Web.Handler;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Areas.SystemManagement.Controllers
{
    /// <summary>
    /// 角色
    /// </summary>
    public class RoleController : ControllerBase
    {
        private IRoleApp roleApp;

        public RoleController(IRoleApp roleApp)
        {
            this.roleApp = roleApp;
        }


        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetDataJson(Pagination pagination)
        {
            try
            {
                var data = new
                {
                    rows = roleApp.FindList(c => c.isDel == false && c.isEnabled == true, pagination),
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records
                };
                WirteOperationRecord("Role", "SELECT", "查询", "Info:获取角色(集合)");
                return Content(data.ToJson());
            }
            catch (Exception ex)
            {
                log.logLevel = "ERROR";
                log.logType = "ERROR";
                WirteOperationRecord("Role", "", "", "Info:" + ex.Message.ToString());
                return Error(ex.Message);
            }
        }


        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        { 
            try
            {
                var data = roleApp.FindEntity(keyValue);
                WirteOperationRecord("Role", "SELECT", "查询", "Info:获取角色(单个)");
                return Content(data.ToJson());
            }
            catch (Exception ex)
            {
                log.logLevel = "ERROR";
                log.logType = "ERROR";
                WirteOperationRecord("Role", "", "", "Info:" + "Info:" + ex.Message.ToString());
                return Error(ex.Message);
            }
        }


        [HandlerAjaxOnly]
        public async Task<ActionResult> SubmitForm(RoleEntity entity, string permissionIds, string keyValue)
        {
            try
            {
                await roleApp.SubmitFormAsync(entity, permissionIds, keyValue);
                if (string.IsNullOrEmpty(keyValue))
                {
                    WirteOperationRecord("Role", "INSERT", "增加", "Info:" + entity.ToJson());
                }
                else
                {
                    WirteOperationRecord("Role", "UPDATE", "修改", "Info:" + entity.ToJson());
                }
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Role", "", "", "Info:" + ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Success("操作成功.");
        }

        public async Task<ActionResult> DeleteForm(string keyValue)
        {
            try
            {
                await roleApp.DeleteFormAsync(keyValue);
                WirteOperationRecord("Module", "DELETE", "删除", "Info:" + keyValue);
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Role", "", "", ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Success("删除成功.");
        }
    }
}