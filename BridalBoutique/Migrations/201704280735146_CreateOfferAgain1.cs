namespace BridalBoutique.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateOfferAgain1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Offers", "ProductId");
            AddForeignKey("dbo.Offers", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "ProductId", "dbo.Products");
            DropIndex("dbo.Offers", new[] { "ProductId" });
        }
    }
}
