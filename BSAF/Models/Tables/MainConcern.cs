namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MainConcern
    {
        public int ID { get; set; }

        public int BeneficiaryID { get; set; }

        [Required]
        public string ConcernCode { get; set; }

        public string Other { get; set; }
    }
}
