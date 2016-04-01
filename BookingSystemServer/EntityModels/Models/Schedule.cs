using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.Models
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Employee Employee { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeOfDayFrom { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeOfDayTo { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }
    }
}
