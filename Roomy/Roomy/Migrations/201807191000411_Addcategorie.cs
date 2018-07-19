namespace Roomy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcategorie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Rooms", "CategorieID", c => c.Int());
            CreateIndex("dbo.Rooms", "CategorieID");
            AddForeignKey("dbo.Rooms", "CategorieID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "CategorieID", "dbo.Categories");
            DropIndex("dbo.Rooms", new[] { "CategorieID" });
            DropColumn("dbo.Rooms", "CategorieID");
            DropTable("dbo.Categories");
        }
    }
}
