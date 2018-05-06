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
    public class AccountRoleRepository : RepositoryBase<AccountRoleEntity>, IAccountRoleRepository
    {
        public void SubmitForm(List<AccountRoleEntity> entities, string keyValue)
        {
            using (var dbContext = BeginTrans())
            {
                Delete(c => c.accountInfoGuid == keyValue);
                Insert(entities);
                dbContext.Commit();
            }
        }
    }
}
