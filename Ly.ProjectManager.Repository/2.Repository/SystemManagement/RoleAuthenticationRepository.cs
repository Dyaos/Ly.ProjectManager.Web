using Ly.ProjectManager.Data.Repository;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Repository._1.IRepository.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Repository._2.Repository.SystemManagement
{
    public class RoleAuthenticationRepository : RepositoryBase<RoleAuthenticationEntity>, IRoleAuthenticationRepository
    {
        public async Task<int> SubmitFormAsync(List<RoleAuthenticationEntity> entities, string keyValue)
        {
            using (var dbContext = BeginTrans())
            {
                Delete(c => c.authRoleGuid == keyValue);
                Insert(entities);
                return await dbContext.CommitAsync();
            }
        }

        public void SubmitForm(List<RoleAuthenticationEntity> entities, string keyValue)
        {
            using (var dbContext = BeginTrans())
            {
                Delete(c => c.authRoleGuid == keyValue);
                Insert(entities);
                dbContext.Commit();
            }
        }
    }
}
