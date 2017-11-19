namespace IvoRakar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        EMail = c.String(nullable: false, maxLength: 128),
                        MarketingTool = c.Int(nullable: false),
                        Resason = c.String(),
                    })
                .PrimaryKey(t => t.EMail);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscribers");
        }
    }
}
