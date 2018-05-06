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
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application.SystemManagement
{
    public class AccountRoleApp : IAccountRoleApp
    {
        private IAccountRoleRepository accountRoleRepository;
        public AccountRoleApp(IAccountRoleRepository accountRoleRepository)
        {
            this.accountRoleRepository = accountRoleRepository;
        }


        public void DeleteForm(string keyValue)
        {
            throw new NotImplementedException();
        }

        public IList<AccountRoleEntity> FindList(string keyValue)
        {
            return accountRoleRepository.IQueryable(c => c.isEnabled == true && c.accountInfoGuid == keyValue).ToList();
        }

        public void ModifyRole(string roleList, string keyValue)
        {
            throw new NotImplementedException();
        }

        public void SubmitForm(AccountRoleEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.Create();
                accountRoleRepository.Insert(entity);
            }
            else
            {
                entity.Modify(keyValue);
                accountRoleRepository.Update(entity);
            }
        }

        public void SubmitForm(string roleList, string keyValue)
        {
            var roleArr = roleList.Split(',');
            var accountRoleList = new List<AccountRoleEntity>();
            foreach (var roleGuid in roleArr)
            {
                var accountRoleEntity = new AccountRoleEntity();
                accountRoleEntity.Create();
                accountRoleEntity.roleInfoGuid = roleGuid;
                accountRoleEntity.accountInfoGuid = keyValue;
                accountRoleList.Add(accountRoleEntity);
            }
            accountRoleRepository.SubmitForm(accountRoleList, keyValue);
        }


    }
}
