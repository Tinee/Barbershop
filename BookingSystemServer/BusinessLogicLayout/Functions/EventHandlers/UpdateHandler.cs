using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BusinessLogicLayout.Functions.DataHandlers;
using EntityModels.DataTransferObject;
using EntityModels.Models;

namespace BusinessLogicLayout.Functions.EventHandlers
{
    public class UpdateHandler : EntityHandler
    { 
      
        public UpdateHandler()
        {
            
        }

        public UpdateHandler(UnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        public List<OrderInfo> GetOrderInfo(int customerId)
        {
            var orders = UnitOfWork.OrderRepository.Get(o => o.Id == customerId).OrderBy(o => o.BookedDate).ToList();

            return orders.ConvertOrderToOrderInfo();
        } 

        public List<OrderInfo> GetLatestOrderInfo(int customerId)
        {
            var orders = UnitOfWork.OrderRepository.Get(o => o.CustomerId == customerId && o.IsBooked == true && o.BookedDate >= DateTime.Now).OrderBy(o => o.BookedDate).Take(10).ToList();

            return orders.ConvertOrderToOrderInfo();
        } 
        public List<OrderInfo> GetOrderByDate(int employeeId,DateTime day)
        {
            return UnitOfWork.OrderRepository.Get().Where(x => x.BookedDate.Day == day.Day && x.EmployeeId == employeeId).ToList().ConvertOrderToOrderInfo();  
        } 

        public User UpdateLastLoggedIn(User user)
        {
            user.LastLoggedIn = DateTime.Now;
            UnitOfWork.UserRepository.Edit(user);
            return user;
        }

        public bool UnbookOrder(int id)
        {
            var order = UnitOfWork.OrderRepository.GetById(id);
            order.IsBooked = false;
            return UnitOfWork.OrderRepository.Edit(order);
        }

        public bool UpdateContactInformation(UserDTO user)
        {
            var dataBaseUser = UnitOfWork.UserRepository.GetById(user.Id);

            var list = new List<string>
            {
                user.FirstName,        
                user.Phone,
                user.LastName,
            };

            if (list.IsListStringEmpty()) return false;
            
            dataBaseUser.FirstName = user.FirstName;
            dataBaseUser.Adress = user.Adress;
            dataBaseUser.ZipCode = user.ZipCode;
            dataBaseUser.Phone = user.Phone;
            dataBaseUser.LastName = user.LastName;
            dataBaseUser.City = user.City;
            return UnitOfWork.UserRepository.Edit(dataBaseUser);

        }

        public bool ChangePasswordInDatabase(PasswordModel passwordModel)
        {
          var user =  UnitOfWork.UserRepository.GetById(passwordModel.Id);

          if (!passwordModel.OldPassword.GenerateHash(user.Salt).Equals(user.Password)) return false;
          var hashedPassword = passwordModel.NewPassword.GenerateHash(user.Salt);
          user.Password = hashedPassword;
          return UnitOfWork.UserRepository.Edit(user);
        }
    }
}