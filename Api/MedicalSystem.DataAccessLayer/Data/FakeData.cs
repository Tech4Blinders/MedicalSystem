using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer;

public static class FakeData
{
    /*
    public static List<Hospital> HospitalData()
    {
        List<Hospital> hospitals = new List<Hospital>()
            {
                new Hospital { Name = "St. Jude Children's Research Hospital", Email = "stjude@example.com" },
                new Hospital { Name = "Mount Sinai Hospital", Email = "mountsinai@example.com" },
                new Hospital { Name = "Children's Hospital of Philadelphia", Email = "chop@example.com" },
                new Hospital { Name = "Toronto General Hospital", Email = "torontogeneral@example.com" },
                new Hospital { Name = "Texas Medical Center", Email = "tmc@example.com" },
                new Hospital { Name = "Moffitt Cancer Center", Email = "moffitt@example.com" },
                new Hospital { Name = "Barnes-Jewish Hospital", Email = "barnesjewish@example.com" },
            };
        return hospitals;
    }
    public static List<Patient> PatientData()
    {
        List<Patient> patients = new List<Patient>()
            {
                new Patient { Name = "John Smith", PhoneNumber = "1234567890", Gender = "M", Age = 25, Email = "john@example.com" },
                new Patient {Name = "Jane Doe", PhoneNumber = "9876543210", Gender = "F", Age = 30, Email = "jane@example.com" },
                new Patient { Name = "Alex Johnson", PhoneNumber = "5555555555", Gender = "M", Age = 40, Email = "alex@example.com" },
                new Patient { Name = "Emily Williams", PhoneNumber = "1112223333", Gender = "F", Age = 22, Email = "emily@example.com" }
            };


        return patients;
    }
    public static List<BranchAddress> AddressData()
    {
        List<BranchAddress> addresses = new List<BranchAddress>()
                {
                new BranchAddress {Id=1, PostalCode = "12345", Street = "Main Street", City = "New York", State = "NY", Country = "USA" },
                new BranchAddress {Id=2, PostalCode = "54321", Street = "First Avenue", City = "Los Angeles", State = "CA", Country = "USA" },
                new BranchAddress {Id=3, PostalCode = "98765", Street = "King's Road", City = "London", State = "GB", Country = "UK" },
                new BranchAddress {Id=4, PostalCode = "45678", Street = "Champs-Élysées", City = "Paris", State = "FA", Country = "France" },
                new BranchAddress {Id=5, PostalCode = "55465", Street = "Grand-Avenue", City = "Florida", State = "FL", Country = "USA" },
                new BranchAddress {Id=6, PostalCode = "64568", Street = "Lo Mark", City = "Alexandria", State = "AX", Country = "Egypt" },
                new BranchAddress {Id=7, PostalCode = "45418", Street = "Banzena", City = "Menoufiya", State = "MF", Country = "Egypt" },
                new BranchAddress {Id=8, PostalCode = "99865", Street = "Fo Sahab", City = "Menya Qmh", State = "MQ", Country = "Zambia" },
                new BranchAddress {Id=9, PostalCode = "11548", Street = "Ras Bar", City = "Qom Hamada", State = "QH", Country = "Brazil" },
                };
        return addresses;
    }
    public static List<Branch> BranchData()
    {
        List<Branch> branches = new List<Branch>()
        {
            new Branch {Id=1, Name = "Branch A", PhoneNumber = "1234567890", HospitalId = 1, BranchAddressId = 1 },
            new Branch {Id=2, Name = "Branch B", PhoneNumber = "9876543210", HospitalId = 2, BranchAddressId = 2 },
            new Branch {Id=3, Name = "Branch C", PhoneNumber = "5555555555", HospitalId = 3, BranchAddressId = 3 },
            new Branch {Id=4, Name = "Branch D", PhoneNumber = "1112223333", HospitalId = 4, BranchAddressId = 4 },
            new Branch {Id=5, Name = "Branch E", PhoneNumber = "5646546546", HospitalId = 1, BranchAddressId = 5 },
            new Branch {Id=6, Name = "Branch F", PhoneNumber = "1555154654", HospitalId = 2, BranchAddressId = 6 },
            new Branch {Id=7, Name = "Branch J", PhoneNumber = "7797988521", HospitalId = 3, BranchAddressId = 7 },
            new Branch {Id=8, Name = "Branch H", PhoneNumber = "6597451215", HospitalId = 4, BranchAddressId = 8 },
            new Branch {Id=9, Name = "Branch I", PhoneNumber = "1564989848", HospitalId = 1, BranchAddressId = 9 },
        };
        return branches;
    }
    public static List<Department> DepartmentData()
    {
        var departments = new List<Department>
            {
                new Department{Id=1,Name="Cardiology",BranchId=1},
                new Department{Id=2,Name="Pediatrics",BranchId=1},
                new Department{Id=3,Name="Orthopedics",BranchId=1},
                new Department{Id=4,Name="Oncology",BranchId=1},
                new Department{Id=5,Name="Anesthesiology",BranchId=1},
                new Department{Id=6,Name="Radiology",BranchId=1},
                new Department{Id=7,Name="Dermatology",BranchId=1},
                new Department{Id=8,Name="Ophthalmology",BranchId=1},
            };
        return departments;
    }
    public static List<Clinic> ClinicData()
    {
        var clinics = new List<Clinic>
            {
                new Clinic
            {   Id=1,
                Specilization = "Family Medicine",
                Description = "Description for Family Medicine Clinic",
                RoomNumber = 1001,
                BranchId=1
            },
            new Clinic
            {   Id=2,
                Specilization = "Dentistry",
                Description = "Description for Dental Clinic",
                RoomNumber = 1002,
                BranchId=1

            },
            new Clinic
            {   Id = 3,
                Specilization = "Internal Medicine",
                Description = "Description for Internal Medicine Clinic",
                RoomNumber = 1003,
                BranchId=2

            },
            new Clinic
            {   Id = 4,
                Specilization = "Orthopedics",
                Description = "Description for Orthopedic Clinic",
                RoomNumber = 1004,
                BranchId=2

            },
            new Clinic
            {   Id = 5,
                Specilization = "Cardiology",
                Description = "Description for Cardiology Clinic",
                RoomNumber = 1005,
                BranchId=3

            },
            new Clinic
            {   Id = 6,
                Specilization = "Pediatrics",
                Description = "Description for Pediatric Clinic",
                RoomNumber = 1006,
                BranchId=3

            }
            };
        return clinics;
    }
    public static List<Doctor> DoctorData()
    {
        var doctors = new List<Doctor>
            {
                    new Doctor
                {
                  
                    Name = "Dr. Ahmed Ali",
                    PhoneNumber = "+971 123-456-7890",
                    Gender = "Male",
                    Email = "ahmed.ali@example.com",
                    Country = "United Arab Emirates",
                    City = "Dubai",
                    Street = "123 Main St",
                    DepartmentId=1,
                    ClinicId=1,
                    OfflineCost=200,
                    OnlineCost=100
                },
                new Doctor
                {   
                    Name = "Dr. Fatima Hassan",
                    PhoneNumber = "+971 987-654-3210",
                    Gender = "Female",
                    Email = "fatima.hassan@example.com",
                    Country = "United Arab Emirates",
                    City = "Abu Dhabi",
                    Street = "456 Elm St",
                    DepartmentId=2,
                    ClinicId=2,
                    OfflineCost=300,
                    OnlineCost=200
                },
                new Doctor
                {
                    Name = "Dr. Ali Mahmoud",
                    PhoneNumber = "+971 555-123-4567",
                    Gender = "Male",
                    Email = "ali.mahmoud@example.com",
                    Country = "United Arab Emirates",
                    City = "Sharjah",
                    Street = "789 Oak St",
                    DepartmentId=3,
                    ClinicId=3,
                    OfflineCost=400,
                    OnlineCost=300
                },
                new Doctor
                {
                    Name = "Dr. Aisha Khan",
                    PhoneNumber = "+971 555-987-6543",
                    Gender = "Female",
                    Email = "aisha.khan@example.com",
                    Country = "United Arab Emirates",
                    City = "Ajman",
                    Street = "321 Pine St",
                    DepartmentId=4,
                    ClinicId=4,
                    OfflineCost=500,
                    OnlineCost=400
                },
                new Doctor
                {
                    Name = "Dr. Omar Ahmed",
                    PhoneNumber = "+971 555-567-8901",
                    Gender = "Male",
                    Email = "omar.ahmed@example.com",
                    Country = "United Arab Emirates",
                    City = "Ras Al Khaimah",
                    Street = "987 Maple St",
                    DepartmentId=5,
                    ClinicId=5,
                    OfflineCost=600,
                    OnlineCost=500
                },
                new Doctor
                { 
                    Name = "Dr. Layla Hassan",
                    PhoneNumber = "+971 555-210-9876",
                    Gender = "Female",
                    Email = "layla.hassan@example.com",
                    Country = "United Arab Emirates",
                    City = "Fujairah",
                    Street = "654 Walnut St",
                    DepartmentId=6,
                    ClinicId=6,
                    OfflineCost=700,
                    OnlineCost=600
                },
                new Doctor
                {
                    Name = "Dr. Ibrahim Khalid",
                    PhoneNumber = "+971 555-876-5432",
                    Gender = "Male",
                    Email = "ibrahim.khalid@example.com",
                    Country = "United Arab Emirates",
                    City = "Umm Al Quwain",
                    Street = "210 Cedar St",
                    DepartmentId=7,
                    ClinicId=1,
                    OfflineCost=800,
                    OnlineCost=700
                },
                new Doctor
                {
                    
                    Name = "Dr. Sarah Ahmed",
                    PhoneNumber = "+971 555-432-1098",
                    Gender = "Female",
                    Email = "sarah.ahmed@example.com",
                    Country = "United Arab Emirates",
                    City = "Al Ain",
                    Street = "876 Birch St",
                    DepartmentId=8,
                    ClinicId=2,
                    OfflineCost=900,
                    OnlineCost=800
                }
            };
        return doctors;
    }
    public static List<DoctorQualification> DoctorQualificationData()
    {
        List<DoctorQualification> qualifications = new List<DoctorQualification>
        {
                new DoctorQualification
                {
                    Certification = "MBBS",
                    CertificationFrom = "University of Medicine",
                    DoctorId=1
                },
                new DoctorQualification
                {
                    Certification = "MD",
                    CertificationFrom = "Medical College",
                    DoctorId=2
                },
                new DoctorQualification
                {
                    Certification = "MS",
                    CertificationFrom = "Surgical Institute",
                    DoctorId=3
                },
                new DoctorQualification
                {
                    Certification = "DM",
                    CertificationFrom = "Cardiology University",
                    DoctorId=4
                },
                new DoctorQualification
                {
                    Certification = "MCh",
                    CertificationFrom = "Neurosurgery Institute",
                    DoctorId=5
                },
                new DoctorQualification
                {
                    Certification = "BDS",
                    CertificationFrom = "Dental School",
                    DoctorId=6
                },
                new DoctorQualification
                {
                    Certification = "PharmD",
                    CertificationFrom = "Pharmacy College",
                    DoctorId=7
                },
                new DoctorQualification
                {
                    Certification = "DPT",
                    CertificationFrom = "Physical Therapy Institute",
                    DoctorId=8
                },
                new DoctorQualification
                {
                    Certification = "MSW",
                    CertificationFrom = "Social Work University",
                    DoctorId=1
                },
                new DoctorQualification
                {
                    Certification = "PhD",
                    CertificationFrom = "Research Institute",
                    DoctorId=2
                }
            };

        return qualifications;
    }
    public static List<BranchDoctor> BranchDoctorData()
    {
        List<BranchDoctor> branchDoctors = new List<BranchDoctor>
        {
            new BranchDoctor
            {
                BranchId = 1,
                DoctorId = 1,
                StaringDate = new DateTime(2021, 10, 15)
            },
            new BranchDoctor
            {
                BranchId = 1,
                DoctorId = 2,
                StaringDate = new DateTime(2021, 10, 15)
            },
            new BranchDoctor
            {
                BranchId = 1,
                DoctorId = 3,
                StaringDate = new DateTime(2021, 10, 15)
            },
            new BranchDoctor
            {
                BranchId = 1,
                DoctorId = 4,
                StaringDate = new DateTime(2021, 10, 15)
            },
            new BranchDoctor
            {
                BranchId = 2,
                DoctorId = 2,
                StaringDate = new DateTime(2022, 3, 8)
            },
            new BranchDoctor
            {
                BranchId = 2,
                DoctorId = 1,
                StaringDate = new DateTime(2022, 3, 8)

            },
            new BranchDoctor
            {
                BranchId = 2,
                DoctorId = 3,
                StaringDate = new DateTime(2022, 3, 8)

            },
            new BranchDoctor
            {
                BranchId = 2,
                DoctorId = 4,
                StaringDate = new DateTime(2022, 3, 8)

            },
            new BranchDoctor
            {
                BranchId = 2,
                DoctorId = 5,
                StaringDate = new DateTime(2022, 3, 8)

            },
            new BranchDoctor
            {
                BranchId = 3,
                DoctorId = 3,
                StaringDate = new DateTime(2022, 7, 20)
            },
            new BranchDoctor
            {
                BranchId = 4,
                DoctorId = 4,
                StaringDate = new DateTime(2022, 11, 5)
            },
            new BranchDoctor
            {
                BranchId = 5,
                DoctorId = 5,
                StaringDate = new DateTime(2023, 2, 12)
            }
        };
        return branchDoctors;
    }
    public static List<Appointment> AppointmentData()
    {
        List<Appointment> appointments = new List<Appointment>
        {
            new Appointment
            {
                Id=1,
                AppointmentDate = new DateTime(2023, 6, 15, 10, 0, 0),
                Cost = 100,
                DoctorId=1,
                PatientId=1,
                BranchId=1
            },
            new Appointment
            {Id = 2,
                AppointmentDate = new DateTime(2023, 6, 16, 15, 30, 0),
                Cost = 75,
                 DoctorId=2,
                PatientId=2,
                BranchId=2
            },
            new Appointment
            {Id = 3,
                AppointmentDate = new DateTime(2023, 6, 17, 9, 0, 0),
                Cost = 120,
                 DoctorId=3,
                PatientId=3,
                BranchId=3
            },
            new Appointment
            {Id = 4,
                AppointmentDate = new DateTime(2023, 6, 18, 14, 15, 0),
                Cost = 90,
                 DoctorId=4,
                PatientId=4,
                BranchId=4
            },
            new Appointment
            {Id = 5,
                AppointmentDate = new DateTime(2023, 6, 19, 11, 30, 0),
                Cost = 80,
                 DoctorId=5,
                PatientId=1,
                BranchId=5
            }
        };
        return appointments;
    }
    public static List<Report> ReportData()
    {
        List<Report> reports = new List<Report>
        {
            new Report
            {   Id=1,
                Description = "Patient presented with flu-like symptoms.",
                Prescription = "Prescribed antiviral medication and rest.",
                Date = new DateTime(2023, 6, 15, 10, 0, 0),
                AppointmentId = 1
            },
            new Report
            {Id=2,
                Description = "Patient complained of joint pain and inflammation.",
                Prescription = "Prescribed anti-inflammatory medication and physical therapy.",
                Date = new DateTime(2023, 6, 16, 15, 30, 0),
                AppointmentId = 2
            },
            new Report
            {Id = 3,
                Description = "Patient underwent routine check-up.",
                Prescription = "No medication prescribed. Advised to maintain a healthy lifestyle.",
                Date = new DateTime(2023, 6, 17, 9, 0, 0),
                AppointmentId = 3
            },
            new Report
            { Id=4,
                Description = "Patient presented with symptoms of food poisoning.",
                Prescription = "Prescribed antibiotics and advised to stay hydrated.",
                Date = new DateTime(2023, 6, 18, 14, 15, 0),
                AppointmentId = 4
            },
            new Report
            {   Id=5,
                Description = "Patient complained of persistent headaches.",
                Prescription = "Prescribed pain relievers and recommended further evaluation.",
                Date = new DateTime(2023, 6, 19, 11, 30, 0),
                AppointmentId = 5
            }
        };
        return reports;
    }
    public static List<Review> ReviewData()
    {
        List<Review> reviews = new List<Review>
        {
            new Review
            {
                Id=1,
                ReviewText = "Great experience with the doctor. Very knowledgeable and friendly.",
                Rate = 90,
                DoctorId = 1,
                PatientId = 1
            },
            new Review
            {Id=2,
                ReviewText = "Highly recommend this doctor. Excellent bedside manner and thorough examination.",
                Rate = 95,
                DoctorId = 1,
                PatientId = 2
            },
            new Review
            {Id=3,
                ReviewText = "Had a positive experience with the doctor. Listened to my concerns and provided helpful advice.",
                Rate = 85,
                DoctorId = 2,
                PatientId = 3
            },
            new Review
            {Id=4,
                ReviewText = "Extremely satisfied with the doctor's expertise. Helped me understand my condition better.",
                Rate = 100,
                DoctorId = 2,
                PatientId = 4
            },
            new Review
            {Id=5,
                ReviewText = "The doctor was friendly and professional. Explained the treatment plan clearly.",
                Rate = 80,
                DoctorId = 1,
                PatientId = 3
            }
        };
        return reviews;
    }
    */
}
