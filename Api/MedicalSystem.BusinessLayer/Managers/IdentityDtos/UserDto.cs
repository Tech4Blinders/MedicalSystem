using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.BusinessLayer.Managers.IdentityDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string UserName { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
    }
}
