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
            var id = $@"{prefix}{String.Format("{0:00000}", number)}";
            return id;
        }
    }
}
