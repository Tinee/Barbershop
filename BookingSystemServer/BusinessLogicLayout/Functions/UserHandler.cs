using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayout.Functions.DataHandlers;
using DbConnector.DataAccessLayer;
using DbConnector.Repositories;
using EntityModels.DataTransferObject;
using EntityModels.Models;


namespace BusinessLogicLayout.Functions
{
    public class UserHandler : EntityHandler
    {   
        public List<UserDTO> GetList()
        {
            return UnitOfWork.UserRepository.Get().ToList().ConvertToUserDto();
        }
        public List<UserDTO> GetEmployeeList()
        {
            return UnitOfWork.EmployeeRepository.Get().Where(x => x.Schedules.Count > 0).ToList().ConvertToUseDto();
        } 
    }
}