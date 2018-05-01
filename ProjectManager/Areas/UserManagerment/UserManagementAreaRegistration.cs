﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Areas.UserManagement
{
    public class UserManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName => "UserManagerment";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
            this.AreaName + "_Default",
            this.AreaName + "/{controller}/{action}/{id}",
            new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
            new string[] { "Ly.ProjectManager.Web.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}