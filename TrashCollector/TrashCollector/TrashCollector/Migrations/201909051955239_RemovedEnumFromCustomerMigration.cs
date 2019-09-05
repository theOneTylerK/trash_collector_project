namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedEnumFromCustomerMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickUpDay", c => c.String());
            DropColumn("dbo.Customers", "PickUpDayId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PickUpDayId", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "PickUpDay");
        }
    }
}
