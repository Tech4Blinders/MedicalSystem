﻿using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer;


public class DoctorQualificationRepo : GenericRepo<Doctor>, IDoctorQualificationRepo
{
    private readonly ApplicationDbContext _context;

    public DoctorQualificationRepo(ApplicationDbContext context) : base(context) 
    {
        _context = context;
    }
}
