using Ly.ProjectManager.Data.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._1.Infrastructure
{
    public interface IApplicationAsyncBase<TEntity> : ICommandOperationAsync<TEntity> where TEntity : class, new()
    {

    }
}
