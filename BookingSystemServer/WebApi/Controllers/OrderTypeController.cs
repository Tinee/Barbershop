using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayout.Functions;
using EntityModels.DataTransferObject;

namespace WebApi.Controllers
{
    public class OrderTypeController : ApiController
    {
        OrderTypeHandler orderTypeHandler = new OrderTypeHandler();
        public List<OrderTypeDTO> Get()
        {
            return orderTypeHandler.Get();
        } 
    }
}
