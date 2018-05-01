using Ly.ProjectManager.Code;
using Ly.ProjectManager.Data.DBContext;
using Ly.ProjectManager.Web.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Controllers
{
    [HandlerLogin]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (OperatorProvider.Provider.GetCurrent()!=null)
            {
                @ViewBag.UserName = OperatorProvider.Provider.GetCurrent().UserName;
                @ViewBag.RoleName = OperatorProvider.Provider.GetCurrent().RoleName;
            }
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
    }
}
