using System;
using EntityModels.Models;
                                            
namespace EntityModels.DataTransferObject
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public PermissionType PermissionType { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public DateTime RegisterDate { get; set; }

    }
}