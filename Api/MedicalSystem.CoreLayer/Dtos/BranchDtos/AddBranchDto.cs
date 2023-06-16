using Microsoft.AspNetCore.Http;

namespace MedicalSystem.CoreLayer
{
    public class AddBranchDto
    {
        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public int HospitalId { get; set; }

        public int BranchAddressId { get; set; }
        public string Image { get; set; } = string.Empty;
        public IFormFile File { get; set; }

    }
}
