using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.Models
{
    public class Absence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Schedule Schedule { get; set; }
        [Required]
        public int ScheduleId { get; set; } 
        public virtual AbsenceType AbsenceType { get; set; }
        [Required]
        public int AbsenceTypeId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateFrom { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataTo { get; set; }
    }
}
