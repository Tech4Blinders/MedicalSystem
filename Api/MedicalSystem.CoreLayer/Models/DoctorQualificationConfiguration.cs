using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalSystem.CoreLayer
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