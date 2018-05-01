namespace Ly.ProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OperationLog", "logLevel", c => c.String());
            AddColumn("dbo.OperationLog", "logThread", c => c.String());
            AddColumn("dbo.OperationLog", "logName", c => c.String());
            AddColumn("dbo.OperationLog", "operationIP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OperationLog", "logName");
            DropColumn("dbo.OperationLog", "logThread");
            DropColumn("dbo.OperationLog", "logLevel");
            DropColumn("dbo.OperationLog", "operationIP");
        }
    }
}
