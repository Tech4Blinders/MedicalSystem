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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
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
                name: "zoomMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zoomMeetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    isOnline = table.Column<bool>(type: "bit", nullable: false),
                    ZoomMeetingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_zoomMeetings_ZoomMeetingId",
                        column: x => x.ZoomMeetingId,
                        principalTable: "zoomMeetings",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doctor_Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    ClinicId = table.Column<int>(type: "int", nullable: true),
                    OfflineCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OnlineCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
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
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_AvaliableAppointment_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
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
                        name: "FK_Branch_AspNetUsers_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branch_BranchAddress_BranchAddressId",
                        column: x => x.BranchAddressId,
                        principalTable: "BranchAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_DoctorQualification_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_Review_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                        name: "FK_BranchDoctor_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchDoctor_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 10, 0, "63615b3a-e1bb-4ede-94f9-42da8b84cc20", "Hospital", "stjude@example.com", false, "", false, null, "St. Jude Children's Research Hospital", null, null, null, null, false, null, false, null },
                    { 20, 0, "f65d0f64-8f52-4f10-9e6d-4c96eba9fd5d", "Hospital", "mountsinai@example.com", false, "", false, null, "Mount Sinai Hospital", null, null, null, null, false, null, false, null },
                    { 30, 0, "acbb728c-51de-4ef7-ab7a-4dccbd2a397a", "Hospital", "chop@example.com", false, "", false, null, "Children's Hospital of Philadelphia", null, null, null, null, false, null, false, null },
                    { 40, 0, "67d5945f-1c18-4523-abb3-cb4392e0ac54", "Hospital", "torontogeneral@example.com", false, "", false, null, "Toronto General Hospital", null, null, null, null, false, null, false, null },
                    { 50, 0, "8789f63e-f0dc-4949-a9d3-115addc3d703", "Hospital", "tmc@example.com", false, "", false, null, "Texas Medical Center", null, null, null, null, false, null, false, null },
                    { 60, 0, "de7c905d-3ce0-42f9-9e16-99d6ec8ec43f", "Hospital", "moffitt@example.com", false, "", false, null, "Moffitt Cancer Center", null, null, null, null, false, null, false, null },
                    { 70, 0, "a37c3541-7189-4a11-882f-d4668216fb7d", "Hospital", "barnesjewish@example.com", false, "", false, null, "Barnes-Jewish Hospital", null, null, null, null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "Gender", "Image", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 100, 0, 25, "d6784edb-3e8e-4d64-88f4-3e4b70d066a5", "Patient", "john@example.com", false, "M", "", false, null, "John Smith", null, null, null, "1234567890", false, null, false, null },
                    { 200, 0, 30, "31c52753-5114-4ea6-9925-4f14e92a8eb1", "Patient", "jane@example.com", false, "F", "", false, null, "Jane Doe", null, null, null, "9876543210", false, null, false, null },
                    { 300, 0, 40, "2a11c830-5624-4b68-8396-1e63868fe735", "Patient", "alex@example.com", false, "M", "", false, null, "Alex Johnson", null, null, null, "5555555555", false, null, false, null },
                    { 400, 0, 22, "9822f025-2e3e-4e89-8fd9-ba241189c017", "Patient", "emily@example.com", false, "F", "", false, null, "Emily Williams", null, null, null, "1112223333", false, null, false, null }
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
                table: "zoomMeetings",
                columns: new[] { "Id", "Duration", "MeetingId", "Password", "StartTime" },
                values: new object[] { 1, 60, "89944185248", "123", new DateTime(2023, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) });

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
                    { 1, 1, "Description for Family Medicine Clinic", "https://res.cloudinary.com/dhksv3uz9/image/upload/v1687355579/Medical%20System/R.jpg", 1001, "Family Medicine" },
                    { 2, 1, "Description for Dental Clinic", "https://res.cloudinary.com/dhksv3uz9/image/upload/v1687355579/Medical%20System/R.jpg", 1002, "Dentistry" },
                    { 3, 2, "Description for Internal Medicine Clinic", "https://res.cloudinary.com/dhksv3uz9/image/upload/v1687355579/Medical%20System/R.jpg", 1003, "Internal Medicine" },
                    { 4, 2, "Description for Orthopedic Clinic", "https://res.cloudinary.com/dhksv3uz9/image/upload/v1687355579/Medical%20System/R.jpg", 1004, "Orthopedics" },
                    { 5, 3, "Description for Cardiology Clinic", "https://res.cloudinary.com/dhksv3uz9/image/upload/v1687355579/Medical%20System/R.jpg", 1005, "Cardiology" },
                    { 6, 3, "Description for Pediatric Clinic", "https://res.cloudinary.com/dhksv3uz9/image/upload/v1687355579/Medical%20System/R.jpg", 1006, "Pediatrics" }
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
                    { 1, 0, "Dubai", 1, "f57f5ce4-4c12-4828-9dc8-5f65b3445896", "United Arab Emirates", 1, "Doctor", "ahmed.ali@example.com", false, "Male", "", false, null, "Dr. Ahmed Ali", null, null, 200m, 100m, null, "+971 123-456-7890", false, null, "123 Main St", false, null },
                    { 2, 0, "Abu Dhabi", 2, "9f2f510e-d901-4ea4-918a-15defbc5cf0b", "United Arab Emirates", 2, "Doctor", "fatima.hassan@example.com", false, "Female", "", false, null, "Dr. Fatima Hassan", null, null, 300m, 200m, null, "+971 987-654-3210", false, null, "456 Elm St", false, null },
                    { 3, 0, "Sharjah", 3, "dd19786f-b0e8-4f8f-804f-9cd2890ef277", "United Arab Emirates", 3, "Doctor", "ali.mahmoud@example.com", false, "Male", "", false, null, "Dr. Ali Mahmoud", null, null, 400m, 300m, null, "+971 555-123-4567", false, null, "789 Oak St", false, null },
                    { 4, 0, "Ajman", 4, "60154035-6162-4cc6-9057-6de1fca5708c", "United Arab Emirates", 4, "Doctor", "aisha.khan@example.com", false, "Female", "", false, null, "Dr. Aisha Khan", null, null, 500m, 400m, null, "+971 555-987-6543", false, null, "321 Pine St", false, null },
                    { 5, 0, "Ras Al Khaimah", 5, "8c0f7029-a05d-467e-a9dc-b61c3bfd67ea", "United Arab Emirates", 5, "Doctor", "omar.ahmed@example.com", false, "Male", "", false, null, "Dr. Omar Ahmed", null, null, 600m, 500m, null, "+971 555-567-8901", false, null, "987 Maple St", false, null },
                    { 6, 0, "Fujairah", 6, "d781f224-4bc6-48dd-a05a-c2bd0dd07a48", "United Arab Emirates", 6, "Doctor", "layla.hassan@example.com", false, "Female", "", false, null, "Dr. Layla Hassan", null, null, 700m, 600m, null, "+971 555-210-9876", false, null, "654 Walnut St", false, null },
                    { 7, 0, "Umm Al Quwain", 1, "39ac409e-70c2-47ac-8d8b-701161f25b04", "United Arab Emirates", 7, "Doctor", "ibrahim.khalid@example.com", false, "Male", "", false, null, "Dr. Ibrahim Khalid", null, null, 800m, 700m, null, "+971 555-876-5432", false, null, "210 Cedar St", false, null },
                    { 8, 0, "Al Ain", 2, "b229e8b8-0c7d-4550-ac2b-01f8876f08d9", "United Arab Emirates", 8, "Doctor", "sarah.ahmed@example.com", false, "Female", "", false, null, "Dr. Sarah Ahmed", null, null, 900m, 800m, null, "+971 555-432-1098", false, null, "876 Birch St", false, null }
                });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "AppointmentDate", "BranchId", "Cost", "DoctorId", "PatientId", "ZoomMeetingId", "isOnline" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 100, 1, 1, 1, true },
                    { 2, new DateTime(2023, 6, 16, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, 75, 2, 2, 1, true },
                    { 3, new DateTime(2023, 6, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, 120, 3, 3, 1, true },
                    { 4, new DateTime(2023, 6, 18, 14, 15, 0, 0, DateTimeKind.Unspecified), 4, 90, 4, 4, 1, true },
                    { 5, new DateTime(2023, 6, 19, 11, 30, 0, 0, DateTimeKind.Unspecified), 5, 80, 5, 1, 1, true }
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
                name: "IX_Appointment_ZoomMeetingId",
                table: "Appointment",
                column: "ZoomMeetingId");

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
                name: "IX_AspNetUsers_ClinicId",
                table: "AspNetUsers",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_DoctorId",
                table: "Appointment",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_PatientId",
                table: "Appointment",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Branch_BranchId",
                table: "Appointment",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clinic_ClinicId",
                table: "AspNetUsers",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Department_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_AspNetUsers_HospitalId",
                table: "Branch");

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
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "zoomMeetings");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "BranchAddress");
        }
    }
}
