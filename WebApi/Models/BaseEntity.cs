using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
