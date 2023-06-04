using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalSystem.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        #region CTOR
        public ApplicationDbContext()
        {

        }
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
            builder.ApplyConfigurationsFromAssembly(typeof(DoctorConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(DoctorQualificationConfiguration).Assembly);
        }
        #endregion

        #region Dbset
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Doctor> DoctorQualification { get; set; }
        #endregion




    }
}
