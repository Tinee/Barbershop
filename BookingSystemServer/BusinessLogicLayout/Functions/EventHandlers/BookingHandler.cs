using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayout.Functions.DataHandlers;
using EntityModels.DataTransferObject;
using EntityModels.Models;

namespace BusinessLogicLayout.Functions.EventHandlers
{
    public class BookingHandler : EntityHandler
    {

        public List<Scheme> GetSchemes(DateTime day)
        {
            var employees = UnitOfWork.EmployeeRepository.Get().ToList();

            var schemes = new List<Scheme>();

            foreach (var employee in employees)
            {
                var scheme = GetScheme(employee, day);
                schemes.Add(scheme);
            }

            return schemes;
        }

        public Scheme GetScheme(Employee employee, DateTime day)
        {
            var schedule = employee.Schedules.LastOrDefault();

            var quarters = TimeHandler.GetTimeQuartersFromDay(day, schedule.TimeOfDayFrom, schedule.TimeOfDayTo);

            if (schedule.Absences.Any(a => a.DateFrom <= day && a.DataTo >= day))
                quarters.ForEach(q => q.IsBooked = true);

            for (int i = 0; i < quarters.Count; i++)
            {
                foreach (var order in employee.Orders.Where(o => o.BookedDate.ToShortDateString() == day.ToShortDateString()))
                {
                    if (!order.IsBooked) continue;
                    if (order.BookedDate != quarters[i].Time) continue;

                    int requiredTime = GetRequiredTimeForOrder(order);
                    int amountOfQuarters = requiredTime / 15;

                    for (int j = 0; j < amountOfQuarters; j++)
                    {
                        quarters[i + j].IsBooked = true;
                    }
                }
            }
            return new Scheme() { TimeQuarters = quarters };
        }

        public Scheme GetUnBookedSchemeFromAllEmployees(DateTime day)
        {
            var schemes = GetSchemes(day);
            var openingHour = UnitOfWork.OpeningHoursRepository.Get().LastOrDefault();
            var quarters = TimeHandler.GetTimeQuartersFromDay(day, openingHour.TimeFrom, openingHour.TimeTo);
            var newScheme = new Scheme() { TimeQuarters = new List<TimeQuarter>() };

            foreach (var quarter in quarters)
            {
                foreach (var scheme in schemes)
                {
                    var unBookedOrBookedQuarter = scheme.TimeQuarters.First(t => t.Time == quarter.Time);

                    if (unBookedOrBookedQuarter.IsBooked != true)
                        newScheme.TimeQuarters.Add(unBookedOrBookedQuarter);
                }
            }

            return newScheme;
        }

        public Scheme GetUnBookedSchemeFromEmployee(OrderDetails orderDetails)
        {
            var employee = UnitOfWork.EmployeeRepository.GetById(orderDetails.EmployeeId);

            var scheme = GetScheme(employee, orderDetails.Day);

            var newScheme = new Scheme() { TimeQuarters = new List<TimeQuarter>() };

            foreach (var quarter in scheme.TimeQuarters)
            {
                if (!quarter.IsBooked)
                    newScheme.TimeQuarters.Add(quarter);
            }

            return newScheme;
        }
        public Scheme GetNearestTimeIntervallScheme(OrderDetails orderDetails)
        {
            orderDetails.Day = DateTime.Today;
            var scheme = new Scheme { TimeQuarters = new List<TimeQuarter>() };
            while (scheme.TimeQuarters.Count <= 5)
            {
                var kurt = GetsAIntervallScheme(orderDetails);
                foreach (var quarters in kurt.TimeQuarters)
                {
                    if (scheme.TimeQuarters.Count <= 5)
                    {
                        scheme.TimeQuarters.Add(quarters);
                    }

                }
                orderDetails.Day.AddDays(1);
            }
            return scheme;
        }

        public Scheme GetsAIntervallScheme(OrderDetails orderDetails)
        {
            var scheme = GetUnBookedSchemeFromEmployee(orderDetails);
            var requiredTime = GetRequiredTimeForOrder(orderDetails);

            var newScheme = new Scheme() { TimeQuarters = new List<TimeQuarter>() };

            for (int i = 0; i < scheme.TimeQuarters.Count; i++)
            {
                int quarterAmount = requiredTime / 15;

                bool exists = true;

                for (int j = 0, k = 0; j < quarterAmount; j++, k += 15)
                {
                    try
                    {
                        var holder = scheme.TimeQuarters[i + j];
                        if (holder.Time != scheme.TimeQuarters[i].Time.AddMinutes(k))
                            exists = false;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        exists = false;
                    }
                }
                if (exists && scheme.TimeQuarters[i].Time > DateTime.Now)
                    newScheme.TimeQuarters.Add(scheme.TimeQuarters[i]);
            }

            return newScheme;
        }
        public int GetRequiredTimeForOrder(Order order)
        {
            return order.OrderTypes.Select(ot => ot.RequiredTime).Sum();
        }
        public int GetRequiredTimeForOrder(OrderDetails order)
        {
            var x = order.OrderTypes.Select(ot => ot.RequiredTime).Sum();

            return x;
        }
        public List<OrderTypeDTO> GetSelectedOrderTypeDtos(int[] selectedOrderTypes)
        {
            var orderTypesFromDatabase = UnitOfWork.OrderTypeRepository.Get().ToList().ConverToOrderTypeDtos();
            return selectedOrderTypes
                .Select(orderTypes => orderTypesFromDatabase
                .First(x => x.Id == orderTypes))
                .ToList();
        }
        public bool PostOrderToDatabase(BookingModel bookingModel, List<OrderType> selectedOrderTypes)
        {
            return UnitOfWork.OrderRepository.Create(EntityConverter.ConvertBookingModelToOrder(bookingModel, selectedOrderTypes));
        }


        public List<OrderType> GetOrderTypesById(int[] selectedOrderTypes)
        {
            var orderTypesFromDatabase = UnitOfWork.OrderTypeRepository.Get().ToList();

            return selectedOrderTypes.Select(orderType => orderTypesFromDatabase.First(x => x.Id == orderType)).ToList();
        }
    }
}