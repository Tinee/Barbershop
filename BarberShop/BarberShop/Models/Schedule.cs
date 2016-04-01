using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarberShop.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }
        [DataType(DataType.Time)]
        public DateTime TimeOfDayFrom { get; set; }
        [DataType(DataType.Time)]
        public DateTime TimeOfDayTo { get; set; }
    }
}