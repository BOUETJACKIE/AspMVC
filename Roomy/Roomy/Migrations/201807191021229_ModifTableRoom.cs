namespace Roomy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifTableRoom : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "CategorieID", "dbo.Categories");
            DropIndex("dbo.Rooms", new[] { "CategorieID" });
            AlterColumn("dbo.Rooms", "CategorieID", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "CategorieID");
            AddForeignKey("dbo.Rooms", "CategorieID", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "CategorieID", "dbo.Categories");
            DropIndex("dbo.Rooms", new[] { "CategorieID" });
            AlterColumn("dbo.Rooms", "CategorieID", c => c.Int());
            CreateIndex("dbo.Rooms", "CategorieID");
            AddForeignKey("dbo.Rooms", "CategorieID", "dbo.Categories", "ID");
        }
    }
}
