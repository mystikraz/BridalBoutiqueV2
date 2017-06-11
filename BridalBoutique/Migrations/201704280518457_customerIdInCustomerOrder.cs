namespace BridalBoutique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerIdInCustomerOrder : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerOrders", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerOrders", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
