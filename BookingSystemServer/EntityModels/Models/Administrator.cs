using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels.Models
{
    public class Administrator : User
    {
        public Administrator()
        {
            Permission = PermissionType.Administrator;
        }
    }
}
