using System.Collections.Generic;
using System.Linq;
using DbConnector.DataAccessLayer;
using EntityModels.Models;

namespace BusinessLogicLayout.Functions.DataHandlers
{
    public class DatabaseHandler
    {
        private UnitOfWork unitOfWork;
        public DatabaseHandler(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool IsEmailInDatabase(string email)
        {
           var user = unitOfWork.UserRepository.Get(x => x.Email == email).FirstOrDefault();
          return user != null;
        } 
    }
}