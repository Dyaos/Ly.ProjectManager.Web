using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.RoleAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._2.IApplication.SystemManagement
{
    public interface IRoleAuthenticationApp : IApplicationBase<RoleAuthenticationEntity>, ICommandOperationAsync<RoleAuthenticationEntity>
    {
        IList<RoleAuthenticationEntity> FindList(Expression<Func<RoleAuthenticationEntity, bool>> predicate);
        bool ActionValidate(string roleGuid, string moduleGuid, string action);
        /// <summary>
        /// 获取当前用户的菜单权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        List<ModuleEntity> GetMenuList(string roleGuid);

        List<ModuleButtonEntity> GetButtonList(string roleGuid);
        Task<int> InsertAsync(IList<RoleAuthenticationEntity> entities);

        void SubmitForm(string permissionIds, string keyValue);

        IList<TreeOutputDto> GetTreeList(string roleGuid);
    }
}
