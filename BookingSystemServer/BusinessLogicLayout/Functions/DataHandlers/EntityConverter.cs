using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EntityModels.DataTransferObject;
using EntityModels.Models;

namespace BusinessLogicLayout.Functions.DataHandlers
{
    public static class EntityConverter
    {
        public static UserDTO ConvertToUserDto(this User user)
        {
            var userDto = new UserDTO()
            {

                FirstName = user.FirstName,
                LastName = user.LastName,
                Adress = user.Adress,
                City = user.City,
                Email = user.Email,
                Id = user.Id,
                LastLoggedIn = user.LastLoggedIn,
                RegisterDate = user.RegisterDate,
                PermissionType = user.Permission,
                Phone = user.Phone,
                ZipCode = user.ZipCode
            };
            return userDto;
        }

        public static List<UserDTO> ConvertToUserDto(this List<User> users)
        {
            return users.ConvertAll(x => new UserDTO()
            {

                FirstName = x.FirstName,
                LastName = x.LastName,
                Adress = x.Adress,
                City = x.City,
                Email = x.Email,
                Id = x.Id,
                LastLoggedIn = x.LastLoggedIn,
                RegisterDate = x.RegisterDate,
                PermissionType = x.Permission,
                Phone = x.Phone,
                ZipCode = x.ZipCode
            });
        }
        public static List<UserDTO> ConvertToUseDto(this List<Employee> users)
        {
            return users.ConvertAll(x => new UserDTO()
            {

                FirstName = x.FirstName,
                LastName = x.LastName,
                Adress = x.Adress,
                City = x.City,
                Email = x.Email,
                Id = x.Id,
                LastLoggedIn = x.LastLoggedIn,
                RegisterDate = x.RegisterDate,
                PermissionType = x.Permission,
                Phone = x.Phone,
                ZipCode = x.ZipCode
            });
        }
        public static Customer ConvertToCustomer(this UserDTO user)
        {
            return new Customer()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Adress = user.Adress,
                City = user.City,
                Email = user.Email,
                Phone = user.Phone,
                ZipCode = user.ZipCode
            };
        }

        public static Administrator ConvertToAdmin(this UserDTO user)
        {
            return new Administrator
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Adress = user.Adress,
                City = user.City,
                Email = user.Email,
                Phone = user.Phone,
                ZipCode = user.ZipCode
            };
        }
        public static Administrator ConvertToAdministrator(this UserDTO user)
        {
            return new Administrator()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Adress = user.Adress,
                City = user.City,
                Email = user.Email,
                Phone = user.Phone,
                ZipCode = user.ZipCode
            };
        }
        public static Employee ConvertToEmployee(this UserDTO user)
        {
            return new Employee()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Adress = user.Adress,
                City = user.City,
                Email = user.Email,
                Phone = user.Phone,
                ZipCode = user.ZipCode
            };
        }
        public static List<OrderTypeDTO> ConverToOrderTypeDtos(this List<OrderType> orderTypes)
        {
            return orderTypes.ConvertAll(x => new OrderTypeDTO
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                RequiredTime = x.RequiredTime
            });
        }

        public static Order ConvertBookingModelToOrder(BookingModel bookingModel,List<OrderType> orderTypes )
        {
            return new Order
            {
             EmployeeId = bookingModel.EmployeeId,
             BookedDate = bookingModel.Day,
             CustomerId = bookingModel.CustomerId,
             OrderDate = DateTime.Now,
             OrderTypes = orderTypes,
             IsBooked = true
            };
        }

        public static Absence ConvertToAbsence(this AbsencePostForm absencePostForm)
        {
            return new Absence()
            {
                DataTo = absencePostForm.DateTo,
                DateFrom = absencePostForm.DateFrom,
                AbsenceTypeId = absencePostForm.AbsenceTypeId,
                ScheduleId = absencePostForm.Schedule,
            };
        }

       

        public static List<OrderInfo> ConvertOrderToOrderInfo(this List<Order> orders)
        {
            var orderInfoList = new List<OrderInfo>();

            foreach (var order in orders)
            {
                orderInfoList.Add(new OrderInfo()
                {
                    Id = order.Id,
                    BookedDate = order.BookedDate,
                    OrderDate = order.OrderDate,
                    CustomerName = order.Customer.FirstName + " " + order.Customer.LastName,
                    EmployeeName = order.Employee.FirstName + " " + order.Employee.LastName,
                    amountOfRequiredTime = order.OrderTypes.Select(ot => ot.RequiredTime).Sum(),
                    OrderTypes = order.OrderTypes.Select(ot => ot.Name).ToList()
                });
            }

            return orderInfoList;
        }

        public static List<ScheduleDTO> ConvertToScheduleDTO(this List<Schedule> schedules)
        {
            return schedules.ConvertAll(s => new ScheduleDTO()
            {
                Id = s.Id,
                DateFrom = s.DateFrom,
                DateTo = s.DateTo,
                TimeOfDayFrom = s.TimeOfDayFrom,
                TimeOfDayTo = s.TimeOfDayTo
            });
        }

        public static List<AbsenceTypeDTO> ConvertToAbsenceTypeDTO(this List<AbsenceType> absenceTypes)
        {
            return absenceTypes.ConvertAll(a => new AbsenceTypeDTO()
            {
                Id = a.Id,
                Name = a.Name
            });
        } 

        public static Schedule ConvertToSchedule(this SchedulePostForm schedule)
        {
            return new Schedule()
            {
                DateFrom = schedule.DateFrom,
                DateTo = schedule.DateTo,
                TimeOfDayFrom = schedule.TimeOfDayFrom,
                TimeOfDayTo = schedule.TimeOfDayTo,
                EmployeeId = schedule.EmployeeId
            };
        }



        //public static List<OrderType> ConvertToOrderTypeFromDto(this List<OrderTypeDTO> orderTypesDtos )
        //{
        //    var list = new List<OrderType>();
        //    list = orderTypesDtos.ConvertAll(o => new OrderType
        //    {
        //        Id = o.Id,
        //        Name = o.
        //    })


        //    /*  public int Id { get; set; }
        //[Required]
        //public int CategoryId { get; set; }
        //[Required]
        //public string Name { get; set; }
        //[Required]
        //public int RequiredTime { get; set; }
        //[Required]
        //public decimal Price { get; set; }
        //public virtual Category Category { get; set; }

        //public virtual ICollection<Order> Orders { get; set; } */
        //}
    }
}