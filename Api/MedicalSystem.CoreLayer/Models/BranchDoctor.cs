namespace MedicalSystem.CoreLayer
{
    public class BranchDoctor
    {
        public int BranchId { get; set; }
        public int DoctorId { get; set; }
        public DateTime StaringDate { get; set; }
        public Branch? Branch { get; set; }
        public Doctor? Doctor { get; set; }

    }
}
