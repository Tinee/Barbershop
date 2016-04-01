namespace DbConnector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOpeningHours : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpeningHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeFrom = c.DateTime(nullable: false),
                        TimeTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OpeningHours");
        }
    }
}
