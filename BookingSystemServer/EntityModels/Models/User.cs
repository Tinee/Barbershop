using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.Models
{
    public abstract class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(128,MinimumLength = 5,ErrorMessage = "Email needs to be between 5-128 characters.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid format of Email.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Salt { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 1,ErrorMessage = "Firstname needs to be between 1-50 characters.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Lastname needs to be between 1-50 characters.")]
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public PermissionType Permission { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime LastLoggedIn { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }
    }
}
