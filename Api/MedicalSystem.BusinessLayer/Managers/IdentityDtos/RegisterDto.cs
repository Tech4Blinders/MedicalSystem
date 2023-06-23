using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MedicalSystem.BusinessLayer; 

public class RegisterDto
{
    public RegisterDto(
       string name,
       string username,
       string email,
       string password,
       string phonenumber,
       string role)
    {
        this.Name = name;
        this.UserName = username;
        this.Email = email;
        this.Password = password;
        this.PhoneNumber = phonenumber;
        this.Role = role;
    }

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
}
