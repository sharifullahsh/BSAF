using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace BSAF.Models.Tables
{
    public partial class Beneficiary
    {
        public int BeneficiaryID { get; set; }

        public Guid GUID { get; set; }

        public DateTime? ScreeningDate { get; set; }

        [StringLength(50)]
        public string ProvinceBCP { get; set; }

        [StringLength(50)]
        public string BorderPoint { get; set; }

        [StringLength(50)]
        public string BeneficiaryType { get; set; }

        [StringLength(50)]
        public string ReturnStatus { get; set; }

        [StringLength(50)]
        public string OriginProvince { get; set; }

        public int? OriginDistrict { get; set; }

        [StringLength(200)]
        public string OriginVillage { get; set; }

        [StringLength(50)]
        public string ReturnProvince { get; set; }

        public int? ReturnDistrict { get; set; }

        [StringLength(200)]
        public string ReturnVillage { get; set; }

        [StringLength(50)]
        public string LeavingReason1 { get; set; }

        [StringLength(500)]
        public string LeavingReason1Other { get; set; }

        [StringLength(50)]
        public string LeavingReason2 { get; set; }

        [StringLength(500)]
        public string LeavingReason2Other { get; set; }

        [StringLength(50)]
        public string LeavingReason3 { get; set; }

        [StringLength(500)]
        public string LeavingReason3Other { get; set; }

        public bool? OwnHouse { get; set; }

        [StringLength(50)]
        public string WhereWillLive { get; set; }

        public int? RentPayForAccom { get; set; }

        public string RentPayCurrency { get; set; }

        public bool? AllowForJob { get; set; }

        [StringLength(50)]
        public string CountryOfExile { get; set; }

        [StringLength(50)]
        public string CountryOfExilOther { get; set; }

        [StringLength(50)]
        public string BeforReturnProvince { get; set; }

        public int? BeforReturnDistrictID { get; set; }

        [StringLength(500)]
        public string BeforReturnRemarks { get; set; }

        public bool? FamilyMemStayedBehind { get; set; }

        public int? FamilyMemStayedBehindNo { get; set; }

        public int? LengthOfStayYears { get; set; }

        public int? LengthOfStayMonths { get; set; }

        public int? LengthOfStayDays { get; set; }

        public bool? WouldYouReturn { get; set; }

        public bool? HaveFamilyBenefited { get; set; }

        public DateTime? TransportationDate { get; set; }

        [StringLength(500)]
        public string TransportationInfo { get; set; }

        [StringLength(10)]
        public string TransportAccompaniedBy { get; set; }

        [StringLength(50)]
        public string AccompaniedByMobileNo { get; set; }

        [StringLength(50)]
        public string TopNeed1 { get; set; }

        [StringLength(500)]
        public string TopNeed1Other { get; set; }

        [StringLength(50)]
        public string TopNeed2 { get; set; }

        [StringLength(500)]
        public string TopNeed2Other { get; set; }

        [StringLength(50)]
        public string TopNeed3 { get; set; }

        [StringLength(500)]
        public string TopNeed3Other { get; set; }

        [StringLength(50)]
        public string IntendToDo { get; set; }

        [StringLength(500)]
        public string IntendToDoOther { get; set; }

        public bool? HoHCanReadWrite { get; set; }

        [StringLength(50)]
        public string HoHEducationLevel { get; set; }

        [StringLength(300)]
        public string HoHEducationLevelOther { get; set; }

        public int? NumHHHaveTaskira { get; set; }

        public int? NumHHHavePassport { get; set; }

        public int? NumHHHaveOther { get; set; }

        public bool? DoHaveSecureLivelihood { get; set; }

        public bool? DidChildrenGoToSchoole { get; set; }

        public int? NumChildrenAttendedSchoole { get; set; }

        public int InsertedBy { get; set; }

        public DateTime InsertedDate { get; set; }

        public int? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        [StringLength(300)]
        public string InsertedLocationCode { get; set; }

        public bool IsActive { get; set; }
    }
}
