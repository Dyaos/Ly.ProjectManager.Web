using Ly.ProjectManager.Code;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.Module;
using Ly.ProjectManager.Web.Handler;
using Ly.ProjectManger.Application._2.IApplication.AcademicManagement;
using Ly.ProjectManger.Application._2.IApplication.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Areas.ProjectManagement.Controllers
{
    /// <summary>
    /// 项目团队
    /// </summary>
    public class ProjectTeamController : ControllerBase
    {
        private IProjectTeamApp teamApp;
        private ITeamMembersApp teamMembersApp;
        public ProjectTeamController(IProjectTeamApp teamApp, ITeamMembersApp teamMembersApp)
        {
            this.teamApp = teamApp;
            this.teamMembersApp = teamMembersApp;
        }
        [HttpGet]
        public ActionResult GetDataJson(Pagination pagination)
        {
            var data = new List<ProjectTeamEntity>();
            try
            {
                data = teamApp.FindList(pagination).ToList();
                WirteOperationRecord("Team", "SELECT", "查询", "Info:获取项目团队资料(集合)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("ProjectTeam", "", "", "Info:" + ex.Message.ToString());
            }
            return Content(data.ToJson());
        }

        public ActionResult GetFormJson(string keyValue)
        {
            var entity = new ProjectTeamEntity();
            try
            {
                entity = teamApp.FindList(c => c.teamGuid == keyValue)[0];
                WirteOperationRecord("ProjectTeam", "SELECT", "查询", "Info:获取项目团队资料(单个)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("ProjectTeam", "", "", "Info:" + ex.Message.ToString());
            }
            return Content(entity.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ProjectTeamEntity entity, string keyValue)
        {
            try
            {
                teamApp.SubmitForm(entity, keyValue);
                if (string.IsNullOrEmpty(keyValue))
                {
                    WirteOperationRecord("ProjectTeam", "INSERT", "增加", "Info:" + entity.ToJson());
                }
                else
                {
                    WirteOperationRecord("ProjectTeam", "UPDATE", "修改", "Info:" + entity.ToJson());
                }
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("ProjectTeam", "", "", "Info:" + ex.Message.ToString());
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
                teamApp.DeleteForm(keyValue);
                WirteOperationRecord("ProjectTeam", "DELETE", "删除", "Info:" + keyValue);
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("ProjectTeam", "", "", ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Success("删除成功.");
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSelectJson()
        {
            var data = new List<ModuleSelectOutputDto>();

            try
            {
                var currentAccount = OperatorProvider.Provider.GetCurrent();
                var membersList = teamMembersApp.FindList(c => c.isEnabled && c.accountInfoGuid == currentAccount.UserId);
                var teamList = teamApp.FindList(c => c.isEnabled);
                if (currentAccount.RoleLv <= 3)
                {
                    data = teamList.Select(c => new ModuleSelectOutputDto() { id = c.teamGuid, text = c.teamName }).ToList();
                }
                else
                {
                    foreach (var item in membersList)
                    {
                        var entity = teamList.Where(c => c.teamGuid == item.teamInfoGuid).Select(c => new ModuleSelectOutputDto() { id = c.teamGuid, text = c.teamName }).FirstOrDefault();
                        if (entity != null)
                        {
                            data.Add(entity);
                        }
                    }
                }
                WirteOperationRecord("Team", "SELECT", "查询", "Info:查询当前用户所在团队集合");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Account", "", "", ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Content(data.ToJson());
        }
    }
}