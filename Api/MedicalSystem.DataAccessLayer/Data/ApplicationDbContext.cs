using MedicalSystem.DataAccessLayer.Models.Doctor;
using MedicalSystem.DataAccessLayer.Models.Doctor_Qualifications;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        #region CTOR
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {
            
        }

        #endregion 

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             if(!optionsBuilder.IsConfigured)
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
