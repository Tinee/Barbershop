using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarberShop.Models
{
    public class SchedulePostForm
    {
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public DateTime TimeOfDayFrom { get; set; }
        [Required]
        public DateTime TimeOfDayTo { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}