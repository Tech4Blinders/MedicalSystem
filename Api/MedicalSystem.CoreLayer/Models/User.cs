using Microsoft.AspNetCore.Identity;

namespace MedicalSystem.CoreLayer
{
    public class User : IdentityUser<int> // id email pass username phoneNum 
    {

        public string Name { get; set; } = string.Empty; 
        public string Image { get; set; } = string.Empty;

    }
}
