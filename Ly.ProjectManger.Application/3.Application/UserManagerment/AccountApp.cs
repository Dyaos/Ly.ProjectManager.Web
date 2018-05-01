
using Ly.ProjectManage.Code.Security;
using Ly.ProjectManager.Code;
using Ly.ProjectManager.Code.AutoMapper;
using Ly.ProjectManager.Data.Repository;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.CustomerException;
using Ly.ProjectManager.Infrastructure.Dtos.InputDto.Login;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.Login;
using Ly.ProjectManager.Infrastructure.Enum;
using Ly.ProjectManager.Repository._1.IRepository.UserManagerment;
using Ly.ProjectManger.Application._2.IApplication.UserManagerment;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application.UserManagerment
{
    public class AccountApp : IAccountApp
    {
        private IAccountRepository accountRepository;
        private ICommonRepositoryBase commonRepository;
        public AccountApp(IAccountRepository accountRepository, ICommonRepositoryBase commonRepository)
        {
            this.accountRepository = accountRepository;
            this.commonRepository = commonRepository;
        }

        public async Task<OperatorModel> CheckLoginAsync(LoginInputDto loginInput)
        {
            var param = new List<SqlParameter>() {
                new SqlParameter("@AccountNo",loginInput.cardNo),
                new SqlParameter("@AccountType",loginInput.accountType)
            };
            var loginEntity = (await commonRepository.FindListAsync<LoginOutputDto>("EXEC SP_Ly_Check_Login @AccountNo,@AccountType", param));
            if (loginEntity == null || loginEntity.Count <= 0)
                throw new ProgramLogicException((new { message = "该账号不存在，请重新输入", errorCode = LoginResultType.loginNotExist }).ToJson());
            if (!loginEntity[0].isEnabled)
                throw new ProgramLogicException((new { message = "该账号被锁住，请联系管理员", errorCode = LoginResultType.loginLocking }).ToJson());

            string pwd = DESEncrypt.Encrypt(loginInput.cardPwd);
            if (!loginEntity[0].accountPwd.Equals(pwd.ToUpper()))
                throw new ProgramLogicException((new { message = "密码输入错误，请重新输入", errorCode = LoginResultType.loginFail }).ToJson());

            return loginEntity[0].ToModel<OperatorModel>();
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
                accountRepository.Update(entity);
            }
            else
            {
                throw new Exception("删除失败，未确认要删除的数据!");
            }
        }

        public void SubmitForm(AccountEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.accountType = 2;
                var pwd = entity.accountCard.Substring(entity.accountCard.Length - 7, 6);
                entity.accountPwd = DESEncrypt.Encrypt(Md5.md5(pwd, 32));
                entity.Create();
                accountRepository.Insert(entity);
            }
            else
            {
                entity.Modify(keyValue);
                accountRepository.Update(entity);
            }
        }

        public IList<AccountEntity> FindList(Expression<Func<AccountEntity, bool>> predicate)
        {
            return accountRepository.IQueryable(predicate).ToList();
        }

        public Task<int> SubmitFormAsync(AccountEntity entity, string keyValue)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteFormAsync(string keyValue)
        {
            return await accountRepository.DeleteAsync(c => c.accountGuid == keyValue);
        }
    }
}
