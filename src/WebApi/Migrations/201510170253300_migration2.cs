namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "PurchaseDate", c => c.DateTime());
            AddColumn("dbo.Assets", "PurchaseCost", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Assets", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "Comments");
            DropColumn("dbo.Assets", "PurchaseCost");
            DropColumn("dbo.Assets", "PurchaseDate");
        }
    }
}
