using CloudinaryDotNet.Actions;
using MedicalSystem.Api.Services.AuthService;
using MedicalSystem.Api.Services.UploadImage;
using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MedicalSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Tech6Blinders";
                options.DefaultChallengeScheme = "Tech6Blinders";
            })
                .AddJwtBearer("Tech6Blinders", options =>
                {
                    string key = builder.Configuration.GetValue<string>("key") ?? string.Empty;
                    var keyinbytes = Encoding.ASCII.GetBytes(key);
                    var symmetricSecurityKey = new SymmetricSecurityKey(keyinbytes);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = symmetricSecurityKey,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            #region Default
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            builder.Services.AddDbContext<ApplicationDbContext>();
            builder.Services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IPatientManager, PatientManager>();
            builder.Services.AddScoped<IBranchDoctorManager, BranchDoctorManager>();
            builder.Services.AddScoped<IDoctorManager, DoctorManager>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IAppointmentManager, AppointmentManager>();
            builder.Services.AddScoped<IReportManager, ReportManager>();
            builder.Services.AddScoped<IClinicManager, ClinicManager>();
            builder.Services.AddScoped<IReviewManager, ReviewManager>();
            builder.Services.AddScoped<IBranchManager, BranchManager>();
            builder.Services.AddScoped<IBranchAddManager, BranchAddManager>();
            builder.Services.AddScoped<IAvaliableAppointmentManager, AvaliableAppointmentManager>();
            builder.Services.AddScoped<IDoctorQualificationManager, DoctorQualificationManager>();
            builder.Services.AddScoped<IAuthService, AuthSevice>();

            builder.Services.AddScoped<IUploadImg, UploadImg>();

            builder.Services.AddCors(option =>
            {
                option.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
                });
            });

            builder.Services.AddStripeInfrastructure(builder.Configuration);
            #region Middlewarees
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(options =>
            {
                options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();

            app.MapControllers();

            app.Run();
            #endregion
        }
    }
}