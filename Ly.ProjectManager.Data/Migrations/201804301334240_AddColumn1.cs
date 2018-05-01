namespace Ly.ProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OperationLog", "operationIP", c => c.String());
            AlterColumn("dbo.OperationLog", "logLevel", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OperationLog", "logLevel", c => c.Int(nullable: false));
            DropColumn("dbo.OperationLog", "operationIP");
        }
    }
}
