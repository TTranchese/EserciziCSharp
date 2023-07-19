using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models;

public class Ordine
{
    [Key]
    public int Id { get; set; }
    
    public int IdProdotto { get; set; }
    [ForeignKey(nameof(IdProdotto))]
    public Prodotto? Prodotto { get; set; }
    
    public string IdUtente { get; set; }
    [ForeignKey(nameof(IdUtente))]
    public IdentityUser? IdentityUser { get; set; }
}