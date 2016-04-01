using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.Models
{
    public class Customer : User
    {
        public virtual ICollection<Order> Orders { get; set; }
        public Customer()
        {
            Permission = PermissionType.Customer;
        }
    }
}
