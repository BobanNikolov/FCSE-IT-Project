namespace FCSE_IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tmpProducts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        name = c.String(),
                        quantity = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        photoURL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tmpProducts", "OrderID", "dbo.Orders");
            DropIndex("dbo.tmpProducts", new[] { "OrderID" });
            DropTable("dbo.Products");
            DropTable("dbo.tmpProducts");
            DropTable("dbo.Orders");
        }
    }
}
