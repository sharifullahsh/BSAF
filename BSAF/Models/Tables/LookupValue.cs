namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LookupValue
    {
        [Key]
        public int ValueId { get; set; }

        public string LookupCode { get; set; }

        public string ValueCode { get; set; }

        public string EnName { get; set; }

        public string DrName { get; set; }

        public string PaName { get; set; }

        public bool IsActive { get; set; }
    }
}
