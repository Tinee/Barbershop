using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayout.Functions.EventHandlers;
using EntityModels.DataTransferObject;

namespace WebApi.Controllers
{
    public class ScheduleController : ApiController
    {
        AbsenceHandler absenceHandler = new AbsenceHandler();
        public List<ScheduleDTO> GetAllSchedules(int employeeId)
        {
            return absenceHandler.GetSchedules(employeeId);
        }

        public HttpResponseMessage PostNewSchedule(SchedulePostForm schedule)
        {
            if(absenceHandler.CreateSchedule(schedule))
                return new HttpResponseMessage(HttpStatusCode.Created);
            else 
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}
