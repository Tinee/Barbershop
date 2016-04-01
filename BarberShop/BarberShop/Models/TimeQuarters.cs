using System;

namespace BarberShop.Models
{
    public class TimeQuarters
    {
        public DateTime Time { get; set; }
        public bool IsBooked { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Time);
        }
    }
}