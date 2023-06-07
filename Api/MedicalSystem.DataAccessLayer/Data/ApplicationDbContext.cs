using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalSystem.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        #region CTOR
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        #endregion 

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =. ;  Initial Catalog = ELMostshfa; Integrated Security = true ");
            }
        }
        #endregion

        #region OnModelCreate

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DoctorConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(DoctorQualificationConfiguration).Assembly);
            builder.Entity<BranchDoctor>()
                .HasKey(a => new { a.DoctorId, a.BranchId });
            builder.Entity<BranchDoctor>()
                .HasOne(a => a.Doctor).WithMany(b => b.BranchDoctors)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<BranchDoctor>()
                .HasOne(a => a.Branch).WithMany(b => b.BranchDoctors)
                .HasForeignKey(a => a.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<DoctorQualification>()
                .HasKey(a => new { a.DoctorId, a.Certification });
            builder.Entity<Appointment>().HasOne(a => a.Doctor).WithMany(b => b.Appointments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Hospital>().HasData(FakeData.HospitalData());
            builder.Entity<Patient>().HasData(FakeData.PatientData());
            builder.Entity<BranchAddress>().HasData(FakeData.AddressData());
            builder.Entity<Branch>().HasData(FakeData.BranchData());
            builder.Entity<Department>().HasData(FakeData.DepartmentData());
            builder.Entity<Clinic>().HasData(FakeData.ClinicData());
            builder.Entity<Doctor>().HasData(FakeData.DoctorData());
            builder.Entity<DoctorQualification>().HasData(FakeData.DoctorQualificationData());
            builder.Entity<BranchDoctor>().HasData(FakeData.BranchDoctorData());
            builder.Entity<Appointment>().HasData(FakeData.AppointmentData());
            builder.Entity<Report>().HasData(FakeData.ReportData());
            builder.Entity<Review>().HasData(FakeData.ReviewData());






        }
        #endregion

        #region Dbset
        public DbSet<Doctor> Doctor => Set<Doctor>();
        public DbSet<DoctorQualification> DoctorQualification => Set<DoctorQualification>();
        public DbSet<Clinic> Clinic => Set<Clinic>();
        public DbSet<Appointment> Appointment => Set<Appointment>();
        public DbSet<Branch> Branch => Set<Branch>();
        public DbSet<Report> Report => Set<Report>();
        public DbSet<Review> Review => Set<Review>();
        public DbSet<Hospital> Hospital => Set<Hospital>();
        public DbSet<BranchAddress> BranchAddress => Set<BranchAddress>();
        public DbSet<BranchDoctor> BranchDoctor => Set<BranchDoctor>();
        public DbSet<Patient> Patient => Set<Patient>();
        public DbSet<Department> Department => Set<Department>();

        #endregion










    }


}
