using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.CoreLayer
{
    public class Hospital:User
    {
       
    public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();


    }
}
