using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.CoreLayer
{
    public class BranchAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string PostalCode { get; set; } = string.Empty;
        [Required, StringLength(20)]
        public string Street { get; set; } = string.Empty;
        [Required, StringLength(20)]
        public string City { get; set; } = string.Empty;
        [Required, StringLength(20)]
        public string State { get; set; } = string.Empty;
        [Required, StringLength(20)]
        public string Country { get; set; } = string.Empty;
        public Branch? Branch { get; set; }
    }
}
