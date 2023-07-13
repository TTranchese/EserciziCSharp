using System;
using System.Collections.Generic;

namespace ProdottiMusicali.Models;

public partial class Cd1
{
    public int Id { get; set; }

    public string? Titolo { get; set; }

    public string? Artista { get; set; }

    public int? Anno { get; set; }

    public override string ToString()
    {
        return "Id: " + Id + "\t||\t" + "Titolo: " + Titolo + "\t||\t" + "Artista: " + Artista + "\t||\t" + "Anno: " + Anno + "\t\n";
    }
}
