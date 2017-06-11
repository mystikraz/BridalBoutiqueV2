namespace BridalBoutique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confirmPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ConfirmPassword");
        }
    }
}
