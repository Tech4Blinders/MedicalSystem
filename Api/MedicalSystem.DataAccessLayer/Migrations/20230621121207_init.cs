using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalSystem.DataAccessLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    BranchAddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_BranchAddress_BranchAddressId",
                        column: x => x.BranchAddressId,
                        principalTable: "BranchAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branch_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specilization = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinic_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    OfflineCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OnlineCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvaliableAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliableAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliableAppointment_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchDoctor",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    StaringDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchDoctor", x => new { x.DoctorId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_BranchDoctor_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchDoctor_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoctorQualification",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Certification = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CertificationFrom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorQualification", x => new { x.DoctorId, x.Certification });
                    table.ForeignKey(
                        name: "FK_DoctorQualification_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Prescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "Age", "Email", "Gender", "Image", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 25, "john@example.com", "M", "", "John Smith", "1234567890" },
                    { 2, 30, "jane@example.com", "F", "", "Jane Doe", "9876543210" },
                    { 3, 40, "alex@example.com", "M", "", "Alex Johnson", "5555555555" },
                    { 4, 22, "emily@example.com", "F", "", "Emily Williams", "1112223333" }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "BranchAddressId", "HospitalId", "Image", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, 1, "", "Branch A", "1234567890" },
                    { 2, 2, 2, "", "Branch B", "9876543210" },
                    { 3, 3, 3, "", "Branch C", "5555555555" },
                    { 4, 4, 4, "", "Branch D", "1112223333" },
                    { 5, 5, 1, "", "Branch E", "5646546546" },
                    { 6, 6, 2, "", "Branch F", "1555154654" },
                    { 7, 7, 3, "", "Branch J", "7797988521" },
                    { 8, 8, 4, "", "Branch H", "6597451215" },
                    { 9, 9, 1, "", "Branch I", "1564989848" }
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
                table: "Doctor",
                columns: new[] { "Id", "City", "ClinicId", "Country", "DepartmentId", "Email", "Gender", "Image", "Name", "OfflineCost", "OnlineCost", "PhoneNumber", "Street" },
                values: new object[,]
                {
                    { 1, "Dubai", 1, "United Arab Emirates", 1, "ahmed.ali@example.com", "Male", "", "Dr. Ahmed Ali", 200m, 100m, "+971 123-456-7890", "123 Main St" },
                    { 2, "Abu Dhabi", 2, "United Arab Emirates", 2, "fatima.hassan@example.com", "Female", "", "Dr. Fatima Hassan", 300m, 200m, "+971 987-654-3210", "456 Elm St" },
                    { 3, "Sharjah", 3, "United Arab Emirates", 3, "ali.mahmoud@example.com", "Male", "", "Dr. Ali Mahmoud", 400m, 300m, "+971 555-123-4567", "789 Oak St" },
                    { 4, "Ajman", 4, "United Arab Emirates", 4, "aisha.khan@example.com", "Female", "", "Dr. Aisha Khan", 500m, 400m, "+971 555-987-6543", "321 Pine St" },
                    { 5, "Ras Al Khaimah", 5, "United Arab Emirates", 5, "omar.ahmed@example.com", "Male", "", "Dr. Omar Ahmed", 600m, 500m, "+971 555-567-8901", "987 Maple St" },
                    { 6, "Fujairah", 6, "United Arab Emirates", 6, "layla.hassan@example.com", "Female", "", "Dr. Layla Hassan", 700m, 600m, "+971 555-210-9876", "654 Walnut St" },
                    { 7, "Umm Al Quwain", 1, "United Arab Emirates", 7, "ibrahim.khalid@example.com", "Male", "", "Dr. Ibrahim Khalid", 800m, 700m, "+971 555-876-5432", "210 Cedar St" },
                    { 8, "Al Ain", 2, "United Arab Emirates", 8, "sarah.ahmed@example.com", "Female", "", "Dr. Sarah Ahmed", 900m, 800m, "+971 555-432-1098", "876 Birch St" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_BranchId",
                table: "Appointment",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliableAppointment_DoctorId",
                table: "AvaliableAppointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_BranchAddressId",
                table: "Branch",
                column: "BranchAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branch_HospitalId",
                table: "Branch",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchDoctor_BranchId",
                table: "BranchDoctor",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_BranchId",
                table: "Clinic",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_BranchId",
                table: "Department",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ClinicId",
                table: "Doctor",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_DepartmentId",
                table: "Doctor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_AppointmentId",
                table: "Report",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_DoctorId",
                table: "Review",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_PatientId",
                table: "Review",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AvaliableAppointment");

            migrationBuilder.DropTable(
                name: "BranchDoctor");

            migrationBuilder.DropTable(
                name: "DoctorQualification");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "BranchAddress");

            migrationBuilder.DropTable(
                name: "Hospital");
        }
    }
}
