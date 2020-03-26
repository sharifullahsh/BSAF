namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LeavingReason")]
    public partial class LeavingReason
    {
        public int ID { get; set; }

        public int BeneficiaryID { get; set; }

        [Required]
        public string LeavingReasonCode { get; set; }

        public string LeavingReasonOther { get; set; }
    }
}
