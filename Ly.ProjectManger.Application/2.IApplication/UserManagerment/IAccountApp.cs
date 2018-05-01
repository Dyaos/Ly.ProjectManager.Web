using Ly.ProjectManager.Code;
using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.Dtos.InputDto.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._2.IApplication.UserManagerment
{
    public interface IAccountApp : IApplicationBase<AccountEntity>, ICommandOperationAsync<AccountEntity>
    {
        Task<OperatorModel> CheckLoginAsync(LoginInputDto loginInput);

        IList<AccountEntity> FindList(Expression<Func<AccountEntity, bool>> predicate);
    }
}
