using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1;

public class Editore
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(200)]
    public string Denominazione { get; set; }
}