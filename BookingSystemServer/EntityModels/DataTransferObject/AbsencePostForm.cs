using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.DataTransferObject
{
    public class AbsencePostForm
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Schedule { get; set; }
        public int AbsenceTypeId { get; set; }
    }
}
