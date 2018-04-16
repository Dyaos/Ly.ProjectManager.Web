
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Ly.ProjectManager.Domain._2.Entity;

namespace Ly.ProjectManager.Mapping.UserManagement
{
    public class ClassStudentMap : EntityTypeConfiguration<ClassStudentEntity>
    {
        public ClassStudentMap()
        {
            this.ToTable("ClassStudent");
            this.HasKey(t => t.stuGuid);
        }
    }
}
