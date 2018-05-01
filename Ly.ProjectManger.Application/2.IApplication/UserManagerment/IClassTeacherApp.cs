using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._2.IApplication.UserManagerment
{
    public interface IClassTeacherApp : IApplicationBase<ClassTeacherEntity>
    {
        IList<ClassTeacherEntity> FindList(Expression<Func<ClassTeacherEntity, bool>> predicate);
    }
}
