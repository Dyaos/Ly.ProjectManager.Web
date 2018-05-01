using Ly.ProjectManager.Data.Repository;
using Ly.ProjectManager.Domain._2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Repository._1.IRepository.SystemManagement
{
    public interface IRoleAuthenticationRepository : IRepositoryBase<RoleAuthenticationEntity>
    {
        Task<int> SubmitFormAsync(List<RoleAuthenticationEntity> entities, string keyValue);

        void SubmitForm(List<RoleAuthenticationEntity> entities, string keyValue);
    }
}
