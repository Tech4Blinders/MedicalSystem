using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer.Models.Doctor_Qualifications
{
    public class DoctorQualificationConfiguration : IEntityTypeConfiguration<DoctorQualification>
    {
        public void Configure(EntityTypeBuilder<DoctorQualification> builder)
        {
            builder.Property(d => d.Certification)
               .HasMaxLength(500)
               .IsRequired();
        }
    }
}