using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Prodotto
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Nome { get; set; }
    
    [Required]
    public double Prezzo { get; set; }
}