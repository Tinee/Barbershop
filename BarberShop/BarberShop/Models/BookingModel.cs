using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace BarberShop.Models
{
    public class BookingModel
    {
        [Required]
        public int EmployeeId { get; set; }

        public int CustomerId { get; set; }
        public DateTime Day { get; set; }
        [Required]
        public int[] SelectedOrderTypes { get; set; }
        public bool? IsNearestDate { get; set; }
    }
}