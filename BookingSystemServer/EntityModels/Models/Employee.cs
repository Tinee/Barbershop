using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.Models
{
   public class Employee : User
    {
       public virtual ICollection<Order> Orders { get; set; }
       public virtual ICollection<Schedule> Schedules { get; set; } 
       public Employee()
       {
           Permission = PermissionType.Employee;
       }
    }
}
