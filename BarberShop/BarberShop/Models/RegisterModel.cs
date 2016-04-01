using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "failed")]
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Lösenord")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        [DisplayName("Stad")]
        public string City { get; set; }
        public string Adress { get; set; }
        [DisplayName("Postkod")]
        public string ZipCode { get; set; }
        [Required]
        [DisplayName("Telefonnummer")]
        [DataType(DataType.PhoneNumber,ErrorMessage = "Fyll i telefonnumret rätt")]
        public string Phone { get; set; }

        public PermissionType PermissionType { get; set; }
    }
}