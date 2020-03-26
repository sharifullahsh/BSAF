namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LivelihoodEmpNeed
    {
        public int ID { get; set; }

        [Required]
        public string NeedCode { get; set; }

        public int BeneficiaryID { get; set; }
    }
}
