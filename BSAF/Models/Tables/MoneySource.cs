namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MoneySource
    {
        public int ID { get; set; }

        public int? BeneficiaryID { get; set; }

        [StringLength(50)]
        public string MoneySourceCode { get; set; }

        [StringLength(500)]
        public string MoneySourceOther { get; set; }
    }
}
