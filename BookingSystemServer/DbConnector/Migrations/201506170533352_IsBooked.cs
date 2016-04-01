namespace DbConnector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsBooked : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsBooked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsBooked");
        }
    }
}
