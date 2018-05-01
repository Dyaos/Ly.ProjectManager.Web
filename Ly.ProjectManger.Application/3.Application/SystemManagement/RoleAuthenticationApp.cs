using Ly.ProjectManager.Code;
using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.AccountRole;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.RoleAuth;
using Ly.ProjectManager.Repository._1.IRepository.SystemManagement;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application.SystemManagement
{
    public class RoleAuthenticationApp : IRoleAuthenticationApp
    {
        private IModuleApp moduleApp;
        private IModuleButtonApp buttonApp;
        private IRoleRepository roleRepository;
        private IRoleAuthenticationRepository roleAuthRepository;

        public RoleAuthenticationApp(IModuleApp moduleApp, IModuleButtonApp buttonApp, IRoleRepository roleRepository, IRoleAuthenticationRepository roleAuthRepository)
        {
            this.moduleApp = moduleApp;
            this.buttonApp = buttonApp;
            this.roleRepository = roleRepository;
            this.roleAuthRepository = roleAuthRepository;
        }
        public void DeleteForm(string keyValue)
        {
            roleAuthRepository.DeleteAsync(c => c.authRoleGuid == keyValue);
        }
        public async Task<int> DeleteFormAsync(string keyValue)
        {
            return await roleAuthRepository.DeleteAsync(c => c.authRoleGuid == keyValue);
        }

        public void SubmitForm(RoleAuthenticationEntity entity, string keyValue)
        {
            throw new NotImplementedException();
        }

        public Task<int> SubmitFormAsync(RoleAuthenticationEntity entity, string keyValue)
        {
            throw new NotImplementedException();
        }

        public IList<RoleAuthenticationEntity> FindList(Expression<Func<RoleAuthenticationEntity, bool>> predicate)
        {
            return roleAuthRepository.IQueryable(predicate).ToList();
        }


        /// <summary>
        /// 角色授权功能验证
        /// </summary>
        /// <param name="roleGuid">当前角色Huid</param>
        /// <param name="moduleGuid">当前模块Guid</param>
        /// <param name="action">操作方法</param>
        /// <returns>返回是否具有该操作方法的权限 </returns>
        public bool ActionValidate(string roleGuid, string moduleGuid, string action)
        {
            var authUrlData = new List<AuthorizeActionOutputDto>();//当前角色的功能
            var role = roleRepository.FindEntity(roleGuid);
            var cacheAuthUrlData = CacheFactory.Cache().GetCache<List<AuthorizeActionOutputDto>>("authurldata_" + role.roleGuid);//读取缓存
            if (cacheAuthUrlData == null)
            {
                var moduleData = moduleApp.FindList(c => c.isEnabled == true).ToList();
                var moduleBtnData = buttonApp.FindList(c => c.isEnabled == true).ToList();
                var roleAuthData = this.FindList(r => r.authRoleGuid == role.roleGuid).ToList();//查询当前角色的功能
                foreach (var item in roleAuthData)
                {
                    if (item.authModuleType == 1)
                    {
                        ModuleEntity sysModule = moduleData.Find(m => m.moduleGuid == item.authModuleGuid);
                        authUrlData.Add(new AuthorizeActionOutputDto() { moduleGuid = sysModule.moduleGuid, moduleUrlAddress = sysModule.moduleUri });
                    }
                    else if (item.authModuleType == 2)
                    {
                        ModuleButtonEntity moduleButton = moduleBtnData.Find(b => b.btnGuid == item.authModuleGuid);
                        authUrlData.Add(new AuthorizeActionOutputDto() { moduleGuid = moduleButton.btnGuid, moduleUrlAddress = moduleButton.btnUri });
                    }
                }
                CacheFactory.Cache().WriteCache(authUrlData, "authurldata_" + roleGuid, DateTime.Now.AddMinutes(5));//写入缓存
            }
            else
            {
                authUrlData = cacheAuthUrlData;
            }
            authUrlData = authUrlData.FindAll(m => m.moduleGuid.Equals(moduleGuid));
            foreach (var item in authUrlData)
            {
                if (!string.IsNullOrEmpty(item.moduleUrlAddress))
                {
                    string[] url = item.moduleUrlAddress.Split('?');
                    if (item.moduleGuid == moduleGuid && url[0] == action)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 获取当前用户的菜单权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<ModuleEntity> GetMenuList(string roleGuid)
        {
            var data = new List<ModuleEntity>();
            var role = roleRepository.FindEntity(roleGuid);
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                data = moduleApp.FindList(m => m.isEnabled == true).ToList();
            }
            else
            {
                var moduleData = moduleApp.FindList(m => m.isEnabled == true).ToList();
                var authData = this.FindList(r => r.authRoleGuid == role.roleGuid && r.authModuleType == 1).ToList();
                foreach (var item in authData)
                {
                    ModuleEntity moduleEntity = moduleData.Find(m => m.moduleGuid == item.authModuleGuid);
                    if (moduleEntity != null)
                    {
                        data.Add(moduleEntity);
                    }
                }
            }
            return data.OrderBy(m => m.sortCode).ToList(); ;
        }

        /// <summary>
        /// 获取认证按钮
        /// </summary>
        /// <param name="roleGuid"></param>
        /// <returns></returns>
        public List<ModuleButtonEntity> GetButtonList(string roleGuid)
        {
            var btnData = new List<ModuleButtonEntity>();
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                btnData = buttonApp.FindList(c => c.isEnabled == true).ToList();
            }
            else
            {
                var buttonData = buttonApp.FindList(c => c.isEnabled == true).ToList();
                var authButtonData = this.FindList(r => r.authRoleGuid == roleGuid && r.authModuleType == 2).ToList();
                foreach (var item in authButtonData)
                {
                    var entity = buttonData.Find(b => b.btnGuid == item.authModuleGuid);
                    if (entity != null)
                    {
                        btnData.Add(entity);
                    }
                }
            }
            return btnData;
        }

        public async Task<int> InsertAsync(IList<RoleAuthenticationEntity> entities)
        {
            return await roleAuthRepository.InsertAsync(entities.ToList());
        }

        public void SubmitForm(string permissionIds, string keyValue)
        {
            var moduleList = moduleApp.FindList(c => c.isEnabled == true).ToList();
            var moduleButtonList = buttonApp.FindList(c => c.isEnabled == true).ToList(); ;
            var roleAuthList = new List<RoleAuthenticationEntity>();
            string[] permissionArr = permissionIds.Split(',');

            foreach (var itemId in permissionArr)
            {
                var roleAuthEntity = new RoleAuthenticationEntity();
                roleAuthEntity.Create();
                roleAuthEntity.authRoleGuid = keyValue;
                roleAuthEntity.authModuleGuid = itemId;
                if (moduleList.Find(c => c.moduleGuid == itemId) != null)
                {
                    roleAuthEntity.authModuleType = 1;
                }
                else if (moduleButtonList.Find(m => m.btnGuid == itemId) != null)
                {
                    roleAuthEntity.authModuleType = 2;
                }
                roleAuthList.Add(roleAuthEntity);
            }
            roleAuthRepository.SubmitForm(roleAuthList, keyValue);
        }

        public IList<TreeOutputDto> GetTreeList(string roleGuid)
        {
            var moduleData = moduleApp.FindList(c => c.isEnabled == true).OrderBy(c => c.parentGuid).ToList();
            var btnData = buttonApp.FindList(c => c.isEnabled == true).ToList();
            var authData = new List<RoleAuthenticationEntity>();
            if (!string.IsNullOrEmpty(roleGuid))
            {
                authData = roleAuthRepository.IQueryable(c => c.authRoleGuid == roleGuid).ToList();
            }
            var treeList = new List<TreeOutputDto>();
            foreach (ModuleEntity item in moduleData)
            {
                var tree = new TreeOutputDto();
                bool hasChildren = moduleData.Count(m => m.moduleGuid == m.parentGuid) == 0 ? false : true;
                tree.id = item.moduleGuid;
                tree.text = item.moduleName;
                tree.value = string.Empty;
                tree.parentId = item.parentGuid;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = authData.Count(t => t.authModuleGuid == item.moduleGuid);
                tree.hasChildren = true;
                tree.img = item.moduleIcon == "" ? "" : item.moduleIcon;
                treeList.Add(tree);
            }
            foreach (ModuleButtonEntity item in btnData)
            {
                var tree = new TreeOutputDto();
                bool hasChildren = false;
                tree.id = item.btnGuid;
                tree.text = item.btnName;
                tree.value = item.btnEncode;
                tree.parentId = item.moduleInfoGuid;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = authData.Count(t => t.authModuleGuid == item.btnGuid);
                tree.hasChildren = hasChildren;
                tree.img = "";
                treeList.Add(tree);
            }

            return treeList;
        }
    }
}
