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
    public class LoginController : ApiController
    {
        // GET: api/Login
        private readonly LoginHandler _loginHandler = new LoginHandler();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public UserDTO Get(string email, string password)
        {
            return _loginHandler.TryLogin(email, password);
        }

        // POST: api/Login
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
