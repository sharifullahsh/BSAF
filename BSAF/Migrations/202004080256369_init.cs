namespace BSAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        StationCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.Beneficiaries",
                c => new
                    {
                        BeneficiaryID = c.Int(nullable: false, identity: true),
                        GUID = c.Guid(nullable: false),
                        ScreeningDate = c.DateTime(nullable: false),
                        ProvinceBCP = c.String(),
                        BorderPoint = c.String(),
                        BeneficiaryType = c.String(),
                        ReturnStatus = c.String(),
                        OriginProvince = c.String(),
                        OriginDistrict = c.Int(),
                        OriginVillage = c.String(),
                        ReturnProvince = c.String(),
                        ReturnDistrict = c.Int(),
                        ReturnVillage = c.String(),
                        LeavingReason1 = c.String(),
                        LeavingReason1Other = c.String(),
                        LeavingReason2 = c.String(),
                        LeavingReason2Other = c.String(),
                        LeavingReason3 = c.String(),
                        LeavingReason3Other = c.String(),
                        OwnHouse = c.Boolean(),
                        WhereWillLive = c.String(),
                        RentPayForAccom = c.Int(),
                        RentPayCurrency = c.String(),
                        AllowForJob = c.Boolean(),
                        CountryOfExile = c.String(),
                        CountryOfExilOther = c.String(),
                        BeforReturnProvince = c.Int(),
                        BeforReturnDistrictID = c.Int(),
                        BeforReturnRemarks = c.String(),
                        FamilyMemStayedBehind = c.Boolean(),
                        FamilyMemStayedBehindNo = c.Int(),
                        LengthOfStayYears = c.Int(),
                        LengthOfStayMonths = c.Int(),
                        LengthOfStayDays = c.Int(),
                        WouldYouReturn = c.Boolean(),
                        HaveFamilyBenefited = c.Boolean(),
                        TransportationDate = c.DateTime(nullable: false),
                        TransportationInfo = c.String(),
                        TransportAccompaniedBy = c.String(),
                        TransportAccomByNo = c.String(),
                        TopNeed1 = c.String(),
                        TopNeed1Other = c.String(),
                        TopNeed2 = c.String(),
                        TopNeed2Other = c.String(),
                        TopNeed3 = c.String(),
                        TopNeed3Other = c.String(),
                        IntendToDo = c.String(),
                        IntendToReturnToHostReason = c.String(),
                        ProfessionInHostCountry = c.String(),
                        ProfessionInHostCountryOther = c.String(),
                        HoHCanReadWrite = c.Boolean(),
                        HoHEducationLevel = c.String(),
                        HoHEducationLevelOther = c.String(),
                        NumHHHaveTaskira = c.Int(),
                        NumHHHavePassport = c.Int(),
                        NumHHHaveDocOther = c.Int(),
                        DoHaveSecureLivelihood = c.Boolean(),
                        DidChildrenGoToSchoole = c.Boolean(),
                        NumChildrenAttendedSchoole = c.Int(),
                        InsertedBy = c.String(),
                        InsertedDate = c.DateTime(nullable: false),
                        LastUpdatedBy = c.String(),
                        LastUpdatedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsSubmitted = c.Boolean(nullable: false),
                        IsCardIssued = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BeneficiaryID);
            
            CreateTable(
                "dbo.BenefitedFromOrgs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeneficiaryID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ProvinceCode = c.String(),
                        DistrictID = c.Int(),
                        Village = c.String(),
                        OrgCode = c.String(nullable: false),
                        AssistanceProvided = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BorderCrossingPoints",
                c => new
                    {
                        BCPId = c.Int(nullable: false, identity: true),
                        BCPCode = c.String(),
                        VillageId = c.Int(nullable: false),
                        DistrictCode = c.String(),
                        ProvinceCode = c.String(),
                        NeighCountryCode = c.String(),
                        EnName = c.String(),
                        DrName = c.String(),
                        PaName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BCPId);
            
            CreateTable(
                "dbo.BroughtItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeneficiaryID = c.Int(),
                        ItemCode = c.String(),
                        ItemOther = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Determinations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeneficiaryID = c.Int(),
                        DeterminationCode = c.String(),
                        AnswerCode = c.String(),
                        Other = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        DistrictCode = c.Int(nullable: false),
                        ProvinceCode = c.String(),
                        EnName = c.String(),
                        DrName = c.String(),
                        PaName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId);
            
            CreateTable(
                "dbo.HostCountryDistricts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        ProvinceId = c.Int(nullable: false),
                        EnName = c.String(),
                        DrName = c.String(),
                        PaName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId);
            
            CreateTable(
                "dbo.HostCountryProvinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(),
                        EnName = c.String(),
                        DrName = c.String(),
                        PaName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinceId);
            
            CreateTable(
                "dbo.HostCountrySchool",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeneficiaryID = c.Int(nullable: false),
                        SchoolTypeCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Individuals",
                c => new
                    {
                        IndividualID = c.Int(nullable: false, identity: true),
                        BeneficiaryID = c.Int(),
                        Name = c.String(),
                        DrName = c.String(),
                        FName = c.String(),
                        DrFName = c.String(),
                        GenderCode = c.String(),
                        MaritalStatusCode = c.String(),
                        Age = c.Int(),
                        IDTypeCode = c.String(),
                        IDNo = c.String(),
                        RelationshipCode = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.IndividualID);
            
            CreateTable(
                "dbo.LivelihoodEmpNeeds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NeedCode = c.String(nullable: false),
                        BeneficiaryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LookupTypes",
                c => new
                    {
                        LookupId = c.Int(nullable: false, identity: true),
                        LookupCode = c.String(),
                        EnName = c.String(),
                        DrName = c.String(),
                        PaName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LookupId);
            
            CreateTable(
                "dbo.LookupValues",
                c => new
                    {
                        ValueId = c.Int(nullable: false, identity: true),
                        LookupCode = c.String(),
                        ValueCode = c.String(),
                        EnName = c.String(),
                        DrName = c.String(),
                        PaName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ValueId);
            
            CreateTable(
                "dbo.MainConcerns",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeneficiaryID = c.Int(nullable: false),
                        ConcernCode = c.String(nullable: false),
                        Other = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MoneySources",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeneficiaryID = c.Int(),
                        MoneySourceCode = c.String(),
                        MoneySourceOther = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NeedTools",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeneficiaryID = c.Int(nullable: false),
                        ToolCode = c.String(nullable: false),
                        Other = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostArrivalNeeds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeneficiaryID = c.Int(),
                        NeedCode = c.String(),
                        Provided = c.Boolean(),
                        ProvidedDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false, identity: true),
                        ProvinceCode = c.String(),
                        MapCode = c.String(),
                        EnName = c.String(),
                        DrName = c.String(),
                        PaName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinceId);
            
            CreateTable(
                "dbo.PSN",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeneficiaryID = c.Int(),
                        PSNCode = c.String(),
                        PSNOther = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReturnReasons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeneficiaryID = c.Int(nullable: false),
                        ReasonCode = c.String(),
                        Other = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Transportations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeneficiaryID = c.Int(),
                        TypedCode = c.String(),
                        Other = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUserAspNetRoles",
                c => new
                    {
                        AspNetUser_Id = c.String(nullable: false, maxLength: 128),
                        AspNetRole_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AspNetUser_Id, t.AspNetRole_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.AspNetRole_Id, cascadeDelete: true)
                .Index(t => t.AspNetUser_Id)
                .Index(t => t.AspNetRole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserLogins", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserAspNetRoles", "AspNetRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserAspNetRoles", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserAspNetRoles", new[] { "AspNetRole_Id" });
            DropIndex("dbo.AspNetUserAspNetRoles", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "AspNetUser_Id" });
            DropTable("dbo.AspNetUserAspNetRoles");
            DropTable("dbo.Transportations");
            DropTable("dbo.ReturnReasons");
            DropTable("dbo.PSN");
            DropTable("dbo.Provinces");
            DropTable("dbo.PostArrivalNeeds");
            DropTable("dbo.NeedTools");
            DropTable("dbo.MoneySources");
            DropTable("dbo.MainConcerns");
            DropTable("dbo.LookupValues");
            DropTable("dbo.LookupTypes");
            DropTable("dbo.LivelihoodEmpNeeds");
            DropTable("dbo.Individuals");
            DropTable("dbo.HostCountrySchool");
            DropTable("dbo.HostCountryProvinces");
            DropTable("dbo.HostCountryDistricts");
            DropTable("dbo.Districts");
            DropTable("dbo.Determinations");
            DropTable("dbo.BroughtItems");
            DropTable("dbo.BorderCrossingPoints");
            DropTable("dbo.BenefitedFromOrgs");
            DropTable("dbo.Beneficiaries");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
        }
    }
}
