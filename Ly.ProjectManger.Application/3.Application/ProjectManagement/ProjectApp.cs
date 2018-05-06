using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Data.Repository;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.Project;
using Ly.ProjectManager.Repository._1.IRepository.ProjectManagement;
using Ly.ProjectManger.Application._2.IApplication.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application.ProjectManagement
{
    public class ProjectApp : IProjectApp
    {
        private IProjectRepository projectRepository;
        private ICommonRepositoryBase commonRepository;

        public ProjectApp(IProjectRepository projectRepository, ICommonRepositoryBase commonRepository)
        {
            this.projectRepository = projectRepository;
            this.commonRepository = commonRepository;
        }
        public void DeleteForm(string keyValue)
        {
            projectRepository.Delete(c => c.projectGuid == keyValue); ;
        }

        public IList<ProjectEntity> FindList(Expression<Func<ProjectEntity, bool>> predicate)
        {
            return projectRepository.IQueryable(predicate).ToList();
        }

        public IList<ProjectInfoOutputDto> FindList(string accountGuid)
        {
            var param = new List<SqlParameter>() {
                new SqlParameter("@AccountGuid",accountGuid)
            };
            var data = commonRepository.FindList<ProjectInfoOutputDto>("EXEC SP_Ly_Get_Project_Info @AccountGuid", param);
            return data.ToList();
        }

        public void SubmitForm(ProjectEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.Create();
                entity.projectStatus = "进行中";
                projectRepository.Insert(entity);
            }
            else
            {
                entity.Modify(keyValue);
                projectRepository.Update(entity);
            }
        }
    }
}
