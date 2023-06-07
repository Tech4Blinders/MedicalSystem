using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace MedicalSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Default
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("LocalConnection");
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
            builder.Services.AddScoped<IDoctorQualificationRepo,DoctorQualificationRepo>();
            builder.Services.AddScoped<IPatientRepo, PatientRepo>();
            builder.Services.AddScoped<IBranchDoctorRepo,BranchDoctorRepo>();

            builder.Services.AddScoped<IPatientManager,PatientManager>();
            builder.Services.AddScoped<IBranchDoctorManager, BranchDoctorManager>();
            builder.Services.AddScoped<IDoctorManager,DoctorManager>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddScoped<IAppointmentManager, AppointmentManager>();
            


            #region Middlewarees
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion
        }
    }
}