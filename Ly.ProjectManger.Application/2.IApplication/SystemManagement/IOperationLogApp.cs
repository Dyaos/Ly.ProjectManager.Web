using Ly.ProjectManager.Code;
using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._2.IApplication.SystemManagement
{
    public interface IOperationLogApp : IApplicationBase<OperationLogEntity>, ICommandOperationAsync<OperationLogEntity>
    {
        IList<OperationLogEntity> FindList(Pagination pagination, string queryJson);
        OperationLogEntity FindEntity(string keyValue);
    }
}
