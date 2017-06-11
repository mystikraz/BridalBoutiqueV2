namespace BridalBoutique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "UserName");
        }
    }
}
