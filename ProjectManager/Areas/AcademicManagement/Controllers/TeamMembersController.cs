using Ly.ProjectManager.Code;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.Module;
using Ly.ProjectManager.Web.Handler;
using Ly.ProjectManger.Application._2.IApplication.AcademicManagement;
using Ly.ProjectManger.Application._2.IApplication.UserManagerment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Areas.AcademicManagement.Controllers
{
    /// <summary>
    /// 团队成员
    /// </summary>
    public class TeamMembersController : ControllerBase
    {
        private ITeamMembersApp teamMembersApp;
        private IAccountApp accountApp;
        public TeamMembersController(ITeamMembersApp teamMembersApp, IAccountApp accountApp)
        {
            this.teamMembersApp = teamMembersApp;
            this.accountApp = accountApp;
        }

        [HttpGet]
        public ActionResult GetDataJson(string keyValue)
        {
            var data = new List<TeamMembersEntity>();
            try
            {
                data = teamMembersApp.FindList(c => c.isEnabled && c.teamInfoGuid == keyValue).ToList();
                WirteOperationRecord("TeamMembers", "SELECT", "查询", "Info:获取项目团队成员资料(集合)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("TeamMembers", "", "", "Info:" + ex.Message.ToString());
            }
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(TeamMembersEntity entity, string keyValue)
        {
            try
            {
                teamMembersApp.SubmitForm(entity, keyValue);
                if (string.IsNullOrEmpty(keyValue))
                {
                    WirteOperationRecord("TeamMembers", "INSERT", "增加", "Info:" + entity.ToJson());
                }
                else
                {
                    WirteOperationRecord("TeamMembers", "UPDATE", "修改", "Info:" + entity.ToJson());
                }
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("TeamMembers", "", "", "Info:" + ex.Message.ToString());
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
                teamMembersApp.DeleteForm(keyValue);
                WirteOperationRecord("TeamMembers", "DELETE", "删除", "Info:" + keyValue);
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("TeamMembers", "", "", ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Success("删除成功.");
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSelectJson(string keyValue)
        {
            var accountList = accountApp.FindList(c => c.isEnabled && c.accountType == 3);

            try
            {
                var members = teamMembersApp.FindList(c => c.isEnabled && c.teamInfoGuid == keyValue);
                foreach (var item in members)
                {
                    accountList.Remove(accountList.Where(c => c.accountGuid == item.accountInfoGuid).FirstOrDefault());
                }
                WirteOperationRecord("Account", "SELECT", "查询", "Info:查询所有学生信息");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Account", "", "", ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Content(accountList.Select(c => new ModuleSelectOutputDto { text = c.accountName, id = c.accountGuid + "&" + c.accountName }).ToJson());
        }


        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSelectChargeJson(string keyValue)
        {
            var members = new List<TeamMembersEntity>();

            try
            {
                members = teamMembersApp.FindList(c => c.isEnabled && c.teamInfoGuid == keyValue).ToList();
                WirteOperationRecord("TeamMembers", "SELECT", "查询", "Info:查询所有团队成员信息");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("TeamMembers", "", "", ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Content(members.Select(c => new ModuleSelectOutputDto { text = c.membersName, id = c.accountInfoGuid + "&" + c.membersName }).ToJson());
        }
    }
}