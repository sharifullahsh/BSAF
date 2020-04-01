using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAF
{
  public class CardInfo
    {
        public string Name { get; set; }
        public string LocalName { get; set; }
        public string FatherName { get; set; }
        public string LocalFatherName { get; set; }
        public string BCP { get; set; }
        public string LocalBCP { get; set; }
        public string ReturnStatus { get; set; }
        public string LocalReturnStatus { get; set; }
        public int FamilySize { get; set; }
        public string ReturnAdress { get; set; }
        public string LocalReturnAdress { get; set; }
        public DateTime ReturnDate { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Barcode { get; set; }

    }
}
