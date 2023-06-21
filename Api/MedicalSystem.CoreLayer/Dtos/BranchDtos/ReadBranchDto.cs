namespace MedicalSystem.CoreLayer
{
    public class ReadBranchDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public int HospitalId { get; set; }

        public int BranchAddressId { get; set; }
        public string Image { get; set; } = string.Empty;

    }
}
