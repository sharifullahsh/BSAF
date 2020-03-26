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

        public string BCPCode { get; set; }

        public int VillageId { get; set; }

        public string DistrictCode { get; set; }

        public string ProvinceCode { get; set; }

        public string NeighCountryCode { get; set; }

        public string EnName { get; set; }

        public string DrName { get; set; }

        public string PaName { get; set; }

        public bool IsActive { get; set; }
    }
}
