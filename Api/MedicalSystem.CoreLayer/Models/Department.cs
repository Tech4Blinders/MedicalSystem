using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedicalSystem.CoreLayer.Models;

namespace MedicalSystem.CoreLayer
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }

    }
}
