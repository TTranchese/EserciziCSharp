using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CustomIdentity.Data;

public class CustomUser: IdentityUser
{
    [Required(ErrorMessage = "{0} e' obbligatorio!")]
    [MaxLength(100, ErrorMessage = "Massimo {1} caratteri!")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "{0} e' obbligatorio!")]
    [MaxLength(100, ErrorMessage = "Massimo {1} caratteri!")]
    public string Cognome { get; set; }
}