using Ly.ProjectManager.Code;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Web.Handler;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using Ly.ProjectManger.Application._2.IApplication.UserManagerment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Areas.UserManagerment.Controllers
{
    /// <summary>
    /// 讲师
    /// </summary>
    public class LecturerController : ControllerBase
    {
        private IAccountApp accountApp;
        private IClassTeacherApp classTeacherApp;
        private IAccountRoleApp accountRoleApp;
        private IRoleApp roleApp;

        private LecturerController(IAccountApp accountApp, IClassTeacherApp classTeacherApp, IAccountRoleApp accountRoleApp, IRoleApp roleApp)
        {
            this.accountApp = accountApp;
            this.classTeacherApp = classTeacherApp;
            this.accountRoleApp = accountRoleApp;
            this.roleApp = roleApp;
        }

        [HttpGet]
        public ActionResult GetDataJson()
        {
            var data = new List<AccountEntity>();
            var lecturerData = new List<ClassTeacherEntity>();
            try
            {
                lecturerData = classTeacherApp.FindList(c => c.teacherType == 1).ToList();
                data = accountApp.FindList(c => c.accountType == 2).ToList();
                data = (from l in lecturerData join a in data on l.accountInfoGuid equals a.accountGuid select a).ToList();
                WirteOperationRecord("Account", "SELECT", "查询", "Info:获取讲师资料(集合)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Module", "", "", "Info:" + ex.Message.ToString());
            }
            return Content(data.ToJson());
        }

        public ActionResult GetFormJson(string keyValue)
        {
            var entity = new AccountEntity();
            try
            {
                entity = accountApp.FindList(c => c.accountGuid == keyValue)[0];
                WirteOperationRecord("Account", "SELECT", "查询", "Info:获取讲师资料(单个)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Account", "", "", "Info:" + ex.Message.ToString());
            }
            return Content(entity.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(AccountEntity entity, string keyValue)
        {
            try
            {
                accountApp.SubmitForm(entity, keyValue);

                if (string.IsNullOrEmpty(keyValue))
                {
                    //插入班级讲师
                    var classTeacherEntity = new ClassTeacherEntity()
                    {
                        accountInfoGuid = entity.accountGuid,
                        teacherType = 1
                    };

                    classTeacherApp.SubmitForm(classTeacherEntity, "");

                    //插入用户角色
                    var roleEntity = roleApp.FindEntity(c => c.roleName.Contains("讲师"));
                    var accountRole = new AccountRoleEntity()
                    {
                        roleInfoGuid = roleEntity.roleGuid,
                        accountInfoGuid = entity.accountGuid
                    };
                    accountRoleApp.SubmitForm(accountRole, "");
                }

                if (string.IsNullOrEmpty(keyValue))
                {
                    WirteOperationRecord("Account", "INSERT", "增加", "Info:" + entity.ToJson());
                }
                else
                {
                    WirteOperationRecord("Account", "UPDATE", "修改", "Info:" + entity.ToJson());
                }
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Account", "", "", "Info:" + ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Success("操作成功.");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteForm(string keyValue)
        {
            try
            {
                await accountApp.DeleteFormAsync(keyValue);
                WirteOperationRecord("Account", "DELETE", "删除", "Info:" + keyValue);
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Account", "", "", ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Success("删除成功.");
        }
    }
}