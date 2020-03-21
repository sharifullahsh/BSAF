namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PostArrivalNeed
    {
        public int ID { get; set; }

        public int? BeneficiaryID { get; set; }

        [StringLength(50)]
        public string NeedCode { get; set; }

        public bool? Requested { get; set; }

        public bool? Provided { get; set; }

        public DateTime? ProvidedDate { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }
    }
}
