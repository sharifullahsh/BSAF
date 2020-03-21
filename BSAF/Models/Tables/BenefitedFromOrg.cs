namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BenefitedFromOrg
    {
        public int ID { get; set; }

        public int BeneficiaryID { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(50)]
        public string ProvinceCode { get; set; }

        public int? DistrictID { get; set; }

        [StringLength(300)]
        public string Village { get; set; }

        [Required]
        [StringLength(50)]
        public string OrgCode { get; set; }

        [StringLength(500)]
        public string AssistanceProvided { get; set; }
    }
}
