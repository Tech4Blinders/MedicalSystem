using MedicalSystem.DataAccessLayer.Repos.DoctorQualificationRepo;
using MedicalSystem.DataAccessLayer.Repos.DoctorRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer.Repos.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        public IDoctorRepo? _DoctorRepo { get; }
        public IDoctorQualificationRepo? _DoctorQualificationRepo { get; }

        public UnitOfWork(IDoctorRepo doctorRepo , IDoctorQualificationRepo doctorQualificationRepo)
        {
            _DoctorRepo = doctorRepo;
            _DoctorQualificationRepo = doctorQualificationRepo;
        }


    }
}
