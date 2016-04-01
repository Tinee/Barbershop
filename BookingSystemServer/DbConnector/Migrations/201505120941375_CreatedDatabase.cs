namespace DbConnector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Absences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleId = c.Int(nullable: false),
                        AbsenceTypeId = c.Int(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DataTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbsenceTypes", t => t.AbsenceTypeId)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId)
                .Index(t => t.ScheduleId)
                .Index(t => t.AbsenceTypeId);
            
            CreateTable(
                "dbo.AbsenceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        TimeOfDayFrom = c.DateTime(nullable: false),
                        TimeOfDayTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Salt = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Adress = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        Phone = c.String(nullable: false),
                        Permission = c.Int(nullable: false),
                        LastLoggedIn = c.DateTime(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        BookedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CustomerId)
                .ForeignKey("dbo.Users", t => t.EmployeeId)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.OrderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        RequiredTime = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderTypeOrders",
                c => new
                    {
                        OrderType_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderType_Id, t.Order_Id })
                .ForeignKey("dbo.OrderTypes", t => t.OrderType_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.OrderType_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "EmployeeId", "dbo.Users");
            DropForeignKey("dbo.OrderTypeOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderTypeOrders", "OrderType_Id", "dbo.OrderTypes");
            DropForeignKey("dbo.OrderTypes", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Users");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.Absences", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Absences", "AbsenceTypeId", "dbo.AbsenceTypes");
            DropIndex("dbo.OrderTypeOrders", new[] { "Order_Id" });
            DropIndex("dbo.OrderTypeOrders", new[] { "OrderType_Id" });
            DropIndex("dbo.OrderTypes", new[] { "Category_Id" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Schedules", new[] { "EmployeeId" });
            DropIndex("dbo.Absences", new[] { "AbsenceTypeId" });
            DropIndex("dbo.Absences", new[] { "ScheduleId" });
            DropTable("dbo.OrderTypeOrders");
            DropTable("dbo.Categories");
            DropTable("dbo.OrderTypes");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Schedules");
            DropTable("dbo.AbsenceTypes");
            DropTable("dbo.Absences");
        }
    }
}
