using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._2.IApplication.SystemManagement
{
    public interface IModuleButtonApp : IApplicationBase<ModuleButtonEntity>, ICommandOperationAsync<ModuleButtonEntity>
    {
        IList<ModuleButtonEntity> FindList(Expression<Func<ModuleButtonEntity, bool>> predicate);

    }
}
