namespace Ly.ProjectManager.Data.Migrations
{
    using Ly.ProjectManage.Code.Security;
    using Ly.ProjectManager.Code;
    using Ly.ProjectManager.Domain._2.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ly.ProjectManager.Data.DBContext.ProjectManagerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ly.ProjectManager.Data.DBContext.ProjectManagerDbContext context)
        {
            ////This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method
            ////  to avoid creating duplicate seed data.

            //var accountEntity = new AccountEntity()
            //{
            //    accountNo = "201517060227",
            //    accountPwd = DESEncrypt.Encrypt(Md5.md5("267211", 32)),
            //    accountType = 1,
            //    accountCard = "430523199605267211",
            //    isEnabled = true,
            //    birthday = "1997-05-26",
            //    gender = true,
            //    wechat = "1259351777",
            //    qq = "1259351777",
            //    phone = "18390772774",
            //    nation = "汉族",
            //    place = "湖南邵阳",
            //    remarks = "安之若素",
            //    accountName = "Dyao"
            //};
            //accountEntity.Create();
            //context.AccountEntity.Add(accountEntity);

            //var roleList = new List<RoleEntity>() {
            //    new RoleEntity() { roleLv = 1, roleName = "超级管理员" },
            //    new RoleEntity() { roleLv = 2, roleName = "管理员" },
            //    new RoleEntity() { roleLv = 3, roleName = "学工主任" },
            //    new RoleEntity() { roleLv = 3, roleName = "学术主任" },
            //    new RoleEntity() { roleLv = 4, roleName = "辅导员" },
            //    new RoleEntity() { roleLv = 4, roleName = "讲师" },
            //    new RoleEntity() { roleLv = 5, roleName = "学生" },
            //    new RoleEntity() { roleLv = 5, roleName = "项目小组长" }
            //};
            //roleList.ForEach(c => c.Create());
            //roleList.ForEach(c => context.RoleEntity.Add(c));

            //var accountRoleEntity = new AccountRoleEntity()
            //{
            //    accountInfoGuid = accountEntity.accountGuid,
            //    roleInfoGuid = roleList[0].roleGuid,
            //    remarks = "一个非常牛逼的存在"
            //};

            //accountRoleEntity.Create();
        }
    }
}
