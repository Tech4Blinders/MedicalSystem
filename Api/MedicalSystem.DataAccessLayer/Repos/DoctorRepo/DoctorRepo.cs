using MedicalSystem.DataAccessLayer.Data;
using MedicalSystem.DataAccessLayer.Models.Doctor;
using MedicalSystem.DataAccessLayer.Repos.MainRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer.Repos.DoctorRepo
{
    public class DoctorRepo : GenericRepo<Doctor>, IDoctorRepo
    {
        public DoctorRepo(ApplicationDbContext context) : base(context) { }
      
    }
}
