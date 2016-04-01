using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using BarberShop.Models;
using BarberShop.Values;
using Microsoft.Ajax.Utilities;

namespace BarberShop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("Manage");
        }

        public ActionResult Manage(UpdateUserInformationModel user = null)
        {   
            var loggedInUser = Session[Sessions.UserLogin] as UserModel;
            if (loggedInUser == null) return RedirectToAction("Login", "Account");


                using (var client = new HttpClient())
                {
                    var data = "?customerId=" + loggedInUser.Id;

                    var orderInfo = client.GetAsync(Routes.GetLatestOrderInfoRoute + data)
                        .Result
                        .Content
                        .ReadAsAsync<List<OrderInfo>>()
                        .Result;

                    ViewBag.OrderInfo = orderInfo;
                }
            if (user.FirstName == null)
            {

                    return View(loggedInUser);
            }
            user.Id = loggedInUser.Id;

            using (var client = new HttpClient())
            {
                var result = client.PutAsJsonAsync(Routes.UpdateApiRoute, user).Result.StatusCode;

                if (result == HttpStatusCode.Accepted)
                {
                    ViewBag.UpdateResult = "Uppdateringen utfördes";
                    UpdateUserSession(user);
                }
                else
                {
                    ViewBag.UpdateResult = "Nånting gick fel";
                }
                loggedInUser = Session[Sessions.UserLogin] as UserModel;
            }

            
            return View(loggedInUser);
        }

        public ActionResult DeleteOrder(int orderId)
        {
            using (var client = new HttpClient())
            {
                var data = "?id=" + orderId;
                var result = client.DeleteAsync(Routes.DeleteOrder + data).Result.StatusCode;

                if (result == HttpStatusCode.Accepted)
                {
                    ViewBag.OrderDeleted = "Tiden har avbokats.";
                }
                else
                {
                    ViewBag.OrderDeleted = "Någonting gick fel.";
                }
            }

            return RedirectToAction("Manage");
        }

        [Route("Account/ManagePassword")]
        public ActionResult ManagePassword(UpdatePasswordModel userPasswordModel, string newRepeatPassword)
        {
            var loggedInUser = Session[Sessions.UserLogin] as UserModel;
            if (userPasswordModel.NewPassword != newRepeatPassword)
            {
                ViewBag.PasswordError = "Lösenordet matchade inte.";
                return View("Manage", loggedInUser);
            }
            userPasswordModel.Id = loggedInUser.Id;

            var client = new HttpClient();
            var result = client.PutAsJsonAsync(Routes.UpdatePasswordApiRoute, userPasswordModel).Result.StatusCode;

            ViewBag.UpdatePasswordResult = result == HttpStatusCode.Accepted 
                ? "Uppdateringen utfördes" 
                : "Fel lösenord";

            return View("Manage", loggedInUser);
        }

        [Route("Login")]
        public ActionResult Login(LoginModel user = null)
        {
            if (Session[Sessions.UserLogin] != null) RedirectToAction("Index", "Home");

            var data = "?email=" + user.Email + "&password=" + user.Password;
            if ((user.Email == null && user.Password == null)) return View();

            using (var client = new HttpClient())
            {
                var model =
                    client.GetAsync(Routes.LoginApiRoute + data)
                        .Result
                        .Content
                        .ReadAsAsync<UserModel>()
                        .Result;

                if (model == null) return View();

                Session[Sessions.UserLogin] = model;
                return RedirectToAction("Index", "Home");

            }
        }

        public ActionResult Logout()
        {
            Session[Sessions.UserLogin] = null;
            return RedirectToAction("Index", "Home");
        }

        public void UpdateUserSession(UpdateUserInformationModel updatedUser)
        {
            if (updatedUser == null) return;
            var user = Session[Sessions.UserLogin] as UserModel;
            user.Phone = updatedUser.Phone;
            user.City = updatedUser.City;
            user.ZipCode = updatedUser.ZipCode;
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Adress = updatedUser.Adress;
            Session[Sessions.UserLogin] = user;
        }

        public ActionResult Orders()
        {
            var loggedInUser = Session[Sessions.UserLogin] as UserModel;
            if (loggedInUser == null) return RedirectToAction("Login", "Account");

            using (var client = new HttpClient())
            {
                var data = "?customerId=" + loggedInUser.Id;

                var orderInfo = client.GetAsync(Routes.GetLatestOrderInfoRoute + data)
                    .Result
                    .Content
                    .ReadAsAsync<List<OrderInfo>>()
                    .Result;

                ViewBag.OrderInfo = orderInfo;
                return View(orderInfo);
            }

        }

        public ActionResult Schedule()
        {
            var loggedInUser = Session[Sessions.UserLogin] as UserModel;

            if (loggedInUser == null) return RedirectToAction("Login");
            if (loggedInUser.PermissionType != PermissionType.Employee) return RedirectToAction("Index");

            var employeeId = loggedInUser.Id;

            using (var client = new HttpClient())
            {
                var data = "?employeeId=" + employeeId;

                var schedules =
                    client.GetAsync(Routes.GetAllSchedulesRoute + data)
                        .Result
                        .Content
                        .ReadAsAsync<List<Schedule>>()
                        .Result;

                return View(schedules);
            }

        }

        public ActionResult CreateScheme(SchedulePostForm schedule)
        {
            var loggedInUser = Session[Sessions.UserLogin] as UserModel;

            if (loggedInUser == null) return RedirectToAction("Login");
            if (loggedInUser.PermissionType != PermissionType.Employee) return RedirectToAction("Index");

            if (schedule.EmployeeId != 0)
            {
                using (var client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync(Routes.PostNewScheduleRoute, schedule)
                        .Result
                        .StatusCode;

                    return RedirectToAction("Schedule");
                }

            }
            return View();

        }

        public ActionResult Absences(int? scheduleId)
        {
            var loggedInUser = Session[Sessions.UserLogin] as UserModel;
            if (scheduleId == null) return RedirectToAction("Manage");

            ViewBag.ScheduleId = scheduleId;

            if (loggedInUser == null) return RedirectToAction("Login");
            if (loggedInUser.PermissionType != PermissionType.Employee) return RedirectToAction("Index");

            using (var client = new HttpClient())
            {
                var data = "?scheduleId=" + scheduleId;

                var absences = client
                    .GetAsync(Routes.GetAllAbsencesFromSchedule + data)
                    .Result
                    .Content
                    .ReadAsAsync<List<Absence>>()
                    .Result;

                return View(absences);
            }
        }

        public ActionResult CreateAbsence(int? scheduleId)
        {
            var loggedInUser = Session[Sessions.UserLogin] as UserModel;

            if (scheduleId == null) return RedirectToAction("Manage");
            if (loggedInUser == null) return RedirectToAction("Login");
            if (loggedInUser.PermissionType != PermissionType.Employee) return RedirectToAction("Index");

            using (var client = new HttpClient())
            {
                var absenceTypes = client
                    .GetAsync(Routes.GetAllAbsenceTypes)
                    .Result
                    .Content
                    .ReadAsAsync<List<AbsenceType>>()
                    .Result;

                ViewBag.AbsenceTypes = absenceTypes;
            }


            ViewBag.ScheduleId = scheduleId;
            return View();
        }

        [HttpPost]
        [ActionName("CreateAbsence")]
        public ActionResult PostAbsence(AbsencePostForm absence)
        {
            using (var client = new HttpClient())
            {
                var result = client.PostAsJsonAsync(Routes.PostNewAbsence, absence)
                    .Result
                    .StatusCode;
            }

            return RedirectToAction("Absences", new { scheduleId = absence.Schedule });
        }
    }
}