using Ly.ProjectManager.Code;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Controllers
{
    public class ClientDataController : Controller
    {
        private IRoleAuthenticationApp roleAuthApp;

        public ClientDataController(IRoleAuthenticationApp roleAuthApp)
        {
            this.roleAuthApp = roleAuthApp;
        }

        [HttpGet]
        // GET: /ClientData/
        public ActionResult GetClientsDataJson()
        {
            var data = new
            {
                authorizeMenu = GetMenuList(),
                authorizeButton = GetButtonList()
            };
            return Content(data.ToJson());
        }

        private object GetButtonList()
        {
            var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            var data = roleAuthApp.GetButtonList(roleId);
            var dataModuleId = data.Distinct(new ExtList<ModuleButtonEntity>("moduleInfoGuid"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (ModuleButtonEntity item in dataModuleId)
            {
                var buttonList = data.Where(t => t.moduleInfoGuid.Equals(item.moduleInfoGuid));
                dictionary.Add(item.moduleInfoGuid, buttonList);
            }
            return dictionary;
        }

        private object GetMenuList()
        {
            var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            return ToMenuJson(roleAuthApp.GetMenuList(roleId), "0");
        }


        private string ToMenuJson(List<ModuleEntity> data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<ModuleEntity> entitys = data.FindAll(t => t.parentGuid == parentId);
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = item.ToJson();
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.moduleGuid) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }

    }
}