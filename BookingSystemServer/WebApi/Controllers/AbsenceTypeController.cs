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
    public class AbsenceTypeController : ApiController
    {
        AbsenceHandler absenceHandler = new AbsenceHandler();

        public List<AbsenceTypeDTO> GetAllAbsenceTypes()
        {
            return absenceHandler.GetAbsenceTypes();
        }
    }
}
