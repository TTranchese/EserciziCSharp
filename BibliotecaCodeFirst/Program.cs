using ConsoleApp1;

string risposta = "";
BibliotecaContext context = new BibliotecaContext();
while (risposta != "5")
{
    Console.WriteLine("1-Inserisci Autore");
    Console.WriteLine("2-Inserisci Editore");
    Console.WriteLine("3-Inserisci Libro");
    Console.WriteLine("4-Visualizza Libri");
    Console.WriteLine("5-Esci");
    Console.WriteLine("Cosa vuoi fare?");
    risposta = Console.ReadLine();


    switch (risposta)
    {
        case "1":
            InserisciAutore();
            break;
        case "2":
            InserisciEditore();
            break;
        case "3":
            InserisciLibro();
            break;
        case "4":
            VisualizzaLibri();
            break;
        case "5":
            break;
    }

    void InserisciAutore()
    {
        Autore autore = new Autore();
        Console.WriteLine("Inserisci nome: ");
        autore.Nome = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Inserisci cognome: ");
        autore.Cognome = Console.ReadLine() ?? string.Empty;
        context.Add(autore);
        context.SaveChanges();
    }

    void InserisciEditore()
    {
        Editore editore = new Editore();
        Console.WriteLine("Inserisci denominazione dell'editore: ");
        editore.Denominazione = Console.ReadLine() ?? string.Empty;
        context.Add(editore);
        context.SaveChanges();
    }

    void InserisciLibro()
    {
        Libro libro = new Libro();
        Console.WriteLine("Inserisci il titolo del libro: ");
        libro.Titolo = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Inserisci il nome dell'autore: ");
        string stringAutore = Console.ReadLine() ?? string.Empty;
        var autore = (from n in context.Autori
            where (n.Nome.Contains(stringAutore)) || (n.Cognome.Contains(stringAutore))
            select n).First();
        libro.ID_Autore = autore.Id;

        Console.WriteLine("Inserisci il nome dell'editore: ");
        string stringEditore = Console.ReadLine() ?? string.Empty;
        var editore = (from n in context.Editori
            where n.Denominazione.Contains(stringEditore)
            select n).First();
        libro.ID_Editore = editore.Id;

        context.Add(libro);
        context.SaveChanges();
    }

    void VisualizzaLibri()
    {
        var query =
            from libro in context.Libri
            join editore in context.Editori on libro.ID_Editore equals editore.Id
            join autore in context.Autori on libro.ID_Autore equals autore.Id
            select new
            {
                Id = libro.Id,
                Titolo = libro.Titolo,
                NomeAutore = libro.Autore.Nome + " "+libro.Autore.Cognome,
                Editore = libro.Editore.Denominazione
            };
        foreach (var VARIABLE in query)
        {
            Console.WriteLine(
                $"Id: {VARIABLE.Id}, Titolo: {VARIABLE.Titolo}, Autore: {VARIABLE.NomeAutore}, Editore: {VARIABLE.Editore}");
        }
    }
}