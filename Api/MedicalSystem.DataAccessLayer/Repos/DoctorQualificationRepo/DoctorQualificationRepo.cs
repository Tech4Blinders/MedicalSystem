using MedicalSystem.DataAccessLayer.Data;
using MedicalSystem.DataAccessLayer.Models.Doctor;
using MedicalSystem.DataAccessLayer.Repos.MainRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer.Repos.DoctorQualificationRepo
{
    public class DoctorQualificationRepo : GenericRepo<Doctor>, IDoctorQualificationRepo
    {
        public DoctorQualificationRepo(ApplicationDbContext context) : base(context) { }
        
        
    }
}
