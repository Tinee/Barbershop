using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayout.Functions.EventHandlers;
using EntityModels.DataTransferObject;
using Microsoft.Ajax.Utilities;

namespace WebApi.Controllers
{
    public class OrderController : ApiController
    {
        UpdateHandler updateHandler = new UpdateHandler();

        [ActionName("GetLatestOrders")]
        public List<OrderInfo> GetLatestOrderInfo(int customerId)
        {
            return updateHandler.GetLatestOrderInfo(customerId);
        }
        [ActionName("GetOrdersByDate")]
        public List<OrderInfo> GetOrdersByDate(int employeeId,DateTime day)
        {
            return updateHandler.GetOrderByDate(employeeId,day);
        }

        [ActionName("GetAllOrders")]
        public List<OrderInfo> GetOrderInfo(int customerId)
        {
            return updateHandler.GetOrderInfo(customerId);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteOrder(int id)
        {
            if (updateHandler.UnbookOrder(id))
                return Request.CreateResponse(HttpStatusCode.Accepted);
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

    }
}
