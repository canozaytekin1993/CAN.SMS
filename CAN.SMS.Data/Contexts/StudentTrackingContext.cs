using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CAN.SMS.Data.StudentTrackingMigration;
using CAN.SMS.Model.Entities;

namespace CAN.SMS.Data.Contexts
{
    public class StudentTrackingContext : BaseDbContext<StudentTrackingContext, Configuration>
    {
        public StudentTrackingContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public StudentTrackingContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        #region DbSet Table

        public DbSet<School> School { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<County> County { get; set; }
        public DbSet<Filter> Filter { get; set; }

        #endregion
    }
}