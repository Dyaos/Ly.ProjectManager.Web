using Ly.ProjectManager.Data.Repository;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Repository._1.IRepository.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Repository._2.Repository.ProjectManagement
{
    public class ProjectRepository : RepositoryBase<ProjectEntity>, IProjectRepository
    {
    }
}
