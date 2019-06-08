using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Helper
{
    public class IdGen
    {
        public static readonly string STOK_PREFIX = "ST";
        public static readonly string OUT_PREFIX = "OUT";
        public static readonly string MATERIAL_PREFIX = "MT";
        
        public static string CreateId(string prefix, int number)
        {
            try
            {
               return $@"{prefix}{String.Format("{0:0000000}", ++number)}";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string CreateId(int number)
        {
            try
            {
               return (++number).ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
