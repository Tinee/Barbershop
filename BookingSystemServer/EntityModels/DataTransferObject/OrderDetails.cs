using System;
using System.Collections.Generic;
using EntityModels.Models;

namespace EntityModels.DataTransferObject
{
    public class OrderDetails
    {
        public int EmployeeId { get; set; } 
        public DateTime Day { get; set; }
        public List<OrderTypeDTO> OrderTypes  { get; set; }
    }
}