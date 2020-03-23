using BSAF.Entity;
using BSAF.Models.Tables;
using BSAF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Helper
{
    public class BeneficiaryController
    {
        public static void Save(BeneficiaryVM model)
        {
            dbContext db = new dbContext();

            var bene = model;
            using (var trans = db.Database.BeginTransaction())
            {
                try
                {
                    var beneficiary = new Beneficiary
                    {
                        GUID = Guid.NewGuid(),
                        ScreeningDate = model.ScreeningDate,
                        ProvinceBCP = model.ProvinceBCP,
                        BorderPoint = model.BorderPoint,
                        BeneficiaryType = model.BeneficiaryType,
                        ReturnStatus = model.ReturnStatus,
                        OriginProvince = model.OriginProvince,
                        OriginDistrict = model.OriginDistrict,
                        OriginVillage = model.OriginVillage,
                        ReturnProvince = model.ReturnProvince,
                        ReturnDistrict = model.ReturnDistrict,
                        ReturnVillage = model.ReturnVillage,
                        LeavingReason1 = model.LeavingReason1,
                        LeavingReason1Other = model.LeavingReason1Other,
                        LeavingReason2 = model.LeavingReason2,
                        LeavingReason2Other = model.LeavingReason2Other,
                        LeavingReason3 = model.LeavingReason3,
                        LeavingReason3Other = model.LeavingReason3Other,
                        OwnHouse = model.OwnHouse,
                        WhereWillLive = model.WhereWillLive,
                        RentPayForAccom = model.RentPayForAccom,
                        RentPayCurrency = model.RentPayCurrency,
                        AllowForJob = model.AllowForJob,
                        CountryOfExile = model.CountryOfExile,
                        CountryOfExilOther = model.CountryOfExilOther,
                        BeforReturnProvince = model.BeforReturnProvince,
                        BeforReturnDistrictID = model.BeforReturnDistrictID,
                        BeforReturnRemarks = model.BeforReturnRemarks,
                        FamilyMemStayedBehind = model.FamilyMemStayedBehind,
                        FamilyMemStayedBehindNo = model.FamilyMemStayedBehindNo,
                        LengthOfStayYears = model.LengthOfStayYears,
                        LengthOfStayMonths = model.LengthOfStayMonths,
                        LengthOfStayDays = model.LengthOfStayDays,
                        WouldYouReturn = model.WouldYouReturn,
                        HaveFamilyBenefited = model.HaveFamilyBenefited,
                        TransportationDate = model.TransportationDate,
                        TransportationInfo = model.TransportationInfo,
                        TransportAccompaniedBy = model.TransportAccompaniedBy,
                        TransportAccomByNo = model.TransportAccomByNo,
                        TopNeed1 = model.TopNeed1,
                        TopNeed1Other = model.TopNeed1Other,
                        TopNeed2 = model.TopNeed2,
                        TopNeed2Other = model.TopNeed2Other,
                        TopNeed3 = model.TopNeed3,
                        TopNeed3Other = model.TopNeed3Other,
                        IntendToDo = model.IntendToDo,
                        IntendToDoOther = model.IntendToDoOther,
                        ProfessionInHostCountry = model.ProfessionInHostCountry,
                        ProfessionInHostCountryOther = model.ProfessionInHostCountryOther,
                        HoHCanReadWrite = model.HoHCanReadWrite,
                        HoHEducationLevel = model.HoHEducationLevel,
                        HoHEducationLevelOther = model.HoHEducationLevelOther,
                        NumHHHaveTaskira = model.NumHHHaveTaskira,
                        NumHHHavePassport = model.NumHHHavePassport,
                        NumHHHaveDocOther = model.NumHHHaveDocOther,
                        DoHaveSecureLivelihood = model.DoHaveSecureLivelihood,
                        DidChildrenGoToSchoole = model.DidChildrenGoToSchoole,
                        NumChildrenAttendedSchoole = model.NumChildrenAttendedSchoole,
                        //TODO: add user information from db
                        InsertedBy = 1,
                        InsertedDate = DateTime.Now,
                        InsertedLocationCode = "KBL",
                        //END TODO
                        IsActive = true
                    };
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                }
            }

        }
    }
}
