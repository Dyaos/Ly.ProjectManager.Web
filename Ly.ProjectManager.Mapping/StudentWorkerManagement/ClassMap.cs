
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Ly.ProjectManager.Domain._2.Entity;

namespace Ly.ProjectManager.Mapping.UserManagement
{
    public class ClassMap : EntityTypeConfiguration<ClassEntity>
    {
        public ClassMap()
        {
            this.ToTable("ClassInfo");
            this.HasKey(t => t.classGuid);
        }
    }
}
