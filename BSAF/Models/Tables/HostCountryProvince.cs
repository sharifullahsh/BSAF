namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HostCountryProvince
    {
        [Key]
        public int ProvinceId { get; set; }

        public string CountryCode { get; set; }

        public string EnName { get; set; }

        public string DrName { get; set; }

        public string PaName { get; set; }

        public bool IsActive { get; set; }
    }
}
