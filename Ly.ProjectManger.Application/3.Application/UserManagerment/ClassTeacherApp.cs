using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Repository._1.IRepository.UserManagerment;
using Ly.ProjectManger.Application._2.IApplication.UserManagerment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application.UserManagerment
{
    public class ClassTeacherApp : IClassTeacherApp
    {
        private IClassTeacherRepository classTeacherRepository;
        public ClassTeacherApp(IClassTeacherRepository classTeacherRepository)
        {
            this.classTeacherRepository = classTeacherRepository;
        }
        public void DeleteForm(string keyValue)
        {
            throw new NotImplementedException();
        }

        public IList<ClassTeacherEntity> FindList(Expression<Func<ClassTeacherEntity, bool>> predicate)
        {
            return classTeacherRepository.IQueryable(predicate).ToList();
        }

        public void SubmitForm(ClassTeacherEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.Create();
                classTeacherRepository.Insert(entity);
            }
            else
            {
                entity.Modify(keyValue);
                classTeacherRepository.Update(entity);
            }
        }
    }
}
