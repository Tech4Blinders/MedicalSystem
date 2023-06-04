
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.CoreLayer
{
    public class Clinic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Specilization { get; set; } = string.Empty;
        [Required, StringLength(40)]
        public string Description { get; set; } = string.Empty;
        [Required, Range(0, 9999)]
        public int RoomNumber { get; set; }

        public ICollection<Doctor> Doctors = new HashSet<Doctor>();
    }
}
