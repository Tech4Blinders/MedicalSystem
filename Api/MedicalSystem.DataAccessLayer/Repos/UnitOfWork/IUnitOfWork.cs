using MedicalSystem.DataAccessLayer.Repos.DoctorQualificationRepo;
using MedicalSystem.DataAccessLayer.Repos.DoctorRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer.Repos.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IDoctorRepo _DoctorRepo { get; }
        public IDoctorQualificationRepo _DoctorQualificationRepo { get;  }
    }
}
