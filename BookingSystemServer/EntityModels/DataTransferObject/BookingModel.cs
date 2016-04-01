using System;

namespace EntityModels.DataTransferObject
{
    public class BookingModel
    {
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; } 
        public DateTime Day { get; set; }
        public int[] SelectedOrderTypes { get; set; }
        public bool? IsNearestDate { get; set; } 
    }
}