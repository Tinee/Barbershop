using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BusinessLogicLayout.Functions.EventHandlers;
using EntityModels.DataTransferObject;
using EntityModels.Models;

namespace WebApi.Controllers
{
    public class BookingController : ApiController
    {
        BookingHandler bookingHandler = new BookingHandler();

        public Scheme Get([FromUri]BookingModel bookingmodel)
        {
            var orderTypes = bookingHandler.GetSelectedOrderTypeDtos(bookingmodel.SelectedOrderTypes);
            var orderDetail = new OrderDetails()
            {
                Day = bookingmodel.Day,
                EmployeeId = bookingmodel.EmployeeId,
                OrderTypes = orderTypes
            };
            if (bookingmodel.IsNearestDate == true)
            {
                return bookingHandler.GetNearestTimeIntervallScheme(orderDetail);
            }
                return bookingHandler.GetsAIntervallScheme(orderDetail);
        }

        public HttpResponseMessage Post(BookingModel bookingModel)
        {
            var list = bookingHandler.GetOrderTypesById(bookingModel.SelectedOrderTypes);

            return Request.CreateResponse(bookingHandler.PostOrderToDatabase(bookingModel,list)
              ? HttpStatusCode.Accepted
              : HttpStatusCode.InternalServerError);
        }
    }
}
