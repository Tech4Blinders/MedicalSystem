using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalSystem.DataAccessLayer.Migrations
{
    public partial class SeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 10, 0, "e9b15875-c2cb-4801-86b1-9c3cf5078b0e", "Hospital", "stjude@example.com", false, "", false, null, "St. Jude Children's Research Hospital", null, null, null, null, false, null, false, null },
                    { 20, 0, "85f0e798-e385-470a-8dc4-b830aa48c03f", "Hospital", "mountsinai@example.com", false, "", false, null, "Mount Sinai Hospital", null, null, null, null, false, null, false, null },
                    { 30, 0, "889b1d18-fe89-4155-8577-42e9ddcd6516", "Hospital", "chop@example.com", false, "", false, null, "Children's Hospital of Philadelphia", null, null, null, null, false, null, false, null },
                    { 40, 0, "7c628e42-6697-453f-82cd-aecd7e2621a5", "Hospital", "torontogeneral@example.com", false, "", false, null, "Toronto General Hospital", null, null, null, null, false, null, false, null },
                    { 50, 0, "2038ef2f-71b4-4184-a1ae-a06a942161fe", "Hospital", "tmc@example.com", false, "", false, null, "Texas Medical Center", null, null, null, null, false, null, false, null },
                    { 60, 0, "9f49fd9f-ea81-4085-98b7-153520791b52", "Hospital", "moffitt@example.com", false, "", false, null, "Moffitt Cancer Center", null, null, null, null, false, null, false, null },
                    { 70, 0, "b23a2980-5dc5-498e-82ed-588796f36cf5", "Hospital", "barnesjewish@example.com", false, "", false, null, "Barnes-Jewish Hospital", null, null, null, null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "Gender", "Image", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 100, 0, 25, "c669f66a-5b13-4cc7-b878-7a958f830214", "Patient", "john@example.com", false, "M", "", false, null, "John Smith", null, null, null, "1234567890", false, null, false, null },
                    { 200, 0, 30, "efa1fbc3-883a-4d08-99b8-e08ebb6cca01", "Patient", "jane@example.com", false, "F", "", false, null, "Jane Doe", null, null, null, "9876543210", false, null, false, null },
                    { 300, 0, 40, "3e0abf8b-12fd-41a8-b5e7-83095a95fbe8", "Patient", "alex@example.com", false, "M", "", false, null, "Alex Johnson", null, null, null, "5555555555", false, null, false, null },
                    { 400, 0, 22, "21715648-dcc7-443e-abc4-2f5d75cdce12", "Patient", "emily@example.com", false, "F", "", false, null, "Emily Williams", null, null, null, "1112223333", false, null, false, null }
                });

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
                table: "Branch",
                columns: new[] { "Id", "BranchAddressId", "HospitalId", "Image", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, 10, "", "Branch A", "1234567890" },
                    { 2, 2, 20, "", "Branch B", "9876543210" },
                    { 3, 3, 30, "", "Branch C", "5555555555" },
                    { 4, 4, 40, "", "Branch D", "1112223333" },
                    { 5, 5, 10, "", "Branch E", "5646546546" },
                    { 6, 6, 20, "", "Branch F", "1555154654" },
                    { 7, 7, 30, "", "Branch J", "7797988521" },
                    { 8, 8, 40, "", "Branch H", "6597451215" },
                    { 9, 9, 10, "", "Branch I", "1564989848" }
                });

            migrationBuilder.InsertData(
                table: "Clinic",
                columns: new[] { "Id", "BranchId", "Description", "Image", "RoomNumber", "Specilization" },
                values: new object[,]
                {
                    { 1, 1, "Description for Family Medicine Clinic", "", 1001, "Family Medicine" },
                    { 2, 1, "Description for Dental Clinic", "", 1002, "Dentistry" },
                    { 3, 2, "Description for Internal Medicine Clinic", "", 1003, "Internal Medicine" },
                    { 4, 2, "Description for Orthopedic Clinic", "", 1004, "Orthopedics" },
                    { 5, 3, "Description for Cardiology Clinic", "", 1005, "Cardiology" },
                    { 6, 3, "Description for Pediatric Clinic", "", 1006, "Pediatrics" }
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ClinicId", "ConcurrencyStamp", "Country", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "Doctor_Gender", "Image", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "OfflineCost", "OnlineCost", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "Dubai", 1, "90a642eb-6041-4c06-834b-56f06681ea45", "United Arab Emirates", 1, "Doctor", "ahmed.ali@example.com", false, "Male", "", false, null, "Dr. Ahmed Ali", null, null, 200m, 100m, null, "+971 123-456-7890", false, null, "123 Main St", false, null },
                    { 2, 0, "Abu Dhabi", 2, "44ca18c8-424e-4b4b-92b2-c226c47a0c0b", "United Arab Emirates", 2, "Doctor", "fatima.hassan@example.com", false, "Female", "", false, null, "Dr. Fatima Hassan", null, null, 300m, 200m, null, "+971 987-654-3210", false, null, "456 Elm St", false, null },
                    { 3, 0, "Sharjah", 3, "bdd5b8e9-9413-4a31-8ed8-a82050cb07e1", "United Arab Emirates", 3, "Doctor", "ali.mahmoud@example.com", false, "Male", "", false, null, "Dr. Ali Mahmoud", null, null, 400m, 300m, null, "+971 555-123-4567", false, null, "789 Oak St", false, null },
                    { 4, 0, "Ajman", 4, "4f089c85-99b7-4a87-b2a1-ec8df18a5afc", "United Arab Emirates", 4, "Doctor", "aisha.khan@example.com", false, "Female", "", false, null, "Dr. Aisha Khan", null, null, 500m, 400m, null, "+971 555-987-6543", false, null, "321 Pine St", false, null },
                    { 5, 0, "Ras Al Khaimah", 5, "f23edd18-e0fe-4450-9ab2-97bcf1c594bb", "United Arab Emirates", 5, "Doctor", "omar.ahmed@example.com", false, "Male", "", false, null, "Dr. Omar Ahmed", null, null, 600m, 500m, null, "+971 555-567-8901", false, null, "987 Maple St", false, null },
                    { 6, 0, "Fujairah", 6, "16611eb1-322c-40cc-b798-d2266ec872e6", "United Arab Emirates", 6, "Doctor", "layla.hassan@example.com", false, "Female", "", false, null, "Dr. Layla Hassan", null, null, 700m, 600m, null, "+971 555-210-9876", false, null, "654 Walnut St", false, null },
                    { 7, 0, "Umm Al Quwain", 1, "6650de46-cd05-4563-934b-3f6fc39f6fa7", "United Arab Emirates", 7, "Doctor", "ibrahim.khalid@example.com", false, "Male", "", false, null, "Dr. Ibrahim Khalid", null, null, 800m, 700m, null, "+971 555-876-5432", false, null, "210 Cedar St", false, null },
                    { 8, 0, "Al Ain", 2, "11c60080-19b9-41e2-a46f-4f79c343ffb2", "United Arab Emirates", 8, "Doctor", "sarah.ahmed@example.com", false, "Female", "", false, null, "Dr. Sarah Ahmed", null, null, 900m, 800m, null, "+971 555-432-1098", false, null, "876 Birch St", false, null }
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
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 400);

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
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8);

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
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

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
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 40);

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
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "BranchAddress",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BranchAddress",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BranchAddress",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
