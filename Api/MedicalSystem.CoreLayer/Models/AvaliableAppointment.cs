using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.CoreLayer
{
    public class AvaliableAppointment
    {
        public int Id { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId {get;set;}

        public DateTime Date { get; set; }

        public Doctor? Doctor { get; set; }

    }
}
