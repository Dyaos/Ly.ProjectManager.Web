using Ly.ProjectManage.Code.Security;
using Ly.ProjectManager.Code;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.CustomerException;
using Ly.ProjectManager.Infrastructure.Dtos.InputDto.Login;
using Ly.ProjectManager.Infrastructure.Enum;
using Ly.ProjectManager.Web.Handler;
using Ly.ProjectManger.Application._2.IApplication;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using Ly.ProjectManger.Application._2.IApplication.UserManagerment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Controllers
{
    public class LoginController : AsyncController
    {
        private IAccountApp accountApp;
        private IOperationLogApp logApp;
        private static OperationLogEntity log;
        public LoginController(IAccountApp accountApp, IOperationLogApp logApp)
        {
            this.accountApp = accountApp;
            this.logApp = logApp;

        }
        static LoginController()
        {
            log = new OperationLogEntity()
            {
                operationIP = Net.Ip,
                logType = "Login",
                operationTable = "Account",
                operationModuleGuid = "0",
                operationType = "0",
                operationDesc = "0",
                logLevel = "INFO",
                logThread = Thread.CurrentThread.ToString(),
                logName = "LoginController"
            };
        }


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult VerificationCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public async Task<ActionResult> CheckLogin(LoginInputDto loginInput)
        {
            log.operationType = "SELECT";
            log.operationDesc = "查询";
            var ajaxObj = new AjaxResult();
            try
            {

                var entity = await accountApp.CheckLoginAsync(loginInput);
                entity.LoginIPAddress = Net.Ip;
                entity.LoginIPAddressName = Net.GetLocation(entity.LoginIPAddress);
                entity.LoginTime = DateTime.Now;
                entity.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                OperatorProvider.Provider.AddCurrent(entity);
                log.logDetails = "登录成功";
                log.creatorUserId = entity.UserId;
                ajaxObj.state = ResultType.success.ToString();
            }
            catch (ProgramLogicException ex)
            {
                ajaxObj.state = ResultType.error.ToString();
                ajaxObj.message = (new { message = ex.Message.ToString(), errorCode = LoginResultType.loginFail }).ToJson();
                log.creatorUserId = "游客";
                log.logDetails = ex.Message.ToString();
                LogFactory.GetLogger(typeof(LoginController)).Info(log);
            }
            catch (Exception ex)
            {
                ajaxObj.state = ResultType.error.ToString();
                ajaxObj.message = (new { message = ex.Message.ToString(), errorCode = LoginResultType.loginFail }).ToJson();
                log.logDetails = ex.Message.ToString();
                log.logType = "ERROR";
                log.logLevel = "ERROR";
            }
            finally
            {
                log.Create();
                await logApp.SubmitFormAsync(log, "");
            }
            return Content(ajaxObj.ToJson());
        }

        public ActionResult OutLogin()
        {
            log.logDetails = "安全退出系统";
            log.creatorUserId = OperatorProvider.Provider.GetCurrent().UserId;
            log.operationType = "EXIT";
            log.operationDesc = "退出";
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }
    }
}