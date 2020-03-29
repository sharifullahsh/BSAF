using BSAF.Entity;
using BSAF.Models.Tables;
using BSAF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BSAF.Helper
{
    public class BeneficiaryController
    {
        public static bool Add(BeneficiaryVM model)
        {
            dbContext db = new dbContext();
       
            var bene = model;
            if(string.IsNullOrEmpty(UserInfo.ID) && string.IsNullOrEmpty(UserInfo.StationCode))
            {
                return false;
            }
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
                        InsertedBy = UserInfo.ID,
                        InsertedDate = DateTime.Now,
                        StationCode = UserInfo.StationCode,
                        //END TODO
                        IsActive = true
                    };
                    db.Beneficiaries.Add(beneficiary);
                    db.SaveChanges();

                    foreach(var ind in model.Individuals)
                    {
                        var member = new Individual {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            Name = ind.Name,
                            DrName = ind.DrName,
                            FName = ind.FName,
                            DrFName = ind.DrFName,
                            GenderCode = ind.GenderCode,
                            MaritalStatusCode = ind.MaritalStatusCode,
                            Age = ind.Age,
                            IDTypeCode = ind.IDTypeCode,
                            IDNo = ind.IDNo,
                            RelationshipCode = ind.RelationshipCode,
                            ContactNumber = ind.ContactNumber,
                            IsActive = true,
                            InsertedBy = UserInfo.ID,
                            InsertedDate = DateTime.Now,
                            
                        };
                        db.Individuals.Add(member);
                    }

                    foreach(var psn in model.PSNs)
                    {
                        var psnObj = new PSN {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            PSNCode = psn.PSNCode,
                            PSNOther = psn.PSNOther
                        };
                        db.PSNs.Add(psnObj);
                    }

                    foreach (var rReason in model.ReturnReasons)
                    {
                        var rrObj = new ReturnReason {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            ReasonCode = rReason.ReasonCode,
                            Other = rReason.Other
                        };
                        db.ReturnReasons.Add(rrObj);
                    }

                    foreach(var d in model.Determinations)
                    {
                        var dObj = new Determination {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            DeterminationCode = d.DeterminationCode,
                            AnswerCode = d.AnswerCode,
                            Other = d.Other
                        };
                        db.Determinations.Add(dObj);
                    }

                    foreach(var m in model.MoneySources)
                    {
                        var moneySObj = new MoneySource {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            MoneySourceCode = m.MoneySourceCode,
                            MoneySourceOther = m.MoneySourceOther
                        };
                        db.MoneySources.Add(moneySObj);
                    }

                    foreach(var bi in model.BroughtItems)
                    {
                        var biObj = new BroughtItem {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            ItemCode = bi.ItemCode,
                            ItemOther = bi.ItemOther
                        };
                        db.BroughtItems.Add(biObj);
                    }

                    foreach (var p in model.PostArrivalNeeds) {
                        var panObj = new PostArrivalNeed {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            NeedCode = p.NeedCode,
                            Provided = p.Provided,
                            ProvidedDate = p.ProvidedDate,
                            Comment = p.Comment
                        };
                        db.PostArrivalNeeds.Add(panObj);
                    }

                    if(model.HaveFamilyBenefited == true)
                    {
                        foreach(var a in model.BenefitedFromOrgs)
                        {
                            var assisOrgInfo = new BenefitedFromOrg
                            {
                                BeneficiaryID = beneficiary.BeneficiaryID,
                                Date = a.Date,
                                ProvinceCode = a.ProvinceCode,
                                DistrictID = a.DistrictID,
                                Village = a.Village,
                                OrgCode = a.OrgCode,
                                AssistanceProvided = a.AssistanceProvided
                            };
                            db.BenefitedFromOrgs.Add(assisOrgInfo);
                        }
                    }

                    foreach (var tran  in model.Transportations)
                    {
                        var tranObj = new Transportation {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            TypedCode = tran.TypedCode,
                            Other = tran.Other
                        };
                        db.Transportations.Add(tranObj);
                    }

                    foreach (var li in model.LivelihoodEmpNeeds)
                    {
                        var liObj = new LivelihoodEmpNeed{
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            NeedCode = li.NeedCode
                        };
                        db.LivelihoodEmpNeeds.Add(liObj);
                    }

                    foreach (var needTool in model.NeedTools)
                    {
                        var needToolObj = new NeedTool {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            ToolCode = needTool.ToolCode,
                            Other = needTool.Other
                        };
                        db.NeedTools.Add(needToolObj);
                    }

                    foreach (var mConcern in model.MainConcerns)
                    {
                        var mcObj = new MainConcern {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            ConcernCode = mConcern.ConcernCode
                        };
                        db.MainConcerns.Add(mcObj);
                    }

                    foreach (var hc in model.HostCountrySchools)
                    {
                        var hcObj = new HostCountrySchool {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            SchoolTypeCode = hc.SchoolTypeCode
                        };
                        db.HostCountrySchools.Add(hcObj);
                    }

                    db.SaveChanges();
                    
                    trans.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    return false;
                }
            }

        }

        public static BeneficiaryVM GetBeneficiary(int? beneficiaryID)
        {
            dbContext db = new dbContext();
            BeneficiaryVM benefVM = new BeneficiaryVM();
            if(beneficiaryID != null && beneficiaryID != 0)
            {
                var benefInDB = db.Beneficiaries.Where(b => b.BeneficiaryID == beneficiaryID && b.IsActive == true).FirstOrDefault();
                if (benefInDB != null)
                {
                    benefVM.BeneficiaryID = benefInDB.BeneficiaryID;
                    benefVM.ScreeningDate = benefInDB.ScreeningDate;
                    benefVM.ProvinceBCP = benefInDB.ProvinceBCP;
                    benefVM.BorderPoint = benefInDB.BorderPoint;
                    benefVM.BeneficiaryType = benefInDB.BeneficiaryType;
                    benefVM.ReturnStatus = benefInDB.ReturnStatus;
                    benefVM.OriginProvince = benefInDB.OriginProvince;
                    benefVM.OriginDistrict = benefInDB.OriginDistrict;
                    benefVM.OriginVillage = benefInDB.OriginVillage;
                    benefVM.ReturnProvince = benefInDB.ReturnProvince;
                    benefVM.ReturnDistrict = benefInDB.ReturnDistrict;
                    benefVM.ReturnVillage = benefInDB.ReturnVillage;
                    benefVM.LeavingReason1 = benefInDB.LeavingReason1;
                    benefVM.LeavingReason1Other = benefInDB.LeavingReason1Other;
                    benefVM.LeavingReason2 = benefInDB.LeavingReason2;
                    benefVM.LeavingReason2Other = benefInDB.LeavingReason2Other;
                    benefVM.LeavingReason3 = benefInDB.LeavingReason3;
                    benefVM.LeavingReason3Other = benefInDB.LeavingReason3Other;
                    benefVM.OwnHouse = benefInDB.OwnHouse;
                    benefVM.WhereWillLive = benefInDB.WhereWillLive;
                    benefVM.RentPayForAccom = benefInDB.RentPayForAccom;
                    benefVM.RentPayCurrency = benefInDB.RentPayCurrency;
                    benefVM.AllowForJob = benefInDB.AllowForJob;
                    benefVM.CountryOfExile = benefInDB.CountryOfExile;
                    benefVM.CountryOfExilOther = benefInDB.CountryOfExilOther;
                    benefVM.BeforReturnProvince = benefInDB.BeforReturnProvince;
                    benefVM.BeforReturnDistrictID = benefInDB.BeforReturnDistrictID;
                    benefVM.BeforReturnRemarks = benefInDB.BeforReturnRemarks;
                    benefVM.FamilyMemStayedBehind = benefInDB.FamilyMemStayedBehind;
                    benefVM.FamilyMemStayedBehindNo = benefInDB.FamilyMemStayedBehindNo;
                    benefVM.LengthOfStayYears = benefInDB.LengthOfStayYears;
                    benefVM.LengthOfStayMonths = benefInDB.LengthOfStayMonths;
                    benefVM.LengthOfStayDays = benefInDB.LengthOfStayDays;
                    benefVM.WouldYouReturn = benefInDB.WouldYouReturn;
                    benefVM.HaveFamilyBenefited = benefInDB.HaveFamilyBenefited;
                    benefVM.TransportationDate = benefInDB.TransportationDate;
                    benefVM.TransportationInfo = benefInDB.TransportationInfo;
                    benefVM.TransportAccompaniedBy = benefInDB.TransportAccompaniedBy;
                    benefVM.TransportAccomByNo = benefInDB.TransportAccomByNo;
                    benefVM.TopNeed1 = benefInDB.TopNeed1;
                    benefVM.TopNeed1Other = benefInDB.TopNeed1Other;
                    benefVM.TopNeed2 = benefInDB.TopNeed2;
                    benefVM.TopNeed2Other = benefInDB.TopNeed2Other;
                    benefVM.TopNeed3 = benefInDB.TopNeed3;
                    benefVM.TopNeed3Other = benefInDB.TopNeed3Other;
                    benefVM.IntendToDo = benefInDB.IntendToDo;
                    benefVM.IntendToDoOther = benefInDB.IntendToDoOther;
                    benefVM.ProfessionInHostCountry = benefInDB.ProfessionInHostCountry;
                    benefVM.ProfessionInHostCountryOther = benefInDB.ProfessionInHostCountryOther;
                    benefVM.HoHCanReadWrite = benefInDB.HoHCanReadWrite;
                    benefVM.HoHEducationLevel = benefInDB.HoHEducationLevel;
                    benefVM.HoHEducationLevelOther = benefInDB.HoHEducationLevelOther;
                    benefVM.NumHHHaveTaskira = benefInDB.NumHHHaveTaskira;
                    benefVM.NumHHHavePassport = benefInDB.NumHHHavePassport;
                    benefVM.NumHHHaveDocOther = benefInDB.NumHHHaveDocOther;
                    benefVM.DoHaveSecureLivelihood = benefInDB.DoHaveSecureLivelihood;
                    benefVM.DidChildrenGoToSchoole = benefInDB.DidChildrenGoToSchoole;
                    benefVM.NumChildrenAttendedSchoole = benefInDB.NumChildrenAttendedSchoole;
                }

                List<IndividualVM> individualsInDB = db.Individuals.
                    Where(i => i.BeneficiaryID == beneficiaryID && i.IsActive == true).Select(i =>
                    new IndividualVM {
                        IndividualID = i.IndividualID,
                        BeneficiaryID = i.BeneficiaryID,
                        Name = i.Name,
                        DrName = i.DrName,
                        FName = i.FName,
                        DrFName = i.DrFName,
                        GenderCode = i.GenderCode,
                        Gender = db.LookupValues.Where(l => l.ValueCode == i.GenderCode).Select(l =>l.EnName).FirstOrDefault(),
                        MaritalStatusCode = i.MaritalStatusCode,
                        MaritalStatus = db.LookupValues.Where(l => l.ValueCode == i.MaritalStatusCode).Select(l => l.EnName).FirstOrDefault(),
                        Age = i.Age,
                        IDTypeCode = i.IDTypeCode,
                        IDType = db.LookupValues.Where(l => l.ValueCode == i.IDTypeCode).Select(l => l.EnName).FirstOrDefault(),
                        IDNo = i.IDNo,
                        RelationshipCode = i.RelationshipCode,
                        Relationship = db.LookupValues.Where(l => l.ValueCode == i.RelationshipCode).Select(l => l.EnName).FirstOrDefault(),
                        ContactNumber = i.ContactNumber
                    }).ToList();
                benefVM.Individuals = individualsInDB;

                var psnInDB = db.PSNs.Where(p => p.BeneficiaryID == beneficiaryID).ToList();
                benefVM.PSNs = psnInDB;

                var returnReasonsInDB = db.ReturnReasons.Where(r => r.BeneficiaryID == beneficiaryID).ToList();
                benefVM.ReturnReasons = returnReasonsInDB;

                var determinationsInDB = db.Determinations.Where(d=> d.BeneficiaryID == beneficiaryID).ToList();
                benefVM.Determinations = determinationsInDB;

                var moneySourcesInDB = db.MoneySources.Where(m => m.BeneficiaryID == beneficiaryID).ToList();
                benefVM.MoneySources = moneySourcesInDB;

                var broughtItemsInDB = db.BroughtItems.Where(b => b.BeneficiaryID == beneficiaryID).ToList();
                benefVM.BroughtItems = broughtItemsInDB;

                var postArivalNeedsInDB = db.PostArrivalNeeds.Where(p => p.BeneficiaryID == beneficiaryID).ToList();
                benefVM.PostArrivalNeeds = postArivalNeedsInDB;

                var transportsInDB = db.Transportations.Where(t => t.BeneficiaryID == beneficiaryID).ToList();
                benefVM.Transportations = transportsInDB;

                var livelihoodNeedsInDB = db.LivelihoodEmpNeeds.Where(l => l.BeneficiaryID == beneficiaryID).ToList();
                benefVM.LivelihoodEmpNeeds = livelihoodNeedsInDB;

                var needToolsInDB = db.NeedTools.Where(b => b.BeneficiaryID == beneficiaryID).ToList();
                benefVM.NeedTools = needToolsInDB;

                var mainConcernsInDB = db.MainConcerns.Where(m => m.BeneficiaryID == beneficiaryID).ToList();
                benefVM.MainConcerns = mainConcernsInDB;

                var hostCountryShoolsInDB = db.HostCountrySchools.Where(s => s.BeneficiaryID == beneficiaryID).ToList();
                benefVM.HostCountrySchools = hostCountryShoolsInDB;
            }
            return benefVM;
        }
    }
}
