namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSN")]
    public partial class PSN
    {
        public int ID { get; set; }

        public int? BeneficiaryID { get; set; }

        public string PSNCode { get; set; }

        public string PSNOther { get; set; }
    }
}
