namespace Ly.ProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectModule", "projectInfoGuid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectModule", "projectInfoGuid");
        }
    }
}
