namespace MedicalSystem.CoreLayer
{
    public class PatientReadDto
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Id { get; set; }
    }
}
