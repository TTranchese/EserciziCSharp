using System;
using System.Collections.Generic;

namespace EFEsercizio.Models;

public partial class Cd
{
    public int Id { get; set; }

    public string? Titolo { get; set; }

    public string? Artista { get; set; }

    public int? Anno { get; set; }
}
