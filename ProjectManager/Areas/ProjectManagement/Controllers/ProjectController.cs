using Ly.ProjectManager.Code;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.Project;
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
    /// 项目
    /// </summary>
    public class ProjectController : ControllerBase
    {
        private IProjectApp projectApp;
        public ProjectController(IProjectApp projectApp)
        {
            this.projectApp = projectApp;
        }
        [HttpGet]
        public ActionResult GetDataJson(string keyValue)
        {
            var data = new List<ProjectInfoOutputDto>();
            try
            {
                data = projectApp.FindList(OperatorProvider.Provider.GetCurrent().UserId).Where(c => string.IsNullOrEmpty(keyValue) || c.projectGuid == keyValue).ToList();

                WirteOperationRecord("Project", "SELECT", "查询", "Info:获取所有项目信息(集合)");
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
            var entity = new ProjectEntity();
            try
            {
                entity = projectApp.FindList(c => c.projectGuid == keyValue).FirstOrDefault();
                WirteOperationRecord("Project", "SELECT", "查询", "Info:获取项目资料(单个)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Project", "", "", "Info:" + ex.Message.ToString());
            }
            return Content(entity.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ProjectEntity entity, string keyValue)
        {
            try
            {
                projectApp.SubmitForm(entity, keyValue);
                if (string.IsNullOrEmpty(keyValue))
                {
                    WirteOperationRecord("Project", "INSERT", "增加", "Info:" + entity.ToJson());
                }
                else
                {
                    WirteOperationRecord("Project", "UPDATE", "修改", "Info:" + entity.ToJson());
                }
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Project", "", "", "Info:" + ex.Message.ToString());
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
                projectApp.DeleteForm(keyValue);
                WirteOperationRecord("Project", "DELETE", "删除", "Info:" + keyValue);
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Project", "", "", ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Success("删除成功.");
        }
    }
}