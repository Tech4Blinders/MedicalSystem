namespace MedicalSystem.CoreLayer
{
    public class BranchWithAddressReadDto : ReadBranchDto
    {
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string HospitalName { get;set; }=string.Empty;
    }
}
