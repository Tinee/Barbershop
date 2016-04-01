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
    public class AbsenceController : ApiController
    {
        AbsenceHandler absenceHandler = new AbsenceHandler();

        public List<AbsenceDTO> GetAbsences(int scheduleId)
        {
            return absenceHandler.GetAbsences(scheduleId);
        }

        public HttpResponseMessage PostNewAbsence(AbsencePostForm absence)
        {
            if (absenceHandler.CreateNewAbsence(absence))
                return new HttpResponseMessage(HttpStatusCode.Created);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}
