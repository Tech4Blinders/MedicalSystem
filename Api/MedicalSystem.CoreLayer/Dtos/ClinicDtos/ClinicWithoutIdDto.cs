using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer
{
	public class ClinicWithoutIdDto
	{
		public string Specilization { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int RoomNumber { get; set; }
        public string? Image { get; set; } = string.Empty;
        public int BranchId { get; set; }
        public IFormFile? File { get; set; }
    }
}
