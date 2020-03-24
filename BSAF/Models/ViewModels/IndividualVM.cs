using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Models.ViewModels
{
    public class IndividualVM
    {
        [Key]
        public int FamilyMemeberID { get; set; }

        public int? BeneficiaryID { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(200)]
        public string FName { get; set; }

        [StringLength(50)]
        public string GenderCode { get; set; }

        [StringLength(50)]
        public string MaritalStatusCode { get; set; }

        public int? Age { get; set; }

        [StringLength(50)]
        public string IDTypeCode { get; set; }

        [StringLength(100)]
        public string IDNo { get; set; }

        [StringLength(50)]
        public string RelationshipCode { get; set; }

        [StringLength(50)]
        public string ContactNumber { get; set; }
    }
}
