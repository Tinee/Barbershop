using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BarberShop.Models;
using BarberShop.Values;

namespace BarberShop.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index(RegisterModel registerUser = null, string repeatPassword = null)
        {
            var userLogin = Session[Sessions.UserLogin] as UserModel;

            registerUser.PermissionType = userLogin.PermissionType == PermissionType.Administrator 
                ? PermissionType.Employee 
                : PermissionType.Customer;
            
                
            
            if (!ModelState.IsValid)
                return View(registerUser);
            if (registerUser.Email == null)
                return View();

            if (registerUser.Password != repeatPassword)
            {
                ViewBag.PasswordIsNotEqual = "Lösenorden stämmer inte överens";
                return View();
            }
            var client = new HttpClient();
            var result = client.PostAsJsonAsync(Routes.RegisterApiRoute, registerUser)
                .Result.StatusCode;

            ViewBag.RegisterResult = result == HttpStatusCode.Created
                ? "Regristrering Lyckades, var vänligen logga in."
                : "Nånting gick fel, var vänligen fyll i alla fält korrekt";

            return View();

        }
    }
}