using Ly.ProjectManager.Domain._3.IRepository;
using Ly.ProjectManager.Domain._4.Entity;
using Ly.ProjectManger.Application._2.IApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application
{
    public class TeacherApp : ITeacherApp
    {
        private ITeacherRepository teacherRepository;
        public TeacherApp(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }
        /// <summary>
        /// 假删除
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                var entity = new TeatherEntity();
                entity.Remove(keyValue);
                teacherRepository.Update(entity);
            }
            else
            {
                throw new Exception("删除失败，未确认要删除的数据!");
            }
        }

        public void SubmitForm(TeatherEntity entity, string keyValue)
        {
            throw new NotImplementedException();
        }
    }
}
