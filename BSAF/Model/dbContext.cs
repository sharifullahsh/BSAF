namespace BSAF.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using BSAF.Model;

    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=BSAFconn")
        {
        }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<BorderCrossingPoint> BorderCrossingPoints { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<HostCountryDistrict> HostCountryDistricts { get; set; }
        public DbSet<HostCountryProvince> HostCountryProvinces { get; set; }
        public DbSet<GenderType> GenderTypes { get; set; }
        public DbSet<IDType> IDTypes { get; set; }
        public DbSet<LeavingReason> LeavingReasons { get; set; }
        public DbSet<MaritalStatusType> MaritalStatusTypes { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Need> Needs { get; set; }
        public DbSet<LookupType> LookupTypes { get; set; }
        public DbSet<LookupValue> LookupValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
