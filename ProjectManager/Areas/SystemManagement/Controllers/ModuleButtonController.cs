using Ly.ProjectManager.Code;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Web.Handler;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ly.ProjectManager.Web.Areas.SystemManagement.Controllers
{
    /// <summary>
    /// 模块按钮
    /// </summary>
    public class ModuleButtonController : ControllerBase
    {
        private IModuleButtonApp btnApp;
        private IModuleApp moduleApp;
        public ModuleButtonController(IModuleButtonApp btnApp, IModuleApp moduleApp)
        {
            this.btnApp = btnApp;
            this.moduleApp = moduleApp;
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitForm(ModuleButtonEntity entity, string keyValue)
        {
            try
            {
                await btnApp.SubmitFormAsync(entity, keyValue);
                if (string.IsNullOrEmpty(keyValue))
                {
                    WirteOperationRecord("ModuleButton", "INSERT", "增加", "Info:" + entity.ToJson());
                }
                else
                {
                    WirteOperationRecord("ModuleButton", "UPDATE", "修改", "Info:" + entity.ToJson());
                }
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("ModuleButton", "", "", "Info:" + ex.Message.ToString());
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
                await btnApp.DeleteFormAsync(keyValue);
                WirteOperationRecord("ModuleButton", "DELETE", "删除", "Info:" + keyValue);
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("ModuleButton", "", "", ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Success("删除成功.");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = new ModuleButtonEntity();
            try
            {
                data = (btnApp.FindList(c => c.btnGuid == keyValue))[0];
                WirteOperationRecord("ModuleButton", "SELECT", "查询", "Info:获取菜单数据(单个)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("ModuleButton", "", "", ex.Message.ToString());
            }
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string keyword)
        {
            var treeList = new List<TreeGridModel>();
            try
            {
                var data = btnApp.FindList(c => c.isEnabled == true).OrderBy(m => m.btnIdentity).ToList();
                var moduleData = moduleApp.FindList(c => c.isEnabled == true && c.moduleLv != "1").ToList();
                foreach (var item in moduleData)
                {
                    var entity = new ModuleButtonEntity();
                    entity.btnGuid = item.moduleGuid;
                    entity.btnName = item.moduleName;
                    entity.moduleInfoGuid = "0";
                    entity.sortCode = 1;
                    entity.remarks = item.remarks;
                    data.Add(entity);
                }

                foreach (var item in data)
                {
                    TreeGridModel treeModel = new TreeGridModel();
                    bool hasChildren = data.Count(m => m.moduleInfoGuid == item.btnGuid) > 0;
                    treeModel.id = item.btnGuid;
                    treeModel.isLeaf = hasChildren;
                    treeModel.parentId = item.moduleInfoGuid;
                    treeModel.expanded = hasChildren;
                    treeModel.entityJson = item.ToJson();
                    treeList.Add(treeModel);
                }
                WirteOperationRecord("ModuleButton", "SELECT", "查询", "Info:获取菜单数据(集合)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Module", "", "", "Info:" + ex.Message.ToString());
            }
            return Content(treeList.TreeGridJson());
        }
    }
}