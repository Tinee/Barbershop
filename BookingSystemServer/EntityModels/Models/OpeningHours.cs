using System;
using System.ComponentModel.DataAnnotations;                    

namespace EntityModels.Models
{
    public class OpeningHours
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime TimeFrom { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime TimeTo { get; set; }
    }
}