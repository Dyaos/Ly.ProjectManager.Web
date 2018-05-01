using Ly.ProjectManager.Code;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Areas
{
    public class ControllerBase : Controller
    {
        public OperationLogEntity log;
        public ControllerBase()
        {
            log = new OperationLogEntity()
            {
                operationIP = Net.Ip,
                logThread = Thread.CurrentThread.ToString()
            };
        }
        // GET: ControllerBase
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        protected void WirteOperationRecord(string tableName, string type, string desc, string details)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            log.Create();
            log.logType = "GUID";
            log.operationType = type.ToString();
            log.operationTable = tableName;
            log.operationDesc = desc;
            log.logDetails = details;
            log.operationModuleGuid = "0";
            log.logLevel = "INFO";
            (ctx.GetObject("OperationLogApp") as IOperationLogApp).SubmitFormAsync(log, "");
        }

        /// <summary>
        /// 返回成功信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message)
        {
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = message }.ToJson());
        }
        /// <summary>
        /// 返回成功信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message, object data)
        {
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = message, data = data }.ToJson());
        }
        /// <summary>
        /// 返回错误信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual ActionResult Error(string message)
        {
            return Content(new AjaxResult { state = ResultType.error.ToString(), message = message }.ToJson());
        }
    }
}