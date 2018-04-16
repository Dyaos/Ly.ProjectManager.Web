
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Ly.ProjectManager.Domain._2.Entity;

namespace Ly.ProjectManager.Mapping.UserManagement
{
    public class ProjectPlanMap : EntityTypeConfiguration<ProjectPlanEntity>
    {
        public ProjectPlanMap()
        {
            this.ToTable("ProjectPlan");
            this.HasKey(t => t.planGuid);
        }
    }
}
