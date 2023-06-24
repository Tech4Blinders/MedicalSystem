using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer
{
    public class SigninDto
    {
       public string credential { get; set; } = string.Empty;
       public string role { get; set; } = string.Empty;

    }
}
