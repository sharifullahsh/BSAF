﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Models.Tables
{
    public class ReturnReason
    {
        [Key]
        public int ID { get; set; }

        public int BeneficiaryID { get; set; }

        public string ReasonCode { get; set; }

        public string Other { get; set; }
    }
}
