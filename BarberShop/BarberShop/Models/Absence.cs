using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarberShop.Models
{
    public class Absence
    {
        public int Id { get; set; }
        public string AbsenceTypeName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }
        public int ScheduleId { get; set; }
    }
}