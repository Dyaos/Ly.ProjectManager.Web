using Ly.ProjectManager.Code;
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
    public interface IRoleApp : IApplicationBase<RoleEntity>, ICommandOperationAsync<RoleEntity>
    {
        RoleEntity FindEntity(string keyValue);

        RoleEntity FindEntity(Expression<Func<RoleEntity, bool>> predicate);

        IList<RoleEntity> FindList(Expression<Func<RoleEntity, bool>> predicate, Pagination pagination);

        Task<int> SubmitFormAsync(RoleEntity entity, string permissionIds, string keyValue);

        List<TreeOutputDto> GetRoleList(string keyValue);
    }
}
