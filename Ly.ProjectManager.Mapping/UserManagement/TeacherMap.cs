using Ly.ProjectManager.Domain._4.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Ly.ProjectManager.Mapping.UserManagement
{
    public class TeacherMap : EntityTypeConfiguration<TeatherEntity>
    {
        public TeacherMap()
        {
            this.ToTable("Teacher");
            this.HasKey(t => t.teacherGuid);
        }
    }
}
