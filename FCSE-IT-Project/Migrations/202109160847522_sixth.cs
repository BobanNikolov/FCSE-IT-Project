namespace FCSE_IT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tmpProducts");
        }
    }
}
