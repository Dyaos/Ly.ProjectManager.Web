using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.RoleAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._2.IApplication.SystemManagement
{
    public interface IAccountRoleApp : IApplicationBase<AccountRoleEntity>
    {
        void ModifyRole(string roleList, string keyValue);

        IList<AccountRoleEntity> FindList(string keyValue);

        void SubmitForm(string roleList, string keyValue);
    }
}
