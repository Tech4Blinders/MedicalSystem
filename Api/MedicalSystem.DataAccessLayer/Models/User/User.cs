using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer.Models.Doctor
{
    public class User:IdentityUser
    {
        public string fname { get; set; } = string.Empty; 
        public string lname { get; set; } = string.Empty;   
    }
}
