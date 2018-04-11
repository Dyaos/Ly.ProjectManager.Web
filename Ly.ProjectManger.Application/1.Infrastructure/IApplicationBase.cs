using Ly.ProjectManager.Domain._1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Data.Application
{
    public interface IApplicationBase<TEntity> : ICommandOperation<TEntity> where TEntity : class, new()
    {

    }
}
