using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._2.IApplication.ProjectManagement
{
    public interface IProjectApp : IApplicationBase<ProjectEntity>
    {
        IList<ProjectEntity> FindList(Expression<Func<ProjectEntity, bool>> predicate);

        IList<ProjectInfoOutputDto> FindList(string accountGuid);
    }
}
