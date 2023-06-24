using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.BusinessLayer;

public class LoginDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; } = string.Empty;
}
