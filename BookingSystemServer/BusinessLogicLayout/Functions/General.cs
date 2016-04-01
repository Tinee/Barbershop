using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayout.Functions
{
    public static class General
    {
        public static bool IsListNullOrWhiteSpace(this List<string> list)
        {
            return list.Any(string.IsNullOrWhiteSpace);
        } 
        public static bool IsListStringEmpty(this List<string> list )
        {
            return list.Any(string.IsNullOrEmpty);
        }
    }
}