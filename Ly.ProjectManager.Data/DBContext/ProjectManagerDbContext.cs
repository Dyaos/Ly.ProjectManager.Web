
using Ly.ProjectManager.Domain._2.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Data.DBContext
{
    class ProjectManagerDbContext : DbContext
    {
        public ProjectManagerDbContext() : base("ProjectManagerDb")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<AccountEntity> AccountEntity { get; set; }
        public DbSet<AccountRoleEntity> AccountRoleEntity { get; set; }
        public DbSet<ClassEntity> ClassEntity { get; set; }
        public DbSet<ClassManageEntity> ClassManageEntity { get; set; }
        public DbSet<ClassStudentEntity> ClassStudentEntity { get; set; }
        public DbSet<ClassTeacherEntity> ClassTeacherEntity { get; set; }
        public DbSet<DataDictionaryEntity> DataDictionaryEntity { get; set; }
        public DbSet<DefencePersonChargeEntity> DefencePersonChargeEntity { get; set; }
        public DbSet<DefenseEntity> DefenseEntity { get; set; }
        public DbSet<GradeEntity> GradeEntity { get; set; }
        public DbSet<ModuleButtonEntity> ModuleButtonEntity { get; set; }
        public DbSet<ModuleEntity> ModuleEntity { get; set; }
        public DbSet<OperationLogEntity> OperationLogEntity { get; set; }
        public DbSet<ProjectDefenceResultEntity> ProjectDefenceResultEntity { get; set; }
        public DbSet<ProjectEntity> ProjectEntity { get; set; }
        public DbSet<ProjectModuleEntity> ProjectModuleEntity { get; set; }
        public DbSet<ProjectPlanEntity> ProjectPlanEntity { get; set; }
        public DbSet<ProjectTeamEntity> ProjectTeamEntity { get; set; }
        public DbSet<RoleAuthenticationEntity> RoleAuthenticationEntity { get; set; }
        public DbSet<RoleEntity> RoleEntity { get; set; }
        public DbSet<TeamMembersEntity> TeamMembersEntity { get; set; }
        public DbSet<TeamMembersResultEntity> TeamMembersResultEntity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ////获取映射文件名
            //string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("Ly.ProjectManager.Data.DLL", "Ly.ProjectManager.Mapping.DLL").Replace("file:///", "");
            ////加载组件
            //Assembly asm = Assembly.LoadFile(assembleFileName);
            ////获取继承EntityTypeConfiguration Class 集合
            //var typesToRegister = asm.GetTypes()
            // .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //.Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}
            base.OnModelCreating(modelBuilder);
            //删除拓展名
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
