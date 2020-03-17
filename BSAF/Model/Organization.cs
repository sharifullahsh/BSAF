using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Model
{
    public class Organization
    {
        [Key]
        public int ID { get; set; }
        public string OrgCode { get; set; }
        public int Name { get; set; }
        public bool IsActive { get; set; }
    }
}
