using CloudinaryDotNet.Actions;
using MedicalSystem.Api.Services.AuthService;
using MedicalSystem.Api.Services.Helper;
using MedicalSystem.Api.Services;
using MedicalSystem.Api.Services.UploadImage;
using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Stripe;
using Stripe.BillingPortal;
using System.Security.Claims;
using System.Text;

namespace MedicalSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
           

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Tech6Blinders";
                options.DefaultChallengeScheme = "Tech6Blinders";
            })
                .AddJwtBearer("Tech6Blinders", options =>
                {
                    //string key = builder.Configuration["JWT:key"]; 
                    //var keyInBytes = Encoding.ASCII.GetBytes(key);
                    //var symmetricSecurityKey = new SymmetricSecurityKey(keyInBytes);
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                      
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"] ,
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))


                    };
                });

            builder.Services.AddAuthorization(options =>
            {
             options.AddPolicy("Patient", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "Doctor", "Patient"));
             options.AddPolicy("Doctor", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "Doctor"));
                options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin")); 
            });
            #region Default
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "Medico App", Version = "v1" });
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Set your JWT Bearer token on textbox ",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {jwtSecurityScheme, Array.Empty<string>()}
            });

            });
            #endregion

            builder.Services.AddDbContext<ApplicationDbContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IPatientManager, PatientManager>();
            builder.Services.AddScoped<IBranchDoctorManager, BranchDoctorManager>();
            builder.Services.AddScoped<IDoctorManager, DoctorManager>();
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            builder.Services.AddScoped<IAppointmentManager, AppointmentManager>();
            builder.Services.AddScoped<IReportManager, ReportManager>();
            builder.Services.AddScoped<IClinicManager, ClinicManager>();
            builder.Services.AddScoped<IReviewManager, ReviewManager>();
            builder.Services.AddScoped<IBranchManager, BranchManager>();
            builder.Services.AddScoped<IBranchAddManager, BranchAddManager>();
            builder.Services.AddScoped<IAvaliableAppointmentManager, AvaliableAppointmentManager>();
            builder.Services.AddScoped<IDoctorQualificationManager, DoctorQualificationManager>();
            builder.Services.AddScoped<IUploadImg, UploadImg>();
            #region Jwt
            builder.Services.AddScoped<IAuthService, AuthSevice>();
            builder.Services.Configure<Jwt>(builder.Configuration.GetSection("JWT"));
            #endregion
            builder.Services.AddScoped<IAuthService, AuthSevice>();

            builder.Services.AddScoped<IZoomMeetingManager,ZoomMeetingManager>();


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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medico App v1"));
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