using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Data.DBContext
{
    class ProjectManagerDbContext : DbContext
    {
        public ProjectManagerDbContext() : base("ProjectManagerDbContext")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //获取映射文件名
            string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("Ly.ProjectManager.Data.DLL", "Ly.ProjectManager.Mapping.DLL").Replace("file:///", "");
            //加载组件
            Assembly asm = Assembly.LoadFile(assembleFileName);
            //获取继承EntityTypeConfiguration Class 集合
            var typesToRegister = asm.GetTypes()
             .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
