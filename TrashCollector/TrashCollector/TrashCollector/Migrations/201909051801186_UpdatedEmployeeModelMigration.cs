namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEmployeeModelMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "emailAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "emailAddress");
        }
    }
}
