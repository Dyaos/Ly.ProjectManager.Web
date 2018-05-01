using Ly.ProjectManager.Code;
using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Repository._1.IRepository.SystemManagement;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application.SystemManagement
{
    public class RoleApp : IRoleApp
    {
        private IRoleRepository roleRepository;
        private IRoleAuthenticationApp roleAuthApp;
        public RoleApp(IRoleRepository roleRepository, IRoleAuthenticationApp roleAuthApp)
        {
            this.roleRepository = roleRepository;
            this.roleAuthApp = roleAuthApp;
        }
        public void DeleteForm(string keyValue)
        {
            throw new NotImplementedException();
        }

        public void SubmitForm(RoleEntity entity, string keyValue)
        {
            throw new NotImplementedException();
        }
        public RoleEntity FindEntity(string keyValue)
        {
            return roleRepository.FindEntity(keyValue);
        }

        public IList<RoleEntity> FindList(Expression<Func<RoleEntity, bool>> predicate, Pagination pagination)
        {
            return roleRepository.FindList(predicate, pagination);
        }

        public Task<int> SubmitFormAsync(RoleEntity entity, string keyValue)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteFormAsync(string keyValue)
        {
            return roleRepository.DeleteAsync(c => c.roleGuid == keyValue);
        }

        public async Task<int> SubmitFormAsync(RoleEntity entity, string permissionIds, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
                entity.Create();
            else
                entity.Modify(keyValue);

            roleAuthApp.SubmitForm(permissionIds, entity.roleGuid);
            return string.IsNullOrEmpty(keyValue) ? await roleRepository.InsertAsync(entity) : await roleRepository.UpdateAsync(entity);
        }

        public RoleEntity FindEntity(Expression<Func<RoleEntity, bool>> predicate)
        {
            return roleRepository.FindEntity(predicate);
        }
    }
}
