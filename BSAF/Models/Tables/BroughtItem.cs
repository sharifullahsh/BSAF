namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BroughtItem
    {
        public int ID { get; set; }

        public int? BeneficiaryID { get; set; }

        [StringLength(50)]
        public string ItemCode { get; set; }

        [StringLength(500)]
        public string ItemOther { get; set; }
    }
}
