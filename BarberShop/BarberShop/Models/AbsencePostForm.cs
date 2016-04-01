using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarberShop.Models
{
    public class AbsencePostForm
    {
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public int Schedule { get; set; }
        [Required]
        public int AbsenceTypeId { get; set; }
    }
}