using System.ComponentModel.DataAnnotations;

namespace EseLibriIdentity.Models;

public class Autore
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    [Required]
    [MaxLength(100)]
    public string Cognome { get; set; }
}