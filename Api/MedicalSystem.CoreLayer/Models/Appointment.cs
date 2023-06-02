using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [Range(0,maximum:99999)]
        public int Cost { get; set; }
        public Report? Report { get; set; }

        //[Required]
        //[ForeignKey("Doctor")]
        //public int DoctorId { get; set; }
        //public Doctor Doctor { get; set; }


        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        //[Required]
        //[ForeignKey("Branch")]
        //public int BranchId { get; set; }
        //public Branch Branch { get; set; }


    }
}
