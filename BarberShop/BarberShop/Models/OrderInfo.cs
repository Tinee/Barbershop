using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarberShop.Models
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime BookedDate { get; set; }
        public string EmployeeName { get; set; }
        public string CustomerName { get; set; }
        public List<string> OrderTypes { get; set; }
        public int amountOfRequiredTime { get; set; }
    }
}