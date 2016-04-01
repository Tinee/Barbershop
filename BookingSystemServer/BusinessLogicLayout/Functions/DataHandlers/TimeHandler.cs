using System;
using System.Collections.Generic;
using EntityModels.DataTransferObject;

namespace BusinessLogicLayout.Functions.DataHandlers
{
    public static class TimeHandler
    {
        public static List<TimeQuarter> GetTimeQuartersFromDay(DateTime date, DateTime timeFrom, DateTime timeTo)
        {
            var quarterList = new List<TimeQuarter>();
            var timeDifference = (timeTo - timeFrom).TotalMinutes;

            for (var i = 0; i < timeDifference; i += 15)
            {
                quarterList.Add(new TimeQuarter()
                {
                    Time = new DateTime(date.Year, date.Month, date.Day,
                        timeFrom.Hour, timeFrom.Minute, 0).AddMinutes(i),
                    IsBooked = false
                });
            }
            return quarterList;
        }
    }
}