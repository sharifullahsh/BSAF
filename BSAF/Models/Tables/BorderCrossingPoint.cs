namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BorderCrossingPoint
    {
        [Key]
        public int BCPId { get; set; }

        [StringLength(100)]
        public string BCPCode { get; set; }

        public int VillageId { get; set; }

        [StringLength(300)]
        public string DistrictCode { get; set; }

        [StringLength(300)]
        public string ProvinceCode { get; set; }

        [StringLength(300)]
        public string NeighCountryCode { get; set; }

        [StringLength(300)]
        public string EnName { get; set; }

        [StringLength(300)]
        public string DrName { get; set; }

        [StringLength(300)]
        public string PaName { get; set; }

        public bool IsActive { get; set; }
    }
}
