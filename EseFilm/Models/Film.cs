using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EseFilm.Models;

public class Film
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "{0} e' obbligatorio!")]
    [MaxLength(200, ErrorMessage ="Massimo {1} caratteri!")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "{0} e' obbligatorio!")]
    [Range(1800, 2023, ErrorMessage = "L'{0} deve essere compreso tra {1} e {2}")]
    public int Anno { get; set; }

    [MaxLength(256)]
    public string? Locandina { get; set; }
    
    [NotMapped]
    public IFormFile? FileLocandina { get; set; }

}