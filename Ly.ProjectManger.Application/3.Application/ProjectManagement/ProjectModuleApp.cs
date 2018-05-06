using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Data.Repository;
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
    public class ProjectModuleApp : IProjectModuleApp
    {
        private IProjectModuleRepository projectModuleRepository;
        private ICommonRepositoryBase commonRepository;
        public ProjectModuleApp(IProjectModuleRepository projectModuleRepository, ICommonRepositoryBase commonRepository)
        {
            this.projectModuleRepository = projectModuleRepository;
            this.commonRepository = commonRepository;
        }

        public void DeleteForm(string keyValue)
        {
            projectModuleRepository.Delete(c => c.projectModuleGuid == keyValue);
        }

        public IList<ProjectModuleEntity> FindList(Expression<Func<ProjectModuleEntity, bool>> predicate)
        {
            return projectModuleRepository.IQueryable(predicate).ToList();
        }

        public void SubmitForm(ProjectModuleEntity entity, string keyValue)
        {
            if (!string.IsNullOrEmpty(entity.chargePerson))
            {
                var account = entity.chargePerson.Split('&');
                entity.chargePersonInfoGuid = account[0];
                entity.chargePerson = account[1];
            }

            if (string.IsNullOrEmpty(keyValue))
            {
                entity.Create();
                entity.projectModuleStatus = "进行中";
                projectModuleRepository.Insert(entity);
            }
            else
            {
                entity.Modify(keyValue);
                projectModuleRepository.Update(entity);
            }
        }
    }
}
