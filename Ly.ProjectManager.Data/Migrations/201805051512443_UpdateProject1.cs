namespace Ly.ProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProject1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectModule", "chargePersonInfoGuid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectModule", "chargePersonInfoGuid");
        }
    }
}
