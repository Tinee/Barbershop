using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.DataTransferObject
{
    public class AbsenceDTO
    {
        public int Id { get; set; }
        public string AbsenceTypeName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int ScheduleId { get; set; }
    }
}
