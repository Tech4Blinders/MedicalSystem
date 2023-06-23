using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.CoreLayer
{
    public class Patient :User
    {
    
        [Required]
        [RegularExpression(@"[FM]")]
        public string Gender { get; set; } = string.Empty;
        [Required]
        [Range(1, 120)]
        public int Age { get; set; }
     
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();


    }
}
