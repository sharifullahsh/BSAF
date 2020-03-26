namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HostCountrySchool")]
    public partial class HostCountrySchool
    {
        public int ID { get; set; }

        public int BeneficiaryID { get; set; }

        [Required]
        public string SchoolTypeCode { get; set; }
    }
}
