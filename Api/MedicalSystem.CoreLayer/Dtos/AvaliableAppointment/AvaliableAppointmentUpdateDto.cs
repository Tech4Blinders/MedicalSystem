namespace MedicalSystem.CoreLayer
{
    public class AvaliableAppointmentUpdateDto
    {
        public int Id { get; set; } 
        public int DoctorId { get; set; }

        public DateTime Date { get; set; }
       
    }
}
