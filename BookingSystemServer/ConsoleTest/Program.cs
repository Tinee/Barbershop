using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayout.Functions;
using BusinessLogicLayout.Functions.DataHandlers;
using BusinessLogicLayout.Functions.EventHandlers;
using EntityModels.DataTransferObject;
using EntityModels.Models;

namespace ConsoleTest
{
  public class Program
    {
        static void Main(string[] args)
        {
           var x = new AbsenceHandler();




           var a1 = new UserDTO()
           {
               Email = "Admin@gmail.com",
               Password = "admin",
               FirstName = "Felix",
               LastName = "Granberg",
               Adress = "Grangatan 7b",
               City = "Örebro",
               ZipCode = "54232",
               Phone = "0745837726",
               RegisterDate = DateTime.Today,
               LastLoggedIn = DateTime.Today,
           };



            var x2 = new UserHandler();

            var s = new RegisterHandler();

            s.AddAdminToDatabase(a1);














            //var e1 = new UserDTO()
            //{
            //    Email = "Employee2@gmail.com",
            //    Password = "employee",
            //    FirstName = "Fia",
            //    LastName = "Svensson",
            //    Adress = "Testgatan 1",
            //    City = "Testby",
            //    ZipCode = "54232",
            //    Phone = "0745837726",
            //};


            //  x.AddEmployeeToDatabase(e1);

            //  var newSchedule = new SchedulePostForm()
            //{
            //    Email = "Employee2@gmail.com",
            //    Password = "employee",
            //    FirstName = "Fia",
            //    LastName = "Svensson",
            //    Adress = "Testgatan 1",
            //    City = "Testby",
            //    ZipCode = "54232",
            //    Phone = "0745837726",
            //};
            //  x.CreateSchedule(newSchedule);



            //  var z = new AbsenceHandler();

            //  x.AddEmployeeToDatabase(e1);


            //var newOpening = new OpeningHours()
            //{
            //    Id = 1,
            //    TimeFrom = Convert.ToDateTime(new DateTime(2015, 01, 01, 09, 0, 0).ToShortTimeString()),
            //    TimeTo = Convert.ToDateTime(new DateTime(2015, 01, 01, 18, 0, 0).ToShortTimeString()),
            //};
            //var x = new OrderTypeDTO()
            //{
            //    Id = 1,
            //    Name = "Klippning",
            //    Price = 200,
            //    RequiredTime = 15
            //};
            //var x2 = new OrderTypeDTO()
            //{
            //    Id = 2,
            //    Name = "Färgning",
            //    Price = 150,
            //    RequiredTime = 45
            //};


            //var bookingHandler = new BookingHandler();

            //var newOreder = new OrderDetails
            //{
            //    Day = new DateTime(2015, 04, 30, 9, 0, 0),
            //    EmployeeId = 2,
            //    OrderTypes = new List<OrderTypeDTO>
            //    {
            //        x,
            //        x2
            //    }
            //};
            //var newOrder = new OrderDetails
            //{
            //    Day = new DateTime(2015, 04, 30, 12, 0, 0),
            //    EmployeeId = 2,
            //    OrderTypes = new List<OrderTypeDTO>
            //    {
            //        x,
            //        x2
            //    }
            //};

            //var kurt = bookingHandler.GetsAIntervallScheme(newOrder);
            // var scheme = bookingHandler.GetUnBookedSchemeFromAllEmployees(new DateTime(2015, 04, 30, 9, 0, 0));

            //RegisterHandler x = new RegisterHandler();

            //var kurt = new Customer()
            //{
            //    FirstName = "Marcus",
            //    LastName = "hej",
            //    Email = "d@s.com",
            //    Password = "hej",
            //    Adress = "dasasd",
            //    City = "asd",
            //    Phone = "asdasd",
            //    ZipCode = "azsd",
            //};

            //x.AddCustomerToDatabase(kurt);




        }
    }
}
