using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BusinessLogicLayout.Functions.DataHandlers;
using DbConnector.Repositories;
using EntityModels.DataTransferObject;
using EntityModels.Models;

namespace BusinessLogicLayout.Functions.EventHandlers
{
    public class RegisterHandler : EntityHandler
    {
        private readonly DatabaseHandler DataBaseHandler;

        public RegisterHandler()
        {
            DataBaseHandler = new DatabaseHandler(UnitOfWork);
        }
        public bool AddCustomerToDatabase(UserDTO user)
        {
            var customer = user.ConvertToCustomer();
            if (DataBaseHandler.IsEmailInDatabase(customer.Email)) return false;
            var list = new List<string>
           {
               customer.LastName,
               customer.FirstName,
               customer.Email,
               customer.Phone,
           };
            if (list.IsListNullOrWhiteSpace()) return false;

            customer.Salt = PasswordHandler.CreateSalt();
            customer.Password = customer.Password.GenerateHash(customer.Salt);
            customer.LastLoggedIn = DateTime.Now;
            customer.RegisterDate = DateTime.Now;
            UnitOfWork.CustomerRepository.Create(customer);
            return true;
        }
        public bool AddEmployeeToDatabase(UserDTO user)
        {
            var customer = user.ConvertToEmployee();
            if (DataBaseHandler.IsEmailInDatabase(customer.Email)) return false;
            var list = new List<string>
           {
               customer.LastName,
               customer.FirstName,
               customer.Email,
               customer.Phone,
           };
            if (list.IsListNullOrWhiteSpace()) return false;

            customer.Salt = PasswordHandler.CreateSalt();
            customer.Password = customer.Password.GenerateHash(customer.Salt);
            customer.LastLoggedIn = DateTime.Now;
            customer.RegisterDate = DateTime.Now;
            UnitOfWork.EmployeeRepository.Create(customer);
            return true;
        }

        public bool AddAdminToDatabase(UserDTO user)
        {
            var admin = user.ConvertToAdmin();
            if (DataBaseHandler.IsEmailInDatabase(admin.Email)) return false;
            var list = new List<string>
           {
               admin.LastName,
               admin.FirstName,
               admin.Email,
               admin.Phone,
           };
            if (list.IsListNullOrWhiteSpace()) return false;

            admin.Salt = PasswordHandler.CreateSalt();
            admin.Password = admin.Password.GenerateHash(admin.Salt);
            admin.LastLoggedIn = DateTime.Now;
            admin.RegisterDate = DateTime.Now;
            UnitOfWork.AdministratorRepository.Create(admin);
            return true;
        }
        

    }
}