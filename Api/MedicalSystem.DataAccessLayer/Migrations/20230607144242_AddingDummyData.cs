using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalSystem.DataAccessLayer.Migrations
{
    public partial class AddingDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BranchAddress",
                columns: new[] { "Id", "City", "Country", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "New York", "USA", "12345", "NY", "Main Street" },
                    { 2, "Los Angeles", "USA", "54321", "CA", "First Avenue" },
                    { 3, "London", "UK", "98765", "GB", "King's Road" },
                    { 4, "Paris", "France", "45678", "FA", "Champs-Élysées" },
                    { 5, "Florida", "USA", "55465", "FL", "Grand-Avenue" },
                    { 6, "Alexandria", "Egypt", "64568", "AX", "Lo Mark" },
                    { 7, "Menoufiya", "Egypt", "45418", "MF", "Banzena" },
                    { 8, "Menya Qmh", "Zambia", "99865", "MQ", "Fo Sahab" },
                    { 9, "Qom Hamada", "Brazil", "11548", "QH", "Ras Bar" }
                });

            migrationBuilder.InsertData(
                table: "Clinic",
                columns: new[] { "Id", "Description", "RoomNumber", "Specilization" },
                values: new object[,]
                {
                    { 1, "Description for Family Medicine Clinic", 1001, "Family Medicine" },
                    { 2, "Description for Dental Clinic", 1002, "Dentistry" },
                    { 3, "Description for Internal Medicine Clinic", 1003, "Internal Medicine" },
                    { 4, "Description for Orthopedic Clinic", 1004, "Orthopedics" },
                    { 5, "Description for Cardiology Clinic", 1005, "Cardiology" },
                    { 6, "Description for Pediatric Clinic", 1006, "Pediatrics" }
                });

            migrationBuilder.InsertData(
                table: "Hospital",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "stjude@example.com", "St. Jude Children's Research Hospital" },
                    { 2, "mountsinai@example.com", "Mount Sinai Hospital" },
                    { 3, "chop@example.com", "Children's Hospital of Philadelphia" },
                    { 4, "torontogeneral@example.com", "Toronto General Hospital" },
                    { 5, "tmc@example.com", "Texas Medical Center" },
                    { 6, "moffitt@example.com", "Moffitt Cancer Center" },
                    { 7, "barnesjewish@example.com", "Barnes-Jewish Hospital" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Age", "Email", "Gender", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 25, "john@example.com", "M", "John Smith", "1234567890" },
                    { 2, 30, "jane@example.com", "F", "Jane Doe", "9876543210" },
                    { 3, 40, "alex@example.com", "M", "Alex Johnson", "5555555555" },
                    { 4, 22, "emily@example.com", "F", "Emily Williams", "1112223333" }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "BranchAddressId", "HospitalId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, 1, "Branch A", "1234567890" },
                    { 2, 2, 2, "Branch B", "9876543210" },
                    { 3, 3, 3, "Branch C", "5555555555" },
                    { 4, 4, 4, "Branch D", "1112223333" },
                    { 5, 5, 1, "Branch E", "5646546546" },
                    { 6, 6, 2, "Branch F", "1555154654" },
                    { 7, 7, 3, "Branch J", "7797988521" },
                    { 8, 8, 4, "Branch H", "6597451215" },
                    { 9, 9, 1, "Branch I", "1564989848" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "BranchId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Cardiology" },
                    { 2, 1, "Pediatrics" },
                    { 3, 1, "Orthopedics" },
                    { 4, 1, "Oncology" },
                    { 5, 1, "Anesthesiology" },
                    { 6, 1, "Radiology" },
                    { 7, 1, "Dermatology" },
                    { 8, 1, "Ophthalmology" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "City", "ClinicId", "Country", "DepartmentId", "Email", "Gender", "Name", "PhoneNumber", "Street" },
                values: new object[,]
                {
                    { 1, "Dubai", 1, "United Arab Emirates", 1, "ahmed.ali@example.com", "Male", "Dr. Ahmed Ali", "+971 123-456-7890", "123 Main St" },
                    { 2, "Abu Dhabi", 2, "United Arab Emirates", 2, "fatima.hassan@example.com", "Female", "Dr. Fatima Hassan", "+971 987-654-3210", "456 Elm St" },
                    { 3, "Sharjah", 3, "United Arab Emirates", 3, "ali.mahmoud@example.com", "Male", "Dr. Ali Mahmoud", "+971 555-123-4567", "789 Oak St" },
                    { 4, "Ajman", 4, "United Arab Emirates", 4, "aisha.khan@example.com", "Female", "Dr. Aisha Khan", "+971 555-987-6543", "321 Pine St" },
                    { 5, "Ras Al Khaimah", 5, "United Arab Emirates", 5, "omar.ahmed@example.com", "Male", "Dr. Omar Ahmed", "+971 555-567-8901", "987 Maple St" },
                    { 6, "Fujairah", 6, "United Arab Emirates", 6, "layla.hassan@example.com", "Female", "Dr. Layla Hassan", "+971 555-210-9876", "654 Walnut St" },
                    { 7, "Umm Al Quwain", 1, "United Arab Emirates", 7, "ibrahim.khalid@example.com", "Male", "Dr. Ibrahim Khalid", "+971 555-876-5432", "210 Cedar St" },
                    { 8, "Al Ain", 2, "United Arab Emirates", 8, "sarah.ahmed@example.com", "Female", "Dr. Sarah Ahmed", "+971 555-432-1098", "876 Birch St" }
                });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "AppointmentDate", "BranchId", "Cost", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 100, 1, 1 },
                    { 2, new DateTime(2023, 6, 16, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, 75, 2, 2 },
                    { 3, new DateTime(2023, 6, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, 120, 3, 3 },
                    { 4, new DateTime(2023, 6, 18, 14, 15, 0, 0, DateTimeKind.Unspecified), 4, 90, 4, 4 },
                    { 5, new DateTime(2023, 6, 19, 11, 30, 0, 0, DateTimeKind.Unspecified), 5, 80, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "BranchDoctor",
                columns: new[] { "BranchId", "DoctorId", "StaringDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 3, new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 4, new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 5, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "DoctorQualification",
                columns: new[] { "Certification", "DoctorId", "CertificationFrom" },
                values: new object[,]
                {
                    { "MBBS", 1, "University of Medicine" },
                    { "MSW", 1, "Social Work University" },
                    { "MD", 2, "Medical College" },
                    { "PhD", 2, "Research Institute" },
                    { "MS", 3, "Surgical Institute" },
                    { "DM", 4, "Cardiology University" },
                    { "MCh", 5, "Neurosurgery Institute" },
                    { "BDS", 6, "Dental School" },
                    { "PharmD", 7, "Pharmacy College" },
                    { "DPT", 8, "Physical Therapy Institute" }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "DoctorId", "PatientId", "Rate", "ReviewText" },
                values: new object[,]
                {
                    { 1, 1, 1, 90, "Great experience with the doctor. Very knowledgeable and friendly." },
                    { 2, 1, 2, 95, "Highly recommend this doctor. Excellent bedside manner and thorough examination." },
                    { 3, 2, 3, 85, "Had a positive experience with the doctor. Listened to my concerns and provided helpful advice." },
                    { 4, 2, 4, 100, "Extremely satisfied with the doctor's expertise. Helped me understand my condition better." },
                    { 5, 1, 3, 80, "The doctor was friendly and professional. Explained the treatment plan clearly." }
                });

            migrationBuilder.InsertData(
                table: "Report",
                columns: new[] { "Id", "AppointmentId", "Date", "Description", "Prescription" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Patient presented with flu-like symptoms.", "Prescribed antiviral medication and rest." },
                    { 2, 2, new DateTime(2023, 6, 16, 15, 30, 0, 0, DateTimeKind.Unspecified), "Patient complained of joint pain and inflammation.", "Prescribed anti-inflammatory medication and physical therapy." },
                    { 3, 3, new DateTime(2023, 6, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), "Patient underwent routine check-up.", "No medication prescribed. Advised to maintain a healthy lifestyle." },
                    { 4, 4, new DateTime(2023, 6, 18, 14, 15, 0, 0, DateTimeKind.Unspecified), "Patient presented with symptoms of food poisoning.", "Prescribed antibiotics and advised to stay hydrated." },
                    { 5, 5, new DateTime(2023, 6, 19, 11, 30, 0, 0, DateTimeKind.Unspecified), "Patient complained of persistent headaches.", "Prescribed pain relievers and recommended further evaluation." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BranchDoctor",
                keyColumns: new[] { "BranchId", "DoctorId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BranchDoctor",
                keyColumns: new[] { "BranchId", "DoctorId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "BranchDoctor",
                keyColumns: new[] { "BranchId", "DoctorId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BranchDoctor",
                keyColumns: new[] { "BranchId", "DoctorId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BranchDoctor",
                keyColumns: new[] { "BranchId", "DoctorId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "BranchDoctor",
                keyColumns: new[] { "BranchId", "DoctorId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "BranchDoctor",
                keyColumns: new[] { "BranchId", "DoctorId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "BranchDoctor",
                keyColumns: new[] { "BranchId", "DoctorId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "BranchDoctor",
                keyColumns: new[] { "BranchId", "DoctorId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "BranchDoctor",
                keyColumns: new[] { "BranchId", "DoctorId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "BranchDoctor",
                keyColumns: new[] { "BranchId", "DoctorId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "BranchDoctor",
                keyColumns: new[] { "BranchId", "DoctorId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "DoctorQualification",
                keyColumns: new[] { "Certification", "DoctorId" },
                keyValues: new object[] { "MBBS", 1 });

            migrationBuilder.DeleteData(
                table: "DoctorQualification",
                keyColumns: new[] { "Certification", "DoctorId" },
                keyValues: new object[] { "MSW", 1 });

            migrationBuilder.DeleteData(
                table: "DoctorQualification",
                keyColumns: new[] { "Certification", "DoctorId" },
                keyValues: new object[] { "MD", 2 });

            migrationBuilder.DeleteData(
                table: "DoctorQualification",
                keyColumns: new[] { "Certification", "DoctorId" },
                keyValues: new object[] { "PhD", 2 });

            migrationBuilder.DeleteData(
                table: "DoctorQualification",
                keyColumns: new[] { "Certification", "DoctorId" },
                keyValues: new object[] { "MS", 3 });

            migrationBuilder.DeleteData(
                table: "DoctorQualification",
                keyColumns: new[] { "Certification", "DoctorId" },
                keyValues: new object[] { "DM", 4 });

            migrationBuilder.DeleteData(
                table: "DoctorQualification",
                keyColumns: new[] { "Certification", "DoctorId" },
                keyValues: new object[] { "MCh", 5 });

            migrationBuilder.DeleteData(
                table: "DoctorQualification",
                keyColumns: new[] { "Certification", "DoctorId" },
                keyValues: new object[] { "BDS", 6 });

            migrationBuilder.DeleteData(
                table: "DoctorQualification",
                keyColumns: new[] { "Certification", "DoctorId" },
                keyValues: new object[] { "PharmD", 7 });

            migrationBuilder.DeleteData(
                table: "DoctorQualification",
                keyColumns: new[] { "Certification", "DoctorId" },
                keyValues: new object[] { "DPT", 8 });

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BranchAddress",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BranchAddress",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BranchAddress",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BranchAddress",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clinic",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BranchAddress",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BranchAddress",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BranchAddress",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BranchAddress",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clinic",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clinic",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clinic",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clinic",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clinic",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BranchAddress",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
