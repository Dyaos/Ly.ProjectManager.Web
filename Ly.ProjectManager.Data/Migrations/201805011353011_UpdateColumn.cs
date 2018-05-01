namespace Ly.ProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClassTeacher", "accountInfoGuid", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClassTeacher", "accountInfoGuid", c => c.Int(nullable: false));
        }
    }
}
