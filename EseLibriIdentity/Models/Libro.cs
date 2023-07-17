using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EseLibriIdentity.Models;

public class Libro
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(200)]
    public string Titolo { get; set; }
    
    public int ID_Autore { get; set; }
    [ForeignKey(nameof(ID_Autore))]
    public Autore? Autore { get; set; }
    
    public int ID_Editore { get; set; }
    [ForeignKey(nameof(ID_Editore))]
    public Editore? Editore { get; set; }
    
}