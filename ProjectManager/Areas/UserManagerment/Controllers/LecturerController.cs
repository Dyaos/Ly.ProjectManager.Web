using Ly.ProjectManage.Code.Security;
using Ly.ProjectManager.Code;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.RoleAuth;
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
        public ActionResult GetDataJson(Pagination pagination)
        {
            var data = new List<AccountEntity>();
            try
            {
                data = accountApp.FindList(pagination).ToList();
                WirteOperationRecord("Account", "SELECT", "查询", "Info:获取讲师资料(集合)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Account", "", "", "Info:" + ex.Message.ToString());
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
                    //插入用户角色
                    string roleName = "学生";
                    if (entity.accountType == 1)
                    {
                        roleName = "管理员";
                    }
                    else if (entity.accountType == 2)
                    {
                        roleName = "讲师";
                    }
                    var roleEntity = roleApp.FindEntity(c => c.roleName.Contains(roleName));

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


        public ActionResult ModfiyPwd()
        {
            return View();
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult ModfiyPwd(string oldPwd, string newPwd, string keyValue)
        {
            try
            {
                oldPwd = DESEncrypt.Encrypt(Md5.md5(oldPwd, 32)).ToUpper();
                var entity = accountApp.FindList(c => c.isEnabled == true && c.accountPwd == oldPwd && c.accountGuid == keyValue);
                if (entity == null || entity.Count == 0)
                    new Exception("请输入正确的密码");
                entity[0].accountPwd = DESEncrypt.Encrypt(Md5.md5(newPwd, 32)).ToUpper();
                accountApp.SubmitForm(entity[0], keyValue);

                WirteOperationRecord("Account", "UPDATE", "修改", "Info:修改用户密码");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Account", "", "", "Info:" + ex.Message.ToString());
                return Error("修改失败");
            }
            return Success("修改成功");
        }

        public ActionResult ModfiyRole()
        {
            return View();
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult ModfiyRole(string roleList, string keyValue)
        {
            try
            {
                accountRoleApp.SubmitForm(roleList, keyValue);
                WirteOperationRecord("Role", "UPDATE", "修改", "Info:修改用户角色");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Role", "", "", "Info:" + ex.Message.ToString());
                return Error("修改角色失败");
            }
            return Success("修改角色成功");
        }

        [HttpGet]
        public ActionResult GetRoleList(string keyValue)
        {
            var entity = new List<TreeOutputDto>();
            try
            {
                entity = roleApp.GetRoleList(keyValue);
                WirteOperationRecord("Role", "SELECT", "查询", "Info:获取角色集合(单个)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Role", "", "", "Info:" + ex.Message.ToString());
            }
            return Content(entity.TreeViewJson());
        }
    }
}