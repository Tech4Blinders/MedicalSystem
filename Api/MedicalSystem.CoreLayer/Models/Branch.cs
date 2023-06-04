using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.CoreLayer
{
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; } = null!;

        [Required]
        [ForeignKey("BranchAddress")]
        public int BranchAddressId { get; set; }
        public BranchAddress BranchAddress { get; set; } = null!;

        public ICollection<BranchDoctor> BranchDoctors { get; set;}=new HashSet<BranchDoctor>();
    
    }
}
