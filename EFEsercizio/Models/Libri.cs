using System;
using System.Collections.Generic;

namespace EFEsercizio.Models;

public partial class Libri
{
    public int Id { get; set; }

    public string? Titolo { get; set; }

    public string? Autore { get; set; }

    public string? Editore { get; set; }

    public int? Anno { get; set; }

    public int? Scaffale { get; set; }

    public int? Piano { get; set; }

    public Libri()
    {
        
    }

    public Libri(string? titolo, string? autore, string? editore, int? anno, int? scaffale, int? piano)
    {
        Titolo = titolo;
        Autore = autore;
        Editore = editore;
        Anno = anno;
        Scaffale = scaffale;
        Piano = piano;
    }
}
