namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedCustomerModelMigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "TempSuspendStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "TempSuspendEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "TempSuspendEnd", c => c.String());
            AlterColumn("dbo.Customers", "TempSuspendStart", c => c.String());
        }
    }
}
