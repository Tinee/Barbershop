using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.Models
{
    public class OrderType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int RequiredTime { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
