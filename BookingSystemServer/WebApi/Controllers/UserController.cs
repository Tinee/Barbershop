using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using BusinessLogicLayout.Functions;
using BusinessLogicLayout.Functions.EventHandlers;
using EntityModels.DataTransferObject;
using EntityModels.Models;
using Microsoft.Ajax.Utilities;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        UpdateHandler updateHandler = new UpdateHandler();
        UserHandler userHandler = new UserHandler();
        //GET: api/User
        public List<UserDTO> Get()
        {
            return userHandler.GetEmployeeList();
        }

        //GET: api/User/5
        public UserDTO Get(int id)
        {
            var user = new UserDTO();
            return user;
        }

        // POST: api/User
        public HttpResponseMessage Post(UserDTO user)
        {
            var registerHandler = new RegisterHandler();
            if (user.PermissionType == PermissionType.Employee)
            {
                return Request.CreateResponse(registerHandler.AddEmployeeToDatabase(user)
                    ? HttpStatusCode.Created
                    : HttpStatusCode.InternalServerError);
            }


            if (registerHandler.AddCustomerToDatabase(user))

                return Request.CreateResponse(HttpStatusCode.Created);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }
        // PUT: api/User/5
        [ActionName("ChangeInformation")]
        public HttpResponseMessage Put(UserDTO user)
        {
            updateHandler = new UpdateHandler();
            return Request.CreateResponse(updateHandler.UpdateContactInformation(user)
                ? HttpStatusCode.Accepted
                : HttpStatusCode.InternalServerError);
        }
        [ActionName("ChangePassword")]
        public HttpResponseMessage PutChangePassword(PasswordModel passwordModel)
        {
            return Request.CreateResponse(updateHandler.ChangePasswordInDatabase(passwordModel)
            ? HttpStatusCode.Accepted
            : HttpStatusCode.InternalServerError);
        }


        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
