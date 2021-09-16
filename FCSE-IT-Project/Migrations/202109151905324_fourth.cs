namespace FCSE_IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tmpProducts", "OrderID", "dbo.Orders");
            DropIndex("dbo.tmpProducts", new[] { "OrderID" });
            DropTable("dbo.tmpProducts");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.tmpProducts", "OrderID");
            AddForeignKey("dbo.tmpProducts", "OrderID", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
