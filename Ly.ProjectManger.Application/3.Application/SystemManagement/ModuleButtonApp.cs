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
    public class ModuleButtonApp : IModuleButtonApp
    {
        private IModuleButtonRepository buttonRepository;
        public ModuleButtonApp(IModuleButtonRepository buttonRepository)
        {
            this.buttonRepository = buttonRepository;
        }
        public void DeleteForm(string keyValue)
        {
            throw new NotImplementedException();
        }

        public void SubmitForm(ModuleButtonEntity entity, string keyValue)
        {
            throw new NotImplementedException();
        }

        public IList<ModuleButtonEntity> FindList(System.Linq.Expressions.Expression<Func<ModuleButtonEntity, bool>> predicate)
        {
            return buttonRepository.IQueryable(predicate).ToList();
        }

        public async Task<int> SubmitFormAsync(ModuleButtonEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.Create();
                return await buttonRepository.InsertAsync(entity);
            }
            else
            {
                entity.Modify(keyValue);
                return await buttonRepository.UpdateAsync(entity);
            }
        }

        public async Task<int> DeleteFormAsync(string keyValue)
        {
            return await buttonRepository.DeleteAsync(c => c.btnGuid == keyValue);
        }
    }
}
