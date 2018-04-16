using Ly.ProjectManager.Domain._2.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Mapping.SystemManagement
{
    public class OperationLogMap : EntityTypeConfiguration<OperationLogEntity>
    {
        public OperationLogMap()
        {
            this.ToTable("OperationLog");
            this.HasKey(t => t.logGuid);
        }
    }
}
