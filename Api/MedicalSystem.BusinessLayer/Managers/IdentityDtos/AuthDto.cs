using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.BusinessLayer.Managers.IdentityDtos
{
    public class AuthDto
    {
        public string Message { get; set; } = String.Empty;
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
        public DateTime ExpiresOn { get; set; }
    }
}
