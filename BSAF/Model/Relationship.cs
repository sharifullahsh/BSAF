using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Model
{
    public class Relationship
    {
        [Key]
        public int ID { get; set; }
        public string TypeCode { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
