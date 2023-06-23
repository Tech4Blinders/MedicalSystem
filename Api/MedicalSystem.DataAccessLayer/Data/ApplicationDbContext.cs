using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MedicalSystem.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<int> ,int>
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
                optionsBuilder.UseSqlServer("Server =. ; Database = NewMedicalLocalDb; Trusted_Connection = true; Encrypt = false;");
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
            builder.Entity<Review>()
                   .HasOne(r => r.Patient).WithMany(p => p.Reviews)
                   .HasForeignKey(r => r.PatientId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<Appointment>()
                   .HasOne(r => r.Branch).WithMany(a=>a.Appoitments)
                   .HasForeignKey(r => r.BranchId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<Doctor>()
             .HasOne(r => r.Department).WithMany(a => a.Doctors)
             .HasForeignKey(r => r.DepartmentId)
             .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<BranchDoctor>()
                .HasOne(a => a.Branch).WithMany(b => b.BranchDoctors)
                .HasForeignKey(a => a.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<DoctorQualification>()
                .HasKey(a => new { a.DoctorId, a.Certification });
            builder.Entity<Appointment>().HasOne(a => a.Doctor).WithMany(b => b.Appointments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Clinic>()
               .HasOne(a => a.Branch).WithMany(b => b.Clinics)
               .HasForeignKey(a => a.BranchId)
               .OnDelete(DeleteBehavior.ClientSetNull);

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
        public DbSet<AvaliableAppointment> AvaliableAppointment => Set<AvaliableAppointment>();


        #endregion










    }


}
