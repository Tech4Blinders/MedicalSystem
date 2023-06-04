using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.CoreLayer
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        public string Prescription { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public int AppointmentId { get; set; }
        [Required]
        public Appointment Appointment { get; set; } = null!;
    }
}
