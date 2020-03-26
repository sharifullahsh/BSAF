namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transportation
    {
        public int ID { get; set; }

        public int? BeneficiaryID { get; set; }

        public string TypedCode { get; set; }

        public string Other { get; set; }
    }
}
