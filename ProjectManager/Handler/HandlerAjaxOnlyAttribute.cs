using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Handler
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HandlerAjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public bool Ignore { get; set; }
        public HandlerAjaxOnlyAttribute(bool ignore = false)
        {
            Ignore = ignore;
        }
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            if (Ignore)
                return true;
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}