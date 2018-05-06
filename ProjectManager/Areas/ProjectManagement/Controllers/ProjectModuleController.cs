using Ly.ProjectManager.Code;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Web.Handler;
using Ly.ProjectManger.Application._2.IApplication.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Areas.ProjectManagement.Controllers
{
    /// <summary>
    /// 项目模块
    /// </summary>
    public class ProjectModuleController : ControllerBase
    {
        private IProjectModuleApp moduleApp;
        public ProjectModuleController(IProjectModuleApp moduleApp)
        {
            this.moduleApp = moduleApp;
        }
        [HttpGet]
        public ActionResult GetDataJson(string keyValue)
        {
            var data = new List<ProjectModuleEntity>();
            try
            {
                data = moduleApp.FindList(c => c.isEnabled && c.projectInfoGuid == keyValue).ToList();
                WirteOperationRecord("Project", "SELECT", "查询", "Info:获取所有项目模块信息(集合)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Project", "", "", "Info:" + ex.Message.ToString());
            }
            return Content(data.ToJson());
        }

        public ActionResult GetFormJson(string keyValue)
        {
            var entity = new ProjectModuleEntity();
            try
            {
                entity = moduleApp.FindList(c => c.projectModuleGuid == keyValue).FirstOrDefault();
                entity.chargePerson = entity.chargePersonInfoGuid + "&" + entity.chargePerson;
                WirteOperationRecord("ProjectModule", "SELECT", "查询", "Info:获取项目模块资料(单个)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("ProjectModule", "", "", "Info:" + ex.Message.ToString());
            }
            return Content(entity.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ProjectModuleEntity entity, string keyValue)
        {
            try
            {
                moduleApp.SubmitForm(entity, keyValue);
                if (string.IsNullOrEmpty(keyValue))
                {
                    WirteOperationRecord("ProjectModule", "INSERT", "增加", "Info:" + entity.ToJson());
                }
                else
                {
                    WirteOperationRecord("ProjectModule", "UPDATE", "修改", "Info:" + entity.ToJson());
                }
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("ProjectModule", "", "", "Info:" + ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Success("操作成功.");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            try
            {
                moduleApp.DeleteForm(keyValue);
                WirteOperationRecord("ProjectModule", "DELETE", "删除", "Info:" + keyValue);
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("ProjectModule", "", "", ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Success("删除成功.");
        }

        public ActionResult ModifyStatus()
        {
            return View();
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult ModifyStatus(string keyValue, string status, int? type = 1, int? work = 4)
        {
            try
            {
                var entity = new ProjectModuleEntity()
                {
                    projectModuleStatus = status
                };

                if (type == 2)
                {
                    entity.actualWorkHours = work.Value;
                    entity.actualStartTime = DateTime.Now;
                }

                entity.Modify(keyValue);
                moduleApp.SubmitForm(entity, keyValue);
                WirteOperationRecord("ProjectModule", "UPDATE", "更新", "Info:" + keyValue);
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("ProjectModule", "", "", ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Success("修改成功.");
        }
    }
}