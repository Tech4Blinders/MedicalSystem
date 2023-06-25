using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace MedicalSystem.BusinessLayer;

public class RegisterDto
{
    //public RegisterDto(
    //   string name,
    //   string username,
    //   string email,
    //   string password,
    //   string phonenumber,
    //   string role)
    //{
    //    this.Name = name;
    //    this.UserName = username;
    //    this.Email = email;
    //    this.Password = password;
    //    this.PhoneNumber = phonenumber;
    //    this.Role = role;
    //}

    [MinLength(3)]
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string UserName { get; set; } = string.Empty;
    [DataType(DataType.EmailAddress)]
    [Required]
    public string Email { get; set; } = string.Empty;
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; } = string.Empty;
    [DataType(DataType.PhoneNumber)]
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    public string Role { get; set; } = string.Empty;
    public string? Gender { get; set; }
    public int? Age { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }

    public string? Street { get; set; }
    public int? DepartmentId { get;set; }

    public int? ClinicId { get; set; }

    public decimal? OfflineCost { get; set; }

    public decimal? OnlineCost { get; set; }
    public IFormFile? File { get; set; }
    public string? Image { get; set; } = string.Empty;

}
