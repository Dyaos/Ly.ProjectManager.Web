using Ly.ProjectManager.Code;
using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Repository._1.IRepository.ProjectManagement;
using Ly.ProjectManger.Application._2.IApplication.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application.ProjectManagement
{
    public class ProjectTeamApp : IProjectTeamApp
    {
        private IProjectTeamRepository teamRepository;
        public ProjectTeamApp(IProjectTeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }
        public void DeleteForm(string keyValue)
        {
            teamRepository.Delete(c => c.teamGuid == keyValue);
        }

        public IList<ProjectTeamEntity> FindList(Pagination pagination)
        {
            return teamRepository.FindList(c => c.isEnabled == true, pagination);
        }

        public IList<ProjectTeamEntity> FindList(Expression<Func<ProjectTeamEntity, bool>> predicate)
        {
            return teamRepository.IQueryable(predicate).ToList();
        }

        public void SubmitForm(ProjectTeamEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.Create();
                teamRepository.Insert(entity);
            }
            else
            {
                entity.Modify(keyValue);
                teamRepository.Update(entity);
            }
        }
    }
}
