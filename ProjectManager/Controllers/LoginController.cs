using Ly.ProjectManager.Code;
using Ly.ProjectManger.Application._2.IApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Controllers
{
    public class LoginController : Controller
    {
        private IAccountApp AccountApp;
        public LoginController(IAccountApp AccountApp)
        {
            this.AccountApp = AccountApp;
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
    }
}