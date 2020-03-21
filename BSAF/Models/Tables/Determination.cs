namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Determination
    {
        public int ID { get; set; }

        public int? BeneficiaryID { get; set; }

        [StringLength(50)]
        public string DeterminationCode { get; set; }

        [StringLength(50)]
        public string AnswerCode { get; set; }

        public string Other { get; set; }
    }
}
