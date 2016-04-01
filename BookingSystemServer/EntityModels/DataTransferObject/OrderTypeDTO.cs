using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityModels.Models;

namespace EntityModels.DataTransferObject
{
    public class OrderTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RequiredTime { get; set; }
        public decimal Price { get; set; }
    }
}