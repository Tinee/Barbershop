using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.DataTransferObject
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime TimeOfDayFrom { get; set; }
        public DateTime TimeOfDayTo { get; set; }
    }
}
