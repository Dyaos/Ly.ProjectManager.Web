
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Ly.ProjectManager.Domain._3.Entity;

namespace Ly.ProjectManager.Mapping.UserManagement
{
    public class AccountMap : EntityTypeConfiguration<AccountEntity>
    {
        public AccountMap()
        {
            this.ToTable("Account");
            this.HasKey(t => t.accountGuid);
        }
    }
}
