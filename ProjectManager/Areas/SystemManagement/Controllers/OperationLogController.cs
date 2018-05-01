using Ly.ProjectManager.Code;
using Ly.ProjectManager.Web.Handler;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Areas.SystemManagement.Controllers
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class OperationLogController : ControllerBase
    {
        private IOperationLogApp operationLogApp;
        public OperationLogController(IOperationLogApp operationLogApp)
        {
            this.operationLogApp = operationLogApp;
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = operationLogApp.FindList(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var entity = operationLogApp.FindEntity(keyValue);
            return Content(entity.ToJson());
        }
    }
}