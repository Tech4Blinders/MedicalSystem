using AutoMapper;
using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Doctor, ReadDoctorDto>() // docName clinicName
        .ForMember(d => d.ClinicName, option => option.MapFrom(src => src.Clinic.Specilization))
        .ForMember(d => d.DepartmentName, option => option.MapFrom(src => src.Department.Name));
        CreateMap<Doctor, AddDoctorDto>().ReverseMap();
        CreateMap<Doctor, UpdateDoctorDto>().ReverseMap();

    }
}
