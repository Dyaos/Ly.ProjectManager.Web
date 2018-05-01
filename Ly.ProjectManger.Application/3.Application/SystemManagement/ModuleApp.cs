using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Repository._1.IRepository.SystemManagement;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application.SystemManagement
{
    public class ModuleApp : IModuleApp
    {
        private IModuleRepository moduleRepository;
        public ModuleApp(IModuleRepository moduleRepository)
        {
            this.moduleRepository = moduleRepository;
        }
        public void DeleteForm(string keyValue)
        {
            throw new NotImplementedException();
        }

        public IList<ModuleEntity> FindList(System.Linq.Expressions.Expression<Func<ModuleEntity, bool>> predicate)
        {
            return moduleRepository.IQueryable(predicate).ToList();
        }

        public void SubmitForm(ModuleEntity entity, string keyValue)
        {
            throw new NotImplementedException();
        }
        public ModuleEntity FindEntity(string keyValue)
        {
            return moduleRepository.FindEntity(keyValue);
        }

        public async Task<int> DeleteFormAsync(string keyValue)
        {
            return await moduleRepository.DeleteAsync(c => c.moduleGuid == keyValue);
        }

        public async Task<int> SubmitFormAsync(ModuleEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.Create();
                return await moduleRepository.InsertAsync(entity);
            }
            else
            {
                entity.Modify(keyValue);
                return await moduleRepository.UpdateAsync(entity);
            }
        }
    }
}
