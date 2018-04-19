
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Repository._1.IRepository.UserManagerment;
using Ly.ProjectManger.Application._2.IApplication.UserManagerment;
using Ly.ProjectManger.Application._3.Application.UserManagerment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application
{
    public class AccountApp : IAccountApp
    {
        private IAccountRepository AccountRepository;
        public AccountApp(IAccountRepository AccountRepository)
        {
            this.AccountRepository = AccountRepository;
        }
        /// <summary>
        /// 假删除
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                var entity = new AccountEntity();
                entity.Remove(keyValue);
                AccountRepository.Update(entity);
            }
            else
            {
                throw new Exception("删除失败，未确认要删除的数据!");
            }
        }

        public void SubmitForm(AccountEntity entity, string keyValue)
        {
            throw new NotImplementedException();
        }
    }
}
