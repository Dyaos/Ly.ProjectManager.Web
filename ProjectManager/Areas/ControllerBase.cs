using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Areas
{
    public class ControllerBase : Controller
    {
        // GET: ControllerBase
        public ActionResult Index()
        {
            return View();
        }
    }
}