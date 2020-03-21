namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Province
    {
        public int ProvinceId { get; set; }

        [StringLength(100)]
        public string ProvinceCode { get; set; }

        [StringLength(100)]
        public string MapCode { get; set; }

        [StringLength(300)]
        public string EnName { get; set; }

        [StringLength(300)]
        public string DrName { get; set; }

        [StringLength(300)]
        public string PaName { get; set; }

        public bool IsActive { get; set; }
    }
}
