using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        [DisplayName("Stad")]
        public string City { get; set; }
        public string Adress { get; set; }
        [DisplayName("Postkod")]
        public string ZipCode { get; set; }
        [DisplayName("Telefonnummer")]
        public string Phone { get; set; }
        public PermissionType PermissionType { get; set; }
        [DisplayName("Senast Inloggad")]
        public DateTime LastLoggedIn { get; set; }
        [DisplayName("Registreringsdatum")]
        public DateTime RegisterDate { get; set; }
    }
}