using Ly.ProjectManager.Code;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.Module;
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
    /// 菜单模块
    /// </summary>
    public class ModuleController : ControllerBase
    {
        private IModuleApp moduleApp;
        public ModuleController(IModuleApp moduleApp)
        {
            this.moduleApp = moduleApp;
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string keyword)
        {
            var treeList = new List<TreeGridModel>();
            try
            {
                var data = moduleApp.FindList(c => c.isEnabled == true).OrderBy(m => m.sortCode).ToList();
                if (!string.IsNullOrEmpty(keyword))
                {
                    data = data.TreeWhere(t => t.moduleName.Contains(keyword), "moduleGuid", "parentGuid");
                }
                foreach (ModuleEntity item in data)
                {
                    TreeGridModel treeModel = new TreeGridModel();
                    bool hasChildren = data.Count(t => t.parentGuid == item.moduleGuid) == 0 ? false : true;
                    treeModel.id = item.moduleGuid;
                    treeModel.isLeaf = hasChildren;
                    treeModel.parentId = item.parentGuid;
                    treeModel.expanded = hasChildren;
                    treeModel.entityJson = item.ToJson();
                    treeList.Add(treeModel);
                }
                WirteOperationRecord("Module", "SELECT", "查询", "Info:获取菜单数据(集合)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Module", "", "", "Info:" + ex.Message.ToString());
            }
            return Content(treeList.TreeGridJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSelectJson(string keyValue, int type = 1)
        {
            var data = new List<ModuleSelectOutputDto>();
            try
            {
                if (type == 1)
                {
                    data = moduleApp.FindList(c => c.moduleGuid != keyValue && c.isMenu == false && c.moduleLv != "2").Select(c => new ModuleSelectOutputDto { id = c.moduleGuid, text = c.moduleName }).ToList();
                }
                else
                {
                    data = moduleApp.FindList(c => c.moduleGuid != keyValue && c.isMenu == true && c.moduleLv != "1").Select(c => new ModuleSelectOutputDto { id = c.moduleGuid, text = c.moduleName }).ToList();
                }
                WirteOperationRecord("Module", "SELECT", "查询", "Info:获取父级菜单数据(集合)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Module", "", "", "Info:" + ex.Message.ToString());
            }
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = new ModuleEntity();
            try
            {
                data = moduleApp.FindEntity(keyValue);
                WirteOperationRecord("Module", "SELECT", "查询", "Info:获取菜单数据(单个)");
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Module", "", "", ex.Message.ToString());
            }
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitForm(ModuleEntity entity, string keyValue)
        {
            try
            {
                await moduleApp.SubmitFormAsync(entity, keyValue);
                if (string.IsNullOrEmpty(keyValue))
                {
                    WirteOperationRecord("Module", "INSERT", "增加", "Info:" + entity.ToJson());
                }
                else
                {
                    WirteOperationRecord("Module", "UPDATE", "修改", "Info:" + entity.ToJson());
                }
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Module", "", "", "Info:" + ex.Message.ToString());
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
                await moduleApp.DeleteFormAsync(keyValue);
                WirteOperationRecord("Module", "DELETE", "删除", "Info:" + keyValue);
            }
            catch (Exception ex)
            {
                log.logType = "ERROR";
                log.logLevel = "ERROR";
                WirteOperationRecord("Module", "", "", ex.Message.ToString());
                return Error(ex.Message.ToString());
            }
            return Success("删除成功.");
        }


    }
}