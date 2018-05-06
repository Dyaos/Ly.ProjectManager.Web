using Ly.ProjectManager.Code;
using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._2.IApplication.ProjectManagement
{
    public interface IProjectTeamApp : IApplicationBase<ProjectTeamEntity>
    {
        IList<ProjectTeamEntity> FindList(Pagination pagination);
        IList<ProjectTeamEntity> FindList(Expression<Func<ProjectTeamEntity, bool>> predicate);
    }
}
