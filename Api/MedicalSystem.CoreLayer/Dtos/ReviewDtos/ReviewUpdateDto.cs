using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer
{
	public class ReviewUpdateDto:ReviewWithIdDto
	{
		public int DoctorId { get; set; }

		public int PatientId { get; set; }
	}
}
