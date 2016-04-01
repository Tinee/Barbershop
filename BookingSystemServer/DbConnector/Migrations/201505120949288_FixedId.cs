namespace DbConnector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderTypes", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.OrderTypes", name: "IX_Category_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OrderTypes", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.OrderTypes", name: "CategoryId", newName: "Category_Id");
        }
    }
}
