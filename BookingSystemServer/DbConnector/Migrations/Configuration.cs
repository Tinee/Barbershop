using System.Collections.Generic;
using System.Collections.ObjectModel;
using EntityModels.Models;

namespace DbConnector.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DbConnector.DataAccessLayer.BookingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbConnector.DataAccessLayer.BookingContext context)
        {
            var kurt = new Collection<OrderType>();
            
            var c1 = new Customer()
            {
                Id = 1,
                Email = "TestCustomerEmail@gmail.com",
                Password = "test",
                FirstName = "Customer",
                LastName = "Test",
                Adress = "Testgatan 1",
                City = "Testby",
                Salt = "TrySaltMe",
                ZipCode = "54232",
                Phone = "0745837726",
                RegisterDate = DateTime.Today,
                LastLoggedIn = DateTime.Today,
                Permission = PermissionType.Customer
            };

            var e1 = new Employee()
            {
                Id = 2,
                Email = "TestEmployeeEmail@gmail.com",
                Password = "test",
                FirstName = "Employee",
                LastName = "Test",
                Salt = "TrySaltMe",
                Adress = "Testgatan 1",
                City = "Testby",
                ZipCode = "54232",
                Phone = "0745837726",
                RegisterDate = DateTime.Today,
                LastLoggedIn = DateTime.Today,
                Permission = PermissionType.Employee
            };

            var a1 = new Administrator()
            {
                Id = 3,
                Email = "TestAdminEmail@gmail.com",
                Password = "test",
                FirstName = "Customer",
                LastName = "Test",
                Salt = "TrySaltMe",
                Adress = "Testgatan 1",
                City = "Testby",
                ZipCode = "54232",
                Phone = "0745837726",
                RegisterDate = DateTime.Today,
                LastLoggedIn = DateTime.Today,
                Permission = PermissionType.Administrator
            };
            var cat = new Category
            {
                Id = 1,
                Name = "Klippning",
            };
            var cat2 = new Category
            {
                Id = 2,
                Name = "Färging"
            };

            var ot1 = new OrderType()
            {
                Id = 2,
                Name = "Klippning",
                Price = 375,
                RequiredTime = 45,
                CategoryId = cat.Id

            };

            var ot2 = new OrderType()
            {
                Id = 1,
                Name = "Färgning",
                Price = 1050,
                RequiredTime = 60,
                CategoryId = cat2.Id
            };
            kurt.Add(ot1);
            kurt.Add(ot2);
            var o1 = new Order()
            {
                Id = 1,
                BookedDate = new DateTime(2015, 04, 30, 9, 0, 0),
                CustomerId = c1.Id,
                EmployeeId = e1.Id,
                OrderDate = DateTime.Now,
                OrderTypes = kurt

            }; var o2 = new Order()
            {
                Id = 2,
                BookedDate = new DateTime(2015, 04, 30, 12, 0, 0),
                CustomerId = c1.Id,
                EmployeeId = e1.Id,
                OrderDate = DateTime.Now,
                OrderTypes = kurt
            };
            var newOpening = new OpeningHours()
            {
                Id = 1,
                TimeFrom = new DateTime(2015, 01, 01, 09, 0, 0),
                TimeTo = new DateTime(2015, 01, 01, 18, 0, 0)
            };

            var newSchedule = new Schedule()
            {
                Id = 1,
                EmployeeId = e1.Id,
                DateFrom = new DateTime(2016, 01, 01),
                DateTo = new DateTime(2016, 12, 31),
                TimeOfDayFrom = new DateTime(2000, 1, 1, 9, 0, 0),
                TimeOfDayTo = new DateTime(2000, 1, 1, 18, 0, 0)

            };

            var at1 = new AbsenceType()
            {
                Id = 1,
                Name = "Sjukdom"
            };

            var at2 = new AbsenceType()
            {
                Id = 2,
                Name = "Vård av barn"
            };

            context.Administrators.AddOrUpdate(a1);
            context.Customers.AddOrUpdate(c1);
            context.Employees.AddOrUpdate(e1);
            context.OrderTypes.AddOrUpdate(ot1, ot2);
            context.Categories.AddOrUpdate(cat, cat2);
            context.Orders.AddOrUpdate(o1);
            context.Orders.AddOrUpdate(o2);
            context.OpeningHours.AddOrUpdate(newOpening);
            context.Schedules.AddOrUpdate(newSchedule);
            context.AbsenceTypes.AddOrUpdate(at1, at2);
        }
    }
}
