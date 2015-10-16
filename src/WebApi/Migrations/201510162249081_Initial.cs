namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApiClients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Secret = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ApiClientType = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RefreshTokenLifeTime = c.Int(nullable: false),
                        AllowedOrigin = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssetAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetId = c.Int(nullable: false),
                        LocationId = c.Int(),
                        UserId = c.Int(),
                        AssignedDate = c.DateTime(nullable: false),
                        UnassignedDate = c.DateTime(),
                        AssignedByUserId = c.Int(nullable: false),
                        UnassignedByUserId = c.Int(),
                        Status = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assets", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.AssignedByUserId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.Users", t => t.UnassignedByUserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.AssetId)
                .Index(t => t.LocationId)
                .Index(t => t.UserId)
                .Index(t => t.AssignedByUserId)
                .Index(t => t.UnassignedByUserId);
            
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetCategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetCategories", t => t.AssetCategoryId, cascadeDelete: true)
                .Index(t => new { t.AssetCategoryId, t.Name }, unique: true, name: "UniqueAsset");
            
            CreateTable(
                "dbo.AssetCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.AssetFields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetCategoryId = c.Int(nullable: false),
                        FieldType = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 32),
                        Description = c.String(),
                        Position = c.Int(nullable: false),
                        ValidationRules = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetCategories", t => t.AssetCategoryId, cascadeDelete: true)
                .Index(t => new { t.AssetCategoryId, t.Name }, unique: true, name: "UniqueAssetField");
            
            CreateTable(
                "dbo.AssetFieldValues",
                c => new
                    {
                        AssetFieldId = c.Int(nullable: false),
                        AssetId = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => new { t.AssetFieldId, t.AssetId })
                .ForeignKey("dbo.Assets", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.AssetFields", t => t.AssetFieldId, cascadeDelete: true)
                .Index(t => t.AssetFieldId)
                .Index(t => t.AssetId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(),
                        UserName = c.String(nullable: false, maxLength: 32),
                        PasswordHash = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.LocationId)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.LocationId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.CodeTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.CodeTableValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeTableId = c.Int(nullable: false),
                        Value = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CodeTables", t => t.CodeTableId, cascadeDelete: true)
                .Index(t => t.CodeTableId)
                .Index(t => t.Value, unique: true);
            
            CreateTable(
                "dbo.RefreshTokens",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Subject = c.String(nullable: false, maxLength: 50),
                        ApiClientId = c.String(nullable: false, maxLength: 50),
                        IssuedUtc = c.DateTime(nullable: false),
                        ExpiresUtc = c.DateTime(nullable: false),
                        ProtectedTicket = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CodeTableValues", "CodeTableId", "dbo.CodeTables");
            DropForeignKey("dbo.AssetAssignments", "UserId", "dbo.Users");
            DropForeignKey("dbo.AssetAssignments", "UnassignedByUserId", "dbo.Users");
            DropForeignKey("dbo.AssetAssignments", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.AssetAssignments", "AssignedByUserId", "dbo.Users");
            DropForeignKey("dbo.Users", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Assets", "AssetCategoryId", "dbo.AssetCategories");
            DropForeignKey("dbo.AssetFieldValues", "AssetFieldId", "dbo.AssetFields");
            DropForeignKey("dbo.AssetFieldValues", "AssetId", "dbo.Assets");
            DropForeignKey("dbo.AssetFields", "AssetCategoryId", "dbo.AssetCategories");
            DropForeignKey("dbo.AssetAssignments", "AssetId", "dbo.Assets");
            DropIndex("dbo.CodeTableValues", new[] { "Value" });
            DropIndex("dbo.CodeTableValues", new[] { "CodeTableId" });
            DropIndex("dbo.CodeTables", new[] { "Name" });
            DropIndex("dbo.Locations", new[] { "Name" });
            DropIndex("dbo.Locations", new[] { "LocationId" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Users", new[] { "LocationId" });
            DropIndex("dbo.AssetFieldValues", new[] { "AssetId" });
            DropIndex("dbo.AssetFieldValues", new[] { "AssetFieldId" });
            DropIndex("dbo.AssetFields", "UniqueAssetField");
            DropIndex("dbo.AssetCategories", new[] { "Name" });
            DropIndex("dbo.Assets", "UniqueAsset");
            DropIndex("dbo.AssetAssignments", new[] { "UnassignedByUserId" });
            DropIndex("dbo.AssetAssignments", new[] { "AssignedByUserId" });
            DropIndex("dbo.AssetAssignments", new[] { "UserId" });
            DropIndex("dbo.AssetAssignments", new[] { "LocationId" });
            DropIndex("dbo.AssetAssignments", new[] { "AssetId" });
            DropTable("dbo.RefreshTokens");
            DropTable("dbo.CodeTableValues");
            DropTable("dbo.CodeTables");
            DropTable("dbo.Locations");
            DropTable("dbo.Users");
            DropTable("dbo.AssetFieldValues");
            DropTable("dbo.AssetFields");
            DropTable("dbo.AssetCategories");
            DropTable("dbo.Assets");
            DropTable("dbo.AssetAssignments");
            DropTable("dbo.ApiClients");
        }
    }
}
