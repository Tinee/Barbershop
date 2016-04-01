using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using BarberShop.Models;
using BarberShop.Values;
using Microsoft.Ajax.Utilities;
using WebGrease;

namespace BarberShop.Controllers
{
    public class BookingController : Controller
    {
        public ActionResult Index(BookingModel bookingModel, DateTime? orderTime = null)
        {
            if (Session[Sessions.UserLogin] == null)
              return  RedirectToAction("Login", "Account");
            if (Session[Sessions.BookingModel] != null && orderTime != null)
            {
                var user = Session[Sessions.UserLogin] as UserModel;                                  
                var sessionBookingModel = Session[Sessions.BookingModel] as BookingModel;
                sessionBookingModel.Day = orderTime.Value;
                sessionBookingModel.CustomerId = user.Id;
                using (var client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync(Routes.PostOrder, sessionBookingModel)
                        .Result
                        .StatusCode;

                         ViewBag.OrderResult = result == HttpStatusCode.Accepted 
                             ? "Klipptid bokad." 
                             : "Nånting gick fel.";
                }
            }

            using (var client = new HttpClient())
            {
                var employees = client.GetAsync(Routes.GetEmployeeList)
                    .Result
                    .Content
                    .ReadAsAsync<List<UserModel>>()
                    .Result;
                ViewBag.employees = employees;

                var orderTypes = client.GetAsync(Routes.GetOrderTypes)
                    .Result
                    .Content
                    .ReadAsAsync<List<OrderType>>()
                    .Result;
                ViewBag.OrderTypes = orderTypes;
            }

            if (bookingModel.SelectedOrderTypes != null)
            {
                Session[Sessions.BookingModel] = bookingModel;
                var selectedOrderTypes = "";
                foreach (var orderType in bookingModel.SelectedOrderTypes)
                {
                    selectedOrderTypes += "&selectedOrderTypes[]=" + orderType;
                }

                var data = "?employeeId=" + bookingModel.EmployeeId +
                           selectedOrderTypes + "&day=" + bookingModel.Day + "&IsNearestDate=" +
                           bookingModel.IsNearestDate;

                using (var client = new HttpClient())
                {
                    var availableTime = client.GetAsync(Routes.GetScheme + data).Result.Content.ReadAsAsync<Scheme>().Result;
                    return View(availableTime);
                }
            }
            return View();
        }
        public ActionResult MySchemes(DateTime? schemeDay,int? employeeId)
        {
            if ((employeeId != null && schemeDay != null))
            {
                using (var client = new HttpClient())
                {
                    
                    var data = "?employeeId=" + employeeId + "&day=" + schemeDay;
                    var orders = client.GetAsync(Routes.GetOrdersByDate + data)
                        .Result
                        .Content
                        .ReadAsAsync<List<OrderInfo>>()
                        .Result;
                    return View(orders);
                }
            }
           return View();
        }
    }
}