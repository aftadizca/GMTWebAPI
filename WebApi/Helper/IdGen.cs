using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Helper
{
    public class IdGen
    {
        public static string CreateId(string prefix, int number)
        {
            var id = $@"{prefix}{String.Format("{0:0000000}", number)}";
            return id;
        }
        public static string IncId(string id)
        {
            return (Int64.Parse(id) + 1).ToString();
        }
    }
}
