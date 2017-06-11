namespace BridalBoutique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateOfferMonth1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Offers", "OfferMonth", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Offers", "OfferMonth", c => c.String());
        }
    }
}
