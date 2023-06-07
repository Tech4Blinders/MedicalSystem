namespace MedicalSystem.CoreLayer
{
	public class ReviewAddDto : ReviewWithoutIdDto
	{
		public int DoctorId { get; set; }

		public int PatientId { get; set; }
	}
}
