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

        public string ItemCode { get; set; }

        public string ItemOther { get; set; }
    }
}
