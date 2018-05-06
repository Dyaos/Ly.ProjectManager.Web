namespace Ly.ProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIdentity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectTeam", "teamIdentity", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectTeam", "teamIdentity", c => c.String(nullable: false));
        }
    }
}
