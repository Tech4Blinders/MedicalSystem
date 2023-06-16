using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.CoreLayer
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"[FM]")]
        public string Gender { get; set; } = string.Empty;
        [Required]
        [Range(1, 120)]
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();


    }
}
