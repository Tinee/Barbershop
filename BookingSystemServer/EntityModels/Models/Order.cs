using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        public int CustomerId { get; set; } 
        public virtual Employee Employee { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BookedDate { get; set; }
        [Required]
        public bool IsBooked { get; set; }
        public virtual ICollection<OrderType> OrderTypes { get; set; }
    }
}
