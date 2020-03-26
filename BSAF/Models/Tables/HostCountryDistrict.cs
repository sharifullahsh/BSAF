using System.ComponentModel.DataAnnotations;
namespace BSAF.Models.Tables
{
    public partial class HostCountryDistrict
    {
        [Key]
        public int DistrictId { get; set; }

        public int ProvinceId { get; set; }

     
        public string EnName { get; set; }

    
        public string DrName { get; set; }

      
        public string PaName { get; set; }

        public bool IsActive { get; set; }
    }
}
