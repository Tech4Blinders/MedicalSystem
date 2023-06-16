using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer
{
    public class AvaliableAppointmentRepo : GenericRepo<AvaliableAppointment>,IAvaliableAppointmentRepo
    {
        private readonly ApplicationDbContext context;
        public AvaliableAppointmentRepo(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
